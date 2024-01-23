using Ambermoon.Data;
using Ambermoon.Editor.Gui.Editors;
using System.Text.RegularExpressions;

namespace Ambermoon.Editor.Gui.Custom {
  public partial class EditMapCharControl : UserControl {
    #region --- events ----------------------------------------------------------------------------
    public event Action? CurrentCharacterChanged;
    public event Action? DirtyChanged;
    public event Action<int>? SelectionChanged;
    #endregion
    #region --- fields ----------------------------------------------------------------------------
    private                 CharacterList?                       characterList;
    private                 bool                                 dirty = false;
    private                 List<string>                         eventNames = new();
    private                 Helper.IGraphicProvider?             graphicProvider;
    private                 Action<IWin32Window, Action<string>> imageSaveHandler;
    [GeneratedRegex(@"~INK ?[0-9]+~", RegexOptions.Compiled)]
    private static partial  Regex                                InkRegex();
    private                 Map?                                 map;
    private                 List<string>                         mapTexts = new();
    private        readonly Dictionary<int, string>              monsters = new();
    private        readonly Dictionary<int, string>              monsterGroups = new();
    private        readonly Dictionary<int, string>              npcs = new();
    private        readonly Dictionary<int, string>              partyMembers = new();
    #endregion
    #region --- properties ------------------------------------------------------------------------
    public int Count => characterList!.Count;

    public bool Dirty {
      get => dirty;
      private set {
        if (dirty != value) {
          dirty = value;
          DirtyChanged?.Invoke();
        }
      }
    }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditMapCharControl() {
      InitializeComponent();

      Visible = false;
    }
    #endregion
    #region --- init ------------------------------------------------------------------------------
    public void Init(Map map) {
      this.map = map;
      mapTexts = map.Texts.Select(t => InkRegex().Replace(t, "")).ToList();

      characterList!.SetMap((type, textPopup) => type switch {
        CharacterType.PartyMember => partyMembers,
        CharacterType.NPC => textPopup ? mapTexts.Select((t, i) => new { t, i }).ToDictionary(x => x.i, x => x.t) : npcs,
        CharacterType.Monster => monsterGroups,
        CharacterType.MapObject => eventNames.Select((e, i) => new { e, i }).ToDictionary(x => x.i, x => x.e),
        _ => throw new ArgumentException("Invalid character type")
      }, map);

      if (characterList.Count != 0)
        UpdateCurrentCharacter();

      buttonAdd.Enabled = characterList!.Count < 32;
      buttonRemove.Enabled = characterList.SelectedIndex != -1 && characterList.Count != 0;
      groupBoxCharProperties.Enabled = characterList.Count != 0;
      Dirty = false;
    }
    #endregion
    #region --- init ------------------------------------------------------------------------------
    public void Init(Map map, ILegacyGameData gameData, Helper.IGraphicProvider graphicProvider, Action<IWin32Window, Action<string>> imageSaveHandler) {
      this.imageSaveHandler = imageSaveHandler;
      this.graphicProvider = graphicProvider;
      this.map = map;
      eventNames = map.EventList.Select(e => e.ToString()!).ToList();
      mapTexts = map.Texts.Select(t => InkRegex().Replace(t, "")).ToList();
      var bossMonsters = new List<int>();

      void LoadCharacters(string filename, Dictionary<int, string> targetList, int skipAmount = 0, bool checkBoss = false) {
        foreach (var file in gameData.Files[filename].Files.Skip(skipAmount)) {
          if (file.Value.Size != 0) {
            if (checkBoss) {
              file.Value.Position = 0x12;

              if ((file.Value.ReadByte() & 0x04) != 0)
                bossMonsters.Add(file.Key);
            }

            file.Value.Position = 0x112;
            string name = file.Value.ReadString(16).TrimEnd(' ', '\0');
            targetList.Add(file.Key, name);
          }
        }
      }

      try {
        LoadCharacters("Monster_char.amb", monsters, 0, true);
      } catch {
        LoadCharacters("Monster_char_data.amb", monsters, 0, true);
      }
      LoadCharacters("Save.00/Party_char.amb", partyMembers, 1);
      LoadCharacters("NPC_char.amb", npcs);

      foreach (var monsterGroupFile in gameData.Files["Monster_groups.amb"].Files) {
        if (monsterGroupFile.Value.Size != 0) {
          monsterGroupFile.Value.Position = 0;
          var indices = Enumerable.Range(0, 18).Select(_ => monsterGroupFile.Value.ReadWord()).Where(i => i != 0).ToList();
          var group = indices.Select(i => monsters[i]).ToList();

          if (group.Count == 1)
            monsterGroups.Add(monsterGroupFile.Key, group[0]);
          else {
            string name = "";
            var bosses = indices.Where(i => bossMonsters.Contains(i));

            if (bosses.Count() == 1) {
              var boss = bosses.FirstOrDefault();

              if (boss != 0) {
                name = monsters[boss];
                group.Remove(name);
                name += ",";
              }
            }

            name += string.Join(",", group.GroupBy(g => g).Select(g => new { c = g.Count(), n = g.Key }).Select(g => g.c == 1 ? g.n : $"{g.c}x {g.n}"));
            monsterGroups.Add(monsterGroupFile.Key, name);
          }
        }
      }

      Visible = true;

      var characterList = new CharacterList((type, textPopup) => type switch {
        CharacterType.PartyMember => partyMembers,
        CharacterType.NPC => textPopup ? mapTexts.Select((t, i) => new { t, i }).ToDictionary(x => x.i, x => x.t) : npcs,
        CharacterType.Monster => monsterGroups,
        CharacterType.MapObject => eventNames.Select((e, i) => new { e, i }).ToDictionary(x => x.i, x => x.e),
        _ => throw new ArgumentException("Invalid character type")
      }, map);

      characterList.Location = new Point(1, 1);
      characterList.Size = new(Width - 2, buttonAdd.Location.Y - 2);
      characterList.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
      characterList.CharacterChanged += CharacterList_CharacterChanged;
      characterList.SelectedIndexChanged += CharacterList_SelectedIndexChanged;
      characterList.RowCountChanged += CharacterList_RowCountChanged;
      this.Controls.Add(characterList);
      this.characterList = characterList;

      if (characterList.Count != 0)
        UpdateCurrentCharacter();

      buttonAdd.Enabled = characterList!.Count < 32;
      buttonRemove.Enabled = characterList.SelectedIndex != -1 && characterList.Count != 0;
      groupBoxCharProperties.Enabled = characterList.Count != 0;
      Dirty = false;
    }
    #endregion
    #region --- save ------------------------------------------------------------------------------
    public void Save() => Dirty = false;
    #endregion
    #region --- set character flag ----------------------------------------------------------------
    private void SetCharacterFlag(Map.CharacterReference character, Map.CharacterReference.Flags flag, bool value) {
      if (value)
        character.CharacterFlags |= flag;
      else
        character.CharacterFlags &= ~flag;

      CurrentCharacterChanged?.Invoke();
      Dirty = true;
    }
    #endregion
    #region --- update current character ----------------------------------------------------------
    private void UpdateCurrentCharacter(Map.CharacterReference? character = null) {
      if (characterList!.SelectedIndex == -1) {
        groupBoxCharProperties.Enabled = false;
        return;
      }

      groupBoxCharProperties.Enabled = true;

      character ??= map!.CharacterReferences[characterList.SelectedIndex];

      checkBoxRandomMovement.Checked = character.CharacterFlags.HasFlag(Map.CharacterReference.Flags.RandomMovement);
      checkBoxUseTileset.Checked = character.Type != CharacterType.Monster &&
          character.CharacterFlags.HasFlag(Map.CharacterReference.Flags.UseTileset);
      checkBoxTextPopup.Checked = character.Type == CharacterType.NPC &&
          character.CharacterFlags.HasFlag(Map.CharacterReference.Flags.TextPopup);
      checkBoxStationary.Checked = character.Type != CharacterType.Monster &&
          character.CharacterFlags.HasFlag(Map.CharacterReference.Flags.Stationary);
      checkBoxOnlyMoveWhenSeePlayer.Checked = character.Type == CharacterType.Monster &&
          character.CharacterFlags.HasFlag(Map.CharacterReference.Flags.MoveOnlyWhenSeePlayer);

      checkBoxUseTileset.Enabled = character.Type != CharacterType.Monster;
      checkBoxTextPopup.Enabled = character.Type == CharacterType.NPC;
      checkBoxStationary.Enabled = character.Type != CharacterType.Monster;
      checkBoxOnlyMoveWhenSeePlayer.Enabled = character.Type == CharacterType.Monster;
    }
    #endregion

