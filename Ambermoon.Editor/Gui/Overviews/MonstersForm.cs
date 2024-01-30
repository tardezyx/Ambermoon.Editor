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
      dgv.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewButtonColumn () { Name = "Remove", Text = "X", UseColumnTextForButtonValue = true },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Index) },
        new DataGridViewImageColumn()   { Name = "Graphic" },
        new DataGridViewImageColumn()   { Name = "Icon" },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Name) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Race) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Gender) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Class) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Level) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Element) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.DefeatExperience) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Morale) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Gold) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Food) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.BaseAttackDamage) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.MagicAttackLevel) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.AttacksPerRound) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.BaseDefense) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.MagicDefenseLevel) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.BonusSpellDamage) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.BonusMaxSpellDamage) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.BonusSpellDamagePercentage) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.BonusSpellDamageReduction) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.SpellMastery) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.SpellTypeImmunity) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterData.Conditions) },
      });

      dgv.DataSource = _monsters.ForDisplay;
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);
      InitDGV();
      WireEvents();
    }
    #endregion
    #region --- on shown --------------------------------------------------------------------------
    protected override void OnShown(EventArgs e) {
      base.OnShown(e);

      SetGraphics();
    }
    #endregion
    #region --- set graphics ----------------------------------------------------------------------
    private void SetGraphics() {
      foreach (DataGridViewRow row in dgv.Rows) {
        if (
          row.DataBoundItem is MonsterData monster
          && row.Cells["Graphic"] is DataGridViewImageCell combatGraphicCell
          && row.Cells["Icon"] is DataGridViewImageCell combatIconCell
        ) {
          combatGraphicCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
          combatGraphicCell.Value       = monster.GetCombatGraphic();
          //combatIconCell.ImageLayout    = DataGridViewImageCellLayout.Zoom;
          combatIconCell.Value          = monster.GetCombatIconGraphic();
        }
      }
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

      dgv.Sorted += (s, e) => SetGraphics();
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