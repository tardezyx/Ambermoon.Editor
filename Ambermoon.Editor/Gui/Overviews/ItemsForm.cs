using Ambermoon.Data.GameDataRepository.Data;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Gui.Editors;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Gui.Overviews {
	public partial class ItemsForm : CustomForm
	{
		#region --- fields ----------------------------------------------------------------------------
		private readonly ListWrapper<ItemData> _items;
		#endregion

		#region --- constructor -----------------------------------------------------------------------
		public ItemsForm()
		{
			InitializeComponent();
			_items = new(Repository.Current.GameData?.Items);
		}
		#endregion
		#region --- init dgv --------------------------------------------------------------------------
		private void InitDGV()
		{
			dgv.Columns.AddRange(new DataGridViewColumn[] {
		new DataGridViewButtonColumn () { Name = "Remove", Text = "X", UseColumnTextForButtonValue = true },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Index) },
		new DataGridViewImageColumn()   { Name = "Graphic" },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Type) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Name) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Weight) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Price) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.EnchantPrice) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.EquipmentSlot) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.NumberOfFingers) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.NumberOfHands) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.BreakChance) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Attribute) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.AttributeValue) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Skill) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.SkillValue) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.PenaltySkill1) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.PenaltyValue1) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.PenaltySkill2) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.PenaltyValue2) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.HitPoints) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Damage) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.MagicAttackLevel) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Defense) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.MagicDefenseLevel) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.AmmunitionType) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.UsedAmmunitionType) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.InitialNumberOfRecharges) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.MaxNumberOfRecharges) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Spell) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.InitialSpellCharges) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.MaxSpellCharges) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Flags) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.DefaultSlotFlags) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.SpecialItemPurpose) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.TextIndex) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.TextSubIndex) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Transportation) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Gender) },
		new DataGridViewTextBoxColumn() { Name = nameof(ItemData.Classes) },
	  });

			dgv.DataSource = _items.ForDisplay;
		}
		#endregion
		#region --- on load ---------------------------------------------------------------------------
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			InitDGV();
			WireEvents();
		}
		#endregion
		#region --- on shown --------------------------------------------------------------------------
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			SetGraphics();
		}
		#endregion
		#region --- set graphics ----------------------------------------------------------------------
		private void SetGraphics()
		{
			foreach (DataGridViewRow row in dgv.Rows)
			{
				if (
				  row.DataBoundItem is ItemData item
				  && row.Cells["Graphic"] is DataGridViewImageCell graphicCell
				)
				{
					graphicCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
					graphicCell.Value = item.GetGraphic();
				}
			}
		}
		#endregion
		#region --- wire events -----------------------------------------------------------------------
		private void WireEvents()
		{
			btnAdd.Click += (s, e) => AddItem();

			dgv.CellClick += (s, e) =>
			{
				if (e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
				{
					RemoveItem((ItemData)dgv.Rows[e.RowIndex].DataBoundItem);
				}
			};

			dgv.CellDoubleClick += (s, e) =>
			{
				if (e.RowIndex > -1 && dgv.Columns[e.ColumnIndex] is not DataGridViewButtonColumn)
				{
					ChangeItem((ItemData)dgv.Rows[e.RowIndex].DataBoundItem, e.RowIndex);
				}
			};

			dgv.Sorted += (s, e) => SetGraphics();
		}
		#endregion

		#region --- add item --------------------------------------------------------------------------
		private void AddItem()
		{
			if (_items.InRepository.Create() is ItemData newItem)
			{
				EditItemForm form = new(newItem);

				if (form.ShowDialog() == DialogResult.OK)
				{
					_items.Add(newItem);
					dgv.AutoResizeColumns();

					foreach (DataGridViewRow row in dgv.Rows)
					{
						if (((ItemData)row.DataBoundItem).Index == newItem.Index)
						{
							if (row.Cells["Graphic"] is DataGridViewImageCell graphicCell)
							{
								graphicCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
								graphicCell.Value = newItem.GetGraphic();
							}

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
		private void ChangeItem(ItemData item, int rowIndex)
		{
			EditItemForm form = new(item);

			if (form.ShowDialog() == DialogResult.OK)
			{
				_items.HasBeenChanged();

				if (dgv.Rows[rowIndex].Cells["Graphic"] is DataGridViewImageCell graphicCell)
				{
					graphicCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
					graphicCell.Value = item.GetGraphic();
				}

				dgv.InvalidateRow(rowIndex);
				dgv.AutoResizeColumns();
			}
		}
		#endregion
		#region --- remove item -----------------------------------------------------------------------
		private void RemoveItem(ItemData item)
		{
			string n = Environment.NewLine;

			if (
			  MsgBox.Show(
				$"Remove {item.Index}: {item.Type} - ({item.Name})?",
				$"Do you really want to remove the following item?{n}{n}"
				+ $"Index: {item.Index}{n}Type: {item.Type}{n}Name: {item.Name}",
				MessageBoxButtons.YesNo
			  ) == DialogResult.Yes
			)
			{
				_items.Remove(item);
				dgv.AutoResizeColumns();
			}
		}
		#endregion

		private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			if (DesignMode)
				e.Cancel = true;
		}
	}
}