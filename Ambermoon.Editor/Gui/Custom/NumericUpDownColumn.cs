namespace Ambermoon.Editor.Gui.Custom {
  internal class NumericUpDownColumn : DataGridViewColumn {
    public int MaxValue { get; set; }
    public int MinValue { get; set; }

    public NumericUpDownColumn() : base(new NumericUpDownCell()) { }

    public override DataGridViewCell CellTemplate {
      get { return base.CellTemplate; }
      set {
        if (value != null && !value.GetType().IsAssignableFrom(typeof(NumericUpDownCell))) {
          throw new InvalidCastException("Must be a NumericUpDownCell");
        }
        base.CellTemplate = value;
      }
    }
  }
}