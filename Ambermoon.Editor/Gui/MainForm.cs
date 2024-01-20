using Ambermoon.Data.GameDataRepository;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Controls;
using Ambermoon.Editor.Gui.Overviews;

namespace Ambermoon.Editor.Gui {
  public partial class MainForm : Form {
    #region --- fields ----------------------------------------------------------------------------
    private GameDataRepository? _repository;
    private string              _repositoryFolder  = string.Empty;
    private bool                _repositoryIsDirty = false;

    //private InfoForm?          _infoForm;
    private MonstersForm?      _monstersForm;
    private MonsterGroupsForm? _monsterGroupsForm;
    private NPCsForm?          _npcsForm;
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
    #region --- node selected ---------------------------------------------------------------------
    private void NodeSelected(string? nodeName) {
      if (nodeName.IsNullOrEmpty()) {
        return;
      }
      
      switch (nodeName) { 
        // case "trvNodeInfo":
        //   if (_infoForm is null || _infoForm.IsDisposed) { 
        //     _infoForm = new();
        //     AddForm(_infoForm);
        //   }

        //   ShowForm(_infoForm);
        //   break;

        case "trvNodeCharactersMonsters":
          if (_monstersForm is null || _monstersForm.IsDisposed) { 
            _monstersForm = new(_repository!.Monsters);
            AddForm(_monstersForm);
          }

          ShowForm(_monstersForm);
          break;

        case "trvNodeCharactersMonsterGroups":
          if (_monsterGroupsForm is null || _monsterGroupsForm.IsDisposed) {
            _monsterGroupsForm = new(_repository!.Monsters, _repository!.MonsterGroups);
            AddForm(_monsterGroupsForm);
          }

          ShowForm(_monsterGroupsForm);
          break;

        case "trvNodeCharactersNPCs":
          if (_npcsForm is null || _npcsForm.IsDisposed) { 
            _npcsForm = new(_repository!.Npcs);
            AddForm(_npcsForm);
          }

          ShowForm(_npcsForm);
          break;
      }

      void AddForm(Form form) {
        form.Dock = DockStyle.Fill;
        form.TopLevel = false;
        splitContainer.Panel2.Controls.Add(form);
      }

      void ShowForm(Form form) {
        foreach (Control control in splitContainer.Panel2.Controls) {
          if (control is Form && control != form) {
            control.Hide();
            control.SendToBack();
          }
        }

        form.Show();
        form.BringToFront();
      }
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
  }
}