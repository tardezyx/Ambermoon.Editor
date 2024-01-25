using Ambermoon.Editor.Gui.Custom;

namespace Ambermoon.Editor.Gui.Overviews {
  partial class MonsterGroupsForm {
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
      btnAdd = new Button();
      grbxMonsters = new GroupBox();
      chbxDescending = new CheckBox();
      lblOrderBy = new Label();
      cbxOrderBy = new ComboBox();
      ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
      grbxMonsters.SuspendLayout();
      SuspendLayout();
      // 
      // dgv
      // 
      dgv.AllowUserToAddRows = false;
      dgv.AllowUserToDeleteRows = false;
      dgv.AllowUserToOrderColumns = true;
      dgv.AllowUserToResizeRows = false;
      dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv.Location = new Point(6, 51);
      dgv.MultiSelect = false;
      dgv.Name = "dgv";
      dgv.ReadOnly = true;
      dgv.RowHeadersVisible = false;
      dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgv.Size = new System.Drawing.Size(587, 261);
      dgv.TabIndex = 0;
      // 
      // btnAdd
      // 
      btnAdd.Location = new Point(6, 22);
      btnAdd.Name = "btnAdd";
      btnAdd.Size = new System.Drawing.Size(75, 23);
      btnAdd.TabIndex = 1;
      btnAdd.Text = "Add";
      btnAdd.UseVisualStyleBackColor = true;
      // 
      // grbxMonsters
      // 
      grbxMonsters.Controls.Add(chbxDescending);
      grbxMonsters.Controls.Add(lblOrderBy);
      grbxMonsters.Controls.Add(cbxOrderBy);
      grbxMonsters.Controls.Add(dgv);
      grbxMonsters.Controls.Add(btnAdd);
      grbxMonsters.Dock = DockStyle.Fill;
      grbxMonsters.Location = new Point(0, 0);
      grbxMonsters.Name = "grbxMonsters";
      grbxMonsters.Size = new System.Drawing.Size(599, 318);
      grbxMonsters.TabIndex = 2;
      grbxMonsters.TabStop = false;
      grbxMonsters.Text = "Monster Groups";
      // 
      // chbxDescending
      // 
      chbxDescending.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      chbxDescending.AutoSize = true;
      chbxDescending.Checked = true;
      chbxDescending.CheckState = CheckState.Checked;
      chbxDescending.Location = new Point(505, 22);
      chbxDescending.Name = "chbxDescending";
      chbxDescending.Size = new System.Drawing.Size(88, 19);
      chbxDescending.TabIndex = 4;
      chbxDescending.Text = "Descending";
      chbxDescending.UseVisualStyleBackColor = true;
      // 
      // lblOrderBy
      // 
      lblOrderBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      lblOrderBy.AutoSize = true;
      lblOrderBy.Location = new Point(366, 23);
      lblOrderBy.Name = "lblOrderBy";
      lblOrderBy.Size = new System.Drawing.Size(53, 15);
      lblOrderBy.TabIndex = 3;
      lblOrderBy.Text = "Order by";
      // 
      // cbxOrderBy
      // 
      cbxOrderBy.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      cbxOrderBy.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxOrderBy.FormattingEnabled = true;
      cbxOrderBy.Location = new Point(425, 20);
      cbxOrderBy.Name = "cbxOrderBy";
      cbxOrderBy.Size = new System.Drawing.Size(74, 23);
      cbxOrderBy.TabIndex = 2;
      // 
      // MonsterGroupsForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new System.Drawing.Size(599, 318);
      Controls.Add(grbxMonsters);
      FormBorderStyle = FormBorderStyle.None;
      Name = "MonsterGroupsForm";
      Text = "MonsterGroupsForm";
      ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
      grbxMonsters.ResumeLayout(false);
      grbxMonsters.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private CustomDataGridView dgv;
    private Button btnAdd;
    private GroupBox grbxMonsters;
    private ComboBox cbxOrderBy;
    private Label lblOrderBy;
    private CheckBox chbxDescending;
  }
}