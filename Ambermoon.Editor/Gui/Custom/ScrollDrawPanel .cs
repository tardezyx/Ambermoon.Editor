namespace System.Windows.Forms {
  public class ScrollDrawPanel : DrawPanel {
    public ScrollDrawPanel() { }

    protected override CreateParams CreateParams {
      get {
        var cp = base.CreateParams;
        cp.Style |= 0x00200000; // WS_VSCROLL
        return cp;
      }
    }
  }
}