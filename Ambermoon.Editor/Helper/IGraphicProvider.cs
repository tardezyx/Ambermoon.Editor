namespace Ambermoon.Editor.Helper {
  public interface IGraphicProvider {
    public Bitmap  GetCombatBackgroundGraphic(bool mapIs3D, uint index);
    public Bitmap  GetNPCGraphic(uint fileIndex, uint index);
    public int     GetNPCGraphicCount(uint fileIndex);
    public Bitmap  GetObject3DGraphic(uint index);
    public int     GetObject3DGraphicCount();
    public Color[] GetPaletteColors(uint paletteIndex);
    public Bitmap  GetTileGraphic(uint tilesetIndex, uint index);
    public int     GetTileGraphicCount(uint tilesetIndex);
  }
}