using Ambermoon.Editor.Base;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui {
  public partial class SettingsForm : CustomForm {
    #region --- constructor -----------------------------------------------------------------------
    public SettingsForm() {
      InitializeComponent();
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();
      MapSettingsToControls();
      WireEvents();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click         += (s, e) => Close();
      btnOK.Click             += (s, e) => { MapControlsToSettings(); DialogResult = DialogResult.OK; Close(); };
      btnGameDataFolder.Click += (s, e) => OpenFolder();
    }
    #endregion

    #region --- open folder -----------------------------------------------------------------------
    private void OpenFolder() {
      FolderBrowserDialog folderBrowserDialog = new() { 
        AutoUpgradeEnabled     = true,
        Description            = "Where is your Ambermoon data folder (i.e. Amberfiles)?",
        InitialDirectory       = tbxGameDataFolder.Text.HasText() ? tbxGameDataFolder.Text : Repository.Current.Folder,
        ShowNewFolderButton    = false,
        UseDescriptionForTitle = true
      };

      if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
        tbxGameDataFolder.Text = folderBrowserDialog.SelectedPath;
      }
    }
    #endregion
    #region --- map controls to settings ----------------------------------------------------------
    private void MapControlsToSettings() {
      Settings.AutoLoadRepository = chbxAutoLoadGameData.Checked;
      Settings.DefaultPath = tbxGameDataFolder.Text;
      Settings.WriteIni();
    }
    #endregion
    #region --- map settings to controls ----------------------------------------------------------
    private void MapSettingsToControls() {
      chbxAutoLoadGameData.Checked = Settings.AutoLoadRepository;
      tbxGameDataFolder.Text = Settings.DefaultPath;
    }
    #endregion
  }
}