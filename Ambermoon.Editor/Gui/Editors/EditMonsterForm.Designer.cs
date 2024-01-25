using Ambermoon.Editor.Gui.Custom;

namespace Ambermoon.Editor.Gui.Editors {
  partial class EditMonsterForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
      tbxName = new TextBox();
      btnOK = new Button();
      btnCancel = new Button();
      tbxIndex = new TextBox();
      lblIndex = new Label();
      lblName = new Label();
      statusStrip = new StatusStrip();
      grbxAttributes = new GroupBox();
      dgvAttributes = new CustomDataGridView();
      grbxSkills = new GroupBox();
      dgvSkills = new CustomDataGridView();
      grbxGeneral = new GroupBox();
      label11 = new Label();
      label10 = new Label();
      cbxElement = new ComboBox();
      label7 = new Label();
      label6 = new Label();
      label5 = new Label();
      label29 = new Label();
      cbxGender = new ComboBox();
      nudDefeatExperience = new NumericUpDown();
      label3 = new Label();
      label2 = new Label();
      label1 = new Label();
      nudFood = new NumericUpDown();
      nudGold = new NumericUpDown();
      nudLevel = new NumericUpDown();
      cbxClass = new ComboBox();
      cbxRace = new ComboBox();
      cbxType = new ComboBox();
      label4 = new Label();
      nudMorale = new NumericUpDown();
      grbxBattleFlags = new GroupBox();
      chbxBattleFlagsUndead = new CheckBox();
      chbxBattleFlagsBonusFire = new CheckBox();
      chbxBattleFlagsBonusWind = new CheckBox();
      chbxBattleFlagsBonusEarth = new CheckBox();
      chbxBattleFlagsAnimal = new CheckBox();
      chbxBattleFlagsBoss = new CheckBox();
      chbxBattleFlagsDemon = new CheckBox();
      chbxBattleFlagsNone = new CheckBox();
      label15 = new Label();
      grbxHitPoints = new GroupBox();
      nudHitPointsBonus = new NumericUpDown();
      nudHitPointsCurrent = new NumericUpDown();
      nudHitPointsMax = new NumericUpDown();
      label16 = new Label();
      label18 = new Label();
      grbxAttack = new GroupBox();
      nudAttackBonus = new NumericUpDown();
      nudAttacksPerRound = new NumericUpDown();
      nudAttackMagicLevel = new NumericUpDown();
      label24 = new Label();
      label23 = new Label();
      nudAttackBase = new NumericUpDown();
      label25 = new Label();
      label26 = new Label();
      grbxSpellPoints = new GroupBox();
      nudSpellPointsCurrent = new NumericUpDown();
      nudSpellPointsBonus = new NumericUpDown();
      nudSpellPointsMax = new NumericUpDown();
      label17 = new Label();
      label19 = new Label();
      label20 = new Label();
      grbxDefense = new GroupBox();
      nudDefenseBonus = new NumericUpDown();
      nudDefenseMagicLevel = new NumericUpDown();
      label31 = new Label();
      nudDefenseBase = new NumericUpDown();
      label32 = new Label();
      label33 = new Label();
      grbxSpellMastery = new GroupBox();
      chbxSpellMasteryMastered = new CheckBox();
      chbxSpellMasteryFunction = new CheckBox();
      chbxSpellMasteryMystic = new CheckBox();
      chbxSpellMasteryUnused1 = new CheckBox();
      chbxSpellMasteryUnused2 = new CheckBox();
      chbxSpellMasteryDestruction = new CheckBox();
      chbxSpellMasteryHealing = new CheckBox();
      chbxSpellMasteryAll = new CheckBox();
      chbxSpellMasteryAlchemistic = new CheckBox();
      chbxSpellMasteryNone = new CheckBox();
      grbxSpellImmunity = new GroupBox();
      chbxSpellImmunityUnused = new CheckBox();
      chbxSpellImmunityFunction = new CheckBox();
      chbxSpellImmunityMystic = new CheckBox();
      chbxSpellImmunityUnused1 = new CheckBox();
      chbxSpellImmunityUnused2 = new CheckBox();
      chbxSpellImmunityDestruction = new CheckBox();
      chbxSpellImmunityHealing = new CheckBox();
      chbxSpellImmunityAlchemistic = new CheckBox();
      chbxSpellImmunityNone = new CheckBox();
      grbxConditions = new GroupBox();
      chbxConditionsDeadDust = new CheckBox();
      chbxConditionsDeadAshes = new CheckBox();
      chbxConditionsDrugged = new CheckBox();
      chbxConditionsSleep = new CheckBox();
      chbxConditionsDeadCorpse = new CheckBox();
      chbxConditionsDiseased = new CheckBox();
      chbxConditionsBlind = new CheckBox();
      chbxConditionsLamed = new CheckBox();
      chbxConditionsExhausted = new CheckBox();
      chbxConditionsPanic = new CheckBox();
      chbxConditionsPetrified = new CheckBox();
      chbxConditionsAging = new CheckBox();
      chbxConditionsPoisoned = new CheckBox();
      chbxConditionsUnused = new CheckBox();
      chbxConditionsCrazy = new CheckBox();
      chbxConditionsNone = new CheckBox();
      chbxConditionsIrritated = new CheckBox();
      grbxEquipment = new GroupBox();
      dgvEquipment = new CustomDataGridView();
      grbxItems = new GroupBox();
      dgvItems = new CustomDataGridView();
      grbxBonusSpellDamage = new GroupBox();
      nudBonusSpellDamageReduction = new NumericUpDown();
      nudBonusSpellDamagePercentage = new NumericUpDown();
      nudBonusSpellDamageBase = new NumericUpDown();
      nudBonusSpellDamageMax = new NumericUpDown();
      label12 = new Label();
      label13 = new Label();
      label37 = new Label();
      label14 = new Label();
      grbxAttributes.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvAttributes).BeginInit();
      grbxSkills.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvSkills).BeginInit();
      grbxGeneral.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nudDefeatExperience).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudFood).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudGold).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudLevel).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudMorale).BeginInit();
      grbxBattleFlags.SuspendLayout();
      grbxHitPoints.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nudHitPointsBonus).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudHitPointsCurrent).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudHitPointsMax).BeginInit();
      grbxAttack.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nudAttackBonus).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudAttacksPerRound).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudAttackMagicLevel).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudAttackBase).BeginInit();
      grbxSpellPoints.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nudSpellPointsCurrent).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudSpellPointsBonus).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudSpellPointsMax).BeginInit();
      grbxDefense.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nudDefenseBonus).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudDefenseMagicLevel).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudDefenseBase).BeginInit();
      grbxSpellMastery.SuspendLayout();
      grbxSpellImmunity.SuspendLayout();
      grbxConditions.SuspendLayout();
      grbxEquipment.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvEquipment).BeginInit();
      grbxItems.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
      grbxBonusSpellDamage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageReduction).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamagePercentage).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageBase).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageMax).BeginInit();
      SuspendLayout();
      // 
      // tbxName
      // 
      tbxName.CharacterCasing = CharacterCasing.Upper;
      tbxName.Font = new Font("Segoe UI", 9F);
      tbxName.Location = new Point(60, 17);
      tbxName.Name = "tbxName";
      tbxName.Size = new System.Drawing.Size(116, 23);
      tbxName.TabIndex = 0;
      // 
      // btnOK
      // 
      btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnOK.Location = new Point(1246, 677);
      btnOK.Name = "btnOK";
      btnOK.Size = new System.Drawing.Size(75, 23);
      btnOK.TabIndex = 1;
      btnOK.Text = "OK";
      btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnCancel.Location = new Point(1327, 677);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 2;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // tbxIndex
      // 
      tbxIndex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      tbxIndex.Location = new Point(57, 678);
      tbxIndex.Name = "tbxIndex";
      tbxIndex.ReadOnly = true;
      tbxIndex.Size = new System.Drawing.Size(45, 23);
      tbxIndex.TabIndex = 3;
      // 
      // lblIndex
      // 
      lblIndex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lblIndex.AutoSize = true;
      lblIndex.Location = new Point(12, 681);
      lblIndex.Name = "lblIndex";
      lblIndex.Size = new System.Drawing.Size(36, 15);
      lblIndex.TabIndex = 4;
      lblIndex.Text = "Index";
      // 
      // lblName
      // 
      lblName.AutoSize = true;
      lblName.Font = new Font("Segoe UI", 9F);
      lblName.Location = new Point(6, 20);
      lblName.Name = "lblName";
      lblName.Size = new System.Drawing.Size(39, 15);
      lblName.TabIndex = 5;
      lblName.Text = "Name";
      // 
      // statusStrip
      // 
      statusStrip.BackColor = Color.Transparent;
      statusStrip.Location = new Point(0, 690);
      statusStrip.Name = "statusStrip";
      statusStrip.Size = new System.Drawing.Size(1414, 22);
      statusStrip.TabIndex = 6;
      statusStrip.Text = "statusStrip1";
      // 
      // grbxAttributes
      // 
      grbxAttributes.Controls.Add(dgvAttributes);
      grbxAttributes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxAttributes.Location = new Point(509, 12);
      grbxAttributes.Name = "grbxAttributes";
      grbxAttributes.Size = new System.Drawing.Size(446, 302);
      grbxAttributes.TabIndex = 7;
      grbxAttributes.TabStop = false;
      grbxAttributes.Text = "Attributes";
      // 
      // dgvAttributes
      // 
      dgvAttributes.AllowUserToAddRows = false;
      dgvAttributes.AllowUserToDeleteRows = false;
      dgvAttributes.AllowUserToResizeRows = false;
      dgvAttributes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = SystemColors.Window;
      dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F);
      dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
      dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
      dgvAttributes.DefaultCellStyle = dataGridViewCellStyle1;
      dgvAttributes.Dock = DockStyle.Fill;
      dgvAttributes.Location = new Point(3, 19);
      dgvAttributes.MultiSelect = false;
      dgvAttributes.Name = "dgvAttributes";
      dgvAttributes.RowHeadersVisible = false;
      dgvAttributes.SelectionMode = DataGridViewSelectionMode.CellSelect;
      dgvAttributes.Size = new System.Drawing.Size(440, 280);
      dgvAttributes.TabIndex = 0;
      // 
      // grbxSkills
      // 
      grbxSkills.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      grbxSkills.Controls.Add(dgvSkills);
      grbxSkills.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxSkills.Location = new Point(961, 12);
      grbxSkills.Name = "grbxSkills";
      grbxSkills.Size = new System.Drawing.Size(446, 302);
      grbxSkills.TabIndex = 8;
      grbxSkills.TabStop = false;
      grbxSkills.Text = "Skills";
      // 
      // dgvSkills
      // 
      dgvSkills.AllowUserToAddRows = false;
      dgvSkills.AllowUserToDeleteRows = false;
      dgvSkills.AllowUserToResizeRows = false;
      dgvSkills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle2.BackColor = SystemColors.Window;
      dataGridViewCellStyle2.Font = new Font("Segoe UI", 8F);
      dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
      dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      dgvSkills.DefaultCellStyle = dataGridViewCellStyle2;
      dgvSkills.Dock = DockStyle.Fill;
      dgvSkills.Location = new Point(3, 19);
      dgvSkills.MultiSelect = false;
      dgvSkills.Name = "dgvSkills";
      dgvSkills.RowHeadersVisible = false;
      dgvSkills.SelectionMode = DataGridViewSelectionMode.CellSelect;
      dgvSkills.Size = new System.Drawing.Size(440, 280);
      dgvSkills.TabIndex = 0;
      // 
      // grbxGeneral
      // 
      grbxGeneral.Controls.Add(label11);
      grbxGeneral.Controls.Add(label10);
      grbxGeneral.Controls.Add(cbxElement);
      grbxGeneral.Controls.Add(label7);
      grbxGeneral.Controls.Add(label6);
      grbxGeneral.Controls.Add(label5);
      grbxGeneral.Controls.Add(label29);
      grbxGeneral.Controls.Add(cbxGender);
      grbxGeneral.Controls.Add(nudDefeatExperience);
      grbxGeneral.Controls.Add(label3);
      grbxGeneral.Controls.Add(label2);
      grbxGeneral.Controls.Add(label1);
      grbxGeneral.Controls.Add(nudFood);
      grbxGeneral.Controls.Add(nudGold);
      grbxGeneral.Controls.Add(nudLevel);
      grbxGeneral.Controls.Add(cbxClass);
      grbxGeneral.Controls.Add(cbxRace);
      grbxGeneral.Controls.Add(cbxType);
      grbxGeneral.Controls.Add(lblName);
      grbxGeneral.Controls.Add(tbxName);
      grbxGeneral.Controls.Add(label4);
      grbxGeneral.Controls.Add(nudMorale);
      grbxGeneral.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxGeneral.Location = new Point(12, 12);
      grbxGeneral.Name = "grbxGeneral";
      grbxGeneral.Size = new System.Drawing.Size(491, 138);
      grbxGeneral.TabIndex = 9;
      grbxGeneral.TabStop = false;
      grbxGeneral.Text = "General";
      // 
      // label11
      // 
      label11.AutoSize = true;
      label11.Font = new Font("Segoe UI", 9F);
      label11.Location = new Point(329, 106);
      label11.Name = "label11";
      label11.Size = new System.Drawing.Size(34, 15);
      label11.TabIndex = 26;
      label11.Text = "Food";
      // 
      // label10
      // 
      label10.AutoSize = true;
      label10.Font = new Font("Segoe UI", 9F);
      label10.Location = new Point(182, 106);
      label10.Name = "label10";
      label10.Size = new System.Drawing.Size(32, 15);
      label10.TabIndex = 25;
      label10.Text = "Gold";
      // 
      // cbxElement
      // 
      cbxElement.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxElement.Font = new Font("Segoe UI", 9F);
      cbxElement.FormattingEnabled = true;
      cbxElement.Location = new Point(393, 17);
      cbxElement.Name = "cbxElement";
      cbxElement.Size = new System.Drawing.Size(85, 23);
      cbxElement.TabIndex = 41;
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Font = new Font("Segoe UI", 9F);
      label7.Location = new Point(329, 20);
      label7.Name = "label7";
      label7.Size = new System.Drawing.Size(50, 15);
      label7.TabIndex = 40;
      label7.Text = "Element";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Font = new Font("Segoe UI", 9F);
      label6.Location = new Point(182, 78);
      label6.Name = "label6";
      label6.Size = new System.Drawing.Size(34, 15);
      label6.TabIndex = 21;
      label6.Text = "Level";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Font = new Font("Segoe UI", 9F);
      label5.Location = new Point(6, 78);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(34, 15);
      label5.TabIndex = 20;
      label5.Text = "Class";
      // 
      // label29
      // 
      label29.AutoSize = true;
      label29.Font = new Font("Segoe UI", 9F);
      label29.Location = new Point(329, 78);
      label29.Name = "label29";
      label29.Size = new System.Drawing.Size(58, 15);
      label29.TabIndex = 38;
      label29.Text = "Defeat XP";
      // 
      // cbxGender
      // 
      cbxGender.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxGender.Font = new Font("Segoe UI", 9F);
      cbxGender.FormattingEnabled = true;
      cbxGender.Location = new Point(236, 46);
      cbxGender.Name = "cbxGender";
      cbxGender.Size = new System.Drawing.Size(87, 23);
      cbxGender.TabIndex = 18;
      // 
      // nudDefeatExperience
      // 
      nudDefeatExperience.Font = new Font("Segoe UI", 9F);
      nudDefeatExperience.Location = new Point(393, 75);
      nudDefeatExperience.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
      nudDefeatExperience.Name = "nudDefeatExperience";
      nudDefeatExperience.Size = new System.Drawing.Size(85, 23);
      nudDefeatExperience.TabIndex = 37;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new Font("Segoe UI", 9F);
      label3.Location = new Point(182, 49);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(45, 15);
      label3.TabIndex = 17;
      label3.Text = "Gender";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 9F);
      label2.Location = new Point(6, 49);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(32, 15);
      label2.TabIndex = 16;
      label2.Text = "Race";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 9F);
      label1.Location = new Point(182, 20);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(31, 15);
      label1.TabIndex = 15;
      label1.Text = "Type";
      // 
      // nudFood
      // 
      nudFood.Font = new Font("Segoe UI", 9F);
      nudFood.Location = new Point(393, 104);
      nudFood.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
      nudFood.Name = "nudFood";
      nudFood.Size = new System.Drawing.Size(85, 23);
      nudFood.TabIndex = 13;
      // 
      // nudGold
      // 
      nudGold.Font = new Font("Segoe UI", 9F);
      nudGold.Location = new Point(236, 104);
      nudGold.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
      nudGold.Name = "nudGold";
      nudGold.Size = new System.Drawing.Size(87, 23);
      nudGold.TabIndex = 12;
      // 
      // nudLevel
      // 
      nudLevel.Font = new Font("Segoe UI", 9F);
      nudLevel.Location = new Point(236, 75);
      nudLevel.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
      nudLevel.Name = "nudLevel";
      nudLevel.Size = new System.Drawing.Size(42, 23);
      nudLevel.TabIndex = 10;
      // 
      // cbxClass
      // 
      cbxClass.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxClass.Font = new Font("Segoe UI", 9F);
      cbxClass.FormattingEnabled = true;
      cbxClass.Location = new Point(60, 75);
      cbxClass.Name = "cbxClass";
      cbxClass.Size = new System.Drawing.Size(116, 23);
      cbxClass.TabIndex = 2;
      // 
      // cbxRace
      // 
      cbxRace.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxRace.Font = new Font("Segoe UI", 9F);
      cbxRace.FormattingEnabled = true;
      cbxRace.Location = new Point(60, 46);
      cbxRace.Name = "cbxRace";
      cbxRace.Size = new System.Drawing.Size(116, 23);
      cbxRace.TabIndex = 1;
      // 
      // cbxType
      // 
      cbxType.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxType.Enabled = false;
      cbxType.Font = new Font("Segoe UI", 9F);
      cbxType.FormattingEnabled = true;
      cbxType.Location = new Point(236, 17);
      cbxType.Name = "cbxType";
      cbxType.Size = new System.Drawing.Size(87, 23);
      cbxType.TabIndex = 0;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Font = new Font("Segoe UI", 9F);
      label4.Location = new Point(329, 50);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(44, 15);
      label4.TabIndex = 19;
      label4.Text = "Morale";
      // 
      // nudMorale
      // 
      nudMorale.Font = new Font("Segoe UI", 9F);
      nudMorale.Location = new Point(393, 46);
      nudMorale.Name = "nudMorale";
      nudMorale.Size = new System.Drawing.Size(57, 23);
      nudMorale.TabIndex = 3;
      // 
      // grbxBattleFlags
      // 
      grbxBattleFlags.Controls.Add(chbxBattleFlagsUndead);
      grbxBattleFlags.Controls.Add(chbxBattleFlagsBonusFire);
      grbxBattleFlags.Controls.Add(chbxBattleFlagsBonusWind);
      grbxBattleFlags.Controls.Add(chbxBattleFlagsBonusEarth);
      grbxBattleFlags.Controls.Add(chbxBattleFlagsAnimal);
      grbxBattleFlags.Controls.Add(chbxBattleFlagsBoss);
      grbxBattleFlags.Controls.Add(chbxBattleFlagsDemon);
      grbxBattleFlags.Controls.Add(chbxBattleFlagsNone);
      grbxBattleFlags.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxBattleFlags.Location = new Point(262, 156);
      grbxBattleFlags.Name = "grbxBattleFlags";
      grbxBattleFlags.Size = new System.Drawing.Size(241, 108);
      grbxBattleFlags.TabIndex = 10;
      grbxBattleFlags.TabStop = false;
      grbxBattleFlags.Text = "Battle Flags";
      // 
      // chbxBattleFlagsUndead
      // 
      chbxBattleFlagsUndead.AutoSize = true;
      chbxBattleFlagsUndead.Font = new Font("Segoe UI", 9F);
      chbxBattleFlagsUndead.Location = new Point(67, 72);
      chbxBattleFlagsUndead.Name = "chbxBattleFlagsUndead";
      chbxBattleFlagsUndead.Size = new System.Drawing.Size(67, 19);
      chbxBattleFlagsUndead.TabIndex = 7;
      chbxBattleFlagsUndead.Text = "Undead";
      chbxBattleFlagsUndead.UseVisualStyleBackColor = true;
      // 
      // chbxBattleFlagsBonusFire
      // 
      chbxBattleFlagsBonusFire.AutoSize = true;
      chbxBattleFlagsBonusFire.Font = new Font("Segoe UI", 9F);
      chbxBattleFlagsBonusFire.Location = new Point(140, 47);
      chbxBattleFlagsBonusFire.Name = "chbxBattleFlagsBonusFire";
      chbxBattleFlagsBonusFire.Size = new System.Drawing.Size(84, 19);
      chbxBattleFlagsBonusFire.TabIndex = 6;
      chbxBattleFlagsBonusFire.Text = "Bonus: Fire";
      chbxBattleFlagsBonusFire.UseVisualStyleBackColor = true;
      // 
      // chbxBattleFlagsBonusWind
      // 
      chbxBattleFlagsBonusWind.AutoSize = true;
      chbxBattleFlagsBonusWind.Font = new Font("Segoe UI", 9F);
      chbxBattleFlagsBonusWind.Location = new Point(140, 72);
      chbxBattleFlagsBonusWind.Name = "chbxBattleFlagsBonusWind";
      chbxBattleFlagsBonusWind.Size = new System.Drawing.Size(93, 19);
      chbxBattleFlagsBonusWind.TabIndex = 5;
      chbxBattleFlagsBonusWind.Text = "Bonus: Wind";
      chbxBattleFlagsBonusWind.UseVisualStyleBackColor = true;
      // 
      // chbxBattleFlagsBonusEarth
      // 
      chbxBattleFlagsBonusEarth.AutoSize = true;
      chbxBattleFlagsBonusEarth.Font = new Font("Segoe UI", 9F);
      chbxBattleFlagsBonusEarth.Location = new Point(140, 22);
      chbxBattleFlagsBonusEarth.Name = "chbxBattleFlagsBonusEarth";
      chbxBattleFlagsBonusEarth.Size = new System.Drawing.Size(92, 19);
      chbxBattleFlagsBonusEarth.TabIndex = 4;
      chbxBattleFlagsBonusEarth.Text = "Bonus: Earth";
      chbxBattleFlagsBonusEarth.UseVisualStyleBackColor = true;
      // 
      // chbxBattleFlagsAnimal
      // 
      chbxBattleFlagsAnimal.AutoSize = true;
      chbxBattleFlagsAnimal.Font = new Font("Segoe UI", 9F);
      chbxBattleFlagsAnimal.Location = new Point(67, 22);
      chbxBattleFlagsAnimal.Name = "chbxBattleFlagsAnimal";
      chbxBattleFlagsAnimal.Size = new System.Drawing.Size(64, 19);
      chbxBattleFlagsAnimal.TabIndex = 3;
      chbxBattleFlagsAnimal.Text = "Animal";
      chbxBattleFlagsAnimal.UseVisualStyleBackColor = true;
      // 
      // chbxBattleFlagsBoss
      // 
      chbxBattleFlagsBoss.AutoSize = true;
      chbxBattleFlagsBoss.Font = new Font("Segoe UI", 9F);
      chbxBattleFlagsBoss.Location = new Point(6, 47);
      chbxBattleFlagsBoss.Name = "chbxBattleFlagsBoss";
      chbxBattleFlagsBoss.Size = new System.Drawing.Size(50, 19);
      chbxBattleFlagsBoss.TabIndex = 2;
      chbxBattleFlagsBoss.Text = "Boss";
      chbxBattleFlagsBoss.UseVisualStyleBackColor = true;
      // 
      // chbxBattleFlagsDemon
      // 
      chbxBattleFlagsDemon.AutoSize = true;
      chbxBattleFlagsDemon.Font = new Font("Segoe UI", 9F);
      chbxBattleFlagsDemon.Location = new Point(67, 47);
      chbxBattleFlagsDemon.Name = "chbxBattleFlagsDemon";
      chbxBattleFlagsDemon.Size = new System.Drawing.Size(65, 19);
      chbxBattleFlagsDemon.TabIndex = 1;
      chbxBattleFlagsDemon.Text = "Demon";
      chbxBattleFlagsDemon.UseVisualStyleBackColor = true;
      // 
      // chbxBattleFlagsNone
      // 
      chbxBattleFlagsNone.AutoSize = true;
      chbxBattleFlagsNone.Font = new Font("Segoe UI", 9F);
      chbxBattleFlagsNone.Location = new Point(6, 22);
      chbxBattleFlagsNone.Name = "chbxBattleFlagsNone";
      chbxBattleFlagsNone.Size = new System.Drawing.Size(55, 19);
      chbxBattleFlagsNone.TabIndex = 0;
      chbxBattleFlagsNone.Text = "None";
      chbxBattleFlagsNone.UseVisualStyleBackColor = true;
      // 
      // label15
      // 
      label15.AutoSize = true;
      label15.Font = new Font("Segoe UI", 9F);
      label15.Location = new Point(6, 23);
      label15.Name = "label15";
      label15.Size = new System.Drawing.Size(47, 15);
      label15.TabIndex = 34;
      label15.Text = "Current";
      // 
      // grbxHitPoints
      // 
      grbxHitPoints.Controls.Add(nudHitPointsBonus);
      grbxHitPoints.Controls.Add(nudHitPointsCurrent);
      grbxHitPoints.Controls.Add(nudHitPointsMax);
      grbxHitPoints.Controls.Add(label16);
      grbxHitPoints.Controls.Add(label15);
      grbxHitPoints.Controls.Add(label18);
      grbxHitPoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxHitPoints.Location = new Point(12, 156);
      grbxHitPoints.Name = "grbxHitPoints";
      grbxHitPoints.Size = new System.Drawing.Size(119, 108);
      grbxHitPoints.TabIndex = 11;
      grbxHitPoints.TabStop = false;
      grbxHitPoints.Text = "Hit Points";
      // 
      // nudHitPointsBonus
      // 
      nudHitPointsBonus.Font = new Font("Segoe UI", 9F);
      nudHitPointsBonus.Location = new Point(59, 79);
      nudHitPointsBonus.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
      nudHitPointsBonus.Name = "nudHitPointsBonus";
      nudHitPointsBonus.ReadOnly = true;
      nudHitPointsBonus.Size = new System.Drawing.Size(54, 23);
      nudHitPointsBonus.TabIndex = 42;
      // 
      // nudHitPointsCurrent
      // 
      nudHitPointsCurrent.Font = new Font("Segoe UI", 9F);
      nudHitPointsCurrent.Location = new Point(59, 21);
      nudHitPointsCurrent.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
      nudHitPointsCurrent.Name = "nudHitPointsCurrent";
      nudHitPointsCurrent.ReadOnly = true;
      nudHitPointsCurrent.Size = new System.Drawing.Size(54, 23);
      nudHitPointsCurrent.TabIndex = 41;
      // 
      // nudHitPointsMax
      // 
      nudHitPointsMax.Font = new Font("Segoe UI", 9F);
      nudHitPointsMax.Location = new Point(59, 50);
      nudHitPointsMax.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
      nudHitPointsMax.Name = "nudHitPointsMax";
      nudHitPointsMax.Size = new System.Drawing.Size(54, 23);
      nudHitPointsMax.TabIndex = 39;
      // 
      // label16
      // 
      label16.AutoSize = true;
      label16.Font = new Font("Segoe UI", 9F);
      label16.Location = new Point(6, 81);
      label16.Name = "label16";
      label16.Size = new System.Drawing.Size(40, 15);
      label16.TabIndex = 36;
      label16.Text = "Bonus";
      // 
      // label18
      // 
      label18.AutoSize = true;
      label18.Font = new Font("Segoe UI", 9F);
      label18.Location = new Point(6, 51);
      label18.Name = "label18";
      label18.Size = new System.Drawing.Size(30, 15);
      label18.TabIndex = 40;
      label18.Text = "Max";
      // 
      // grbxAttack
      // 
      grbxAttack.Controls.Add(nudAttackBonus);
      grbxAttack.Controls.Add(nudAttacksPerRound);
      grbxAttack.Controls.Add(nudAttackMagicLevel);
      grbxAttack.Controls.Add(label24);
      grbxAttack.Controls.Add(label23);
      grbxAttack.Controls.Add(nudAttackBase);
      grbxAttack.Controls.Add(label25);
      grbxAttack.Controls.Add(label26);
      grbxAttack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxAttack.Location = new Point(12, 270);
      grbxAttack.Name = "grbxAttack";
      grbxAttack.Size = new System.Drawing.Size(171, 145);
      grbxAttack.TabIndex = 34;
      grbxAttack.TabStop = false;
      grbxAttack.Text = "Attack";
      // 
      // nudAttackBonus
      // 
      nudAttackBonus.Font = new Font("Segoe UI", 9F);
      nudAttackBonus.Location = new Point(104, 51);
      nudAttackBonus.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudAttackBonus.Name = "nudAttackBonus";
      nudAttackBonus.ReadOnly = true;
      nudAttackBonus.Size = new System.Drawing.Size(57, 23);
      nudAttackBonus.TabIndex = 48;
      // 
      // nudAttacksPerRound
      // 
      nudAttacksPerRound.Font = new Font("Segoe UI", 9F);
      nudAttacksPerRound.Location = new Point(104, 109);
      nudAttacksPerRound.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
      nudAttacksPerRound.Name = "nudAttacksPerRound";
      nudAttacksPerRound.Size = new System.Drawing.Size(57, 23);
      nudAttacksPerRound.TabIndex = 41;
      // 
      // nudAttackMagicLevel
      // 
      nudAttackMagicLevel.Font = new Font("Segoe UI", 9F);
      nudAttackMagicLevel.Location = new Point(104, 80);
      nudAttackMagicLevel.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudAttackMagicLevel.Name = "nudAttackMagicLevel";
      nudAttackMagicLevel.Size = new System.Drawing.Size(57, 23);
      nudAttackMagicLevel.TabIndex = 39;
      // 
      // label24
      // 
      label24.AutoSize = true;
      label24.Font = new Font("Segoe UI", 9F);
      label24.Location = new Point(6, 111);
      label24.Name = "label24";
      label24.Size = new System.Drawing.Size(92, 15);
      label24.TabIndex = 42;
      label24.Text = "Attacks / Round";
      // 
      // label23
      // 
      label23.AutoSize = true;
      label23.Font = new Font("Segoe UI", 9F);
      label23.Location = new Point(6, 82);
      label23.Name = "label23";
      label23.Size = new System.Drawing.Size(70, 15);
      label23.TabIndex = 40;
      label23.Text = "Magic Level";
      // 
      // nudAttackBase
      // 
      nudAttackBase.Font = new Font("Segoe UI", 9F);
      nudAttackBase.Location = new Point(104, 22);
      nudAttackBase.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudAttackBase.Name = "nudAttackBase";
      nudAttackBase.Size = new System.Drawing.Size(57, 23);
      nudAttackBase.TabIndex = 33;
      // 
      // label25
      // 
      label25.AutoSize = true;
      label25.Font = new Font("Segoe UI", 9F);
      label25.Location = new Point(6, 52);
      label25.Name = "label25";
      label25.Size = new System.Drawing.Size(40, 15);
      label25.TabIndex = 36;
      label25.Text = "Bonus";
      // 
      // label26
      // 
      label26.AutoSize = true;
      label26.Font = new Font("Segoe UI", 9F);
      label26.Location = new Point(6, 24);
      label26.Name = "label26";
      label26.Size = new System.Drawing.Size(31, 15);
      label26.TabIndex = 34;
      label26.Text = "Base";
      // 
      // grbxSpellPoints
      // 
      grbxSpellPoints.Controls.Add(nudSpellPointsCurrent);
      grbxSpellPoints.Controls.Add(nudSpellPointsBonus);
      grbxSpellPoints.Controls.Add(nudSpellPointsMax);
      grbxSpellPoints.Controls.Add(label17);
      grbxSpellPoints.Controls.Add(label19);
      grbxSpellPoints.Controls.Add(label20);
      grbxSpellPoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxSpellPoints.Location = new Point(137, 156);
      grbxSpellPoints.Name = "grbxSpellPoints";
      grbxSpellPoints.Size = new System.Drawing.Size(119, 108);
      grbxSpellPoints.TabIndex = 36;
      grbxSpellPoints.TabStop = false;
      grbxSpellPoints.Text = "Spell Points";
      // 
      // nudSpellPointsCurrent
      // 
      nudSpellPointsCurrent.Font = new Font("Segoe UI", 9F);
      nudSpellPointsCurrent.Location = new Point(59, 21);
      nudSpellPointsCurrent.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
      nudSpellPointsCurrent.Name = "nudSpellPointsCurrent";
      nudSpellPointsCurrent.ReadOnly = true;
      nudSpellPointsCurrent.Size = new System.Drawing.Size(54, 23);
      nudSpellPointsCurrent.TabIndex = 48;
      // 
      // nudSpellPointsBonus
      // 
      nudSpellPointsBonus.Font = new Font("Segoe UI", 9F);
      nudSpellPointsBonus.Location = new Point(59, 79);
      nudSpellPointsBonus.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
      nudSpellPointsBonus.Name = "nudSpellPointsBonus";
      nudSpellPointsBonus.ReadOnly = true;
      nudSpellPointsBonus.Size = new System.Drawing.Size(54, 23);
      nudSpellPointsBonus.TabIndex = 43;
      // 
      // nudSpellPointsMax
      // 
      nudSpellPointsMax.Font = new Font("Segoe UI", 9F);
      nudSpellPointsMax.Location = new Point(59, 50);
      nudSpellPointsMax.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
      nudSpellPointsMax.Name = "nudSpellPointsMax";
      nudSpellPointsMax.Size = new System.Drawing.Size(54, 23);
      nudSpellPointsMax.TabIndex = 39;
      // 
      // label17
      // 
      label17.AutoSize = true;
      label17.Font = new Font("Segoe UI", 9F);
      label17.Location = new Point(6, 23);
      label17.Name = "label17";
      label17.Size = new System.Drawing.Size(47, 15);
      label17.TabIndex = 34;
      label17.Text = "Current";
      // 
      // label19
      // 
      label19.AutoSize = true;
      label19.Font = new Font("Segoe UI", 9F);
      label19.Location = new Point(6, 52);
      label19.Name = "label19";
      label19.Size = new System.Drawing.Size(30, 15);
      label19.TabIndex = 40;
      label19.Text = "Max";
      // 
      // label20
      // 
      label20.AutoSize = true;
      label20.Font = new Font("Segoe UI", 9F);
      label20.Location = new Point(5, 81);
      label20.Name = "label20";
      label20.Size = new System.Drawing.Size(40, 15);
      label20.TabIndex = 36;
      label20.Text = "Bonus";
      // 
      // grbxDefense
      // 
      grbxDefense.Controls.Add(nudDefenseBonus);
      grbxDefense.Controls.Add(nudDefenseMagicLevel);
      grbxDefense.Controls.Add(label31);
      grbxDefense.Controls.Add(nudDefenseBase);
      grbxDefense.Controls.Add(label32);
      grbxDefense.Controls.Add(label33);
      grbxDefense.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxDefense.Location = new Point(189, 270);
      grbxDefense.Name = "grbxDefense";
      grbxDefense.Size = new System.Drawing.Size(146, 145);
      grbxDefense.TabIndex = 39;
      grbxDefense.TabStop = false;
      grbxDefense.Text = "Defense";
      // 
      // nudDefenseBonus
      // 
      nudDefenseBonus.Font = new Font("Segoe UI", 9F);
      nudDefenseBonus.Location = new Point(82, 51);
      nudDefenseBonus.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudDefenseBonus.Name = "nudDefenseBonus";
      nudDefenseBonus.ReadOnly = true;
      nudDefenseBonus.Size = new System.Drawing.Size(57, 23);
      nudDefenseBonus.TabIndex = 49;
      // 
      // nudDefenseMagicLevel
      // 
      nudDefenseMagicLevel.Font = new Font("Segoe UI", 9F);
      nudDefenseMagicLevel.Location = new Point(82, 80);
      nudDefenseMagicLevel.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudDefenseMagicLevel.Name = "nudDefenseMagicLevel";
      nudDefenseMagicLevel.Size = new System.Drawing.Size(57, 23);
      nudDefenseMagicLevel.TabIndex = 39;
      // 
      // label31
      // 
      label31.AutoSize = true;
      label31.Font = new Font("Segoe UI", 9F);
      label31.Location = new Point(6, 82);
      label31.Name = "label31";
      label31.Size = new System.Drawing.Size(70, 15);
      label31.TabIndex = 40;
      label31.Text = "Magic Level";
      // 
      // nudDefenseBase
      // 
      nudDefenseBase.Font = new Font("Segoe UI", 9F);
      nudDefenseBase.Location = new Point(82, 22);
      nudDefenseBase.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudDefenseBase.Name = "nudDefenseBase";
      nudDefenseBase.Size = new System.Drawing.Size(57, 23);
      nudDefenseBase.TabIndex = 33;
      // 
      // label32
      // 
      label32.AutoSize = true;
      label32.Font = new Font("Segoe UI", 9F);
      label32.Location = new Point(6, 52);
      label32.Name = "label32";
      label32.Size = new System.Drawing.Size(40, 15);
      label32.TabIndex = 36;
      label32.Text = "Bonus";
      // 
      // label33
      // 
      label33.AutoSize = true;
      label33.Font = new Font("Segoe UI", 9F);
      label33.Location = new Point(6, 24);
      label33.Name = "label33";
      label33.Size = new System.Drawing.Size(31, 15);
      label33.TabIndex = 34;
      label33.Text = "Base";
      // 
      // grbxSpellMastery
      // 
      grbxSpellMastery.Controls.Add(chbxSpellMasteryMastered);
      grbxSpellMastery.Controls.Add(chbxSpellMasteryFunction);
      grbxSpellMastery.Controls.Add(chbxSpellMasteryMystic);
      grbxSpellMastery.Controls.Add(chbxSpellMasteryUnused1);
      grbxSpellMastery.Controls.Add(chbxSpellMasteryUnused2);
      grbxSpellMastery.Controls.Add(chbxSpellMasteryDestruction);
      grbxSpellMastery.Controls.Add(chbxSpellMasteryHealing);
      grbxSpellMastery.Controls.Add(chbxSpellMasteryAll);
      grbxSpellMastery.Controls.Add(chbxSpellMasteryAlchemistic);
      grbxSpellMastery.Controls.Add(chbxSpellMasteryNone);
      grbxSpellMastery.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxSpellMastery.Location = new Point(12, 421);
      grbxSpellMastery.Name = "grbxSpellMastery";
      grbxSpellMastery.Size = new System.Drawing.Size(186, 145);
      grbxSpellMastery.TabIndex = 42;
      grbxSpellMastery.TabStop = false;
      grbxSpellMastery.Text = "Spell Mastery";
      // 
      // chbxSpellMasteryMastered
      // 
      chbxSpellMasteryMastered.AutoSize = true;
      chbxSpellMasteryMastered.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryMastered.Location = new Point(6, 72);
      chbxSpellMasteryMastered.Name = "chbxSpellMasteryMastered";
      chbxSpellMasteryMastered.Size = new System.Drawing.Size(75, 19);
      chbxSpellMasteryMastered.TabIndex = 43;
      chbxSpellMasteryMastered.Text = "Mastered";
      chbxSpellMasteryMastered.UseVisualStyleBackColor = true;
      // 
      // chbxSpellMasteryFunction
      // 
      chbxSpellMasteryFunction.AutoSize = true;
      chbxSpellMasteryFunction.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryFunction.Location = new Point(87, 72);
      chbxSpellMasteryFunction.Name = "chbxSpellMasteryFunction";
      chbxSpellMasteryFunction.Size = new System.Drawing.Size(73, 19);
      chbxSpellMasteryFunction.TabIndex = 43;
      chbxSpellMasteryFunction.Text = "Function";
      chbxSpellMasteryFunction.UseVisualStyleBackColor = true;
      // 
      // chbxSpellMasteryMystic
      // 
      chbxSpellMasteryMystic.AutoSize = true;
      chbxSpellMasteryMystic.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryMystic.Location = new Point(87, 122);
      chbxSpellMasteryMystic.Name = "chbxSpellMasteryMystic";
      chbxSpellMasteryMystic.Size = new System.Drawing.Size(61, 19);
      chbxSpellMasteryMystic.TabIndex = 7;
      chbxSpellMasteryMystic.Text = "Mystic";
      chbxSpellMasteryMystic.UseVisualStyleBackColor = true;
      // 
      // chbxSpellMasteryUnused1
      // 
      chbxSpellMasteryUnused1.AutoSize = true;
      chbxSpellMasteryUnused1.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryUnused1.Location = new Point(6, 97);
      chbxSpellMasteryUnused1.Name = "chbxSpellMasteryUnused1";
      chbxSpellMasteryUnused1.Size = new System.Drawing.Size(75, 19);
      chbxSpellMasteryUnused1.TabIndex = 6;
      chbxSpellMasteryUnused1.Text = "Unused 1";
      chbxSpellMasteryUnused1.UseVisualStyleBackColor = true;
      // 
      // chbxSpellMasteryUnused2
      // 
      chbxSpellMasteryUnused2.AutoSize = true;
      chbxSpellMasteryUnused2.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryUnused2.Location = new Point(6, 122);
      chbxSpellMasteryUnused2.Name = "chbxSpellMasteryUnused2";
      chbxSpellMasteryUnused2.Size = new System.Drawing.Size(75, 19);
      chbxSpellMasteryUnused2.TabIndex = 5;
      chbxSpellMasteryUnused2.Text = "Unused 2";
      chbxSpellMasteryUnused2.UseVisualStyleBackColor = true;
      // 
      // chbxSpellMasteryDestruction
      // 
      chbxSpellMasteryDestruction.AutoSize = true;
      chbxSpellMasteryDestruction.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryDestruction.Location = new Point(87, 47);
      chbxSpellMasteryDestruction.Name = "chbxSpellMasteryDestruction";
      chbxSpellMasteryDestruction.Size = new System.Drawing.Size(87, 19);
      chbxSpellMasteryDestruction.TabIndex = 4;
      chbxSpellMasteryDestruction.Text = "Destruction";
      chbxSpellMasteryDestruction.UseVisualStyleBackColor = true;
      // 
      // chbxSpellMasteryHealing
      // 
      chbxSpellMasteryHealing.AutoSize = true;
      chbxSpellMasteryHealing.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryHealing.Location = new Point(87, 97);
      chbxSpellMasteryHealing.Name = "chbxSpellMasteryHealing";
      chbxSpellMasteryHealing.Size = new System.Drawing.Size(67, 19);
      chbxSpellMasteryHealing.TabIndex = 3;
      chbxSpellMasteryHealing.Text = "Healing";
      chbxSpellMasteryHealing.UseVisualStyleBackColor = true;
      // 
      // chbxSpellMasteryAll
      // 
      chbxSpellMasteryAll.AutoSize = true;
      chbxSpellMasteryAll.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryAll.Location = new Point(6, 47);
      chbxSpellMasteryAll.Name = "chbxSpellMasteryAll";
      chbxSpellMasteryAll.Size = new System.Drawing.Size(40, 19);
      chbxSpellMasteryAll.TabIndex = 2;
      chbxSpellMasteryAll.Text = "All";
      chbxSpellMasteryAll.UseVisualStyleBackColor = true;
      // 
      // chbxSpellMasteryAlchemistic
      // 
      chbxSpellMasteryAlchemistic.AutoSize = true;
      chbxSpellMasteryAlchemistic.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryAlchemistic.Location = new Point(87, 22);
      chbxSpellMasteryAlchemistic.Name = "chbxSpellMasteryAlchemistic";
      chbxSpellMasteryAlchemistic.Size = new System.Drawing.Size(88, 19);
      chbxSpellMasteryAlchemistic.TabIndex = 1;
      chbxSpellMasteryAlchemistic.Text = "Alchemistic";
      chbxSpellMasteryAlchemistic.UseVisualStyleBackColor = true;
      // 
      // chbxSpellMasteryNone
      // 
      chbxSpellMasteryNone.AutoSize = true;
      chbxSpellMasteryNone.Font = new Font("Segoe UI", 9F);
      chbxSpellMasteryNone.Location = new Point(6, 22);
      chbxSpellMasteryNone.Name = "chbxSpellMasteryNone";
      chbxSpellMasteryNone.Size = new System.Drawing.Size(55, 19);
      chbxSpellMasteryNone.TabIndex = 0;
      chbxSpellMasteryNone.Text = "None";
      chbxSpellMasteryNone.UseVisualStyleBackColor = true;
      // 
      // grbxSpellImmunity
      // 
      grbxSpellImmunity.Controls.Add(chbxSpellImmunityUnused);
      grbxSpellImmunity.Controls.Add(chbxSpellImmunityFunction);
      grbxSpellImmunity.Controls.Add(chbxSpellImmunityMystic);
      grbxSpellImmunity.Controls.Add(chbxSpellImmunityUnused1);
      grbxSpellImmunity.Controls.Add(chbxSpellImmunityUnused2);
      grbxSpellImmunity.Controls.Add(chbxSpellImmunityDestruction);
      grbxSpellImmunity.Controls.Add(chbxSpellImmunityHealing);
      grbxSpellImmunity.Controls.Add(chbxSpellImmunityAlchemistic);
      grbxSpellImmunity.Controls.Add(chbxSpellImmunityNone);
      grbxSpellImmunity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxSpellImmunity.Location = new Point(204, 421);
      grbxSpellImmunity.Name = "grbxSpellImmunity";
      grbxSpellImmunity.Size = new System.Drawing.Size(186, 145);
      grbxSpellImmunity.TabIndex = 43;
      grbxSpellImmunity.TabStop = false;
      grbxSpellImmunity.Text = "Spell Immunity";
      // 
      // chbxSpellImmunityUnused
      // 
      chbxSpellImmunityUnused.AutoSize = true;
      chbxSpellImmunityUnused.Font = new Font("Segoe UI", 9F);
      chbxSpellImmunityUnused.Location = new Point(6, 72);
      chbxSpellImmunityUnused.Name = "chbxSpellImmunityUnused";
      chbxSpellImmunityUnused.Size = new System.Drawing.Size(66, 19);
      chbxSpellImmunityUnused.TabIndex = 43;
      chbxSpellImmunityUnused.Text = "Unused";
      chbxSpellImmunityUnused.UseVisualStyleBackColor = true;
      // 
      // chbxSpellImmunityFunction
      // 
      chbxSpellImmunityFunction.AutoSize = true;
      chbxSpellImmunityFunction.Font = new Font("Segoe UI", 9F);
      chbxSpellImmunityFunction.Location = new Point(87, 72);
      chbxSpellImmunityFunction.Name = "chbxSpellImmunityFunction";
      chbxSpellImmunityFunction.Size = new System.Drawing.Size(73, 19);
      chbxSpellImmunityFunction.TabIndex = 43;
      chbxSpellImmunityFunction.Text = "Function";
      chbxSpellImmunityFunction.UseVisualStyleBackColor = true;
      // 
      // chbxSpellImmunityMystic
      // 
      chbxSpellImmunityMystic.AutoSize = true;
      chbxSpellImmunityMystic.Font = new Font("Segoe UI", 9F);
      chbxSpellImmunityMystic.Location = new Point(87, 122);
      chbxSpellImmunityMystic.Name = "chbxSpellImmunityMystic";
      chbxSpellImmunityMystic.Size = new System.Drawing.Size(61, 19);
      chbxSpellImmunityMystic.TabIndex = 7;
      chbxSpellImmunityMystic.Text = "Mystic";
      chbxSpellImmunityMystic.UseVisualStyleBackColor = true;
      // 
      // chbxSpellImmunityUnused1
      // 
      chbxSpellImmunityUnused1.AutoSize = true;
      chbxSpellImmunityUnused1.Font = new Font("Segoe UI", 9F);
      chbxSpellImmunityUnused1.Location = new Point(6, 97);
      chbxSpellImmunityUnused1.Name = "chbxSpellImmunityUnused1";
      chbxSpellImmunityUnused1.Size = new System.Drawing.Size(75, 19);
      chbxSpellImmunityUnused1.TabIndex = 6;
      chbxSpellImmunityUnused1.Text = "Unused 1";
      chbxSpellImmunityUnused1.UseVisualStyleBackColor = true;
      // 
      // chbxSpellImmunityUnused2
      // 
      chbxSpellImmunityUnused2.AutoSize = true;
      chbxSpellImmunityUnused2.Font = new Font("Segoe UI", 9F);
      chbxSpellImmunityUnused2.Location = new Point(6, 122);
      chbxSpellImmunityUnused2.Name = "chbxSpellImmunityUnused2";
      chbxSpellImmunityUnused2.Size = new System.Drawing.Size(75, 19);
      chbxSpellImmunityUnused2.TabIndex = 5;
      chbxSpellImmunityUnused2.Text = "Unused 2";
      chbxSpellImmunityUnused2.UseVisualStyleBackColor = true;
      // 
      // chbxSpellImmunityDestruction
      // 
      chbxSpellImmunityDestruction.AutoSize = true;
      chbxSpellImmunityDestruction.Font = new Font("Segoe UI", 9F);
      chbxSpellImmunityDestruction.Location = new Point(87, 47);
      chbxSpellImmunityDestruction.Name = "chbxSpellImmunityDestruction";
      chbxSpellImmunityDestruction.Size = new System.Drawing.Size(87, 19);
      chbxSpellImmunityDestruction.TabIndex = 4;
      chbxSpellImmunityDestruction.Text = "Destruction";
      chbxSpellImmunityDestruction.UseVisualStyleBackColor = true;
      // 
      // chbxSpellImmunityHealing
      // 
      chbxSpellImmunityHealing.AutoSize = true;
      chbxSpellImmunityHealing.Font = new Font("Segoe UI", 9F);
      chbxSpellImmunityHealing.Location = new Point(87, 97);
      chbxSpellImmunityHealing.Name = "chbxSpellImmunityHealing";
      chbxSpellImmunityHealing.Size = new System.Drawing.Size(67, 19);
      chbxSpellImmunityHealing.TabIndex = 3;
      chbxSpellImmunityHealing.Text = "Healing";
      chbxSpellImmunityHealing.UseVisualStyleBackColor = true;
      // 
      // chbxSpellImmunityAlchemistic
      // 
      chbxSpellImmunityAlchemistic.AutoSize = true;
      chbxSpellImmunityAlchemistic.Font = new Font("Segoe UI", 9F);
      chbxSpellImmunityAlchemistic.Location = new Point(87, 22);
      chbxSpellImmunityAlchemistic.Name = "chbxSpellImmunityAlchemistic";
      chbxSpellImmunityAlchemistic.Size = new System.Drawing.Size(88, 19);
      chbxSpellImmunityAlchemistic.TabIndex = 1;
      chbxSpellImmunityAlchemistic.Text = "Alchemistic";
      chbxSpellImmunityAlchemistic.UseVisualStyleBackColor = true;
      // 
      // chbxSpellImmunityNone
      // 
      chbxSpellImmunityNone.AutoSize = true;
      chbxSpellImmunityNone.Font = new Font("Segoe UI", 9F);
      chbxSpellImmunityNone.Location = new Point(6, 22);
      chbxSpellImmunityNone.Name = "chbxSpellImmunityNone";
      chbxSpellImmunityNone.Size = new System.Drawing.Size(55, 19);
      chbxSpellImmunityNone.TabIndex = 0;
      chbxSpellImmunityNone.Text = "None";
      chbxSpellImmunityNone.UseVisualStyleBackColor = true;
      // 
      // grbxConditions
      // 
      grbxConditions.Controls.Add(chbxConditionsDeadDust);
      grbxConditions.Controls.Add(chbxConditionsDeadAshes);
      grbxConditions.Controls.Add(chbxConditionsDrugged);
      grbxConditions.Controls.Add(chbxConditionsSleep);
      grbxConditions.Controls.Add(chbxConditionsDeadCorpse);
      grbxConditions.Controls.Add(chbxConditionsDiseased);
      grbxConditions.Controls.Add(chbxConditionsBlind);
      grbxConditions.Controls.Add(chbxConditionsLamed);
      grbxConditions.Controls.Add(chbxConditionsExhausted);
      grbxConditions.Controls.Add(chbxConditionsPanic);
      grbxConditions.Controls.Add(chbxConditionsPetrified);
      grbxConditions.Controls.Add(chbxConditionsAging);
      grbxConditions.Controls.Add(chbxConditionsPoisoned);
      grbxConditions.Controls.Add(chbxConditionsUnused);
      grbxConditions.Controls.Add(chbxConditionsCrazy);
      grbxConditions.Controls.Add(chbxConditionsNone);
      grbxConditions.Controls.Add(chbxConditionsIrritated);
      grbxConditions.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxConditions.Location = new Point(12, 572);
      grbxConditions.Name = "grbxConditions";
      grbxConditions.Size = new System.Drawing.Size(491, 98);
      grbxConditions.TabIndex = 44;
      grbxConditions.TabStop = false;
      grbxConditions.Text = "Conditions";
      // 
      // chbxConditionsDeadDust
      // 
      chbxConditionsDeadDust.AutoSize = true;
      chbxConditionsDeadDust.Font = new Font("Segoe UI", 9F);
      chbxConditionsDeadDust.Location = new Point(142, 72);
      chbxConditionsDeadDust.Name = "chbxConditionsDeadDust";
      chbxConditionsDeadDust.Size = new System.Drawing.Size(77, 19);
      chbxConditionsDeadDust.TabIndex = 50;
      chbxConditionsDeadDust.Text = "DeadDust";
      chbxConditionsDeadDust.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsDeadAshes
      // 
      chbxConditionsDeadAshes.AutoSize = true;
      chbxConditionsDeadAshes.Font = new Font("Segoe UI", 9F);
      chbxConditionsDeadAshes.Location = new Point(142, 22);
      chbxConditionsDeadAshes.Name = "chbxConditionsDeadAshes";
      chbxConditionsDeadAshes.Size = new System.Drawing.Size(84, 19);
      chbxConditionsDeadAshes.TabIndex = 49;
      chbxConditionsDeadAshes.Text = "DeadAshes";
      chbxConditionsDeadAshes.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsDrugged
      // 
      chbxConditionsDrugged.AutoSize = true;
      chbxConditionsDrugged.Font = new Font("Segoe UI", 9F);
      chbxConditionsDrugged.Location = new Point(238, 47);
      chbxConditionsDrugged.Name = "chbxConditionsDrugged";
      chbxConditionsDrugged.Size = new System.Drawing.Size(72, 19);
      chbxConditionsDrugged.TabIndex = 43;
      chbxConditionsDrugged.Text = "Drugged";
      chbxConditionsDrugged.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsSleep
      // 
      chbxConditionsSleep.AutoSize = true;
      chbxConditionsSleep.Font = new Font("Segoe UI", 9F);
      chbxConditionsSleep.Location = new Point(397, 72);
      chbxConditionsSleep.Name = "chbxConditionsSleep";
      chbxConditionsSleep.Size = new System.Drawing.Size(54, 19);
      chbxConditionsSleep.TabIndex = 43;
      chbxConditionsSleep.Text = "Sleep";
      chbxConditionsSleep.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsDeadCorpse
      // 
      chbxConditionsDeadCorpse.AutoSize = true;
      chbxConditionsDeadCorpse.Font = new Font("Segoe UI", 9F);
      chbxConditionsDeadCorpse.Location = new Point(142, 47);
      chbxConditionsDeadCorpse.Name = "chbxConditionsDeadCorpse";
      chbxConditionsDeadCorpse.Size = new System.Drawing.Size(90, 19);
      chbxConditionsDeadCorpse.TabIndex = 48;
      chbxConditionsDeadCorpse.Text = "DeadCorpse";
      chbxConditionsDeadCorpse.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsDiseased
      // 
      chbxConditionsDiseased.AutoSize = true;
      chbxConditionsDiseased.Font = new Font("Segoe UI", 9F);
      chbxConditionsDiseased.Location = new Point(238, 22);
      chbxConditionsDiseased.Name = "chbxConditionsDiseased";
      chbxConditionsDiseased.Size = new System.Drawing.Size(72, 19);
      chbxConditionsDiseased.TabIndex = 50;
      chbxConditionsDiseased.Text = "Diseased";
      chbxConditionsDiseased.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsBlind
      // 
      chbxConditionsBlind.AutoSize = true;
      chbxConditionsBlind.Font = new Font("Segoe UI", 9F);
      chbxConditionsBlind.Location = new Point(78, 47);
      chbxConditionsBlind.Name = "chbxConditionsBlind";
      chbxConditionsBlind.Size = new System.Drawing.Size(53, 19);
      chbxConditionsBlind.TabIndex = 7;
      chbxConditionsBlind.Text = "Blind";
      chbxConditionsBlind.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsLamed
      // 
      chbxConditionsLamed.AutoSize = true;
      chbxConditionsLamed.Font = new Font("Segoe UI", 9F);
      chbxConditionsLamed.Location = new Point(324, 47);
      chbxConditionsLamed.Name = "chbxConditionsLamed";
      chbxConditionsLamed.Size = new System.Drawing.Size(62, 19);
      chbxConditionsLamed.TabIndex = 5;
      chbxConditionsLamed.Text = "Lamed";
      chbxConditionsLamed.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsExhausted
      // 
      chbxConditionsExhausted.AutoSize = true;
      chbxConditionsExhausted.Font = new Font("Segoe UI", 9F);
      chbxConditionsExhausted.Location = new Point(238, 72);
      chbxConditionsExhausted.Name = "chbxConditionsExhausted";
      chbxConditionsExhausted.Size = new System.Drawing.Size(80, 19);
      chbxConditionsExhausted.TabIndex = 2;
      chbxConditionsExhausted.Text = "Exhausted";
      chbxConditionsExhausted.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsPanic
      // 
      chbxConditionsPanic.AutoSize = true;
      chbxConditionsPanic.Font = new Font("Segoe UI", 9F);
      chbxConditionsPanic.Location = new Point(324, 72);
      chbxConditionsPanic.Name = "chbxConditionsPanic";
      chbxConditionsPanic.Size = new System.Drawing.Size(55, 19);
      chbxConditionsPanic.TabIndex = 3;
      chbxConditionsPanic.Text = "Panic";
      chbxConditionsPanic.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsPetrified
      // 
      chbxConditionsPetrified.AutoSize = true;
      chbxConditionsPetrified.Font = new Font("Segoe UI", 9F);
      chbxConditionsPetrified.Location = new Point(397, 22);
      chbxConditionsPetrified.Name = "chbxConditionsPetrified";
      chbxConditionsPetrified.Size = new System.Drawing.Size(70, 19);
      chbxConditionsPetrified.TabIndex = 47;
      chbxConditionsPetrified.Text = "Petrified";
      chbxConditionsPetrified.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsAging
      // 
      chbxConditionsAging.AutoSize = true;
      chbxConditionsAging.Font = new Font("Segoe UI", 9F);
      chbxConditionsAging.Location = new Point(78, 22);
      chbxConditionsAging.Name = "chbxConditionsAging";
      chbxConditionsAging.Size = new System.Drawing.Size(58, 19);
      chbxConditionsAging.TabIndex = 46;
      chbxConditionsAging.Text = "Aging";
      chbxConditionsAging.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsPoisoned
      // 
      chbxConditionsPoisoned.AutoSize = true;
      chbxConditionsPoisoned.Font = new Font("Segoe UI", 9F);
      chbxConditionsPoisoned.Location = new Point(397, 47);
      chbxConditionsPoisoned.Name = "chbxConditionsPoisoned";
      chbxConditionsPoisoned.Size = new System.Drawing.Size(75, 19);
      chbxConditionsPoisoned.TabIndex = 45;
      chbxConditionsPoisoned.Text = "Poisoned";
      chbxConditionsPoisoned.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsUnused
      // 
      chbxConditionsUnused.AutoSize = true;
      chbxConditionsUnused.Font = new Font("Segoe UI", 9F);
      chbxConditionsUnused.Location = new Point(6, 72);
      chbxConditionsUnused.Name = "chbxConditionsUnused";
      chbxConditionsUnused.Size = new System.Drawing.Size(66, 19);
      chbxConditionsUnused.TabIndex = 6;
      chbxConditionsUnused.Text = "Unused";
      chbxConditionsUnused.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsCrazy
      // 
      chbxConditionsCrazy.AutoSize = true;
      chbxConditionsCrazy.Font = new Font("Segoe UI", 9F);
      chbxConditionsCrazy.Location = new Point(78, 72);
      chbxConditionsCrazy.Name = "chbxConditionsCrazy";
      chbxConditionsCrazy.Size = new System.Drawing.Size(55, 19);
      chbxConditionsCrazy.TabIndex = 4;
      chbxConditionsCrazy.Text = "Crazy";
      chbxConditionsCrazy.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsNone
      // 
      chbxConditionsNone.AutoSize = true;
      chbxConditionsNone.Font = new Font("Segoe UI", 9F);
      chbxConditionsNone.Location = new Point(6, 22);
      chbxConditionsNone.Name = "chbxConditionsNone";
      chbxConditionsNone.Size = new System.Drawing.Size(55, 19);
      chbxConditionsNone.TabIndex = 0;
      chbxConditionsNone.Text = "None";
      chbxConditionsNone.UseVisualStyleBackColor = true;
      // 
      // chbxConditionsIrritated
      // 
      chbxConditionsIrritated.AutoSize = true;
      chbxConditionsIrritated.Font = new Font("Segoe UI", 9F);
      chbxConditionsIrritated.Location = new Point(324, 22);
      chbxConditionsIrritated.Name = "chbxConditionsIrritated";
      chbxConditionsIrritated.Size = new System.Drawing.Size(67, 19);
      chbxConditionsIrritated.TabIndex = 1;
      chbxConditionsIrritated.Text = "Irritated";
      chbxConditionsIrritated.UseVisualStyleBackColor = true;
      // 
      // grbxEquipment
      // 
      grbxEquipment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      grbxEquipment.Controls.Add(dgvEquipment);
      grbxEquipment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxEquipment.Location = new Point(509, 317);
      grbxEquipment.Name = "grbxEquipment";
      grbxEquipment.Size = new System.Drawing.Size(443, 354);
      grbxEquipment.TabIndex = 45;
      grbxEquipment.TabStop = false;
      grbxEquipment.Text = "Equipment";
      // 
      // dgvEquipment
      // 
      dgvEquipment.AllowUserToAddRows = false;
      dgvEquipment.AllowUserToDeleteRows = false;
      dgvEquipment.AllowUserToResizeRows = false;
      dgvEquipment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvEquipment.Dock = DockStyle.Fill;
      dgvEquipment.Location = new Point(3, 19);
      dgvEquipment.MultiSelect = false;
      dgvEquipment.Name = "dgvEquipment";
      dgvEquipment.RowHeadersVisible = false;
      dgvEquipment.SelectionMode = DataGridViewSelectionMode.CellSelect;
      dgvEquipment.Size = new System.Drawing.Size(437, 332);
      dgvEquipment.TabIndex = 0;
      // 
      // grbxItems
      // 
      grbxItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      grbxItems.Controls.Add(dgvItems);
      grbxItems.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxItems.Location = new Point(961, 317);
      grbxItems.Name = "grbxItems";
      grbxItems.Size = new System.Drawing.Size(443, 354);
      grbxItems.TabIndex = 46;
      grbxItems.TabStop = false;
      grbxItems.Text = "Items";
      // 
      // dgvItems
      // 
      dgvItems.AllowUserToAddRows = false;
      dgvItems.AllowUserToDeleteRows = false;
      dgvItems.AllowUserToResizeRows = false;
      dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = SystemColors.Window;
      dataGridViewCellStyle3.Font = new Font("Segoe UI", 8F);
      dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
      dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
      dgvItems.DefaultCellStyle = dataGridViewCellStyle3;
      dgvItems.Dock = DockStyle.Fill;
      dgvItems.Location = new Point(3, 19);
      dgvItems.MultiSelect = false;
      dgvItems.Name = "dgvItems";
      dgvItems.RowHeadersVisible = false;
      dgvItems.SelectionMode = DataGridViewSelectionMode.CellSelect;
      dgvItems.Size = new System.Drawing.Size(437, 332);
      dgvItems.TabIndex = 0;
      // 
      // grbxBonusSpellDamage
      // 
      grbxBonusSpellDamage.Controls.Add(nudBonusSpellDamageReduction);
      grbxBonusSpellDamage.Controls.Add(nudBonusSpellDamagePercentage);
      grbxBonusSpellDamage.Controls.Add(nudBonusSpellDamageBase);
      grbxBonusSpellDamage.Controls.Add(nudBonusSpellDamageMax);
      grbxBonusSpellDamage.Controls.Add(label12);
      grbxBonusSpellDamage.Controls.Add(label13);
      grbxBonusSpellDamage.Controls.Add(label37);
      grbxBonusSpellDamage.Controls.Add(label14);
      grbxBonusSpellDamage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxBonusSpellDamage.Location = new Point(341, 270);
      grbxBonusSpellDamage.Name = "grbxBonusSpellDamage";
      grbxBonusSpellDamage.Size = new System.Drawing.Size(162, 145);
      grbxBonusSpellDamage.TabIndex = 47;
      grbxBonusSpellDamage.TabStop = false;
      grbxBonusSpellDamage.Text = "Bonus Spell Damage";
      // 
      // nudBonusSpellDamageReduction
      // 
      nudBonusSpellDamageReduction.Font = new Font("Segoe UI", 9F);
      nudBonusSpellDamageReduction.Location = new Point(78, 109);
      nudBonusSpellDamageReduction.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudBonusSpellDamageReduction.Name = "nudBonusSpellDamageReduction";
      nudBonusSpellDamageReduction.Size = new System.Drawing.Size(44, 23);
      nudBonusSpellDamageReduction.TabIndex = 50;
      // 
      // nudBonusSpellDamagePercentage
      // 
      nudBonusSpellDamagePercentage.Font = new Font("Segoe UI", 9F);
      nudBonusSpellDamagePercentage.Location = new Point(78, 80);
      nudBonusSpellDamagePercentage.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudBonusSpellDamagePercentage.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
      nudBonusSpellDamagePercentage.Name = "nudBonusSpellDamagePercentage";
      nudBonusSpellDamagePercentage.Size = new System.Drawing.Size(44, 23);
      nudBonusSpellDamagePercentage.TabIndex = 49;
      // 
      // nudBonusSpellDamageBase
      // 
      nudBonusSpellDamageBase.Font = new Font("Segoe UI", 9F);
      nudBonusSpellDamageBase.Location = new Point(78, 22);
      nudBonusSpellDamageBase.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudBonusSpellDamageBase.Name = "nudBonusSpellDamageBase";
      nudBonusSpellDamageBase.Size = new System.Drawing.Size(44, 23);
      nudBonusSpellDamageBase.TabIndex = 48;
      // 
      // nudBonusSpellDamageMax
      // 
      nudBonusSpellDamageMax.Font = new Font("Segoe UI", 9F);
      nudBonusSpellDamageMax.Location = new Point(78, 51);
      nudBonusSpellDamageMax.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
      nudBonusSpellDamageMax.Name = "nudBonusSpellDamageMax";
      nudBonusSpellDamageMax.Size = new System.Drawing.Size(44, 23);
      nudBonusSpellDamageMax.TabIndex = 47;
      // 
      // label12
      // 
      label12.AutoSize = true;
      label12.Font = new Font("Segoe UI", 9F);
      label12.Location = new Point(6, 53);
      label12.Name = "label12";
      label12.Size = new System.Drawing.Size(30, 15);
      label12.TabIndex = 48;
      label12.Text = "Max";
      // 
      // label13
      // 
      label13.AutoSize = true;
      label13.Font = new Font("Segoe UI", 9F);
      label13.Location = new Point(6, 111);
      label13.Name = "label13";
      label13.Size = new System.Drawing.Size(61, 15);
      label13.TabIndex = 45;
      label13.Text = "Reduction";
      // 
      // label37
      // 
      label37.AutoSize = true;
      label37.Font = new Font("Segoe UI", 9F);
      label37.Location = new Point(6, 24);
      label37.Name = "label37";
      label37.Size = new System.Drawing.Size(31, 15);
      label37.TabIndex = 34;
      label37.Text = "Base";
      // 
      // label14
      // 
      label14.AutoSize = true;
      label14.Font = new Font("Segoe UI", 9F);
      label14.Location = new Point(6, 82);
      label14.Name = "label14";
      label14.Size = new System.Drawing.Size(66, 15);
      label14.TabIndex = 43;
      label14.Text = "Percentage";
      // 
      // EditMonsterForm
      // 
      AcceptButton = btnOK;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = btnCancel;
      ClientSize = new System.Drawing.Size(1414, 712);
      Controls.Add(grbxBonusSpellDamage);
      Controls.Add(lblIndex);
      Controls.Add(tbxIndex);
      Controls.Add(grbxItems);
      Controls.Add(grbxEquipment);
      Controls.Add(grbxConditions);
      Controls.Add(grbxSpellImmunity);
      Controls.Add(grbxSpellMastery);
      Controls.Add(grbxDefense);
      Controls.Add(grbxSpellPoints);
      Controls.Add(grbxAttack);
      Controls.Add(grbxBattleFlags);
      Controls.Add(grbxGeneral);
      Controls.Add(grbxHitPoints);
      Controls.Add(grbxSkills);
      Controls.Add(grbxAttributes);
      Controls.Add(btnCancel);
      Controls.Add(btnOK);
      Controls.Add(statusStrip);
      DoubleBuffered = true;
      MinimumSize = new System.Drawing.Size(300, 150);
      Name = "EditMonsterForm";
      ShowIcon = false;
      Text = "Monster";
      grbxAttributes.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvAttributes).EndInit();
      grbxSkills.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvSkills).EndInit();
      grbxGeneral.ResumeLayout(false);
      grbxGeneral.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)nudDefeatExperience).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudFood).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudGold).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudLevel).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudMorale).EndInit();
      grbxBattleFlags.ResumeLayout(false);
      grbxBattleFlags.PerformLayout();
      grbxHitPoints.ResumeLayout(false);
      grbxHitPoints.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)nudHitPointsBonus).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudHitPointsCurrent).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudHitPointsMax).EndInit();
      grbxAttack.ResumeLayout(false);
      grbxAttack.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)nudAttackBonus).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudAttacksPerRound).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudAttackMagicLevel).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudAttackBase).EndInit();
      grbxSpellPoints.ResumeLayout(false);
      grbxSpellPoints.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)nudSpellPointsCurrent).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudSpellPointsBonus).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudSpellPointsMax).EndInit();
      grbxDefense.ResumeLayout(false);
      grbxDefense.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)nudDefenseBonus).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudDefenseMagicLevel).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudDefenseBase).EndInit();
      grbxSpellMastery.ResumeLayout(false);
      grbxSpellMastery.PerformLayout();
      grbxSpellImmunity.ResumeLayout(false);
      grbxSpellImmunity.PerformLayout();
      grbxConditions.ResumeLayout(false);
      grbxConditions.PerformLayout();
      grbxEquipment.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvEquipment).EndInit();
      grbxItems.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
      grbxBonusSpellDamage.ResumeLayout(false);
      grbxBonusSpellDamage.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageReduction).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamagePercentage).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageBase).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageMax).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox tbxName;
    private Button btnOK;
    private Button btnCancel;
    private TextBox tbxIndex;
    private Label lblIndex;
    private Label lblName;
    private StatusStrip statusStrip;
    private GroupBox grbxAttributes;
    private CustomDataGridView dgvAttributes;
    private GroupBox grbxSkills;
    private CustomDataGridView dgvSkills;
    private GroupBox grbxGeneral;
    private ComboBox cbxClass;
    private ComboBox cbxRace;
    private ComboBox cbxType;
    private NumericUpDown nudLevel;
    private NumericUpDown nudMorale;
    private NumericUpDown nudFood;
    private NumericUpDown nudGold;
    private Label label3;
    private Label label2;
    private Label label1;
    private ComboBox cbxGender;
    private Label label4;
    private Label label6;
    private Label label5;
    private Label label11;
    private Label label10;
    private GroupBox grbxBattleFlags;
    private CheckBox chbxBattleFlagsAnimal;
    private CheckBox chbxBattleFlagsBoss;
    private CheckBox chbxBattleFlagsDemon;
    private CheckBox chbxBattleFlagsNone;
    private CheckBox chbxBattleFlagsUndead;
    private CheckBox chbxBattleFlagsBonusFire;
    private CheckBox chbxBattleFlagsBonusWind;
    private CheckBox chbxBattleFlagsBonusEarth;
    private GroupBox grbxHitPoints;
    private Label label15;
    private Label label16;
    private NumericUpDown nudHitPointsMax;
    private Label label18;
    private GroupBox grbxAttack;
    private NumericUpDown nudAttackMagicLevel;
    private Label label23;
    private NumericUpDown nudAttackBase;
    private Label label26;
    private NumericUpDown nudAttacksPerRound;
    private Label label24;
    private GroupBox grbxSpellPoints;
    private NumericUpDown nudSpellPointsMax;
    private Label label17;
    private Label label19;
    private Label label20;
    private Label label25;
    private Label label29;
    private NumericUpDown nudDefeatExperience;
    private GroupBox grbxDefense;
    private NumericUpDown nudDefenseMagicLevel;
    private Label label31;
    private NumericUpDown nudDefenseBase;
    private Label label32;
    private Label label33;
    private ComboBox cbxElement;
    private Label label7;
    private GroupBox grbxSpellMastery;
    private CheckBox chbxSpellMasteryMystic;
    private CheckBox chbxSpellMasteryUnused1;
    private CheckBox chbxSpellMasteryUnused2;
    private CheckBox chbxSpellMasteryDestruction;
    private CheckBox chbxSpellMasteryHealing;
    private CheckBox chbxSpellMasteryAll;
    private CheckBox chbxSpellMasteryAlchemistic;
    private CheckBox chbxSpellMasteryNone;
    private CheckBox chbxSpellMasteryMastered;
    private CheckBox chbxSpellMasteryFunction;
    private GroupBox grbxSpellImmunity;
    private CheckBox chbxSpellImmunityUnused;
    private CheckBox chbxSpellImmunityFunction;
    private CheckBox chbxSpellImmunityMystic;
    private CheckBox chbxSpellImmunityUnused1;
    private CheckBox chbxSpellImmunityUnused2;
    private CheckBox chbxSpellImmunityDestruction;
    private CheckBox chbxSpellImmunityHealing;
    private CheckBox chbxSpellImmunityAlchemistic;
    private CheckBox chbxSpellImmunityNone;
    private GroupBox grbxConditions;
    private CheckBox chbxConditionsDrugged;
    private CheckBox chbxConditionsSleep;
    private CheckBox chbxConditionsBlind;
    private CheckBox chbxConditionsUnused;
    private CheckBox chbxConditionsLamed;
    private CheckBox chbxConditionsCrazy;
    private CheckBox chbxConditionsPanic;
    private CheckBox chbxConditionsExhausted;
    private CheckBox chbxConditionsIrritated;
    private CheckBox chbxConditionsNone;
    private CheckBox chbxConditionsDeadAshes;
    private CheckBox chbxConditionsDiseased;
    private CheckBox chbxConditionsDeadCorpse;
    private CheckBox chbxConditionsPetrified;
    private CheckBox chbxConditionsAging;
    private CheckBox chbxConditionsPoisoned;
    private CheckBox chbxConditionsDeadDust;
    private GroupBox grbxEquipment;
    private CustomDataGridView dgvEquipment;
    private GroupBox grbxItems;
    private CustomDataGridView dgvItems;
    private GroupBox grbxBonusSpellDamage;
    private NumericUpDown nudBonusSpellDamageMax;
    private Label label12;
    private Label label13;
    private Label label14;
    private Label label37;
    private NumericUpDown nudHitPointsBonus;
    private NumericUpDown nudHitPointsCurrent;
    private NumericUpDown nudSpellPointsCurrent;
    private NumericUpDown nudSpellPointsBonus;
    private NumericUpDown nudAttackBonus;
    private NumericUpDown nudDefenseBonus;
    private NumericUpDown nudBonusSpellDamageReduction;
    private NumericUpDown nudBonusSpellDamagePercentage;
    private NumericUpDown nudBonusSpellDamageBase;
  }
}