using Ambermoon.Editor.Extensions;

namespace Ambermoon.Editor.Gui.Custom {
  public partial class CustomForm : Form {
    #region --- constructor -----------------------------------------------------------------------
    public CustomForm() {
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);
      InitializeComponent();
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      SetStyle(
        ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint,
        true
      );
    }
    #endregion
    #region --- on shown --------------------------------------------------------------------------
    protected override void OnShown(EventArgs e) {
      base.OnShown(e);

      Refresh();
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
    }
    #endregion
  }
}