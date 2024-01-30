using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Gui.Editors;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews {
  public partial class MapsForm : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private readonly ListWrapper<MapData> _maps;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public MapsForm() {
      InitializeComponent();
      _maps = new(Repository.Current.GameData?.Maps);
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      dgv.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewButtonColumn () { Name = "Remove", Text = "X", UseColumnTextForButtonValue = true },
        new DataGridViewTextBoxColumn() { Name = nameof(MapData.Index) },
        new DataGridViewTextBoxColumn() { Name = nameof(MapData.World) },
        new DataGridViewTextBoxColumn() { Name = nameof(MapData.Type) },
        new DataGridViewTextBoxColumn() { Name = nameof(MapData.Width) },
        new DataGridViewTextBoxColumn() { Name = nameof(MapData.Height) },
        new DataGridViewTextBoxColumn() { Name = nameof(MapData.Flags) },
      });

      dgv.DataSource = _maps.ForDisplay;
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      InitDGV();
      WireEvents();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      //btnAdd.Click += (s, e) => AddMonster();

      dgv.CellClick += (s, e) => { 
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) {
          //RemoveMonster((MonsterData)dgv.Rows[e.RowIndex].DataBoundItem);
        }
      };

      dgv.CellDoubleClick += (s, e) => {
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is not DataGridViewButtonColumn) {
          ChangeMap((MapData)dgv.Rows[e.RowIndex].DataBoundItem, e.RowIndex);
        }
      };
    }
    #endregion

    //#region --- add monster -----------------------------------------------------------------------
    //private void AddMonster() {
    //  uint index = _maps.GetFirstFreeIndex();

    //  MonsterForm form = new(
    //    new MonsterData() {
    //      Index = index,
    //      Name  = "(NEW...)"
    //    }
    //  );

    //  if (form.ShowDialog() == DialogResult.OK) {
    //    _maps.Add(form.Monster);
    //    dgv.AutoResizeColumns();

    //    foreach (DataGridViewRow row in dgv.Rows) {
    //      if (((MonsterData)row.DataBoundItem).Index == index) {
    //        dgv.ClearSelection();
    //        dgv.FirstDisplayedScrollingRowIndex = row.Index;
    //        row.Selected = true;

    //        break;
    //      }
    //    }
    //  }
    //}
    //#endregion
    #region --- change map --------------------------------------------------------------------
    private void ChangeMap(MapData map, int rowIndex) {
      EditMap2DForm form = new(map);

      if (form.ShowDialog() == DialogResult.OK) {
        _maps.HasBeenChanged();
        dgv.InvalidateRow(rowIndex);
        dgv.AutoResizeColumns();
      }
    }
    #endregion
    //#region --- remove monster --------------------------------------------------------------------
    //private void RemoveMonster(MonsterData monster) {
    //  string n = Environment.NewLine;

    //  if (
    //    MsgBox.Show(
    //      $"Remove {monster.Index}: {monster.Name} ({monster.Level})?",
    //      $"Do you really want to remove the following monster?{n}{n}"
    //      + $"Index: {monster.Index}{n}Name: {monster.Name}{n}Level: {monster.Level}",
    //      MessageBoxButtons.YesNo
    //    ) == DialogResult.Yes
    //  ) {
    //    _maps.Remove(monster);
    //    dgv.AutoResizeColumns();
    //  }
    //}
    //#endregion
  }
}