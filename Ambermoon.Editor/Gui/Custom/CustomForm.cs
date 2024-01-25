namespace Ambermoon.Editor.Gui.Custom {
  public partial class CustomForm : Form {
    #region --- constructor -----------------------------------------------------------------------
    public CustomForm() {
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
    }
    #endregion
  }
}