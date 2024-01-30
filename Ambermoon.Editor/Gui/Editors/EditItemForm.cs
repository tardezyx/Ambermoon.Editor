using Ambermoon.Data;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditItemForm : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private readonly ItemData _item;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditItemForm(ItemData item) {
      InitializeComponent();

      _item = item;
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();
      WireEvents();
      SetControls();

      MapItemToControls();
      //GetCombatGraphics();
      //InitDGVAttributes();
    }
    #endregion
    #region --- set controls ------------------------------------------------------------------------
    private void SetControls() {
      cbxAmmunitionType.DataSource = _item.AmmunitionType.GetValuesAsOrderedStringList();
      cbxAttribute.DataSource      = _item.Attribute.GetValuesAsOrderedStringList();
      cbxEquipmentSlot.DataSource  = _item.EquipmentSlot.GetValuesAsOrderedStringList();
      cbxGender.DataSource         = _item.Gender.GetValuesAsOrderedStringList();
      cbxPenaltySkill1.DataSource  = _item.PenaltySkill1.GetValuesAsOrderedStringList();
      cbxPenaltySkill2.DataSource  = _item.PenaltySkill2.GetValuesAsOrderedStringList();
      cbxSkill.DataSource          = _item.Skill.GetValuesAsOrderedStringList();
      cbxSpecialPurpose.DataSource = SpecialItemPurpose.Compass.GetValuesAsOrderedStringList();
      cbxSpell.DataSource          = _item.Spell.GetValuesAsOrderedStringList();
      cbxTransportation.DataSource = Transportation.FlyingDisc.GetValuesAsOrderedStringList();
      cbxType.DataSource           = _item.Type.GetValuesAsOrderedStringList();
      cbxUsedAmmunition.DataSource = _item.UsedAmmunitionType.GetValuesAsOrderedStringList();

      nudAttribute.SetMinMaxByProperty(_item, nameof(_item.AttributeValue));
      nudBreakChance.SetMinMaxByProperty(_item, nameof(_item.BreakChance));
      nudDamage.SetMinMaxByProperty(_item, nameof(_item.Damage));
      nudDefense.SetMinMaxByProperty(_item, nameof(_item.Defense));
      nudEnchantPrice.SetMinMaxByProperty(_item, nameof(_item.EnchantPrice));
      nudFingers.SetMinMaxByProperty(_item, nameof(_item.NumberOfFingers));
      nudGraphicIndex.Maximum = Repository.Current.GameData!.ItemImages.Keys.Max();
      nudGraphicIndex.Minimum = Repository.Current.GameData!.ItemImages.Keys.Min();
      nudHands.SetMinMaxByProperty(_item, nameof(_item.NumberOfHands));
      nudHitPoints.SetMinMaxByProperty(_item, nameof(_item.HitPoints));
      nudInitialRecharges.SetMinMaxByProperty(_item, nameof(_item.InitialNumberOfRecharges));
      nudInitialSpellCharges.SetMinMaxByProperty(_item, nameof(_item.InitialSpellCharges));
      nudMagicAttackLevel.SetMinMaxByProperty(_item, nameof(_item.MagicAttackLevel));
      nudMagicDefenseLevel.SetMinMaxByProperty(_item, nameof(_item.MagicDefenseLevel));
      nudMaxRecharges.SetMinMaxByProperty(_item, nameof(_item.MaxNumberOfRecharges));
      nudMaxSpellCharges.SetMinMaxByProperty(_item, nameof(_item.MaxSpellCharges));
      nudPenaltySkill1.SetMinMaxByProperty(_item, nameof(_item.PenaltyValue1));
      nudPenaltySkill2.SetMinMaxByProperty(_item, nameof(_item.PenaltyValue2));
      nudPrice.SetMinMaxByProperty(_item, nameof(_item.Price));
      nudSpellPoints.SetMinMaxByProperty(_item, nameof(_item.SpellPoints));
      nudSkill.SetMinMaxByProperty(_item, nameof(_item.SkillValue));
      nudText.SetMinMaxByProperty(_item, nameof(_item.TextIndex));
      nudTextSub.SetMinMaxByProperty(_item, nameof(_item.TextSubIndex));
      nudWeight.SetMinMaxByProperty(_item, nameof(_item.Weight));
      tbxName.SetMaxLengthByProperty(_item, nameof(_item.Name));

      pbxGraphic.SizeMode = chbxZoom.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
    }
    #endregion
    #region --- update check boxes: battle flags --------------------------------------------------
    private void UpdateCheckBoxesBattleFlags(object? s, BattleFlags flag) {
      if (s is CheckBox checkBox && checkBox.Checked) {
        if (flag == BattleFlags.None) {
          chbxItemFlagsAccursed.Checked = false;
          chbxItemFlagsRemovableDuringFight.Checked = false;
          chbxItemFlagsDestroyAfterUsage.Checked = false;
          chbxItemFlagsIndestructible.Checked = false;
          chbxItemFlagsCloneable.Checked = false;
          chbxItemFlagsNotImportant.Checked = false;
          chbxItemFlagsStackable.Checked = false;
        } else {
          chbxItemFlagsNone.Checked = false;
        }
      }

      if (
           !chbxItemFlagsAccursed.Checked
        && !chbxItemFlagsRemovableDuringFight.Checked
        && !chbxItemFlagsDestroyAfterUsage.Checked
        && !chbxItemFlagsIndestructible.Checked
        && !chbxItemFlagsCloneable.Checked
        && !chbxItemFlagsNotImportant.Checked
        && !chbxItemFlagsStackable.Checked
      ) {
        chbxItemFlagsNone.Checked = true;
        chbxItemFlagsNone.Enabled = false;
      } else {
        chbxItemFlagsNone.Enabled = true;
      }
    }
    #endregion
    #region --- update check boxes: conditions ----------------------------------------------------
    private void UpdateCheckBoxesConditions(object? s, Condition flag) {
      //if (s is CheckBox checkBox && checkBox.Checked) {
      //  if (flag == Condition.None) {
      //    chbxClassesAdventurer.Checked = false;
      //    chbxClassesWarrior.Checked = false;
      //    chbxClassesPaladin.Checked = false;
      //    chbxClassesHealer.Checked = false;
      //    chbxClassesAlchemist.Checked = false;
      //    chbxClassesMystic.Checked = false;
      //    chbxClassesMonster.Checked = false;
      //    chbxConditionsDrugged.Checked = false;
      //    chbxConditionsExhausted.Checked = false;
      //    chbxClassesThief.Checked = false;
      //    chbxClassesRanger.Checked = false;
      //    chbxConditionsPanic.Checked = false;
      //    chbxClassesMage.Checked = false;
      //    chbxClassesAnimal.Checked = false;
      //    chbxConditionsSleep.Checked = false;
      //    chbxClassesUnused1.Checked = false;
      //  } else {
      //    chbxClassesNone.Checked = false;
      //  }
      //}

      //if (
      //     !chbxClassesAdventurer.Checked
      //  && !chbxClassesWarrior.Checked
      //  && !chbxClassesPaladin.Checked
      //  && !chbxClassesHealer.Checked
      //  && !chbxClassesAlchemist.Checked
      //  && !chbxClassesMystic.Checked
      //  && !chbxClassesMonster.Checked
      //  && !chbxConditionsDrugged.Checked
      //  && !chbxConditionsExhausted.Checked
      //  && !chbxClassesThief.Checked
      //  && !chbxClassesRanger.Checked
      //  && !chbxConditionsPanic.Checked
      //  && !chbxClassesMage.Checked
      //  && !chbxClassesAnimal.Checked
      //  && !chbxConditionsSleep.Checked
      //  && !chbxClassesUnused1.Checked
      //) {
      //  chbxClassesNone.Checked = true;
      //  chbxClassesNone.Enabled = false;
      //} else {
      //  chbxClassesNone.Enabled = true;
      //}
    }
    #endregion
    #region --- update check boxes: spell immunity ------------------------------------------------
    private void UpdateCheckBoxesSpellImmunity(object? s, SpellTypeImmunity flag) {
      //if (s is CheckBox checkBox && checkBox.Checked) {
      //  if (flag == SpellTypeImmunity.None) {
      //    chbxSpellImmunityAlchemistic.Checked = false;
      //    chbxSpellImmunityDestruction.Checked = false;
      //    chbxSpellImmunityFunction.Checked = false;
      //    chbxSpellImmunityHealing.Checked = false;
      //    chbxSpellImmunityMystic.Checked = false;
      //    chbxSpellImmunityUnused.Checked = false;
      //    chbxSpellImmunityUnused1.Checked = false;
      //    chbxSpellImmunityUnused2.Checked = false;
      //  } else {
      //    chbxSpellImmunityNone.Checked = false;
      //  }
      //}

      //if (
      //     !chbxSpellImmunityAlchemistic.Checked
      //  && !chbxSpellImmunityDestruction.Checked
      //  && !chbxSpellImmunityFunction.Checked
      //  && !chbxSpellImmunityHealing.Checked
      //  && !chbxSpellImmunityMystic.Checked
      //  && !chbxSpellImmunityUnused.Checked
      //  && !chbxSpellImmunityUnused1.Checked
      //  && !chbxSpellImmunityUnused2.Checked
      //) {
      //  chbxSpellImmunityNone.Checked = true;
      //  chbxSpellImmunityNone.Enabled = false;
      //} else {
      //  chbxSpellImmunityNone.Enabled = true;
      //}
    }
    #endregion
    #region --- update check boxes: spell mastery -------------------------------------------------
    private void UpdateCheckBoxesSpellMastery(object? s, SpellTypeMastery flag) {
      //if (s is CheckBox checkBox && checkBox.Checked) {
      //  if (flag == SpellTypeMastery.None) {
      //    chbxDefaultSlotFlagBroken.Checked = false;
      //    chbxSpellMasteryAll.Enabled = true;
      //    chbxSpellMasteryAll.Checked = false;
      //    chbxDefaultSlotFlagIdentified.Checked = false;
      //    chbxDefaultSlotFlagCursed.Checked = false;
      //    chbxDefaultSlotFlagLocked.Checked = false;
      //    chbxSpellMasteryMastered.Checked = false;
      //    chbxSpellMasteryMystic.Checked = false;
      //    chbxSpellMasteryUnused1.Checked = false;
      //    chbxSpellMasteryUnused2.Checked = false;
      //  } else {
      //    chbxDefaultSlotFlagNone.Checked = false;

      //    if (flag == SpellTypeMastery.All) {
      //      chbxDefaultSlotFlagBroken.Checked = true;
      //      chbxDefaultSlotFlagIdentified.Checked = true;
      //      chbxDefaultSlotFlagCursed.Checked = true;
      //      chbxDefaultSlotFlagLocked.Checked = true;
      //      chbxSpellMasteryMystic.Checked = true;
      //      chbxSpellMasteryUnused1.Checked = true;
      //      chbxSpellMasteryUnused2.Checked = true;
      //    }
      //  }
      //}

      //chbxSpellMasteryAll.Checked = chbxDefaultSlotFlagBroken.Checked
      //  && chbxDefaultSlotFlagIdentified.Checked
      //  && chbxDefaultSlotFlagCursed.Checked
      //  && chbxDefaultSlotFlagLocked.Checked
      //  && chbxSpellMasteryMystic.Checked
      //  && chbxSpellMasteryUnused1.Checked
      //  && chbxSpellMasteryUnused2.Checked;

      //chbxSpellMasteryAll.Enabled = !chbxSpellMasteryAll.Checked;

      //chbxSpellMasteryMastered.Enabled = chbxDefaultSlotFlagBroken.Checked
      //  || chbxDefaultSlotFlagIdentified.Checked
      //  || chbxDefaultSlotFlagCursed.Checked
      //  || chbxDefaultSlotFlagLocked.Checked
      //  || chbxSpellMasteryMystic.Checked
      //  || chbxSpellMasteryUnused1.Checked
      //  || chbxSpellMasteryUnused2.Checked;

      //if (!chbxSpellMasteryMastered.Enabled) {
      //  chbxSpellMasteryMastered.Checked = false;
      //}

      //if (
      //     !chbxDefaultSlotFlagBroken.Checked
      //  && !chbxSpellMasteryAll.Checked
      //  && !chbxDefaultSlotFlagIdentified.Checked
      //  && !chbxDefaultSlotFlagCursed.Checked
      //  && !chbxDefaultSlotFlagLocked.Checked
      //  && !chbxSpellMasteryMastered.Checked
      //  && !chbxSpellMasteryMystic.Checked
      //  && !chbxSpellMasteryUnused1.Checked
      //  && !chbxSpellMasteryUnused2.Checked
      //) {
      //  chbxDefaultSlotFlagNone.Checked = true;
      //  chbxDefaultSlotFlagNone.Enabled = false;
      //} else {
      //  chbxDefaultSlotFlagNone.Enabled = true;
      //}
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();
      btnOK.Click += (s, e) => { MapControlsToItem(); DialogResult = DialogResult.OK; Close(); };

      //chbxItemFlagsAccursed.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.Animal);
      //chbxItemFlagsRemovableDuringFight.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.EarthSpellDamageBonus);
      //chbxItemFlagsDestroyAfterUsage.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.FireSpellDamageBonus);
      //chbxItemFlagsIndestructible.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.WindSpellDamageBonus);
      //chbxItemFlagsCloneable.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.Boss);
      //chbxItemFlagsNotImportant.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.Demon);
      //chbxItemFlagsNone.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.None);
      //chbxItemFlagsStackable.CheckStateChanged += (s, e) => UpdateCheckBoxesBattleFlags(s, BattleFlags.Undead);

      //chbxClassesAdventurer.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Aging);
      //chbxClassesWarrior.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Blind);
      //chbxClassesPaladin.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Crazy);
      //chbxClassesHealer.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.DeadAshes);
      //chbxClassesAlchemist.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.DeadCorpse);
      //chbxClassesMystic.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.DeadDust);
      //chbxClassesMonster.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Diseased);
      //chbxConditionsDrugged.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Drugged);
      //chbxConditionsExhausted.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Exhausted);
      //chbxClassesThief.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Irritated);
      //chbxClassesRanger.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Lamed);
      //chbxClassesNone.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.None);
      //chbxConditionsPanic.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Panic);
      //chbxClassesMage.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Petrified);
      //chbxClassesAnimal.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Poisoned);
      //chbxConditionsSleep.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Sleep);
      //chbxClassesUnused1.CheckStateChanged += (s, e) => UpdateCheckBoxesConditions(s, Condition.Unused);

      //chbxSpellImmunityAlchemistic.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Alchemistic);
      //chbxSpellImmunityDestruction.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Destruction);
      //chbxSpellImmunityFunction.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Function);
      //chbxSpellImmunityHealing.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Healing);
      //chbxSpellImmunityMystic.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Mystic);
      //chbxSpellImmunityNone.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.None);
      //chbxSpellImmunityUnused.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Unused);
      //chbxSpellImmunityUnused1.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Unused1);
      //chbxSpellImmunityUnused2.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellImmunity(s, SpellTypeImmunity.Unused2);

      //chbxDefaultSlotFlagNone.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.None);
      //chbxDefaultSlotFlagBroken.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Alchemistic);
      //chbxSpellMasteryAll.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.All);
      //chbxDefaultSlotFlagIdentified.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Destruction);
      //chbxDefaultSlotFlagCursed.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Function);
      //chbxDefaultSlotFlagLocked.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Healing);
      //chbxSpellMasteryMastered.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Mastered);
      //chbxSpellMasteryMystic.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Mystic);
      //chbxSpellMasteryUnused1.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Unused1);
      //chbxSpellMasteryUnused2.CheckStateChanged += (s, e) => UpdateCheckBoxesSpellMastery(s, SpellTypeMastery.Unused2);

      chbxZoom.CheckStateChanged += (s, e) => { pbxGraphic.SizeMode = chbxZoom.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage; };

      nudGraphicIndex.ValueChanged += (s, e) => {
        if (_item.GetGraphic((int)nudGraphicIndex.Value) is Bitmap itemGraphic) { 
          Icon             = itemGraphic.GetIcon(24, 24);
          pbxGraphic.Image = itemGraphic;
        }
      };
    }
    #endregion

    #region --- map controls to item -----------------------------------------------------------
    private void MapControlsToItem() {
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
    private void MapItemToControls() {
      cbxAmmunitionType.SelectedIndex = ((List<string>)cbxAmmunitionType.DataSource!).FindIndex(x => x == _item.AmmunitionType.ToString());
      cbxAttribute.SelectedIndex      = ((List<string>)cbxAttribute.DataSource!).FindIndex(x => x == _item.Attribute.ToString());
      cbxEquipmentSlot.SelectedIndex  = ((List<string>)cbxEquipmentSlot.DataSource!).FindIndex(x => x == _item.EquipmentSlot.ToString());
      cbxGender.SelectedIndex         = ((List<string>)cbxGender.DataSource!).FindIndex(x => x == _item.Gender.ToString());
      cbxPenaltySkill1.SelectedIndex  = ((List<string>)cbxPenaltySkill1.DataSource!).FindIndex(x => x == _item.PenaltySkill1.ToString());
      cbxPenaltySkill2.SelectedIndex  = ((List<string>)cbxPenaltySkill2.DataSource!).FindIndex(x => x == _item.PenaltySkill2.ToString());
      cbxSkill.SelectedIndex          = ((List<string>)cbxSkill.DataSource!).FindIndex(x => x == _item.Skill.ToString());
      cbxSpecialPurpose.SelectedIndex = ((List<string>)cbxSpecialPurpose.DataSource!).FindIndex(x => x == _item.SpecialItemPurpose.ToString());
      cbxSpell.SelectedIndex          = ((List<string>)cbxSpell.DataSource!).FindIndex(x => x == _item.Spell.ToString());
      cbxTransportation.SelectedIndex = ((List<string>)cbxTransportation.DataSource!).FindIndex(x => x == _item.Transportation.ToString());
      cbxType.SelectedIndex           = ((List<string>)cbxType.DataSource!).FindIndex(x => x == _item.Type.ToString());
      cbxUsedAmmunition.SelectedIndex = ((List<string>)cbxUsedAmmunition.DataSource!).FindIndex(x => x == _item.UsedAmmunitionType.ToString());

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

      nudAttribute.Value = _item.AttributeValue;
      nudBreakChance.Value = _item.BreakChance;
      nudDamage.Value = _item.Damage;
      nudDefense.Value = _item.Defense;
      nudEnchantPrice.Value = _item.EnchantPrice;
      nudFingers.Value = _item.NumberOfFingers;
      nudGraphicIndex.Value = _item.GraphicIndex;
      nudHands.Value = _item.NumberOfHands;
      nudHitPoints.Value = _item.HitPoints;
      nudInitialRecharges.Value = _item.InitialNumberOfRecharges;
      nudInitialSpellCharges.Value = _item.InitialSpellCharges;
      nudMagicAttackLevel.Value = _item.MagicAttackLevel;
      nudMagicDefenseLevel.Value = _item.MagicDefenseLevel;
      nudMaxRecharges.Value = _item.MaxNumberOfRecharges;
      nudMaxSpellCharges.Value = _item.MaxSpellCharges;
      nudPenaltySkill1.Value = _item.PenaltyValue1;
      nudPenaltySkill2.Value = _item.PenaltyValue2;
      nudPrice.Value = _item.Price;
      nudSpellPoints.Value = _item.SpellPoints;
      nudSkill.Value = _item.SkillValue;
      nudText.Value = _item.TextIndex.HasValue ? (decimal)_item.TextIndex : 0;
      nudTextSub.Value = _item.TextSubIndex.HasValue ? (decimal)_item.TextSubIndex : 0;
      nudWeight.Value = _item.Weight;

      tbxIndex.Text = _item.Index.ToString();
      tbxName.Text = _item.Name;
    }
    #endregion
  }
}