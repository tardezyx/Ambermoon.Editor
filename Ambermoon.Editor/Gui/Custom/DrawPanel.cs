namespace System.Windows.Forms {
  public class DrawPanel : Panel {
    public DrawPanel() {
      SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }
  }
}