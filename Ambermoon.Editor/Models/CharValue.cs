namespace Ambermoon.Editor.Models {
  public class CharValue {
    #region --- properties ------------------------------------------------------------------------
    public int    Bonus        { get; set; }
    public uint   Current      { get; set; }
    public uint   Max          { get; set; }
    public string Name         { get; set; } = string.Empty;
    public string Short        { get; set; } = string.Empty;
    public uint   Stored       { get; set; }
    public uint   TotalCurrent { get => (uint)Math.Max(0, (int)Current + Bonus); }
    public uint   TotalMax     { get => (uint)Math.Max(0, (int)Max     + Bonus); }
    #endregion
  }
}