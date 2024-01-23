using Ambermoon.Data;
using Ambermoon.Data.Legacy.Serialization;
using Ambermoon.Data.Serialization;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Ambermoon.Editor.Helper {
  internal class ImageCache {
    #region --- fields ----------------------------------------------------------------------------
    // key1: tileset index | key2: graphic index | key3: palette index
    private        readonly Dictionary<uint, Dictionary<uint, Dictionary<uint, Bitmap>>> _images = [];
    private static readonly GraphicReader                                                _graphicReader = new();
    private        readonly Dictionary<uint, Graphic>                                    _palettes;
    private const           int                                                          _sizePerImage = 16 * 16 * 5 / 8;
    private        readonly Dictionary<uint, IDataReader>                                _tilesets = [];

    private static readonly GraphicInfo _paletteGraphicInfo = new() {
      Alpha         = false,
      GraphicFormat = GraphicFormat.XRGB16,
      Width         = 32,
      Height        = 1
    };

    private static readonly GraphicInfo _tileGraphicInfo = new() {
      Alpha         = true,
      GraphicFormat = GraphicFormat.Palette5Bit,
      Width         = 16,
      Height        = 16
    };
    #endregion
    #region --- properties ------------------------------------------------------------------------
    // TODO: Maybe allow adding new palettes later
    public int PaletteCount => _palettes.Count;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public ImageCache(ILegacyGameData gameData) {
      IFileContainer icons1 = gameData.Files["1Icon_gfx.amb"];
      IFileContainer icons2 = gameData.Files["2Icon_gfx.amb"];
      IFileContainer icons3 = gameData.Files["3Icon_gfx.amb"];

      _palettes = gameData.Files["Palettes.amb"].Files
        .ToDictionary(f => (uint)f.Key, f => {
          f.Value.Position = 0; return ReadPalette(f.Value);
        }
      );

      AddTilesets(icons1);
      AddTilesets(icons2);
      AddTilesets(icons3);

      void AddTilesets(IFileContainer container) {
        foreach (KeyValuePair<int, IDataReader> file in container.Files.Where(x => x.Value.Size > 0)) {
          _tilesets.Add((uint)file.Key, file.Value);
        }
      }
    }
    #endregion
    #region --- get bitplane data -----------------------------------------------------------------
    public byte[] GetBitplaneData(uint tilesetIndex, uint graphicIndex) {
      IDataReader dataReader = _tilesets[tilesetIndex];
      dataReader.Position = (int)graphicIndex * _sizePerImage;
      
      return dataReader
        .ReadBytes(_sizePerImage);
    }
    #endregion
    #region --- get image -------------------------------------------------------------------------
    public Bitmap GetImage(uint tilesetIndex, uint graphicIndex, uint paletteIndex) {
      if (!_images.TryGetValue(tilesetIndex, out Dictionary<uint, Dictionary<uint, Bitmap>>? tileset)) {
        Bitmap image = LoadImageViaGraphicIndex(
          _tilesets[tilesetIndex],
          graphicIndex,
          _palettes[paletteIndex],
          true
        );

        _images.Add(
          tilesetIndex,
          new Dictionary<uint, Dictionary<uint, Bitmap>> {
            {
              graphicIndex, new Dictionary<uint, Bitmap> {
                {
                  paletteIndex, image
                }
              }
            }
          }
        );

        return image;
      } else if (!tileset.TryGetValue(graphicIndex, out Dictionary<uint, Bitmap>? graphic)) {
        Bitmap image = LoadImageViaGraphicIndex(
          _tilesets[tilesetIndex],
          graphicIndex,
          _palettes[paletteIndex],
          true
        );

        tileset.Add(
          graphicIndex,
          new Dictionary<uint, Bitmap> {
            {
              paletteIndex, image
            }
          }
        );

        return image;
      } else if (!graphic.TryGetValue(paletteIndex, out Bitmap? image)) {
        image = LoadImageViaGraphicIndex(
          _tilesets[tilesetIndex],
          graphicIndex,
          _palettes[paletteIndex],
          true
        );
        
        graphic.Add(paletteIndex, image);
        
        return image;
      } else {
        return image;
      }
    }
    #endregion
    #region --- get image count -------------------------------------------------------------------
    public int GetImageCount(uint tilesetIndex) {
      return _tilesets[tilesetIndex].Size / _sizePerImage;
    }
    #endregion
    #region --- get palette color -----------------------------------------------------------------
    public Color GetPaletteColor(uint paletteIndex, uint colorIndex) {
      colorIndex %= 32;

      int r = _palettes[paletteIndex].Data[colorIndex * 4 + 0];
      int g = _palettes[paletteIndex].Data[colorIndex * 4 + 1];
      int b = _palettes[paletteIndex].Data[colorIndex * 4 + 2];

      return Color.FromArgb(r, g, b);
    }
    #endregion
    #region --- get palette colors ----------------------------------------------------------------
    public Color[] GetPaletteColors(uint index) {
      return Enumerable
        .Range(0, 32)
        .Select(i => GetPaletteColor(index, (uint)i))
        .ToArray();
    }
    #endregion
    #region --- get pixel data --------------------------------------------------------------------
    private static byte[] GetPixelData(Graphic graphic, Graphic palette, bool alpha) {
      byte[] pixelData = new byte[graphic.Width * graphic.Height * 4];

      for (int y = 0; y < graphic.Height; ++y) {
        for (int x = 0; x < graphic.Width; ++x) {
          int index = x + y * graphic.Width;
          int dIndex = index << 2;
          index = graphic.Data[index] << 2;

          if (alpha && index == 0) {
            pixelData[dIndex + 0] = 0;
            pixelData[dIndex + 1] = 0;
            pixelData[dIndex + 2] = 0;
            pixelData[dIndex + 3] = 0;
          } else {
            pixelData[dIndex + 2] = palette.Data[index];
            pixelData[dIndex + 1] = palette.Data[index + 1];
            pixelData[dIndex + 0] = palette.Data[index + 2];
            pixelData[dIndex + 3] = palette.Data[index + 3];
          }
        }
      }

      return pixelData;
    }
    #endregion
    #region --- graphic to bitmap -----------------------------------------------------------------
    public Bitmap GraphicToBitmap(Graphic graphic, uint paletteIndex, bool alpha) {
      Bitmap result = new(graphic.Width, graphic.Height);

      BitmapData imageData = result.LockBits(
        new Rectangle(
          0,
          0,
          graphic.Width,
          graphic.Height
        ),
        ImageLockMode.WriteOnly,
        PixelFormat.Format32bppArgb
      );

      byte[] pixelData = GetPixelData(
        graphic,
        _palettes[paletteIndex],
        alpha
      );

      Marshal.Copy(
        pixelData,
        0,
        imageData.Scan0,
        pixelData.Length
      );

      result.UnlockBits(imageData);

      return result;
    }
    #endregion
    #region --- load image via graphic index ------------------------------------------------------
    private static Bitmap LoadImageViaGraphicIndex(IDataReader dataReader, uint graphicIndex, Graphic palette, bool alpha) {
      dataReader.Position = (int)graphicIndex * _sizePerImage;

      Graphic graphic = new();

      _graphicReader.ReadGraphic(
        graphic,
        dataReader,
        _tileGraphicInfo
      );

      Bitmap bitmap = new(16, 16);

      BitmapData imageData = bitmap.LockBits(
        new Rectangle(0, 0, 16, 16),
        ImageLockMode.WriteOnly,
        PixelFormat.Format32bppArgb
      );

      byte[] pixelData = GetPixelData(
        graphic,
        palette,
        alpha
      );

      Marshal.Copy(
        pixelData,
        0,
        imageData.Scan0,
        pixelData.Length
      );

      bitmap.UnlockBits(imageData);

      return bitmap;
    }
    #endregion
    #region --- load image via palette index ------------------------------------------------------
    internal Bitmap LoadImageViaPaletteIndex(
      IDataReader dataReader,
      uint paletteIndex,
      GraphicInfo graphicInfo
    ) {
      Graphic graphic = new();

      _graphicReader.ReadGraphic(
        graphic,
        dataReader,
        graphicInfo
      );

      return GraphicToBitmap(
        graphic,
        paletteIndex,
        graphicInfo.Alpha
      );
    }
    #endregion
    #region --- read palette ----------------------------------------------------------------------
    private static Graphic ReadPalette(IDataReader dataReader) {
      Graphic result = new();

      _graphicReader.ReadGraphic(
        result,
        dataReader,
        _paletteGraphicInfo
      );

      return result;
    }
    #endregion
  }
}