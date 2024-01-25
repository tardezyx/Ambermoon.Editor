namespace Ambermoon.Editor.Gui.Custom {
  internal class NumericUpDownEditingControl : NumericUpDown, IDataGridViewEditingControl {
    #region --- fields ----------------------------------------------------------------------------
    private DataGridView? _dgv;
    private int           _rowIndexNum;
    private bool          _valueIsChanged = false;
    #endregion
    #region --- properties ------------------------------------------------------------------------
    public DataGridView? EditingControlDataGridView {
      get { return _dgv; }
      set { _dgv = value; }
    }

    public object EditingControlFormattedValue {
      get { return Value.ToString("F0"); }
      set { Value = Decimal.Parse(value.ToString()!); }
    }

    public int EditingControlRowIndex {
      get { return _rowIndexNum; }
      set { _rowIndexNum = value; }
    }

    public bool EditingControlValueChanged {
      get { return _valueIsChanged; }
      set { _valueIsChanged = value; }
    }

    public Cursor EditingPanelCursor {
      get { return base.Cursor; }
    }

    public bool RepositionEditingControlOnValueChange {
      get { return false; }
    }
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public NumericUpDownEditingControl() : base() {
      DecimalPlaces = 0;
    }
    #endregion
    #region --- apply cell style to editing control -----------------------------------------------
    public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle) {
      BackColor = dataGridViewCellStyle.BackColor;
      Font      = dataGridViewCellStyle.Font;
      ForeColor = dataGridViewCellStyle.ForeColor;
    }
    #endregion
    #region --- editing control wants input key ---------------------------------------------------
    public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey) {
      return (
           keyData == Keys.Left     || keyData == Keys.Right
        || keyData == Keys.Up       || keyData == Keys.Down
        || keyData == Keys.Home     || keyData == Keys.End
        || keyData == Keys.PageDown || keyData == Keys.PageUp
      );
    }
    #endregion
    #region --- get editing control formatted value -----------------------------------------------
    public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) {
      return Value.ToString();
    }
    #endregion
    #region --- on value changed ------------------------------------------------------------------
    protected override void OnValueChanged(EventArgs e) {
      _valueIsChanged = true;
      EditingControlDataGridView?.NotifyCurrentCellDirty(true);
      base.OnValueChanged(e);
    }
    #endregion
    #region --- prepare editing control for edit --------------------------------------------------
    public void PrepareEditingControlForEdit(bool selectAll) { }
    #endregion
  }
}