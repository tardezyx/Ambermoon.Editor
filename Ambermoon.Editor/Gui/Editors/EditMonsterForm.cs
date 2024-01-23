using Ambermoon.Data.GameDataRepository.Data;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditMonsterForm : Form {
    #region --- fields ----------------------------------------------------------------------------
    private MonsterData _monster;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditMonsterForm(MonsterData monster) {
      InitializeComponent();

      _monster = monster;
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();

      tbxIndex.Text = _monster.Index.ToString();
      tbxName.Text  = _monster.Name;

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
      _monster.Name = tbxName.Text;
      // ...
    }
    #endregion
  }
}