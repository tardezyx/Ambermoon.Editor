using Ambermoon.Data.GameDataRepository;
using Ambermoon.Data.GameDataRepository.Collections;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews {
  public partial class MapsForm : Form {
    #region --- fields ----------------------------------------------------------------------------
    private readonly ListWrapper<MapData> _maps;
    private readonly ListWrapper<TextList<MapData>> _mapTexts;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public MapsForm(
      DictionaryList<MapData>           maps,
      DictionaryList<TextList<MapData>> mapTexts
    ) {
      InitializeComponent();
      _maps     = new(maps);
      _mapTexts = new(mapTexts);
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      dgv.AutoGenerateColumns = false;

      dgv.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewButtonColumn () { DataPropertyName = "Remove", Text = "X", UseColumnTextForButtonValue = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Index) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.World) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Type) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Width) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Height) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Flags) },
      });

      foreach (DataGridViewColumn column in dgv.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      dgv.DataSource = _maps.ForDisplay;
      dgv.AutoResizeColumns();
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
          //ChangeMonster((MonsterData)dgv.Rows[e.RowIndex].DataBoundItem, e.RowIndex);
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
    //#region --- change monster --------------------------------------------------------------------
    //private void ChangeMonster(MonsterData monster, int rowIndex) {
    //  MonsterForm form = new(monster);

    //  if (form.ShowDialog() == DialogResult.OK) {
    //    _maps.HasBeenChanged();
    //    dgv.InvalidateRow(rowIndex);
    //    dgv.AutoResizeColumns();
    //  }
    //}
    //#endregion
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