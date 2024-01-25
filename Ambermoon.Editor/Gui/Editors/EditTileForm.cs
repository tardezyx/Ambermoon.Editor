using Ambermoon.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Helper;
using static Ambermoon.Data.Tileset;

namespace Ambermoon.Editor.Gui.Editors {
  partial class EditTileForm : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private          bool                     _animateForward = true;
    private readonly Dictionary<uint, Bitmap> _combatGraphics;
    //private readonly Configuration           _configuration;
    private          uint                     _frame          = 0;
    private readonly ImageCache               _imageCache;
    private          bool                     _initialize     = true;
    private readonly uint                     _paletteIndex;
    private readonly Random                   _random         = new();    
    private readonly Tileset                  _tileset;
    private const    int                      _timePerFrame   = 166;
    #endregion
    #region --- properties ------------------------------------------------------------------------
    internal Tile Tile { get; }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    //public EditTileForm(Configuration configuration, Tile tile, Tileset tileset, ImageCache imageCache,
    public EditTileForm(
      Tile                     tile,
      Tileset                  tileset,
      ImageCache               imageCache,
      uint                     paletteIndex,
      Dictionary<uint, Bitmap> combatGraphics
    ) {
      //_configuration = configuration;
      _combatGraphics = combatGraphics;
      _imageCache     = imageCache;
      _paletteIndex   = paletteIndex;
      _tileset        = tileset;

      Tile = new();
      Tile.Fill(tile);

      InitializeComponent();

      checkBoxAllowBroom.Checked           = tile.Flags.HasFlag(TileFlags.AllowMovementWitchBroom);
      checkBoxAllowEagle.Checked           = tile.Flags.HasFlag(TileFlags.AllowMovementEagle);
      checkBoxAllowFly.Checked             = tile.Flags.HasFlag(TileFlags.AllowMovementFly);
      checkBoxAllowHorse.Checked           = tile.Flags.HasFlag(TileFlags.AllowMovementHorse);
      checkBoxAllowMagicDisc.Checked       = tile.Flags.HasFlag(TileFlags.AllowMovementMagicalDisc);
      checkBoxAllowRaft.Checked            = tile.Flags.HasFlag(TileFlags.AllowMovementRaft);
      checkBoxAllowSandLizard.Checked      = tile.Flags.HasFlag(TileFlags.AllowMovementSandLizard);
      checkBoxAllowSandShip.Checked        = tile.Flags.HasFlag(TileFlags.AllowMovementSandShip);
      checkBoxAllowShip.Checked            = tile.Flags.HasFlag(TileFlags.AllowMovementShip);
      checkBoxAllowSwim.Checked            = tile.Flags.HasFlag(TileFlags.AllowMovementSwim);
      checkBoxAllowUnused1.Checked         = tile.Flags.HasFlag(TileFlags.AllowMovementWasp);
      checkBoxAllowUnused2.Checked         = tile.Flags.HasFlag(TileFlags.AllowMovementUnused13);
      checkBoxAllowUnused3.Checked         = tile.Flags.HasFlag(TileFlags.AllowMovementUnused14);
      checkBoxAllowUnused4.Checked         = tile.Flags.HasFlag(TileFlags.AllowMovementUnused15);
      checkBoxAllowWalk.Checked            = tile.Flags.HasFlag(TileFlags.AllowMovementWalk);
      checkBoxAutoPoison.Checked           = tile.Flags.HasFlag(TileFlags.AutoPoison);
      //checkBoxAlternate.Checked            = tile.Flags.HasFlag(TileFlags.AlternateAnimation);
      checkBoxBackgroundFlags.Checked      = tile.Flags.HasFlag(TileFlags.UseBackgroundTileFlags);
      checkBoxBlockAllMovement.Checked     = tile.Flags.HasFlag(TileFlags.BlockAllMovement);
      checkBoxBlockSight.Checked           = tile.Flags.HasFlag(TileFlags.BlockSight);
      checkBoxFloor.Checked                = tile.Flags.HasFlag(TileFlags.Floor);
      checkBoxHidePlayer.Checked           = tile.Flags.HasFlag(TileFlags.PlayerInvisible);
      checkBoxRandomAnimationStart.Checked = tile.Flags.HasFlag(TileFlags.RandomAnimationStart);
      
      comboBoxSitSleep.SelectedIndex = tile.Sleep
        ? 5
        : tile.SitDirection != null
          ? 1 + (int)tile.SitDirection.Value
          : 0;

      numericUpDownCombatBackground.Value  = tile.CombatBackgroundIndex;
      numericUpDownImageIndex.Value        = tile.GraphicIndex;
      trackBarFrames.Value                 = Math.Max(1, tile.NumAnimationFrames);
      
      radioButtonBackground.Checked        = tile.Flags.HasFlag(TileFlags.Background) && !tile.Flags.HasFlag(TileFlags.BringToFront);
      radioButtonForeground.Checked        = tile.Flags.HasFlag(TileFlags.Background) && tile.Flags.HasFlag(TileFlags.BringToFront);
      radioButtonNormal.Checked            = !tile.Flags.HasFlag(TileFlags.Background);

      UpdateColor();

      timerAnimation.Interval = _timePerFrame;
      timerAnimation.Start();

      _initialize = false;
    }
    #endregion

