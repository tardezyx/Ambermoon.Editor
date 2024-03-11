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
      nudFood = new NumericUpDown();
      label11 = new Label();
      label4 = new Label();
      label10 = new Label();
      nudGold = new NumericUpDown();
      nudMorale = new NumericUpDown();
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
      nudLevel = new NumericUpDown();
      cbxClass = new ComboBox();
      cbxRace = new ComboBox();
      cbxType = new ComboBox();
      chbxZoom = new CheckBox();
      label8 = new Label();
      nudCombatBackgroundIndex = new NumericUpDown();
      pbxCombatGraphic = new ExtendedPictureBox();
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
      pbxEquipmentLeftFinger = new ExtendedPictureBox();
      pbxEquipmentFeet = new ExtendedPictureBox();
      pbxEquipmentRightFinger = new ExtendedPictureBox();
      pbxEquipmentLeftHand = new ExtendedPictureBox();
      pbxEquipmentBody = new ExtendedPictureBox();
      pbxEquipmentRightHand = new ExtendedPictureBox();
      pbxEquipmentChest = new ExtendedPictureBox();
      pbxEquipmentHead = new ExtendedPictureBox();
      pbxEquipmentNeck = new ExtendedPictureBox();
      extendedPictureBox1 = new ExtendedPictureBox();
      grbxItems = new GroupBox();
      pbxEquipmentItem1 = new ExtendedPictureBox();
      extendedPictureBox2 = new ExtendedPictureBox();
      grbxBonusSpellDamage = new GroupBox();
      nudBonusSpellDamageReduction = new NumericUpDown();
      nudBonusSpellDamagePercentage = new NumericUpDown();
      nudBonusSpellDamageBase = new NumericUpDown();
      nudBonusSpellDamageMax = new NumericUpDown();
      label12 = new Label();
      label13 = new Label();
      label37 = new Label();
      label14 = new Label();
      grbxSpells = new GroupBox();
      btnAddSpell = new Button();
      dgvSpells = new CustomDataGridView();
      grbxCombatGraphic = new GroupBox();
      nudFPS = new NumericUpDown();
      label27 = new Label();
      nudPaletteIndex = new NumericUpDown();
      nudCombatGraphicIndex = new NumericUpDown();
      label22 = new Label();
      label9 = new Label();
      label21 = new Label();
      cbxCombatBackgroundDaytime = new ComboBox();
      grbxAttributes.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvAttributes).BeginInit();
      grbxSkills.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvSkills).BeginInit();
      grbxGeneral.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nudFood).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudGold).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudMorale).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudDefeatExperience).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudLevel).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudCombatBackgroundIndex).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pbxCombatGraphic).BeginInit();
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
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentLeftFinger).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentFeet).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentRightFinger).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentLeftHand).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentBody).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentRightHand).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentChest).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentHead).BeginInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentNeck).BeginInit();
      ((System.ComponentModel.ISupportInitialize)extendedPictureBox1).BeginInit();
      grbxItems.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentItem1).BeginInit();
      ((System.ComponentModel.ISupportInitialize)extendedPictureBox2).BeginInit();
      grbxBonusSpellDamage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageReduction).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamagePercentage).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageBase).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageMax).BeginInit();
      grbxSpells.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvSpells).BeginInit();
      grbxCombatGraphic.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)nudFPS).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudPaletteIndex).BeginInit();
      ((System.ComponentModel.ISupportInitialize)nudCombatGraphicIndex).BeginInit();
      SuspendLayout();
      // 
      // tbxName
      // 
      tbxName.CharacterCasing = CharacterCasing.Upper;
      tbxName.Font = new Font("Segoe UI", 9F);
      tbxName.Location = new Point(61, 22);
      tbxName.MaxLength = 150;
      tbxName.Name = "tbxName";
      tbxName.Size = new System.Drawing.Size(119, 23);
      tbxName.TabIndex = 0;
      // 
      // btnOK
      // 
      btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnOK.Location = new Point(1364, 594);
      btnOK.Name = "btnOK";
      btnOK.Size = new System.Drawing.Size(75, 23);
      btnOK.TabIndex = 1;
      btnOK.Text = "OK";
      btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnCancel.Location = new Point(1445, 594);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 2;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // tbxIndex
      // 
      tbxIndex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      tbxIndex.Enabled = false;
      tbxIndex.Location = new Point(57, 595);
      tbxIndex.Name = "tbxIndex";
      tbxIndex.ReadOnly = true;
      tbxIndex.Size = new System.Drawing.Size(45, 23);
      tbxIndex.TabIndex = 3;
      // 
      // lblIndex
      // 
      lblIndex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lblIndex.AutoSize = true;
      lblIndex.Location = new Point(12, 598);
      lblIndex.Name = "lblIndex";
      lblIndex.Size = new System.Drawing.Size(36, 15);
      lblIndex.TabIndex = 4;
      lblIndex.Text = "Index";
      // 
      // lblName
      // 
      lblName.AutoSize = true;
      lblName.Font = new Font("Segoe UI", 9F);
      lblName.Location = new Point(5, 25);
      lblName.Name = "lblName";
      lblName.Size = new System.Drawing.Size(39, 15);
      lblName.TabIndex = 5;
      lblName.Text = "Name";
      // 
      // statusStrip
      // 
      statusStrip.BackColor = Color.Transparent;
      statusStrip.Location = new Point(0, 607);
      statusStrip.Name = "statusStrip";
      statusStrip.Size = new System.Drawing.Size(1532, 22);
      statusStrip.TabIndex = 6;
      statusStrip.Text = "statusStrip1";
      // 
      // grbxAttributes
      // 
      grbxAttributes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      grbxAttributes.Controls.Add(dgvAttributes);
      grbxAttributes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxAttributes.Location = new Point(874, 295);
      grbxAttributes.Name = "grbxAttributes";
      grbxAttributes.Size = new System.Drawing.Size(318, 292);
      grbxAttributes.TabIndex = 7;
      grbxAttributes.TabStop = false;
      grbxAttributes.Text = "Attributes";
      // 
      // dgvAttributes
      // 
      dgvAttributes.AllowUserToAddRows = false;
      dgvAttributes.AllowUserToDeleteRows = false;
      dgvAttributes.AllowUserToResizeRows = false;
      dgvAttributes.BackgroundColor = SystemColors.Control;
      dgvAttributes.BorderStyle = BorderStyle.None;
      dgvAttributes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvAttributes.Dock = DockStyle.Fill;
      dgvAttributes.EnableHeadersVisualStyles = false;
      dgvAttributes.Font = new Font("Segoe UI", 8F);
      dgvAttributes.Location = new Point(3, 19);
      dgvAttributes.MultiSelect = false;
      dgvAttributes.Name = "dgvAttributes";
      dgvAttributes.RowHeadersVisible = false;
      dgvAttributes.RowTemplate.Resizable = DataGridViewTriState.False;
      dgvAttributes.SelectionMode = DataGridViewSelectionMode.CellSelect;
      dgvAttributes.Size = new System.Drawing.Size(312, 270);
      dgvAttributes.TabIndex = 0;
      // 
      // grbxSkills
      // 
      grbxSkills.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      grbxSkills.Controls.Add(dgvSkills);
      grbxSkills.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxSkills.Location = new Point(1198, 295);
      grbxSkills.Name = "grbxSkills";
      grbxSkills.Size = new System.Drawing.Size(319, 292);
      grbxSkills.TabIndex = 8;
      grbxSkills.TabStop = false;
      grbxSkills.Text = "Skills";
      // 
      // dgvSkills
      // 
      dgvSkills.AllowUserToAddRows = false;
      dgvSkills.AllowUserToDeleteRows = false;
      dgvSkills.AllowUserToResizeRows = false;
      dgvSkills.BackgroundColor = SystemColors.Control;
      dgvSkills.BorderStyle = BorderStyle.None;
      dgvSkills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvSkills.Dock = DockStyle.Fill;
      dgvSkills.EnableHeadersVisualStyles = false;
      dgvSkills.Font = new Font("Segoe UI", 8F);
      dgvSkills.Location = new Point(3, 19);
      dgvSkills.MultiSelect = false;
      dgvSkills.Name = "dgvSkills";
      dgvSkills.RowHeadersVisible = false;
      dgvSkills.RowTemplate.Resizable = DataGridViewTriState.False;
      dgvSkills.SelectionMode = DataGridViewSelectionMode.CellSelect;
      dgvSkills.Size = new System.Drawing.Size(313, 270);
      dgvSkills.TabIndex = 0;
      // 
      // grbxGeneral
      // 
      grbxGeneral.Controls.Add(nudFood);
      grbxGeneral.Controls.Add(label11);
      grbxGeneral.Controls.Add(label4);
      grbxGeneral.Controls.Add(label10);
      grbxGeneral.Controls.Add(nudGold);
      grbxGeneral.Controls.Add(nudMorale);
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
      grbxGeneral.Controls.Add(nudLevel);
      grbxGeneral.Controls.Add(cbxClass);
      grbxGeneral.Controls.Add(cbxRace);
      grbxGeneral.Controls.Add(cbxType);
      grbxGeneral.Controls.Add(lblName);
      grbxGeneral.Controls.Add(tbxName);
      grbxGeneral.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxGeneral.Location = new Point(12, 12);
      grbxGeneral.Name = "grbxGeneral";
      grbxGeneral.Size = new System.Drawing.Size(491, 143);
      grbxGeneral.TabIndex = 9;
      grbxGeneral.TabStop = false;
      grbxGeneral.Text = "General";
      // 
      // nudFood
      // 
      nudFood.Font = new Font("Segoe UI", 9F);
      nudFood.Location = new Point(390, 110);
      nudFood.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
      nudFood.Name = "nudFood";
      nudFood.Size = new System.Drawing.Size(54, 23);
      nudFood.TabIndex = 13;
      nudFood.Value = new decimal(new int[] { 9999, 0, 0, 0 });
      // 
      // label11
      // 
      label11.AutoSize = true;
      label11.Font = new Font("Segoe UI", 9F);
      label11.Location = new Point(340, 112);
      label11.Name = "label11";
      label11.Size = new System.Drawing.Size(34, 15);
      label11.TabIndex = 26;
      label11.Text = "Food";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Font = new Font("Segoe UI", 9F);
      label4.Location = new Point(340, 54);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(44, 15);
      label4.TabIndex = 19;
      label4.Text = "Morale";
      // 
      // label10
      // 
      label10.AutoSize = true;
      label10.Font = new Font("Segoe UI", 9F);
      label10.Location = new Point(340, 83);
      label10.Name = "label10";
      label10.Size = new System.Drawing.Size(32, 15);
      label10.TabIndex = 25;
      label10.Text = "Gold";
      // 
      // nudGold
      // 
      nudGold.Font = new Font("Segoe UI", 9F);
      nudGold.Location = new Point(390, 80);
      nudGold.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
      nudGold.Name = "nudGold";
      nudGold.Size = new System.Drawing.Size(54, 23);
      nudGold.TabIndex = 12;
      nudGold.Value = new decimal(new int[] { 65535, 0, 0, 0 });
      // 
      // nudMorale
      // 
      nudMorale.Font = new Font("Segoe UI", 9F);
      nudMorale.Location = new Point(390, 51);
      nudMorale.Name = "nudMorale";
      nudMorale.Size = new System.Drawing.Size(54, 23);
      nudMorale.TabIndex = 3;
      nudMorale.Value = new decimal(new int[] { 100, 0, 0, 0 });
      // 
      // cbxElement
      // 
      cbxElement.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxElement.Font = new Font("Segoe UI", 9F);
      cbxElement.FormattingEnabled = true;
      cbxElement.Location = new Point(61, 109);
      cbxElement.Name = "cbxElement";
      cbxElement.Size = new System.Drawing.Size(119, 23);
      cbxElement.TabIndex = 41;
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Font = new Font("Segoe UI", 9F);
      label7.Location = new Point(5, 112);
      label7.Name = "label7";
      label7.Size = new System.Drawing.Size(50, 15);
      label7.TabIndex = 40;
      label7.Text = "Element";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Font = new Font("Segoe UI", 9F);
      label6.Location = new Point(186, 83);
      label6.Name = "label6";
      label6.Size = new System.Drawing.Size(34, 15);
      label6.TabIndex = 21;
      label6.Text = "Level";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Font = new Font("Segoe UI", 9F);
      label5.Location = new Point(5, 83);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(34, 15);
      label5.TabIndex = 20;
      label5.Text = "Class";
      // 
      // label29
      // 
      label29.AutoSize = true;
      label29.Font = new Font("Segoe UI", 9F);
      label29.Location = new Point(186, 112);
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
      cbxGender.Location = new Point(250, 51);
      cbxGender.Name = "cbxGender";
      cbxGender.Size = new System.Drawing.Size(84, 23);
      cbxGender.TabIndex = 18;
      // 
      // nudDefeatExperience
      // 
      nudDefeatExperience.Font = new Font("Segoe UI", 9F);
      nudDefeatExperience.Location = new Point(250, 110);
      nudDefeatExperience.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
      nudDefeatExperience.Name = "nudDefeatExperience";
      nudDefeatExperience.Size = new System.Drawing.Size(82, 23);
      nudDefeatExperience.TabIndex = 37;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new Font("Segoe UI", 9F);
      label3.Location = new Point(186, 54);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(45, 15);
      label3.TabIndex = 17;
      label3.Text = "Gender";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 9F);
      label2.Location = new Point(5, 54);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(32, 15);
      label2.TabIndex = 16;
      label2.Text = "Race";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 9F);
      label1.Location = new Point(186, 25);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(31, 15);
      label1.TabIndex = 15;
      label1.Text = "Type";
      // 
      // nudLevel
      // 
      nudLevel.Font = new Font("Segoe UI", 9F);
      nudLevel.Location = new Point(250, 80);
      nudLevel.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
      nudLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      nudLevel.Name = "nudLevel";
      nudLevel.Size = new System.Drawing.Size(42, 23);
      nudLevel.TabIndex = 10;
      nudLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
      // 
      // cbxClass
      // 
      cbxClass.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxClass.Font = new Font("Segoe UI", 9F);
      cbxClass.FormattingEnabled = true;
      cbxClass.Location = new Point(61, 80);
      cbxClass.Name = "cbxClass";
      cbxClass.Size = new System.Drawing.Size(119, 23);
      cbxClass.TabIndex = 2;
      // 
      // cbxRace
      // 
      cbxRace.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxRace.Font = new Font("Segoe UI", 9F);
      cbxRace.FormattingEnabled = true;
      cbxRace.Location = new Point(61, 51);
      cbxRace.Name = "cbxRace";
      cbxRace.Size = new System.Drawing.Size(119, 23);
      cbxRace.TabIndex = 1;
      // 
      // cbxType
      // 
      cbxType.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxType.Enabled = false;
      cbxType.Font = new Font("Segoe UI", 9F);
      cbxType.FormattingEnabled = true;
      cbxType.Location = new Point(250, 22);
      cbxType.Name = "cbxType";
      cbxType.Size = new System.Drawing.Size(84, 23);
      cbxType.TabIndex = 0;
      // 
      // chbxZoom
      // 
      chbxZoom.AutoSize = true;
      chbxZoom.Font = new Font("Segoe UI", 9F);
      chbxZoom.Location = new Point(226, 132);
      chbxZoom.Name = "chbxZoom";
      chbxZoom.Size = new System.Drawing.Size(58, 19);
      chbxZoom.TabIndex = 50;
      chbxZoom.Text = "Zoom";
      chbxZoom.UseVisualStyleBackColor = true;
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Font = new Font("Segoe UI", 9F);
      label8.Location = new Point(6, 163);
      label8.Name = "label8";
      label8.Size = new System.Drawing.Size(71, 15);
      label8.TabIndex = 51;
      label8.Text = "Background";
      // 
      // nudCombatBackgroundIndex
      // 
      nudCombatBackgroundIndex.Font = new Font("Segoe UI", 9F);
      nudCombatBackgroundIndex.Location = new Point(83, 161);
      nudCombatBackgroundIndex.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
      nudCombatBackgroundIndex.Name = "nudCombatBackgroundIndex";
      nudCombatBackgroundIndex.Size = new System.Drawing.Size(37, 23);
      nudCombatBackgroundIndex.TabIndex = 50;
      // 
      // pbxCombatGraphic
      // 
      pbxCombatGraphic.BackColor = Color.Black;
      pbxCombatGraphic.BackgroundImageLayout = ImageLayout.Zoom;
      pbxCombatGraphic.Location = new Point(6, 22);
      pbxCombatGraphic.Name = "pbxCombatGraphic";
      pbxCombatGraphic.Size = new System.Drawing.Size(347, 103);
      pbxCombatGraphic.SizeMode = PictureBoxSizeMode.CenterImage;
      pbxCombatGraphic.TabIndex = 49;
      pbxCombatGraphic.TabStop = false;
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
      grbxBattleFlags.Location = new Point(262, 161);
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
      grbxHitPoints.Location = new Point(12, 161);
      grbxHitPoints.Name = "grbxHitPoints";
      grbxHitPoints.Size = new System.Drawing.Size(119, 108);
      grbxHitPoints.TabIndex = 11;
      grbxHitPoints.TabStop = false;
      grbxHitPoints.Text = "Hit Points";
      // 
      // nudHitPointsBonus
      // 
      nudHitPointsBonus.Enabled = false;
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
      nudHitPointsCurrent.Enabled = false;
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
      nudHitPointsMax.Value = new decimal(new int[] { 9999, 0, 0, 0 });
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
      grbxAttack.Location = new Point(12, 275);
      grbxAttack.Name = "grbxAttack";
      grbxAttack.Size = new System.Drawing.Size(171, 145);
      grbxAttack.TabIndex = 34;
      grbxAttack.TabStop = false;
      grbxAttack.Text = "Attack";
      // 
      // nudAttackBonus
      // 
      nudAttackBonus.Enabled = false;
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
      nudAttacksPerRound.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
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
      grbxSpellPoints.Location = new Point(137, 161);
      grbxSpellPoints.Name = "grbxSpellPoints";
      grbxSpellPoints.Size = new System.Drawing.Size(119, 108);
      grbxSpellPoints.TabIndex = 36;
      grbxSpellPoints.TabStop = false;
      grbxSpellPoints.Text = "Spell Points";
      // 
      // nudSpellPointsCurrent
      // 
      nudSpellPointsCurrent.Enabled = false;
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
      nudSpellPointsBonus.Enabled = false;
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
      grbxDefense.Location = new Point(189, 275);
      grbxDefense.Name = "grbxDefense";
      grbxDefense.Size = new System.Drawing.Size(146, 145);
      grbxDefense.TabIndex = 39;
      grbxDefense.TabStop = false;
      grbxDefense.Text = "Defense";
      // 
      // nudDefenseBonus
      // 
      nudDefenseBonus.Enabled = false;
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
      grbxSpellMastery.Location = new Point(509, 211);
      grbxSpellMastery.Name = "grbxSpellMastery";
      grbxSpellMastery.Size = new System.Drawing.Size(178, 153);
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
      grbxSpellImmunity.Location = new Point(690, 211);
      grbxSpellImmunity.Name = "grbxSpellImmunity";
      grbxSpellImmunity.Size = new System.Drawing.Size(178, 153);
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
      grbxConditions.Location = new Point(12, 426);
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
      grbxEquipment.Controls.Add(pbxEquipmentLeftFinger);
      grbxEquipment.Controls.Add(pbxEquipmentFeet);
      grbxEquipment.Controls.Add(pbxEquipmentRightFinger);
      grbxEquipment.Controls.Add(pbxEquipmentLeftHand);
      grbxEquipment.Controls.Add(pbxEquipmentBody);
      grbxEquipment.Controls.Add(pbxEquipmentRightHand);
      grbxEquipment.Controls.Add(pbxEquipmentChest);
      grbxEquipment.Controls.Add(pbxEquipmentHead);
      grbxEquipment.Controls.Add(pbxEquipmentNeck);
      grbxEquipment.Controls.Add(extendedPictureBox1);
      grbxEquipment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxEquipment.Location = new Point(874, 12);
      grbxEquipment.Name = "grbxEquipment";
      grbxEquipment.Size = new System.Drawing.Size(318, 277);
      grbxEquipment.TabIndex = 45;
      grbxEquipment.TabStop = false;
      grbxEquipment.Text = "Equipment";
      // 
      // pbxEquipmentLeftFinger
      // 
      pbxEquipmentLeftFinger.Location = new Point(193, 230);
      pbxEquipmentLeftFinger.Name = "pbxEquipmentLeftFinger";
      pbxEquipmentLeftFinger.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentLeftFinger.TabIndex = 56;
      pbxEquipmentLeftFinger.TabStop = false;
      // 
      // pbxEquipmentFeet
      // 
      pbxEquipmentFeet.Location = new Point(145, 230);
      pbxEquipmentFeet.Name = "pbxEquipmentFeet";
      pbxEquipmentFeet.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentFeet.TabIndex = 55;
      pbxEquipmentFeet.TabStop = false;
      // 
      // pbxEquipmentRightFinger
      // 
      pbxEquipmentRightFinger.Location = new Point(97, 230);
      pbxEquipmentRightFinger.Name = "pbxEquipmentRightFinger";
      pbxEquipmentRightFinger.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentRightFinger.TabIndex = 54;
      pbxEquipmentRightFinger.TabStop = false;
      // 
      // pbxEquipmentLeftHand
      // 
      pbxEquipmentLeftHand.Location = new Point(193, 152);
      pbxEquipmentLeftHand.Name = "pbxEquipmentLeftHand";
      pbxEquipmentLeftHand.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentLeftHand.TabIndex = 53;
      pbxEquipmentLeftHand.TabStop = false;
      // 
      // pbxEquipmentBody
      // 
      pbxEquipmentBody.Location = new Point(193, 112);
      pbxEquipmentBody.Name = "pbxEquipmentBody";
      pbxEquipmentBody.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentBody.TabIndex = 52;
      pbxEquipmentBody.TabStop = false;
      // 
      // pbxEquipmentRightHand
      // 
      pbxEquipmentRightHand.Location = new Point(97, 152);
      pbxEquipmentRightHand.Name = "pbxEquipmentRightHand";
      pbxEquipmentRightHand.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentRightHand.TabIndex = 51;
      pbxEquipmentRightHand.TabStop = false;
      // 
      // pbxEquipmentChest
      // 
      pbxEquipmentChest.Location = new Point(193, 75);
      pbxEquipmentChest.Name = "pbxEquipmentChest";
      pbxEquipmentChest.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentChest.TabIndex = 51;
      pbxEquipmentChest.TabStop = false;
      // 
      // pbxEquipmentHead
      // 
      pbxEquipmentHead.Location = new Point(145, 75);
      pbxEquipmentHead.Name = "pbxEquipmentHead";
      pbxEquipmentHead.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentHead.TabIndex = 51;
      pbxEquipmentHead.TabStop = false;
      // 
      // pbxEquipmentNeck
      // 
      pbxEquipmentNeck.Location = new Point(97, 75);
      pbxEquipmentNeck.Name = "pbxEquipmentNeck";
      pbxEquipmentNeck.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentNeck.TabIndex = 50;
      pbxEquipmentNeck.TabStop = false;
      // 
      // extendedPictureBox1
      // 
      extendedPictureBox1.BackgroundImage = Properties.Resources.background_equipment;
      extendedPictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
      extendedPictureBox1.Location = new Point(6, 22);
      extendedPictureBox1.Name = "extendedPictureBox1";
      extendedPictureBox1.Size = new System.Drawing.Size(303, 245);
      extendedPictureBox1.TabIndex = 0;
      extendedPictureBox1.TabStop = false;
      // 
      // grbxItems
      // 
      grbxItems.Controls.Add(pbxEquipmentItem1);
      grbxItems.Controls.Add(extendedPictureBox2);
      grbxItems.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxItems.Location = new Point(1198, 12);
      grbxItems.Name = "grbxItems";
      grbxItems.Size = new System.Drawing.Size(319, 277);
      grbxItems.TabIndex = 46;
      grbxItems.TabStop = false;
      grbxItems.Text = "Items";
      // 
      // pbxEquipmentItem1
      // 
      pbxEquipmentItem1.Location = new Point(50, 79);
      pbxEquipmentItem1.Name = "pbxEquipmentItem1";
      pbxEquipmentItem1.Size = new System.Drawing.Size(24, 24);
      pbxEquipmentItem1.TabIndex = 51;
      pbxEquipmentItem1.TabStop = false;
      // 
      // extendedPictureBox2
      // 
      extendedPictureBox2.BackgroundImage = Properties.Resources.background_items;
      extendedPictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
      extendedPictureBox2.Location = new Point(6, 22);
      extendedPictureBox2.Name = "extendedPictureBox2";
      extendedPictureBox2.Size = new System.Drawing.Size(303, 245);
      extendedPictureBox2.TabIndex = 1;
      extendedPictureBox2.TabStop = false;
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
      grbxBonusSpellDamage.Location = new Point(341, 273);
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
      nudBonusSpellDamagePercentage.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
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
      // grbxSpells
      // 
      grbxSpells.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      grbxSpells.Controls.Add(btnAddSpell);
      grbxSpells.Controls.Add(dgvSpells);
      grbxSpells.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxSpells.Location = new Point(509, 370);
      grbxSpells.Name = "grbxSpells";
      grbxSpells.Size = new System.Drawing.Size(359, 217);
      grbxSpells.TabIndex = 48;
      grbxSpells.TabStop = false;
      grbxSpells.Text = "Spells";
      // 
      // btnAddSpell
      // 
      btnAddSpell.Font = new Font("Segoe UI", 9F);
      btnAddSpell.Location = new Point(6, 22);
      btnAddSpell.Name = "btnAddSpell";
      btnAddSpell.Size = new System.Drawing.Size(75, 23);
      btnAddSpell.TabIndex = 49;
      btnAddSpell.Text = "Add Spell";
      btnAddSpell.UseVisualStyleBackColor = true;
      // 
      // dgvSpells
      // 
      dgvSpells.AllowUserToAddRows = false;
      dgvSpells.AllowUserToDeleteRows = false;
      dgvSpells.AllowUserToResizeRows = false;
      dgvSpells.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dgvSpells.BackgroundColor = SystemColors.Control;
      dgvSpells.BorderStyle = BorderStyle.None;
      dgvSpells.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvSpells.EnableHeadersVisualStyles = false;
      dgvSpells.Font = new Font("Segoe UI", 8F);
      dgvSpells.Location = new Point(3, 51);
      dgvSpells.MultiSelect = false;
      dgvSpells.Name = "dgvSpells";
      dgvSpells.RowHeadersVisible = false;
      dgvSpells.RowTemplate.Resizable = DataGridViewTriState.False;
      dgvSpells.SelectionMode = DataGridViewSelectionMode.CellSelect;
      dgvSpells.Size = new System.Drawing.Size(353, 159);
      dgvSpells.TabIndex = 0;
      // 
      // grbxCombatGraphic
      // 
      grbxCombatGraphic.Controls.Add(nudFPS);
      grbxCombatGraphic.Controls.Add(label27);
      grbxCombatGraphic.Controls.Add(nudPaletteIndex);
      grbxCombatGraphic.Controls.Add(nudCombatGraphicIndex);
      grbxCombatGraphic.Controls.Add(chbxZoom);
      grbxCombatGraphic.Controls.Add(label22);
      grbxCombatGraphic.Controls.Add(label9);
      grbxCombatGraphic.Controls.Add(pbxCombatGraphic);
      grbxCombatGraphic.Controls.Add(label21);
      grbxCombatGraphic.Controls.Add(label8);
      grbxCombatGraphic.Controls.Add(nudCombatBackgroundIndex);
      grbxCombatGraphic.Controls.Add(cbxCombatBackgroundDaytime);
      grbxCombatGraphic.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxCombatGraphic.Location = new Point(509, 12);
      grbxCombatGraphic.Name = "grbxCombatGraphic";
      grbxCombatGraphic.Size = new System.Drawing.Size(359, 193);
      grbxCombatGraphic.TabIndex = 49;
      grbxCombatGraphic.TabStop = false;
      grbxCombatGraphic.Text = "Combat Graphic";
      // 
      // nudFPS
      // 
      nudFPS.Font = new Font("Segoe UI", 9F);
      nudFPS.Location = new Point(183, 131);
      nudFPS.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
      nudFPS.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      nudFPS.Name = "nudFPS";
      nudFPS.Size = new System.Drawing.Size(37, 23);
      nudFPS.TabIndex = 54;
      nudFPS.Value = new decimal(new int[] { 8, 0, 0, 0 });
      // 
      // label27
      // 
      label27.AutoSize = true;
      label27.Font = new Font("Segoe UI", 9F);
      label27.Location = new Point(126, 133);
      label27.Name = "label27";
      label27.Size = new System.Drawing.Size(26, 15);
      label27.TabIndex = 55;
      label27.Text = "FPS";
      // 
      // nudPaletteIndex
      // 
      nudPaletteIndex.Enabled = false;
      nudPaletteIndex.Font = new Font("Segoe UI", 9F);
      nudPaletteIndex.Location = new Point(305, 160);
      nudPaletteIndex.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
      nudPaletteIndex.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      nudPaletteIndex.Name = "nudPaletteIndex";
      nudPaletteIndex.ReadOnly = true;
      nudPaletteIndex.Size = new System.Drawing.Size(37, 23);
      nudPaletteIndex.TabIndex = 52;
      nudPaletteIndex.Value = new decimal(new int[] { 9, 0, 0, 0 });
      // 
      // nudCombatGraphicIndex
      // 
      nudCombatGraphicIndex.Font = new Font("Segoe UI", 9F);
      nudCombatGraphicIndex.Location = new Point(83, 131);
      nudCombatGraphicIndex.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
      nudCombatGraphicIndex.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
      nudCombatGraphicIndex.Name = "nudCombatGraphicIndex";
      nudCombatGraphicIndex.Size = new System.Drawing.Size(37, 23);
      nudCombatGraphicIndex.TabIndex = 51;
      nudCombatGraphicIndex.Value = new decimal(new int[] { 9, 0, 0, 0 });
      // 
      // label22
      // 
      label22.AutoSize = true;
      label22.Font = new Font("Segoe UI", 9F);
      label22.Location = new Point(261, 163);
      label22.Name = "label22";
      label22.Size = new System.Drawing.Size(43, 15);
      label22.TabIndex = 53;
      label22.Text = "Palette";
      // 
      // label9
      // 
      label9.AutoSize = true;
      label9.Font = new Font("Segoe UI", 9F);
      label9.Location = new Point(6, 133);
      label9.Name = "label9";
      label9.Size = new System.Drawing.Size(48, 15);
      label9.TabIndex = 52;
      label9.Text = "Graphic";
      // 
      // label21
      // 
      label21.AutoSize = true;
      label21.Font = new Font("Segoe UI", 9F);
      label21.Location = new Point(126, 163);
      label21.Name = "label21";
      label21.Size = new System.Drawing.Size(51, 15);
      label21.TabIndex = 53;
      label21.Text = "Daytime";
      // 
      // cbxCombatBackgroundDaytime
      // 
      cbxCombatBackgroundDaytime.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxCombatBackgroundDaytime.Font = new Font("Segoe UI", 9F);
      cbxCombatBackgroundDaytime.FormattingEnabled = true;
      cbxCombatBackgroundDaytime.Location = new Point(183, 160);
      cbxCombatBackgroundDaytime.Name = "cbxCombatBackgroundDaytime";
      cbxCombatBackgroundDaytime.Size = new System.Drawing.Size(72, 23);
      cbxCombatBackgroundDaytime.TabIndex = 50;
      // 
      // EditMonsterForm
      // 
      AcceptButton = btnOK;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = btnCancel;
      ClientSize = new System.Drawing.Size(1532, 629);
      Controls.Add(grbxCombatGraphic);
      Controls.Add(grbxSpells);
      Controls.Add(grbxAttributes);
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
      Controls.Add(btnCancel);
      Controls.Add(btnOK);
      Controls.Add(statusStrip);
      DoubleBuffered = true;
      MinimumSize = new System.Drawing.Size(1548, 668);
      Name = "EditMonsterForm";
      Text = "Monster";
      grbxAttributes.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvAttributes).EndInit();
      grbxSkills.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvSkills).EndInit();
      grbxGeneral.ResumeLayout(false);
      grbxGeneral.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)nudFood).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudGold).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudMorale).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudDefeatExperience).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudLevel).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudCombatBackgroundIndex).EndInit();
      ((System.ComponentModel.ISupportInitialize)pbxCombatGraphic).EndInit();
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
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentLeftFinger).EndInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentFeet).EndInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentRightFinger).EndInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentLeftHand).EndInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentBody).EndInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentRightHand).EndInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentChest).EndInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentHead).EndInit();
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentNeck).EndInit();
      ((System.ComponentModel.ISupportInitialize)extendedPictureBox1).EndInit();
      grbxItems.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)pbxEquipmentItem1).EndInit();
      ((System.ComponentModel.ISupportInitialize)extendedPictureBox2).EndInit();
      grbxBonusSpellDamage.ResumeLayout(false);
      grbxBonusSpellDamage.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageReduction).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamagePercentage).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageBase).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudBonusSpellDamageMax).EndInit();
      grbxSpells.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)dgvSpells).EndInit();
      grbxCombatGraphic.ResumeLayout(false);
      grbxCombatGraphic.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)nudFPS).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudPaletteIndex).EndInit();
      ((System.ComponentModel.ISupportInitialize)nudCombatGraphicIndex).EndInit();
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
    private GroupBox grbxItems;
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
    private GroupBox grbxSpells;
    private CustomDataGridView dgvSpells;
    private Button btnAddSpell;
    private ExtendedPictureBox pbxCombatGraphic;
    private GroupBox grbxCombatGraphic;
    private Label label8;
    private NumericUpDown nudCombatBackgroundIndex;
    private ComboBox cbxCombatBackgroundDaytime;
    private Label label9;
    private NumericUpDown nudCombatGraphicIndex;
    private Label label21;
    private NumericUpDown nudPaletteIndex;
    private Label label22;
    private CheckBox chbxZoom;
    private ExtendedPictureBox extendedPictureBox1;
    private ExtendedPictureBox extendedPictureBox2;
    private ExtendedPictureBox pbxEquipmentNeck;
    private NumericUpDown nudFPS;
    private Label label27;
    private ExtendedPictureBox pbxEquipmentLeftFinger;
    private ExtendedPictureBox pbxEquipmentFeet;
    private ExtendedPictureBox pbxEquipmentRightFinger;
    private ExtendedPictureBox pbxEquipmentLeftHand;
    private ExtendedPictureBox pbxEquipmentBody;
    private ExtendedPictureBox pbxEquipmentRightHand;
    private ExtendedPictureBox pbxEquipmentChest;
    private ExtendedPictureBox pbxEquipmentHead;
    private ExtendedPictureBox pbxEquipmentItem1;
  }
}