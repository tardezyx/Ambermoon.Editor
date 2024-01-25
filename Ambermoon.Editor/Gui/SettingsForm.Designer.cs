namespace Ambermoon.Editor.Gui {
  partial class SettingsForm {
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
      chbxAutoLoadGameData = new CheckBox();
      tbxGameDataFolder = new TextBox();
      lblGameDataFolder = new Label();
      btnGameDataFolder = new Button();
      statusStrip1 = new StatusStrip();
      SuspendLayout();
      // 
      // btnOK
      // 
      btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnOK.Location = new Point(166, 66);
      btnOK.Name = "btnOK";
      btnOK.Size = new System.Drawing.Size(75, 23);
      btnOK.TabIndex = 0;
      btnOK.Text = "OK";
      btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnCancel.Location = new Point(247, 66);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 1;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // chbxAutoLoadGameData
      // 
      chbxAutoLoadGameData.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      chbxAutoLoadGameData.AutoSize = true;
      chbxAutoLoadGameData.Location = new Point(165, 14);
      chbxAutoLoadGameData.Name = "chbxAutoLoadGameData";
      chbxAutoLoadGameData.Size = new System.Drawing.Size(157, 19);
      chbxAutoLoadGameData.TabIndex = 2;
      chbxAutoLoadGameData.Text = "Load Game Data on Start";
      chbxAutoLoadGameData.UseVisualStyleBackColor = true;
      // 
      // tbxGameDataFolder
      // 
      tbxGameDataFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      tbxGameDataFolder.Location = new Point(12, 33);
      tbxGameDataFolder.Name = "tbxGameDataFolder";
      tbxGameDataFolder.Size = new System.Drawing.Size(270, 23);
      tbxGameDataFolder.TabIndex = 3;
      // 
      // lblGameDataFolder
      // 
      lblGameDataFolder.AutoSize = true;
      lblGameDataFolder.Location = new Point(12, 15);
      lblGameDataFolder.Name = "lblGameDataFolder";
      lblGameDataFolder.Size = new System.Drawing.Size(142, 15);
      lblGameDataFolder.TabIndex = 4;
      lblGameDataFolder.Text = "Default Game Data Folder";
      // 
      // btnGameDataFolder
      // 
      btnGameDataFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btnGameDataFolder.Location = new Point(288, 33);
      btnGameDataFolder.Name = "btnGameDataFolder";
      btnGameDataFolder.Size = new System.Drawing.Size(34, 23);
      btnGameDataFolder.TabIndex = 5;
      btnGameDataFolder.Text = "...";
      btnGameDataFolder.UseVisualStyleBackColor = true;
      // 
      // statusStrip1
      // 
      statusStrip1.BackColor = Color.Transparent;
      statusStrip1.Location = new Point(0, 79);
      statusStrip1.Name = "statusStrip1";
      statusStrip1.Size = new System.Drawing.Size(334, 22);
      statusStrip1.TabIndex = 6;
      statusStrip1.Text = "statusStrip1";
      // 
      // SettingsForm
      // 
      AcceptButton = btnOK;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = btnCancel;
      ClientSize = new System.Drawing.Size(334, 101);
      Controls.Add(btnCancel);
      Controls.Add(btnOK);
      Controls.Add(statusStrip1);
      Controls.Add(btnGameDataFolder);
      Controls.Add(lblGameDataFolder);
      Controls.Add(tbxGameDataFolder);
      Controls.Add(chbxAutoLoadGameData);
      DoubleBuffered = true;
      MinimumSize = new System.Drawing.Size(350, 140);
      Name = "SettingsForm";
      Text = "Settings";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Button btnOK;
    private Button btnCancel;
    private CheckBox chbxAutoLoadGameData;
    private TextBox tbxGameDataFolder;
    private Label lblGameDataFolder;
    private Button btnGameDataFolder;
    private StatusStrip statusStrip1;
  }
}