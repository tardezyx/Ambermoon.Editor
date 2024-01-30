using Ambermoon.Data.GameDataRepository;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Data.GameDataRepository.Windows;
using Ambermoon.Editor.Models;
using Image = Ambermoon.Data.GameDataRepository.Image;

namespace Ambermoon.Editor.Extensions {
  internal static partial class Extensions {
    #region --- item data: get graphic ------------------------------------------------------------
    internal static Bitmap? GetGraphic(this ItemData source, int graphicIndex = -1) {
      uint imageIndex = graphicIndex == -1
        ? source.GraphicIndex
        : (uint)graphicIndex;

      if (
        Repository.Current.GameData is not GameDataRepository repository
        || !repository.ItemImages.ContainsKey(imageIndex)
      ) {
        return null;
      }

      return WindowsExtensions.ToBitmap(
        repository.ItemImages[imageIndex].Frames[0],
        repository.ItemPalette,
        true
      );
    }
    #endregion

    #region --- monster data: get combat graphic --------------------------------------------------
    internal static Bitmap? GetCombatGraphic(this MonsterData source, int combatGraphicIndex = -1, uint paletteIndex = 21) {
      if (combatGraphicIndex == -1) {
        combatGraphicIndex = (int)source.CombatGraphicIndex;
      }

      if (
        source.GetImage(combatGraphicIndex) is not Image image
        || source.GetPalette(paletteIndex) is not Palette palette
      ) {
        return null;
      }

      return WindowsExtensions.ToBitmap(
        image.Frames[0],
        palette,
        true
      );
    }
    #endregion
    #region --- monster data: get combat icon graphic ---------------------------------------------
    internal static Bitmap? GetCombatIconGraphic(this MonsterData source, int combatGraphicIndex = -1) {
      uint imageIndex = combatGraphicIndex == -1
        ? source.CombatGraphicIndex
        : (uint)combatGraphicIndex;

      if (
        Repository.Current.GameData is not GameDataRepository repository
        || !repository.MonsterCombatIcons.ContainsKey(imageIndex)
      ) {
        return null;
      }

      return WindowsExtensions.ToBitmap(
        repository.MonsterCombatIcons[imageIndex].Frames[0],
        repository.UserInterfacePalette,
        true
      );
    }
    #endregion
    #region --- monster data: get image -----------------------------------------------------------
    internal static Image? GetImage(this MonsterData source, int imageIndex = -1) {
      uint index = imageIndex == -1
        ? source.CombatGraphicIndex
        : (uint)imageIndex;

      if (
        Repository.Current.GameData is not GameDataRepository repository
        || !repository.MonsterImages.ContainsKey(index)
      ) {
        return null;
      }

      return repository.MonsterImages[index];
    }
    #endregion
    #region --- monster data: get palette ---------------------------------------------------------
    internal static Palette? GetPalette(this MonsterData source, uint paletteIndex) {
      if (
        Repository.Current.GameData is not GameDataRepository repository
        || !repository.Palettes.ContainsKey(paletteIndex)
      ) {
        return null;
      }

      return repository.Palettes[paletteIndex];
    }
    #endregion
  }
}