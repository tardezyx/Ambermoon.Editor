using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Helper;
using AmbermoonMapEditor2D;

namespace Ambermoon.Editor.Gui.Editors
{
	partial class EditTileForm : CustomForm
	{
		#region --- fields ----------------------------------------------------------------------------
		private bool _animateForward = true;
		private readonly Dictionary<uint, Bitmap> _combatGraphics;
		private uint _frame = 0;
		private readonly ImageCache _imageCache;
		private bool _initialize = true;
		private readonly uint _paletteIndex;
		private readonly Random _random = new();
		private readonly Tileset2DData _tileset;
		private const int _timePerFrame = 166;
		#endregion
		#region --- properties ------------------------------------------------------------------------
		internal Tile2DIconData Tile { get; private set; }
		#endregion

		#region --- constructor -----------------------------------------------------------------------
		public EditTileForm
		(
			Tile2DIconData tile,
			Tileset2DData tileset,
			ImageCache imageCache,
			uint paletteIndex,
			Dictionary<uint, Bitmap> combatGraphics
		)
		{
			_combatGraphics = combatGraphics;
			_imageCache = imageCache;
			_paletteIndex = paletteIndex;
			_tileset = tileset;

			Tile = tile.Copy();

			InitializeComponent();

			checkBoxAllowBroom.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.WitchBroom);
			checkBoxAllowEagle.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Eagle);
			checkBoxAllowFly.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Fly);
			checkBoxAllowHorse.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Horse);
			checkBoxAllowMagicDisc.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.MagicalDisc);
			checkBoxAllowRaft.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Raft);
			checkBoxAllowSandLizard.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.SandLizard);
			checkBoxAllowSandShip.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.SandShip);
			checkBoxAllowShip.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Ship);
			checkBoxAllowSwim.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Swim);
			checkBoxAllowWasp.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Wasp);
			checkBoxAllowUnused13.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Unused13);
			checkBoxAllowUnused14.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Unused14);
			checkBoxAllowUnused15.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Unused15);
			checkBoxAllowWalk.Checked = tile.AllowedTravelTypes.HasFlag(AllowedTravelTypes.Walk);
			checkBoxAutoPoison.Checked = tile.AutoPoison;
			//checkBoxAlternate.Checked            = tile.Flags.HasFlag(TileFlags.AlternateAnimation);
			checkBoxBackgroundFlags.Checked = tile.UseBackgroundTileFlags;
			checkBoxBlockAllMovement.Checked = tile.AllowedTravelTypes == AllowedTravelTypes.None;
			checkBoxBlockSight.Checked = tile.BlockSight;
			checkBoxHidePlayer.Checked = tile.HidePlayer;
			checkBoxRandomAnimation.Checked = tile.RandomAnimation;

			comboBoxSitSleep.SelectedIndex = (int)tile.Type % 6;

			numericUpDownCombatBackground.Value = tile.CombatBackgroundIndex;
			numericUpDownImageIndex.Value = tile.GraphicIndex;
			trackBarFrames.Value = Math.Max(1, (int)tile.NumberOfFrames);

			radioButtonAlwaysBelow.Checked = tile.RenderOrder == Tile2DRenderOrder.AlwaysBelowPlayer;
			radioButtonAlwaysAbove.Checked = tile.RenderOrder == Tile2DRenderOrder.AlwaysAbovePlayer;
			radioButtonNormal.Checked = tile.RenderOrder == Tile2DRenderOrder.Normal;

			UpdateColor();

			timerAnimation.Interval = _timePerFrame;
			timerAnimation.Start();

			_initialize = false;
		}
		#endregion

		#region --- button apply: click ---------------------------------------------------------------
		private void ButtonApply_Click(object? sender, EventArgs e)
		{
			var tile = new Tile2DIconData();

			if (checkBoxAllowBroom.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.WitchBroom;
			if (checkBoxAllowEagle.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Eagle;
			if (checkBoxAllowFly.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Fly;
			if (checkBoxAllowHorse.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Horse;
			if (checkBoxAllowMagicDisc.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.MagicalDisc;
			if (checkBoxAllowRaft.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Raft;
			if (checkBoxAllowSandLizard.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.SandLizard;
			if (checkBoxAllowSandShip.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.SandShip;
			if (checkBoxAllowShip.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Ship;
			if (checkBoxAllowSwim.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Swim;
			if (checkBoxAllowWasp.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Wasp;
			if (checkBoxAllowUnused13.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Unused13;
			if (checkBoxAllowUnused14.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Unused14;
			if (checkBoxAllowUnused15.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Unused15;
			if (checkBoxAllowWalk.Checked)
				tile.AllowedTravelTypes |= AllowedTravelTypes.Walk;
			tile.WaveAnimation = checkBoxAlternate.Checked;
			tile.UseBackgroundTileFlags = checkBoxBackgroundFlags.Checked;
			tile.HidePlayer = checkBoxHidePlayer.Checked;
			tile.BlockSight = checkBoxBlockSight.Checked;
			tile.RandomAnimation = checkBoxRandomAnimation.Checked;
			tile.AutoPoison = checkBoxAutoPoison.Checked;
			if (radioButtonAlwaysBelow.Checked)
				tile.RenderOrder = Tile2DRenderOrder.AlwaysBelowPlayer;
			else if (radioButtonAlwaysAbove.Checked)
				tile.RenderOrder = Tile2DRenderOrder.AlwaysAbovePlayer;

			if (tile.Type != Tile2DType.Water)
				tile.Type = (Tile2DType)comboBoxSitSleep.SelectedIndex;

			tile.CombatBackgroundIndex = (uint)numericUpDownCombatBackground.Value;
			Tile = tile;

			DialogResult = DialogResult.OK;
		}
		#endregion
		#region --- button block indoor: click --------------------------------------------------------
		private void ButtonBlockIndoor_Click(object? sender, EventArgs e)
		{
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
			checkBoxAllowWasp.Checked = false;
			checkBoxAllowUnused13.Checked = false;
			checkBoxAllowUnused14.Checked = false;
			checkBoxAllowUnused15.Checked = false;
		}
		#endregion
		#region --- button block outdoor: click -------------------------------------------------------
		private void ButtonBlockOutdoor_Click(object? sender, EventArgs e)
		{
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
			checkBoxAllowWasp.Checked = false;
			checkBoxAllowUnused13.Checked = false;
			checkBoxAllowUnused14.Checked = false;
			checkBoxAllowUnused15.Checked = false;
		}
		#endregion
		#region --- button free in: click -------------------------------------------------------------
		private void ButtonFreeIn_Click(object? sender, EventArgs e)
		{
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
			checkBoxAllowWasp.Checked = false;
			checkBoxAllowUnused13.Checked = false;
			checkBoxAllowUnused14.Checked = false;
			checkBoxAllowUnused15.Checked = false;
		}
		#endregion
		#region --- button free out: click ------------------------------------------------------------
		private void ButtonFreeOut_Click(object? sender, EventArgs e)
		{
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
			checkBoxAllowWasp.Checked = false;
			checkBoxAllowUnused13.Checked = false;
			checkBoxAllowUnused14.Checked = false;
			checkBoxAllowUnused15.Checked = false;
		}
		#endregion
		#region --- button swim: click ----------------------------------------------------------------
		private void ButtonSwim_Click(object? sender, EventArgs e)
		{
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
			checkBoxAllowWasp.Checked = false;
			checkBoxAllowUnused13.Checked = false;
			checkBoxAllowUnused14.Checked = false;
			checkBoxAllowUnused15.Checked = false;
		}
		#endregion
		#region --- checkbox alternate: check changed -------------------------------------------------
		private void CheckBoxAlternate_CheckedChanged(object? sender, EventArgs e)
		{
			this.timerAnimation.Stop();
			_frame = 0;
			_animateForward = true;
			panelImage?.Refresh();
			this.timerAnimation.Start();
		}
		#endregion
		#region --- checkbox block all movement: checked changed --------------------------------------
		private void CheckBoxBlockAllMovement_CheckedChanged(object? sender, EventArgs e)
		{
			groupBoxAllowMovement.Enabled = !checkBoxBlockAllMovement.Checked;
		}
		#endregion
		#region --- checkbox random animation start: check changed ------------------------------------
		private void CheckBoxRandomAnimationStart_CheckedChanged(object? sender, EventArgs e)
		{
			this.timerAnimation.Stop();
			// TODO
			_frame = checkBoxRandomAnimation.Checked && Tile.NumberOfFrames > 1 ? _random.Next() % (uint)Tile.NumberOfFrames : 0u;
			_animateForward = true;
			panelImage?.Refresh();
			this.timerAnimation.Start();
		}
		#endregion
		#region --- draw panel color: click -----------------------------------------------------------
		private void DrawPanelColor_Click(object? sender, EventArgs e)
		{
			Tile.ColorIndex = (byte)((Tile.ColorIndex + 1) % 32);
			UpdateColor();
		}
		#endregion
		#region --- menu export image: click ----------------------------------------------------------
		private void ToolStripMenuItemExportImage_Click(object? sender, EventArgs e)
		{
			var dialog = new ImageExportDialog("Export tile graphic")
			{
				Filter = "Portable Network Graphics (*.png)|*.png|Windows Bitmaps (*.bmp)|*.bmp|All Files (*.*)|*.*",
				FileName = $"{Tile.GraphicIndex:000}"
			};

			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					var image = _imageCache.GetImage(_tileset.Index, Tile.GraphicIndex - 1, _paletteIndex);
					image.Save(dialog.FileName, dialog.FileName.ToLower().EndsWith(".bmp") ? System.Drawing.Imaging.ImageFormat.Bmp : System.Drawing.Imaging.ImageFormat.Png);

					MessageBox.Show(this, "Tile graphic was saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, "Error saving file." + Environment.NewLine + "Error: " + ex.Message,
						"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		#endregion
		#region --- nud combat background: value changed ----------------------------------------------
		private void NumericUpDownCombatBackground_ValueChanged(object? sender, EventArgs e)
		{
			if (!_initialize)
				panelCombatBackground.BackgroundImage = _combatGraphics[(uint)numericUpDownCombatBackground.Value];
			panelCombatBackground.ClientSize = new(320, 95);
		}
		#endregion
		#region --- nud image index: value changed ----------------------------------------------------
		private void NumericUpDownImageIndex_ValueChanged(object? sender, EventArgs e)
		{
			Tile.GraphicIndex = (uint)numericUpDownImageIndex.Value;
			panelImage?.Refresh();
		}
		#endregion
		#region --- panel image: paint ----------------------------------------------------------------
		private void PanelImage_Paint(object? sender, PaintEventArgs e)
		{
			var rect = new Rectangle(0, 0, 32, 32);

			try
			{
				var image = _imageCache.GetImage(_tileset.Index, Tile.GraphicIndex + _frame - 1, _paletteIndex);
				e.Graphics.DrawImage(image, rect);
			}
			catch
			{
				using var errorBrush = new SolidBrush(System.Drawing.Color.White);
				using var errorFont = new Font(FontFamily.GenericMonospace, 8.0f);
				using var errorFontBrush = new SolidBrush(System.Drawing.Color.Red);
				e.Graphics.FillRectangle(errorBrush, rect);
				e.Graphics.DrawString("X", errorFont, errorFontBrush, rect.X + 3, rect.Y);
			}
		}
		#endregion
		#region --- timer animation: tick -------------------------------------------------------------
		private void TimerAnimation_Tick(object? sender, EventArgs e)
		{
			if (Tile.NumberOfFrames <= 1)
				_frame = 0;
			else
			{
				bool alternate = checkBoxAlternate.Checked;
				if (!alternate)
					_animateForward = true;
				if (_animateForward)
				{
					if (++_frame == Tile.NumberOfFrames)
					{
						if (alternate)
						{
							_animateForward = false;
							--_frame;
						}
						else
						{
							_frame = 0;
						}
					}
				}
				else
				{
					if (--_frame == 0)
					{
						_animateForward = true;
						_frame = 1;
					}
				}
			}

			panelImage?.Refresh();
		}
		#endregion
		#region --- trackbar frames: value changed ----------------------------------------------------
		private void TrackBarFrames_ValueChanged(object? sender, EventArgs e)
		{
			Tile.NumberOfFrames = (uint)trackBarFrames.Value;
			labelFrames.Text = $"Frames: {trackBarFrames.Value}";

			if (!_initialize)
				panelImage?.Refresh();
		}
		#endregion
		#region --- update color ----------------------------------------------------------------------
		private void UpdateColor()
		{
			drawPanelColor.BackColor = _imageCache.GetPaletteColor(_paletteIndex, Tile.ColorIndex);
		}
		#endregion
	}
}