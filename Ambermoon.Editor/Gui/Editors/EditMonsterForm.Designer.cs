namespace Ambermoon.Editor.Gui.Editors {
  partial class EditMonsterForm {
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
      tbxName = new TextBox();
      btnOK = new Button();
      btnCancel = new Button();
      tbxIndex = new TextBox();
      lblIndex = new Label();
      lblName = new Label();
      statusStrip = new StatusStrip();
      SuspendLayout();
      // 
      // tbxName
      // 
      tbxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      tbxName.Location = new Point(57, 41);
      tbxName.Name = "tbxName";
      tbxName.Size = new System.Drawing.Size(215, 23);
      tbxName.TabIndex = 0;
      // 
      // btnOK
      // 
      btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnOK.Location = new Point(116, 76);
      btnOK.Name = "btnOK";
      btnOK.Size = new System.Drawing.Size(75, 23);
      btnOK.TabIndex = 1;
      btnOK.Text = "OK";
      btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnCancel.Location = new Point(197, 76);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 2;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // tbxIndex
      // 
      tbxIndex.Location = new Point(57, 12);
      tbxIndex.Name = "tbxIndex";
      tbxIndex.ReadOnly = true;
      tbxIndex.Size = new System.Drawing.Size(45, 23);
      tbxIndex.TabIndex = 3;
      // 
      // lblIndex
      // 
      lblIndex.AutoSize = true;
      lblIndex.Location = new Point(12, 15);
      lblIndex.Name = "lblIndex";
      lblIndex.Size = new System.Drawing.Size(36, 15);
      lblIndex.TabIndex = 4;
      lblIndex.Text = "Index";
      // 
      // lblName
      // 
      lblName.AutoSize = true;
      lblName.Location = new Point(12, 44);
      lblName.Name = "lblName";
      lblName.Size = new System.Drawing.Size(39, 15);
      lblName.TabIndex = 5;
      lblName.Text = "Name";
      // 
      // statusStrip
      // 
      statusStrip.Location = new Point(0, 89);
      statusStrip.Name = "statusStrip";
      statusStrip.Size = new System.Drawing.Size(284, 22);
      statusStrip.TabIndex = 6;
      statusStrip.Text = "statusStrip1";
      // 
      // MonsterForm
      // 
      AcceptButton = btnOK;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = btnCancel;
      ClientSize = new System.Drawing.Size(284, 111);
      Controls.Add(btnCancel);
      Controls.Add(btnOK);
      Controls.Add(statusStrip);
      Controls.Add(lblName);
      Controls.Add(lblIndex);
      Controls.Add(tbxIndex);
      Controls.Add(tbxName);
      MinimumSize = new System.Drawing.Size(300, 150);
      Name = "MonsterForm";
      ShowIcon = false;
      Text = "Monster";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox tbxName;
    private Button btnOK;
    private Button btnCancel;
    private TextBox tbxIndex;
    private Label lblIndex;
    private Label lblName;
    private StatusStrip statusStrip;
  }
}