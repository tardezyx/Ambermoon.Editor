using Ambermoon.Editor.Gui.Custom;

namespace Ambermoon.Editor.Gui.Editors {
  partial class EditMonsterGroupForm {
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
      btnOK = new Button();
      btnCancel = new Button();
      tbxIndex = new TextBox();
      lblIndex = new Label();
      dgv = new CustomDataGridView();
      statusStrip1 = new StatusStrip();
      ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
      SuspendLayout();
      // 
      // btnOK
      // 
      btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnOK.Location = new Point(981, 126);
      btnOK.Name = "btnOK";
      btnOK.Size = new System.Drawing.Size(75, 23);
      btnOK.TabIndex = 1;
      btnOK.Text = "OK";
      btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnCancel.Location = new Point(1062, 126);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 2;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // tbxIndex
      // 
      tbxIndex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      tbxIndex.Location = new Point(57, 127);
      tbxIndex.Name = "tbxIndex";
      tbxIndex.ReadOnly = true;
      tbxIndex.Size = new System.Drawing.Size(45, 23);
      tbxIndex.TabIndex = 3;
      // 
      // lblIndex
      // 
      lblIndex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lblIndex.AutoSize = true;
      lblIndex.Location = new Point(12, 130);
      lblIndex.Name = "lblIndex";
      lblIndex.Size = new System.Drawing.Size(36, 15);
      lblIndex.TabIndex = 4;
      lblIndex.Text = "Index";
      // 
      // dgv
      // 
      dgv.AllowUserToAddRows = false;
      dgv.AllowUserToDeleteRows = false;
      dgv.AllowUserToResizeRows = false;
      dgv.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgv.Location = new Point(12, 12);
      dgv.MultiSelect = false;
      dgv.Name = "dgv";
      dgv.RowHeadersVisible = false;
      dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
      dgv.Size = new System.Drawing.Size(1125, 104);
      dgv.TabIndex = 7;
      // 
      // statusStrip1
      // 
      statusStrip1.BackColor = Color.Transparent;
      statusStrip1.Location = new Point(0, 139);
      statusStrip1.Name = "statusStrip1";
      statusStrip1.Size = new System.Drawing.Size(1149, 22);
      statusStrip1.TabIndex = 8;
      statusStrip1.Text = "statusStrip1";
      // 
      // EditMonsterGroupForm
      // 
      AcceptButton = btnOK;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = btnCancel;
      ClientSize = new System.Drawing.Size(1149, 161);
      Controls.Add(lblIndex);
      Controls.Add(tbxIndex);
      Controls.Add(dgv);
      Controls.Add(btnCancel);
      Controls.Add(btnOK);
      Controls.Add(statusStrip1);
      DoubleBuffered = true;
      MinimumSize = new System.Drawing.Size(300, 150);
      Name = "EditMonsterGroupForm";
      ShowIcon = false;
      Text = "MonsterGroup";
      ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Button btnOK;
    private Button btnCancel;
    private TextBox tbxIndex;
    private Label lblIndex;
    private CustomDataGridView dgv;
    private StatusStrip statusStrip1;
  }
}