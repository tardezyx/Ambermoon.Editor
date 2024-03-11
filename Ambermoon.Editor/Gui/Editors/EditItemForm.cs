using Ambermoon.Data;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Models;
using Attribute = Ambermoon.Data.Attribute;
using Spell = Ambermoon.Data.Spell;

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
    #region --- set controls ----------------------------------------------------------------------
    private void SetControls() {
      cbxAmmunitionType.DataSource = AmmunitionType.None.GetValuesAsOrderedStringList();
      cbxAttribute.DataSource = Attribute.Age.GetValuesAsOrderedStringList();
      cbxEquipmentSlot.DataSource = EquipmentSlot.None.GetValuesAsOrderedStringList();
      cbxGender.DataSource = GenderFlag.None.GetValuesAsOrderedStringList();
      cbxPenaltySkill1.DataSource = Skill.Attack.GetValuesAsOrderedStringList();
      cbxPenaltySkill2.DataSource = Skill.Attack.GetValuesAsOrderedStringList();
      cbxSkill.DataSource = Skill.Attack.GetValuesAsOrderedStringList();
      cbxSpecialPurpose.DataSource = SpecialItemPurpose.Compass.GetValuesAsOrderedStringList();
      cbxSpell.DataSource = Spell.None.GetValuesAsOrderedStringList();
      cbxTransportation.DataSource = Transportation.FlyingDisc.GetValuesAsOrderedStringList();
      cbxType.DataSource = ItemType.None.GetValuesAsOrderedStringList();
      cbxUsedAmmunition.DataSource = AmmunitionType.None.GetValuesAsOrderedStringList();

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
      nudText.Maximum = Repository.Current.GameData!.ItemTexts.Keys.Max();
      nudText.Minimum = 0;
      nudTextSub.Maximum = -1;
      nudTextSub.Minimum = -1;
      nudWeight.SetMinMaxByProperty(_item, nameof(_item.Weight));

      pbxGraphic.SizeMode = chbxZoom.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage;
      pbxTextBorder.Image = new Bitmap(Properties.Resources.background_text);

      tbxName.SetMaxLengthByProperty(_item, nameof(_item.Name));
    }
    #endregion
    #region --- update check boxes: classes -------------------------------------------------------
    private void UpdateCheckBoxesClasses(object? s, ClassFlag flag) {
      if (s is CheckBox checkBox && checkBox.Checked) {
        if (flag == ClassFlag.None) {
          chbxClassesAdventurer.Checked = false;
          chbxClassesAlchemist.Checked = false;
          chbxClassesAll.Checked = false;
          chbxClassesAllWithUnused.Checked = false;
          chbxClassesAnimal.Checked = false;
          chbxClassesHealer.Checked = false;
          chbxClassesMage.Checked = false;
          chbxClassesMonster.Checked = false;
          chbxClassesMystic.Checked = false;
          chbxClassesPaladin.Checked = false;
          chbxClassesRanger.Checked = false;
          chbxClassesThief.Checked = false;
          chbxClassesUnused1.Checked = false;
          chbxClassesUnused2.Checked = false;
          chbxClassesUnused3.Checked = false;
          chbxClassesUnused4.Checked = false;
          chbxClassesWarrior.Checked = false;
        } else {
          chbxClassesNone.Checked = false;

          if (flag == ClassFlag.All) {
            chbxClassesAdventurer.Checked = true;
            chbxClassesAlchemist.Checked = true;
            chbxClassesAnimal.Checked = true;
            chbxClassesHealer.Checked = true;
            chbxClassesMage.Checked = true;
            chbxClassesMystic.Checked = true;
            chbxClassesPaladin.Checked = true;
            chbxClassesRanger.Checked = true;
            chbxClassesThief.Checked = true;
            chbxClassesWarrior.Checked = true;
          }

          if (flag == ClassFlag.AllWithUnused) {
            chbxClassesAdventurer.Checked = true;
            chbxClassesAlchemist.Checked = true;
            chbxClassesAnimal.Checked = true;
            chbxClassesHealer.Checked = true;
            chbxClassesMage.Checked = true;
            chbxClassesMonster.Checked = true;
            chbxClassesMystic.Checked = true;
            chbxClassesPaladin.Checked = true;
            chbxClassesRanger.Checked = true;
            chbxClassesThief.Checked = true;
            chbxClassesUnused1.Checked = true;
            chbxClassesUnused2.Checked = true;
            chbxClassesUnused3.Checked = true;
            chbxClassesUnused4.Checked = true;
            chbxClassesWarrior.Checked = true;
          }
        }
      }

      chbxClassesAll.Checked = chbxClassesAdventurer.Checked
        && chbxClassesAlchemist.Checked
        && chbxClassesAnimal.Checked
        && chbxClassesHealer.Checked
        && chbxClassesMage.Checked
        && chbxClassesMystic.Checked
        && chbxClassesPaladin.Checked
        && chbxClassesRanger.Checked
        && chbxClassesThief.Checked
        && chbxClassesWarrior.Checked;

      chbxClassesAll.Enabled = !chbxClassesAll.Checked;

      chbxClassesAllWithUnused.Checked = chbxClassesAdventurer.Checked
        && chbxClassesAlchemist.Checked
        && chbxClassesAnimal.Checked
        && chbxClassesHealer.Checked
        && chbxClassesMage.Checked
        && chbxClassesMonster.Checked
        && chbxClassesMystic.Checked
        && chbxClassesPaladin.Checked
        && chbxClassesRanger.Checked
        && chbxClassesThief.Checked
        && chbxClassesUnused1.Checked
        && chbxClassesUnused2.Checked
        && chbxClassesUnused3.Checked
        && chbxClassesUnused4.Checked
        && chbxClassesWarrior.Checked;

      chbxClassesAllWithUnused.Enabled = !chbxClassesAllWithUnused.Checked;

      if (
           !chbxClassesAdventurer.Checked
        && !chbxClassesAlchemist.Checked
        && !chbxClassesAll.Checked
        && !chbxClassesAllWithUnused.Checked
        && !chbxClassesAnimal.Checked
        && !chbxClassesHealer.Checked
        && !chbxClassesMage.Checked
        && !chbxClassesMonster.Checked
        && !chbxClassesMystic.Checked
        && !chbxClassesPaladin.Checked
        && !chbxClassesRanger.Checked
        && !chbxClassesThief.Checked
        && !chbxClassesUnused1.Checked
        && !chbxClassesUnused2.Checked
        && !chbxClassesUnused3.Checked
        && !chbxClassesUnused4.Checked
        && !chbxClassesWarrior.Checked
      ) {
        chbxClassesNone.Checked = true;
        chbxClassesNone.Enabled = false;
      } else {
        chbxClassesNone.Enabled = true;
      }
    }
    #endregion
    #region --- update check boxes: default slot --------------------------------------------------
    private void UpdateCheckBoxesDefaultSlot(object? s, ItemSlotFlags flag) {
      if (s is CheckBox checkBox && checkBox.Checked) {
        if (flag == ItemSlotFlags.None) {
          chbxDefaultSlotFlagBroken.Checked = false;
          chbxDefaultSlotFlagCursed.Checked = false;
          chbxDefaultSlotFlagIdentified.Checked = false;
          chbxDefaultSlotFlagLocked.Checked = false;
        } else {
          chbxDefaultSlotFlagNone.Checked = false;
        }

        if (
             !chbxDefaultSlotFlagCursed.Checked
          && !chbxDefaultSlotFlagBroken.Checked
          && !chbxDefaultSlotFlagIdentified.Checked
          && !chbxDefaultSlotFlagLocked.Checked
        ) {
          chbxDefaultSlotFlagNone.Checked = true;
          chbxDefaultSlotFlagNone.Enabled = false;
        } else {
          chbxDefaultSlotFlagNone.Enabled = true;
        }
      }
    }
    #endregion
    #region --- update check boxes: item flags ----------------------------------------------------
    private void UpdateCheckBoxesItemFlags(object? s, ItemFlags flag) {
      if (s is CheckBox checkBox && checkBox.Checked) {
        if (flag == ItemFlags.None) {
          chbxItemFlagsAccursed.Checked = false;
          chbxItemFlagsCloneable.Checked = false;
          chbxItemFlagsDestroyAfterUsage.Checked = false;
          chbxItemFlagsIndestructible.Checked = false;
          chbxItemFlagsNotImportant.Checked = false;
          chbxItemFlagsRemovableDuringFight.Checked = false;
          chbxItemFlagsStackable.Checked = false;
        } else {
          chbxItemFlagsNone.Checked = false;
        }
      }

      if (
           !chbxItemFlagsAccursed.Checked
        && !chbxItemFlagsCloneable.Checked
        && !chbxItemFlagsDestroyAfterUsage.Checked
        && !chbxItemFlagsIndestructible.Checked
        && !chbxItemFlagsNotImportant.Checked
        && !chbxItemFlagsRemovableDuringFight.Checked
        && !chbxItemFlagsStackable.Checked
      ) {
        chbxItemFlagsNone.Checked = true;
        chbxItemFlagsNone.Enabled = false;
      } else {
        chbxItemFlagsNone.Enabled = true;
      }
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();

      btnEditText.Click += (s, e) => {
        EditText form = new(
          Repository.Current.GameData!.ItemTexts,
          (int)nudText.Value,
          (int)nudTextSub.Value
        );

        if (form.ShowDialog() == DialogResult.OK) {
          rtbxText.Text = _item.GetText((int)nudText.Value, (int)nudTextSub.Value);
        }
      };

      btnOK.Click += (s, e) => {
        MapControlsToItem();
        DialogResult = DialogResult.OK;
        Close();
      };

      chbxDefaultSlotFlagBroken.CheckStateChanged += (s, e) => UpdateCheckBoxesDefaultSlot(s, ItemSlotFlags.Broken);
      chbxDefaultSlotFlagCursed.CheckStateChanged += (s, e) => UpdateCheckBoxesDefaultSlot(s, ItemSlotFlags.Cursed);
      chbxDefaultSlotFlagIdentified.CheckStateChanged += (s, e) => UpdateCheckBoxesDefaultSlot(s, ItemSlotFlags.Identified);
      chbxDefaultSlotFlagLocked.CheckStateChanged += (s, e) => UpdateCheckBoxesDefaultSlot(s, ItemSlotFlags.Locked);
      chbxDefaultSlotFlagNone.CheckStateChanged += (s, e) => UpdateCheckBoxesDefaultSlot(s, ItemSlotFlags.None);

      chbxClassesAdventurer.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Adventurer);
      chbxClassesAlchemist.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Alchemist);
      chbxClassesAll.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.All);
      chbxClassesAllWithUnused.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.AllWithUnused);
      chbxClassesAnimal.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Animal);
      chbxClassesHealer.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Healer);
      chbxClassesMage.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Mage);
      chbxClassesMonster.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Monster);
      chbxClassesMystic.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Mystic);
      chbxClassesNone.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.None);
      chbxClassesPaladin.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Paladin);
      chbxClassesRanger.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Ranger);
      chbxClassesThief.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Thief);
      chbxClassesUnused1.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Unknown1);
      chbxClassesUnused2.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Unknown2);
      chbxClassesUnused3.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Unknown3);
      chbxClassesUnused4.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Unknown4);
      chbxClassesWarrior.CheckStateChanged += (s, e) => UpdateCheckBoxesClasses(s, ClassFlag.Warrior);

      chbxFormatText.CheckStateChanged += (s, e) => rtbxText.FormatOutput(chbxFormatText.Checked);

      chbxItemFlagsAccursed.CheckStateChanged += (s, e) => UpdateCheckBoxesItemFlags(s, ItemFlags.Accursed);
      chbxItemFlagsCloneable.CheckStateChanged += (s, e) => UpdateCheckBoxesItemFlags(s, ItemFlags.Cloneable);
      chbxItemFlagsDestroyAfterUsage.CheckStateChanged += (s, e) => UpdateCheckBoxesItemFlags(s, ItemFlags.DestroyAfterUsage);
      chbxItemFlagsIndestructible.CheckStateChanged += (s, e) => UpdateCheckBoxesItemFlags(s, ItemFlags.Indestructible);
      chbxItemFlagsNone.CheckStateChanged += (s, e) => UpdateCheckBoxesItemFlags(s, ItemFlags.None);
      chbxItemFlagsNotImportant.CheckStateChanged += (s, e) => UpdateCheckBoxesItemFlags(s, ItemFlags.NotImportant);
      chbxItemFlagsRemovableDuringFight.CheckStateChanged += (s, e) => UpdateCheckBoxesItemFlags(s, ItemFlags.RemovableDuringFight);
      chbxItemFlagsStackable.CheckStateChanged += (s, e) => UpdateCheckBoxesItemFlags(s, ItemFlags.Stackable);

      chbxZoom.CheckStateChanged += (s, e) => { pbxGraphic.SizeMode = chbxZoom.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage; };

      nudGraphicIndex.ValueChanged += (s, e) => {
        if (_item.GetGraphic((int)nudGraphicIndex.Value) is Bitmap itemGraphic) {
          Icon = itemGraphic.GetIcon(24, 24);
          pbxGraphic.Image = itemGraphic;
        }
      };

      nudText.ValueChanged += (s, e) => {
        if (nudText.Value == 0) {
          nudTextSub.Minimum = -1;
          nudTextSub.Value   = -1;
          nudTextSub.Maximum = -1;
        } else {
          nudTextSub.Maximum = Repository.Current.GameData!.ItemTexts[(uint)nudText.Value].Count - 1;
          nudTextSub.Value   = 0;
          nudTextSub.Minimum = 0;
        }

        rtbxText.Text = _item.GetText((int)nudText.Value, (int)nudTextSub.Value);
      };

      nudTextSub.ValueChanged += (s, e) => rtbxText.Text = _item.GetText((int)nudText.Value, (int)nudTextSub.Value);
    }
    #endregion

    #region --- map controls to item --------------------------------------------------------------
    private void MapControlsToItem() {
      _item.AmmunitionType = cbxAmmunitionType.Text.GetEnumByName<AmmunitionType>();
      _item.Attribute = cbxAttribute.Text.GetEnumByName<Attribute>();
      _item.AttributeValue = (int)nudAttribute.Value;
      _item.BreakChance = (uint)nudBreakChance.Value;
      _item.Damage = (uint)nudDamage.Value;
      _item.Defense = (uint)nudDefense.Value;
      _item.EnchantPrice = (uint)nudEnchantPrice.Value;
      _item.EquipmentSlot = cbxEquipmentSlot.Text.GetEnumByName<EquipmentSlot>();
      _item.Gender = cbxGender.Text.GetEnumByName<GenderFlag>();
      _item.GraphicIndex = (uint)nudGraphicIndex.Value;
      _item.HitPoints = (uint)nudHitPoints.Value;
      _item.InitialNumberOfRecharges = (uint)nudInitialRecharges.Value;
      _item.InitialSpellCharges = (uint)nudInitialSpellCharges.Value;
      _item.MagicAttackLevel = (uint)nudMagicAttackLevel.Value;
      _item.MagicDefenseLevel = (uint)nudMagicDefenseLevel.Value;
      _item.MaxNumberOfRecharges = (uint)nudMaxRecharges.Value;
      _item.MaxSpellCharges = (uint)nudMaxSpellCharges.Value;
      _item.Name = tbxName.Text;
      _item.NumberOfFingers = (uint)nudFingers.Value;
      _item.NumberOfHands = (uint)nudHands.Value;
      _item.PenaltySkill1 = cbxPenaltySkill1.Text.GetEnumByName<Skill>();
      _item.PenaltySkill2 = cbxPenaltySkill2.Text.GetEnumByName<Skill>();
      _item.PenaltyValue1 = (uint)nudPenaltySkill1.Value;
      _item.PenaltyValue2 = (uint)nudPenaltySkill2.Value;
      _item.Price = (uint)nudPrice.Value;
      _item.Skill = cbxSkill.Text.GetEnumByName<Skill>();
      _item.SkillValue = (uint)nudSkill.Value;
      //_item.SpecialItemPurpose = cbxSpecialPurpose.Text.GetEnumByName<SpecialItemPurpose>();
      _item.Spell = cbxSpell.Text.GetEnumByName<Spell>();
      _item.SpellPoints = (uint)nudSpellPoints.Value;
      //_item.TextIndex = (int)nudText.Value == 0 ? null : (uint)nudText.Value;
      //_item.TextSubIndex = (int)nudTextSub.Value == -1 ? null : (uint)nudTextSub.Value;
      //_item.Transportation     = cbxTransportation.Text.GetEnumByName<Transportation>();
      _item.Type = cbxType.Text.GetEnumByName<ItemType>();
      _item.UsedAmmunitionType = cbxUsedAmmunition.Text.GetEnumByName<AmmunitionType>();
      _item.Weight = (uint)nudWeight.Value;

      _item.Classes = ClassFlag.None
        | (chbxClassesAdventurer.Checked ? ClassFlag.Adventurer: ClassFlag.None)
        | (chbxClassesAlchemist.Checked ? ClassFlag.Alchemist : ClassFlag.None)
        | (chbxClassesAll.Checked ? ClassFlag.All : ClassFlag.None)
        | (chbxClassesAllWithUnused.Checked ? ClassFlag.AllWithUnused : ClassFlag.None)
        | (chbxClassesAnimal.Checked ? ClassFlag.Animal : ClassFlag.None)
        | (chbxClassesHealer.Checked ? ClassFlag.Healer : ClassFlag.None)
        | (chbxClassesMage.Checked ? ClassFlag.Mage : ClassFlag.None)
        | (chbxClassesMonster.Checked ? ClassFlag.Monster : ClassFlag.None)
        | (chbxClassesMystic.Checked ? ClassFlag.Mystic : ClassFlag.None)
        | (chbxClassesPaladin.Checked ? ClassFlag.Paladin : ClassFlag.None)
        | (chbxClassesRanger.Checked ? ClassFlag.Ranger : ClassFlag.None)
        | (chbxClassesThief.Checked ? ClassFlag.Thief : ClassFlag.None)
        | (chbxClassesUnused1.Checked ? ClassFlag.Unknown1 : ClassFlag.None)
        | (chbxClassesUnused2.Checked ? ClassFlag.Unknown2 : ClassFlag.None)
        | (chbxClassesUnused3.Checked ? ClassFlag.Unknown3 : ClassFlag.None)
        | (chbxClassesUnused4.Checked ? ClassFlag.Unknown4 : ClassFlag.None)
        | (chbxClassesWarrior.Checked ? ClassFlag.Warrior : ClassFlag.None);

      _item.DefaultSlotFlags = ItemSlotFlags.None
        | (chbxDefaultSlotFlagBroken.Checked ? ItemSlotFlags.Broken : ItemSlotFlags.None)
        | (chbxDefaultSlotFlagCursed.Checked ? ItemSlotFlags.Cursed : ItemSlotFlags.None)
        | (chbxDefaultSlotFlagIdentified.Checked ? ItemSlotFlags.Identified : ItemSlotFlags.None)
        | (chbxDefaultSlotFlagLocked.Checked ? ItemSlotFlags.Locked : ItemSlotFlags.None);

      _item.Flags = ItemFlags.None
        | (chbxItemFlagsAccursed.Checked ? ItemFlags.Accursed : ItemFlags.None)
        | (chbxItemFlagsCloneable.Checked ? ItemFlags.Cloneable : ItemFlags.None)
        | (chbxItemFlagsDestroyAfterUsage.Checked ? ItemFlags.DestroyAfterUsage : ItemFlags.None)
        | (chbxItemFlagsIndestructible.Checked ? ItemFlags.Indestructible : ItemFlags.None)
        | (chbxItemFlagsNotImportant.Checked ? ItemFlags.NotImportant : ItemFlags.None)
        | (chbxItemFlagsRemovableDuringFight.Checked ? ItemFlags.RemovableDuringFight : ItemFlags.None)
        | (chbxItemFlagsStackable.Checked ? ItemFlags.Stackable : ItemFlags.None);
    }
    #endregion
    #region --- map item to controls --------------------------------------------------------------
    private void MapItemToControls() {
      cbxAmmunitionType.SelectedIndex = ((List<string>)cbxAmmunitionType.DataSource!).FindIndex(x => x == _item.AmmunitionType.ToString());
      cbxAttribute.SelectedIndex = ((List<string>)cbxAttribute.DataSource!).FindIndex(x => x == _item.Attribute.ToString());
      cbxEquipmentSlot.SelectedIndex = ((List<string>)cbxEquipmentSlot.DataSource!).FindIndex(x => x == _item.EquipmentSlot.ToString());
      cbxGender.SelectedIndex = ((List<string>)cbxGender.DataSource!).FindIndex(x => x == _item.Gender.ToString());
      cbxPenaltySkill1.SelectedIndex = ((List<string>)cbxPenaltySkill1.DataSource!).FindIndex(x => x == _item.PenaltySkill1.ToString());
      cbxPenaltySkill2.SelectedIndex = ((List<string>)cbxPenaltySkill2.DataSource!).FindIndex(x => x == _item.PenaltySkill2.ToString());
      cbxSkill.SelectedIndex = ((List<string>)cbxSkill.DataSource!).FindIndex(x => x == _item.Skill.ToString());
      cbxSpecialPurpose.SelectedIndex = ((List<string>)cbxSpecialPurpose.DataSource!).FindIndex(x => x == _item.SpecialItemPurpose.ToString());
      cbxSpell.SelectedIndex = ((List<string>)cbxSpell.DataSource!).FindIndex(x => x == _item.Spell.ToString());
      cbxTransportation.SelectedIndex = ((List<string>)cbxTransportation.DataSource!).FindIndex(x => x == _item.Transportation.ToString());
      cbxType.SelectedIndex = ((List<string>)cbxType.DataSource!).FindIndex(x => x == _item.Type.ToString());
      cbxUsedAmmunition.SelectedIndex = ((List<string>)cbxUsedAmmunition.DataSource!).FindIndex(x => x == _item.UsedAmmunitionType.ToString());

      chbxClassesNone.Checked = _item.Classes.HasFlag(ClassFlag.None);
      chbxClassesAdventurer.Checked = _item.Classes.HasFlag(ClassFlag.Adventurer);
      chbxClassesAlchemist.Checked = _item.Classes.HasFlag(ClassFlag.Alchemist);
      chbxClassesAnimal.Checked = _item.Classes.HasFlag(ClassFlag.Animal);
      chbxClassesHealer.Checked = _item.Classes.HasFlag(ClassFlag.Healer);
      chbxClassesMage.Checked = _item.Classes.HasFlag(ClassFlag.Mage);
      chbxClassesMonster.Checked = _item.Classes.HasFlag(ClassFlag.Monster);
      chbxClassesMystic.Checked = _item.Classes.HasFlag(ClassFlag.Mystic);
      chbxClassesPaladin.Checked = _item.Classes.HasFlag(ClassFlag.Paladin);
      chbxClassesRanger.Checked = _item.Classes.HasFlag(ClassFlag.Ranger);
      chbxClassesThief.Checked = _item.Classes.HasFlag(ClassFlag.Thief);
      chbxClassesWarrior.Checked = _item.Classes.HasFlag(ClassFlag.Warrior);
      chbxClassesAll.Checked = _item.Classes.HasFlag(ClassFlag.All);
      chbxClassesUnused1.Checked = _item.Classes.HasFlag(ClassFlag.Unknown1);
      chbxClassesUnused2.Checked = _item.Classes.HasFlag(ClassFlag.Unknown2);
      chbxClassesUnused3.Checked = _item.Classes.HasFlag(ClassFlag.Unknown3);
      chbxClassesUnused4.Checked = _item.Classes.HasFlag(ClassFlag.Unknown4);
      chbxClassesAllWithUnused.Checked = _item.Classes.HasFlag(ClassFlag.AllWithUnused);

      chbxDefaultSlotFlagNone.Checked = _item.DefaultSlotFlags.HasFlag(ItemSlotFlags.None);
      chbxDefaultSlotFlagBroken.Checked = _item.DefaultSlotFlags.HasFlag(ItemSlotFlags.Broken);
      chbxDefaultSlotFlagCursed.Checked = _item.DefaultSlotFlags.HasFlag(ItemSlotFlags.Cursed);
      chbxDefaultSlotFlagIdentified.Checked = _item.DefaultSlotFlags.HasFlag(ItemSlotFlags.Identified);
      chbxDefaultSlotFlagLocked.Checked = _item.DefaultSlotFlags.HasFlag(ItemSlotFlags.Locked);

      chbxItemFlagsNone.Checked = _item.Flags.HasFlag(ItemFlags.None);
      chbxItemFlagsAccursed.Checked = _item.Flags.HasFlag(ItemFlags.Accursed);
      chbxItemFlagsCloneable.Checked = _item.Flags.HasFlag(ItemFlags.Cloneable);
      chbxItemFlagsDestroyAfterUsage.Checked = _item.Flags.HasFlag(ItemFlags.DestroyAfterUsage);
      chbxItemFlagsIndestructible.Checked = _item.Flags.HasFlag(ItemFlags.Indestructible);
      chbxItemFlagsNotImportant.Checked = _item.Flags.HasFlag(ItemFlags.NotImportant);
      chbxItemFlagsRemovableDuringFight.Checked = _item.Flags.HasFlag(ItemFlags.RemovableDuringFight);
      chbxItemFlagsStackable.Checked = _item.Flags.HasFlag(ItemFlags.Stackable);

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
      nudTextSub.Value = _item.TextSubIndex.HasValue ? (decimal)_item.TextSubIndex : -1;
      nudWeight.Value = _item.Weight;

      tbxIndex.Text = _item.Index.ToString();
      tbxName.Text = _item.Name;
    }
    #endregion
  }
}