using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Gui.Editors;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews {
  public partial class MonstersForm : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private readonly ListWrapper<MonsterData> _monsters;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public MonstersForm() {
      InitializeComponent();
      _monsters = new(Repository.Current.GameData?.Monsters);
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

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
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.DefeatExperience) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Food) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Gold) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.Morale) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.AttacksPerRound) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.BaseAttackDamage) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.MagicAttackLevel) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.BaseDefense) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.MagicDefenseLevel) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.BonusSpellDamage) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.BonusMaxSpellDamage) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.BonusSpellDamagePercentage) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MonsterData.BonusSpellDamageReduction) },
      });

      foreach (DataGridViewColumn column in dgv.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      dgv.DataSource = _monsters.ForDisplay;
      dgv.AutoResizeColumns();

      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
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
      if (_monsters.InRepository.Create() is MonsterData newMonster) {
        EditMonsterForm form = new(newMonster);

        if (form.ShowDialog() == DialogResult.OK) {
          _monsters.Add(newMonster);
          dgv.AutoResizeColumns();

          foreach (DataGridViewRow row in dgv.Rows) {
            if (((MonsterData)row.DataBoundItem).Index == newMonster.Index) {
              dgv.ClearSelection();
              dgv.FirstDisplayedScrollingRowIndex = row.Index;
              row.Selected = true;

              break;
            }
          }
        }
      }
    }
    #endregion
    #region --- change monster --------------------------------------------------------------------
    private void ChangeMonster(MonsterData monster, int rowIndex) {
      EditMonsterForm form = new(monster);

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