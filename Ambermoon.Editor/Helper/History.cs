using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Helper {
  internal class History {
    #region --- events ----------------------------------------------------------------------------
    public event Action? UndoGotFilled;
    public event Action? UndoGotEmpty;
    public event Action? RedoGotFilled;
    public event Action? RedoGotEmpty;
    #endregion
    #region --- fields ----------------------------------------------------------------------------
    private          IAction?              savedAtAction = null;
    private readonly DropOutStack<IAction> actions       = new(HistorySize);
    private readonly DropOutStack<IAction> undoneActions = new(HistorySize);
    #endregion
    #region --- properties ------------------------------------------------------------------------
    public bool Dirty => (savedAtAction != null && actions.Count == 0) || (actions.Count != 0 && savedAtAction != actions.Peek());
    public const int HistorySize = 128;
    #endregion

    #region --- clear -----------------------------------------------------------------------------
    public void Clear() {
      actions.Clear();
      savedAtAction = null;
    }
    #endregion
    #region --- do action -------------------------------------------------------------------------
    public void DoAction(IAction action) {
      if (undoneActions.Count != 0) {
        undoneActions.Clear();
        RedoGotEmpty?.Invoke();
      }

      actions.Push(action);
      action.Do();

      if (actions.Count == 1)
        UndoGotFilled?.Invoke();
    }
    #endregion
    #region --- get redo names---------------------------------------------------------------------
    public string[] GetRedoNames() {
      return undoneActions.Select(action => action.UndoDisplayName).ToArray();
    }
    #endregion
    #region --- get undo names --------------------------------------------------------------------
    public string[] GetUndoNames() {
      return actions.Select(action => action.DisplayName).ToArray();
    }
    #endregion
    #region --- redo ------------------------------------------------------------------------------
    public void Redo() {
      var action = undoneActions.Pop();
      actions.Push(action);
      action.Redo();

      if (actions.Count == 1)
        UndoGotFilled?.Invoke();
      if (undoneActions.Count == 0)
        RedoGotEmpty?.Invoke();
    }
    #endregion
    #region --- save ------------------------------------------------------------------------------
    public void Save() => savedAtAction = actions.Peek();
    #endregion
    #region --- undo ------------------------------------------------------------------------------
    public void Undo() {
      if (actions.Count == 0)
        return;

      var undoAction = actions.Pop();
      undoAction.Undo();
      undoneActions.Push(undoAction);

      if (actions.Count == 0)
        UndoGotEmpty?.Invoke();
      if (undoneActions.Count == 1)
        RedoGotFilled?.Invoke();
    }
    #endregion
  }
}