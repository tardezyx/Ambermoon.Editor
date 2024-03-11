using Ambermoon.Data.GameDataRepository;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Data.GameDataRepository.Windows;
using Ambermoon.Editor.Models;
using Image = Ambermoon.Data.GameDataRepository.Image;

namespace Ambermoon.Editor.Extensions {
  internal static partial class Extensions {
    #region --- item data: get graphic ------------------------------------------------------------
    internal static Bitmap? GetGraphic(this ItemData source, int graphicIndex = -1) {
      Bitmap? result = null;

      uint imageIndex = graphicIndex < 0
        ? source.GraphicIndex
        : (uint)graphicIndex;

      if (
        Repository.Current.GameData is GameDataRepository repository
        && repository.ItemImages.TryGetValue(imageIndex, out Image? image)
      ) {
        result =  WindowsExtensions.ToBitmap(
          image.Frames[0],
          repository.ItemPalette,
          true
        );
      }

      return result;
    }
    #endregion
    #region --- item data: get text ---------------------------------------------------------------
    internal static string GetText(this ItemData source, int textIndex = -1, int textSubIndex = -1) {
      string result = string.Empty;

      uint? index = textIndex < 0
        ? source.TextIndex
        : (uint)textIndex;

      uint? subIndex = textSubIndex < 0
        ? source.TextSubIndex
        : (uint)textSubIndex;

      if (
        index.HasValue
        && subIndex.HasValue
        && Repository.Current.GameData is GameDataRepository repository
        && repository.ItemTexts.TryGetValue((uint)index, out TextList? textList)
        && subIndex < textList.Count) {
        result = textList[(int)subIndex];
      }
      
      return result;
    }
    #endregion

    #region --- monster data: get combat graphic --------------------------------------------------
    internal static Bitmap? GetCombatGraphic(this MonsterData source, int combatGraphicIndex = -1, int paletteIndex = -1) {
      Bitmap? result = null;

      if (combatGraphicIndex < 0) {
        combatGraphicIndex = (int)source.GraphicIndex;
      }

      if (
        source.GetImage(combatGraphicIndex) is Image image
        && source.GetPalette(paletteIndex) is Palette palette
      ) {
        result = WindowsExtensions.ToBitmap(
          image.Frames[0],
          palette,
          true
        );
      }

      return result;
    }
    #endregion
    #region --- monster data: get combat icon graphic ---------------------------------------------
    internal static Bitmap? GetCombatIconGraphic(this MonsterData source, int combatGraphicIndex = -1) {
      Bitmap? result = null;

      uint imageIndex = combatGraphicIndex < 0
        ? source.GraphicIndex
        : (uint)combatGraphicIndex;

      if (
        Repository.Current.GameData is GameDataRepository repository
        && repository.MonsterCombatIcons.TryGetValue(imageIndex, out Image? image)
      ) {
        result = WindowsExtensions.ToBitmap(
          image.Frames[0],
          repository.UserInterfacePalette,
          true
        );
      }

      return result;
    }
    #endregion
    #region --- monster data: get image -----------------------------------------------------------
    internal static Image? GetImage(this MonsterData source, int imageIndex = -1) {
      Image? result = null;

      uint index = imageIndex < 0
        ? source.GraphicIndex
        : (uint)imageIndex;

      if (Repository.Current.GameData is GameDataRepository repository) {
        repository.MonsterImages.TryGetValue(index, out result);
      }

      return result;
    }
    #endregion
    #region --- monster data: get palette ---------------------------------------------------------
    internal static Palette? GetPalette(this MonsterData source, int paletteIndex = -1) {
      Palette? result = null;

      if (paletteIndex < 0) {
        if (Repository.Current.DefaultMonsterImagePalettes.TryGetValue(source.Index, out result)) {
          return result;
        }

        paletteIndex = 21;
      }

      if (Repository.Current.GameData is GameDataRepository repository) {
        repository.Palettes.TryGetValue((uint)paletteIndex, out result);
      }

      return result;
    }
    #endregion
  }
}