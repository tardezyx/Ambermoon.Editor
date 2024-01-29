using Ambermoon.Data;
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
    #region --- get indexes -----------------------------------------------------------------------
    public int? GetAttributeIndex(string name) => GetIndexOfStringList(GameData?.AttributeNames,name);
    public int? GetSkillIndex(string name)     => GetIndexOfStringList(GameData?.SkillNames,name);
    #endregion
    #region --- get names -------------------------------------------------------------------------
    public string GetAttributeName(int index)                      => GetValueNameOfStringList(GameData?.AttributeNames,      index);
    public string GetAttributeShortName(int index)                 => GetValueNameOfStringList(GameData?.AttributeShortNames, index);
    public string GetSkillName(int index)                          => GetValueNameOfStringList(GameData?.SkillNames,          index);
    public string GetSkillShortName(int index)                     => GetValueNameOfStringList(GameData?.SkillShortNames,     index);
    public string GetSpellName(SpellSchool spellSchool, int index) => GetValueNameOfStringList(GetSpellNames(spellSchool),    index);
    public string GetSpellSchoolName(SpellSchool spellSchool)      => GetValueNameOfStringList(GameData?.SpellClassNames,     (int)spellSchool);
    #endregion
    #region --- get value name of string list -----------------------------------------------------
    private static string GetValueNameOfStringList(List<string>? list, int index) {
      if (list is null || list.Count < index - 1) {
        return string.Empty;
      }

      return list[index];
    }
    #endregion
    #region --- get index of string list ----------------------------------------------------------
    private static int? GetIndexOfStringList(List<string>? list, string entry) {
      return list?.IndexOf(entry);
    }
    #endregion
    #region --- get spell -------------------------------------------------------------------------
    public Spell GetSpell(SpellSchool spellSchool, int index) {
      return new() {
        Index  = index,
        School = GetSpellSchoolName(spellSchool),
        Name   = GetSpellName(spellSchool, index)
      };
    }
    #endregion
    #region --- get spell names -------------------------------------------------------------------
    public List<string> GetSpellNames(SpellSchool spellSchool) {
      List<string> result = [];

      if (GameData is not null) { 
        int startIndex = (int)spellSchool * 30;

        for (int i = startIndex; i <= startIndex + 29; i++) {
          result.Add(GameData.SpellNames[i]);
        }
      }

      return result;
    }
    #endregion
    #region --- get spells by uint ----------------------------------------------------------------
    public List<Spell> GetSpellsByUint(SpellSchool spellSchool, uint spells) {
      List<Spell> result = [];

      if (GameData is not null) {
        string spellsInBitString = Convert
          .ToString(spells, toBase: 2)
          .Reverse();

        List<int> foundIndexes = [];

        for (int i = spellsInBitString.IndexOf('1'); i > -1; i = spellsInBitString.IndexOf('1', i + 1)) {
          foundIndexes.Add(i-1);
        }

        foreach (int i in foundIndexes) {
          result.Add(GetSpell(spellSchool, i));
        }
      }

      return result;
    }
    #endregion
    #region --- map repo stuff --------------------------------------------------------------------
    public void MapRepoStuff() {
      if (GameData is null) {
        return;
      }

      int asdadafd = 0;
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

      MapRepoStuff();
    }
    #endregion
    #region --- save ------------------------------------------------------------------------------
    public void Save() {
      if (IsDirty) {
        GameData?.Save(Folder);
        IsDirty = false;

        MapRepoStuff();
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