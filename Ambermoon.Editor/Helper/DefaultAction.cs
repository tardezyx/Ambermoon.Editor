namespace Ambermoon.Editor.Helper {
  public class DefaultAction(
    string       displayName,
    string       undoDisplayName,
    Action<bool> doAction,
    Action       undoAction
  ) : IAction {
    public string DisplayName     { get; } = displayName;
    public string UndoDisplayName { get; } = undoDisplayName;

    public void Do()   => doAction?.Invoke(false);
    public void Redo() => doAction?.Invoke(true);
    public void Undo() => undoAction?.Invoke();
  }
}