    // needs rework:
    #region --- button apply: click ---------------------------------------------------------------
    private void buttonApply_Click(object sender, EventArgs e) {
      Tile.Flags = TileFlags.None;

      //Tile.Flags |= (checkBoxAllowBroom.Checked ? TileFlags.AllowMovementWitchBroom : TileFlags.None)
      //           |  (checkBoxAllowBroom.Checked ? TileFlags.None : TileFlags.None);

      if (checkBoxAllowBroom.Checked)
        Tile.Flags |= TileFlags.AllowMovementWitchBroom;
      if (checkBoxAllowEagle.Checked)
        Tile.Flags |= TileFlags.AllowMovementEagle;
      if (checkBoxAllowFly.Checked)
        Tile.Flags |= TileFlags.AllowMovementFly;
      if (checkBoxAllowHorse.Checked)
        Tile.Flags |= TileFlags.AllowMovementHorse;
      if (checkBoxAllowMagicDisc.Checked)
        Tile.Flags |= TileFlags.AllowMovementMagicalDisc;
      if (checkBoxAllowRaft.Checked)
        Tile.Flags |= TileFlags.AllowMovementRaft;
      if (checkBoxAllowSandLizard.Checked)
        Tile.Flags |= TileFlags.AllowMovementSandLizard;
      if (checkBoxAllowSandShip.Checked)
        Tile.Flags |= TileFlags.AllowMovementSandShip;
      if (checkBoxAllowShip.Checked)
        Tile.Flags |= TileFlags.AllowMovementShip;
      if (checkBoxAllowSwim.Checked)
        Tile.Flags |= TileFlags.AllowMovementSwim;
      if (checkBoxAllowUnused1.Checked)
        Tile.Flags |= TileFlags.AllowMovementWasp;
      if (checkBoxAllowUnused2.Checked)
        Tile.Flags |= TileFlags.AllowMovementUnused13;
      if (checkBoxAllowUnused3.Checked)
        Tile.Flags |= TileFlags.AllowMovementUnused14;
      if (checkBoxAllowUnused4.Checked)
        Tile.Flags |= TileFlags.AllowMovementUnused15;
      if (checkBoxAllowWalk.Checked)
        Tile.Flags |= TileFlags.AllowMovementWalk;
      if (checkBoxAlternate.Checked)
        //Tile.Flags |= TileFlags.AlternateAnimation;
      if (checkBoxBackgroundFlags.Checked)
        Tile.Flags |= TileFlags.UseBackgroundTileFlags;
      if (checkBoxBlockAllMovement.Checked)
        Tile.Flags |= TileFlags.BlockAllMovement;
      if (checkBoxBlockSight.Checked)
        Tile.Flags |= TileFlags.BlockSight;
      if (checkBoxFloor.Checked)
        Tile.Flags |= TileFlags.Floor;
      if (checkBoxHidePlayer.Checked)
        Tile.Flags |= TileFlags.PlayerInvisible;
      if (checkBoxRandomAnimationStart.Checked)
        Tile.Flags |= TileFlags.RandomAnimationStart;
      if (checkBoxAutoPoison.Checked)
        Tile.Flags |= TileFlags.AutoPoison;

      if (radioButtonBackground.Checked)
        Tile.Flags |= TileFlags.Background;
      else if (radioButtonForeground.Checked) {
        Tile.Flags |= TileFlags.Background;
        Tile.Flags |= TileFlags.BringToFront;
      }

      Tile.SitDirection = comboBoxSitSleep.SelectedIndex == 0 || comboBoxSitSleep.SelectedIndex > 4
          ? null : (CharacterDirection?)(comboBoxSitSleep.SelectedIndex - 1);
      Tile.Sleep = comboBoxSitSleep.SelectedIndex == 5;
      Tile.CombatBackgroundIndex = (uint)numericUpDownCombatBackground.Value;

      DialogResult = DialogResult.OK;
    }
    #endregion
    #region --- button block indoor: click --------------------------------------------------------
    private void buttonBlockIndoor_Click(object sender, EventArgs e) {
      checkBoxBlockAllMovement.Checked = false;
      checkBoxAllowWalk.Checked = false;
      checkBoxAllowHorse.Checked = false;
      checkBoxAllowRaft.Checked = false;
      checkBoxAllowShip.Checked = false;
      checkBoxAllowMagicDisc.Checked = false;
      checkBoxAllowEagle.Checked = false;
      checkBoxAllowFly.Checked = true;
      checkBoxAllowSwim.Checked = false;
      checkBoxAllowBroom.Checked = false;
      checkBoxAllowSandLizard.Checked = false;
      checkBoxAllowSandShip.Checked = false;
      checkBoxAllowUnused1.Checked = false;
      checkBoxAllowUnused2.Checked = false;
      checkBoxAllowUnused3.Checked = false;
      checkBoxAllowUnused4.Checked = false;
    }
    #endregion
    #region --- button block outdoor: click -------------------------------------------------------
    private void buttonBlockOutdoor_Click(object sender, EventArgs e) {
      checkBoxBlockAllMovement.Checked = false;
      checkBoxAllowWalk.Checked = false;
      checkBoxAllowHorse.Checked = false;
      checkBoxAllowRaft.Checked = false;
      checkBoxAllowShip.Checked = false;
      checkBoxAllowMagicDisc.Checked = false;
      checkBoxAllowEagle.Checked = true;
      checkBoxAllowFly.Checked = true;
      checkBoxAllowSwim.Checked = false;
      checkBoxAllowBroom.Checked = true;
      checkBoxAllowSandLizard.Checked = false;
      checkBoxAllowSandShip.Checked = false;
      checkBoxAllowUnused1.Checked = false;
      checkBoxAllowUnused2.Checked = false;
      checkBoxAllowUnused3.Checked = false;
      checkBoxAllowUnused4.Checked = false;
    }
    #endregion
    #region --- button free in: click -------------------------------------------------------------
    private void buttonFreeIn_Click(object sender, EventArgs e) {
      checkBoxBlockAllMovement.Checked = false;
      checkBoxAllowWalk.Checked = true;
      checkBoxAllowHorse.Checked = false;
      checkBoxAllowRaft.Checked = false;
      checkBoxAllowShip.Checked = false;
      checkBoxAllowMagicDisc.Checked = false;
      checkBoxAllowEagle.Checked = false;
      checkBoxAllowFly.Checked = true;
      checkBoxAllowSwim.Checked = false;
      checkBoxAllowBroom.Checked = false;
      checkBoxAllowSandLizard.Checked = false;
      checkBoxAllowSandShip.Checked = false;
      checkBoxAllowUnused1.Checked = false;
      checkBoxAllowUnused2.Checked = false;
      checkBoxAllowUnused3.Checked = false;
      checkBoxAllowUnused4.Checked = false;
    }
    #endregion
    #region --- button free out: click ------------------------------------------------------------
    private void buttonFreeOut_Click(object sender, EventArgs e) {
      checkBoxBlockAllMovement.Checked = false;
      checkBoxAllowWalk.Checked = true;
      checkBoxAllowHorse.Checked = true;
      checkBoxAllowRaft.Checked = false;
      checkBoxAllowShip.Checked = false;
      checkBoxAllowMagicDisc.Checked = true;
      checkBoxAllowEagle.Checked = true;
      checkBoxAllowFly.Checked = true;
      checkBoxAllowSwim.Checked = false;
      checkBoxAllowBroom.Checked = true;
      checkBoxAllowSandLizard.Checked = false;
      checkBoxAllowSandShip.Checked = false;
      checkBoxAllowUnused1.Checked = false;
      checkBoxAllowUnused2.Checked = false;
      checkBoxAllowUnused3.Checked = false;
      checkBoxAllowUnused4.Checked = false;
    }
    #endregion
    #region --- button swim: click ----------------------------------------------------------------
    private void buttonSwim_Click(object sender, EventArgs e) {
      checkBoxBlockAllMovement.Checked = false;
      checkBoxAllowWalk.Checked = true;
      checkBoxAllowHorse.Checked = false;
      checkBoxAllowRaft.Checked = true;
      checkBoxAllowShip.Checked = true;
      checkBoxAllowMagicDisc.Checked = true;
      checkBoxAllowEagle.Checked = true;
      checkBoxAllowFly.Checked = true;
      checkBoxAllowSwim.Checked = true;
      checkBoxAllowBroom.Checked = true;
      checkBoxAllowSandLizard.Checked = false;
      checkBoxAllowSandShip.Checked = false;
      checkBoxAllowUnused1.Checked = false;
      checkBoxAllowUnused2.Checked = false;
      checkBoxAllowUnused3.Checked = false;
      checkBoxAllowUnused4.Checked = false;
    }
    #endregion
    #region --- checkbox alternate: check changed -------------------------------------------------
    private void checkBoxAlternate_CheckedChanged(object sender, EventArgs e) {
      this.timerAnimation.Stop();
      _frame = 0;
      _animateForward = true;
      panelImage.Refresh();
      this.timerAnimation.Start();
    }
    #endregion
    #region --- checkbox block all movement: checked changed --------------------------------------
    private void checkBoxBlockAllMovement_CheckedChanged(object sender, EventArgs e) {
      groupBoxAllowMovement.Enabled = !checkBoxBlockAllMovement.Checked;
    }
    #endregion
    #region --- checkbox random animation start: check changed ------------------------------------
    private void checkBoxRandomAnimationStart_CheckedChanged(object sender, EventArgs e) {
      this.timerAnimation.Stop();
      _frame = checkBoxRandomAnimationStart.Checked && Tile.NumAnimationFrames > 1 ? _random.Next() % (uint)Tile.NumAnimationFrames : 0u;
      _animateForward = true;
      panelImage.Refresh();
      this.timerAnimation.Start();
    }
    #endregion
    #region --- draw panel color: click -----------------------------------------------------------
    private void drawPanelColor_Click(object sender, EventArgs e) {
      Tile.ColorIndex = (byte)((Tile.ColorIndex + 1) % 32);
      UpdateColor();
    }
    #endregion
    #region --- menu export image: click ----------------------------------------------------------
    private void toolStripMenuItemExportImage_Click(object sender, EventArgs e) {
      //var dialog = new SaveDialog(configuration, Configuration.ImagePathName, "Export tile graphic", "png");
      //dialog.Filter = "Portable Network Graphics (*.png)|*.png|Amiga Bit Planes (*.abp)|*.abp|All Files (*.*)|*.*";
      //dialog.FileName = $"{Tile.GraphicIndex:000}";

      //if (dialog.ShowDialog(this) == DialogResult.OK) {
      //  try {
      //    if (dialog.FileName.ToLower().EndsWith(".png")) {
      //      // PNG
      //      var image = imageCache.GetImage(tileset.Index, Tile.GraphicIndex - 1, paletteIndex);
      //      image.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
      //    } else {
      //      // Amiga Bitplanes
      //      System.IO.File.WriteAllBytes(dialog.FileName, imageCache.GetBitplaneData(tileset.Index, Tile.GraphicIndex - 1));
      //    }

      //    MessageBox.Show(this, "Tile graphic was saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
      //  } catch (Exception ex) {
      //    MessageBox.Show(this, "Error saving file." + Environment.NewLine + "Error: " + ex.Message,
      //        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //  }
      //}
    }
    #endregion
    #region --- nud combat background: value changed ----------------------------------------------
    private void numericUpDownCombatBackground_ValueChanged(object sender, EventArgs e) {
      if (!_initialize)
        panelCombatBackground.BackgroundImage = _combatGraphics[(uint)numericUpDownCombatBackground.Value];
        panelCombatBackground.ClientSize = new(320, 95);
    }
    #endregion
    #region --- nud image index: value changed ----------------------------------------------------
    private void numericUpDownImageIndex_ValueChanged(object sender, EventArgs e) {
      Tile.GraphicIndex = (uint)numericUpDownImageIndex.Value;
      panelImage.Refresh();
    }
    #endregion
    #region --- panel image: paint ----------------------------------------------------------------
    private void panelImage_Paint(object sender, PaintEventArgs e) {
      var rect = new Rectangle(0, 0, 32, 32);

      try {
        var image = _imageCache.GetImage(_tileset.Index, Tile.GraphicIndex + _frame - 1, _paletteIndex);
        e.Graphics.DrawImage(image, rect);
      } catch {
        using var errorBrush = new SolidBrush(Color.White);
        using var errorFont = new Font(FontFamily.GenericMonospace, 8.0f);
        using var errorFontBrush = new SolidBrush(Color.Red);
        e.Graphics.FillRectangle(errorBrush, rect);
        e.Graphics.DrawString("X", errorFont, errorFontBrush, rect.X + 3, rect.Y);
      }
    }
    #endregion
    #region --- timer animation: tick -------------------------------------------------------------
    private void timerAnimation_Tick(object sender, EventArgs e) {
      if (Tile.NumAnimationFrames <= 1)
        _frame = 0;
      else {
        bool alternate = checkBoxAlternate.Checked;
        if (!alternate)
          _animateForward = true;
        if (_animateForward) {
          if (++_frame == Tile.NumAnimationFrames) {
            if (alternate) {
              _animateForward = false;
              --_frame;
            } else {
              _frame = 0;
            }
          }
        } else {
          if (--_frame == 0) {
            _animateForward = true;
            _frame = 1;
          }
        }
      }

      panelImage.Refresh();
    }
    #endregion
    #region --- trackbar frames: value changed ----------------------------------------------------
    private void trackBarFrames_ValueChanged(object sender, EventArgs e) {
      Tile.NumAnimationFrames = trackBarFrames.Value;
      labelFrames.Text = $"Frames: {trackBarFrames.Value}";

      if (!_initialize)
        panelImage.Refresh();
    }
    #endregion
    #region --- update color ----------------------------------------------------------------------
    private void UpdateColor() {
      drawPanelColor.BackColor = _imageCache.GetPaletteColor(_paletteIndex, Tile.ColorIndex);
    }
    #endregion
  }
}