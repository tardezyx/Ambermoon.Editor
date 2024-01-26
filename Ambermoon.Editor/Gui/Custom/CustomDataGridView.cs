namespace Ambermoon.Editor.Gui.Custom {
  internal class CustomDataGridView : DataGridView {
    #region --- constructor -----------------------------------------------------------------------
    public CustomDataGridView() : base() {
      SetStyle(
        ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint,
        true
      );

      BackgroundColor                         = Color.FromArgb(255, 24, 32, 48);
      BorderStyle                             = BorderStyle.FixedSingle;
      ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 8, 16, 24);
      ColumnHeadersDefaultCellStyle.Font      = new(Font, FontStyle.Bold);
      ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255, 255);
      DefaultCellStyle.BackColor              = Color.FromArgb(255, 16, 24, 32);
      DefaultCellStyle.ForeColor              = Color.FromArgb(255, 200, 200, 200);
      EnableHeadersVisualStyles               = false;
      Font                                    = new(Font.FontFamily, 8);
      RowTemplate.Resizable                   = DataGridViewTriState.False;
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

      if (e.CellStyle is not null && !Columns[e.ColumnIndex].ReadOnly) { 
        e.CellStyle.BackColor = Color.FromArgb(255, 32, 48, 64);
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
          buttonColumn.DefaultCellStyle.BackColor = Color.FromArgb(255, 16, 24, 32);
          buttonColumn.DefaultCellStyle.ForeColor = Color.FromArgb(255, 192, 0, 0);
          buttonColumn.DefaultCellStyle.Font      = new(Font, FontStyle.Bold);
          buttonColumn.Width                      = 60;
        }
        if (column is DataGridViewComboBoxColumn comboBoxColumn) {
          comboBoxColumn.FlatStyle = FlatStyle.Flat;
        }
      }
    }
    #endregion
  }
}