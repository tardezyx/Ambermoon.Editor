using Ambermoon.Data.GameDataRepository.Data;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class NPCForm : Form {
    #region --- properties ------------------------------------------------------------------------
    public NpcData NPC { get; private set; }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public NPCForm(NpcData npc) {
      InitializeComponent();

      NPC = npc;
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();

      tbxIndex.Text = NPC.Index.ToString();
      tbxName.Text  = NPC.Name;

      WireEvents();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();
      btnOK.Click     += (s, e) => { MapNPC(); DialogResult = DialogResult.OK; Close(); };
    }
    #endregion

    #region --- map npc ---------------------------------------------------------------------------
    private void MapNPC() {
      NPC.Name = tbxName.Text;
      // ...
    }
    #endregion
  }
}