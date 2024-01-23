using Ambermoon.Data.GameDataRepository.Collections;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditMonsterGroupForm : Form {
    #region --- local class: monster as text ------------------------------------------------------
    public class MonsterAsText {
      public uint   Index { get; set; } = 0;
      public string Text  { get; set; } = string.Empty;
    }
    #endregion
    #region --- local class: monster group row ----------------------------------------------------
    private class MonsterGroupRow { 
      public uint   Row { get; set; } = 0;
      public string C1  { get; set; } = string.Empty;
      public string C2  { get; set; } = string.Empty;
      public string C3  { get; set; } = string.Empty;
      public string C4  { get; set; } = string.Empty;
      public string C5  { get; set; } = string.Empty;
      public string C6  { get; set; } = string.Empty;
    }
    #endregion
    #region --- fields ----------------------------------------------------------------------------
    private readonly DictionaryList<MonsterData> _monsters;
    private readonly List<MonsterAsText>         _monstersAsText   = [];
    private readonly List<MonsterGroupRow>       _monsterGroupRows = [];
    #endregion
    #region --- properties ------------------------------------------------------------------------
    public MonsterGroupData MonsterGroup { get; private set; }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditMonsterGroupForm(
      DictionaryList<MonsterData> monsters,
      MonsterGroupData monsterGroup
    ) {
      InitializeComponent();

      _monsters    = monsters;
      MonsterGroup = monsterGroup;

      tbxIndex.Text = MonsterGroup.Index.ToString();
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      dgv.AutoGenerateColumns = false;

      dgv.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewTextBoxColumn()  { DataPropertyName = nameof(MonsterGroupRow.Row) },
        new DataGridViewComboBoxColumn() { DataPropertyName = nameof(MonsterGroupRow.C1) },
        new DataGridViewComboBoxColumn() { DataPropertyName = nameof(MonsterGroupRow.C2) },
        new DataGridViewComboBoxColumn() { DataPropertyName = nameof(MonsterGroupRow.C3) },
        new DataGridViewComboBoxColumn() { DataPropertyName = nameof(MonsterGroupRow.C4) },
        new DataGridViewComboBoxColumn() { DataPropertyName = nameof(MonsterGroupRow.C5) },
        new DataGridViewComboBoxColumn() { DataPropertyName = nameof(MonsterGroupRow.C6) },
      });

      foreach (DataGridViewColumn column in dgv.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
        column.ReadOnly   = true;
        column.SortMode   = DataGridViewColumnSortMode.NotSortable;
        column.Width      = 40;

        if (column is DataGridViewComboBoxColumn comboBoxColumn) {
          comboBoxColumn.DataSource = _monstersAsText.Select(x => x.Text).ToList();
          comboBoxColumn.ReadOnly   = false;
          comboBoxColumn.Width      = 180;
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
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();
      btnOK.Click     += (s, e) => { MapMonsterRowsToGroup(); DialogResult = DialogResult.OK; Close(); };

      dgv.CellClick += (s, e) => { 
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) {
          dgv.BeginEdit(true);
          ((ComboBox)dgv.EditingControl).DroppedDown = true;
        }
      };
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
            case 1: monsterGroupRow.C1 = monsterAsText.Text; break;
            case 2: monsterGroupRow.C2 = monsterAsText.Text; break;
            case 3: monsterGroupRow.C3 = monsterAsText.Text; break;
            case 4: monsterGroupRow.C4 = monsterAsText.Text; break;
            case 5: monsterGroupRow.C5 = monsterAsText.Text; break;
            case 6: monsterGroupRow.C6 = monsterAsText.Text; break;
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

      MonsterGroup.MonsterIndices[0]  = GetMonsterIndex(row1.C1);
      MonsterGroup.MonsterIndices[1]  = GetMonsterIndex(row1.C2);
      MonsterGroup.MonsterIndices[2]  = GetMonsterIndex(row1.C3);
      MonsterGroup.MonsterIndices[3]  = GetMonsterIndex(row1.C4);
      MonsterGroup.MonsterIndices[4]  = GetMonsterIndex(row1.C5);
      MonsterGroup.MonsterIndices[5]  = GetMonsterIndex(row1.C6);

      MonsterGroup.MonsterIndices[6]  = GetMonsterIndex(row2.C1);
      MonsterGroup.MonsterIndices[7]  = GetMonsterIndex(row2.C2);
      MonsterGroup.MonsterIndices[8]  = GetMonsterIndex(row2.C3);
      MonsterGroup.MonsterIndices[9]  = GetMonsterIndex(row2.C4);
      MonsterGroup.MonsterIndices[10] = GetMonsterIndex(row2.C5);
      MonsterGroup.MonsterIndices[11] = GetMonsterIndex(row2.C6);

      MonsterGroup.MonsterIndices[12] = GetMonsterIndex(row3.C1);
      MonsterGroup.MonsterIndices[13] = GetMonsterIndex(row3.C2);
      MonsterGroup.MonsterIndices[14] = GetMonsterIndex(row3.C3);
      MonsterGroup.MonsterIndices[15] = GetMonsterIndex(row3.C4);
      MonsterGroup.MonsterIndices[16] = GetMonsterIndex(row3.C5);
      MonsterGroup.MonsterIndices[17] = GetMonsterIndex(row3.C6);

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

      foreach (MonsterData monster in _monsters) {
        _monstersAsText.Add(
          new() { 
            Index = monster.Index,
            Text = $"{monster.Index}: {monster.Name} ({monster.Level})"
          }
        );
      }
    }
    #endregion
  }
}