    #region --- button add ------------------------------------------------------------------------
    private void buttonAdd_Click(object sender, EventArgs e) {
      var character = map!.CharacterReferences[characterList!.Count] ??= new Map.CharacterReference {
        Index = 1,
        Type = CharacterType.NPC
      };
      character.Positions.AddRange(Enumerable.Range(0, 288).Select(_ => new Ambermoon.Position(0, 0)));
      CurrentCharacterChanged?.Invoke();
      characterList.Add();
      Dirty = true;
    }
    #endregion
    #region --- button more -----------------------------------------------------------------------
    private void buttonMore_Click(object sender, EventArgs e) {
      if (characterList!.SelectedIndex != -1) {
        bool mapIs3D = map!.Type == MapType.Map3D;
        var character = map.CharacterReferences[characterList.SelectedIndex];
        var graphicProvider = (uint index) => {
          if (mapIs3D)
            return this.graphicProvider!.GetObject3DGraphic(index);
          if (character.CharacterFlags.HasFlag(Map.CharacterReference.Flags.UseTileset))
            return this.graphicProvider!.GetTileGraphic(map.TilesetOrLabdataIndex, index);
          return this.graphicProvider!.GetNPCGraphic(map.NPCGfxIndex, index);
        };
        var graphicCountProvider = () => {
          if (mapIs3D)
            return this.graphicProvider!.GetObject3DGraphicCount();
          if (character.CharacterFlags.HasFlag(Map.CharacterReference.Flags.UseTileset))
            return this.graphicProvider!.GetTileGraphicCount(map.TilesetOrLabdataIndex);
          return this.graphicProvider!.GetNPCGraphicCount(map.NPCGfxIndex);
        };

        var settingsForm = new EditMapCharSettingsForm(mapIs3D, character,
            index => this.graphicProvider!.GetCombatBackgroundGraphic(mapIs3D, index),
            graphicProvider, graphicCountProvider, imageSaveHandler);

        if (settingsForm.ShowDialog() == DialogResult.OK) {
          if (character.TileFlags != settingsForm.TileFlags) {
            character.TileFlags = settingsForm.TileFlags;
            Dirty = true;
          }
          if (character.GraphicIndex != settingsForm.GraphicIndex) {
            character.GraphicIndex = settingsForm.GraphicIndex;
            Dirty = true;
          }
        }
      }
    }
    #endregion
    #region --- button remove ---------------------------------------------------------------------
    private void buttonRemove_Click(object sender, EventArgs e) {
      if (characterList!.SelectedIndex != -1 && characterList.Count != 0) {
        int index = characterList.SelectedIndex;
        characterList.Remove(index);
        Dirty = true;
        int count = map!.CharacterReferences.Length;

        for (int i = index; i < count; ++i) {
          map!.CharacterReferences[i] = i == count - 1 ? null : map!.CharacterReferences[i + 1];
        }
      }
    }
    #endregion
    #region --- character list: character changed -------------------------------------------------
    private void CharacterList_CharacterChanged(CharacterRow row) {
      var character = map!.CharacterReferences[characterList!.SelectedIndex];

      character.Type = row.CharacterType;
      character.Index = row.CharacterIndex;

      if (character.Type == CharacterType.MapObject) {
        character.EventIndex = character.Index + 1;
        character.Index = 1;
      }

      UpdateCurrentCharacter(character);

      CurrentCharacterChanged?.Invoke();

      Dirty = true;
    }
    #endregion
    #region --- character list: row count changed -------------------------------------------------
    private void CharacterList_RowCountChanged() {
      buttonAdd.Enabled = characterList!.Count < 32;
      buttonRemove.Enabled = characterList.SelectedIndex != -1 && characterList.Count != 0;
      groupBoxCharProperties.Enabled = characterList.Count != 0;

      if (characterList.Count == 0)
        SelectionChanged?.Invoke(-1);

      Dirty = true;
    }
    #endregion
    #region --- character list: selected index changed --------------------------------------------
    private void CharacterList_SelectedIndexChanged(int index) {
      UpdateCurrentCharacter();
      SelectionChanged?.Invoke(index);
      buttonRemove.Enabled = characterList!.SelectedIndex != -1 && characterList.Count != 0;
    }
    #endregion
    #region --- checkbox only move when see player: checked changed -------------------------------
    private void checkBoxOnlyMoveWhenSeePlayer_CheckedChanged(object sender, EventArgs e) {
      var character = map!.CharacterReferences[characterList!.SelectedIndex];

      SetCharacterFlag(character, Map.CharacterReference.Flags.MoveOnlyWhenSeePlayer, checkBoxOnlyMoveWhenSeePlayer.Checked);
    }
    #endregion
    #region --- checkbox random movement: checked changed -----------------------------------------
    private void checkBoxRandomMovement_CheckedChanged(object sender, EventArgs e) {
      if (checkBoxRandomMovement.Checked)
        checkBoxStationary.Checked = false;

      var character = map!.CharacterReferences[characterList!.SelectedIndex];

      SetCharacterFlag(character, Map.CharacterReference.Flags.RandomMovement, checkBoxRandomMovement.Checked);
    }
    #endregion
    #region --- checkbox stationary: checked changed ----------------------------------------------
    private void checkBoxStationary_CheckedChanged(object sender, EventArgs e) {
      if (checkBoxStationary.Checked)
        checkBoxRandomMovement.Checked = false;

      var character = map!.CharacterReferences[characterList!.SelectedIndex];

      SetCharacterFlag(character, Map.CharacterReference.Flags.Stationary, checkBoxStationary.Checked);
    }
    #endregion
    #region --- checkbox text popup: checked changed ----------------------------------------------
    private void checkBoxTextPopup_CheckedChanged(object sender, EventArgs e) {
      var character = map!.CharacterReferences[characterList!.SelectedIndex];

      SetCharacterFlag(character, Map.CharacterReference.Flags.TextPopup, checkBoxTextPopup.Checked);

      characterList.ChangeTextPopupFlag(checkBoxTextPopup.Checked);
    }
    #endregion
    #region --- checkbox use tileset: checked changed ---------------------------------------------
    private void checkBoxUseTileset_CheckedChanged(object sender, EventArgs e) {
      var character = map!.CharacterReferences[characterList!.SelectedIndex];

      SetCharacterFlag(character, Map.CharacterReference.Flags.UseTileset, checkBoxUseTileset.Checked);
    }
    #endregion
  }
}