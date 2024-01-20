using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Data.GameDataRepository.Util;
using Ambermoon.Editor.Gui.Controls;
using Ambermoon.Editor.Gui.Editors;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews {
  public partial class NPCsForm : Form {
    #region --- fields ----------------------------------------------------------------------------
    private readonly ListWrapper<NpcData> _npcs;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public NPCsForm(DictionaryList<NpcData> npcs) {
      InitializeComponent();
      _npcs = new(npcs);
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      dgv.AutoGenerateColumns = false;

      dgv.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewButtonColumn () { DataPropertyName = "Remove", Text = "X", UseColumnTextForButtonValue = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(NpcData.Index) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(NpcData.Name) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(NpcData.Level) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(NpcData.Type) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(NpcData.Race) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(NpcData.Class) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(NpcData.Gender) },
      });

      foreach (DataGridViewColumn column in dgv.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      dgv.DataSource = _npcs.ForDisplay;
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
      btnAdd.Click += (s, e) => AddNPC();

      dgv.CellClick += (s, e) => { 
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) {
          RemoveNPC((NpcData)dgv.Rows[e.RowIndex].DataBoundItem);
        }
      };

      dgv.CellDoubleClick += (s, e) => {
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is not DataGridViewButtonColumn) {
          ChangeNPC((NpcData)dgv.Rows[e.RowIndex].DataBoundItem, e.RowIndex);
        }
      };
    }
    #endregion

    #region --- add npc ---------------------------------------------------------------------------
    private void AddNPC() {
      uint index = _npcs.GetFirstFreeIndex();

      NPCForm form = new(
        new NpcData() {
          Index = index,
          Name  = "(NEW...)"
        }
      );

      if (form.ShowDialog() == DialogResult.OK) {
        _npcs.Add(form.NPC);
        dgv.AutoResizeColumns();

        foreach (DataGridViewRow row in dgv.Rows) {
          if (((NpcData)row.DataBoundItem).Index == index) {
            dgv.ClearSelection();
            dgv.FirstDisplayedScrollingRowIndex = row.Index;
            row.Selected = true;

            break;
          }
        }
      }
    }
    #endregion
    #region --- change npc ------------------------------------------------------------------------
    private void ChangeNPC(NpcData npc, int rowIndex) {
      NPCForm form = new(npc);

      if (form.ShowDialog() == DialogResult.OK) {
        _npcs.HasBeenChanged();
        dgv.InvalidateRow(rowIndex);
        dgv.AutoResizeColumns();
      }
    }
    #endregion
    #region --- remove npc ------------------------------------------------------------------------
    private void RemoveNPC(NpcData npc) {
      string n = Environment.NewLine;

      if (
        MsgBox.Show(
          $"Remove {npc.Index}: {npc.Name} (...)?",
          $"Do you really want to remove the following NPC?{n}{n}"
          + $"Index: {npc.Index}{n}Name: {npc.Name}{n}Level: ...",
          MessageBoxButtons.YesNo
        ) == DialogResult.Yes
      ) {
        _npcs.Remove(npc);
        dgv.AutoResizeColumns();
      }
    }
    #endregion
  }
}