using Ambermoon.Editor.Extensions;
using System.Runtime.InteropServices;

namespace System.Windows.Forms {
  // Source: https://psycodedeveloper.wordpress.com/2013/05/26/how-to-load-an-embedded-cursor-from-resources-in-c-windows-forms/

  public static class CursorResourceLoader {
    #region --- load embedded cursor --------------------------------------------------------------
    public static Cursor LoadEmbeddedCursor(byte[] cursorResource, int imageIndex = 0) {
      IntPtr   cursorHandle   = IntPtr.Zero;
      IntPtr   iconImage      = IntPtr.Zero;
      GCHandle resourceHandle = GCHandle.Alloc(cursorResource, GCHandleType.Pinned);

      try {
        if (
          Marshal.PtrToStructure(
            resourceHandle.AddrOfPinnedObject(),
            typeof(User32.IconHeader)
          ) is User32.IconHeader header
        ) {
          ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(imageIndex, header.count);

          nint iconInfoPtr = resourceHandle.AddrOfPinnedObject()
            + Marshal.SizeOf(typeof(User32.IconHeader))
            + imageIndex * Marshal.SizeOf(typeof(User32.IconInfo));
        
          if (
            Marshal.PtrToStructure(
              iconInfoPtr,
              typeof(User32.IconInfo)
            ) is User32.IconInfo info
          ) { 
            iconImage = Marshal.AllocHGlobal(info.size + 4);
            Marshal.WriteInt16(iconImage + 0, info.hotspot_x);
            Marshal.WriteInt16(iconImage + 2, info.hotspot_y);
            Marshal.Copy(cursorResource, info.offset, iconImage + 4, info.size);

            cursorHandle = User32.CreateIconFromResource(iconImage, info.size + 4, false, 0x30000);
          }
        }

        return new Cursor(cursorHandle);
      } finally {
        if (cursorHandle != IntPtr.Zero) {
          User32.DestroyIcon(cursorHandle);
        }

        if (iconImage != IntPtr.Zero) {
          Marshal.FreeHGlobal(iconImage);
        }

        if (resourceHandle.IsAllocated) {
          resourceHandle.Free();
        }
      }
    }
    #endregion
  }
}