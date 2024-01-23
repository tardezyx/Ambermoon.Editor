using Ambermoon.Data;

namespace Ambermoon.Editor.Extensions {
  internal static partial class Extensions {
    #region --- fill ------------------------------------------------------------------------------
    internal static void Fill(this Tileset.Tile target, Tileset.Tile source) {
      target.AllowedTravelTypes    = source.AllowedTravelTypes;
      target.ColorIndex            = source.ColorIndex;
      target.CombatBackgroundIndex = source.CombatBackgroundIndex;
      target.Flags                 = source.Flags;
      target.GraphicIndex          = source.GraphicIndex;
      target.NumAnimationFrames    = source.NumAnimationFrames;
      target.SitDirection          = source.SitDirection;
      target.Sleep                 = source.Sleep;
    }
    #endregion
  }
}