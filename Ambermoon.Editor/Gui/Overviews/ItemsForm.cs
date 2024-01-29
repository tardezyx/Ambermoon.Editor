using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Gui.Editors;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews {
  public partial class ItemsForm : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private readonly ListWrapper<ItemData> _items;
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public ItemsForm() {
      InitializeComponent();
      _items = new(Repository.Current.GameData?.Items);
    }
    #endregion
    #region --- init dgv --------------------------------------------------------------------------
    private void InitDGV() {
      _ = User32.SendMessage(Handle, (int)User32.WindowMessages.SetRedraw, false, 0);

      dgv.AutoGenerateColumns = false;

      dgv.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewButtonColumn () { DataPropertyName = "Remove", Text = "X", UseColumnTextForButtonValue = true },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Index) },
        new DataGridViewImageColumn()   { DataPropertyName = "Graphic" },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Type) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Name) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Weight) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Price) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.EnchantPrice) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.EquipmentSlot) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.NumberOfFingers) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.NumberOfHands) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.BreakChance) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Attribute) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.AttributeValue) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Skill) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.SkillValue) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.PenaltySkill1) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.PenaltyValue1) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.PenaltySkill2) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.PenaltyValue2) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.HitPoints) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Damage) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.MagicAttackLevel) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Defense) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.MagicDefenseLevel) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.AmmunitionType) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.UsedAmmunitionType) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.InitialNumberOfRecharges) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.MaxNumberOfRecharges) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Spell) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.InitialSpellCharges) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.MaxSpellCharges) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Flags) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.DefaultSlotFlags) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.SpecialItemPurpose) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.TextIndex) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.TextSubIndex) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Transportation) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Gender) },
        new DataGridViewTextBoxColumn() { DataPropertyName = nameof(ItemData.Classes) },
      });

      foreach (DataGridViewColumn column in dgv.Columns) {
        column.HeaderText = column.Name = column.DataPropertyName;
      }

      dgv.DataSource = _items.ForDisplay;
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
    #region --- on shown --------------------------------------------------------------------------
    protected override void OnShown(EventArgs e) {
      base.OnShown(e);

      SetGraphics();
    }
    #endregion
    #region --- set graphics ----------------------------------------------------------------------
    private void SetGraphics() {
      foreach (DataGridViewRow row in dgv.Rows) {
        if (
          row.DataBoundItem is ItemData item
          && row.Cells["Graphic"] is DataGridViewImageCell graphicCell
        ) {
          graphicCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
          graphicCell.Value       = item.GetGraphic();
        }
      }
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnAdd.Click += (s, e) => AddItem();

      dgv.CellClick += (s, e) => { 
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn) {
          RemoveItem((ItemData)dgv.Rows[e.RowIndex].DataBoundItem);
        }
      };

      dgv.CellDoubleClick += (s, e) => {
        if(e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is not DataGridViewButtonColumn) {
          ChangeItem((ItemData)dgv.Rows[e.RowIndex].DataBoundItem, e.RowIndex);
        }
      };

      dgv.Sorted += (s, e) => SetGraphics();
    }
    #endregion

    #region --- add item --------------------------------------------------------------------------
    private void AddItem() {
      if (_items.InRepository.Create() is ItemData newItem) {
        EditItemForm form = new(newItem);

        if (form.ShowDialog() == DialogResult.OK) {
          _items.Add(newItem);
          dgv.AutoResizeColumns();

          foreach (DataGridViewRow row in dgv.Rows) {
            if (((ItemData)row.DataBoundItem).Index == newItem.Index) {
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
    #region --- change item -----------------------------------------------------------------------
    private void ChangeItem(ItemData item, int rowIndex) {
      EditItemForm form = new(item);

      if (form.ShowDialog() == DialogResult.OK) {
        _items.HasBeenChanged();
        dgv.InvalidateRow(rowIndex);
        dgv.AutoResizeColumns();
      }
    }
    #endregion
    #region --- remove item -----------------------------------------------------------------------
    private void RemoveItem(ItemData item) {
      string n = Environment.NewLine;

      if (
        MsgBox.Show(
          $"Remove {item.Index}: {item.Type} - ({item.Name})?",
          $"Do you really want to remove the following item?{n}{n}"
          + $"Index: {item.Index}{n}Type: {item.Type}{n}Name: {item.Name}",
          MessageBoxButtons.YesNo
        ) == DialogResult.Yes
      ) {
        _items.Remove(item);
        dgv.AutoResizeColumns();
      }
    }
    #endregion
  }
}