using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Ambermoon.Editor.Extensions {
  public static partial class Msvcrt {
    #region --- dll import: memcmp ----------------------------------------------------------------
    [LibraryImport("msvcrt.dll")]
    private static partial int memcmp(IntPtr b1, IntPtr b2, long count);
    #endregion

    #region --- are bitmaps equal -----------------------------------------------------------------
    public static bool AreBitmapsEqual(Bitmap bitmap1, Bitmap bitmap2) {
      if (bitmap1 is null != bitmap2 is null) {
        return false;
      }

      // only true if both are null due to the check before
      // but needed to prevent further null warnings
      if (bitmap1 is null || bitmap2 is null) {
        return true;
      }
      
      if (bitmap1.Size != bitmap2.Size) {
        return false;
      }

      BitmapData bitmap1data = bitmap1.LockBits(
        new Rectangle(
          new Point(0, 0),
          bitmap1.Size
        ),
        ImageLockMode.ReadOnly,
        PixelFormat.Format32bppArgb
      );

      BitmapData bitmap2data = bitmap2.LockBits(
        new Rectangle(
          new Point(0, 0),
          bitmap2.Size
        ),
        ImageLockMode.ReadOnly,
        PixelFormat.Format32bppArgb
      );

      try {
        IntPtr bitmap1scanline = bitmap1data.Scan0;
        IntPtr bitmap2scanline = bitmap2data.Scan0;

        return memcmp(
          bitmap1scanline,
          bitmap2scanline,
          bitmap1data.Stride * bitmap1.Height
        ) == 0;
      } finally {
        bitmap1.UnlockBits(bitmap1data);
        bitmap2.UnlockBits(bitmap2data);
      }
    }
    #endregion
  }
}