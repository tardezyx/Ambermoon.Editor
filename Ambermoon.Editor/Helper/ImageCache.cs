using Ambermoon.Data.GameDataRepository;
using Ambermoon.Data.GameDataRepository.Windows;

namespace Ambermoon.Editor.Helper
{
	internal class ImageCache
	{
		#region --- fields ----------------------------------------------------------------------------
		private readonly GameDataRepository repository;
		// key1: tileset index | key2: graphic index | key3: palette index
		private readonly Dictionary<uint, Dictionary<uint, Dictionary<uint, Bitmap>>> _images = [];
		private const int _sizePerImage = 16 * 16 * 5 / 8;
		#endregion

		#region --- constructor -----------------------------------------------------------------------
		public ImageCache(GameDataRepository repository)
		{
			this.repository = repository;
		}
		#endregion
		#region --- get image -------------------------------------------------------------------------
		public Bitmap GetImage(uint tilesetIndex, uint graphicIndex, uint paletteIndex)
		{
			if (!_images.TryGetValue(tilesetIndex, out Dictionary<uint, Dictionary<uint, Bitmap>>? tileset))
			{
				Bitmap image = repository.Tile2DImages[tilesetIndex][(int)graphicIndex].ToBitmap(repository.Palettes[paletteIndex], true);

				_images.Add(tilesetIndex, new Dictionary<uint, Dictionary<uint, Bitmap>>
				{
					{
						graphicIndex, new Dictionary<uint, Bitmap>
						{
							{ paletteIndex, image }
						}
					}
				});

				return image;
			}
			else if (!tileset.TryGetValue(graphicIndex, out Dictionary<uint, Bitmap>? graphic))
			{
				Bitmap image = repository.Tile2DImages[tilesetIndex][(int)graphicIndex].ToBitmap(repository.Palettes[paletteIndex], true);

				tileset.Add(graphicIndex, new Dictionary<uint, Bitmap>
				{
					{ paletteIndex, image }
				});

				return image;
			}
			else if (!graphic.TryGetValue(paletteIndex, out Bitmap? cachedImage))
			{
				Bitmap image = repository.Tile2DImages[tilesetIndex][(int)graphicIndex].ToBitmap(repository.Palettes[paletteIndex], true);

				graphic.Add(paletteIndex, image);

				return image;
			}
			else
			{
				return cachedImage;
			}
		}
		#endregion
		#region --- get image count -------------------------------------------------------------------
		public int GetImageCount(uint tilesetIndex)
		{
			return repository.Tile2DImages[tilesetIndex].Count;
		}
		#endregion
		#region --- get palette color -----------------------------------------------------------------
		public Color GetPaletteColor(uint paletteIndex, uint colorIndex)
		{
			return repository.Palettes[paletteIndex].ToColor(colorIndex % 32);
		}
		#endregion
		#region --- get palette colors ----------------------------------------------------------------
		public Color[] GetPaletteColors(uint index)
		{
			return repository.Palettes[index].ToColors();
		}
		#endregion
	}
}