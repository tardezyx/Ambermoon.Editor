namespace Ambermoon.Editor.Helper {
  public interface IAction {
    string DisplayName { get; }
    string UndoDisplayName { get; }
    void Do();
    void Undo();
    void Redo();
  }
}