namespace Ambermoon.Editor.Gui.Custom {
  internal class NumericUpDownCell : DataGridViewTextBoxCell {
    public NumericUpDownCell() : base() {
      Style.Format = "F0";
    }
    public NumericUpDownCell(decimal min, decimal max) : base() {
      Style.Format = "F0";
    }

    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle) {
      base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

      if (DataGridView.EditingControl is NumericUpDownEditingControl editingControl) { 
        editingControl.Minimum = ((NumericUpDownColumn)OwningColumn).MinValue;
        editingControl.Maximum = ((NumericUpDownColumn)OwningColumn).MaxValue;
        editingControl.Value = Convert.ToDecimal(this.Value);
      }
    }

    public override Type EditType { get { return typeof(NumericUpDownEditingControl); } }
    public override Type ValueType { get { return typeof(Decimal); } }
    public override object DefaultNewRowValue { get { return null; } } // avoid extra initial values for unedited new lines
  }
}