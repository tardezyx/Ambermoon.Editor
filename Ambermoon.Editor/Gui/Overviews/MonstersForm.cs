using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Data.GameDataRepository.Util;
using Ambermoon.Editor.Gui.Controls;
using Ambermoon.Editor.Gui.Editors;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews {
  public partial class MonstersForm : Form {
    #region --- fields ----------------------------------------------------------------------------
    private readonly ListWrapper<MonsterData> _monsters;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public MonstersForm(DictionaryList<MonsterData> monsters) {
      InitializeComponent();
      _monsters = new(monsters);
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      dgv.AutoGenerateColumns = false;

      dgv.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewButtonColumn () { DataPropertyName = "Remove", Text = "X", UseColumnTextForButtonValue = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Index) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Name) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Level) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Type) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Race) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Class) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Gender) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Element) },
      });

      foreach (DataGridViewColumn column in dgv.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      dgv.DataSource = _monsters.ForDisplay;
      dgv.AutoResizeColumns();
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);
      InitDGV();
      WireEvents();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnAdd.Click += (s, e) => AddMonster();

      dgv.CellClick += (s, e) => { 
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) {
          RemoveMonster((MonsterData)dgv.Rows[e.RowIndex].DataBoundItem);
        }
      };

      dgv.CellDoubleClick += (s, e) => {
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is not DataGridViewButtonColumn) {
          ChangeMonster((MonsterData)dgv.Rows[e.RowIndex].DataBoundItem, e.RowIndex);
        }
      };
    }
    #endregion

    #region --- add monster -----------------------------------------------------------------------
    private void AddMonster() {
      uint index = _monsters.GetFirstFreeIndex();

      MonsterForm form = new(
        new MonsterData() {
          Index = index,
          Name  = "(NEW...)"
        }
      );

      if (form.ShowDialog() == DialogResult.OK) {
        _monsters.Add(form.Monster);
        dgv.AutoResizeColumns();

        foreach (DataGridViewRow row in dgv.Rows) {
          if (((MonsterData)row.DataBoundItem).Index == index) {
            dgv.ClearSelection();
            dgv.FirstDisplayedScrollingRowIndex = row.Index;
            row.Selected = true;

            break;
          }
        }
      }
    }
    #endregion
    #region --- change monster --------------------------------------------------------------------
    private void ChangeMonster(MonsterData monster, int rowIndex) {
      MonsterForm form = new(monster);

      if (form.ShowDialog() == DialogResult.OK) {
        _monsters.HasBeenChanged();
        dgv.InvalidateRow(rowIndex);
        dgv.AutoResizeColumns();
      }
    }
    #endregion
    #region --- remove monster --------------------------------------------------------------------
    private void RemoveMonster(MonsterData monster) {
      string n = Environment.NewLine;

      if (
        MsgBox.Show(
          $"Remove {monster.Index}: {monster.Name} ({monster.Level})?",
          $"Do you really want to remove the following monster?{n}{n}"
          + $"Index: {monster.Index}{n}Name: {monster.Name}{n}Level: {monster.Level}",
          MessageBoxButtons.YesNo
        ) == DialogResult.Yes
      ) {
        _monsters.Remove(monster);
        dgv.AutoResizeColumns();
      }
    }
    #endregion
  }
}