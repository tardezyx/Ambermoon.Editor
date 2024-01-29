using Ambermoon.Editor.Gui.Custom;

namespace Ambermoon.Editor.Gui.Overviews {
  partial class ItemsForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      dgv = new CustomDataGridView();
      grbxItems = new GroupBox();
      btnAdd = new Button();
      ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
      grbxItems.SuspendLayout();
      SuspendLayout();
      // 
      // dgv
      // 
      dgv.AllowUserToAddRows = false;
      dgv.AllowUserToDeleteRows = false;
      dgv.AllowUserToOrderColumns = true;
      dgv.AllowUserToResizeRows = false;
      dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dgv.BackgroundColor = SystemColors.Control;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv.Location = new Point(6, 51);
      dgv.MultiSelect = false;
      dgv.Name = "dgv";
      dgv.ReadOnly = true;
      dgv.RowHeadersVisible = false;
      dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgv.Size = new System.Drawing.Size(587, 255);
      dgv.TabIndex = 0;
      // 
      // grbxItems
      // 
      grbxItems.Controls.Add(btnAdd);
      grbxItems.Controls.Add(dgv);
      grbxItems.Dock = DockStyle.Fill;
      grbxItems.Location = new Point(0, 0);
      grbxItems.Name = "grbxItems";
      grbxItems.Size = new System.Drawing.Size(599, 318);
      grbxItems.TabIndex = 2;
      grbxItems.TabStop = false;
      grbxItems.Text = "Items";
      // 
      // btnAdd
      // 
      btnAdd.Location = new Point(6, 22);
      btnAdd.Name = "btnAdd";
      btnAdd.Size = new System.Drawing.Size(75, 23);
      btnAdd.TabIndex = 2;
      btnAdd.Text = "Add";
      btnAdd.UseVisualStyleBackColor = true;
      // 
      // ItemsForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(599, 318);
      Controls.Add(grbxItems);
      DoubleBuffered = true;
      FormBorderStyle = FormBorderStyle.None;
      Name = "ItemsForm";
      Text = "ItemsForm";
      ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
      grbxItems.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion

    private CustomDataGridView dgv;
    private GroupBox grbxItems;
    private Button btnAdd;
  }
}