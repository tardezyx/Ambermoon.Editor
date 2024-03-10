using Ambermoon.Data;
using Ambermoon.Data.Legacy.Serialization;

namespace Ambermoon.Editor.Helper
{
	/*internal class GraphicProvider2D : IGraphicProvider
	{
		readonly Dictionary<uint, Bitmap> combatBackgrounds;
		readonly Dictionary<uint, Dictionary<uint, Graphic>> npcGraphics = [];
		readonly ImageCache imageCache;
		readonly Dictionary<uint, Tileset> tilesets;

		public uint PaletteIndex { get; set; }

		public GraphicProvider2D(
		  Dictionary<uint, Bitmap> combatBackgrounds,
		  ILegacyGameData gameData,
		  ImageCache imageCache,
		  Dictionary<uint,
		  Tileset> tilesets
		)
		{
			this.imageCache = imageCache;
			this.combatBackgrounds = combatBackgrounds;
			this.tilesets = tilesets;

			var npcImageFiles = gameData.Files["NPC_gfx.amb"].Files;
			var npcGraphicInfo = new GraphicInfo
			{
				Alpha = true,
				GraphicFormat = GraphicFormat.Palette5Bit,
				Width = 16,
				Height = 32
			};
			var graphicReader = new GraphicReader();
			foreach (var imageFile in npcImageFiles)
			{
				var graphics = new Dictionary<uint, Graphic>();

				var reader = imageFile.Value;
				reader.Position = 0;
				uint imageIndex = 0;

				while (reader.Position < reader.Size)
				{
					int numFrames = reader.ReadByte();

					if (numFrames == 0)
						break;

					reader.AlignToWord();

					for (int i = 0; i < numFrames; ++i)
					{
						var graphic = new Graphic();

						graphicReader.ReadGraphic(graphic, reader, npcGraphicInfo);

						if (i == 0)
							graphics.Add(imageIndex++, graphic);
					}
				}

				npcGraphics.Add((uint)imageFile.Key, graphics);
			}
		}

		public Bitmap GetCombatBackgroundGraphic(bool mapIs3D, uint index)
		{
			if (mapIs3D)
				throw new NotSupportedException("3D combat graphics are not supported.");

			return combatBackgrounds[index];
		}

		public Bitmap GetNPCGraphic(uint fileIndex, uint index)
		{
			return imageCache.GraphicToBitmap(npcGraphics[fileIndex][index], PaletteIndex, true);
		}

		public int GetNPCGraphicCount(uint fileIndex)
		{
			return npcGraphics[fileIndex].Count;
		}

		public Bitmap GetObject3DGraphic(uint index)
		{
			throw new NotSupportedException("3D object graphics are not supported.");
		}

		public int GetObject3DGraphicCount()
		{
			throw new NotSupportedException("3D object graphics are not supported.");
		}

		public Bitmap GetTileGraphic(uint tilesetIndex, uint index)
		{
			var tile = tilesets[tilesetIndex].Tiles[index - 1];
			return imageCache.GetImage(tilesetIndex, tile.GraphicIndex - 1, PaletteIndex);
		}

		public int GetTileGraphicCount(uint tilesetIndex)
		{
			return tilesets[tilesetIndex].Tiles.Length;
		}

		public Color[] GetPaletteColors(uint paletteIndex)
		{
			return imageCache.GetPaletteColors(paletteIndex);
		}
	}*/
}