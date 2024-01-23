namespace System.Windows.Forms {
  public class MapDrawPanel : ScrollDrawPanel {
    protected override CreateParams CreateParams {
      get {
        var cp = base.CreateParams;
        cp.Style |= 0x00300000; // WS_HSCROLL | WS_VSCROLL
        return cp;
      }
    }
  }
}