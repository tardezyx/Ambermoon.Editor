using Ambermoon.Data.GameDataRepository.Data;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class MonsterForm : Form {
    #region --- properties ------------------------------------------------------------------------
    public MonsterData Monster { get; private set; }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public MonsterForm(MonsterData monster) {
      InitializeComponent();

      Monster = monster;
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();

      tbxIndex.Text = Monster.Index.ToString();
      tbxName.Text  = Monster.Name;

      WireEvents();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();
      btnOK.Click     += (s, e) => { MapMonster(); DialogResult = DialogResult.OK; Close(); };
    }
    #endregion

    #region --- map monster -----------------------------------------------------------------------
    private void MapMonster() {
      Monster.Name = tbxName.Text;
      // ...
    }
    #endregion
  }
}