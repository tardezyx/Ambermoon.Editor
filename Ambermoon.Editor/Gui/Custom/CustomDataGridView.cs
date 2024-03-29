﻿using Ambermoon.Editor.Base;

namespace Ambermoon.Editor.Gui.Custom {
  internal class CustomDataGridView : DataGridView {
    #region --- constructor -----------------------------------------------------------------------
    public CustomDataGridView() : base() {
      if (!Settings.IsNotInDesignMode) { 
        return;
      }

      SetStyle(
        ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint,
        true
      );

      AutoGenerateColumns                     = false;
      BackgroundColor                         = Color.LightGray;
      BorderStyle                             = BorderStyle.FixedSingle;
      ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192, 192);
      ColumnHeadersDefaultCellStyle.Font      = new(Font, FontStyle.Bold);
      ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
      DefaultCellStyle.BackColor              = Color.FromArgb(255, 200, 200, 200);
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
        e.CellStyle.BackColor = Color.FromArgb(255, 255, 255, 255);
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
        column.DataPropertyName = column.HeaderText = column.Name;

        if (column is DataGridViewButtonColumn buttonColumn) {
          buttonColumn.FlatStyle                  = FlatStyle.Flat;
          buttonColumn.DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192, 192);
          buttonColumn.DefaultCellStyle.ForeColor = Color.FromArgb(255, 127, 0, 0);
          buttonColumn.DefaultCellStyle.Font      = new(Font, FontStyle.Bold);
          buttonColumn.Width                      = 60;
        }

        //if (column is DataGridViewComboBoxColumn comboBoxColumn) {
        //  comboBoxColumn.FlatStyle = FlatStyle.Flat;
        //}
      }

      AutoResizeColumns();
      ClearSelection();
    }
    #endregion
  }
}