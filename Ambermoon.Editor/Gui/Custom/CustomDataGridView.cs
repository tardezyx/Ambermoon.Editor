namespace Ambermoon.Editor.Gui.Custom {
  internal class CustomDataGridView : DataGridView {
    #region --- constructor -----------------------------------------------------------------------
    public CustomDataGridView() : base() {
      SetStyle(
        ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint,
        true
      );
    }
    #endregion
    #region --- on cell painting ------------------------------------------------------------------
    protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e) {
      base.OnCellPainting(e);

      if (e.RowIndex < 0 || e.ColumnIndex < 0)
        return;

      if (Columns[e.ColumnIndex] is DataGridViewButtonColumn) {
        return;
      }

      if (e.CellStyle is not null) {
        e.CellStyle.BackColor = Columns[e.ColumnIndex].ReadOnly
          ? Color.FromArgb(220, 220, 220)
          : Color.White;
      }
    }
    #endregion
    #region --- on cell click ---------------------------------------------------------------------
    protected override void OnCellClick(DataGridViewCellEventArgs e) {
      base.OnCellClick(e);

      if (e.RowIndex > -1) {
        if (Columns[e.ColumnIndex] is not DataGridViewButtonColumn) {
          BeginEdit(true);
        }

        if (Columns[e.ColumnIndex] is DataGridViewComboBoxColumn) {
          ((ComboBox)EditingControl).DroppedDown = true;
        }
      }
    }
    #endregion
    #region --- on data binding complete ----------------------------------------------------------
    protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e) {
      base.OnDataBindingComplete(e);

      foreach (DataGridViewColumn column in Columns) {
        if (column is DataGridViewButtonColumn buttonColumn) {
          buttonColumn.FlatStyle                  = FlatStyle.Flat;
          buttonColumn.DefaultCellStyle.BackColor = Color.DarkRed;
          buttonColumn.DefaultCellStyle.ForeColor = Color.MintCream;
          buttonColumn.DefaultCellStyle.Font      = new(Font, FontStyle.Bold);
        }
      }
    }
    #endregion
  }
}