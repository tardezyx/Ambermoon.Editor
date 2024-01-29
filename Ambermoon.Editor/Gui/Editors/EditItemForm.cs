using Ambermoon.Data;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Data.GameDataRepository.Enumerations;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditItemForm : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private readonly ItemData                       _item;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditItemForm(ItemData item) {
      InitializeComponent();

      _item = item;

      //cbxClass.DataSource                   = _item.Class.GetValuesAsOrderedStringList();
      cbxCombatBackgroundDaytime.DataSource = CombatBackgroundDaytime.Day.GetValuesAsOrderedStringList();
      //cbxElement.DataSource                 = _item.Element.GetValuesAsOrderedStringList();
      cbxGender.DataSource                  = _item.Gender.GetValuesAsOrderedStringList();
      //cbxRace.DataSource                    = _item.Race.GetValuesAsOrderedStringList();
      cbxType.DataSource                    = _item.Type.GetValuesAsOrderedStringList();
      nudCombatBackgroundIndex.Maximum      = Repository.Current.GameData.DistinctCombatBackgroundImages.Count;
      //nudCombatGraphicIndex.Maximum         = Repository.Current.GameData!.itemImages.Count;
      nudPaletteIndex.Maximum               = Repository.Current.GameData!.Palettes.Count;
    }
    #endregion
    #region --- init dgv: attributes --------------------------------------------------------------
    //private void InitDGVAttributes() {
    //  _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

    //  dgvAttributes.AutoGenerateColumns = false;
    //  dgvAttributes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

    //  dgvAttributes.Columns.AddRange(new DataGridViewColumn[] {
    //    new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Name),                   ReadOnly = true },
    //    new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Short),                  ReadOnly = true },
    //    new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Current), MaxValue = 99 },
    //    new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Bonus),   MaxValue = 99, ReadOnly = true },
    //    new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Max),     MaxValue = 99 },
    //  });

    //  foreach (DataGridViewColumn column in dgvAttributes.Columns) {
    //    column.HeaderText = column.Name = column.DataPropertyName;
    //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
    //  }

    //  dgvAttributes.DataSource = _attributes;
    //  dgvAttributes.AutoResizeColumns();

    //  _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
    //}
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();
      WireEvents();

      MapitemToControls();
      //GetCombatGraphics();
      //InitDGVAttributes();
    }
    #endregion
    #region --- update check boxes: battle flags --------------------------------------------------
    private void UpdateCheckBoxesBattleFlags(object? s, BattleFlags flag) {
      if (s is CheckBox checkBox && checkBox.Checked) {
        if (flag == BattleFlags.None) {
          chbxBattleFlagsAnimal.Checked = false;
          chbxBattleFlagsBonusEarth.Checked = false;
          chbxBattleFlagsBonusFire.Checked = false;
          chbxBattleFlagsBonusWind.Checked = false;
          chbxBattleFlagsBoss.Checked = false;
          chbxBattleFlagsDemon.Checked = false;
          chbxBattleFlagsUndead.Checked = false;
        } else {
          chbxBattleFlagsNone.Checked = false;
        }
      }

      if (
           !chbxBattleFlagsAnimal.Checked
        && !chbxBattleFlagsBonusEarth.Checked
        && !chbxBattleFlagsBonusFire.Checked
        && !chbxBattleFlagsBonusWind.Checked
        && !chbxBattleFlagsBoss.Checked
        && !chbxBattleFlagsDemon.Checked
        && !chbxBattleFlagsUndead.Checked
      ) {
        chbxBattleFlagsNone.Checked = true;
        chbxBattleFlagsNone.Enabled = false;
      } else { 
        chbxBattleFlagsNone.Enabled = true;
      }
    }
    #endregion
    #region --- update check boxes: conditions ----------------------------------------------------
    private void UpdateCheckBoxesConditions(object? s, Condition flag) {
      if (s is CheckBox checkBox && checkBox.Checked) {
        if (flag == Condition.None) {
          chbxConditionsAging.Checked = false;
          chbxConditionsBlind.Checked = false;
          chbxConditionsCrazy.Checked = false;
          chbxConditionsDeadAshes.Checked = false;
          chbxConditionsDeadCorpse.Checked = false;
          chbxConditionsDeadDust.Checked = false;
          chbxConditionsDiseased.Checked = false;
          chbxConditionsDrugged.Checked = false;
          chbxConditionsExhausted.Checked = false; 
          chbxConditionsIrritated.Checked = false;
          chbxConditionsLamed.Checked = false;
          chbxConditionsPanic.Checked = false;
          chbxConditionsPetrified.Checked = false;
          chbxConditionsPoisoned.Checked = false;
          chbxConditionsSleep.Checked = false;
          chbxConditionsUnused.Checked = false;
        } else {
          chbxConditionsNone.Checked = false;
        }
      }

      if (
           !chbxConditionsAging.Checked
        && !chbxConditionsBlind.Checked
        && !chbxConditionsCrazy.Checked
        && !chbxConditionsDeadAshes.Checked 
        && !chbxConditionsDeadCorpse.Checked
        && !chbxConditionsDeadDust.Checked
        && !chbxConditionsDiseased.Checked
        && !chbxConditionsDrugged.Checked
        && !chbxConditionsExhausted.Checked 
        && !chbxConditionsIrritated.Checked 
        && !chbxConditionsLamed.Checked
        && !chbxConditionsPanic.Checked
        && !chbxConditionsPetrified.Checked
        && !chbxConditionsPoisoned.Checked
        && !chbxConditionsSleep.Checked
        && !chbxConditionsUnused.Checked
      ) {
        chbxConditionsNone.Checked = true;
        chbxConditionsNone.Enabled = false;
      } else { 
        chbxConditionsNone.Enabled = true;
      }
    }
    #endregion
    #region --- update check boxes: spell immunity ------------------------------------------------
    private void UpdateCheckBoxesSpellImmunity(object? s, SpellTypeImmunity flag) {
      if (s is CheckBox checkBox && checkBox.Checked) {
        if (flag == SpellTypeImmunity.None) {
          chbxSpellImmunityAlchemistic.Checked = false;
          chbxSpellImmunityDestruction.Checked = false;
          chbxSpellImmunityFunction.Checked = false;
          chbxSpellImmunityHealing.Checked = false;
          chbxSpellImmunityMystic.Checked = false;
          chbxSpellImmunityUnused.Checked = false;
          chbxSpellImmunityUnused1.Checked = false;
          chbxSpellImmunityUnused2.Checked = false;
        } else {
          chbxSpellImmunityNone.Checked = false;
        }
      }

      if (
           !chbxSpellImmunityAlchemistic.Checked
        && !chbxSpellImmunityDestruction.Checked
        && !chbxSpellImmunityFunction.Checked
        && !chbxSpellImmunityHealing.Checked
        && !chbxSpellImmunityMystic.Checked
        && !chbxSpellImmunityUnused.Checked
        && !chbxSpellImmunityUnused1.Checked
        && !chbxSpellImmunityUnused2.Checked
      ) {
        chbxSpellImmunityNone.Checked = true;
        chbxSpellImmunityNone.Enabled = false;
      } else { 
        chbxSpellImmunityNone.Enabled = true;
      }
    }
    #endregion
    #region --- update check boxes: spell mastery -------------------------------------------------
    private void UpdateCheckBoxesSpellMastery(object? s, SpellTypeMastery flag) {
      if (s is CheckBox checkBox && checkBox.Checked) {
        if (flag == SpellTypeMastery.None) {
          chbxSpellMasteryAlchemistic.Checked = false;
          chbxSpellMasteryAll.Enabled = true;
          chbxSpellMasteryAll.Checked = false;
          chbxSpellMasteryDestruction.Checked = false;
          chbxSpellMasteryFunction.Checked = false;
          chbxSpellMasteryHealing.Checked = false;
          chbxSpellMasteryMastered.Checked = false;
          chbxSpellMasteryMystic.Checked = false;
          chbxSpellMasteryUnused1.Checked = false;
          chbxSpellMasteryUnused2.Checked = false;
        } else {
          chbxSpellMasteryNone.Checked = false;

          if (flag == SpellTypeMastery.All) { 
            chbxSpellMasteryAlchemistic.Checked = true;
            chbxSpellMasteryDestruction.Checked = true;
            chbxSpellMasteryFunction.Checked = true;
            chbxSpellMasteryHealing.Checked = true;
            chbxSpellMasteryMystic.Checked = true;
            chbxSpellMasteryUnused1.Checked = true;
            chbxSpellMasteryUnused2.Checked = true;  
          }
        }
      }

      chbxSpellMasteryAll.Checked = chbxSpellMasteryAlchemistic.Checked
        && chbxSpellMasteryDestruction.Checked
        && chbxSpellMasteryFunction.Checked
        && chbxSpellMasteryHealing.Checked
        && chbxSpellMasteryMystic.Checked
        && chbxSpellMasteryUnused1.Checked
        && chbxSpellMasteryUnused2.Checked;

      chbxSpellMasteryAll.Enabled = !chbxSpellMasteryAll.Checked;

      chbxSpellMasteryMastered.Enabled = chbxSpellMasteryAlchemistic.Checked
        || chbxSpellMasteryDestruction.Checked
        || chbxSpellMasteryFunction.Checked
        || chbxSpellMasteryHealing.Checked
        || chbxSpellMasteryMystic.Checked
        || chbxSpellMasteryUnused1.Checked
        || chbxSpellMasteryUnused2.Checked;

      if (!chbxSpellMasteryMastered.Enabled) {
        chbxSpellMasteryMastered.Checked = false;
      }

      if (
           !chbxSpellMasteryAlchemistic.Checked
        && !chbxSpellMasteryAll.Checked
        && !chbxSpellMasteryDestruction.Checked
        && !chbxSpellMasteryFunction.Checked
        && !chbxSpellMasteryHealing.Checked
        && !chbxSpellMasteryMastered.Checked
        && !chbxSpellMasteryMystic.Checked
        && !chbxSpellMasteryUnused1.Checked
        && !chbxSpellMasteryUnused2.Checked
      ) {
        chbxSpellMasteryNone.Checked = true;
        chbxSpellMasteryNone.Enabled = false;
      } else { 
        chbxSpellMasteryNone.Enabled = true;
      }
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();
      btnOK.Click += (s, e) => { MapControlsToitem(); DialogResult = DialogResult.OK; Close(); };

      chbxBattleFlagsAnimal.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.Animal);
      chbxBattleFlagsBonusEarth.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.EarthSpellDamageBonus);
      chbxBattleFlagsBonusFire.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.FireSpellDamageBonus);
      chbxBattleFlagsBonusWind.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.WindSpellDamageBonus);
      chbxBattleFlagsBoss.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.Boss);
      chbxBattleFlagsDemon.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.Demon);
      chbxBattleFlagsNone.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.None);
      chbxBattleFlagsUndead.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.Undead);

      chbxConditionsAging.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Aging);
      chbxConditionsBlind.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Blind);
      chbxConditionsCrazy.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Crazy);
      chbxConditionsDeadAshes.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.DeadAshes);
      chbxConditionsDeadCorpse.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.DeadCorpse);
      chbxConditionsDeadDust.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.DeadDust);
      chbxConditionsDiseased.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Diseased);
      chbxConditionsDrugged.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Drugged);
      chbxConditionsExhausted.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Exhausted);
      chbxConditionsIrritated.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Irritated);
      chbxConditionsLamed.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Lamed);
      chbxConditionsNone.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.None);
      chbxConditionsPanic.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Panic);
      chbxConditionsPetrified.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Petrified);
      chbxConditionsPoisoned.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Poisoned);
      chbxConditionsSleep.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Sleep);
      chbxConditionsUnused.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Unused);

      chbxSpellImmunityAlchemistic.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Alchemistic);
      chbxSpellImmunityDestruction.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Destruction);
      chbxSpellImmunityFunction.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Function);
      chbxSpellImmunityHealing.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Healing);
      chbxSpellImmunityMystic.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Mystic);
      chbxSpellImmunityNone.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.None);
      chbxSpellImmunityUnused.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Unused);
      chbxSpellImmunityUnused1.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Unused1);
      chbxSpellImmunityUnused2.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Unused2);
      
      chbxSpellMasteryNone.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.None);
      chbxSpellMasteryAlchemistic.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Alchemistic);
      chbxSpellMasteryAll.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.All);
      chbxSpellMasteryDestruction.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Destruction);
      chbxSpellMasteryFunction.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Function);
      chbxSpellMasteryHealing.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Healing);
      chbxSpellMasteryMastered.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Mastered);
      chbxSpellMasteryMystic.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Mystic);
      chbxSpellMasteryUnused1.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Unused1);
      chbxSpellMasteryUnused2.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Unused2);

      chbxZoom.CheckStateChanged += (s, e) => { pbxCombatGraphic.SizeMode = chbxZoom.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage; };

      //nudCombatBackgroundIndex.ValueChanged += (s, e) => GetCombatGraphics();
      //nudCombatGraphicIndex.ValueChanged += (s, e) => GetCombatGraphics();
    }
    #endregion

    #region --- get combat graphics ---------------------------------------------------------------
    //private void GetCombatGraphics() {
    //  _animationFrames.Clear();

    //  if (Repository.Current.GameData is null) { 
    //    return;
    //  }

    //  CombatBackgroundDaytime daytime = cbxCombatBackgroundDaytime.Text
    //    .GetEnumByName<CombatBackgroundDaytime>();

    //  CombatBackground background = Repository.Current.CombatBackgrounds
    //    .First(x => x.Index == nudCombatBackgroundIndex.Value);

    //  Data.GameDataRepository.Image itemImage = Repository.Current.GameData
    //    .itemImages[(uint)nudCombatGraphicIndex.Value];

    //  Palette palette = background.GetPalette(daytime);

    //  foreach (ImageData frame in itemImage.Frames) {
    //    Bitmap combatGraphicBitmap = WindowsExtensions.ToBitmap(frame, palette, true);
    //    _animationFrames.Add(combatGraphicBitmap);
    //  }

    //  cbxCombatBackgroundDaytime.Enabled = background.HasDaytimes;
    //  nudPaletteIndex.Value = palette.Index;
    //  pbxCombatGraphic.BackgroundImage = background.GetRenderedFrame(daytime);
    //}
    #endregion
    #region --- map controls to item -----------------------------------------------------------
    private void MapControlsToitem() {
      _item.Name = tbxName.Text;
      
      //_item.Class   = cbxClass.Text.GetEnumByName<Class>();
      //_item.Element = cbxElement.Text.GetEnumByName<CharacterElement>();
      //_item.Gender  = cbxGender.Text.GetEnumByName<Gender>();
      //_item.Race    = cbxRace.Text.GetEnumByName<Race>();
      ////_item.Type    = cbxType.Text.GetEnumByName<CharacterType>();

      //_item.BattleFlags = BattleFlags.None
      //  | (chbxBattleFlagsAnimal.Checked ? BattleFlags.Animal : BattleFlags.None)
      //  | (chbxBattleFlagsBonusEarth.Checked ? BattleFlags.EarthSpellDamageBonus : BattleFlags.None)
      //  | (chbxBattleFlagsBonusFire.Checked ? BattleFlags.FireSpellDamageBonus : BattleFlags.None)
      //  | (chbxBattleFlagsBonusWind.Checked ? BattleFlags.WindSpellDamageBonus : BattleFlags.None)
      //  | (chbxBattleFlagsBoss.Checked ? BattleFlags.Boss : BattleFlags.None)
      //  | (chbxBattleFlagsDemon.Checked ? BattleFlags.Demon : BattleFlags.None)
      //  | (chbxBattleFlagsUndead.Checked ? BattleFlags.Undead : BattleFlags.None);

      //_item.Conditions = Condition.None
      //  | (chbxConditionsAging.Checked ? Condition.Aging : Condition.None)
      //  | (chbxConditionsBlind.Checked ? Condition.Blind : Condition.None)
      //  | (chbxConditionsCrazy.Checked ? Condition.Crazy : Condition.None)
      //  | (chbxConditionsDeadAshes.Checked ? Condition.DeadAshes : Condition.None)
      //  | (chbxConditionsDeadCorpse.Checked ? Condition.DeadCorpse : Condition.None)
      //  | (chbxConditionsDeadDust.Checked ? Condition.DeadDust : Condition.None)
      //  | (chbxConditionsDiseased.Checked ? Condition.Diseased : Condition.None)
      //  | (chbxConditionsDrugged.Checked ? Condition.Drugged : Condition.None)
      //  | (chbxConditionsExhausted.Checked ? Condition.Exhausted : Condition.None)
      //  | (chbxConditionsIrritated.Checked ? Condition.Irritated : Condition.None)
      //  | (chbxConditionsLamed.Checked ? Condition.Lamed : Condition.None)
      //  | (chbxConditionsPanic.Checked ? Condition.Panic : Condition.None)
      //  | (chbxConditionsPetrified.Checked ? Condition.Petrified : Condition.None)
      //  | (chbxConditionsPoisoned.Checked ? Condition.Poisoned : Condition.None)
      //  | (chbxConditionsSleep.Checked ? Condition.Sleep : Condition.None)
      //  | (chbxConditionsUnused.Checked ? Condition.Unused : Condition.None);

      //_item.SpellTypeImmunity = SpellTypeImmunity.None
      //  | (chbxSpellImmunityAlchemistic.Checked ? SpellTypeImmunity.Alchemistic : SpellTypeImmunity.None)
      //  | (chbxSpellImmunityDestruction.Checked ? SpellTypeImmunity.Destruction : SpellTypeImmunity.None)
      //  | (chbxSpellImmunityFunction.Checked ? SpellTypeImmunity.Function : SpellTypeImmunity.None)
      //  | (chbxSpellImmunityHealing.Checked ? SpellTypeImmunity.Healing : SpellTypeImmunity.None)
      //  | (chbxSpellImmunityMystic.Checked ? SpellTypeImmunity.Mystic : SpellTypeImmunity.None)
      //  | (chbxSpellImmunityUnused.Checked ? SpellTypeImmunity.Unused : SpellTypeImmunity.None)
      //  | (chbxSpellImmunityUnused1.Checked ? SpellTypeImmunity.Unused1 : SpellTypeImmunity.None)
      //  | (chbxSpellImmunityUnused2.Checked ? SpellTypeImmunity.Unused2 : SpellTypeImmunity.None);

      //_item.SpellMastery = SpellTypeMastery.None
      //  | (chbxSpellMasteryAlchemistic.Checked ? SpellTypeMastery.Alchemistic : SpellTypeMastery.None)
      //  | (chbxSpellMasteryAll.Checked ? SpellTypeMastery.All : SpellTypeMastery.None)
      //  | (chbxSpellMasteryDestruction.Checked ? SpellTypeMastery.Destruction : SpellTypeMastery.None)
      //  | (chbxSpellMasteryFunction.Checked ? SpellTypeMastery.Function : SpellTypeMastery.None)
      //  | (chbxSpellMasteryHealing.Checked ? SpellTypeMastery.Healing : SpellTypeMastery.None)
      //  | (chbxSpellMasteryMastered.Checked ? SpellTypeMastery.Mastered : SpellTypeMastery.None)
      //  | (chbxSpellMasteryMystic.Checked ? SpellTypeMastery.Mystic : SpellTypeMastery.None)
      //  | (chbxSpellMasteryUnused1.Checked ? SpellTypeMastery.Unused1 : SpellTypeMastery.None)
      //  | (chbxSpellMasteryUnused2.Checked ? SpellTypeMastery.Unused2 : SpellTypeMastery.None);

      //_item.BaseAttackDamage = (uint)nudAttackBase.Value;
      ////_item.BonusAttackDamage = nudAttackBonus.Value;

      //_item.MagicAttackLevel = (int)nudAttackMagicLevel.Value;
      //_item.AttacksPerRound = (uint)nudAttacksPerRound.Value;
      //_item.BonusSpellDamage = (uint)nudBonusSpellDamageBase.Value;
      //_item.BonusMaxSpellDamage = (uint)nudBonusSpellDamageMax.Value;
      //_item.BonusSpellDamagePercentage = (int)nudBonusSpellDamagePercentage.Value;
      //_item.BonusSpellDamageReduction = (int)nudBonusSpellDamageReduction.Value;
      //_item.DefeatExperience = (uint)nudDefeatExperience.Value;
      //_item.BaseDefense = (uint)nudDefenseBase.Value;
      ////_item.BonusDefense = nudDefenseBonus.Value;
      ////_item.CombatGraphicIndex = (uint)nudCombatGraphicIndex.Value;
      //_item.MagicDefenseLevel = (int)nudDefenseMagicLevel.Value;
      //_item.Food = (uint)nudFood.Value;
      //_item.Gold = (uint)nudGold.Value;
      //_item.HitPoints.BonusValue = (int)nudHitPointsBonus.Value;
      //_item.HitPoints.CurrentValue = (uint)nudHitPointsCurrent.Value;
      //_item.HitPoints.MaxValue = (uint)nudHitPointsMax.Value;
      //_item.Level = (uint)nudLevel.Value;
      //_item.Morale = (uint)nudMorale.Value;
      //_item.SpellPoints.BonusValue = (int)nudSpellPointsBonus.Value;
      //_item.SpellPoints.CurrentValue = (uint)nudSpellPointsCurrent.Value;
      //_item.SpellPoints.MaxValue = (uint)nudSpellPointsMax.Value;

      //tbxIndex.Text = _item.Index.ToString();
      //tbxName.Text = _item.Name;

      //foreach (CharValue attribute in _attributes) {
      //  if (Repository.Current.GetAttributeIndex(attribute.Name) is int index) {
      //    _item.Attributes[index].BonusValue = attribute.Bonus;
      //    _item.Attributes[index].CurrentValue = attribute.Current;
      //    _item.Attributes[index].MaxValue = attribute.Max;
      //    _item.Attributes[index].StoredValue = attribute.Stored;
      //    //_item.Attributes[index].TotalCurrentValue = attribute.TotalCurrent;
      //    //_item.Attributes[index].TotalMaxValue = attribute.TotalMax;
      //  }
      //}

      //foreach (CharValue skill in _skills) {
      //  if (Repository.Current.GetSkillIndex(skill.Name) is int index) {
      //    _item.Skills[index].BonusValue = skill.Bonus;
      //    _item.Skills[index].CurrentValue = skill.Current;
      //    _item.Skills[index].MaxValue = skill.Max;
      //    _item.Skills[index].StoredValue = skill.Stored;
      //    //_item.Skills[index].TotalCurrentValue = attribute.TotalCurrent;
      //    //_item.Skills[index].TotalMaxValue = attribute.TotalMax;
      //  }
      //}

      //_item.LearnedSpellsAlchemistic = 0;
      //_item.LearnedSpellsDestruction = 0;
      //_item.LearnedSpellsFunctional = 0;
      //_item.LearnedSpellsHealing = 0;
      //_item.LearnedSpellsMystic = 0;
      //_item.LearnedSpellsType5 = 0;
      //_item.LearnedSpellsType6 = 0;

      //foreach (Spell spell in _spells) {
      //  uint spellValue = (uint)Math.Pow(2, spell.Index + 1);

      //  switch (Repository.Current.GameData!.SpellClassNames.IndexOf(spell.School)) {
      //    case 0: _item.LearnedSpellsHealing += spellValue; break;
      //    case 1: _item.LearnedSpellsAlchemistic += spellValue; break;
      //    case 2: _item.LearnedSpellsMystic += spellValue; break;
      //    case 3: _item.LearnedSpellsDestruction += spellValue; break;
      //    case 4: _item.LearnedSpellsType5 += spellValue; break;
      //    case 5: _item.LearnedSpellsType6 += spellValue; break;
      //    case 6: _item.LearnedSpellsFunctional += spellValue; break;
      //  };
      //}
    }
    #endregion
    #region --- map item to controls -----------------------------------------------------------
    private void MapitemToControls() {
      //cbxClass.SelectedIndex = ((List<string>)cbxClass.DataSource!).FindIndex(x => x == _item.Class.ToString());
      //cbxElement.SelectedIndex = ((List<string>)cbxElement.DataSource!).FindIndex(x => x == _item.Element.ToString());
      //cbxGender.SelectedIndex = ((List<string>)cbxGender.DataSource!).FindIndex(x => x == _item.Gender.ToString());
      //cbxRace.SelectedIndex = ((List<string>)cbxRace.DataSource!).FindIndex(x => x == _item.Race.ToString());
      //cbxType.SelectedIndex = ((List<string>)cbxType.DataSource!).FindIndex(x => x == _item.Type.ToString());

      //chbxBattleFlagsAnimal.Checked = _item.BattleFlags.HasFlag(BattleFlags.Animal);
      //chbxBattleFlagsBonusEarth.Checked = _item.BattleFlags.HasFlag(BattleFlags.EarthSpellDamageBonus);
      //chbxBattleFlagsBonusFire.Checked = _item.BattleFlags.HasFlag(BattleFlags.FireSpellDamageBonus);
      //chbxBattleFlagsBonusWind.Checked = _item.BattleFlags.HasFlag(BattleFlags.WindSpellDamageBonus);
      //chbxBattleFlagsBoss.Checked = _item.BattleFlags.HasFlag(BattleFlags.Boss);
      //chbxBattleFlagsDemon.Checked = _item.BattleFlags.HasFlag(BattleFlags.Demon);
      //chbxBattleFlagsNone.Checked = _item.BattleFlags == BattleFlags.None;
      //chbxBattleFlagsUndead.Checked = _item.BattleFlags.HasFlag(BattleFlags.Undead);

      //chbxConditionsAging.Checked = _item.Conditions.HasFlag(Condition.Aging);
      //chbxConditionsBlind.Checked = _item.Conditions.HasFlag(Condition.Blind);
      //chbxConditionsCrazy.Checked = _item.Conditions.HasFlag(Condition.Crazy);
      //chbxConditionsDeadAshes.Checked = _item.Conditions.HasFlag(Condition.DeadAshes);
      //chbxConditionsDeadCorpse.Checked = _item.Conditions.HasFlag(Condition.DeadCorpse);
      //chbxConditionsDeadDust.Checked = _item.Conditions.HasFlag(Condition.DeadDust);
      //chbxConditionsDiseased.Checked = _item.Conditions.HasFlag(Condition.Diseased);
      //chbxConditionsDrugged.Checked = _item.Conditions.HasFlag(Condition.Drugged);
      //chbxConditionsExhausted.Checked = _item.Conditions.HasFlag(Condition.Exhausted);
      //chbxConditionsIrritated.Checked = _item.Conditions.HasFlag(Condition.Irritated);
      //chbxConditionsLamed.Checked = _item.Conditions.HasFlag(Condition.Lamed);
      //chbxConditionsNone.Checked = _item.Conditions == Condition.None;
      //chbxConditionsPanic.Checked = _item.Conditions.HasFlag(Condition.Panic);
      //chbxConditionsPetrified.Checked = _item.Conditions.HasFlag(Condition.Petrified);
      //chbxConditionsPoisoned.Checked = _item.Conditions.HasFlag(Condition.Poisoned);
      //chbxConditionsSleep.Checked = _item.Conditions.HasFlag(Condition.Sleep);
      //chbxConditionsUnused.Checked = _item.Conditions.HasFlag(Condition.Unused);

      //chbxSpellImmunityAlchemistic.Checked = _item.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Alchemistic);
      //chbxSpellImmunityDestruction.Checked = _item.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Destruction);
      //chbxSpellImmunityFunction.Checked = _item.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Function);
      //chbxSpellImmunityHealing.Checked = _item.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Healing);
      //chbxSpellImmunityMystic.Checked = _item.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Mystic);
      //chbxSpellImmunityNone.Checked = _item.SpellTypeImmunity == SpellTypeImmunity.None;
      //chbxSpellImmunityUnused.Checked = _item.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Unused);
      //chbxSpellImmunityUnused1.Checked = _item.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Unused1);
      //chbxSpellImmunityUnused2.Checked = _item.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Unused2);

      //chbxSpellMasteryAlchemistic.Checked = _item.SpellMastery.HasFlag(SpellTypeMastery.Alchemistic);
      //chbxSpellMasteryAll.Checked = _item.SpellMastery.HasFlag(SpellTypeMastery.All);
      //chbxSpellMasteryDestruction.Checked = _item.SpellMastery.HasFlag(SpellTypeMastery.Destruction);
      //chbxSpellMasteryFunction.Checked = _item.SpellMastery.HasFlag(SpellTypeMastery.Function);
      //chbxSpellMasteryHealing.Checked = _item.SpellMastery.HasFlag(SpellTypeMastery.Healing);
      //chbxSpellMasteryMastered.Checked = _item.SpellMastery.HasFlag(SpellTypeMastery.Mastered);
      //chbxSpellMasteryMystic.Checked = _item.SpellMastery.HasFlag(SpellTypeMastery.Mystic);
      //chbxSpellMasteryNone.Checked = _item.SpellMastery == SpellTypeMastery.None;
      //chbxSpellMasteryUnused1.Checked = _item.SpellMastery.HasFlag(SpellTypeMastery.Unused1);
      //chbxSpellMasteryUnused2.Checked = _item.SpellMastery.HasFlag(SpellTypeMastery.Unused2);

      //nudAttackBase.Value = _item.BaseAttackDamage;
      //nudAttackBonus.Value = _item.BonusAttackDamage;
      //nudAttackMagicLevel.Value = _item.MagicAttackLevel;
      //nudAttacksPerRound.Value = _item.AttacksPerRound;
      //nudBonusSpellDamageBase.Value = _item.BonusSpellDamage;
      //nudBonusSpellDamageMax.Value = _item.BonusMaxSpellDamage;
      //nudBonusSpellDamagePercentage.Value = _item.BonusSpellDamagePercentage;
      //nudBonusSpellDamageReduction.Value = _item.BonusSpellDamageReduction;
      //nudCombatGraphicIndex.Value = _item.CombatGraphicIndex;
      //nudDefeatExperience.Value = _item.DefeatExperience;
      //nudDefenseBase.Value = _item.BaseDefense;
      //nudDefenseBonus.Value = _item.BonusDefense;
      //nudDefenseMagicLevel.Value = _item.MagicDefenseLevel;
      //nudFood.Value = _item.Food;
      //nudGold.Value = _item.Gold;
      //nudHitPointsBonus.Value = _item.HitPoints.BonusValue;
      //nudHitPointsCurrent.Value = _item.HitPoints.CurrentValue;
      //nudHitPointsMax.Value = _item.HitPoints.MaxValue;
      //nudLevel.Value = _item.Level;
      //nudMorale.Value = _item.Morale;
      //nudSpellPointsBonus.Value = _item.SpellPoints.BonusValue;
      //nudSpellPointsCurrent.Value = _item.SpellPoints.CurrentValue;
      //nudSpellPointsMax.Value = _item.SpellPoints.MaxValue;

      //tbxIndex.Text = _item.Index.ToString();
      //tbxName.Text = _item.Name;

      //int index = 0;
      //foreach (CharacterValue characterValue in _item.Attributes) {
      //  _attributes.Add(
      //    new() {
      //      Bonus = characterValue.BonusValue,
      //      Current = characterValue.CurrentValue,
      //      Max = characterValue.MaxValue,
      //      Name = Repository.Current.GetAttributeName(index),
      //      Short = Repository.Current.GetAttributeShortName(index),
      //      Stored = characterValue.StoredValue
      //    }
      //  );

      //  index++;
      //}

      //index = 0;
      //foreach (CharacterValue characterValue in _item.Skills) {
      //  _skills.Add(
      //    new() {
      //      Bonus = characterValue.BonusValue,
      //      Current = characterValue.CurrentValue,
      //      Max = characterValue.MaxValue,
      //      Name = Repository.Current.GetSkillName(index),
      //      Short = Repository.Current.GetSkillShortName(index),
      //      Stored = characterValue.StoredValue
      //    }
      //  );

      //  index++;
      //}

      //foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Alchemistic, _item.LearnedSpellsAlchemistic)) { _spells.Add(spell); }
      //foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Destruction, _item.LearnedSpellsDestruction)) { _spells.Add(spell); }
      //foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Function, _item.LearnedSpellsFunctional)) { _spells.Add(spell); }
      //foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Healing, _item.LearnedSpellsHealing)) { _spells.Add(spell); }
      //foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Mystic, _item.LearnedSpellsMystic)) { _spells.Add(spell); }
      //foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Unknown1, _item.LearnedSpellsType5)) { _spells.Add(spell); }
      //foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Unknown2, _item.LearnedSpellsType5)) { _spells.Add(spell); }
    }
    #endregion
  }
}