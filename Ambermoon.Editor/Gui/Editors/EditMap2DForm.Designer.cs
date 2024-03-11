
using Ambermoon.Editor.Gui.Custom;

namespace Ambermoon.Editor.Gui.Editors {
  partial class EditMap2DForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMap2DForm));
			panelMap = new MapDrawPanel();
			menuStrip = new MenuStrip();
			toolStripMenuItemMap = new ToolStripMenuItem();
			toolStripMenuItemMapSave = new ToolStripMenuItem();
			toolStripMenuItemMapSaveAs = new ToolStripMenuItem();
			toolStripMenuItemMapSaveAsPNG = new ToolStripMenuItem();
			toolStripSeparatorMap1 = new ToolStripSeparator();
			toolStripMenuItemMapQuit = new ToolStripMenuItem();
			toolStripMenuItemEdit = new ToolStripMenuItem();
			toolStripMenuItemEditUndo = new ToolStripMenuItem();
			toolStripMenuItemEditRedo = new ToolStripMenuItem();
			toolStripSeparatorEdit1 = new ToolStripSeparator();
			groupBoxTileset = new GroupBox();
			checkBoxMarkUnusedTiles = new CheckBox();
			buttonEditTile = new Button();
			comboBoxPalettes = new ComboBox();
			comboBoxTilesets = new ComboBox();
			buttonDuplicateTile = new Button();
			panelTileset = new ScrollDrawPanel();
			groupBoxProperties = new GroupBox();
			comboBoxWorld = new ComboBox();
			labelSizeCross = new Label();
			numericUpDownHeight = new NumericUpDown();
			labelSize = new Label();
			numericUpDownWidth = new NumericUpDown();
			buttonResize = new Button();
			buttonToggleMusic = new Button();
			comboBoxMusic = new ComboBox();
			labelMusic = new Label();
			checkBoxWorldSurface = new CheckBox();
			checkBoxMagic = new CheckBox();
			buttonIndoorDefaults = new Button();
			buttonWorldMapDefaults = new Button();
			checkBoxTravelGraphics = new CheckBox();
			checkBoxNoSleepUntilDawn = new CheckBox();
			checkBoxUnknown1 = new CheckBox();
			checkBoxResting = new CheckBox();
			radioButtonDungeon = new RadioButton();
			radioButtonOutdoor = new RadioButton();
			radioButtonIndoor = new RadioButton();
			toolTipIndoor = new ToolTip(components);
			toolTipOutdoor = new ToolTip(components);
			toolTipDungeon = new ToolTip(components);
			toolTipResting = new ToolTip(components);
			toolTipNoSleepUntilDawn = new ToolTip(components);
			toolTipMagic = new ToolTip(components);
			toolTipWorldSurface = new ToolTip(components);
			groupBoxCharacters = new GroupBox();
			buttonPositions = new Button();
			mapCharEditorControl = new EditMapCharControl();
			buttonPlaceCharacterOnMap = new Button();
			labelCharacterPosition = new Label();
			buttonToolBrush = new Button();
			buttonToolColorPicker = new Button();
			buttonToolLayers = new Button();
			contextMenuStripLayers = new ContextMenuStrip(components);
			toolStripMenuItemBackLayer = new ToolStripMenuItem();
			toolStripMenuItemFrontLayer = new ToolStripMenuItem();
			toolStripSeparatorLayers1 = new ToolStripSeparator();
			toolStripMenuItemShowBackLayer = new ToolStripMenuItem();
			toolStripMenuItemShowFrontLayer = new ToolStripMenuItem();
			toolStripMenuShowAllowWalk = new ToolStripMenuItem();
			toolStripMenuShowAllowHorse = new ToolStripMenuItem();
			toolStripMenuShowAllowDisc = new ToolStripMenuItem();
			toolStripMenuShowAllowRaft = new ToolStripMenuItem();
			toolStripMenuShowAllowShip = new ToolStripMenuItem();
			statusStrip = new StatusStrip();
			toolStripStatusLabelTool = new ToolStripStatusLabel();
			toolStripStatusLabelLayer = new ToolStripStatusLabel();
			toolStripStatusLabelCurrentTile = new ToolStripStatusLabel();
			toolStripStatusLabelCurrentTilesetTile = new ToolStripStatusLabel();
			buttonToolBlocks = new Button();
			contextMenuStripBlockModes = new ContextMenuStrip(components);
			toolStripMenuItemBlocks2x2 = new ToolStripMenuItem();
			toolStripMenuItemBlocks3x2 = new ToolStripMenuItem();
			toolStripMenuItemBlocks3x3 = new ToolStripMenuItem();
			buttonToolFill = new Button();
			buttonToggleGrid = new Button();
			toolTipBrush = new ToolTip(components);
			toolTipBlocks = new ToolTip(components);
			toolTipFill = new ToolTip(components);
			toolTipColorPicker = new ToolTip(components);
			toolTipLayers = new ToolTip(components);
			toolTipGrid = new ToolTip(components);
			buttonToggleTileMarker = new Button();
			toolTipTileMarker = new ToolTip(components);
			labelDivider = new Label();
			buttonToolRemoveFrontLayer = new Button();
			toolTipRemoveFrontLayer = new ToolTip(components);
			groupBoxEvents = new GroupBox();
			listViewEvents = new ListView();
			columnHeaderEventId = new ColumnHeader();
			columnHeaderEventDescription = new ColumnHeader();
			buttonToggleEvents = new Button();
			timerAnimation = new System.Windows.Forms.Timer(components);
			trackBarZoom = new TrackBar();
			buttonToolEventChanger = new Button();
			menuStrip.SuspendLayout();
			groupBoxTileset.SuspendLayout();
			groupBoxProperties.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownHeight).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownWidth).BeginInit();
			groupBoxCharacters.SuspendLayout();
			contextMenuStripLayers.SuspendLayout();
			statusStrip.SuspendLayout();
			contextMenuStripBlockModes.SuspendLayout();
			groupBoxEvents.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)trackBarZoom).BeginInit();
			SuspendLayout();
			// 
			// panelMap
			// 
			panelMap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panelMap.BackColor = Color.Black;
			panelMap.BorderStyle = BorderStyle.Fixed3D;
			panelMap.Location = new Point(0, 27);
			panelMap.Margin = new Padding(2, 3, 2, 3);
			panelMap.Name = "panelMap";
			panelMap.Size = new System.Drawing.Size(817, 520);
			panelMap.TabIndex = 0;
			// 
			// menuStrip
			// 
			menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItemMap, toolStripMenuItemEdit });
			menuStrip.Location = new Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Size = new System.Drawing.Size(1197, 24);
			menuStrip.TabIndex = 1;
			menuStrip.Text = "menuStrip1";
			// 
			// toolStripMenuItemMap
			// 
			toolStripMenuItemMap.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemMapSave, toolStripMenuItemMapSaveAs, toolStripMenuItemMapSaveAsPNG, toolStripSeparatorMap1, toolStripMenuItemMapQuit });
			toolStripMenuItemMap.Name = "toolStripMenuItemMap";
			toolStripMenuItemMap.Size = new System.Drawing.Size(43, 20);
			toolStripMenuItemMap.Text = "&Map";
			// 
			// toolStripMenuItemMapSave
			// 
			toolStripMenuItemMapSave.Enabled = false;
			toolStripMenuItemMapSave.Name = "toolStripMenuItemMapSave";
			toolStripMenuItemMapSave.ShortcutKeys = Keys.Control | Keys.S;
			toolStripMenuItemMapSave.Size = new System.Drawing.Size(196, 22);
			toolStripMenuItemMapSave.Text = "Save";
			// 
			// toolStripMenuItemMapSaveAs
			// 
			toolStripMenuItemMapSaveAs.Name = "toolStripMenuItemMapSaveAs";
			toolStripMenuItemMapSaveAs.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
			toolStripMenuItemMapSaveAs.Size = new System.Drawing.Size(196, 22);
			toolStripMenuItemMapSaveAs.Text = "Save as ...";
			// 
			// toolStripMenuItemMapSaveAsPNG
			// 
			toolStripMenuItemMapSaveAsPNG.Name = "toolStripMenuItemMapSaveAsPNG";
			toolStripMenuItemMapSaveAsPNG.ShortcutKeys = Keys.Control | Keys.P;
			toolStripMenuItemMapSaveAsPNG.Size = new System.Drawing.Size(196, 22);
			toolStripMenuItemMapSaveAsPNG.Text = "Save as PNG";
			// 
			// toolStripSeparatorMap1
			// 
			toolStripSeparatorMap1.Name = "toolStripSeparatorMap1";
			toolStripSeparatorMap1.Size = new System.Drawing.Size(193, 6);
			// 
			// toolStripMenuItemMapQuit
			// 
			toolStripMenuItemMapQuit.Name = "toolStripMenuItemMapQuit";
			toolStripMenuItemMapQuit.ShortcutKeys = Keys.Alt | Keys.F4;
			toolStripMenuItemMapQuit.Size = new System.Drawing.Size(196, 22);
			toolStripMenuItemMapQuit.Text = "Quit";
			// 
			// toolStripMenuItemEdit
			// 
			toolStripMenuItemEdit.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemEditUndo, toolStripMenuItemEditRedo, toolStripSeparatorEdit1 });
			toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
			toolStripMenuItemEdit.Size = new System.Drawing.Size(39, 20);
			toolStripMenuItemEdit.Text = "&Edit";
			// 
			// toolStripMenuItemEditUndo
			// 
			toolStripMenuItemEditUndo.Enabled = false;
			toolStripMenuItemEditUndo.Name = "toolStripMenuItemEditUndo";
			toolStripMenuItemEditUndo.ShortcutKeys = Keys.Control | Keys.Z;
			toolStripMenuItemEditUndo.Size = new System.Drawing.Size(180, 22);
			toolStripMenuItemEditUndo.Text = "Undo";
			// 
			// toolStripMenuItemEditRedo
			// 
			toolStripMenuItemEditRedo.Enabled = false;
			toolStripMenuItemEditRedo.Name = "toolStripMenuItemEditRedo";
			toolStripMenuItemEditRedo.ShortcutKeys = Keys.Control | Keys.Y;
			toolStripMenuItemEditRedo.Size = new System.Drawing.Size(180, 22);
			toolStripMenuItemEditRedo.Text = "Redo";
			// 
			// toolStripSeparatorEdit1
			// 
			toolStripSeparatorEdit1.Name = "toolStripSeparatorEdit1";
			toolStripSeparatorEdit1.Size = new System.Drawing.Size(177, 6);
			// 
			// groupBoxTileset
			// 
			groupBoxTileset.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			groupBoxTileset.Controls.Add(checkBoxMarkUnusedTiles);
			groupBoxTileset.Controls.Add(buttonEditTile);
			groupBoxTileset.Controls.Add(comboBoxPalettes);
			groupBoxTileset.Controls.Add(comboBoxTilesets);
			groupBoxTileset.Controls.Add(buttonDuplicateTile);
			groupBoxTileset.Controls.Add(panelTileset);
			groupBoxTileset.Location = new Point(11, 553);
			groupBoxTileset.Margin = new Padding(2, 3, 2, 3);
			groupBoxTileset.Name = "groupBoxTileset";
			groupBoxTileset.Padding = new Padding(2, 3, 2, 3);
			groupBoxTileset.Size = new System.Drawing.Size(805, 177);
			groupBoxTileset.TabIndex = 2;
			groupBoxTileset.TabStop = false;
			groupBoxTileset.Text = "Tileset";
			// 
			// checkBoxMarkUnusedTiles
			// 
			checkBoxMarkUnusedTiles.AutoSize = true;
			checkBoxMarkUnusedTiles.Location = new Point(707, 73);
			checkBoxMarkUnusedTiles.Name = "checkBoxMarkUnusedTiles";
			checkBoxMarkUnusedTiles.Size = new System.Drawing.Size(95, 19);
			checkBoxMarkUnusedTiles.TabIndex = 6;
			checkBoxMarkUnusedTiles.Text = "Mark unused";
			checkBoxMarkUnusedTiles.UseVisualStyleBackColor = true;
			// 
			// buttonEditTile
			// 
			buttonEditTile.Location = new Point(707, 94);
			buttonEditTile.Margin = new Padding(2, 3, 2, 3);
			buttonEditTile.Name = "buttonEditTile";
			buttonEditTile.Size = new System.Drawing.Size(89, 24);
			buttonEditTile.TabIndex = 4;
			buttonEditTile.Text = "Edit tile ...";
			buttonEditTile.UseVisualStyleBackColor = true;
			// 
			// comboBoxPalettes
			// 
			comboBoxPalettes.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxPalettes.FormattingEnabled = true;
			comboBoxPalettes.Location = new Point(707, 47);
			comboBoxPalettes.Margin = new Padding(2, 3, 2, 3);
			comboBoxPalettes.Name = "comboBoxPalettes";
			comboBoxPalettes.Size = new System.Drawing.Size(89, 23);
			comboBoxPalettes.TabIndex = 3;
			// 
			// comboBoxTilesets
			// 
			comboBoxTilesets.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxTilesets.FormattingEnabled = true;
			comboBoxTilesets.Location = new Point(707, 21);
			comboBoxTilesets.Margin = new Padding(2, 3, 2, 3);
			comboBoxTilesets.Name = "comboBoxTilesets";
			comboBoxTilesets.Size = new System.Drawing.Size(89, 23);
			comboBoxTilesets.TabIndex = 2;
			// 
			// buttonDuplicateTile
			// 
			buttonDuplicateTile.Location = new Point(707, 121);
			buttonDuplicateTile.Margin = new Padding(2, 3, 2, 3);
			buttonDuplicateTile.Name = "buttonDuplicateTile";
			buttonDuplicateTile.Size = new System.Drawing.Size(89, 24);
			buttonDuplicateTile.TabIndex = 1;
			buttonDuplicateTile.Text = "Duplicate tile";
			buttonDuplicateTile.UseVisualStyleBackColor = true;
			// 
			// panelTileset
			// 
			panelTileset.AutoScroll = true;
			panelTileset.BackColor = Color.Black;
			panelTileset.BorderStyle = BorderStyle.Fixed3D;
			panelTileset.Location = new Point(9, 21);
			panelTileset.Margin = new Padding(2, 3, 2, 3);
			panelTileset.Name = "panelTileset";
			panelTileset.Size = new System.Drawing.Size(695, 149);
			panelTileset.TabIndex = 0;
			// 
			// groupBoxProperties
			// 
			groupBoxProperties.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			groupBoxProperties.Controls.Add(comboBoxWorld);
			groupBoxProperties.Controls.Add(labelSizeCross);
			groupBoxProperties.Controls.Add(numericUpDownHeight);
			groupBoxProperties.Controls.Add(labelSize);
			groupBoxProperties.Controls.Add(numericUpDownWidth);
			groupBoxProperties.Controls.Add(buttonResize);
			groupBoxProperties.Controls.Add(buttonToggleMusic);
			groupBoxProperties.Controls.Add(comboBoxMusic);
			groupBoxProperties.Controls.Add(labelMusic);
			groupBoxProperties.Controls.Add(checkBoxWorldSurface);
			groupBoxProperties.Controls.Add(checkBoxMagic);
			groupBoxProperties.Controls.Add(buttonIndoorDefaults);
			groupBoxProperties.Controls.Add(buttonWorldMapDefaults);
			groupBoxProperties.Controls.Add(checkBoxTravelGraphics);
			groupBoxProperties.Controls.Add(checkBoxNoSleepUntilDawn);
			groupBoxProperties.Controls.Add(checkBoxUnknown1);
			groupBoxProperties.Controls.Add(checkBoxResting);
			groupBoxProperties.Controls.Add(radioButtonDungeon);
			groupBoxProperties.Controls.Add(radioButtonOutdoor);
			groupBoxProperties.Controls.Add(radioButtonIndoor);
			groupBoxProperties.Location = new Point(856, 26);
			groupBoxProperties.Margin = new Padding(2, 3, 2, 3);
			groupBoxProperties.Name = "groupBoxProperties";
			groupBoxProperties.Padding = new Padding(2, 3, 2, 3);
			groupBoxProperties.Size = new System.Drawing.Size(338, 224);
			groupBoxProperties.TabIndex = 3;
			groupBoxProperties.TabStop = false;
			groupBoxProperties.Text = "Properties";
			// 
			// comboBoxWorld
			// 
			comboBoxWorld.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxWorld.FormattingEnabled = true;
			comboBoxWorld.Items.AddRange(new object[] { "Lyramion", "Forest Moon", "Morag" });
			comboBoxWorld.Location = new Point(229, 45);
			comboBoxWorld.Margin = new Padding(2, 3, 2, 3);
			comboBoxWorld.Name = "comboBoxWorld";
			comboBoxWorld.Size = new System.Drawing.Size(104, 23);
			comboBoxWorld.TabIndex = 21;
			// 
			// labelSizeCross
			// 
			labelSizeCross.AutoSize = true;
			labelSizeCross.Location = new Point(90, 24);
			labelSizeCross.Margin = new Padding(2, 0, 2, 0);
			labelSizeCross.Name = "labelSizeCross";
			labelSizeCross.Size = new System.Drawing.Size(13, 15);
			labelSizeCross.TabIndex = 20;
			labelSizeCross.Text = "x";
			// 
			// numericUpDownHeight
			// 
			numericUpDownHeight.Enabled = false;
			numericUpDownHeight.Location = new Point(104, 21);
			numericUpDownHeight.Margin = new Padding(2, 3, 2, 3);
			numericUpDownHeight.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
			numericUpDownHeight.Minimum = new decimal(new int[] { 9, 0, 0, 0 });
			numericUpDownHeight.Name = "numericUpDownHeight";
			numericUpDownHeight.Size = new System.Drawing.Size(44, 23);
			numericUpDownHeight.TabIndex = 19;
			numericUpDownHeight.Value = new decimal(new int[] { 50, 0, 0, 0 });
			// 
			// labelSize
			// 
			labelSize.AutoSize = true;
			labelSize.Location = new Point(7, 24);
			labelSize.Margin = new Padding(2, 0, 2, 0);
			labelSize.Name = "labelSize";
			labelSize.Size = new System.Drawing.Size(30, 15);
			labelSize.TabIndex = 18;
			labelSize.Text = "Size:";
			// 
			// numericUpDownWidth
			// 
			numericUpDownWidth.Enabled = false;
			numericUpDownWidth.Location = new Point(43, 20);
			numericUpDownWidth.Margin = new Padding(2, 3, 2, 3);
			numericUpDownWidth.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
			numericUpDownWidth.Minimum = new decimal(new int[] { 11, 0, 0, 0 });
			numericUpDownWidth.Name = "numericUpDownWidth";
			numericUpDownWidth.Size = new System.Drawing.Size(44, 23);
			numericUpDownWidth.TabIndex = 17;
			numericUpDownWidth.Value = new decimal(new int[] { 50, 0, 0, 0 });
			// 
			// buttonResize
			// 
			buttonResize.Location = new Point(154, 21);
			buttonResize.Margin = new Padding(2, 3, 2, 3);
			buttonResize.Name = "buttonResize";
			buttonResize.Size = new System.Drawing.Size(104, 24);
			buttonResize.TabIndex = 16;
			buttonResize.Text = "Enable resizing";
			buttonResize.UseVisualStyleBackColor = true;
			// 
			// buttonToggleMusic
			// 
			buttonToggleMusic.Image = Properties.Resources.round_play_arrow_black_24;
			buttonToggleMusic.Location = new Point(308, 186);
			buttonToggleMusic.Margin = new Padding(2, 3, 2, 3);
			buttonToggleMusic.Name = "buttonToggleMusic";
			buttonToggleMusic.Size = new System.Drawing.Size(23, 24);
			buttonToggleMusic.TabIndex = 15;
			buttonToggleMusic.UseVisualStyleBackColor = true;
			// 
			// comboBoxMusic
			// 
			comboBoxMusic.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxMusic.FormattingEnabled = true;
			comboBoxMusic.Location = new Point(55, 186);
			comboBoxMusic.Margin = new Padding(2, 3, 2, 3);
			comboBoxMusic.Name = "comboBoxMusic";
			comboBoxMusic.Size = new System.Drawing.Size(250, 23);
			comboBoxMusic.TabIndex = 14;
			// 
			// labelMusic
			// 
			labelMusic.AutoSize = true;
			labelMusic.Location = new Point(7, 190);
			labelMusic.Margin = new Padding(2, 0, 2, 0);
			labelMusic.Name = "labelMusic";
			labelMusic.Size = new System.Drawing.Size(42, 15);
			labelMusic.TabIndex = 13;
			labelMusic.Text = "Music:";
			// 
			// checkBoxWorldSurface
			// 
			checkBoxWorldSurface.AutoSize = true;
			checkBoxWorldSurface.Enabled = false;
			checkBoxWorldSurface.Location = new Point(7, 71);
			checkBoxWorldSurface.Margin = new Padding(2, 3, 2, 3);
			checkBoxWorldSurface.Name = "checkBoxWorldSurface";
			checkBoxWorldSurface.Size = new System.Drawing.Size(85, 19);
			checkBoxWorldSurface.TabIndex = 12;
			checkBoxWorldSurface.Text = "World Map";
			checkBoxWorldSurface.UseVisualStyleBackColor = true;
			// 
			// checkBoxMagic
			// 
			checkBoxMagic.AutoSize = true;
			checkBoxMagic.Checked = true;
			checkBoxMagic.CheckState = CheckState.Checked;
			checkBoxMagic.Location = new Point(7, 121);
			checkBoxMagic.Margin = new Padding(2, 3, 2, 3);
			checkBoxMagic.Name = "checkBoxMagic";
			checkBoxMagic.Size = new System.Drawing.Size(92, 19);
			checkBoxMagic.TabIndex = 11;
			checkBoxMagic.Text = "Allow Magic";
			checkBoxMagic.UseVisualStyleBackColor = true;
			// 
			// buttonIndoorDefaults
			// 
			buttonIndoorDefaults.Location = new Point(173, 145);
			buttonIndoorDefaults.Margin = new Padding(2, 3, 2, 3);
			buttonIndoorDefaults.Name = "buttonIndoorDefaults";
			buttonIndoorDefaults.Size = new System.Drawing.Size(160, 24);
			buttonIndoorDefaults.TabIndex = 9;
			buttonIndoorDefaults.Text = "Use Indoor Defaults";
			buttonIndoorDefaults.UseVisualStyleBackColor = true;
			// 
			// buttonWorldMapDefaults
			// 
			buttonWorldMapDefaults.Location = new Point(6, 145);
			buttonWorldMapDefaults.Margin = new Padding(2, 3, 2, 3);
			buttonWorldMapDefaults.Name = "buttonWorldMapDefaults";
			buttonWorldMapDefaults.Size = new System.Drawing.Size(160, 24);
			buttonWorldMapDefaults.TabIndex = 8;
			buttonWorldMapDefaults.Text = "Use World Map Defaults";
			buttonWorldMapDefaults.UseVisualStyleBackColor = true;
			// 
			// checkBoxTravelGraphics
			// 
			checkBoxTravelGraphics.AutoSize = true;
			checkBoxTravelGraphics.Enabled = false;
			checkBoxTravelGraphics.Location = new Point(111, 71);
			checkBoxTravelGraphics.Margin = new Padding(2, 3, 2, 3);
			checkBoxTravelGraphics.Name = "checkBoxTravelGraphics";
			checkBoxTravelGraphics.Size = new System.Drawing.Size(105, 19);
			checkBoxTravelGraphics.TabIndex = 7;
			checkBoxTravelGraphics.Text = "Travel Graphics";
			checkBoxTravelGraphics.UseVisualStyleBackColor = true;
			// 
			// checkBoxNoSleepUntilDawn
			// 
			checkBoxNoSleepUntilDawn.AutoSize = true;
			checkBoxNoSleepUntilDawn.Location = new Point(111, 96);
			checkBoxNoSleepUntilDawn.Margin = new Padding(2, 3, 2, 3);
			checkBoxNoSleepUntilDawn.Name = "checkBoxNoSleepUntilDawn";
			checkBoxNoSleepUntilDawn.Size = new System.Drawing.Size(134, 19);
			checkBoxNoSleepUntilDawn.TabIndex = 6;
			checkBoxNoSleepUntilDawn.Text = "No Sleep Until Dawn";
			checkBoxNoSleepUntilDawn.UseVisualStyleBackColor = true;
			// 
			// checkBoxUnknown1
			// 
			checkBoxUnknown1.AutoSize = true;
			checkBoxUnknown1.Enabled = false;
			checkBoxUnknown1.Location = new Point(111, 121);
			checkBoxUnknown1.Margin = new Padding(2, 3, 2, 3);
			checkBoxUnknown1.Name = "checkBoxUnknown1";
			checkBoxUnknown1.Size = new System.Drawing.Size(77, 19);
			checkBoxUnknown1.TabIndex = 5;
			checkBoxUnknown1.Text = "Unknown";
			checkBoxUnknown1.UseVisualStyleBackColor = true;
			// 
			// checkBoxResting
			// 
			checkBoxResting.AutoSize = true;
			checkBoxResting.Checked = true;
			checkBoxResting.CheckState = CheckState.Checked;
			checkBoxResting.Location = new Point(7, 96);
			checkBoxResting.Margin = new Padding(2, 3, 2, 3);
			checkBoxResting.Name = "checkBoxResting";
			checkBoxResting.Size = new System.Drawing.Size(98, 19);
			checkBoxResting.TabIndex = 4;
			checkBoxResting.Text = "Allow Resting";
			checkBoxResting.UseVisualStyleBackColor = true;
			// 
			// radioButtonDungeon
			// 
			radioButtonDungeon.AutoSize = true;
			radioButtonDungeon.Location = new Point(148, 46);
			radioButtonDungeon.Margin = new Padding(2, 3, 2, 3);
			radioButtonDungeon.Name = "radioButtonDungeon";
			radioButtonDungeon.Size = new System.Drawing.Size(74, 19);
			radioButtonDungeon.TabIndex = 2;
			radioButtonDungeon.Text = "Dungeon";
			radioButtonDungeon.UseVisualStyleBackColor = true;
			// 
			// radioButtonOutdoor
			// 
			radioButtonOutdoor.AutoSize = true;
			radioButtonOutdoor.Location = new Point(72, 46);
			radioButtonOutdoor.Margin = new Padding(2, 3, 2, 3);
			radioButtonOutdoor.Name = "radioButtonOutdoor";
			radioButtonOutdoor.Size = new System.Drawing.Size(70, 19);
			radioButtonOutdoor.TabIndex = 1;
			radioButtonOutdoor.Text = "Outdoor";
			radioButtonOutdoor.UseVisualStyleBackColor = true;
			// 
			// radioButtonIndoor
			// 
			radioButtonIndoor.AutoSize = true;
			radioButtonIndoor.Checked = true;
			radioButtonIndoor.Location = new Point(6, 46);
			radioButtonIndoor.Margin = new Padding(2, 3, 2, 3);
			radioButtonIndoor.Name = "radioButtonIndoor";
			radioButtonIndoor.Size = new System.Drawing.Size(60, 19);
			radioButtonIndoor.TabIndex = 0;
			radioButtonIndoor.TabStop = true;
			radioButtonIndoor.Text = "Indoor";
			radioButtonIndoor.UseVisualStyleBackColor = true;
			// 
			// groupBoxCharacters
			// 
			groupBoxCharacters.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			groupBoxCharacters.Controls.Add(buttonPositions);
			groupBoxCharacters.Controls.Add(mapCharEditorControl);
			groupBoxCharacters.Controls.Add(buttonPlaceCharacterOnMap);
			groupBoxCharacters.Controls.Add(labelCharacterPosition);
			groupBoxCharacters.Location = new Point(856, 256);
			groupBoxCharacters.Margin = new Padding(2, 3, 2, 3);
			groupBoxCharacters.Name = "groupBoxCharacters";
			groupBoxCharacters.Padding = new Padding(2, 3, 2, 3);
			groupBoxCharacters.Size = new System.Drawing.Size(338, 291);
			groupBoxCharacters.TabIndex = 4;
			groupBoxCharacters.TabStop = false;
			groupBoxCharacters.Text = "Monsters && NPCs";
			// 
			// buttonPositions
			// 
			buttonPositions.Location = new Point(124, 261);
			buttonPositions.Name = "buttonPositions";
			buttonPositions.Size = new System.Drawing.Size(86, 24);
			buttonPositions.TabIndex = 17;
			buttonPositions.Text = "Positions ...";
			buttonPositions.UseVisualStyleBackColor = true;
			// 
			// mapCharEditorControl
			// 
			mapCharEditorControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			mapCharEditorControl.AutoSize = true;
			mapCharEditorControl.Location = new Point(7, 21);
			mapCharEditorControl.Margin = new Padding(2, 4, 2, 4);
			mapCharEditorControl.Name = "mapCharEditorControl";
			mapCharEditorControl.Size = new System.Drawing.Size(326, 234);
			mapCharEditorControl.TabIndex = 0;
			mapCharEditorControl.Visible = false;
			// 
			// buttonPlaceCharacterOnMap
			// 
			buttonPlaceCharacterOnMap.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonPlaceCharacterOnMap.Image = Properties.Resources.round_control_camera_black_24;
			buttonPlaceCharacterOnMap.Location = new Point(215, 261);
			buttonPlaceCharacterOnMap.Margin = new Padding(2, 3, 2, 3);
			buttonPlaceCharacterOnMap.Name = "buttonPlaceCharacterOnMap";
			buttonPlaceCharacterOnMap.Size = new System.Drawing.Size(23, 24);
			buttonPlaceCharacterOnMap.TabIndex = 16;
			buttonPlaceCharacterOnMap.UseVisualStyleBackColor = true;
			// 
			// labelCharacterPosition
			// 
			labelCharacterPosition.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			labelCharacterPosition.AutoSize = true;
			labelCharacterPosition.Location = new Point(240, 267);
			labelCharacterPosition.Margin = new Padding(2, 0, 2, 0);
			labelCharacterPosition.Name = "labelCharacterPosition";
			labelCharacterPosition.Size = new System.Drawing.Size(89, 15);
			labelCharacterPosition.TabIndex = 4;
			labelCharacterPosition.Text = "Location: 50, 50";
			// 
			// buttonToolBrush
			// 
			buttonToolBrush.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToolBrush.ForeColor = SystemColors.ControlText;
			buttonToolBrush.Image = Properties.Resources.round_brush_black_24;
			buttonToolBrush.Location = new Point(821, 27);
			buttonToolBrush.Margin = new Padding(2, 3, 2, 3);
			buttonToolBrush.Name = "buttonToolBrush";
			buttonToolBrush.Size = new System.Drawing.Size(33, 32);
			buttonToolBrush.TabIndex = 5;
			buttonToolBrush.UseVisualStyleBackColor = true;
			// 
			// buttonToolColorPicker
			// 
			buttonToolColorPicker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToolColorPicker.Image = Properties.Resources.round_colorize_black_24;
			buttonToolColorPicker.Location = new Point(821, 179);
			buttonToolColorPicker.Margin = new Padding(2, 3, 2, 3);
			buttonToolColorPicker.Name = "buttonToolColorPicker";
			buttonToolColorPicker.Size = new System.Drawing.Size(33, 32);
			buttonToolColorPicker.TabIndex = 6;
			buttonToolColorPicker.UseVisualStyleBackColor = true;
			// 
			// buttonToolLayers
			// 
			buttonToolLayers.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToolLayers.Image = Properties.Resources.round_layers_black_24;
			buttonToolLayers.Location = new Point(821, 264);
			buttonToolLayers.Margin = new Padding(2, 3, 2, 3);
			buttonToolLayers.Name = "buttonToolLayers";
			buttonToolLayers.Size = new System.Drawing.Size(33, 32);
			buttonToolLayers.TabIndex = 7;
			buttonToolLayers.UseVisualStyleBackColor = true;
			// 
			// contextMenuStripLayers
			// 
			contextMenuStripLayers.ImageScalingSize = new System.Drawing.Size(20, 20);
			contextMenuStripLayers.Items.AddRange(new ToolStripItem[] { toolStripMenuItemBackLayer, toolStripMenuItemFrontLayer, toolStripSeparatorLayers1, toolStripMenuItemShowBackLayer, toolStripMenuItemShowFrontLayer, toolStripMenuShowAllowWalk, toolStripMenuShowAllowHorse, toolStripMenuShowAllowDisc, toolStripMenuShowAllowRaft, toolStripMenuShowAllowShip });
			contextMenuStripLayers.Name = "contextMenuStripLayers";
			contextMenuStripLayers.Size = new System.Drawing.Size(171, 208);
			// 
			// toolStripMenuItemBackLayer
			// 
			toolStripMenuItemBackLayer.Checked = true;
			toolStripMenuItemBackLayer.CheckOnClick = true;
			toolStripMenuItemBackLayer.CheckState = CheckState.Checked;
			toolStripMenuItemBackLayer.Name = "toolStripMenuItemBackLayer";
			toolStripMenuItemBackLayer.Size = new System.Drawing.Size(170, 22);
			toolStripMenuItemBackLayer.Text = "Back Layer";
			// 
			// toolStripMenuItemFrontLayer
			// 
			toolStripMenuItemFrontLayer.CheckOnClick = true;
			toolStripMenuItemFrontLayer.Name = "toolStripMenuItemFrontLayer";
			toolStripMenuItemFrontLayer.Size = new System.Drawing.Size(170, 22);
			toolStripMenuItemFrontLayer.Text = "Front Layer";
			// 
			// toolStripSeparatorLayers1
			// 
			toolStripSeparatorLayers1.Name = "toolStripSeparatorLayers1";
			toolStripSeparatorLayers1.Size = new System.Drawing.Size(167, 6);
			// 
			// toolStripMenuItemShowBackLayer
			// 
			toolStripMenuItemShowBackLayer.Checked = true;
			toolStripMenuItemShowBackLayer.CheckOnClick = true;
			toolStripMenuItemShowBackLayer.CheckState = CheckState.Checked;
			toolStripMenuItemShowBackLayer.Name = "toolStripMenuItemShowBackLayer";
			toolStripMenuItemShowBackLayer.Size = new System.Drawing.Size(170, 22);
			toolStripMenuItemShowBackLayer.Text = "Show Back Layer";
			// 
			// toolStripMenuItemShowFrontLayer
			// 
			toolStripMenuItemShowFrontLayer.Checked = true;
			toolStripMenuItemShowFrontLayer.CheckOnClick = true;
			toolStripMenuItemShowFrontLayer.CheckState = CheckState.Checked;
			toolStripMenuItemShowFrontLayer.Name = "toolStripMenuItemShowFrontLayer";
			toolStripMenuItemShowFrontLayer.Size = new System.Drawing.Size(170, 22);
			toolStripMenuItemShowFrontLayer.Text = "Show Front Layer";
			// 
			// toolStripMenuShowAllowWalk
			// 
			toolStripMenuShowAllowWalk.CheckOnClick = true;
			toolStripMenuShowAllowWalk.Name = "toolStripMenuShowAllowWalk";
			toolStripMenuShowAllowWalk.Size = new System.Drawing.Size(170, 22);
			toolStripMenuShowAllowWalk.Text = "Show Allow Walk";
			// 
			// toolStripMenuShowAllowHorse
			// 
			toolStripMenuShowAllowHorse.CheckOnClick = true;
			toolStripMenuShowAllowHorse.Name = "toolStripMenuShowAllowHorse";
			toolStripMenuShowAllowHorse.Size = new System.Drawing.Size(170, 22);
			toolStripMenuShowAllowHorse.Text = "Show Allow Horse";
			// 
			// toolStripMenuShowAllowDisc
			// 
			toolStripMenuShowAllowDisc.CheckOnClick = true;
			toolStripMenuShowAllowDisc.Name = "toolStripMenuShowAllowDisc";
			toolStripMenuShowAllowDisc.Size = new System.Drawing.Size(170, 22);
			toolStripMenuShowAllowDisc.Text = "Show Allow Disc";
			// 
			// toolStripMenuShowAllowRaft
			// 
			toolStripMenuShowAllowRaft.CheckOnClick = true;
			toolStripMenuShowAllowRaft.Name = "toolStripMenuShowAllowRaft";
			toolStripMenuShowAllowRaft.Size = new System.Drawing.Size(170, 22);
			toolStripMenuShowAllowRaft.Text = "Show Allow Raft";
			// 
			// toolStripMenuShowAllowShip
			// 
			toolStripMenuShowAllowShip.CheckOnClick = true;
			toolStripMenuShowAllowShip.Name = "toolStripMenuShowAllowShip";
			toolStripMenuShowAllowShip.Size = new System.Drawing.Size(170, 22);
			toolStripMenuShowAllowShip.Text = "Show Allow Ship";
			// 
			// statusStrip
			// 
			statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelTool, toolStripStatusLabelLayer, toolStripStatusLabelCurrentTile, toolStripStatusLabelCurrentTilesetTile });
			statusStrip.Location = new Point(0, 743);
			statusStrip.Name = "statusStrip";
			statusStrip.Size = new System.Drawing.Size(1197, 25);
			statusStrip.SizingGrip = false;
			statusStrip.TabIndex = 8;
			statusStrip.Text = "statusStrip1";
			// 
			// toolStripStatusLabelTool
			// 
			toolStripStatusLabelTool.Image = Properties.Resources.round_brush_black_24;
			toolStripStatusLabelTool.Name = "toolStripStatusLabelTool";
			toolStripStatusLabelTool.Size = new System.Drawing.Size(20, 20);
			// 
			// toolStripStatusLabelLayer
			// 
			toolStripStatusLabelLayer.BorderSides = ToolStripStatusLabelBorderSides.Left;
			toolStripStatusLabelLayer.BorderStyle = Border3DStyle.Etched;
			toolStripStatusLabelLayer.Name = "toolStripStatusLabelLayer";
			toolStripStatusLabelLayer.Size = new System.Drawing.Size(67, 20);
			toolStripStatusLabelLayer.Text = "Back Layer";
			// 
			// toolStripStatusLabelCurrentTile
			// 
			toolStripStatusLabelCurrentTile.BorderSides = ToolStripStatusLabelBorderSides.Left;
			toolStripStatusLabelCurrentTile.BorderStyle = Border3DStyle.Etched;
			toolStripStatusLabelCurrentTile.Name = "toolStripStatusLabelCurrentTile";
			toolStripStatusLabelCurrentTile.Size = new System.Drawing.Size(29, 20);
			toolStripStatusLabelCurrentTile.Text = "0, 0";
			toolStripStatusLabelCurrentTile.Visible = false;
			// 
			// toolStripStatusLabelCurrentTilesetTile
			// 
			toolStripStatusLabelCurrentTilesetTile.BorderSides = ToolStripStatusLabelBorderSides.Left;
			toolStripStatusLabelCurrentTilesetTile.BorderStyle = Border3DStyle.Etched;
			toolStripStatusLabelCurrentTilesetTile.Name = "toolStripStatusLabelCurrentTilesetTile";
			toolStripStatusLabelCurrentTilesetTile.Size = new System.Drawing.Size(29, 20);
			toolStripStatusLabelCurrentTilesetTile.Text = "0, 0";
			toolStripStatusLabelCurrentTilesetTile.Visible = false;
			// 
			// buttonToolBlocks
			// 
			buttonToolBlocks.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToolBlocks.ContextMenuStrip = contextMenuStripBlockModes;
			buttonToolBlocks.ForeColor = SystemColors.ControlText;
			buttonToolBlocks.Image = Properties.Resources.round_grid_view_black_24_with_arrow;
			buttonToolBlocks.Location = new Point(821, 65);
			buttonToolBlocks.Margin = new Padding(2, 3, 2, 3);
			buttonToolBlocks.Name = "buttonToolBlocks";
			buttonToolBlocks.Size = new System.Drawing.Size(33, 32);
			buttonToolBlocks.TabIndex = 9;
			buttonToolBlocks.UseVisualStyleBackColor = true;
			// 
			// contextMenuStripBlockModes
			// 
			contextMenuStripBlockModes.ImageScalingSize = new System.Drawing.Size(20, 20);
			contextMenuStripBlockModes.Items.AddRange(new ToolStripItem[] { toolStripMenuItemBlocks2x2, toolStripMenuItemBlocks3x2, toolStripMenuItemBlocks3x3 });
			contextMenuStripBlockModes.Name = "contextMenuStripBlockModes";
			contextMenuStripBlockModes.Size = new System.Drawing.Size(97, 82);
			// 
			// toolStripMenuItemBlocks2x2
			// 
			toolStripMenuItemBlocks2x2.Image = Properties.Resources.round_grid_view_black_24;
			toolStripMenuItemBlocks2x2.Name = "toolStripMenuItemBlocks2x2";
			toolStripMenuItemBlocks2x2.Size = new System.Drawing.Size(96, 26);
			toolStripMenuItemBlocks2x2.Text = "2x2";
			// 
			// toolStripMenuItemBlocks3x2
			// 
			toolStripMenuItemBlocks3x2.Image = Properties.Resources.round_view_module_black_24;
			toolStripMenuItemBlocks3x2.Name = "toolStripMenuItemBlocks3x2";
			toolStripMenuItemBlocks3x2.Size = new System.Drawing.Size(96, 26);
			toolStripMenuItemBlocks3x2.Text = "3x2";
			// 
			// toolStripMenuItemBlocks3x3
			// 
			toolStripMenuItemBlocks3x3.Image = Properties.Resources.round_apps_black_24;
			toolStripMenuItemBlocks3x3.Name = "toolStripMenuItemBlocks3x3";
			toolStripMenuItemBlocks3x3.Size = new System.Drawing.Size(96, 26);
			toolStripMenuItemBlocks3x3.Text = "3x3";
			// 
			// buttonToolFill
			// 
			buttonToolFill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToolFill.ForeColor = SystemColors.ControlText;
			buttonToolFill.Image = Properties.Resources.round_format_color_fill_black_24;
			buttonToolFill.Location = new Point(821, 103);
			buttonToolFill.Margin = new Padding(2, 3, 2, 3);
			buttonToolFill.Name = "buttonToolFill";
			buttonToolFill.Size = new System.Drawing.Size(33, 32);
			buttonToolFill.TabIndex = 10;
			buttonToolFill.UseVisualStyleBackColor = true;
			// 
			// buttonToggleGrid
			// 
			buttonToggleGrid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToggleGrid.ForeColor = SystemColors.ControlText;
			buttonToggleGrid.Image = Properties.Resources.round_grid_off_black_24;
			buttonToggleGrid.Location = new Point(821, 302);
			buttonToggleGrid.Margin = new Padding(2, 3, 2, 3);
			buttonToggleGrid.Name = "buttonToggleGrid";
			buttonToggleGrid.Size = new System.Drawing.Size(33, 32);
			buttonToggleGrid.TabIndex = 11;
			buttonToggleGrid.UseVisualStyleBackColor = true;
			// 
			// buttonToggleTileMarker
			// 
			buttonToggleTileMarker.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToggleTileMarker.ForeColor = SystemColors.ControlText;
			buttonToggleTileMarker.Image = Properties.Resources.round_select_all_black_24;
			buttonToggleTileMarker.Location = new Point(821, 340);
			buttonToggleTileMarker.Margin = new Padding(2, 3, 2, 3);
			buttonToggleTileMarker.Name = "buttonToggleTileMarker";
			buttonToggleTileMarker.Size = new System.Drawing.Size(33, 32);
			buttonToggleTileMarker.TabIndex = 12;
			buttonToggleTileMarker.UseVisualStyleBackColor = true;
			// 
			// labelDivider
			// 
			labelDivider.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			labelDivider.BorderStyle = BorderStyle.Fixed3D;
			labelDivider.Location = new Point(821, 255);
			labelDivider.Margin = new Padding(2, 0, 2, 0);
			labelDivider.Name = "labelDivider";
			labelDivider.Size = new System.Drawing.Size(33, 2);
			labelDivider.TabIndex = 13;
			// 
			// buttonToolRemoveFrontLayer
			// 
			buttonToolRemoveFrontLayer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToolRemoveFrontLayer.Image = Properties.Resources.round_layers_clear_black_24;
			buttonToolRemoveFrontLayer.Location = new Point(821, 141);
			buttonToolRemoveFrontLayer.Margin = new Padding(2, 3, 2, 3);
			buttonToolRemoveFrontLayer.Name = "buttonToolRemoveFrontLayer";
			buttonToolRemoveFrontLayer.Size = new System.Drawing.Size(33, 32);
			buttonToolRemoveFrontLayer.TabIndex = 14;
			buttonToolRemoveFrontLayer.UseVisualStyleBackColor = true;
			// 
			// groupBoxEvents
			// 
			groupBoxEvents.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			groupBoxEvents.Controls.Add(listViewEvents);
			groupBoxEvents.Location = new Point(820, 553);
			groupBoxEvents.Margin = new Padding(2, 3, 2, 3);
			groupBoxEvents.Name = "groupBoxEvents";
			groupBoxEvents.Padding = new Padding(2, 3, 2, 3);
			groupBoxEvents.Size = new System.Drawing.Size(374, 177);
			groupBoxEvents.TabIndex = 15;
			groupBoxEvents.TabStop = false;
			groupBoxEvents.Text = "Events";
			// 
			// listViewEvents
			// 
			listViewEvents.Columns.AddRange(new ColumnHeader[] { columnHeaderEventId, columnHeaderEventDescription });
			listViewEvents.Dock = DockStyle.Fill;
			listViewEvents.FullRowSelect = true;
			listViewEvents.GridLines = true;
			listViewEvents.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			listViewEvents.Location = new Point(2, 19);
			listViewEvents.Margin = new Padding(2, 3, 2, 3);
			listViewEvents.Name = "listViewEvents";
			listViewEvents.Size = new System.Drawing.Size(370, 155);
			listViewEvents.TabIndex = 0;
			listViewEvents.UseCompatibleStateImageBehavior = false;
			listViewEvents.View = View.Details;
			// 
			// columnHeaderEventId
			// 
			columnHeaderEventId.Text = "ID";
			columnHeaderEventId.Width = 30;
			// 
			// columnHeaderEventDescription
			// 
			columnHeaderEventDescription.Text = "Description";
			columnHeaderEventDescription.Width = 292;
			// 
			// buttonToggleEvents
			// 
			buttonToggleEvents.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToggleEvents.ForeColor = SystemColors.ControlText;
			buttonToggleEvents.Image = Properties.Resources.round_vpn_key_black_24_off;
			buttonToggleEvents.Location = new Point(821, 378);
			buttonToggleEvents.Margin = new Padding(2, 3, 2, 3);
			buttonToggleEvents.Name = "buttonToggleEvents";
			buttonToggleEvents.Size = new System.Drawing.Size(33, 32);
			buttonToggleEvents.TabIndex = 16;
			buttonToggleEvents.UseVisualStyleBackColor = true;
			// 
			// timerAnimation
			// 
			timerAnimation.Interval = 166;
			// 
			// trackBarZoom
			// 
			trackBarZoom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			trackBarZoom.AutoSize = false;
			trackBarZoom.LargeChange = 1;
			trackBarZoom.Location = new Point(828, 411);
			trackBarZoom.Margin = new Padding(2, 3, 2, 3);
			trackBarZoom.Maximum = 4;
			trackBarZoom.Minimum = 1;
			trackBarZoom.Name = "trackBarZoom";
			trackBarZoom.Orientation = Orientation.Vertical;
			trackBarZoom.Size = new System.Drawing.Size(26, 84);
			trackBarZoom.TabIndex = 17;
			trackBarZoom.TickStyle = TickStyle.None;
			trackBarZoom.Value = 4;
			// 
			// buttonToolEventChanger
			// 
			buttonToolEventChanger.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonToolEventChanger.Image = Properties.Resources.baseline_grade_black_24dp;
			buttonToolEventChanger.Location = new Point(821, 216);
			buttonToolEventChanger.Margin = new Padding(2, 3, 2, 3);
			buttonToolEventChanger.Name = "buttonToolEventChanger";
			buttonToolEventChanger.Size = new System.Drawing.Size(33, 32);
			buttonToolEventChanger.TabIndex = 18;
			buttonToolEventChanger.UseVisualStyleBackColor = true;
			// 
			// EditMap2DForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(1197, 768);
			Controls.Add(buttonToolEventChanger);
			Controls.Add(buttonToggleEvents);
			Controls.Add(groupBoxEvents);
			Controls.Add(buttonToolRemoveFrontLayer);
			Controls.Add(labelDivider);
			Controls.Add(buttonToggleTileMarker);
			Controls.Add(buttonToggleGrid);
			Controls.Add(buttonToolFill);
			Controls.Add(buttonToolBlocks);
			Controls.Add(statusStrip);
			Controls.Add(buttonToolLayers);
			Controls.Add(buttonToolColorPicker);
			Controls.Add(buttonToolBrush);
			Controls.Add(groupBoxCharacters);
			Controls.Add(groupBoxProperties);
			Controls.Add(groupBoxTileset);
			Controls.Add(panelMap);
			Controls.Add(menuStrip);
			Controls.Add(trackBarZoom);
			DoubleBuffered = true;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip;
			Margin = new Padding(2, 3, 2, 3);
			Name = "EditMap2DForm";
			Text = "Ambermoon Map Editor 2D";
			menuStrip.ResumeLayout(false);
			menuStrip.PerformLayout();
			groupBoxTileset.ResumeLayout(false);
			groupBoxTileset.PerformLayout();
			groupBoxProperties.ResumeLayout(false);
			groupBoxProperties.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numericUpDownHeight).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownWidth).EndInit();
			groupBoxCharacters.ResumeLayout(false);
			groupBoxCharacters.PerformLayout();
			contextMenuStripLayers.ResumeLayout(false);
			statusStrip.ResumeLayout(false);
			statusStrip.PerformLayout();
			contextMenuStripBlockModes.ResumeLayout(false);
			groupBoxEvents.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)trackBarZoom).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.MapDrawPanel panelMap;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.GroupBox groupBoxTileset;
    private System.Windows.Forms.Button buttonDuplicateTile;
    private System.Windows.Forms.ScrollDrawPanel panelTileset;
    private System.Windows.Forms.ComboBox comboBoxTilesets;
    private System.Windows.Forms.GroupBox groupBoxProperties;
    private System.Windows.Forms.RadioButton radioButtonOutdoor;
    private System.Windows.Forms.RadioButton radioButtonIndoor;
    private System.Windows.Forms.RadioButton radioButtonDungeon;
    private System.Windows.Forms.ToolTip toolTipIndoor;
    private System.Windows.Forms.ToolTip toolTipOutdoor;
    private System.Windows.Forms.ToolTip toolTipDungeon;
    private System.Windows.Forms.CheckBox checkBoxResting;
    private System.Windows.Forms.CheckBox checkBoxNoSleepUntilDawn;
    private System.Windows.Forms.CheckBox checkBoxUnknown1;
    private System.Windows.Forms.ToolTip toolTipResting;
    private System.Windows.Forms.CheckBox checkBoxTravelGraphics;
    private System.Windows.Forms.ToolTip toolTipNoSleepUntilDawn;
    private System.Windows.Forms.Button buttonIndoorDefaults;
    private System.Windows.Forms.Button buttonWorldMapDefaults;
    private System.Windows.Forms.CheckBox checkBoxMagic;
    private System.Windows.Forms.CheckBox checkBoxWorldSurface;
    private System.Windows.Forms.ToolTip toolTipMagic;
    private System.Windows.Forms.ToolTip toolTipWorldSurface;
    private System.Windows.Forms.ComboBox comboBoxMusic;
    private System.Windows.Forms.Label labelMusic;
    private System.Windows.Forms.Button buttonResize;
    private System.Windows.Forms.Button buttonToggleMusic;
    private System.Windows.Forms.NumericUpDown numericUpDownHeight;
    private System.Windows.Forms.Label labelSize;
    private System.Windows.Forms.NumericUpDown numericUpDownWidth;
    private System.Windows.Forms.Label labelSizeCross;
    private System.Windows.Forms.GroupBox groupBoxCharacters;
    private System.Windows.Forms.Label labelCharacterPosition;
    private System.Windows.Forms.Button buttonPlaceCharacterOnMap;
    private System.Windows.Forms.ComboBox comboBoxWorld;
    private System.Windows.Forms.Button buttonToolBrush;
    private System.Windows.Forms.Button buttonToolColorPicker;
    private System.Windows.Forms.Button buttonToolLayers;
    private System.Windows.Forms.ContextMenuStrip contextMenuStripLayers;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBackLayer;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFrontLayer;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparatorLayers1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowBackLayer;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowFrontLayer;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.Button buttonToolBlocks;
    private System.Windows.Forms.Button buttonToolFill;
    private System.Windows.Forms.Button buttonToggleGrid;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTool;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLayer;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCurrentTile;
    private System.Windows.Forms.ContextMenuStrip contextMenuStripBlockModes;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBlocks2x2;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBlocks3x2;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBlocks3x3;
    private System.Windows.Forms.ToolTip toolTipBrush;
    private System.Windows.Forms.ToolTip toolTipBlocks;
    private System.Windows.Forms.ToolTip toolTipFill;
    private System.Windows.Forms.ToolTip toolTipColorPicker;
    private System.Windows.Forms.ToolTip toolTipLayers;
    private System.Windows.Forms.ToolTip toolTipGrid;
    private System.Windows.Forms.Button buttonToggleTileMarker;
    private System.Windows.Forms.ToolTip toolTipTileMarker;
    private System.Windows.Forms.Label labelDivider;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCurrentTilesetTile;
    private System.Windows.Forms.Button buttonEditTile;
    private System.Windows.Forms.ComboBox comboBoxPalettes;
    private System.Windows.Forms.Button buttonToolRemoveFrontLayer;
    private System.Windows.Forms.ToolTip toolTipRemoveFrontLayer;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMap;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditUndo;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditRedo;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparatorEdit1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMapSave;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMapSaveAs;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMap1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMapQuit;
    private System.Windows.Forms.GroupBox groupBoxEvents;
    private System.Windows.Forms.Button buttonToggleEvents;
    private System.Windows.Forms.ListView listViewEvents;
    private System.Windows.Forms.ColumnHeader columnHeaderEventId;
    private System.Windows.Forms.ColumnHeader columnHeaderEventDescription;
    private System.Windows.Forms.Timer timerAnimation;
    private System.Windows.Forms.TrackBar trackBarZoom;
    private System.Windows.Forms.Button buttonToolEventChanger;
    private EditMapCharControl mapCharEditorControl;
    private System.Windows.Forms.Button buttonPositions;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuShowAllowWalk;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuShowAllowHorse;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuShowAllowRaft;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuShowAllowShip;
    private System.Windows.Forms.CheckBox checkBoxMarkUnusedTiles;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuShowAllowDisc;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMapSaveAsPNG;
  }
}

