using Ambermoon.Data.GameDataRepository;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Gui.Overviews;
using static Ambermoon.Data.Tileset;

namespace Ambermoon.Editor.Gui {
  public partial class MainForm : Form {
    #region --- fields ----------------------------------------------------------------------------
    private GameDataRepository? _repository;
    private string              _repositoryFolder  = string.Empty;
    private bool                _repositoryIsDirty = false;

    //private readonly InfoForm?          _infoForm;
    private readonly MapsForm?          _mapsForm;
    private readonly MonstersForm?      _monstersForm;
    private readonly MonsterGroupsForm? _monsterGroupsForm;
    private readonly NPCsForm?          _npcsForm;
    #endregion
    #region --- local enum: entity type -----------------------------------------------------------
    private enum EntityType {
      Maps,
      Monsters,
      MonsterGroups,
      NPCs,
    }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public MainForm() {
      InitializeComponent();
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      trv.ExpandAll();
      CenterToScreen();
      UpdateControls();
      WireEvents();
    }
    #endregion
    #region --- update controls -------------------------------------------------------------------
    private void UpdateControls() {
      menuItemLoad.Enabled   = _repository is null;
      menuItemSave.Enabled   =
      menuItemUnload.Enabled =
      splitContainer.Enabled = _repository is not null;
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      menuItemExit.Click   += (s, e) => { SaveRepository(); Application.Exit(); };
      menuItemLoad.Click   += (s, e) => LoadRepository();
      menuItemSave.Click   += (s, e) => SaveRepository();
      menuItemUnload.Click += (s, e) => UnloadRepository();
      trv.AfterSelect      += (s, e) => NodeSelected(e.Node?.Name);
    }
    #endregion

    #region --- load repository -------------------------------------------------------------------
    private void LoadRepository() {
      FolderBrowserDialog folderBrowserDialog = new() { 
        AutoUpgradeEnabled     = true,
        Description            = "Where is your Ambermoon data folder (i.e. Amberfiles)?",
        ShowNewFolderButton    = false,
        UseDescriptionForTitle = true
      };

      if (_repositoryFolder.IsNullOrEmpty()) { 
        folderBrowserDialog.InitialDirectory = _repositoryFolder;
      }

      if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
        _repositoryFolder = folderBrowserDialog.SelectedPath;
      }

      try {
        _repository = new(_repositoryFolder);
      } catch (Exception ex) {
        MsgBox.Show(
          "Error",
          $"Repository could not be loaded:{Environment.NewLine}{Environment.NewLine}{ex.Message}"
        );
      }

      UpdateControls();
    }
    #endregion
    #region --- save repository -------------------------------------------------------------------
    private void SaveRepository() {
      if (_repositoryIsDirty) {
        _repository?.Save(_repositoryFolder);
        _repositoryIsDirty = false;
      }
    }
    #endregion
    #region --- unload repository -----------------------------------------------------------------
    private void UnloadRepository() {
      if (
        _repositoryIsDirty
        && MsgBox.Show(
          "Save before unload?",
          "Do you want to save the changes you've made before unloading?",
          MessageBoxButtons.YesNo
        ) == DialogResult.Yes
      ) {
        SaveRepository();
      }

      _repository = null;

      for (int i = splitContainer.Panel2.Controls.Count - 1; i > -1; i--) {
        if (splitContainer.Panel2.Controls[i] is Form form) { 
          splitContainer.Panel2.Controls.Remove(form);
          form.Close();
        }
      }

      UpdateControls();
    }
    #endregion

    #region --- node selected ---------------------------------------------------------------------
    private void NodeSelected(string? nodeName) {
      if (nodeName.IsNullOrEmpty()) {
        return;
      }

      Tile tile = new();
      tile.Flags |= (true ? TileFlags.AllowMovementWitchBroom : TileFlags.None)
                 |  (true ? TileFlags.None : TileFlags.None);
      
      switch (nodeName) { 
        //case "trvNodeInfo":                    ShowForm(EntityType.Maps);          break;
        case "trvNodeMaps":                    ShowForm(EntityType.Maps);          break;
        case "trvNodeCharactersMonsters":      ShowForm(EntityType.Monsters);      break;
        case "trvNodeCharactersMonsterGroups": ShowForm(EntityType.MonsterGroups); break;
        case "trvNodeCharactersNPCs":          ShowForm(EntityType.NPCs);          break;
      }
    }
    #endregion
    #region --- show form -------------------------------------------------------------------------
    private void ShowForm(EntityType type) {
      Form? form = type switch {
        EntityType.Maps          => _mapsForm,
        EntityType.Monsters      => _monstersForm,
        EntityType.MonsterGroups => _monsterGroupsForm,
        EntityType.NPCs          => _npcsForm,
        _                        => throw new NotImplementedException(),
      };

      if (form is null || form.IsDisposed ) { 
        form = type switch {
          EntityType.Maps          => new MapsForm(_repository!.Maps, _repository!.MapTexts),
          EntityType.Monsters      => new MonstersForm(_repository!.Monsters),
          EntityType.MonsterGroups => new MonsterGroupsForm(_repository!.Monsters, _repository!.MonsterGroups),
          EntityType.NPCs          => new NPCsForm(_repository!.Npcs),
          _                        => throw new NotImplementedException(),
        };

        form.Dock = DockStyle.Fill;
        form.TopLevel = false;
        splitContainer.Panel2.Controls.Add(form);
      }

      foreach (Control control in splitContainer.Panel2.Controls) {
        if (control is Form && control != form) {
          control.Hide();
          control.SendToBack();
        }
      }

      form.Show();
      form.BringToFront();
    }
    #endregion
  }
}