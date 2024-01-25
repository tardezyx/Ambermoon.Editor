using Ambermoon.Data;
using Ambermoon.Data.Enumerations;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Data.Legacy;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Helper;
using System.ComponentModel;
using System.Drawing.Imaging;

//using NAudio.Wave;
using Color = System.Drawing.Color;
using Cursor = System.Windows.Forms.Cursor;
using Cursors = System.Windows.Forms.Cursors;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditMap2DForm : CustomForm {
    #region --- local enum: tool ------------------------------------------------------------------
    private enum Tool {
      Brush,
      Blocks2x2,
      Blocks3x2,
      Blocks3x3,
      Fill,
      ColorPicker,
      RemoveFrontLayer,
      EventChanger,
      PositionPicker
    }
    #endregion
    #region --- fields ----------------------------------------------------------------------------
    private                 Tool                              blocksTool = Tool.Blocks2x2;
    private                 bool                              choosingTileSlotForDuplicating = false;
    private                 Dictionary<uint, Bitmap>          combatBackgrounds = new(16);
    private                 bool                              compressGameData = false;
    //private                 Configuration                     configuration;
    private                 Cursor                            cursorColorPicker;
    private                 Cursor                            cursorEraser;
    private                 Cursor                            cursorPrecision;
    private                 Cursor                            cursorPointer;
    private                 int                               currentLayer = 0;
    private                 int                               currentTilesetTiles = 0;
    private                 Tool                              currentTool = Tool.Brush;
    private                 ulong                             frame = 0;
    private                 string                            gameDataPath;
    private                 ILegacyGameData                   gameData;
    private                 GraphicProvider2D                 graphicProvider;
    private                 History                           history = new();
    private                 int                               hoveredMapTile = -1;
    private                 int                               hoveredTilesetTile = -1;
    private                 ImageCache                        imageCache;
    private                 Song?                             lastSong = null;
    private static readonly string[]                          LayerName = [ "Back Layer", "Front Layer" ];
    //private                 Map                               map;
    private                 MapData                           map;
    private                 int                               MapHeight => map?.Height ?? (int)numericUpDownHeight.Value;
    private                 bool                              mapLoading = false;
    private                 MapManager                        mapManager;
    private                 Panel                             mapScrollIndicator = new();
    private                 int                               MapWidth => map?.Width ?? (int)numericUpDownWidth.Value;
    //private                 Dictionary<Song, WaveStream>      musicCache = new Dictionary<Song, WaveStream>();
    private                 Song?                             playingSong = null;
    private                 string?                           saveFileName = null;
    private                 bool                              saveIntoGameData = false;
    private                 int                               selectedMapCharacter = -1;
    private                 int                               selectedTilesetTile = 0;
    private                 bool                              showEvents = false;
    private                 bool                              showGrid = false;
    private                 bool                              showTileMarker = true;
    private                 IReadOnlyDictionary<Song, string> songNames;
    private const           int                               _timePerFrame = 166;
    private                 int                               tileMarkerHeight = 0;
    private                 int                               tileMarkerWidth = 0;
    private                 Dictionary<uint, Tileset>         tilesets;
    private                 Panel                             tilesetScrollIndicator = new();
    // Note: Every tileset seems to have exactly 2500 tile slots (but many are unused).
    private const           int                               TilesetTilesPerRow = 42;
    private                 string                            title;
    private                 bool                              unsavedChanges = false;
    private                 bool                              unsavedChangesBesideHistory = false;
    //private                 IWavePlayer                       wavePlayer = new WaveOut();
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditMap2DForm(MapData map) {
      InitializeComponent();

      title = Text;
    }
    #endregion
    #region --- on closing ------------------------------------------------------------------------
    protected override void OnClosing(CancelEventArgs e) {
      base.OnClosing(e);

      //if (unsavedChanges) {
      //  var result = MessageBox.Show(this, "There are unsaved changes. Do you want to save them now?",
      //      "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

      //  if (result == DialogResult.Cancel) {
      //    e.Cancel = true;
      //    return;
      //  }

      //  if (result == DialogResult.Yes) {
      //    var saveResult = Save();

      //    if (saveResult == SaveResult.Error) {
      //      if (MessageBox.Show(this, "Error saving the map. Do you want to abort and return to your current map?",
      //          "Unable to save map", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) {
      //        e.Cancel = true;
      //        return;
      //      }
      //    } else if (saveResult == SaveResult.Cancelled) {
      //      e.Cancel = true;
      //      return;
      //    }
      //  }
      //}
    }
    #endregion
    #region --- on key down -----------------------------------------------------------------------
    protected override void OnKeyDown(KeyEventArgs e) {
      base.OnKeyDown(e);

      if (e.KeyCode == Keys.Escape) {
        choosingTileSlotForDuplicating = false;
      }
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      //configuration = Configuration.Load(Configuration.FilePath);

      Refresh();
      //gameDataPath = openMapForm.GameDataPath;
      //gameData = openMapForm.GameData;
      //tilesets = openMapForm.Tilesets;
      //mapManager = openMapForm.MapManager;
      //currentTilesetTiles = tilesets[openMapForm.Map.TilesetOrLabdataIndex].Tiles.Length;
      Initialize();
      //InitializeMap(openMapForm.Map?.Clone());
      history.Clear();
      toolStripMenuItemEditUndo.Enabled = false;
      toolStripMenuItemEditRedo.Enabled = false;

      graphicProvider = new GraphicProvider2D(combatBackgrounds, gameData, imageCache, tilesets) {
        PaletteIndex = map.PaletteIndex
      };
      //mapCharEditorControl.Init(map, gameData, graphicProvider, SaveImage);

      //selectedMapCharacter = mapCharEditorControl.Count == 0 ? -1 : 0;
      UpdateMapCharacterButtons();
      WireEvents();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      comboBoxMusic.SelectedIndexChanged += (s, e) => {
        //StopMusic();
        //map.MusicIndex = (uint)(comboBoxMusic.SelectedIndex + 1);
        MarkAsDirty();
      };

      buttonPlaceCharacterOnMap.Click              += (s, e) => SelectTool(Tool.PositionPicker);
      buttonToggleEvents.Click                     += (s, e) => ToggleEvents();
      buttonToolBlocks.Click                       += (s, e) => SelectTool(blocksTool);
      buttonToolBrush.Click                        += (s, e) => SelectTool(Tool.Brush);
      buttonToolColorPicker.Click                  += (s, e) => SelectTool(Tool.ColorPicker);
      buttonToolFill.Click                         += (s, e) => SelectTool(Tool.Fill);
      buttonToolRemoveFrontLayer.Click             += (s, e) => SelectTool(Tool.RemoveFrontLayer);
      checkBoxMagic.CheckedChanged                 += (s, e) => UpdateMapFlags();
      checkBoxMarkUnusedTiles.CheckedChanged       += (s, e) => panelTileset.Refresh();
      checkBoxNoSleepUntilDawn.CheckedChanged      += (s, e) => UpdateMapFlags();
      checkBoxTravelGraphics.CheckedChanged        += (s, e) => UpdateMapFlags();
      checkBoxUnknown1.CheckedChanged              += (s, e) => UpdateMapFlags();
      //comboBoxWorld.SelectedIndexChanged           += (s, e) => { map.World = (World)comboBoxWorld.SelectedIndex; MarkAsDirty(); };
      history.RedoGotEmpty                         += ()     => toolStripMenuItemEditRedo.Enabled = false;
      history.RedoGotFilled                        += ()     => toolStripMenuItemEditRedo.Enabled = true;
      history.UndoGotEmpty                         += ()     => toolStripMenuItemEditUndo.Enabled = false;
      history.UndoGotFilled                        += ()     => toolStripMenuItemEditUndo.Enabled = true;
      //mapCharEditorControl.CurrentCharacterChanged += (s, e) => UpdateMapCharacterButtons();
      //mapCharEditorControl.DirtyChanged            += (s, e) => { if (mapCharEditorControl.Dirty) { MarkAsDirty(); } };
      //mapCharEditorControl.SelectionChanged        += (s, e) => { selectedMapCharacter = index; UpdateMapCharacterButtons(); };
      radioButtonDungeon.CheckedChanged            += (s, e) => MapTypeChanged();
      radioButtonIndoor.CheckedChanged             += (s, e) => MapTypeChanged();
      radioButtonOutdoor.CheckedChanged            += (s, e) => MapTypeChanged();
      panelMap.Paint                               += (s, e) => PaintMap(e.Graphics, true);
      panelMap.Scroll                              += (s, e) => panelMap.Refresh();
      toolStripMenuItemEditUndo.Click              += (s, e) => { history.Undo(); CheckHistoryUnsavedChanges(); };
      toolStripMenuItemEditRedo.Click              += (s, e) => { history.Redo(); CheckHistoryUnsavedChanges(); };
      toolStripMenuItemMapSave.Click               += (s, e) => { /*Save();*/ };
      toolStripMenuItemMapQuit.Click               += (s, e) => Close();
      toolStripMenuItemShowBackLayer.Click         += (s, e) => panelMap.Refresh();
      toolStripMenuItemShowFrontLayer.Click        += (s, e) => panelMap.Refresh();
      toolStripMenuShowAllowDisc.Click             += (s, e) => panelMap.Refresh();
      toolStripMenuShowAllowHorse.Click            += (s, e) => panelMap.Refresh();
      toolStripMenuShowAllowRaft.Click             += (s, e) => panelMap.Refresh();
      toolStripMenuShowAllowShip.Click             += (s, e) => panelMap.Refresh();
      toolStripMenuShowAllowWalk.Click             += (s, e) => panelMap.Refresh();
      trackBarZoom.Scroll                          += (s, e) => MapSizeChanged();

      buttonDuplicateTile.Click                += buttonDuplicateTile_Click;
      buttonEditTile.Click                     += buttonEditTile_Click;
      buttonExportTileset.Click                += buttonExportTileset_Click;
      buttonIndoorDefaults.Click               += buttonIndoorDefaults_Click;
      buttonPlaceCharacterOnMap.EnabledChanged += buttonPlaceCharacterOnMap_EnabledChanged;
      buttonPositions.Click                    += buttonPositions_Click;
      buttonResize.Click                       += buttonResize_Click;
      buttonToggleGrid.Click                   += buttonToggleGrid_Click;
      buttonToggleMusic.Click                  += buttonToggleMusic_Click;
      buttonToggleTileMarker.Click             += buttonToggleTileMarker_Click;
      buttonToolEventChanger.Click             += buttonToolEventChanger_Click;
      buttonToolLayers.Click                   += buttonToolLayers_Click;
      buttonWorldMapDefaults.Click             += buttonWorldMapDefaults_Click;
      checkBoxResting.CheckedChanged           += checkBoxResting_CheckedChanged;
      checkBoxWorldSurface.CheckedChanged      += checkBoxWorldSurface_CheckedChanged;
      comboBoxPalettes.SelectedIndexChanged    += comboBoxPalettes_SelectedIndexChanged;
      comboBoxTilesets.SelectedIndexChanged    += comboBoxTilesets_SelectedIndexChanged;
      numericUpDownHeight.ValueChanged         += numericUpDownHeight_ValueChanged;
      numericUpDownWidth.ValueChanged          += numericUpDownWidth_ValueChanged;
      panelMap.MouseDown                       += panelMap_MouseDown;
      panelMap.MouseLeave                      += panelMap_MouseLeave;
      panelMap.MouseMove                       += panelMap_MouseMove;
      panelTileset.MouseDown                   += panelTileset_MouseDown;
      panelTileset.MouseLeave                  += panelTileset_MouseLeave;
      panelTileset.MouseMove                   += panelTileset_MouseMove;
      panelTileset.Paint                       += panelTileset_Paint;
      timerAnimation.Tick                      += timerAnimation_Tick;
      toolStripMenuItemBackLayer.Click         += toolStripMenuItemBackLayer_Click;
      toolStripMenuItemBlocks2x2.Click         += toolStripMenuItemBlocks2x2_Click;
      toolStripMenuItemBlocks3x2.Click         += toolStripMenuItemBlocks3x2_Click;
      toolStripMenuItemBlocks3x3.Click         += toolStripMenuItemBlocks3x3_Click;
      toolStripMenuItemFrontLayer.Click        += toolStripMenuItemFrontLayer_Click;
      toolStripMenuItemMapNew.Click            += toolStripMenuItemMapNew_Click;
      toolStripMenuItemMapSaveAs.Click         += toolStripMenuItemMapSaveAs_Click;
      toolStripMenuItemMapSaveAsPNG.Click      += toolStripMenuItemMapSaveAsPNG_Click;
    }
    #endregion
    
    #region --- ask yes no ------------------------------------------------------------------------
    private bool AskYesNo(string question) {
      return MessageBox.Show(
        this,
        question,
        "Question",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) == DialogResult.Yes;
    }
    #endregion
    #region --- button from tool ------------------------------------------------------------------
    private Button? ButtonFromTool(Tool tool) {
      return tool switch {
        Tool.Brush            => buttonToolBrush,
        Tool.Blocks2x2
        or Tool.Blocks3x2
        or Tool.Blocks3x3     => buttonToolBlocks,
        Tool.Fill             => buttonToolFill,
        Tool.ColorPicker      => buttonToolColorPicker,
        Tool.RemoveFrontLayer => buttonToolRemoveFrontLayer,
        Tool.EventChanger     => buttonToolEventChanger,
        Tool.PositionPicker   => buttonPlaceCharacterOnMap,
        _                     => null,
      };
    }
    #endregion
    #region --- change event ----------------------------------------------------------------------
    private void ChangeEvent(int x, int y, bool remove) {
      if (remove) {
        if (map.Tiles2D[x, y].MapEventId != 0) {
          map.Tiles2D[x, y].MapEventId = 0;

          if (showEvents)
            panelMap.Refresh();
        }
      } else {
        //var eventIdSelector = new EventIdSelectionForm(map, map.Tiles2D[x, y].MapEventId);

        //if (eventIdSelector.ShowDialog() == DialogResult.OK) {
        //  uint newId = eventIdSelector.EventId;

        //  if (map.Tiles2D[x, y].MapEventId != newId) {
        //    map.Tiles2D[x, y].MapEventId = newId;

        //    if (showEvents)
        //      panelMap.Refresh();
        //  }
        //}
      }
    }
    #endregion
    #region --- check history unsaved changes -----------------------------------------------------
    private void CheckHistoryUnsavedChanges() {
      if (unsavedChanges && !unsavedChangesBesideHistory && !history.Dirty) {
        unsavedChanges = false;
        Text = title;
      } else if (history.Dirty) {
        MarkAsDirty(true);
      }
    }
    #endregion
    #region --- clean up --------------------------------------------------------------------------
    //private void CleanUp() {
    //  playingSong = null;
    //  wavePlayer?.Stop();
    //  wavePlayer?.Dispose();
    //  wavePlayer = null;
    //  musicCache.Clear();
    //}
    #endregion
    #region --- cursor from tool ------------------------------------------------------------------
    private Cursor? CursorFromTool(Tool tool) {
      return tool switch {
        Tool.Brush or Tool.EventChanger => cursorPointer,
        Tool.Blocks2x2 or Tool.Blocks3x2 or Tool.Blocks3x3 => cursorPointer,
        Tool.Fill => cursorPointer,
        Tool.ColorPicker => cursorColorPicker,
        Tool.RemoveFrontLayer => cursorEraser,
        Tool.PositionPicker => cursorPrecision,
        _ => null,
      };
    }
    #endregion
    #region --- fill tiles ------------------------------------------------------------------------
    private void FillTiles(int x, int y, bool areaOnly) {
      var oldTile = map.Tiles2D[x, y];
      uint oldTileIndex = currentLayer == 0 ? oldTile.BackTileIndex : oldTile.FrontTileIndex;
      uint newTileIndex = 1 + (uint)selectedTilesetTile;

      if (oldTileIndex == newTileIndex)
        return;

      var changedTiles = new Dictionary<int, uint>();
      int layer = currentLayer;

      string doText = $"Change tiles from {oldTileIndex} to {newTileIndex} on {LayerName[layer]}";
      string undoText = $"Change tiles from {newTileIndex} to {oldTileIndex} on {LayerName[layer]}";

      PerformAction(doText, undoText, _ => {
        if (areaOnly) {
          var areaFiller = new AreaFiller(map);
          areaFiller.Fill(x, y, newTileIndex, layer, changedTiles);
        } else {
          int tileIndex = 0;
          foreach (var tile in map.Tiles2D) {
            if (layer == 0) {
              if (tile.BackTileIndex == oldTileIndex) {
                changedTiles.Add(tileIndex, tile.BackTileIndex);
                tile.BackTileIndex = newTileIndex;
              }
            } else {
              if (tile.FrontTileIndex == oldTileIndex) {
                changedTiles.Add(tileIndex, tile.FrontTileIndex);
                tile.FrontTileIndex = newTileIndex;
              }
            }

            ++tileIndex;
          }
        }
        panelMap.Refresh();
      }, () => {
        foreach (var changedTile in changedTiles) {
          int x = changedTile.Key % map.Width;
          int y = changedTile.Key / map.Width;
          if (layer == 0) {
            map.Tiles2D[x, y].BackTileIndex = changedTile.Value;
          } else {
            map.Tiles2D[x, y].FrontTileIndex = changedTile.Value;
          }
        }
        panelMap.Refresh();
      });
    }
    #endregion
    #region --- image from tool -------------------------------------------------------------------
    private static Bitmap? ImageFromTool(Tool tool, bool withArrowIfAvailable) {
      return tool switch {
        Tool.Brush => Properties.Resources.round_brush_black_24,
        Tool.Blocks2x2 => withArrowIfAvailable
          ? Properties.Resources.round_grid_view_black_24_with_arrow
          : Properties.Resources.round_grid_view_black_24,
        Tool.Blocks3x2 => withArrowIfAvailable
          ? Properties.Resources.round_view_module_black_24_with_arrow
          : Properties.Resources.round_view_module_black_24,
        Tool.Blocks3x3 => withArrowIfAvailable
          ? Properties.Resources.round_apps_black_24_with_arrow
          : Properties.Resources.round_apps_black_24,
        Tool.Fill => Properties.Resources.round_format_color_fill_black_24,
        Tool.ColorPicker => Properties.Resources.round_colorize_black_24,
        Tool.RemoveFrontLayer => Properties.Resources.round_layers_clear_black_24,
        Tool.PositionPicker => Properties.Resources.round_control_camera_black_24,
        _ => null,
      };
    }
    #endregion
    #region --- initialize ------------------------------------------------------------------------
    private void Initialize() {
      cursorPointer     = CursorResourceLoader.LoadEmbeddedCursor(Properties.Resources.pointer);
      cursorColorPicker = CursorResourceLoader.LoadEmbeddedCursor(Properties.Resources.color_picker);
      cursorEraser      = CursorResourceLoader.LoadEmbeddedCursor(Properties.Resources.eraser);
      cursorPrecision   = CursorResourceLoader.LoadEmbeddedCursor(Properties.Resources.Precision);

      toolTipIndoor.SetToolTip(radioButtonIndoor, "Indoor maps are always fully lighted.");
      toolTipOutdoor.SetToolTip(radioButtonOutdoor, "Outdoor maps are affected by the day-night-cycle.");
      toolTipDungeon.SetToolTip(radioButtonDungeon, "Dungeons are dark. You'll need your own light source.");

      toolTipWorldSurface.SetToolTip(checkBoxWorldSurface, "On world maps the player is drawn smaller (16x16) and you can use and display transportation.");
      toolTipResting.SetToolTip(checkBoxResting, "Enables the rest/camp functionality on the map.");
      toolTipNoSleepUntilDawn.SetToolTip(checkBoxNoSleepUntilDawn, "If set you will always sleep for 8 hours.");
      toolTipMagic.SetToolTip(checkBoxMagic, "Enables the use of spells on the map.");

      toolTipBrush.SetToolTip(buttonToolBrush, "Draws single tiles onto the map.\r\n\r\nUse with right click to draw to the non-selected layer.");
      toolTipBlocks.SetToolTip(buttonToolBlocks, "Draws blocks of tiles onto the map.\r\n\r\nUse right click on the button to choose a block size.\r\n\r\nUse with right click to use the same tile multiple times. Otherwise it picks adjacent tiles from the tileset.");
      toolTipFill.SetToolTip(buttonToolFill, "Fills all tiles of the same type with a tile from the tileset.\r\n\r\nUse with right click to limit it to an enclosed area.");
      toolTipColorPicker.SetToolTip(buttonToolColorPicker, "Selects a map tile inside the tileset and locks it in for further drawing.\r\n\r\nUse with right click to pick from the non-selected layer instead.");
      toolTipColorPicker.SetToolTip(buttonToolRemoveFrontLayer, "Removes the front layer tile.");
      toolTipColorPicker.SetToolTip(buttonToolEventChanger, "Changes the event on a tile.\r\n\r\nUse with right click to remove the event.");
      toolTipLayers.SetToolTip(buttonToolLayers, "Opens the layers context menu where you can choose which layer to draw to and which layers to show.");
      toolTipGrid.SetToolTip(buttonToggleGrid, "Toggles the tile grid overlay.");
      toolTipTileMarker.SetToolTip(buttonToggleTileMarker, "Toggles the tile selection marker.");

      //if (gameData.Files.TryGetValue("Text.amb", out var textAmbReader)) {
      //  var textContainer = new TextContainer();
      //  new TextContainerReader().ReadTextContainer(textContainer, textAmbReader.Files[1], false);
      //  songNames = Ambermoon.Enum.GetValues<Song>().Skip(1).Take(32).ToDictionary(song => song, song => textContainer.MusicNames[(int)song - 1]);
      //} else if (gameData.Files.TryGetValue("AM2_CPU", out var asmReader)) {
      //  var stream = asmReader.Files[1];
      //  stream.Position = 0;
      //  var executableData = new ExecutableData(AmigaExecutable.Read(stream));
      //  songNames = executableData.SongNames.Entries;
      //} else {
      //  songNames = Ambermoon.Enum.GetValues<Song>().Skip(1).Take(32).ToDictionary(song => song, song => song.ToString());
      //}

      //foreach (var song in songNames)
      //  comboBoxMusic.Items.Add(song.Value);

      // TODO: what if we add one later?
      for (int i = 1; i <= 10; ++i)
        comboBoxTilesets.Items.Add($"Tileset {i}");

      imageCache = new ImageCache(gameData);

      for (int i = 1; i <= imageCache.PaletteCount; ++i)
        comboBoxPalettes.Items.Add($"Palette {i}");

      // TODO: ensure this file
      var combatBackgroundImageFiles = gameData.Files["Combat_background.amb"].Files;
      var combatGraphicInfo = new GraphicInfo {
        Alpha = false,
        GraphicFormat = GraphicFormat.Palette5Bit,
        Width = 320,
        Height = 95
      };
      for (int i = 0; i < 16; ++i) {
        var combatBackgroundInfo = CombatBackgrounds.Info2D[i];
        var reader = combatBackgroundImageFiles[(int)combatBackgroundInfo.GraphicIndex];
        reader.Position = 0;
        combatBackgrounds.Add((uint)i, imageCache.LoadImageViaPaletteIndex(reader, combatBackgroundInfo.Palettes[0], combatGraphicInfo));
      }

      mapScrollIndicator.Size = new(1, 1);
      tilesetScrollIndicator.Size = new(1, 1);
      panelMap.Controls.Add(mapScrollIndicator);
      panelTileset.Controls.Add(tilesetScrollIndicator);
      SelectTool(Tool.Brush, true);
      panelTileset.Cursor = CursorFromTool(Tool.Brush);
      timerAnimation.Interval = _timePerFrame;
    }
    #endregion
    #region --- initialize map --------------------------------------------------------------------
    private void InitializeMap(MapData map) {
      timerAnimation.Stop();
      unsavedChangesBesideHistory = false;
      unsavedChanges = false;
      title = "Ambermoon Map Editor 2D:";// {map.Name}";
      Text = title;
      history.Clear();
      this.map = map;
      mapLoading = true;

      numericUpDownWidth.Value = map.Width;
      numericUpDownHeight.Value = map.Height;

      if (map.Flags.HasFlag(MapFlags.Indoor))
        radioButtonIndoor.Checked = true;
      else if (map.Flags.HasFlag(MapFlags.Outdoor))
        radioButtonOutdoor.Checked = true;
      else if (map.Flags.HasFlag(MapFlags.Dungeon))
        radioButtonDungeon.Checked = true;

      checkBoxMagic.Checked = map.Flags.HasFlag(MapFlags.CanUseMagic);
      checkBoxNoSleepUntilDawn.Checked = map.Flags.HasFlag(MapFlags.NoSleepUntilDawn);
      checkBoxResting.Checked = map.Flags.HasFlag(MapFlags.CanRest);
      checkBoxUnknown1.Checked = map.Flags.HasFlag(MapFlags.Unknown1);
      checkBoxTravelGraphics.Checked = map.Flags.HasFlag(MapFlags.StationaryGraphics);
      checkBoxWorldSurface.Checked = map.Flags.HasFlag(MapFlags.WorldSurface);
      comboBoxWorld.SelectedIndex = (int)map.World % 3;
      //comboBoxMusic.SelectedIndex = map.MusicIndex == 0 ? (int)Song.PloddingAlong - 1 : (int)map.MusicIndex - 1;
      comboBoxTilesets.SelectedIndex = map.TilesetIndex == 0 ? 0 : (int)map.TilesetIndex - 1;
      comboBoxPalettes.SelectedIndex = map.PaletteIndex == 0 ? 0 : (int)map.PaletteIndex - 1;

      listViewEvents.Items.Clear();
      int index = 1;
      foreach (var @event in map.Events) {
        var item = listViewEvents.Items.Add(index++.ToString("x2"));
        item.SubItems.Add(@event.ToString());
      }

      MapSizeChanged();
      UpdateTileset();
      timerAnimation.Start();

      mapLoading = false;
    }
    #endregion
    #region --- load song -------------------------------------------------------------------------
    //private WaveStream LoadSong(Song song) {
    //  if (musicCache.TryGetValue(song, out var waveStream))
    //    return waveStream;

    //  var sonicArrangerFile = new SonicArranger.SonicArrangerFile(gameData.Files["Music.amb"].Files[(int)song] as DataReader);
    //  var sonicArrangerSong = new SonicArranger.Stream(sonicArrangerFile, 0, 44100, SonicArranger.Stream.ChannelMode.Mono);
    //  var stream = new System.IO.MemoryStream();
    //  sonicArrangerSong.WriteUnsignedTo(stream);
    //  stream.Position = 0;
    //  waveStream = new RawSourceWaveStream(stream, WaveFormat.CreateCustomFormat(WaveFormatEncoding.Pcm, 44100, 1, 44100, 1, 8));
    //  musicCache.Add(song, waveStream);

    //  return waveStream;
    //}
    #endregion
    #region --- local enum: save result -----------------------------------------------------------
    private enum SaveResult {
      Success,
      Error,
      Cancelled
    }
    #endregion
    #region --- map size changed ------------------------------------------------------------------
    private void MapSizeChanged() {
      // TODO: this must be part of the undo/redo chain!

      MarkAsDirty();

      int tileSize = (trackBarZoom.Maximum - trackBarZoom.Value + 1) * 16;
      mapScrollIndicator.Location = new Point(map.Width * tileSize, map.Height * tileSize);

      int visibleColumns = panelMap.Width / tileSize;
      int visibleRows = panelMap.Height / tileSize;

      panelMap.HorizontalScroll.Visible = false;
      panelMap.VerticalScroll.Visible = false;

      if (map.Width <= visibleColumns) {
        panelMap.HorizontalScroll.Enabled = false;
      } else {
        panelMap.HorizontalScroll.Maximum = mapScrollIndicator.Location.X;
        panelMap.HorizontalScroll.Enabled = true;
      }

      if (map.Height <= visibleRows) {
        panelMap.VerticalScroll.Enabled = false;
      } else {
        panelMap.VerticalScroll.Maximum = mapScrollIndicator.Location.Y;
        panelMap.VerticalScroll.Enabled = true;
      }

      panelMap.HorizontalScroll.Visible = true;
      panelMap.VerticalScroll.Visible = true;

      panelMap.Refresh();
    }
    #endregion
    #region --- map type changed ------------------------------------------------------------------
    private void MapTypeChanged() {
      if (radioButtonIndoor.Checked || radioButtonDungeon.Checked) {
        checkBoxWorldSurface.Checked = false;
        checkBoxWorldSurface.Enabled = false;
      } else {
        checkBoxWorldSurface.Enabled = true;
      }

      MarkAsDirty();

      UpdateMapFlags();
    }
    #endregion
    #region --- mark as dirty ---------------------------------------------------------------------
    private void MarkAsDirty(bool fromHistory = false) {
      if (mapLoading)
        return;

      Text = title + " *";
      unsavedChangesBesideHistory = unsavedChangesBesideHistory || !fromHistory;
      unsavedChanges = true;
    }
    #endregion
    #region --- not implemented -------------------------------------------------------------------
    private void NotImplemented() => MessageBox.Show(
      this,
      "Not implemented yet",
      "Not implemented",
      MessageBoxButtons.OK,
      MessageBoxIcon.Information
    );
    #endregion
    #region --- paint map -------------------------------------------------------------------------
    private void PaintMap(Graphics graphics, bool onPanel = false) {
      graphics.Clear(panelMap.BackColor);

      if (map is not null) {
        uint? imageIndex = map.TilesetIndex is uint tilesetIndex
          ? tilesetIndex
          : map.LabdataIndex is uint labdataIndex
          ? labdataIndex
          : null;

        if (imageIndex is uint) { 
          var tileset = tilesets[(uint)imageIndex];
          using var grid = new Pen(Color.Black, 1.0f);
          using var textBrush = new SolidBrush(Color.White);
          using var textBackground = new SolidBrush(Color.FromArgb(0x40, 0x80, 0x80, 0x80));
          using var blockBrush = new SolidBrush(Color.FromArgb(0x80, 0x20, 0xff, 0x40));
          using var font = new Font(FontFamily.GenericMonospace, 8.0f);
          int tileSize = (trackBarZoom.Maximum - trackBarZoom.Value + 1) * 16;
          int showAllowedTravelTypes = 0;

          if (toolStripMenuShowAllowWalk.Checked)
            showAllowedTravelTypes |= (1 << (int)TravelType.Walk);
          if (toolStripMenuShowAllowHorse.Checked)
            showAllowedTravelTypes |= (1 << (int)TravelType.Horse);
          if (toolStripMenuShowAllowDisc.Checked)
            showAllowedTravelTypes |= (1 << (int)TravelType.MagicalDisc);
          if (toolStripMenuShowAllowRaft.Checked)
            showAllowedTravelTypes |= (1 << (int)TravelType.Raft);
          if (toolStripMenuShowAllowShip.Checked)
            showAllowedTravelTypes |= (1 << (int)TravelType.Ship);

          for (int y = 0; y < MapHeight; ++y) {
            int drawY = onPanel
              ? panelMap.AutoScrollPosition.Y + y * tileSize
              : y * tileSize;

            if (drawY + tileSize <= 0)
              continue;

            if (onPanel && drawY >= panelMap.Height)
              break;

            for (int x = 0; x < MapWidth; ++x) {
              int drawX = onPanel
                ? panelMap.AutoScrollPosition.X + x * tileSize
                : x * tileSize;

              if (drawX + tileSize <= 0)
                continue;

              if (onPanel && drawX >= panelMap.Width)
                break;

              var tile = map.Tiles2D[x, y];
              var backgroundTile = tile.BackTileIndex == 0 ? null : tile.BackTileIndex > tileset.Tiles.Length ? null : tileset.Tiles[tile.BackTileIndex - 1];
              var foregroundTile = tile.FrontTileIndex == 0 ? null : tile.FrontTileIndex > tileset.Tiles.Length ? null : tileset.Tiles[tile.FrontTileIndex - 1];
              var rect = new Rectangle(drawX, drawY, tileSize + (tileSize / 16 - 1), tileSize + (tileSize / 16 - 1));

              if (toolStripMenuItemShowBackLayer.Checked && backgroundTile != null) {
                try {
                  uint frame = backgroundTile.NumAnimationFrames <= 1 ? 0 : (uint)(this.frame % (ulong)backgroundTile.NumAnimationFrames);

                  var backgroundImage = imageCache.GetImage(
                    (uint)imageIndex,
                    backgroundTile.GraphicIndex + frame - 1,
                    map.PaletteIndex
                  );

                  var interpolationMode = graphics.InterpolationMode;
                  graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                  graphics.DrawImage(backgroundImage, rect);
                  graphics.InterpolationMode = interpolationMode;
                } catch {
                  // ignore
                }
              }

              if (toolStripMenuItemShowFrontLayer.Checked && foregroundTile != null) {
                try {
                  uint frame = foregroundTile.NumAnimationFrames <= 1 ? 0 : (uint)(this.frame % (ulong)foregroundTile.NumAnimationFrames);

                  var foregroundImage = imageCache.GetImage(
                    (uint)imageIndex,
                    foregroundTile.GraphicIndex + frame - 1,
                    map.PaletteIndex
                  );
                  var interpolationMode = graphics.InterpolationMode;
                  graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                  graphics.DrawImage(foregroundImage, rect);
                  graphics.InterpolationMode = interpolationMode;
                } catch {
                  // ignore
                }
              }

              if (showAllowedTravelTypes != 0) {
                Tileset.Tile blockFlagsTile = foregroundTile == null || foregroundTile.UseBackgroundTileFlags ? backgroundTile : foregroundTile;

                if ((~blockFlagsTile.AllowedTravelTypes & showAllowedTravelTypes) != showAllowedTravelTypes)
                  graphics.FillRectangle(blockBrush, rect);
              }

              if (showGrid)
                graphics.DrawRectangle(grid, new Rectangle(drawX, drawY, tileSize - 1, tileSize - 1));

              if (showEvents && tile.MapEventId != 0) {
                int diff = (tileSize - 16) / 2;
                graphics.FillRectangle(textBackground, new Rectangle(drawX + 1 + diff, drawY + 1 + diff, 13, 13));
                graphics.DrawString(tile.MapEventId.ToString("x2"), font, textBrush, drawX, drawY);
              }
            }
          }

          if (showTileMarker && hoveredMapTile != -1 && tileMarkerWidth > 0 && tileMarkerHeight > 0) {
            int visibleColumns = panelMap.Width / tileSize;
            int visibleRows = panelMap.Height / tileSize;
            int hoveredX = hoveredMapTile % visibleColumns;
            int hoveredY = hoveredMapTile / visibleColumns;

            if (hoveredX + tileMarkerWidth <= visibleColumns + 1 &&
                hoveredY + tileMarkerHeight <= visibleRows + 1) {
              int startX = panelMap.AutoScrollPosition.X % tileSize + hoveredX * tileSize;
              int startY = panelMap.AutoScrollPosition.Y % tileSize + hoveredY * tileSize;
              using var marker = new SolidBrush(Color.FromArgb(0x40, 0x77, 0xff, 0x66));
              using var border = new Pen(Color.FromArgb(0x80, 0xff, 0xff, 0x00), 1);

              for (int y = 0; y < tileMarkerHeight; ++y) {
                for (int x = 0; x < tileMarkerWidth; ++x) {
                  graphics.FillRectangle(marker, new Rectangle(startX + x * tileSize + 1, startY + y * tileSize + 1, tileSize - 2, tileSize - 2));
                  graphics.DrawRectangle(border, new Rectangle(startX + x * tileSize, startY + y * tileSize, tileSize - 1, tileSize - 1));
                }
              }
            }
          }
        }
        // TODO: fill marker
      }
    }
    #endregion
    #region --- perform action --------------------------------------------------------------------
    private void PerformAction(string displayName, string undoDisplayName, Action<bool> doAction, Action undoAction) {
      history.DoAction(new DefaultAction(displayName, undoDisplayName, doAction, undoAction));

      if (mapLoading)
        history.Save();

      unsavedChanges = unsavedChanges || history.Dirty;

      if (unsavedChanges)
        MarkAsDirty(true);
    }
    #endregion
    #region --- pick position ---------------------------------------------------------------------
    private void PickPosition(int x, int y) {
      // TODO: undo/redo

      // x and y are 0-based here!
      if (selectedMapCharacter != -1) {
        var character = map.MapCharacters[selectedMapCharacter];

        if (character != null) {
          //if (character.Positions.Count < 1)
          //  character.Positions.Add(new Ambermoon.Position(x + 1, y + 1));
          //else {
          //  character.Positions[0].X = x + 1;
          //  character.Positions[0].Y = y + 1;
          //}

          //UpdateMapCharacterPosition(character.Positions[0]);
        }
      }

      RunDelayed(TimeSpan.FromMilliseconds(250), () => SelectTool(Tool.Brush));
    }
    #endregion
    #region --- pick tile -------------------------------------------------------------------------
    private void PickTile(int x, int y, int layer) {
      var tile = map.Tiles2D[x, y];
      uint tileIndex = layer == 0 ? tile.BackTileIndex : tile.FrontTileIndex;

      if (tileIndex == 0)
        SelectTool(Tool.RemoveFrontLayer);
      else {
        selectedTilesetTile = (int)tileIndex - 1;
        panelTileset.Refresh();
        SelectTool(Tool.Brush);
      }
    }
    #endregion
    #region --- remove front tile -----------------------------------------------------------------
    private void RemoveFrontTile(int x, int y) {
      if (map.Tiles2D[x, y].FrontTileIndex == 0)
        return;

      uint oldTileIndex = map.Tiles2D[x, y].FrontTileIndex;

      void SetTile(uint tileIndex) {
        map.Tiles2D[x, y].FrontTileIndex = tileIndex;
        panelMap.Refresh();
      }

      PerformAction($"Delete front tile at {x},{y}", $"Set front tile at {x},{y} to {oldTileIndex}",
          _ => SetTile(0), () => SetTile(oldTileIndex));
    }
    #endregion
    #region --- run delayed -----------------------------------------------------------------------
    private void RunDelayed(TimeSpan delay, Action action) {
      System.Windows.Forms.Timer timer = new() {
        Interval = (int)delay.TotalMilliseconds
      };
      timer.Tick += Timer_Tick;

      void Timer_Tick(object? sender, EventArgs e) {
        timer.Stop();
        timer.Tick -= Timer_Tick;
        action();
      }

      timer.Start();
    }
    #endregion
    #region --- save ------------------------------------------------------------------------------
    //private SaveResult Save() {
    //  if (saveFileName == null)
    //    return SaveAs();

    //  if (saveIntoGameData)
    //    return SaveToGameData() ? SaveResult.Success : SaveResult.Error;
    //  else
    //    return SaveToFile(saveFileName) ? SaveResult.Success : SaveResult.Error;
    //}
    #endregion
    #region --- save as ---------------------------------------------------------------------------
    //private SaveResult SaveAs() {
    //  var saveMapForm = new SaveMapForm();
    //  var result = saveMapForm.ShowDialog(this);

    //  if (result == DialogResult.No) {
    //    return SaveToFile(null, saveFileName) ? SaveResult.Success : SaveResult.Error;
    //  } else if (result == DialogResult.Yes) {
    //    //compressGameData = saveMapForm.Compress;
    //    return SaveToGameData() ? SaveResult.Success : SaveResult.Error;
    //  }

    //  return SaveResult.Cancelled;
    //}
    #endregion
    #region --- save image ------------------------------------------------------------------------
    private void SaveImage(IWin32Window parent, Action<string> saveAction) {
      //var dialog = new SaveDialog(configuration, Configuration.ImagePathName, "Save image", "png");

      //dialog.Filter = "Portable Network Graphic (*.png)|*.png";

      //if (dialog.ShowDialog(parent) == DialogResult.OK)
      //  saveAction?.Invoke(dialog.FileName);
    }
    #endregion
    #region --- save to file ----------------------------------------------------------------------
    //private bool SaveToFile(string fileName, string suggestedFileName = null) {
    //  if (string.IsNullOrWhiteSpace(fileName)) {
    //    var dialog = new SaveDialog(configuration, Configuration.MapPathName, "Save map");

    //    dialog.FileName = suggestedFileName ?? "";
    //    dialog.Filter = "All files (*.*)|*.*";

    //    if (dialog.ShowDialog(this) != DialogResult.OK)
    //      return false;

    //    fileName = dialog.FileName;
    //  }

    //  var dataWriter = new DataWriter();
    //  MapWriter.WriteMap(map, dataWriter);

    //  try {
    //    System.IO.File.WriteAllBytes(fileName, dataWriter.ToArray());
    //    saveFileName = fileName;
    //    Text = title;
    //    unsavedChangesBesideHistory = false;
    //    unsavedChanges = false;
    //    history.Save();
    //    mapCharEditorControl.Save();
    //    return true;
    //  } catch {
    //    return false;
    //  }
    //}
    #endregion
    #region --- save to gamedata ------------------------------------------------------------------
    private bool SaveToGameData() {
      int mapContainerIndex = map.Index <= 256 ? 1 : map.Index >= 300 && map.Index < 400 ? 3 : 2;
      string mapContainerName = $"{mapContainerIndex}Map_data.amb";

      try {
        //var waitForm = new WorkingForm("Saving map back to game data ...");
        //Task.Run(() => (gameData as GameData)
        //  .Save(
        //    gameDataPath, writer => {
        //      var mapDataWriter = new DataWriter();
        //      MapWriter.WriteMap(map, mapDataWriter);
        //      writer.ReplaceFile(mapContainerName, (int)map.Index, mapDataWriter);
        //    },
        //    true,
        //    waitForm.Finish,
        //    !compressGameData
        //  )
        //);
        //waitForm.ShowDialog(this);
        Text = title;
        unsavedChangesBesideHistory = false;
        unsavedChanges = false;
        history.Save();
        mapCharEditorControl.Save();
        return true;
      } catch {
        return false;
      }
    }
    #endregion
    #region --- select tool -----------------------------------------------------------------------
    private void SelectTool(Tool tool, bool force = false) {
      if (!force && currentTool == tool)
        return;

      var button = ButtonFromTool(currentTool);

      if (button != null)
        SetButtonActive(button, false);

      currentTool = tool;
      toolStripStatusLabelTool.Image = ImageFromTool(tool, false);
      button = ButtonFromTool(currentTool);
      var cursor = CursorFromTool(currentTool);
      tileMarkerWidth = TileMarkerWidthFromTool(currentTool);
      tileMarkerHeight = TileMarkerHeightFromTool(currentTool);
      panelMap.Refresh();

      if (button != null)
        SetButtonActive(button, true);

      panelMap.Cursor = cursor ?? Cursors.Arrow;
    }
    #endregion
    #region --- set button active -----------------------------------------------------------------
    private static void SetButtonActive(Button button, bool active) {
      button.UseVisualStyleBackColor = false;
      button.BackColor = Color.FromArgb(0x30, active ? Color.Lime : SystemColors.Control);
    }
    #endregion
    #region --- set tiles -------------------------------------------------------------------------
    private void SetTiles(int x, int y, int w, int h, int layer, bool useSameTile = false) {
      if (w < 1)
        w = 1;
      if (h < 1)
        h = 1;
      if (layer < 0)
        layer = 0;
      else if (layer > 1)
        layer = 1;

      var currentTiles = new List<uint>(9);
      bool hasChange = false;
      int tile = 1 + selectedTilesetTile;
      int checkTile = tile;
      for (int ty = 0; ty < h; ++ty) {
        int totalY = y + ty;

        if (totalY >= map.Height)
          break;

        for (int tx = 0; tx < w; ++tx) {
          int totalX = x + tx;

          if (totalX >= map.Width)
            continue;

          var mapTile = map.Tiles2D[totalX, totalY];
          uint tileIndex = layer == 0 ? mapTile.BackTileIndex : mapTile.FrontTileIndex;
          currentTiles.Add(tileIndex);

          if (tileIndex != checkTile)
            hasChange = true;

          if (!useSameTile)
            ++checkTile;
        }
      }

      if (!hasChange)
        return;

      string doText = w == 1 && h == 1
          ? $"Change tile at {x},{y} on {LayerName[layer]} to tile {tile}"
          : useSameTile
              ? $"Change tiles from {x},{y} to {x + w - 1},{y + h - 1} on {LayerName[layer]} to tile {tile}"
              : $"Change tiles from {x},{y} to {x + w - 1},{y + h - 1} on {LayerName[layer]} to tiles {tile} to {tile + (w - 1) * (h - 1)}";
      bool sameUndoTile = currentTiles.GroupBy(t => t).Count() == 1;
      string undoText = w == 1 && h == 1
          ? $"Change tile at {x},{y} on {LayerName[layer]} to tile {(currentTiles[0] == 0 ? "empty" : (currentTiles[0] - 1).ToString())}"
          : sameUndoTile
              ? $"Change tiles from {x},{y} to {x + w - 1},{y + h - 1} on {LayerName[layer]} to tile {(currentTiles[0] == 0 ? "empty" : (currentTiles[0] - 1).ToString())}"
              : $"Change tiles from {x},{y} to {x + w - 1},{y + h - 1} on {LayerName[layer]} to tiles [{string.Join(",", currentTiles.Select(t => t == 0 ? "empty" : (t - 1).ToString()))}]";

      PerformAction(doText, undoText,
          _ => {
            for (int ty = 0; ty < h; ++ty) {
              int totalY = y + ty;

              if (totalY >= map.Height)
                break;

              for (int tx = 0; tx < w; ++tx) {
                int totalX = x + tx;

                if (totalX >= map.Width)
                  continue;

                var mapTile = map.Tiles2D[totalX, totalY];

                if (layer == 0)
                  mapTile.BackTileIndex = (uint)tile;
                else
                  mapTile.FrontTileIndex = (uint)tile;

                if (!useSameTile)
                  ++tile;
              }
            }

            panelMap.Refresh();
          },
          () => {
            int listIndex = 0;
            for (int ty = 0; ty < h; ++ty) {
              int totalY = y + ty;

              if (totalY >= map.Height)
                break;

              for (int tx = 0; tx < w; ++tx) {
                int totalX = x + tx;

                if (totalX >= map.Width)
                  continue;

                var mapTile = map.Tiles2D[totalX, totalY];

                if (layer == 0)
                  mapTile.BackTileIndex = currentTiles[listIndex++];
                else
                  mapTile.FrontTileIndex = currentTiles[listIndex++];
              }
            }

            panelMap.Refresh();
          }
      );
    }
    #endregion
    #region --- start music -----------------------------------------------------------------------
    //private void StartMusic() {
    //  playingSong = (Song)(comboBoxMusic.SelectedIndex + 1);
    //  var waveStream = LoadSong(playingSong.Value);
    //  if (playingSong != lastSong)
    //    waveStream.Position = 0;
    //  wavePlayer.Init(waveStream);
    //  wavePlayer.Play();
    //  buttonToggleMusic.Image = Properties.Resources.round_stop_black_24;
    //}
    #endregion
    #region --- stop music ------------------------------------------------------------------------
    //private void StopMusic() {
    //  lastSong = playingSong;
    //  playingSong = null;
    //  wavePlayer.Stop();
    //  buttonToggleMusic.Image = Properties.Resources.round_play_arrow_black_24;
    //}
    #endregion
    #region --- tile marker height from tool ------------------------------------------------------
    private static int TileMarkerHeightFromTool(Tool tool) {
      return tool switch {
        Tool.Brush => 1,
        Tool.Blocks2x2 or Tool.Blocks3x2 => 2,
        Tool.Blocks3x3 => 3,
        Tool.Fill => -1,
        Tool.ColorPicker => 1,
        Tool.RemoveFrontLayer => 1,
        Tool.EventChanger => 1,
        Tool.PositionPicker => 1,
        _ => 0,
      };
    }
    #endregion
    #region --- tile marker width from tool -------------------------------------------------------
    private static int TileMarkerWidthFromTool(Tool tool) {
      return tool switch {
        Tool.Brush            => 1,
        Tool.Blocks2x2        => 2,
        Tool.Blocks3x2        => 3,
        Tool.Blocks3x3        => 3,
        Tool.Fill             => -1,
        Tool.ColorPicker      => 1,
        Tool.RemoveFrontLayer => 1,
        Tool.EventChanger     => 1,
        Tool.PositionPicker   => 1,
        _                     => 0,
      };
    }
    #endregion
    #region --- tileset changed -------------------------------------------------------------------
    private void TilesetChanged() {
      MarkAsDirty();

      panelTileset.Refresh();
      tilesetScrollIndicator.Location = new Point(TilesetTilesPerRow * 16, ((currentTilesetTiles + TilesetTilesPerRow - 1) / TilesetTilesPerRow) * 16);
    }
    #endregion
    #region --- toggle events ---------------------------------------------------------------------
    private void ToggleEvents() {
      showEvents = !showEvents;
      //buttonToggleEvents.Image = showEvents ? Properties.Resources.round_vpn_key_black_24 : Properties.Resources.round_vpn_key_black_24_off;
      panelMap.Refresh();
    }
    #endregion
    #region --- toggle music ----------------------------------------------------------------------
    //private void ToggleMusic() {
    //  if (playingSong != null)
    //    StopMusic();
    //  else
    //    StartMusic();
    //}
    #endregion
    #region --- update map flags ------------------------------------------------------------------
    private void UpdateMapFlags() {
      if (mapLoading)
        return;

      //map.Flags &= MapFlags.Unknown2; // keep this unknown flag if present

      //if (radioButtonIndoor.Checked)
      //  map.Flags |= MapFlags.Indoor;
      //else if (radioButtonOutdoor.Checked)
      //  map.Flags |= MapFlags.Outdoor;
      //else if (radioButtonDungeon.Checked)
      //  map.Flags |= MapFlags.Dungeon;

      //if (checkBoxMagic.Checked)
      //  map.Flags |= MapFlags.CanUseMagic;
      //if (checkBoxResting.Checked)
      //  map.Flags |= MapFlags.CanRest;
      //if (checkBoxUnknown1.Checked)
      //  map.Flags |= MapFlags.Unknown1;
      //if (checkBoxTravelGraphics.Checked)
      //  map.Flags |= MapFlags.StationaryGraphics;
      //if (checkBoxNoSleepUntilDawn.Checked)
      //  map.Flags |= MapFlags.NoSleepUntilDawn;
      //if (checkBoxWorldSurface.Checked)
      //  map.Flags |= MapFlags.WorldSurface;

      MarkAsDirty();
    }
    #endregion
    #region --- update tileset --------------------------------------------------------------------
    private void UpdateTileset() {
      uint? imageIndex = map.TilesetIndex is uint tilesetIndex
        ? tilesetIndex
        : map.LabdataIndex is uint labdataIndex
        ? labdataIndex
        : null;

      if (imageIndex is uint) {
        currentTilesetTiles = currentLayer == 0
          ? Math.Min(256, tilesets[(uint)imageIndex].Tiles.Length)
          : tilesets[(uint)imageIndex].Tiles.Length;

        TilesetChanged();
      }
    }
    #endregion
    #region --- use tool --------------------------------------------------------------------------
    private void UseTool(int x, int y, bool secondaryFunction) {
      if (x < 0 || y < 0 || x >= map.Width || y >= map.Height) {
        return;
      }

      switch (currentTool) {
        case Tool.Brush:            SetTiles(x, y, 1, 1, secondaryFunction ? 1 - currentLayer : currentLayer); break;
        case Tool.Blocks2x2:        SetTiles(x, y, 2, 2, currentLayer, secondaryFunction); break;
        case Tool.Blocks3x2:        SetTiles(x, y, 3, 2, currentLayer, secondaryFunction); break;
        case Tool.Blocks3x3:        SetTiles(x, y, 3, 3, currentLayer, secondaryFunction); break;
        case Tool.ColorPicker:      PickTile(x, y, secondaryFunction ? 1 - currentLayer : currentLayer); break;
        case Tool.Fill:             FillTiles(x, y, secondaryFunction); break;
        case Tool.RemoveFrontLayer: RemoveFrontTile(x, y); break;
        case Tool.EventChanger:     ChangeEvent(x, y, secondaryFunction); break;
        case Tool.PositionPicker:   PickPosition(x, y); break;
      }
    }
    #endregion

    #region --- menu: back layer ------------------------------------------------------------------
    private void toolStripMenuItemBackLayer_Click(object sender, EventArgs e) {
      toolStripMenuItemFrontLayer.Checked = !toolStripMenuItemBackLayer.Checked;
      currentLayer = 0;
      toolStripStatusLabelLayer.Text = LayerName[0];
      UpdateTileset();
    }
    #endregion
    #region --- menu: blocks 2x2 ------------------------------------------------------------------
    private void toolStripMenuItemBlocks2x2_Click(object sender, EventArgs e) {
      blocksTool = Tool.Blocks2x2;
      buttonToolBlocks.Image = ImageFromTool(blocksTool, true);
      SelectTool(blocksTool);
    }
    #endregion
    #region --- menu: blocks 3x2 ------------------------------------------------------------------
    private void toolStripMenuItemBlocks3x2_Click(object sender, EventArgs e) {
      blocksTool = Tool.Blocks3x2;
      buttonToolBlocks.Image = ImageFromTool(blocksTool, true);
      SelectTool(blocksTool);
    }
    #endregion
    #region --- menu: blocks 3x3 ------------------------------------------------------------------
    private void toolStripMenuItemBlocks3x3_Click(object sender, EventArgs e) {
      blocksTool = Tool.Blocks3x3;
      buttonToolBlocks.Image = ImageFromTool(blocksTool, true);
      SelectTool(blocksTool);
    }
    #endregion
    #region --- menu: front layer -----------------------------------------------------------------
    private void toolStripMenuItemFrontLayer_Click(object sender, EventArgs e) {
      toolStripMenuItemBackLayer.Checked = !toolStripMenuItemFrontLayer.Checked;
      currentLayer = 1;
      toolStripStatusLabelLayer.Text = LayerName[1];
      UpdateTileset();
    }
    #endregion
    #region --- menu: map new ---------------------------------------------------------------------
    private void toolStripMenuItemMapNew_Click(object sender, EventArgs e) {
      //if (unsavedChanges) {
      //  var result = MessageBox.Show(this, "There are unsaved changes. Do you want to save them now?",
      //      "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

      //  if (result == DialogResult.Cancel)
      //    return;

      //  if (result == DialogResult.Yes) {
      //    var saveResult = Save();

      //    if (saveResult == SaveResult.Error) {
      //      if (MessageBox.Show(this, "Error saving the map. Do you want to abort and return to your current map?",
      //          "Unable to save map", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
      //        return;
      //    } else if (saveResult == SaveResult.Cancelled) {
      //      return;
      //    }
      //  }
      //}

      //if (OpenMap()) {
      //  saveFileName = null;
      //  toolStripMenuItemMapSave.Enabled = false;
      //  graphicProvider.PaletteIndex = map.PaletteIndex;
      //  mapCharEditorControl.Init(map);
      //  selectedMapCharacter = mapCharEditorControl.Count == 0 ? -1 : 0;
      //  UpdateMapCharacterButtons();
      //}
    }
    #endregion
    #region --- menu: map save as -----------------------------------------------------------------
    private void toolStripMenuItemMapSaveAs_Click(object sender, EventArgs e) {
      //if (SaveAs() == SaveResult.Success && saveFileName != null)
      //  toolStripMenuItemMapSave.Enabled = true;
    }
    #endregion
    #region --- menu: save as png -----------------------------------------------------------------
    private void toolStripMenuItemMapSaveAsPNG_Click(object sender, EventArgs e) {
      SaveFileDialog dialog = new() {
        FileName = $"{map.Index:D3}",// - {map.Name}",
        Filter = "(*.png)|*.png",
        Title = "Select file location"
      };

      if (map is not null && dialog.ShowDialog() == DialogResult.OK) {
        int tileSize = (trackBarZoom.Maximum - trackBarZoom.Value + 1) * 16;
        using Bitmap bitmap = new(map.Width * tileSize, map.Height * tileSize);
        using Graphics graphics = Graphics.FromImage(bitmap);
        PaintMap(graphics);
        bitmap.Save(dialog.FileName, ImageFormat.Png);
      }
    }
    #endregion

    #region --- button add tileset: click ---------------------------------------------------------
    /*private void buttonAddTileset_Click(object sender, EventArgs e)
    {
        // TODO: we also have to add a new icon file
        uint index = 1 + (uint)tilesets.Count;

        var tileset = new Tileset()
        {
            Index = index,
            Tiles = new Tileset.Tile[2500]
        };

        for (int i = 0; i < 2500; ++i)
            tileset.Tiles[i] = new Tileset.Tile();

        tilesets.Add(index, tileset);

        comboBoxTilesets.SelectedIndex = (int)index - 1;
    }*/
    #endregion
    #region --- button duplicate tile: click ------------------------------------------------------
    private void buttonDuplicateTile_Click(object sender, EventArgs e) {
      MessageBox.Show("Close this window, then left click on the tile slot where the copy should be placed. Use right click on tileset or Escape key to abort.");

      choosingTileSlotForDuplicating = true;
    }
    #endregion
    #region --- button edit tile: click -----------------------------------------------------------
    private void buttonEditTile_Click(object sender, EventArgs e) {
      uint? imageIndex = map.TilesetIndex is uint tilesetIndex
          ? tilesetIndex
          : map.LabdataIndex is uint labdataIndex
          ? labdataIndex
          : null;

      if (imageIndex is uint) { 
        var tileset = tilesets[(uint)imageIndex];
        //var form = new EditTileForm(configuration, tileset.Tiles[selectedTilesetTile], tileset, imageCache, map.PaletteIndex, combatBackgrounds);
        var form = new EditTileForm(tileset.Tiles[selectedTilesetTile], tileset, imageCache, map.PaletteIndex, combatBackgrounds);

        if (form.ShowDialog() == DialogResult.OK) {
          tileset.Tiles[selectedTilesetTile].Fill(form.Tile);
          panelTileset.Refresh();
        }
      }
    }
    #endregion
    #region --- button export tileset: click ------------------------------------------------------
    private void buttonExportTileset_Click(object sender, EventArgs e) {
      //var dialog = new SaveDialog(configuration, Configuration.TilesetPathName, "Save tileset");

      //dialog.Filter = "All files (*.*)|*.*";

      //if (dialog.ShowDialog(this) == DialogResult.OK) {
      //  var tileset = tilesets[map.TilesetOrLabdataIndex];
      //  var dataWriter = new DataWriter();
      //  TilesetWriter.WriteTileset(tileset, dataWriter);
      //  System.IO.File.WriteAllBytes(dialog.FileName, dataWriter.ToArray());
      //}
    }
    #endregion
    #region --- button indoor defaults: click -----------------------------------------------------
    private void buttonIndoorDefaults_Click(object sender, EventArgs e) {
      radioButtonIndoor.Checked = true;
      checkBoxWorldSurface.Checked = false;
      checkBoxResting.Checked = false;
      checkBoxMagic.Checked = true;

      MarkAsDirty();
    }
    #endregion
    #region --- button place character on map: enabled changed ------------------------------------
    private void buttonPlaceCharacterOnMap_EnabledChanged(object sender, EventArgs e) {
      if (!buttonPlaceCharacterOnMap.Enabled && currentTool == Tool.PositionPicker)
        SelectTool(Tool.Brush);
    }
    #endregion
    #region --- button positions: click -----------------------------------------------------------
    private void buttonPositions_Click(object sender, EventArgs e) {
      if (selectedMapCharacter == -1)
        return;

      var character = map.MapCharacters[selectedMapCharacter];

      if (character == null)
        return;

      //var positionEditor = new AmbermoonMapCharEditor.PositionEditorForm(map, character);

      //positionEditor.ShowDialog();

      //if (positionEditor.Dirty)
      //MarkAsDirty();
    }
    #endregion
    #region --- button resize: click --------------------------------------------------------------
    private void buttonResize_Click(object sender, EventArgs e) {
      if (numericUpDownWidth.Enabled) {
        buttonResize.Text = "Enable resizing";
        numericUpDownWidth.Enabled = false;
        numericUpDownHeight.Enabled = false;
      } else {
        buttonResize.Text = "Disable resizing";
        numericUpDownWidth.Enabled = true;
        numericUpDownHeight.Enabled = true;
      }
    }
    #endregion
    #region --- button toggle grid: click ---------------------------------------------------------
    private void buttonToggleGrid_Click(object sender, EventArgs e) {
      showGrid = !showGrid;
      //buttonToggleGrid.Image = showGrid ? Properties.Resources.round_grid_on_black_24 : Properties.Resources.round_grid_off_black_24;
      panelMap.Refresh();
    }
    #endregion
    #region --- button toggle music: click --------------------------------------------------------
    private void buttonToggleMusic_Click(object sender, EventArgs e) {
      //ToggleMusic();
    }
    #endregion
    #region --- button toggle tile marker: click --------------------------------------------------
    private void buttonToggleTileMarker_Click(object sender, EventArgs e) {
      showTileMarker = !showTileMarker;
      //buttonToggleTileMarker.Image = showTileMarker ? Properties.Resources.round_select_all_black_24 : Properties.Resources.round_select_all_black_24_off;
      panelMap.Refresh();
    }
    #endregion
    #region --- button tool event changer: click --------------------------------------------------
    private void buttonToolEventChanger_Click(object sender, EventArgs e) {
      SelectTool(Tool.EventChanger);

      if (!showEvents)
        ToggleEvents();
    }
    #endregion
    #region --- button tool layers: click ---------------------------------------------------------
    private void buttonToolLayers_Click(object sender, EventArgs e) {
      var point = new Point(buttonToolLayers.Right, buttonToolLayers.Bottom);
      point = PointToScreen(point);
      contextMenuStripLayers.Show(point);
    }
    #endregion
    #region --- button world map defaults: click --------------------------------------------------
    private void buttonWorldMapDefaults_Click(object sender, EventArgs e) {
      if (numericUpDownWidth.Value != 50 || numericUpDownHeight.Value != 50) {
        if (!AskYesNo("Changing to world map, forces the map size to be changed to 50x50. Do you want to proceed?"))
          return;

        numericUpDownWidth.Value = 50;
        numericUpDownHeight.Value = 50;
        MapSizeChanged();
      }

      radioButtonOutdoor.Checked = true;
      checkBoxWorldSurface.Checked = true;
      checkBoxResting.Checked = true;
      checkBoxNoSleepUntilDawn.Checked = false;
      checkBoxMagic.Checked = true;

      MarkAsDirty();
    }
    #endregion
    #region --- checkbox world surface: checked changed -------------------------------------------
    private void checkBoxWorldSurface_CheckedChanged(object sender, EventArgs e) {
      if (checkBoxWorldSurface.Checked && (numericUpDownWidth.Value != 50 || numericUpDownHeight.Value != 50)) {
        if (AskYesNo("Changing to world map, forces the map size to be changed to 50x50. Do you want to proceed?")) {
          numericUpDownWidth.Value = 50;
          numericUpDownHeight.Value = 50;
          MapSizeChanged();
        }
      }

      buttonResize.Enabled = !checkBoxWorldSurface.Checked;

      if (checkBoxWorldSurface.Checked) {
        numericUpDownWidth.Enabled = false;
        numericUpDownHeight.Enabled = false;
        buttonResize.Text = "Enable resizing";
      }

      checkBoxUnknown1.Checked = checkBoxTravelGraphics.Checked = checkBoxWorldSurface.Checked;
      groupBoxCharacters.Enabled = !checkBoxWorldSurface.Checked;

      UpdateMapFlags();
    }
    #endregion
    #region --- checkbox resting: checked changed -------------------------------------------------
    private void checkBoxResting_CheckedChanged(object sender, EventArgs e) {
      if (!checkBoxResting.Checked) {
        checkBoxNoSleepUntilDawn.Checked = false;
      }

      checkBoxNoSleepUntilDawn.Enabled = checkBoxResting.Checked;

      UpdateMapFlags();
    }
    #endregion
    #region --- combobox characters: selected index changed ---------------------------------------
    private void comboBoxCharacters_SelectedIndexChanged(object sender, EventArgs e) {

    }
    #endregion
    #region --- combobox palettes: selected index changed -----------------------------------------
    private void comboBoxPalettes_SelectedIndexChanged(object sender, EventArgs e) {
      uint oldPaletteIndex = map.PaletteIndex;
      uint newPaletteIndex = (uint)(1 + comboBoxPalettes.SelectedIndex);

      void UpdatePalette(uint index, bool updateIndex) {
        if (graphicProvider != null)
          graphicProvider.PaletteIndex = index;
        map.PaletteIndex = index;
        panelTileset.Refresh();
        panelMap.Refresh();

        if (updateIndex) {
          comboBoxPalettes.SelectedIndexChanged -= comboBoxPalettes_SelectedIndexChanged;
          comboBoxPalettes.SelectedIndex = (int)index - 1;
          comboBoxPalettes.SelectedIndexChanged += comboBoxPalettes_SelectedIndexChanged;
        }
      }

      PerformAction($"Change palette to {newPaletteIndex}", $"Change palette to {oldPaletteIndex}",
          redo => UpdatePalette(newPaletteIndex, redo), () => UpdatePalette(oldPaletteIndex, true));
    }
    #endregion
    #region --- combobox tilesets: selected index changed -----------------------------------------
    private void comboBoxTilesets_SelectedIndexChanged(object sender, EventArgs e) {
      uint? imageIndex = map.TilesetIndex is uint tilesetIndex
        ? tilesetIndex
        : map.LabdataIndex is uint labdataIndex
        ? labdataIndex
        : null;

      if (imageIndex is uint) { 
        uint oldTilesetIndex = (uint)imageIndex;
        uint newTilesetIndex = (uint)(1 + comboBoxTilesets.SelectedIndex);

        void UpdateTileset(uint index, bool updateIndex) {
          imageIndex = index;
          currentTilesetTiles = tilesets[index].Tiles.Length;
          panelMap.Refresh();
          TilesetChanged();

          if (updateIndex) {
            comboBoxTilesets.SelectedIndexChanged -= comboBoxTilesets_SelectedIndexChanged;
            comboBoxTilesets.SelectedIndex = (int)index - 1;
            comboBoxTilesets.SelectedIndexChanged += comboBoxTilesets_SelectedIndexChanged;
          }
        }

        PerformAction(
          $"Change tileset to {newTilesetIndex}",
          $"Change tileset to {oldTilesetIndex}",
          redo => UpdateTileset(newTilesetIndex, redo),
          () => UpdateTileset(oldTilesetIndex, true)
        );
      }
    }
    #endregion
    #region --- nud heigth: value changed ---------------------------------------------------------
    private void numericUpDownHeight_ValueChanged(object sender, EventArgs e) {
      int oldHeight = map.Height;
      //map.Height = (int)numericUpDownHeight.Value;
      var backup = new Map.Tile[map.Width, map.Height];
      var initialBackup = new Map.Tile[map.Width, map.Height];
      //for (int y = 0; y < map.Height; ++y) {
      //  for (int x = 0; x < map.Width; ++x) {
      //    initialBackup[x, y] = y >= oldHeight
      //        ? new Map.Tile { BackTileIndex = 1 }
      //        : map.Tiles2D[x, y];
      //    backup[x, y] = y >= oldHeight
      //        ? new Map.Tile { BackTileIndex = 1 }
      //        : map.Tiles2D[x, y];
      //  }
      //}
      //map.Tiles2D = initialBackup;
      //map.Tiles2D = backup;
      MapSizeChanged();
    }
    #endregion
    #region --- nud width: value changed ----------------------------------------------------------
    private void numericUpDownWidth_ValueChanged(object sender, EventArgs e) {
      //int oldWidth = map.Width;
      //map.Width = (int)numericUpDownWidth.Value;
      //var backup = new MapData.Tile[map.Width, map.Height];
      //var initialBackup = new MapData.Tile[map.Width, map.Height];
      //for (int y = 0; y < map.Height; ++y) {
      //  for (int x = 0; x < map.Width; ++x) {
      //    initialBackup[x, y] = x >= oldWidth
      //        ? new MapData.Tile { BackTileIndex = 1 }
      //        : map.Tiles2D[x, y];
      //    backup[x, y] = x >= oldWidth
      //        ? new MapData.Tile { BackTileIndex = 1 }
      //        : map.Tiles2D[x, y];
      //  }
      //}
      //map.Tiles2D = initialBackup;
      //map.Tiles2D = backup;
      //MapSizeChanged();
    }
    #endregion
    #region --- panel map: mouse down -------------------------------------------------------------
    private void panelMap_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) {
        int tileSize = (trackBarZoom.Maximum - trackBarZoom.Value + 1) * 16;
        int hoveredColumn = (e.X - panelMap.AutoScrollPosition.X % tileSize) / tileSize;
        int hoveredRow = (e.Y - panelMap.AutoScrollPosition.Y % tileSize) / tileSize;
        int scrolledXTile = -panelMap.AutoScrollPosition.X / tileSize;
        int scrolledYTile = -panelMap.AutoScrollPosition.Y / tileSize;

        int x = scrolledXTile + hoveredColumn;
        int y = scrolledYTile + hoveredRow;

        UseTool(x, y, e.Button == MouseButtons.Right);
      }
    }
    #endregion
    #region --- panel map: mouse move -------------------------------------------------------------
    private void panelMap_MouseMove(object sender, MouseEventArgs e) {
      if (!panelMap.ClientRectangle.Contains(e.Location)) {
        if (hoveredMapTile != -1) {
          toolStripStatusLabelCurrentTile.Visible = false;
          hoveredMapTile = -1;
          panelMap.Refresh();
        }
        return;
      }

      int tileSize = (trackBarZoom.Maximum - trackBarZoom.Value + 1) * 16;
      int visibleColumns = panelMap.Width / tileSize;
      int hoveredColumn = (e.X - panelMap.AutoScrollPosition.X % tileSize) / tileSize;
      int hoveredRow = (e.Y - panelMap.AutoScrollPosition.Y % tileSize) / tileSize;
      int scrolledXTile = -panelMap.AutoScrollPosition.X / tileSize;
      int scrolledYTile = -panelMap.AutoScrollPosition.Y / tileSize;
      int newHoveredTile = hoveredColumn + hoveredRow * visibleColumns;

      int x = scrolledXTile + hoveredColumn;
      int y = scrolledYTile + hoveredRow;

      if (x >= map.Width || y >= map.Height) {
        if (hoveredMapTile != -1) {
          toolStripStatusLabelCurrentTile.Visible = false;
          hoveredMapTile = -1;
          panelMap.Refresh();
        }
        return;
      }

      toolStripStatusLabelCurrentTile.Text = $"{1 + x}, {1 + y} [Index: {x + y * map.Width}]";
      toolStripStatusLabelCurrentTile.Visible = true;

      if (newHoveredTile != hoveredMapTile) {
        hoveredMapTile = newHoveredTile;
        panelMap.Refresh();
      }

      if (e.Button == MouseButtons.Left)
        UseTool(x, y, false);
      else if (e.Button == MouseButtons.Right)
        UseTool(x, y, true);
    }
    #endregion
    #region --- panel map: mouse leave ------------------------------------------------------------
    private void panelMap_MouseLeave(object sender, EventArgs e) {
      toolStripStatusLabelCurrentTile.Visible = false;
      hoveredMapTile = -1;
      panelMap.Refresh();
    }
    #endregion
    #region --- panel tileset: mouse down ---------------------------------------------------------
    private void panelTileset_MouseDown(object sender, MouseEventArgs e) {
      int tx = (e.X - panelTileset.AutoScrollPosition.X) / 16;
      int ty = (e.Y - panelTileset.AutoScrollPosition.Y) / 16;
      int selectedIndex = tx + ty * TilesetTilesPerRow;

      uint? imageIndex = map.TilesetIndex is uint tilesetIndex
        ? tilesetIndex
        : map.LabdataIndex is uint labdataIndex
        ? labdataIndex
        : null;

      if (imageIndex is uint) { 
        if (choosingTileSlotForDuplicating) {
          choosingTileSlotForDuplicating = false;

          if (e.Button != MouseButtons.Left || selectedIndex >= tilesets[(uint)imageIndex].Tiles.Length)
            return;

          var tile = tilesets[(uint)imageIndex].Tiles[selectedTilesetTile];
          selectedTilesetTile = selectedIndex;
          tilesets[(uint)imageIndex].Tiles[selectedTilesetTile].Fill(tile);
          panelTileset.Refresh();

          try {
            toolStripStatusLabelCurrentTile.Image = imageCache.GetImage((uint)imageIndex, tile.GraphicIndex - 1, map.PaletteIndex);
          } catch {
            toolStripStatusLabelCurrentTile.Image = null;
          }
        }

        if (selectedIndex < tilesets[(uint)imageIndex].Tiles.Length) {
          selectedTilesetTile = selectedIndex;
          panelTileset.Refresh();

          try {
            var tile = tilesets[(uint)imageIndex].Tiles[selectedIndex];
            toolStripStatusLabelCurrentTile.Image = imageCache.GetImage((uint)imageIndex, tile.GraphicIndex - 1, map.PaletteIndex);
          } catch {
            toolStripStatusLabelCurrentTile.Image = null;
          }
        }
      }
    }
    #endregion
    #region --- panel tileset: mouse leave --------------------------------------------------------
    private void panelTileset_MouseLeave(object sender, EventArgs e) {
      toolStripStatusLabelCurrentTilesetTile.Visible = false;
      hoveredTilesetTile = -1;
      panelTileset.Refresh();
    }
    #endregion
    #region --- panel tileset: mouse move ---------------------------------------------------------
    private void panelTileset_MouseMove(object sender, MouseEventArgs e) {
      if (!panelTileset.ClientRectangle.Contains(e.Location)) {
        if (hoveredTilesetTile != -1) {
          toolStripStatusLabelCurrentTilesetTile.Visible = false;
          hoveredTilesetTile = -1;
          panelTileset.Refresh();
        }
        return;
      }

      int visibleColumns = panelTileset.Width / 16;
      int hoveredColumn = (e.X - panelTileset.AutoScrollPosition.X % 16) / 16;
      int hoveredRow = (e.Y - panelTileset.AutoScrollPosition.Y % 16) / 16;
      int scrolledXTile = -panelTileset.AutoScrollPosition.X / 16;
      int scrolledYTile = -panelTileset.AutoScrollPosition.Y / 16;
      int newHoveredTile = hoveredColumn + hoveredRow * visibleColumns;

      int x = scrolledXTile + hoveredColumn;
      int y = scrolledYTile + hoveredRow;
      int index = x + y * TilesetTilesPerRow;

      if (index >= (currentLayer == 0 ? Math.Min(256, currentTilesetTiles) : currentTilesetTiles)) {
        toolStripStatusLabelCurrentTilesetTile.Visible = false;

        if (hoveredTilesetTile != -1) {
          hoveredTilesetTile = -1;
          panelTileset.Refresh();
        }
      } else {
        toolStripStatusLabelCurrentTilesetTile.Text = $"{1 + x}, {1 + y} [Index: {index + 1}]";
        toolStripStatusLabelCurrentTilesetTile.Visible = true;

        if (newHoveredTile != hoveredTilesetTile) {
          hoveredTilesetTile = newHoveredTile;
          panelTileset.Refresh();
        }
      }
    }
    #endregion
    #region --- panel titleset: paint -------------------------------------------------------------
    private void panelTileset_Paint(object sender, PaintEventArgs e) {
      e.Graphics.Clear(panelTileset.BackColor);

      if (map != null) {
        var tileset = tilesets[(uint)map.TilesetIndex];
        int x = 0;
        int y = 0;
        using var border = new Pen(Color.Black, 1.0f);
        using var selectedBorder = new Pen(Color.Yellow, 2.0f);
        using var errorBrush = new SolidBrush(Color.White);
        using var errorFont = new Font(FontFamily.GenericMonospace, 8.0f);
        using var errorFontBrush = new SolidBrush(Color.Red);
        using var unusedBrush = new SolidBrush(Color.FromArgb(0x80, 0xff, 0x40, 0x20));
        var tiles = currentLayer == 0 ? tileset.Tiles.Take(256) : tileset.Tiles;
        var mapTiles = !checkBoxMarkUnusedTiles.Checked ? null : map.Tiles2D.Cast<Map.Tile>()
            .SelectMany(tile => new[] { tile.BackTileIndex, tile.FrontTileIndex })
            .Distinct()
            .Where(tile => tile != 0)
            .ToHashSet();
        uint tileIndex = 1;

        foreach (var tile in tiles) {
          int drawY = panelTileset.AutoScrollPosition.Y + y * 16;

          if (drawY >= panelTileset.Height)
            break;

          int drawX = panelTileset.AutoScrollPosition.X + x * 16;

          if (drawY + 16 > 0 && drawX + 16 > 0 && drawX < panelMap.Width) {
            var rect = new Rectangle(drawX, drawY, 16, 16);

            try {
              uint frame = tile.NumAnimationFrames <= 1 ? 0 : (uint)(this.frame % (ulong)tile.NumAnimationFrames);
              var image = imageCache.GetImage((uint)map.TilesetIndex, tile.GraphicIndex + frame - 1, map.PaletteIndex);
              e.Graphics.DrawImageUnscaledAndClipped(image, rect);
              e.Graphics.DrawRectangle(border, rect);
            } catch {
              e.Graphics.FillRectangle(errorBrush, rect);
              e.Graphics.DrawString("X", errorFont, errorFontBrush, rect.X + 3, rect.Y);
              // ignore, there are many unused tiles without valid graphic indices, just skip them and mark them as unused/invalid
            }

            if (checkBoxMarkUnusedTiles.Checked && !mapTiles.Contains(tileIndex)) {
              e.Graphics.FillRectangle(unusedBrush, rect);
            }
          }

          if (++x == TilesetTilesPerRow) {
            x = 0;
            ++y;
          }

          ++tileIndex;
        }

        if (selectedTilesetTile > tiles.Count())
          selectedTilesetTile = 0;

        int selectedColumn = selectedTilesetTile % TilesetTilesPerRow;
        int selectedRow = selectedTilesetTile / TilesetTilesPerRow;
        e.Graphics.DrawRectangle(selectedBorder, new Rectangle(panelTileset.AutoScrollPosition.X + selectedColumn * 16,
            panelTileset.AutoScrollPosition.Y + selectedRow * 16, 16, 16));

        if (showTileMarker && hoveredTilesetTile != -1) {
          int visibleColumns = panelTileset.Width / 16;
          int visibleRows = panelTileset.Height / 16;
          int hoveredX = hoveredTilesetTile % visibleColumns;
          int hoveredY = hoveredTilesetTile / visibleColumns;

          int startX = panelTileset.AutoScrollPosition.X % 16 + hoveredX * 16;
          int startY = panelTileset.AutoScrollPosition.Y % 16 + hoveredY * 16;
          using var marker = new SolidBrush(Color.FromArgb(0x40, 0x77, 0xff, 0x66));
          using var markedBorder = new Pen(Color.FromArgb(0x80, 0xff, 0xff, 0x00), 1);

          e.Graphics.FillRectangle(marker, new Rectangle(startX + 1, startY + 1, 14, 14));
          e.Graphics.DrawRectangle(markedBorder, new Rectangle(startX, startY, 15, 15));
        }
      }
    }
    #endregion
    #region --- timer animation: tick -------------------------------------------------------------
    private void timerAnimation_Tick(object sender, EventArgs e) {
      if (mapLoading)
        return;

      ++frame;
      panelTileset.Refresh();
      panelMap.Refresh();
    }
    #endregion
    #region --- update map character buttons ------------------------------------------------------
    private void UpdateMapCharacterButtons() {
      if (selectedMapCharacter == -1 || map.MapCharacters[selectedMapCharacter] == null) {
        buttonPositions.Enabled = false;
        buttonPlaceCharacterOnMap.Enabled = false;
        labelCharacterPosition.Visible = false;
      } else {
        var character = map.MapCharacters[selectedMapCharacter];
        //buttonPositions.Enabled = !character.CharacterFlags.HasFlag(Map.CharacterReference.Flags.RandomMovement) &&
        //    (character.Type == CharacterType.Monster || !character.CharacterFlags.HasFlag(Map.CharacterReference.Flags.Stationary));
        buttonPlaceCharacterOnMap.Enabled = !buttonPositions.Enabled;
        labelCharacterPosition.Visible = buttonPlaceCharacterOnMap.Enabled;

        //if (buttonPositions.Enabled) {
        //  if (character.Positions.Count < 288) {
        //    int add = 288 - character.Positions.Count;
        //    int x = character.Positions.Count == 0 ? 1 : character.Positions[0].X;
        //    int y = character.Positions.Count == 0 ? 1 : character.Positions[0].Y;

        //    for (int i = 0; i < add; ++i)
        //      character.Positions.Add(new Ambermoon.Position(x, y));
        //  }
        //} else {
        //  if (character.Positions.Count == 0)
        //    character.Positions.Add(new Ambermoon.Position(0, 0));
        //  else if (character.Positions.Count > 1)
        //    character.Positions.RemoveRange(1, character.Positions.Count - 1);

        //  var position = character.Positions[0];
        //  UpdateMapCharacterPosition(position);
        //}
      }
    }
    #endregion
    #region --- update map character position -----------------------------------------------------
    private void UpdateMapCharacterPosition(Position position) {
      labelCharacterPosition.Text = $"Location: {position.X}, {position.Y}";
    }
    #endregion
  }
}