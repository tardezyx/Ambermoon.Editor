using Ambermoon.Data.GameDataRepository;
using Ambermoon.Data.GameDataRepository.Enumerations;
using Ambermoon.Data.GameDataRepository.Windows;

namespace Ambermoon.Editor.Models {
  internal class CombatBackground {
    #region --- fields ----------------------------------------------------------------------------
    private readonly List<ImageData> _frames = [];
    #endregion
    #region --- properties ------------------------------------------------------------------------
    public Bitmap          ComparisonFrame { get; private set; }
    public int             Index           { get; set; }
    public List<Palette>   Palettes        { get; private set; } = [];
    public List<Bitmap>    RenderedFrames  { get; private set; } = [];
    public string          Variant         { get; set; } = string.Empty;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public CombatBackground(CombatBackgroundImage combatBackgroundImage) {
      _frames = combatBackgroundImage.Frames;

      foreach (uint paletteIndex in combatBackgroundImage.PaletteIndices) {
        Palette palette = Repository.Current.GameData!.Palettes[(uint)paletteIndex];
        Palettes.Add(palette);

        RenderedFrames.Add(
          WindowsExtensions.ToBitmap(
            _frames[0],
            palette,
            true
          )
        );
      }

      ComparisonFrame = WindowsExtensions.ToBitmap(
        _frames[0],
        Repository.Current.GameData!.Palettes[1],
        true
      );
    }
    #endregion
    #region --- has identical palettes as ---------------------------------------------------------
    public bool HasIdenticalPalettesAs(CombatBackground combatBackground) {
      if (Palettes.Count != combatBackground.Palettes.Count) { 
        return false;
      }

      for (int i = 0; i < Palettes.Count; i++) {
        if (Palettes[i].Index != combatBackground.Palettes[i].Index) { 
          return false;
        }
      }

      return true;
    }
    #endregion
    #region --- get palette -----------------------------------------------------------------------
    public Palette GetPalette(CombatBackgroundDaytime combatBackgroundDaytime) { 
      return Palettes[(int)combatBackgroundDaytime];
    }
    #endregion
    #region --- get rendered frame ----------------------------------------------------------------
    public Bitmap GetRenderedFrame(CombatBackgroundDaytime combatBackgroundDaytime) { 
      return RenderedFrames[(int)combatBackgroundDaytime];
    }
    #endregion
  }
}