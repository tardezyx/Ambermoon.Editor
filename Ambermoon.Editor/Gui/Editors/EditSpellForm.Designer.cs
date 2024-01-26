using Ambermoon.Editor.Gui.Custom;

namespace Ambermoon.Editor.Gui.Editors {
  partial class EditSpellForm {
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
      statusStrip = new StatusStrip();
      lblSchool = new Label();
      cbxSchool = new ComboBox();
      lblName = new Label();
      cbxName = new ComboBox();
      SuspendLayout();
      // 
      // btnOK
      // 
      btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnOK.Location = new Point(38, 76);
      btnOK.Name = "btnOK";
      btnOK.Size = new System.Drawing.Size(75, 23);
      btnOK.TabIndex = 1;
      btnOK.Text = "OK";
      btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnCancel.Location = new Point(119, 76);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 2;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // statusStrip
      // 
      statusStrip.BackColor = Color.Transparent;
      statusStrip.Location = new Point(0, 89);
      statusStrip.Name = "statusStrip";
      statusStrip.Size = new System.Drawing.Size(206, 22);
      statusStrip.TabIndex = 6;
      statusStrip.Text = "statusStrip1";
      // 
      // lblSchool
      // 
      lblSchool.AutoSize = true;
      lblSchool.Font = new Font("Segoe UI", 9F);
      lblSchool.Location = new Point(12, 15);
      lblSchool.Name = "lblSchool";
      lblSchool.Size = new System.Drawing.Size(43, 15);
      lblSchool.TabIndex = 20;
      lblSchool.Text = "School";
      // 
      // cbxSchool
      // 
      cbxSchool.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxSchool.Font = new Font("Segoe UI", 9F);
      cbxSchool.FormattingEnabled = true;
      cbxSchool.Location = new Point(61, 12);
      cbxSchool.Name = "cbxSchool";
      cbxSchool.Size = new System.Drawing.Size(133, 23);
      cbxSchool.TabIndex = 2;
      // 
      // lblName
      // 
      lblName.AutoSize = true;
      lblName.Font = new Font("Segoe UI", 9F);
      lblName.Location = new Point(12, 44);
      lblName.Name = "lblName";
      lblName.Size = new System.Drawing.Size(39, 15);
      lblName.TabIndex = 22;
      lblName.Text = "Name";
      // 
      // cbxName
      // 
      cbxName.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxName.Font = new Font("Segoe UI", 9F);
      cbxName.FormattingEnabled = true;
      cbxName.Location = new Point(61, 41);
      cbxName.Name = "cbxName";
      cbxName.Size = new System.Drawing.Size(133, 23);
      cbxName.TabIndex = 21;
      // 
      // EditSpellForm
      // 
      AcceptButton = btnOK;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = btnCancel;
      ClientSize = new System.Drawing.Size(206, 111);
      Controls.Add(lblName);
      Controls.Add(cbxName);
      Controls.Add(lblSchool);
      Controls.Add(cbxSchool);
      Controls.Add(btnCancel);
      Controls.Add(btnOK);
      Controls.Add(statusStrip);
      DoubleBuffered = true;
      MinimumSize = new System.Drawing.Size(222, 150);
      Name = "EditSpellForm";
      ShowIcon = false;
      Text = "Spell";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Button btnOK;
    private Button btnCancel;
    private StatusStrip statusStrip;
    private ComboBox cbxSchool;
    private Label lblSchool;
    private Label lblName;
    private ComboBox cbxName;
  }
}