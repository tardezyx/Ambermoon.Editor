using Ambermoon.Data;
using Ambermoon.Data.GameDataRepository;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Data.GameDataRepository.Enumerations;
using Ambermoon.Data.GameDataRepository.Windows;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Models;
using Spell = Ambermoon.Editor.Models.Spell;
using Timer = System.Windows.Forms.Timer;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditMonsterForm : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private readonly List<Bitmap>                   _animationFrames = [];
    private          Timer                          _animationTimer = new();
    private readonly SortableBindingList<CharValue> _attributes = [];
    private          int                            _currentAnimationFrame = 0;
    private readonly MonsterData                    _monster;
    private readonly SortableBindingList<CharValue> _skills = [];
    private readonly SortableBindingList<Spell>     _spells = [];
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditMonsterForm(MonsterData monster) {
      InitializeComponent();

      _monster = monster;

      cbxClass.DataSource                    = _monster.Class.GetValuesAsOrderedStringList();
      cbxCombatBackgroundDaytime.DataSource  = CombatBackgroundDaytime.Day.GetValuesAsOrderedStringList();
      cbxElement.DataSource                  = _monster.Element.GetValuesAsOrderedStringList();
      cbxGender.DataSource                   = _monster.Gender.GetValuesAsOrderedStringList();
      cbxRace.DataSource                     = _monster.Race.GetValuesAsOrderedStringList();
      cbxType.DataSource                     = _monster.Type.GetValuesAsOrderedStringList();
      nudCombatGraphicIndex.Maximum          = Repository.Current.GameData!.MonsterImages.Count;
      nudPaletteIndex.Maximum                = Repository.Current.GameData!.Palettes.Count;
      pbxCombatGraphic.BackColor             = Color.Black;
      pbxCombatGraphic.BackgroundImageLayout = ImageLayout.Zoom;
      pbxCombatGraphic.SizeMode              = PictureBoxSizeMode.CenterImage;
    }
    #endregion
    #region --- init dgv: attributes --------------------------------------------------------------
    private void InitDGVAttributes() {
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

      dgvAttributes.AutoGenerateColumns = false;
      dgvAttributes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

      dgvAttributes.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Name),                   ReadOnly = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Short),                  ReadOnly = true },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Current), MaxValue = 99 },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Bonus),   MaxValue = 99, ReadOnly = true },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Max),     MaxValue = 99 },
      });

      foreach (DataGridViewColumn column in dgvAttributes.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
        column.SortMode = DataGridViewColumnSortMode.NotSortable;
      }

      dgvAttributes.DataSource = _attributes;
      dgvAttributes.AutoResizeColumns();

      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
    }
    #endregion
    #region --- init dgv: equipment ---------------------------------------------------------------
    private void InitDGVEquipment() {
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

      dgvEquipment.AutoGenerateColumns = false;

      //dgvEquipment.Columns.AddRange(new DataGridViewColumn[] {
        //new DataGridViewTextBoxColumn() { DataPropertyName = nameof(SkillValue.Name), ReadOnly = true },
      //});

      foreach (DataGridViewColumn column in dgvEquipment.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
        column.SortMode = DataGridViewColumnSortMode.NotSortable;
      }

      //dgvEquipment.DataSource = _equipment;
      dgvEquipment.AutoResizeColumns();

      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
    }
    #endregion
    #region --- init dgv: items -------------------------------------------------------------------
    private void InitDGVItems() {
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

      dgvItems.AutoGenerateColumns = false;

      //dgvItems.Columns.AddRange(new DataGridViewColumn[] {
        //new DataGridViewTextBoxColumn() { DataPropertyName = nameof(SkillValue.Name), ReadOnly = true },
      //});

      foreach (DataGridViewColumn column in dgvItems.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
        column.SortMode = DataGridViewColumnSortMode.NotSortable;
      }

      //dgvItems.DataSource = _skills;
      dgvItems.AutoResizeColumns();

      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
    }
    #endregion
    #region --- init dgv: skills ------------------------------------------------------------------
    private void InitDGVSkills() {
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

      dgvSkills.AutoGenerateColumns = false;
      dgvSkills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

      dgvSkills.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Name),                   ReadOnly = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(CharValue.Short),                  ReadOnly = true },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Current), MaxValue = 99 },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Bonus),   MaxValue = 99, ReadOnly = true },
        new NumericUpDownColumn()       { DataPropertyName = nameof(CharValue.Max),     MaxValue = 99 },
      });

      foreach (DataGridViewColumn column in dgvSkills.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
        column.SortMode = DataGridViewColumnSortMode.NotSortable;
      }

      dgvSkills.DataSource = _skills;
      dgvSkills.AutoResizeColumns();

      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
    }
    #endregion
    #region --- init dgv: spells ------------------------------------------------------------------
    private void InitDGVSpells() {
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

      dgvSpells.AutoGenerateColumns = false;
      dgvSpells.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

      dgvSpells.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewButtonColumn () { DataPropertyName = "Remove", Text = "X", UseColumnTextForButtonValue = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(Spell.School), ReadOnly = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(Spell.Index),  ReadOnly = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(Spell.Name),   ReadOnly = true },
      });

      foreach (DataGridViewColumn column in dgvSpells.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      dgvSpells.DataSource = _spells;
      dgvSpells.AutoResizeColumns();

      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();
      WireEvents();

      MapMonsterToControls();
      GetCombatGraphics();
      InitDGVAttributes();
      InitDGVEquipment();
      InitDGVItems();
      InitDGVSkills();
      InitDGVSpells();
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
      btnAddSpell.Click += (s, e) => AddSpell();
      btnCancel.Click += (s, e) => Close();
      btnOK.Click += (s, e) => { MapControlsToMonster(); DialogResult = DialogResult.OK; Close(); };

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

      dgvSpells.CellClick += (s, e) => { 
        if(e.RowIndex > -1 && dgvSpells.Columns[e.ColumnIndex] is DataGridViewButtonColumn) {
          RemoveSpell((Spell)dgvSpells.Rows[e.RowIndex].DataBoundItem);
        }
      };

      cbxCombatBackgroundDaytime.SelectedValueChanged += (s, e) => GetCombatGraphics();
      chbxZoom.CheckStateChanged += (s, e) => { pbxCombatGraphic.SizeMode = chbxZoom.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.CenterImage; };
      nudCombatBackgroundIndex.ValueChanged += (s, e) => GetCombatGraphics();
      nudCombatGraphicIndex.ValueChanged += (s, e) => GetCombatGraphics();
    }
    #endregion

    #region --- add spell -------------------------------------------------------------------------
    private void AddSpell() {
      Spell newSpell = new() { 
        Index  = 1,
        School = Repository.Current.GetSpellSchoolName(SpellSchool.Destruction),
        Name   = Repository.Current.GetSpellName(SpellSchool.Destruction, 1)
      };

      EditSpellForm form = new(newSpell);

      if (form.ShowDialog() == DialogResult.OK) {
        bool spellAlreadyInList = false;
        foreach (DataGridViewRow row in dgvSpells.Rows) {
          Spell dgvSpell = (Spell)row.DataBoundItem;

          if (dgvSpell.School == newSpell.School && dgvSpell.Index == newSpell.Index) {
            spellAlreadyInList = true;
          }
        }

        if (!spellAlreadyInList) {
          _spells.Add(newSpell);
          dgvSpells.AutoResizeColumns();
        }

        foreach (DataGridViewRow row in dgvSpells.Rows) {
          Spell dgvSpell = (Spell)row.DataBoundItem;

          if (dgvSpell.School == newSpell.School && dgvSpell.Index == newSpell.Index) {
            dgvSpells.ClearSelection();
            dgvSpells.FirstDisplayedScrollingRowIndex = row.Index;
            row.Selected = true;

            break;
          }
        }
      }
    }
    #endregion
    #region --- get combat graphics ---------------------------------------------------------------
    private void GetCombatGraphics() {
      _animationTimer.Stop();
      _animationFrames.Clear();

      if (Repository.Current.GameData is null) { 
        return;
      }
      
      CombatBackgroundImage backgroundImage = Repository.Current.GameData
        .CombatBackgroundImages3D[(uint)nudCombatBackgroundIndex.Value];

      Data.GameDataRepository.Image monsterImage = Repository.Current.GameData
        .MonsterImages[(uint)nudCombatGraphicIndex.Value];

      uint? paletteIndex = backgroundImage
        .GetPaletteIndex(cbxCombatBackgroundDaytime.Text.GetEnumByName<CombatBackgroundDaytime>());

      if (!paletteIndex.HasValue) {
        return;
      }

      Palette palette = Repository.Current.GameData.Palettes[(uint)paletteIndex];
      nudPaletteIndex.Value = palette.Index;

      Bitmap combatBackgroundBitmap = WindowsExtensions.ToBitmap(backgroundImage.Frames[0], palette, true);
      pbxCombatGraphic.BackgroundImage = combatBackgroundBitmap;

      foreach (ImageData frame in monsterImage.Frames) {
        Bitmap combatGraphicBitmap = WindowsExtensions.ToBitmap(frame, palette, true);
        _animationFrames.Add(combatGraphicBitmap);
      }

      // animation timer
      if (_animationFrames.Count > 0) {
        _animationTimer.Interval = 125;

        _animationTimer.Tick += (s, e) => {
          if (_currentAnimationFrame > _animationFrames.Count - 1) {
            _currentAnimationFrame = 0;
          }

          pbxCombatGraphic.Image = _animationFrames[_currentAnimationFrame];

          _currentAnimationFrame++;
        };
     
        _animationTimer.Start();
      }
    }
    #endregion
    #region --- map controls to monster -----------------------------------------------------------
    private void MapControlsToMonster() {
      _monster.Name = tbxName.Text;
      
      _monster.Class   = cbxClass.Text.GetEnumByName<Class>();
      _monster.Element = cbxElement.Text.GetEnumByName<CharacterElement>();
      _monster.Gender  = cbxGender.Text.GetEnumByName<Gender>();
      _monster.Race    = cbxRace.Text.GetEnumByName<Race>();
      //_monster.Type    = cbxType.Text.GetEnumByName<CharacterType>();

      _monster.BattleFlags = BattleFlags.None
        | (chbxBattleFlagsAnimal.Checked ? BattleFlags.Animal : BattleFlags.None)
        | (chbxBattleFlagsBonusEarth.Checked ? BattleFlags.EarthSpellDamageBonus : BattleFlags.None)
        | (chbxBattleFlagsBonusFire.Checked ? BattleFlags.FireSpellDamageBonus : BattleFlags.None)
        | (chbxBattleFlagsBonusWind.Checked ? BattleFlags.WindSpellDamageBonus : BattleFlags.None)
        | (chbxBattleFlagsBoss.Checked ? BattleFlags.Boss : BattleFlags.None)
        | (chbxBattleFlagsDemon.Checked ? BattleFlags.Demon : BattleFlags.None)
        | (chbxBattleFlagsUndead.Checked ? BattleFlags.Undead : BattleFlags.None);

      _monster.Conditions = Condition.None
        | (chbxConditionsAging.Checked ? Condition.Aging : Condition.None)
        | (chbxConditionsBlind.Checked ? Condition.Blind : Condition.None)
        | (chbxConditionsCrazy.Checked ? Condition.Crazy : Condition.None)
        | (chbxConditionsDeadAshes.Checked ? Condition.DeadAshes : Condition.None)
        | (chbxConditionsDeadCorpse.Checked ? Condition.DeadCorpse : Condition.None)
        | (chbxConditionsDeadDust.Checked ? Condition.DeadDust : Condition.None)
        | (chbxConditionsDiseased.Checked ? Condition.Diseased : Condition.None)
        | (chbxConditionsDrugged.Checked ? Condition.Drugged : Condition.None)
        | (chbxConditionsExhausted.Checked ? Condition.Exhausted : Condition.None)
        | (chbxConditionsIrritated.Checked ? Condition.Irritated : Condition.None)
        | (chbxConditionsLamed.Checked ? Condition.Lamed : Condition.None)
        | (chbxConditionsPanic.Checked ? Condition.Panic : Condition.None)
        | (chbxConditionsPetrified.Checked ? Condition.Petrified : Condition.None)
        | (chbxConditionsPoisoned.Checked ? Condition.Poisoned : Condition.None)
        | (chbxConditionsSleep.Checked ? Condition.Sleep : Condition.None)
        | (chbxConditionsUnused.Checked ? Condition.Unused : Condition.None);

      _monster.SpellTypeImmunity = SpellTypeImmunity.None
        | (chbxSpellImmunityAlchemistic.Checked ? SpellTypeImmunity.Alchemistic : SpellTypeImmunity.None)
        | (chbxSpellImmunityDestruction.Checked ? SpellTypeImmunity.Destruction : SpellTypeImmunity.None)
        | (chbxSpellImmunityFunction.Checked ? SpellTypeImmunity.Function : SpellTypeImmunity.None)
        | (chbxSpellImmunityHealing.Checked ? SpellTypeImmunity.Healing : SpellTypeImmunity.None)
        | (chbxSpellImmunityMystic.Checked ? SpellTypeImmunity.Mystic : SpellTypeImmunity.None)
        | (chbxSpellImmunityUnused.Checked ? SpellTypeImmunity.Unused : SpellTypeImmunity.None)
        | (chbxSpellImmunityUnused1.Checked ? SpellTypeImmunity.Unused1 : SpellTypeImmunity.None)
        | (chbxSpellImmunityUnused2.Checked ? SpellTypeImmunity.Unused2 : SpellTypeImmunity.None);

      _monster.SpellMastery = SpellTypeMastery.None
        | (chbxSpellMasteryAlchemistic.Checked ? SpellTypeMastery.Alchemistic : SpellTypeMastery.None)
        | (chbxSpellMasteryAll.Checked ? SpellTypeMastery.All : SpellTypeMastery.None)
        | (chbxSpellMasteryDestruction.Checked ? SpellTypeMastery.Destruction : SpellTypeMastery.None)
        | (chbxSpellMasteryFunction.Checked ? SpellTypeMastery.Function : SpellTypeMastery.None)
        | (chbxSpellMasteryHealing.Checked ? SpellTypeMastery.Healing : SpellTypeMastery.None)
        | (chbxSpellMasteryMastered.Checked ? SpellTypeMastery.Mastered : SpellTypeMastery.None)
        | (chbxSpellMasteryMystic.Checked ? SpellTypeMastery.Mystic : SpellTypeMastery.None)
        | (chbxSpellMasteryUnused1.Checked ? SpellTypeMastery.Unused1 : SpellTypeMastery.None)
        | (chbxSpellMasteryUnused2.Checked ? SpellTypeMastery.Unused2 : SpellTypeMastery.None);

      _monster.BaseAttackDamage = (uint)nudAttackBase.Value;
      //_monster.BonusAttackDamage = nudAttackBonus.Value;

      _monster.MagicAttackLevel = (int)nudAttackMagicLevel.Value;
      _monster.AttacksPerRound = (uint)nudAttacksPerRound.Value;
      _monster.BonusSpellDamage = (uint)nudBonusSpellDamageBase.Value;
      _monster.BonusMaxSpellDamage = (uint)nudBonusSpellDamageMax.Value;
      _monster.BonusSpellDamagePercentage = (int)nudBonusSpellDamagePercentage.Value;
      _monster.BonusSpellDamageReduction = (int)nudBonusSpellDamageReduction.Value;
      _monster.DefeatExperience = (uint)nudDefeatExperience.Value;
      _monster.BaseDefense = (uint)nudDefenseBase.Value;
      //_monster.BonusDefense = nudDefenseBonus.Value;
      //_monster.CombatGraphicIndex = (uint)nudCombatGraphicIndex.Value;
      _monster.MagicDefenseLevel = (int)nudDefenseMagicLevel.Value;
      _monster.Food = (uint)nudFood.Value;
      _monster.Gold = (uint)nudGold.Value;
      _monster.HitPoints.BonusValue = (int)nudHitPointsBonus.Value;
      _monster.HitPoints.CurrentValue = (uint)nudHitPointsCurrent.Value;
      _monster.HitPoints.MaxValue = (uint)nudHitPointsMax.Value;
      _monster.Level = (uint)nudLevel.Value;
      _monster.Morale = (uint)nudMorale.Value;
      _monster.SpellPoints.BonusValue = (int)nudSpellPointsBonus.Value;
      _monster.SpellPoints.CurrentValue = (uint)nudSpellPointsCurrent.Value;
      _monster.SpellPoints.MaxValue = (uint)nudSpellPointsMax.Value;

      tbxIndex.Text = _monster.Index.ToString();
      tbxName.Text = _monster.Name;

      foreach (CharValue attribute in _attributes) {
        if (Repository.Current.GetAttributeIndex(attribute.Name) is int index) {
          _monster.Attributes[index].BonusValue = attribute.Bonus;
          _monster.Attributes[index].CurrentValue = attribute.Current;
          _monster.Attributes[index].MaxValue = attribute.Max;
          _monster.Attributes[index].StoredValue = attribute.Stored;
          //_monster.Attributes[index].TotalCurrentValue = attribute.TotalCurrent;
          //_monster.Attributes[index].TotalMaxValue = attribute.TotalMax;
        }
      }

      foreach (CharValue skill in _skills) {
        if (Repository.Current.GetSkillIndex(skill.Name) is int index) {
          _monster.Skills[index].BonusValue = skill.Bonus;
          _monster.Skills[index].CurrentValue = skill.Current;
          _monster.Skills[index].MaxValue = skill.Max;
          _monster.Skills[index].StoredValue = skill.Stored;
          //_monster.Skills[index].TotalCurrentValue = attribute.TotalCurrent;
          //_monster.Skills[index].TotalMaxValue = attribute.TotalMax;
        }
      }

      _monster.LearnedSpellsAlchemistic = 0;
      _monster.LearnedSpellsDestruction = 0;
      _monster.LearnedSpellsFunctional = 0;
      _monster.LearnedSpellsHealing = 0;
      _monster.LearnedSpellsMystic = 0;
      _monster.LearnedSpellsType5 = 0;
      _monster.LearnedSpellsType6 = 0;

      foreach (Spell spell in _spells) {
        uint spellValue = (uint)Math.Pow(2, spell.Index + 1);

        switch (Repository.Current.GameData!.SpellClassNames.IndexOf(spell.School)) {
          case 0: _monster.LearnedSpellsHealing += spellValue; break;
          case 1: _monster.LearnedSpellsAlchemistic += spellValue; break;
          case 2: _monster.LearnedSpellsMystic += spellValue; break;
          case 3: _monster.LearnedSpellsDestruction += spellValue; break;
          case 4: _monster.LearnedSpellsType5 += spellValue; break;
          case 5: _monster.LearnedSpellsType6 += spellValue; break;
          case 6: _monster.LearnedSpellsFunctional += spellValue; break;
        };
      }
    }
    #endregion
    #region --- map monster to controls -----------------------------------------------------------
    private void MapMonsterToControls() {
      cbxClass.SelectedIndex = ((List<string>)cbxClass.DataSource!).FindIndex(x => x == _monster.Class.ToString());
      cbxElement.SelectedIndex = ((List<string>)cbxElement.DataSource!).FindIndex(x => x == _monster.Element.ToString());
      cbxGender.SelectedIndex = ((List<string>)cbxGender.DataSource!).FindIndex(x => x == _monster.Gender.ToString());
      cbxRace.SelectedIndex = ((List<string>)cbxRace.DataSource!).FindIndex(x => x == _monster.Race.ToString());
      cbxType.SelectedIndex = ((List<string>)cbxType.DataSource!).FindIndex(x => x == _monster.Type.ToString());

      chbxBattleFlagsAnimal.Checked = _monster.BattleFlags.HasFlag(BattleFlags.Animal);
      chbxBattleFlagsBonusEarth.Checked = _monster.BattleFlags.HasFlag(BattleFlags.EarthSpellDamageBonus);
      chbxBattleFlagsBonusFire.Checked = _monster.BattleFlags.HasFlag(BattleFlags.FireSpellDamageBonus);
      chbxBattleFlagsBonusWind.Checked = _monster.BattleFlags.HasFlag(BattleFlags.WindSpellDamageBonus);
      chbxBattleFlagsBoss.Checked = _monster.BattleFlags.HasFlag(BattleFlags.Boss);
      chbxBattleFlagsDemon.Checked = _monster.BattleFlags.HasFlag(BattleFlags.Demon);
      chbxBattleFlagsNone.Checked = _monster.BattleFlags == BattleFlags.None;
      chbxBattleFlagsUndead.Checked = _monster.BattleFlags.HasFlag(BattleFlags.Undead);

      chbxConditionsAging.Checked = _monster.Conditions.HasFlag(Condition.Aging);
      chbxConditionsBlind.Checked = _monster.Conditions.HasFlag(Condition.Blind);
      chbxConditionsCrazy.Checked = _monster.Conditions.HasFlag(Condition.Crazy);
      chbxConditionsDeadAshes.Checked = _monster.Conditions.HasFlag(Condition.DeadAshes);
      chbxConditionsDeadCorpse.Checked = _monster.Conditions.HasFlag(Condition.DeadCorpse);
      chbxConditionsDeadDust.Checked = _monster.Conditions.HasFlag(Condition.DeadDust);
      chbxConditionsDiseased.Checked = _monster.Conditions.HasFlag(Condition.Diseased);
      chbxConditionsDrugged.Checked = _monster.Conditions.HasFlag(Condition.Drugged);
      chbxConditionsExhausted.Checked = _monster.Conditions.HasFlag(Condition.Exhausted);
      chbxConditionsIrritated.Checked = _monster.Conditions.HasFlag(Condition.Irritated);
      chbxConditionsLamed.Checked = _monster.Conditions.HasFlag(Condition.Lamed);
      chbxConditionsNone.Checked = _monster.Conditions == Condition.None;
      chbxConditionsPanic.Checked = _monster.Conditions.HasFlag(Condition.Panic);
      chbxConditionsPetrified.Checked = _monster.Conditions.HasFlag(Condition.Petrified);
      chbxConditionsPoisoned.Checked = _monster.Conditions.HasFlag(Condition.Poisoned);
      chbxConditionsSleep.Checked = _monster.Conditions.HasFlag(Condition.Sleep);
      chbxConditionsUnused.Checked = _monster.Conditions.HasFlag(Condition.Unused);

      chbxSpellImmunityAlchemistic.Checked = _monster.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Alchemistic);
      chbxSpellImmunityDestruction.Checked = _monster.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Destruction);
      chbxSpellImmunityFunction.Checked = _monster.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Function);
      chbxSpellImmunityHealing.Checked = _monster.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Healing);
      chbxSpellImmunityMystic.Checked = _monster.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Mystic);
      chbxSpellImmunityNone.Checked = _monster.SpellTypeImmunity == SpellTypeImmunity.None;
      chbxSpellImmunityUnused.Checked = _monster.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Unused);
      chbxSpellImmunityUnused1.Checked = _monster.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Unused1);
      chbxSpellImmunityUnused2.Checked = _monster.SpellTypeImmunity.HasFlag(SpellTypeImmunity.Unused2);

      chbxSpellMasteryAlchemistic.Checked = _monster.SpellMastery.HasFlag(SpellTypeMastery.Alchemistic);
      chbxSpellMasteryAll.Checked = _monster.SpellMastery.HasFlag(SpellTypeMastery.All);
      chbxSpellMasteryDestruction.Checked = _monster.SpellMastery.HasFlag(SpellTypeMastery.Destruction);
      chbxSpellMasteryFunction.Checked = _monster.SpellMastery.HasFlag(SpellTypeMastery.Function);
      chbxSpellMasteryHealing.Checked = _monster.SpellMastery.HasFlag(SpellTypeMastery.Healing);
      chbxSpellMasteryMastered.Checked = _monster.SpellMastery.HasFlag(SpellTypeMastery.Mastered);
      chbxSpellMasteryMystic.Checked = _monster.SpellMastery.HasFlag(SpellTypeMastery.Mystic);
      chbxSpellMasteryNone.Checked = _monster.SpellMastery == SpellTypeMastery.None;
      chbxSpellMasteryUnused1.Checked = _monster.SpellMastery.HasFlag(SpellTypeMastery.Unused1);
      chbxSpellMasteryUnused2.Checked = _monster.SpellMastery.HasFlag(SpellTypeMastery.Unused2);

      nudAttackBase.Value = _monster.BaseAttackDamage;
      nudAttackBonus.Value = _monster.BonusAttackDamage;
      nudAttackMagicLevel.Value = _monster.MagicAttackLevel;
      nudAttacksPerRound.Value = _monster.AttacksPerRound;
      nudBonusSpellDamageBase.Value = _monster.BonusSpellDamage;
      nudBonusSpellDamageMax.Value = _monster.BonusMaxSpellDamage;
      nudBonusSpellDamagePercentage.Value = _monster.BonusSpellDamagePercentage;
      nudBonusSpellDamageReduction.Value = _monster.BonusSpellDamageReduction;
      nudCombatGraphicIndex.Value = _monster.CombatGraphicIndex;
      nudDefeatExperience.Value = _monster.DefeatExperience;
      nudDefenseBase.Value = _monster.BaseDefense;
      nudDefenseBonus.Value = _monster.BonusDefense;
      nudDefenseMagicLevel.Value = _monster.MagicDefenseLevel;
      nudFood.Value = _monster.Food;
      nudGold.Value = _monster.Gold;
      nudHitPointsBonus.Value = _monster.HitPoints.BonusValue;
      nudHitPointsCurrent.Value = _monster.HitPoints.CurrentValue;
      nudHitPointsMax.Value = _monster.HitPoints.MaxValue;
      nudLevel.Value = _monster.Level;
      nudMorale.Value = _monster.Morale;
      nudSpellPointsBonus.Value = _monster.SpellPoints.BonusValue;
      nudSpellPointsCurrent.Value = _monster.SpellPoints.CurrentValue;
      nudSpellPointsMax.Value = _monster.SpellPoints.MaxValue;

      tbxIndex.Text = _monster.Index.ToString();
      tbxName.Text = _monster.Name;

      int index = 0;
      foreach (CharacterValue characterValue in _monster.Attributes) {
        _attributes.Add(
          new() {
            Bonus = characterValue.BonusValue,
            Current = characterValue.CurrentValue,
            Max = characterValue.MaxValue,
            Name = Repository.Current.GetAttributeName(index),
            Short = Repository.Current.GetAttributeShortName(index),
            Stored = characterValue.StoredValue
          }
        );

        index++;
      }

      index = 0;
      foreach (CharacterValue characterValue in _monster.Skills) {
        _skills.Add(
          new() {
            Bonus = characterValue.BonusValue,
            Current = characterValue.CurrentValue,
            Max = characterValue.MaxValue,
            Name = Repository.Current.GetSkillName(index),
            Short = Repository.Current.GetSkillShortName(index),
            Stored = characterValue.StoredValue
          }
        );

        index++;
      }

      foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Alchemistic, _monster.LearnedSpellsAlchemistic)) { _spells.Add(spell); }
      foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Destruction, _monster.LearnedSpellsDestruction)) { _spells.Add(spell); }
      foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Function, _monster.LearnedSpellsFunctional)) { _spells.Add(spell); }
      foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Healing, _monster.LearnedSpellsHealing)) { _spells.Add(spell); }
      foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Mystic, _monster.LearnedSpellsMystic)) { _spells.Add(spell); }
      foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Unknown1, _monster.LearnedSpellsType5)) { _spells.Add(spell); }
      foreach (Spell spell in Repository.Current.GetSpellsByUint(SpellSchool.Unknown2, _monster.LearnedSpellsType5)) { _spells.Add(spell); }
    }
    #endregion
    #region --- remove spell ----------------------------------------------------------------------
    private void RemoveSpell(Spell spell) {
      string n = Environment.NewLine;

      if (
        MsgBox.Show(
          $"Remove {spell.School} {spell.Index}: {spell.Name}?",
          $"Do you really want to remove the following spell?{n}{n}"
          + $"School: {spell.School}{n}Index: {spell.Index}{n}Name: {spell.Name}",
          MessageBoxButtons.YesNo
        ) == DialogResult.Yes
      ) {
        _spells.Remove(spell);
        dgvSpells.AutoResizeColumns();
      }
    }
    #endregion
  }
}