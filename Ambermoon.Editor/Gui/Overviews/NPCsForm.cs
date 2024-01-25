using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Gui.Editors;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews {
  public partial class NPCsForm : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private readonly ListWrapper<NpcData> _npcs;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public NPCsForm() {
      InitializeComponent();

      _npcs = new(Repository.Current.GameData?.Npcs);
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

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

      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, true, 0);
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
      if (_npcs.InRepository.Create() is NpcData newNPC) {
        EditNPCForm form = new(newNPC);

        if (form.ShowDialog() == DialogResult.OK) {
          _npcs.Add(newNPC);
          dgv.AutoResizeColumns();

          foreach (DataGridViewRow row in dgv.Rows) {
            if (((NpcData)row.DataBoundItem).Index == newNPC.Index) {
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
    #region --- change npc ------------------------------------------------------------------------
    private void ChangeNPC(NpcData npc, int rowIndex) {
      EditNPCForm form = new(npc);

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