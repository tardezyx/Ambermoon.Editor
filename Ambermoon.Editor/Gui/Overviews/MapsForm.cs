using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Gui.Editors;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews
{
	public partial class MapsForm : CustomForm
	{
		#region --- fields ----------------------------------------------------------------------------
		private readonly ListWrapper<MapData> _maps;
		#endregion

		#region --- constructor -----------------------------------------------------------------------
		public MapsForm()
		{
			InitializeComponent();
			var nameFilter = new FilterProperty<MapData>("Name", GetMapName);
			_maps = new(Repository.Current.GameData?.Maps,
				// Filters
				nameFilter,
				nameof(MapData.World),
				nameof(MapData.Type));
		}
		#endregion
		#region --- init dgv --------------------------------------------------------------------------
		private void InitDGV()
		{
			_ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

			dgv.AutoGenerateColumns = false;

			dgv.Columns.AddRange(new DataGridViewColumn[]
			{
				new DataGridViewButtonColumn () { DataPropertyName = "Remove", Text = "X", UseColumnTextForButtonValue = true },
				new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Index) },
				new DataGridViewTextBoxColumn() { DataPropertyName = "Name", ReadOnly = true },
				new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.World) },
				new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Type) },
				new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Width) },
				new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Height) },
				new DataGridViewTextBoxColumn() { DataPropertyName = nameof(MapData.Flags) },
			});

			foreach (DataGridViewColumn column in dgv.Columns)
			{
				column.HeaderText = column.Name = column.DataPropertyName;
			}

			dgv.DataSource = _maps.ForDisplay;
			dgv.AutoResizeColumns();

			_ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
		}
		#endregion
		#region --- on load ---------------------------------------------------------------------------
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			InitDGV();
			WireEvents();
		}
		#endregion
		#region --- wire events -----------------------------------------------------------------------
		private void WireEvents()
		{
			//btnAdd.Click += (s, e) => AddMonster();

			dgv.CellClick += (s, e) =>
			{
				if (e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
				{
					//RemoveMonster((MonsterData)dgv.Rows[e.RowIndex].DataBoundItem);
				}
			};

			dgv.CellDoubleClick += (s, e) =>
			{
				if (e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is not DataGridViewButtonColumn)
				{
					ChangeMap((MapData)dgv.Rows[e.RowIndex].DataBoundItem, e.RowIndex);
				}
			};

			dgv.CellFormatting += (s, e) =>
			{
				if (e.RowIndex > -1 && dgv.Columns[e.ColumnIndex].DataPropertyName == "Name")
				{
					var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
					cell.Value = GetMapName((MapData)dgv.Rows[e.RowIndex].DataBoundItem);
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
		private void ChangeMap(MapData map, int rowIndex)
		{
			// TODO: open map in already open editor
			// TODO: close open editor (maybe if map type differs or in general?)

			if (map.Type == Data.MapType.Map2D)
			{
				EditMap2DForm form = new(map, Repository.Current.GameData!);

				if (form.ShowDialog() == DialogResult.OK)
				{
					_maps.HasBeenChanged();
					dgv.InvalidateRow(rowIndex);
					dgv.AutoResizeColumns();
				}
			}
			else
			{
				MessageBox.Show("3D maps can't be edited in this version.", "Not implemented", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion
		private void FilterMaps_FilterChanged(string filter)
		{
			_maps.ForDisplay.Filter = filter;
		}

		private static string GetMapName(MapData map)
		{
			if (map.WorldMap)
				return $"{map.World} {map.Index:000}";

			if (Repository.Current.GameData!.MapTexts.TryGetValue(map.Index, out var texts) && texts.Count != 0)
				return texts[0];

			return "Unknown map";
		}
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