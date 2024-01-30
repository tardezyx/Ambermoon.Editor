using Ambermoon.Data.GameDataRepository;
using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Gui.Editors;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews {
  public partial class MonsterGroupsForm : CustomForm {
    #region --- local class: monster details ------------------------------------------------------
    private class MonsterDetails {
      public int    Count { get; set; } = 0;
      public uint   Index { get; set; } = 0;
      public uint   Level { get; set; } = 0;
      public string Name  { get; set; } = string.Empty;
    }
    #endregion
    #region --- local class: monster group as text ------------------------------------------------
    private class MonsterGroupAsText { 
      public uint   Index    { get; set; } = 0;
      public string Monsters { get; set; } = string.Empty;
    }
    #endregion
    #region --- local enum: order by --------------------------------------------------------------
    private enum OrderBy { 
      Count = 1,
      Index,
      Level,
      Name
    }
    #endregion
    #region --- fields ----------------------------------------------------------------------------
    private readonly ListWrapper<MonsterGroupData>           _monsterGroups;
    private readonly SortableBindingList<MonsterGroupAsText> _monsterGroupsAsText;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public MonsterGroupsForm() {
      InitializeComponent();

      _monsterGroups       = new(Repository.Current.GameData?.MonsterGroups);
      _monsterGroupsAsText = [];

      Dictionary<OrderBy, string> orderOptions = [];
      foreach (OrderBy entry in ((OrderBy[])Enum.GetValues(typeof(OrderBy))).Distinct()) {
        orderOptions.Add(entry, entry.ToString());
      }

      cbxOrderBy.DataSource    = new BindingSource(orderOptions, null);
      cbxOrderBy.DisplayMember = "Value";
      cbxOrderBy.ValueMember   = "Key";
      cbxOrderBy.SelectedValue = OrderBy.Level;
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

      dgv.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewButtonColumn () { Name = "Remove", Text = "X", UseColumnTextForButtonValue = true },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterGroupAsText.Index) },
        new DataGridViewTextBoxColumn() { Name = nameof(MonsterGroupAsText.Monsters) },
      });

      dgv.Columns[nameof(MonsterGroupAsText.Monsters)].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

      dgv.DataSource = _monsterGroupsAsText;
      ResizeDGV();
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      MapMonsterGroupsToText();
      InitDGV();
      WireEvents();
    }
    #endregion
    #region --- resize dgv ------------------------------------------------------------------------
    private void ResizeDGV() {
      dgv.Columns["Monsters"].Width = 500;
      dgv.AutoResizeColumns();
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnAdd.Click += (s, e) => AddMonsterGroup();

      cbxOrderBy.SelectedIndexChanged += (s, e) => MapMonsterGroupsToText();
      chbxDescending.CheckedChanged   += (s, e) => MapMonsterGroupsToText();

      dgv.CellClick += (s, e) => { 
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) {
          RemoveMonsterGroup((MonsterGroupAsText)dgv.Rows[e.RowIndex].DataBoundItem);
        }
      };

      dgv.CellDoubleClick += (s, e) => {
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is not DataGridViewButtonColumn) {
          ChangeMonsterGroup((MonsterGroupAsText)dgv.Rows[e.RowIndex].DataBoundItem, e.RowIndex);
        }
      };
    }
    #endregion

    #region --- add monster group -----------------------------------------------------------------
    private void AddMonsterGroup() {
      if (_monsterGroups.InRepository.Create() is MonsterGroupData newMonsterGroup) { 
        EditMonsterGroupForm form = new(newMonsterGroup);

        if (form.ShowDialog() == DialogResult.OK) {
          _monsterGroups.Add(form.MonsterGroup);
          _monsterGroupsAsText.Add(MapMonsterGroupToText(newMonsterGroup));
          ResizeDGV();

          foreach (DataGridViewRow row in dgv.Rows) {
            if (((MonsterGroupAsText)row.DataBoundItem).Index == newMonsterGroup.Index) {
              dgv.ClearSelection();
              dgv.FirstDisplayedScrollingRowIndex = row.Index;
              row.Selected = true;

              break;
            }
          }
        }
      }
    }
    #endregion
    #region --- change monster group  -------------------------------------------------------------
    private void ChangeMonsterGroup(MonsterGroupAsText monsterGroupAsText, int rowIndex) {
      if (_monsterGroups.Get(monsterGroupAsText.Index) is MonsterGroupData monsterGroup) {
        EditMonsterGroupForm form = new(monsterGroup);

        if (form.ShowDialog() == DialogResult.OK) {
          monsterGroupAsText.Monsters = MapMonsterDetailsToText(MapMonsterGroupToDetails(monsterGroup));
          _monsterGroups.HasBeenChanged();
          dgv.InvalidateRow(rowIndex);
          ResizeDGV();
        }
      }
    }
    #endregion
    #region --- map monsters details to text ------------------------------------------------------
    private string MapMonsterDetailsToText(List<MonsterDetails> monstersDetails) {
      string result = string.Empty;

      if (monstersDetails.Count == 0) {
        return result;
      }

      monstersDetails = cbxOrderBy.SelectedValue switch {
        OrderBy.Count => chbxDescending.Checked ? [.. monstersDetails.OrderByDescending(x => x.Count)] : [.. monstersDetails.OrderBy(x => x.Count)],
        OrderBy.Index => chbxDescending.Checked ? [.. monstersDetails.OrderByDescending(x => x.Index)] : [.. monstersDetails.OrderBy(x => x.Index)],
        OrderBy.Level => chbxDescending.Checked ? [.. monstersDetails.OrderByDescending(x => x.Level)] : [.. monstersDetails.OrderBy(x => x.Level)],
        OrderBy.Name  => chbxDescending.Checked ? [.. monstersDetails.OrderByDescending(x => x.Name)]  : [.. monstersDetails.OrderBy(x => x.Name)],
        _ => throw new NotImplementedException(),
      };

      foreach (MonsterDetails monsterDetails in monstersDetails) {
        result = result
          + (result.HasText()
            ? $"{Environment.NewLine}"
            : string.Empty)
          + $"{monsterDetails.Count}x {monsterDetails.Index}: {monsterDetails.Name} ({monsterDetails.Level})";
      }

      return result;
    }
    #endregion
    #region --- map monster group to details ------------------------------------------------------
    private List<MonsterDetails> MapMonsterGroupToDetails(MonsterGroupData monsterGroup) {
      List<MonsterDetails> result = [];

      foreach (uint monsterIndex in monsterGroup.MonsterIndices.Where(x => x > 0)) {
        if (result.FirstOrDefault(x => x.Index == monsterIndex) is MonsterDetails monsterDetailsInList) {
          monsterDetailsInList.Count++;
        } else { 
          MonsterDetails monsterDetails = new() {
            Count = 1,
            Index = monsterIndex,
          };

          if (
            Repository.Current.GameData is GameDataRepository repository
            && repository.Monsters.ContainsKey(monsterIndex)
          ) {
            monsterDetails.Level = repository.Monsters[monsterIndex].Level;
            monsterDetails.Name = repository.Monsters[monsterIndex].Name;
          }

          result.Add(monsterDetails);
        }
      }

      return result;
    }
    #endregion
    #region --- map monster group to text ---------------------------------------------------------
    private MonsterGroupAsText MapMonsterGroupToText(MonsterGroupData monsterGroup) {
      return new() { 
        Index    = monsterGroup.Index,
        Monsters = MapMonsterDetailsToText(MapMonsterGroupToDetails(monsterGroup))
      };
    }
    #endregion
    #region --- map monster groups to text --------------------------------------------------------
    private void MapMonsterGroupsToText() {
      _monsterGroupsAsText.Clear();

      foreach (MonsterGroupData monsterGroup in _monsterGroups.InRepository) {
        _monsterGroupsAsText.Add(MapMonsterGroupToText(monsterGroup));
      }
    }
    #endregion
    #region --- remove monster group --------------------------------------------------------------
    private void RemoveMonsterGroup(MonsterGroupAsText monsterGroupAsText) {
      if (_monsterGroups.Get(monsterGroupAsText.Index) is MonsterGroupData monsterGroup) {
        string n = Environment.NewLine;

        if (
          MsgBox.Show(
            $"Remove {monsterGroup.Index}?",
            $"Do you really want to remove the following monster group?{n}{n}"
            + $"Index: {monsterGroup.Index}{n}Monsters:{n}{monsterGroupAsText.Monsters}",
            MessageBoxButtons.YesNo
          ) == DialogResult.Yes
        ) {
          _monsterGroupsAsText.Remove(monsterGroupAsText);
          _monsterGroups.Remove(monsterGroup);
          ResizeDGV();
        }
      }
    }
    #endregion
  }
}