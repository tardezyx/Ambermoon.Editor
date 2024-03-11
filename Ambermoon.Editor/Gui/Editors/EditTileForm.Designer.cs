
namespace Ambermoon.Editor.Gui.Editors
{
	partial class EditTileForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTileForm));
			contextMenuImage = new ContextMenuStrip(components);
			toolStripMenuItemExportImage = new ToolStripMenuItem();
			numericUpDownImageIndex = new NumericUpDown();
			trackBarFrames = new TrackBar();
			checkBoxAlternate = new CheckBox();
			labelFrames = new Label();
			timerAnimation = new System.Windows.Forms.Timer(components);
			checkBoxBlockSight = new CheckBox();
			checkBoxBackgroundFlags = new CheckBox();
			checkBoxHidePlayer = new CheckBox();
			groupBoxAllowMovement = new GroupBox();
			checkBoxAllowSwim = new CheckBox();
			checkBoxAllowUnused15 = new CheckBox();
			checkBoxAllowUnused14 = new CheckBox();
			checkBoxAllowUnused13 = new CheckBox();
			checkBoxAllowWasp = new CheckBox();
			buttonFreeOut = new Button();
			checkBoxAllowSandShip = new CheckBox();
			buttonBlockOutdoor = new Button();
			checkBoxAllowSandLizard = new CheckBox();
			buttonBlockIndoor = new Button();
			checkBoxAllowBroom = new CheckBox();
			buttonSwim = new Button();
			checkBoxAllowFly = new CheckBox();
			buttonFreeIn = new Button();
			checkBoxAllowEagle = new CheckBox();
			checkBoxAllowMagicDisc = new CheckBox();
			checkBoxAllowShip = new CheckBox();
			checkBoxAllowRaft = new CheckBox();
			checkBoxAllowHorse = new CheckBox();
			checkBoxAllowWalk = new CheckBox();
			checkBoxBlockAllMovement = new CheckBox();
			buttonApply = new Button();
			buttonCancel = new Button();
			comboBoxSitSleep = new ComboBox();
			numericUpDownCombatBackground = new NumericUpDown();
			buttonShowCombatBackground = new Button();
			radioButtonNormal = new RadioButton();
			radioButtonAlwaysBelow = new RadioButton();
			radioButtonAlwaysAbove = new RadioButton();
			labelDraw = new Label();
			label1 = new Label();
			checkBoxRandomAnimation = new CheckBox();
			checkBoxAutoPoison = new CheckBox();
			panelCombatBackground = new DrawPanel();
			labelCombatBackground = new Label();
			contextMenuImage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownImageIndex).BeginInit();
			((System.ComponentModel.ISupportInitialize)trackBarFrames).BeginInit();
			groupBoxAllowMovement.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownCombatBackground).BeginInit();
			SuspendLayout();
			// 
			// contextMenuImage
			// 
			contextMenuImage.ImageScalingSize = new System.Drawing.Size(20, 20);
			contextMenuImage.Items.AddRange(new ToolStripItem[] { toolStripMenuItemExportImage });
			contextMenuImage.Name = "contextMenuImage";
			contextMenuImage.Size = new System.Drawing.Size(121, 26);
			// 
			// toolStripMenuItemExportImage
			// 
			toolStripMenuItemExportImage.Name = "toolStripMenuItemExportImage";
			toolStripMenuItemExportImage.Size = new System.Drawing.Size(120, 22);
			toolStripMenuItemExportImage.Text = "Export ...";
			toolStripMenuItemExportImage.Click += ToolStripMenuItemExportImage_Click;
			// 
			// numericUpDownImageIndex
			// 
			numericUpDownImageIndex.Location = new Point(54, 12);
			numericUpDownImageIndex.Maximum = new decimal(new int[] { 2500, 0, 0, 0 });
			numericUpDownImageIndex.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			numericUpDownImageIndex.Name = "numericUpDownImageIndex";
			numericUpDownImageIndex.Size = new System.Drawing.Size(44, 23);
			numericUpDownImageIndex.TabIndex = 1;
			numericUpDownImageIndex.TextAlign = HorizontalAlignment.Right;
			numericUpDownImageIndex.Value = new decimal(new int[] { 1, 0, 0, 0 });
			numericUpDownImageIndex.ValueChanged += NumericUpDownImageIndex_ValueChanged;
			// 
			// trackBarFrames
			// 
			trackBarFrames.Location = new Point(12, 69);
			trackBarFrames.Maximum = 16;
			trackBarFrames.Minimum = 1;
			trackBarFrames.Name = "trackBarFrames";
			trackBarFrames.Size = new System.Drawing.Size(139, 45);
			trackBarFrames.TabIndex = 2;
			trackBarFrames.Value = 1;
			trackBarFrames.ValueChanged += TrackBarFrames_ValueChanged;
			// 
			// checkBoxAlternate
			// 
			checkBoxAlternate.AutoSize = true;
			checkBoxAlternate.Location = new Point(75, 53);
			checkBoxAlternate.Name = "checkBoxAlternate";
			checkBoxAlternate.Size = new System.Drawing.Size(74, 19);
			checkBoxAlternate.TabIndex = 3;
			checkBoxAlternate.Text = "Alternate";
			checkBoxAlternate.UseVisualStyleBackColor = true;
			checkBoxAlternate.CheckedChanged += CheckBoxAlternate_CheckedChanged;
			// 
			// labelFrames
			// 
			labelFrames.AutoSize = true;
			labelFrames.Location = new Point(12, 54);
			labelFrames.Name = "labelFrames";
			labelFrames.Size = new System.Drawing.Size(57, 15);
			labelFrames.TabIndex = 4;
			labelFrames.Text = "Frames: 1";
			// 
			// timerAnimation
			// 
			timerAnimation.Interval = 166;
			timerAnimation.Tick += TimerAnimation_Tick;
			// 
			// checkBoxBlockSight
			// 
			checkBoxBlockSight.AutoSize = true;
			checkBoxBlockSight.Location = new Point(275, 8);
			checkBoxBlockSight.Name = "checkBoxBlockSight";
			checkBoxBlockSight.Size = new System.Drawing.Size(85, 19);
			checkBoxBlockSight.TabIndex = 5;
			checkBoxBlockSight.Text = "Block Sight";
			checkBoxBlockSight.UseVisualStyleBackColor = true;
			// 
			// checkBoxBackgroundFlags
			// 
			checkBoxBackgroundFlags.AutoSize = true;
			checkBoxBackgroundFlags.Location = new Point(160, 84);
			checkBoxBackgroundFlags.Name = "checkBoxBackgroundFlags";
			checkBoxBackgroundFlags.Size = new System.Drawing.Size(163, 19);
			checkBoxBackgroundFlags.TabIndex = 8;
			checkBoxBackgroundFlags.Text = "Use Background Tile Flags";
			checkBoxBackgroundFlags.UseVisualStyleBackColor = true;
			// 
			// checkBoxHidePlayer
			// 
			checkBoxHidePlayer.AutoSize = true;
			checkBoxHidePlayer.Location = new Point(275, 33);
			checkBoxHidePlayer.Name = "checkBoxHidePlayer";
			checkBoxHidePlayer.Size = new System.Drawing.Size(86, 19);
			checkBoxHidePlayer.TabIndex = 10;
			checkBoxHidePlayer.Text = "Hide Player";
			checkBoxHidePlayer.UseVisualStyleBackColor = true;
			// 
			// groupBoxAllowMovement
			// 
			groupBoxAllowMovement.Controls.Add(checkBoxAllowSwim);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowUnused15);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowUnused14);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowUnused13);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowWasp);
			groupBoxAllowMovement.Controls.Add(buttonFreeOut);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowSandShip);
			groupBoxAllowMovement.Controls.Add(buttonBlockOutdoor);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowSandLizard);
			groupBoxAllowMovement.Controls.Add(buttonBlockIndoor);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowBroom);
			groupBoxAllowMovement.Controls.Add(buttonSwim);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowFly);
			groupBoxAllowMovement.Controls.Add(buttonFreeIn);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowEagle);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowMagicDisc);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowShip);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowRaft);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowHorse);
			groupBoxAllowMovement.Controls.Add(checkBoxAllowWalk);
			groupBoxAllowMovement.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			groupBoxAllowMovement.Location = new Point(414, 8);
			groupBoxAllowMovement.Name = "groupBoxAllowMovement";
			groupBoxAllowMovement.Size = new System.Drawing.Size(445, 127);
			groupBoxAllowMovement.TabIndex = 11;
			groupBoxAllowMovement.TabStop = false;
			groupBoxAllowMovement.Text = "Allow Movement";
			// 
			// checkBoxAllowSwim
			// 
			checkBoxAllowSwim.AutoSize = true;
			checkBoxAllowSwim.Font = new Font("Segoe UI", 9F);
			checkBoxAllowSwim.Location = new Point(238, 98);
			checkBoxAllowSwim.Name = "checkBoxAllowSwim";
			checkBoxAllowSwim.Size = new System.Drawing.Size(55, 19);
			checkBoxAllowSwim.TabIndex = 28;
			checkBoxAllowSwim.Text = "Swim";
			checkBoxAllowSwim.UseVisualStyleBackColor = true;
			// 
			// checkBoxAllowUnused4
			// 
			checkBoxAllowUnused15.AutoSize = true;
			checkBoxAllowUnused15.Font = new Font("Segoe UI", 9F);
			checkBoxAllowUnused15.Location = new Point(378, 73);
			checkBoxAllowUnused15.Name = "checkBoxAllowUnused4";
			checkBoxAllowUnused15.Size = new System.Drawing.Size(66, 19);
			checkBoxAllowUnused15.TabIndex = 26;
			checkBoxAllowUnused15.Text = "Unused";
			checkBoxAllowUnused15.UseVisualStyleBackColor = true;
			// 
			// checkBoxAllowUnused3
			// 
			checkBoxAllowUnused14.AutoSize = true;
			checkBoxAllowUnused14.Font = new Font("Segoe UI", 9F);
			checkBoxAllowUnused14.Location = new Point(378, 48);
			checkBoxAllowUnused14.Name = "checkBoxAllowUnused3";
			checkBoxAllowUnused14.Size = new System.Drawing.Size(66, 19);
			checkBoxAllowUnused14.TabIndex = 25;
			checkBoxAllowUnused14.Text = "Unused";
			checkBoxAllowUnused14.UseVisualStyleBackColor = true;
			// 
			// checkBoxAllowUnused2
			// 
			checkBoxAllowUnused13.AutoSize = true;
			checkBoxAllowUnused13.Font = new Font("Segoe UI", 9F);
			checkBoxAllowUnused13.Location = new Point(378, 24);
			checkBoxAllowUnused13.Name = "checkBoxAllowUnused2";
			checkBoxAllowUnused13.Size = new System.Drawing.Size(66, 19);
			checkBoxAllowUnused13.TabIndex = 24;
			checkBoxAllowUnused13.Text = "Unused";
			checkBoxAllowUnused13.UseVisualStyleBackColor = true;
			// 
			// checkBoxAllowWasp
			// 
			checkBoxAllowWasp.AutoSize = true;
			checkBoxAllowWasp.Font = new Font("Segoe UI", 9F);
			checkBoxAllowWasp.Location = new Point(306, 98);
			checkBoxAllowWasp.Name = "checkBoxAllowWasp";
			checkBoxAllowWasp.Size = new System.Drawing.Size(55, 19);
			checkBoxAllowWasp.TabIndex = 23;
			checkBoxAllowWasp.Text = "Wasp";
			checkBoxAllowWasp.UseVisualStyleBackColor = true;
			// 
			// buttonFreeOut
			// 
			buttonFreeOut.Font = new Font("Segoe UI", 9F);
			buttonFreeOut.Location = new Point(6, 53);
			buttonFreeOut.Name = "buttonFreeOut";
			buttonFreeOut.Size = new System.Drawing.Size(81, 25);
			buttonFreeOut.TabIndex = 29;
			buttonFreeOut.Text = "Free Out";
			buttonFreeOut.TextAlign = ContentAlignment.MiddleLeft;
			buttonFreeOut.UseVisualStyleBackColor = true;
			buttonFreeOut.Click += ButtonFreeOut_Click;
			// 
			// checkBoxAllowSandShip
			// 
			checkBoxAllowSandShip.AutoSize = true;
			checkBoxAllowSandShip.Font = new Font("Segoe UI", 9F);
			checkBoxAllowSandShip.Location = new Point(306, 73);
			checkBoxAllowSandShip.Name = "checkBoxAllowSandShip";
			checkBoxAllowSandShip.Size = new System.Drawing.Size(60, 19);
			checkBoxAllowSandShip.TabIndex = 22;
			checkBoxAllowSandShip.Text = "S-Ship";
			checkBoxAllowSandShip.UseVisualStyleBackColor = true;
			// 
			// buttonBlockOutdoor
			// 
			buttonBlockOutdoor.Font = new Font("Segoe UI", 9F);
			buttonBlockOutdoor.Location = new Point(93, 53);
			buttonBlockOutdoor.Name = "buttonBlockOutdoor";
			buttonBlockOutdoor.Size = new System.Drawing.Size(81, 25);
			buttonBlockOutdoor.TabIndex = 28;
			buttonBlockOutdoor.Text = "Block Out";
			buttonBlockOutdoor.TextAlign = ContentAlignment.MiddleLeft;
			buttonBlockOutdoor.UseVisualStyleBackColor = true;
			buttonBlockOutdoor.Click += ButtonBlockOutdoor_Click;
			// 
			// checkBoxAllowSandLizard
			// 
			checkBoxAllowSandLizard.AutoSize = true;
			checkBoxAllowSandLizard.Font = new Font("Segoe UI", 9F);
			checkBoxAllowSandLizard.Location = new Point(306, 48);
			checkBoxAllowSandLizard.Name = "checkBoxAllowSandLizard";
			checkBoxAllowSandLizard.Size = new System.Drawing.Size(57, 19);
			checkBoxAllowSandLizard.TabIndex = 21;
			checkBoxAllowSandLizard.Text = "Lizard";
			checkBoxAllowSandLizard.UseVisualStyleBackColor = true;
			// 
			// buttonBlockIndoor
			// 
			buttonBlockIndoor.Font = new Font("Segoe UI", 9F);
			buttonBlockIndoor.Location = new Point(93, 22);
			buttonBlockIndoor.Name = "buttonBlockIndoor";
			buttonBlockIndoor.Size = new System.Drawing.Size(81, 25);
			buttonBlockIndoor.TabIndex = 27;
			buttonBlockIndoor.Text = "Block In";
			buttonBlockIndoor.TextAlign = ContentAlignment.MiddleLeft;
			buttonBlockIndoor.UseVisualStyleBackColor = true;
			buttonBlockIndoor.Click += ButtonBlockIndoor_Click;
			// 
			// checkBoxAllowBroom
			// 
			checkBoxAllowBroom.AutoSize = true;
			checkBoxAllowBroom.Font = new Font("Segoe UI", 9F);
			checkBoxAllowBroom.Location = new Point(306, 24);
			checkBoxAllowBroom.Name = "checkBoxAllowBroom";
			checkBoxAllowBroom.Size = new System.Drawing.Size(62, 19);
			checkBoxAllowBroom.TabIndex = 20;
			checkBoxAllowBroom.Text = "Broom";
			checkBoxAllowBroom.UseVisualStyleBackColor = true;
			// 
			// buttonSwim
			// 
			buttonSwim.Font = new Font("Segoe UI", 9F);
			buttonSwim.Location = new Point(6, 81);
			buttonSwim.Name = "buttonSwim";
			buttonSwim.Size = new System.Drawing.Size(81, 25);
			buttonSwim.TabIndex = 26;
			buttonSwim.Text = "Swim";
			buttonSwim.TextAlign = ContentAlignment.MiddleLeft;
			buttonSwim.UseVisualStyleBackColor = true;
			buttonSwim.Click += ButtonSwim_Click;
			// 
			// checkBoxAllowFly
			// 
			checkBoxAllowFly.AutoSize = true;
			checkBoxAllowFly.Font = new Font("Segoe UI", 9F);
			checkBoxAllowFly.Location = new Point(238, 73);
			checkBoxAllowFly.Name = "checkBoxAllowFly";
			checkBoxAllowFly.Size = new System.Drawing.Size(41, 19);
			checkBoxAllowFly.TabIndex = 19;
			checkBoxAllowFly.Text = "Fly";
			checkBoxAllowFly.UseVisualStyleBackColor = true;
			// 
			// buttonFreeIn
			// 
			buttonFreeIn.Font = new Font("Segoe UI", 9F);
			buttonFreeIn.Location = new Point(6, 22);
			buttonFreeIn.Name = "buttonFreeIn";
			buttonFreeIn.Size = new System.Drawing.Size(81, 25);
			buttonFreeIn.TabIndex = 25;
			buttonFreeIn.Text = "Free In";
			buttonFreeIn.TextAlign = ContentAlignment.MiddleLeft;
			buttonFreeIn.UseVisualStyleBackColor = true;
			buttonFreeIn.Click += ButtonFreeIn_Click;
			// 
			// checkBoxAllowEagle
			// 
			checkBoxAllowEagle.AutoSize = true;
			checkBoxAllowEagle.Font = new Font("Segoe UI", 9F);
			checkBoxAllowEagle.Location = new Point(238, 48);
			checkBoxAllowEagle.Name = "checkBoxAllowEagle";
			checkBoxAllowEagle.Size = new System.Drawing.Size(54, 19);
			checkBoxAllowEagle.TabIndex = 18;
			checkBoxAllowEagle.Text = "Eagle";
			checkBoxAllowEagle.UseVisualStyleBackColor = true;
			// 
			// checkBoxAllowMagicDisc
			// 
			checkBoxAllowMagicDisc.AutoSize = true;
			checkBoxAllowMagicDisc.Font = new Font("Segoe UI", 9F);
			checkBoxAllowMagicDisc.Location = new Point(238, 24);
			checkBoxAllowMagicDisc.Name = "checkBoxAllowMagicDisc";
			checkBoxAllowMagicDisc.Size = new System.Drawing.Size(48, 19);
			checkBoxAllowMagicDisc.TabIndex = 17;
			checkBoxAllowMagicDisc.Text = "Disc";
			checkBoxAllowMagicDisc.UseVisualStyleBackColor = true;
			// 
			// checkBoxAllowShip
			// 
			checkBoxAllowShip.AutoSize = true;
			checkBoxAllowShip.Font = new Font("Segoe UI", 9F);
			checkBoxAllowShip.Location = new Point(180, 98);
			checkBoxAllowShip.Name = "checkBoxAllowShip";
			checkBoxAllowShip.Size = new System.Drawing.Size(49, 19);
			checkBoxAllowShip.TabIndex = 16;
			checkBoxAllowShip.Text = "Ship";
			checkBoxAllowShip.UseVisualStyleBackColor = true;
			// 
			// checkBoxAllowRaft
			// 
			checkBoxAllowRaft.AutoSize = true;
			checkBoxAllowRaft.Font = new Font("Segoe UI", 9F);
			checkBoxAllowRaft.Location = new Point(180, 73);
			checkBoxAllowRaft.Name = "checkBoxAllowRaft";
			checkBoxAllowRaft.Size = new System.Drawing.Size(47, 19);
			checkBoxAllowRaft.TabIndex = 15;
			checkBoxAllowRaft.Text = "Raft";
			checkBoxAllowRaft.UseVisualStyleBackColor = true;
			// 
			// checkBoxAllowHorse
			// 
			checkBoxAllowHorse.AutoSize = true;
			checkBoxAllowHorse.Font = new Font("Segoe UI", 9F);
			checkBoxAllowHorse.Location = new Point(180, 48);
			checkBoxAllowHorse.Name = "checkBoxAllowHorse";
			checkBoxAllowHorse.Size = new System.Drawing.Size(57, 19);
			checkBoxAllowHorse.TabIndex = 14;
			checkBoxAllowHorse.Text = "Horse";
			checkBoxAllowHorse.UseVisualStyleBackColor = true;
			// 
			// checkBoxAllowWalk
			// 
			checkBoxAllowWalk.AutoSize = true;
			checkBoxAllowWalk.Font = new Font("Segoe UI", 9F);
			checkBoxAllowWalk.Location = new Point(180, 24);
			checkBoxAllowWalk.Name = "checkBoxAllowWalk";
			checkBoxAllowWalk.Size = new System.Drawing.Size(52, 19);
			checkBoxAllowWalk.TabIndex = 13;
			checkBoxAllowWalk.Text = "Walk";
			checkBoxAllowWalk.UseVisualStyleBackColor = true;
			// 
			// checkBoxBlockAllMovement
			// 
			checkBoxBlockAllMovement.AutoSize = true;
			checkBoxBlockAllMovement.Location = new Point(275, 59);
			checkBoxBlockAllMovement.Name = "checkBoxBlockAllMovement";
			checkBoxBlockAllMovement.Size = new System.Drawing.Size(133, 19);
			checkBoxBlockAllMovement.TabIndex = 12;
			checkBoxBlockAllMovement.Text = "Block All Movement";
			checkBoxBlockAllMovement.UseVisualStyleBackColor = true;
			checkBoxBlockAllMovement.CheckedChanged += CheckBoxBlockAllMovement_CheckedChanged;
			// 
			// buttonApply
			// 
			buttonApply.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonApply.Location = new Point(722, 296);
			buttonApply.Name = "buttonApply";
			buttonApply.Size = new System.Drawing.Size(68, 25);
			buttonApply.TabIndex = 13;
			buttonApply.Text = "Apply";
			buttonApply.UseVisualStyleBackColor = true;
			buttonApply.Click += ButtonApply_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.DialogResult = DialogResult.Cancel;
			buttonCancel.Location = new Point(793, 296);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(68, 25);
			buttonCancel.TabIndex = 14;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			// 
			// comboBoxSitSleep
			// 
			comboBoxSitSleep.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxSitSleep.FormattingEnabled = true;
			comboBoxSitSleep.Items.AddRange(new object[] { "Normal", "SitLookUp", "SitLookRight", "SitLookDown", "SitLookLeft", "Sleep" });
			comboBoxSitSleep.Location = new Point(160, 109);
			comboBoxSitSleep.Name = "comboBoxSitSleep";
			comboBoxSitSleep.Size = new System.Drawing.Size(100, 23);
			comboBoxSitSleep.TabIndex = 15;
			// 
			// numericUpDownCombatBackground
			// 
			numericUpDownCombatBackground.Hexadecimal = true;
			numericUpDownCombatBackground.Location = new Point(139, 142);
			numericUpDownCombatBackground.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
			numericUpDownCombatBackground.Name = "numericUpDownCombatBackground";
			numericUpDownCombatBackground.Size = new System.Drawing.Size(30, 23);
			numericUpDownCombatBackground.TabIndex = 16;
			numericUpDownCombatBackground.TextAlign = HorizontalAlignment.Center;
			numericUpDownCombatBackground.ValueChanged += NumericUpDownCombatBackground_ValueChanged;
			// 
			// buttonShowCombatBackground
			// 
			buttonShowCombatBackground.Location = new Point(170, 141);
			buttonShowCombatBackground.Name = "buttonShowCombatBackground";
			buttonShowCombatBackground.Size = new System.Drawing.Size(46, 25);
			buttonShowCombatBackground.TabIndex = 18;
			buttonShowCombatBackground.Text = "Show";
			buttonShowCombatBackground.UseVisualStyleBackColor = true;
			// 
			// radioButtonNormal
			// 
			radioButtonNormal.AutoSize = true;
			radioButtonNormal.Checked = true;
			radioButtonNormal.Location = new Point(160, 7);
			radioButtonNormal.Name = "radioButtonNormal";
			radioButtonNormal.Size = new System.Drawing.Size(65, 19);
			radioButtonNormal.TabIndex = 19;
			radioButtonNormal.TabStop = true;
			radioButtonNormal.Text = "Normal";
			radioButtonNormal.UseVisualStyleBackColor = true;
			// 
			// radioButtonAlwaysBelow
			// 
			radioButtonAlwaysBelow.AutoSize = true;
			radioButtonAlwaysBelow.Location = new Point(160, 32);
			radioButtonAlwaysBelow.Name = "radioButtonAlwaysBelow";
			radioButtonAlwaysBelow.Size = new System.Drawing.Size(97, 19);
			radioButtonAlwaysBelow.TabIndex = 20;
			radioButtonAlwaysBelow.Text = "Always Below";
			radioButtonAlwaysBelow.UseVisualStyleBackColor = true;
			// 
			// radioButtonAlwaysAbove
			// 
			radioButtonAlwaysAbove.AutoSize = true;
			radioButtonAlwaysAbove.Location = new Point(160, 58);
			radioButtonAlwaysAbove.Name = "radioButtonAlwaysAbove";
			radioButtonAlwaysAbove.Size = new System.Drawing.Size(99, 19);
			radioButtonAlwaysAbove.TabIndex = 21;
			radioButtonAlwaysAbove.Text = "Always Above";
			radioButtonAlwaysAbove.UseVisualStyleBackColor = true;
			// 
			// labelDraw
			// 
			labelDraw.AutoSize = true;
			labelDraw.Location = new Point(120, 8);
			labelDraw.Name = "labelDraw";
			labelDraw.Size = new System.Drawing.Size(37, 15);
			labelDraw.TabIndex = 22;
			labelDraw.Text = "Draw:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(51, 36);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(71, 15);
			label1.TabIndex = 24;
			label1.Text = "Minimap ->";
			// 
			// checkBoxRandomAnimation
			// 
			checkBoxRandomAnimation.AutoSize = true;
			checkBoxRandomAnimation.Location = new Point(12, 99);
			checkBoxRandomAnimation.Name = "checkBoxRandomAnimation";
			checkBoxRandomAnimation.Size = new System.Drawing.Size(103, 19);
			checkBoxRandomAnimation.TabIndex = 31;
			checkBoxRandomAnimation.Text = "Random Anim";
			checkBoxRandomAnimation.UseVisualStyleBackColor = true;
			checkBoxRandomAnimation.CheckedChanged += CheckBoxRandomAnimationStart_CheckedChanged;
			// 
			// checkBoxAutoPoison
			// 
			checkBoxAutoPoison.AutoSize = true;
			checkBoxAutoPoison.Location = new Point(12, 116);
			checkBoxAutoPoison.Name = "checkBoxAutoPoison";
			checkBoxAutoPoison.Size = new System.Drawing.Size(91, 19);
			checkBoxAutoPoison.TabIndex = 32;
			checkBoxAutoPoison.Text = "Auto Poison";
			checkBoxAutoPoison.UseVisualStyleBackColor = true;
			// 
			// panelCombatBackground
			// 
			panelCombatBackground.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelCombatBackground.Location = new Point(12, 172);
			panelCombatBackground.Name = "panelCombatBackground";
			panelCombatBackground.Size = new System.Drawing.Size(849, 118);
			panelCombatBackground.TabIndex = 33;
			// 
			// labelCombatBackground
			// 
			labelCombatBackground.AutoSize = true;
			labelCombatBackground.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			labelCombatBackground.Location = new Point(12, 146);
			labelCombatBackground.Name = "labelCombatBackground";
			labelCombatBackground.Size = new System.Drawing.Size(123, 15);
			labelCombatBackground.TabIndex = 34;
			labelCombatBackground.Text = "Combat Background:";
			// 
			// EditTileForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(873, 333);
			Controls.Add(labelCombatBackground);
			Controls.Add(panelCombatBackground);
			Controls.Add(checkBoxAutoPoison);
			Controls.Add(checkBoxRandomAnimation);
			Controls.Add(label1);
			Controls.Add(labelDraw);
			Controls.Add(radioButtonAlwaysAbove);
			Controls.Add(radioButtonAlwaysBelow);
			Controls.Add(radioButtonNormal);
			Controls.Add(buttonShowCombatBackground);
			Controls.Add(numericUpDownCombatBackground);
			Controls.Add(comboBoxSitSleep);
			Controls.Add(buttonCancel);
			Controls.Add(buttonApply);
			Controls.Add(checkBoxBlockAllMovement);
			Controls.Add(groupBoxAllowMovement);
			Controls.Add(checkBoxHidePlayer);
			Controls.Add(checkBoxBackgroundFlags);
			Controls.Add(checkBoxBlockSight);
			Controls.Add(labelFrames);
			Controls.Add(checkBoxAlternate);
			Controls.Add(trackBarFrames);
			Controls.Add(numericUpDownImageIndex);
			DoubleBuffered = true;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MinimumSize = new System.Drawing.Size(889, 372);
			Name = "EditTileForm";
			Text = "Edit Tile";
			contextMenuImage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)numericUpDownImageIndex).EndInit();
			((System.ComponentModel.ISupportInitialize)trackBarFrames).EndInit();
			groupBoxAllowMovement.ResumeLayout(false);
			groupBoxAllowMovement.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownCombatBackground).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.DrawPanel panelImage;
		private System.Windows.Forms.NumericUpDown numericUpDownImageIndex;
		private System.Windows.Forms.TrackBar trackBarFrames;
		private System.Windows.Forms.CheckBox checkBoxAlternate;
		private System.Windows.Forms.Label labelFrames;
		private System.Windows.Forms.Timer timerAnimation;
		private System.Windows.Forms.CheckBox checkBoxBlockSight;
		private System.Windows.Forms.CheckBox checkBoxBackgroundFlags;
		private System.Windows.Forms.CheckBox checkBoxHidePlayer;
		private System.Windows.Forms.GroupBox groupBoxAllowMovement;
		private System.Windows.Forms.CheckBox checkBoxAllowRaft;
		private System.Windows.Forms.CheckBox checkBoxAllowHorse;
		private System.Windows.Forms.CheckBox checkBoxAllowWalk;
		private System.Windows.Forms.CheckBox checkBoxBlockAllMovement;
		private System.Windows.Forms.CheckBox checkBoxAllowMagicDisc;
		private System.Windows.Forms.CheckBox checkBoxAllowShip;
		private System.Windows.Forms.CheckBox checkBoxAllowEagle;
		private System.Windows.Forms.CheckBox checkBoxAllowFly;
		private System.Windows.Forms.CheckBox checkBoxAllowBroom;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.CheckBox checkBoxAllowSandLizard;
		private System.Windows.Forms.CheckBox checkBoxAllowSandShip;
		private System.Windows.Forms.CheckBox checkBoxAllowWasp;
		private System.Windows.Forms.CheckBox checkBoxAllowUnused15;
		private System.Windows.Forms.CheckBox checkBoxAllowUnused14;
		private System.Windows.Forms.CheckBox checkBoxAllowUnused13;
		private System.Windows.Forms.CheckBox checkBoxAllowSwim;
		private System.Windows.Forms.ComboBox comboBoxSitSleep;
		private System.Windows.Forms.NumericUpDown numericUpDownCombatBackground;
		private System.Windows.Forms.Button buttonShowCombatBackground;
		private System.Windows.Forms.RadioButton radioButtonNormal;
		private System.Windows.Forms.RadioButton radioButtonAlwaysBelow;
		private System.Windows.Forms.RadioButton radioButtonAlwaysAbove;
		private System.Windows.Forms.Label labelDraw;
		private System.Windows.Forms.DrawPanel drawPanelColor;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip contextMenuImage;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportImage;
		private System.Windows.Forms.Button buttonFreeIn;
		private System.Windows.Forms.Button buttonSwim;
		private System.Windows.Forms.Button buttonBlockIndoor;
		private System.Windows.Forms.Button buttonBlockOutdoor;
		private System.Windows.Forms.Button buttonFreeOut;
		private System.Windows.Forms.CheckBox checkBoxRandomAnimation;
		private System.Windows.Forms.CheckBox checkBoxAutoPoison;
		private DrawPanel panelCombatBackground;
		private Label labelCombatBackground;
	}
}