using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditMonsterGroupForm : CustomForm {
    #region --- local class: monster as text ------------------------------------------------------
    private class MonsterAsText {
      public uint   Index { get; set; } = 0;
      public string Text  { get; set; } = string.Empty;
    }
    #endregion
    #region --- local class: monster group row ----------------------------------------------------
    private class MonsterGroupRow { 
      public uint   Row     { get; set; } = 0;
      public string Column1 { get; set; } = string.Empty;
      public string Column2 { get; set; } = string.Empty;
      public string Column3 { get; set; } = string.Empty;
      public string Column4 { get; set; } = string.Empty;
      public string Column5 { get; set; } = string.Empty;
      public string Column6 { get; set; } = string.Empty;
    }
    #endregion
    #region --- fields ----------------------------------------------------------------------------
    private readonly List<MonsterAsText>   _monstersAsText   = [];
    private readonly List<MonsterGroupRow> _monsterGroupRows = [];
    #endregion
    #region --- properties ------------------------------------------------------------------------
    public MonsterGroupData MonsterGroup { get; private set; }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditMonsterGroupForm(MonsterGroupData monsterGroup) {
      InitializeComponent();

      MonsterGroup = monsterGroup;

      tbxIndex.Text = MonsterGroup.Index.ToString();
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      dgv.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewTextBoxColumn()  { Name = nameof(MonsterGroupRow.Row) },
        new DataGridViewComboBoxColumn() { Name = nameof(MonsterGroupRow.Column1) },
        new DataGridViewComboBoxColumn() { Name = nameof(MonsterGroupRow.Column2) },
        new DataGridViewComboBoxColumn() { Name = nameof(MonsterGroupRow.Column3) },
        new DataGridViewComboBoxColumn() { Name = nameof(MonsterGroupRow.Column4) },
        new DataGridViewComboBoxColumn() { Name = nameof(MonsterGroupRow.Column5) },
        new DataGridViewComboBoxColumn() { Name = nameof(MonsterGroupRow.Column6) },
      });

      foreach (DataGridViewColumn column in dgv.Columns) {
        column.ReadOnly = true;
        column.SortMode = DataGridViewColumnSortMode.NotSortable;

        if (column is DataGridViewComboBoxColumn comboBoxColumn) {
          comboBoxColumn.DataSource = _monstersAsText.Select(x => x.Text).ToList();
          comboBoxColumn.ReadOnly   = false;
        }
      }

      dgv.DataSource = _monsterGroupRows;
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();
      MapMonstersToText();
      MapMonsterGroupToRows();
      InitDGV();
      WireEvents();
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnShown(EventArgs e) {
      base.OnShown(e);

      foreach (DataGridViewColumn column in dgv.Columns) {
        column.Width = 40;

        if (column is DataGridViewComboBoxColumn comboBoxColumn) {
          comboBoxColumn.Width = 180;
        }
      }
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();
      btnOK.Click     += (s, e) => { MapMonsterRowsToGroup(); DialogResult = DialogResult.OK; Close(); };
    }
    #endregion

    #region --- map monster group to rows ---------------------------------------------------------
    private void MapMonsterGroupToRows() {
      _monsterGroupRows.AddRange(
        new List<MonsterGroupRow> {
          new() { Row = 1},
          new() { Row = 2},
          new() { Row = 3}
        }
      );

      uint rowIndex    = 0;
      uint columnIndex = 0;

      foreach (uint monsterIndex in MonsterGroup.MonsterIndices) {
        columnIndex = columnIndex == 6
          ? 1
          : columnIndex + 1;

        if (columnIndex == 1) {
          rowIndex++;
        }

        if (
          _monsterGroupRows.First(x => x.Row == rowIndex) is MonsterGroupRow monsterGroupRow
          && _monstersAsText.First(x => x.Index == monsterIndex) is MonsterAsText monsterAsText
        ) {
          switch (columnIndex) {
            case 1: monsterGroupRow.Column1 = monsterAsText.Text; break;
            case 2: monsterGroupRow.Column2 = monsterAsText.Text; break;
            case 3: monsterGroupRow.Column3 = monsterAsText.Text; break;
            case 4: monsterGroupRow.Column4 = monsterAsText.Text; break;
            case 5: monsterGroupRow.Column5 = monsterAsText.Text; break;
            case 6: monsterGroupRow.Column6 = monsterAsText.Text; break;
          }
        }
      }
    }
    #endregion
    #region --- map monster rows to group ---------------------------------------------------------
    private void MapMonsterRowsToGroup() {
      MonsterGroupRow row1 = _monsterGroupRows.First(monster => monster.Row == 1);
      MonsterGroupRow row2 = _monsterGroupRows.First(monster => monster.Row == 2);
      MonsterGroupRow row3 = _monsterGroupRows.First(monster => monster.Row == 3);

      MonsterGroup.MonsterIndices[0]  = GetMonsterIndex(row1.Column1);
      MonsterGroup.MonsterIndices[1]  = GetMonsterIndex(row1.Column2);
      MonsterGroup.MonsterIndices[2]  = GetMonsterIndex(row1.Column3);
      MonsterGroup.MonsterIndices[3]  = GetMonsterIndex(row1.Column4);
      MonsterGroup.MonsterIndices[4]  = GetMonsterIndex(row1.Column5);
      MonsterGroup.MonsterIndices[5]  = GetMonsterIndex(row1.Column6);

      MonsterGroup.MonsterIndices[6]  = GetMonsterIndex(row2.Column1);
      MonsterGroup.MonsterIndices[7]  = GetMonsterIndex(row2.Column2);
      MonsterGroup.MonsterIndices[8]  = GetMonsterIndex(row2.Column3);
      MonsterGroup.MonsterIndices[9]  = GetMonsterIndex(row2.Column4);
      MonsterGroup.MonsterIndices[10] = GetMonsterIndex(row2.Column5);
      MonsterGroup.MonsterIndices[11] = GetMonsterIndex(row2.Column6);

      MonsterGroup.MonsterIndices[12] = GetMonsterIndex(row3.Column1);
      MonsterGroup.MonsterIndices[13] = GetMonsterIndex(row3.Column2);
      MonsterGroup.MonsterIndices[14] = GetMonsterIndex(row3.Column3);
      MonsterGroup.MonsterIndices[15] = GetMonsterIndex(row3.Column4);
      MonsterGroup.MonsterIndices[16] = GetMonsterIndex(row3.Column5);
      MonsterGroup.MonsterIndices[17] = GetMonsterIndex(row3.Column6);

      static uint GetMonsterIndex(string monsterText) {
        uint result = 0;

        if (int.TryParse(monsterText.GetSubstringBeforeOccurrence(':', 1), out int monsterIndex)) {
          result = (uint)monsterIndex;
        }

        return result;
      }
    }
    #endregion
    #region --- map monsters to text --------------------------------------------------------------
    private void MapMonstersToText() {
      _monstersAsText.Add(new());

      if (Repository.Current.GameData is not null) {
        foreach (MonsterData monster in Repository.Current.GameData.Monsters) {
          _monstersAsText.Add(
            new() { 
              Index = monster.Index,
              Text = $"{monster.Index}: {monster.Name} ({monster.Level})"
            }
          );
        }
      }
    }
    #endregion
  }
}