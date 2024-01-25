using Ambermoon.Data.GameDataRepository;
using Ambermoon.Editor.Base;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;

namespace Ambermoon.Editor.Models {
  internal class Repository {
    #region --- fields ----------------------------------------------------------------------------
    private static readonly Repository _instance;
    #endregion
    #region --- property --------------------------------------------------------------------------
    public static Repository          Current  { get { return _instance; } }
    public        string              Folder   { get; private set; } = string.Empty;
    public        GameDataRepository? GameData { get; private set; }
    public        bool                IsDirty  { get; private set; } = false;
    #endregion

    #region --- constructor: singleton ------------------------------------------------------------
    static Repository() {
      _instance = new Repository();
    }
    #endregion
    #region --- get names -------------------------------------------------------------------------
    public string GetAttributeName(int index)      => GetValueNameOfStringList(GameData?.AttributeNames, index);
    public string GetAttributeShortName(int index) => GetValueNameOfStringList(GameData?.AttributeShortNames, index);
    public string GetSkillName(int index)          => GetValueNameOfStringList(GameData?.SkillNames, index);
    public string GetSkillShortName(int index)     => GetValueNameOfStringList(GameData?.SkillShortNames, index);
    #endregion
    #region --- get value name of string list -----------------------------------------------------
    public static string GetValueNameOfStringList(List<string>? list, int index) {
      if (list is null || list.Count < index - 1) {
        return string.Empty;
      }

      return list[index];
    }
    #endregion
    #region --- load ------------------------------------------------------------------------------
    public void Load(string folder = "") {
      if (folder.IsNullOrEmpty()) {
        folder = Folder;
      }

      if (folder.IsNullOrEmpty()) {
        return;
      }

      Folder = folder;

      try {
        GameData = new(Folder);

        if (Settings.DefaultPath.IsNullOrEmpty()) {
          Settings.DefaultPath = Folder;
          Settings.WriteIni();
        }
      } catch (Exception ex) {
        MsgBox.Show(
          "Error",
          $"Repository could not be loaded:{Environment.NewLine}{Environment.NewLine}{ex.Message}"
        );
      }
    }
    #endregion
    #region --- save ------------------------------------------------------------------------------
    public void Save() {
      if (IsDirty) {
        GameData?.Save(Folder);
        IsDirty = false;
      }
    }
    #endregion
    #region --- unload ----------------------------------------------------------------------------
    public void Unload() {
      if (
        IsDirty
        && MsgBox.Show(
          "Save before unload?",
          "Do you want to save the changes you've made before unloading?",
          MessageBoxButtons.YesNo
        ) == DialogResult.Yes
      ) {
        Save();
      }

      GameData = null;
      IsDirty  = false;
    }
    #endregion
  }
}