using Ambermoon.Data;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditMonsterForm : Form {
    #region --- fields ----------------------------------------------------------------------------
    private readonly SortableBindingList<CharValue> _attributes = [];
    private          MonsterData                    _monster;
    private readonly SortableBindingList<CharValue> _skills = [];
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditMonsterForm(MonsterData monster) {
      InitializeComponent();

      _monster = monster;

      cbxClass.DataSource   = _monster.Class.GetValuesAsOrderedStringList();
      cbxElement.DataSource = _monster.Element.GetValuesAsOrderedStringList();
      cbxGender.DataSource  = _monster.Gender.GetValuesAsOrderedStringList();
      cbxRace.DataSource    = _monster.Race.GetValuesAsOrderedStringList();
      cbxType.DataSource    = _monster.Type.GetValuesAsOrderedStringList();

      int index = 0;
      foreach (CharacterValue characterValue in monster.Attributes) {
        _attributes.Add(
          new() { 
            Bonus   = characterValue.BonusValue,
            Current = characterValue.CurrentValue,
            Max     = characterValue.MaxValue,
            Name    = Repository.Current.GetAttributeName(index),
            Short   = Repository.Current.GetAttributeShortName(index),
            Stored  = characterValue.StoredValue
          }
        );

        index++;
      }

      index = 0;
      foreach (CharacterValue characterValue in monster.Skills) {
        _skills.Add(
          new() { 
            Bonus   = characterValue.BonusValue,
            Current = characterValue.CurrentValue,
            Max     = characterValue.MaxValue,
            Name    = Repository.Current.GetSkillName(index),
            Short   = Repository.Current.GetSkillShortName(index),
            Stored  = characterValue.StoredValue
          }
        );

        index++;
      }


    }
    #endregion
    #region --- init dgv: attributes --------------------------------------------------------------
    private void InitDGVAttributes() {
      dgvAttributes.AutoGenerateColumns = false;

      dgvAttributes.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Name),                   ReadOnly = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Short),                  ReadOnly = true },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Current), MaxValue = 99 },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Bonus),   MaxValue = 99, ReadOnly = true },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Max),     MaxValue = 99 },
      });

      foreach (DataGridViewColumn column in dgvAttributes.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      dgvAttributes.DataSource = _attributes;
      dgvAttributes.AutoResizeColumns();
    }
    #endregion
    #region --- init dgv: equipment ---------------------------------------------------------------
    private void InitDGVEquipment() {
      dgvEquipment.AutoGenerateColumns = false;

      dgvEquipment.Columns.AddRange(new DataGridViewColumn[] {
        //new DataGridViewTextBoxColumn() { DataPropertyName = nameof(SkillValue.Name), ReadOnly = true },
      });

      foreach (DataGridViewColumn column in dgvEquipment.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      //dgvEquipment.DataSource = _skills;
      dgvEquipment.AutoResizeColumns();
    }
    #endregion
    #region --- init dgv: items -------------------------------------------------------------------
    private void InitDGVItems() {
      dgvItems.AutoGenerateColumns = false;

      dgvItems.Columns.AddRange(new DataGridViewColumn[] {
        //new DataGridViewTextBoxColumn() { DataPropertyName = nameof(SkillValue.Name), ReadOnly = true },
      });

      foreach (DataGridViewColumn column in dgvItems.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      //dgvItems.DataSource = _skills;
      dgvItems.AutoResizeColumns();
    }
    #endregion
    #region --- init dgv: skills ------------------------------------------------------------------
    private void InitDGVSkills() {
      dgvSkills.AutoGenerateColumns = false;

      dgvSkills.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Name),                   ReadOnly = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Short),                  ReadOnly = true },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Current), MaxValue = 99 },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Bonus),   MaxValue = 99, ReadOnly = true },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Max),     MaxValue = 99 },
      });

      foreach (DataGridViewColumn column in dgvSkills.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      dgvSkills.DataSource = _skills;
      dgvSkills.AutoResizeColumns();
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();      
      MapMonsterToControls();
      InitDGVAttributes();
      InitDGVEquipment();
      InitDGVItems();
      InitDGVSkills();
      WireEvents();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click         += (s, e) => Close();
      btnOK.Click             += (s, e) => { MapControlsToMonster(); DialogResult = DialogResult.OK; Close(); };
      dgvAttributes.CellClick += (s, e) => { if (e.RowIndex > -1) { dgvAttributes.BeginEdit(true); } };
      dgvEquipment.CellClick  += (s, e) => { if (e.RowIndex > -1) { dgvEquipment.BeginEdit(true); } };
      dgvItems.CellClick      += (s, e) => { if (e.RowIndex > -1) { dgvItems.BeginEdit(true); } };
      dgvSkills.CellClick     += (s, e) => { if (e.RowIndex > -1) { dgvSkills.BeginEdit(true); } };
    }
    #endregion

    #region --- map controls to monster -----------------------------------------------------------
    private void MapControlsToMonster() {
      _monster.Name = tbxName.Text;
      // ...
    }
    #endregion
    #region --- map monster to controls -----------------------------------------------------------
    private void MapMonsterToControls() {
      cbxClass.SelectedIndex   = ((List<string>)cbxClass.DataSource!).FindIndex(x => x == _monster.Class.ToString());
      cbxElement.SelectedIndex = ((List<string>)cbxElement.DataSource!).FindIndex(x => x == _monster.Element.ToString());
      cbxGender.SelectedIndex  = ((List<string>)cbxGender.DataSource!).FindIndex(x => x == _monster.Gender.ToString());
      cbxRace.SelectedIndex    = ((List<string>)cbxRace.DataSource!).FindIndex(x => x == _monster.Race.ToString());
      cbxType.SelectedIndex    = ((List<string>)cbxType.DataSource!).FindIndex(x => x == _monster.Type.ToString());

      chbxBattleFlagsAnimal.Checked = _monster.BattleFlags.HasFlag(Data.BattleFlags.Animal);
      chbxBattleFlagsBonusEarth.Checked = _monster.BattleFlags.HasFlag(Data.BattleFlags.EarthSpellDamageBonus);
      chbxBattleFlagsBonusFire.Checked = _monster.BattleFlags.HasFlag(Data.BattleFlags.FireSpellDamageBonus);
      chbxBattleFlagsBonusWind.Checked = _monster.BattleFlags.HasFlag(Data.BattleFlags.WindSpellDamageBonus);
      chbxBattleFlagsBoss.Checked = _monster.BattleFlags.HasFlag(Data.BattleFlags.Boss);
      chbxBattleFlagsDemon.Checked = _monster.BattleFlags.HasFlag(Data.BattleFlags.Demon);
      chbxBattleFlagsNone.Checked = _monster.BattleFlags == Data.BattleFlags.None;
      chbxBattleFlagsUndead.Checked = _monster.BattleFlags.HasFlag(Data.BattleFlags.Undead);
      
      chbxConditionsAging.Checked = _monster.Conditions.HasFlag(Data.Condition.Aging);
      chbxConditionsBlind.Checked = _monster.Conditions.HasFlag(Data.Condition.Blind);
      chbxConditionsCrazy.Checked = _monster.Conditions.HasFlag(Data.Condition.Crazy);
      chbxConditionsDeadAshes.Checked = _monster.Conditions.HasFlag(Data.Condition.DeadAshes);
      chbxConditionsDeadCorpse.Checked = _monster.Conditions.HasFlag(Data.Condition.DeadCorpse);
      chbxConditionsDeadDust.Checked = _monster.Conditions.HasFlag(Data.Condition.DeadDust);
      chbxConditionsDiseased.Checked = _monster.Conditions.HasFlag(Data.Condition.Diseased);
      chbxConditionsDrugged.Checked = _monster.Conditions.HasFlag(Data.Condition.Drugged);
      chbxConditionsExhausted.Checked = _monster.Conditions.HasFlag(Data.Condition.Exhausted);
      chbxConditionsIrritated.Checked = _monster.Conditions.HasFlag(Data.Condition.Irritated);
      chbxConditionsLamed.Checked = _monster.Conditions.HasFlag(Data.Condition.Lamed);
      chbxConditionsNone.Checked = _monster.Conditions == Data.Condition.None;
      chbxConditionsPanic.Checked = _monster.Conditions.HasFlag(Data.Condition.Panic);
      chbxConditionsPetrified.Checked = _monster.Conditions.HasFlag(Data.Condition.Petrified);
      chbxConditionsPoisoned.Checked = _monster.Conditions.HasFlag(Data.Condition.Poisoned);
      chbxConditionsSleep.Checked = _monster.Conditions.HasFlag(Data.Condition.Sleep);
      chbxConditionsUnused.Checked = _monster.Conditions.HasFlag(Data.Condition.Unused);

      chbxSpellImmunityAlchemistic.Checked = _monster.SpellTypeImmunity.HasFlag(Data.SpellTypeImmunity.Alchemistic);
      chbxSpellImmunityDestruction.Checked = _monster.SpellTypeImmunity.HasFlag(Data.SpellTypeImmunity.Destruction);
      chbxSpellImmunityFunction.Checked = _monster.SpellTypeImmunity.HasFlag(Data.SpellTypeImmunity.Function);
      chbxSpellImmunityHealing.Checked = _monster.SpellTypeImmunity.HasFlag(Data.SpellTypeImmunity.Healing);
      chbxSpellImmunityMystic.Checked = _monster.SpellTypeImmunity.HasFlag(Data.SpellTypeImmunity.Mystic);
      chbxSpellImmunityNone.Checked = _monster.SpellTypeImmunity == Data.SpellTypeImmunity.None;
      chbxSpellImmunityUnused.Checked = _monster.SpellTypeImmunity.HasFlag(Data.SpellTypeImmunity.Unused);
      chbxSpellImmunityUnused1.Checked = _monster.SpellTypeImmunity.HasFlag(Data.SpellTypeImmunity.Unused1);
      chbxSpellImmunityUnused2.Checked = _monster.SpellTypeImmunity.HasFlag(Data.SpellTypeImmunity.Unused2);

      chbxSpellMasteryAlchemistic.Checked = _monster.SpellMastery.HasFlag(Data.SpellTypeMastery.Alchemistic);
      chbxSpellMasteryAll.Checked = _monster.SpellMastery.HasFlag(Data.SpellTypeMastery.All);
      chbxSpellMasteryDestruction.Checked = _monster.SpellMastery.HasFlag(Data.SpellTypeMastery.Destruction);
      chbxSpellMasteryFunction.Checked = _monster.SpellMastery.HasFlag(Data.SpellTypeMastery.Function);
      chbxSpellMasteryHealing.Checked = _monster.SpellMastery.HasFlag(Data.SpellTypeMastery.Healing);
      chbxSpellMasteryMastered.Checked = _monster.SpellMastery.HasFlag(Data.SpellTypeMastery.Mastered);
      chbxSpellMasteryMystic.Checked = _monster.SpellMastery.HasFlag(Data.SpellTypeMastery.Mystic);
      chbxSpellMasteryNone.Checked = _monster.SpellMastery == Data.SpellTypeMastery.None;
      chbxSpellMasteryUnused1.Checked = _monster.SpellMastery.HasFlag(Data.SpellTypeMastery.Unused1);
      chbxSpellMasteryUnused2.Checked = _monster.SpellMastery.HasFlag(Data.SpellTypeMastery.Unused2);

      nudAttackBase.Value = _monster.BaseAttackDamage;
      nudAttackMagicLevel.Value = _monster.MagicAttackLevel;
      nudAttacksPerRound.Value = _monster.AttacksPerRound;
      nudBonusSpellDamageMax.Value = _monster.BonusMaxSpellDamage;
      nudDefeatExperience.Value = _monster.DefeatExperience;
      nudDefenseBase.Value = _monster.BaseDefense;
      nudDefenseMagicLevel.Value = _monster.MagicDefenseLevel;
      nudFood.Value = _monster.Food;
      nudGold.Value = _monster.Gold;
      nudHitPointsMax.Value = _monster.HitPoints.MaxValue;
      nudLevel.Value = _monster.Level;
      nudMorale.Value = _monster.Morale;
      nudSpellPointsMax.Value = _monster.SpellPoints.MaxValue;

      tbxAttackBonus.Text = _monster.BonusAttackDamage.ToString();
      tbxBonusSpellDamageBase.Text = _monster.BonusSpellDamage.ToString();
      tbxBonusSpellDamagePercentage.Text = _monster.BonusSpellDamagePercentage.ToString();
      tbxBonusSpellDamageReduction.Text = _monster.BonusSpellDamageReduction.ToString();
      tbxDefenseBonus.Text = _monster.BonusDefense.ToString();
      tbxHitPointsBonus.Text = _monster.HitPoints.BonusValue.ToString();
      tbxHitPointsCurrent.Text = _monster.HitPoints.CurrentValue.ToString();
      tbxIndex.Text = _monster.Index.ToString();
      tbxName.Text = _monster.Name;
      tbxSpellPointsBonus.Text = _monster.SpellPoints.BonusValue.ToString();
      tbxSpellPointsCurrent.Text = _monster.SpellPoints.CurrentValue.ToString();
    }
    #endregion
  }
}