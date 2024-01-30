using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Ambermoon.Editor.Extensions {
  internal static partial class Extensions {
    #region --- get scaled bitmap (via factor) ----------------------------------------------------
    internal static Bitmap GetScaledBitmap(this Bitmap source, float factor) {
      if (factor == 1 || factor <= 0) {
        return source;
      }

      Rectangle rectangle = new(
        0,
        0,
        (int)(source.Width * factor),
        (int)(source.Height * factor)
      );

      Bitmap result = new(
        rectangle.Width,
        rectangle.Height,
        PixelFormat.Format32bppArgb
      );

      Graphics graph = Graphics.FromImage(result);
      graph.CompositingQuality = CompositingQuality.HighQuality;
      graph.InterpolationMode = InterpolationMode.NearestNeighbor;
      graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graph.SmoothingMode = SmoothingMode.HighQuality;
      graph.DrawImage(source, rectangle);

      return result;
    }
    #endregion
    #region --- get scaled bitmap (via width & height) --------------------------------------------
    internal static Bitmap GetScaledBitmap(this Bitmap source, int width, int height) {
      return source.GetScaledBitmap(
        Math.Min(
          width  / source.Width,
          height / source.Height
        )
      );
    }
    #endregion
    #region --- get icon (via width & height) -----------------------------------------------------
    internal static Icon? GetIcon(this Bitmap source, int width, int height) {
      Icon? result = null;

      float factor = Math.Min(
        width  / source.Width,
        height / source.Height
      );

      if (source.GetScaledBitmap(factor)?.GetHicon() is IntPtr hIcon) {
        result = (Icon?)Icon.FromHandle(hIcon).Clone();
        User32.DestroyIcon(hIcon);
      }

      return result;
    }
    #endregion
  }
}