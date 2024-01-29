using System.Drawing.Drawing2D;

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

      Bitmap result = new(rectangle.Width, rectangle.Height);
      Graphics graph = Graphics.FromImage(result);

      graph.InterpolationMode = InterpolationMode.High;
      graph.CompositingQuality = CompositingQuality.HighQuality;
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
  }
}