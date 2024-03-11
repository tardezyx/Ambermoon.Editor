using System.Drawing.Drawing2D;

namespace System.Windows.Forms {
  public class ExtendedPictureBox : PictureBox {
    #region --- on paint --------------------------------------------------------------------------
    protected override void OnPaint(PaintEventArgs paintEventArgs) {
      paintEventArgs.Graphics.CompositingQuality = CompositingQuality.HighQuality;
      paintEventArgs.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
      paintEventArgs.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      paintEventArgs.Graphics.SmoothingMode = SmoothingMode.HighQuality;

      base.OnPaint(paintEventArgs);
    }
    #endregion
    #region --- on paint background ---------------------------------------------------------------
    protected override void OnPaintBackground(PaintEventArgs pevent) {
      pevent.Graphics.CompositingQuality = CompositingQuality.HighQuality;
      pevent.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
      pevent.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
      pevent.Graphics.SmoothingMode = SmoothingMode.HighQuality;

      base.OnPaintBackground(pevent);
    }
    #endregion
  }
}