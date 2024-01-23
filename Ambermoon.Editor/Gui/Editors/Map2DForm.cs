using Ambermoon.Data.GameDataRepository.Data;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class Map2DForm : Form {
    #region --- properties ------------------------------------------------------------------------
    public MapData Map { get; private set; }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public Map2DForm(MapData map) {
      InitializeComponent();

      Map = map;
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();

      tbxIndex.Text = Map.Index.ToString();
      //tbxName.Text  = Map.Name;

      WireEvents();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();
      btnOK.Click     += (s, e) => { MapMap(); DialogResult = DialogResult.OK; Close(); };
    }
    #endregion

    #region --- map map ---------------------------------------------------------------------------
    private void MapMap() {
      //Map.Name = tbxName.Text;
      // ...
    }
    #endregion
  }
}