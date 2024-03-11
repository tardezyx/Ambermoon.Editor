using Ambermoon.Editor.Gui.Custom;

namespace Ambermoon.Editor.Gui.Editors {
  partial class EditText {
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
      statusStrip = new StatusStrip();
      rtbxTextCode = new RichTextBox();
      lblSubindex = new Label();
      tbxSubindex = new TextBox();
      grbxCode = new GroupBox();
      grbxInGame = new GroupBox();
      chbxFormat = new CheckBox();
      rtbxTextInGame = new CustomRichTextBox();
      pbxTextBorder = new ExtendedPictureBox();
      grbxCommands = new GroupBox();
      textBox11 = new TextBox();
      label11 = new Label();
      textBox10 = new TextBox();
      label10 = new Label();
      textBox9 = new TextBox();
      label9 = new Label();
      textBox8 = new TextBox();
      label8 = new Label();
      textBox7 = new TextBox();
      label7 = new Label();
      textBox6 = new TextBox();
      label6 = new Label();
      textBox5 = new TextBox();
      label5 = new Label();
      textBox3 = new TextBox();
      label3 = new Label();
      textBox4 = new TextBox();
      label4 = new Label();
      textBox2 = new TextBox();
      label2 = new Label();
      textBox1 = new TextBox();
      label1 = new Label();
      grbxCode.SuspendLayout();
      grbxInGame.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)pbxTextBorder).BeginInit();
      grbxCommands.SuspendLayout();
      SuspendLayout();
      // 
      // btnOK
      // 
      btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnOK.Location = new Point(1232, 363);
      btnOK.Name = "btnOK";
      btnOK.Size = new System.Drawing.Size(75, 23);
      btnOK.TabIndex = 1;
      btnOK.Text = "OK";
      btnOK.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnCancel.Location = new Point(1313, 363);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new System.Drawing.Size(75, 23);
      btnCancel.TabIndex = 2;
      btnCancel.Text = "Cancel";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // tbxIndex
      // 
      tbxIndex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      tbxIndex.Enabled = false;
      tbxIndex.Location = new Point(57, 364);
      tbxIndex.Name = "tbxIndex";
      tbxIndex.ReadOnly = true;
      tbxIndex.Size = new System.Drawing.Size(45, 23);
      tbxIndex.TabIndex = 3;
      // 
      // lblIndex
      // 
      lblIndex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lblIndex.AutoSize = true;
      lblIndex.Location = new Point(12, 367);
      lblIndex.Name = "lblIndex";
      lblIndex.Size = new System.Drawing.Size(36, 15);
      lblIndex.TabIndex = 4;
      lblIndex.Text = "Index";
      // 
      // statusStrip
      // 
      statusStrip.BackColor = Color.Transparent;
      statusStrip.Location = new Point(0, 376);
      statusStrip.Name = "statusStrip";
      statusStrip.Size = new System.Drawing.Size(1400, 22);
      statusStrip.TabIndex = 6;
      statusStrip.Text = "statusStrip1";
      // 
      // rtbxTextCode
      // 
      rtbxTextCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      rtbxTextCode.BorderStyle = BorderStyle.FixedSingle;
      rtbxTextCode.Font = new Font("Segoe UI", 9F);
      rtbxTextCode.Location = new Point(6, 22);
      rtbxTextCode.Name = "rtbxTextCode";
      rtbxTextCode.Size = new System.Drawing.Size(483, 317);
      rtbxTextCode.TabIndex = 76;
      rtbxTextCode.Text = "";
      // 
      // lblSubindex
      // 
      lblSubindex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      lblSubindex.AutoSize = true;
      lblSubindex.Location = new Point(108, 367);
      lblSubindex.Name = "lblSubindex";
      lblSubindex.Size = new System.Drawing.Size(56, 15);
      lblSubindex.TabIndex = 78;
      lblSubindex.Text = "Subindex";
      // 
      // tbxSubindex
      // 
      tbxSubindex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      tbxSubindex.Enabled = false;
      tbxSubindex.Location = new Point(170, 364);
      tbxSubindex.Name = "tbxSubindex";
      tbxSubindex.ReadOnly = true;
      tbxSubindex.Size = new System.Drawing.Size(45, 23);
      tbxSubindex.TabIndex = 77;
      // 
      // grbxCode
      // 
      grbxCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      grbxCode.Controls.Add(rtbxTextCode);
      grbxCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxCode.Location = new Point(392, 12);
      grbxCode.Name = "grbxCode";
      grbxCode.Size = new System.Drawing.Size(495, 345);
      grbxCode.TabIndex = 79;
      grbxCode.TabStop = false;
      grbxCode.Text = "Code";
      // 
      // grbxInGame
      // 
      grbxInGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      grbxInGame.Controls.Add(chbxFormat);
      grbxInGame.Controls.Add(rtbxTextInGame);
      grbxInGame.Controls.Add(pbxTextBorder);
      grbxInGame.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxInGame.Location = new Point(893, 12);
      grbxInGame.Name = "grbxInGame";
      grbxInGame.Size = new System.Drawing.Size(495, 345);
      grbxInGame.TabIndex = 80;
      grbxInGame.TabStop = false;
      grbxInGame.Text = "In Game";
      // 
      // chbxFormat
      // 
      chbxFormat.AutoSize = true;
      chbxFormat.Checked = true;
      chbxFormat.CheckState = CheckState.Checked;
      chbxFormat.Font = new Font("Segoe UI", 9F);
      chbxFormat.Location = new Point(6, 22);
      chbxFormat.Name = "chbxFormat";
      chbxFormat.Size = new System.Drawing.Size(105, 19);
      chbxFormat.TabIndex = 79;
      chbxFormat.Text = "Format Output";
      chbxFormat.UseVisualStyleBackColor = true;
      // 
      // rtbxTextInGame
      // 
      rtbxTextInGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      rtbxTextInGame.BorderStyle = BorderStyle.None;
      rtbxTextInGame.Font = new Font("Segoe UI", 9F);
      rtbxTextInGame.Location = new Point(29, 73);
      rtbxTextInGame.Name = "rtbxTextInGame";
      rtbxTextInGame.ReadOnly = true;
      rtbxTextInGame.Size = new System.Drawing.Size(438, 238);
      rtbxTextInGame.TabIndex = 78;
      rtbxTextInGame.Text = "";
      // 
      // pbxTextBorder
      // 
      pbxTextBorder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      pbxTextBorder.BackColor = Color.Transparent;
      pbxTextBorder.BackgroundImageLayout = ImageLayout.Zoom;
      pbxTextBorder.Location = new Point(6, 47);
      pbxTextBorder.Name = "pbxTextBorder";
      pbxTextBorder.Size = new System.Drawing.Size(483, 292);
      pbxTextBorder.SizeMode = PictureBoxSizeMode.StretchImage;
      pbxTextBorder.TabIndex = 77;
      pbxTextBorder.TabStop = false;
      // 
      // grbxCommands
      // 
      grbxCommands.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      grbxCommands.Controls.Add(textBox11);
      grbxCommands.Controls.Add(label11);
      grbxCommands.Controls.Add(textBox10);
      grbxCommands.Controls.Add(label10);
      grbxCommands.Controls.Add(textBox9);
      grbxCommands.Controls.Add(label9);
      grbxCommands.Controls.Add(textBox8);
      grbxCommands.Controls.Add(label8);
      grbxCommands.Controls.Add(textBox7);
      grbxCommands.Controls.Add(label7);
      grbxCommands.Controls.Add(textBox6);
      grbxCommands.Controls.Add(label6);
      grbxCommands.Controls.Add(textBox5);
      grbxCommands.Controls.Add(label5);
      grbxCommands.Controls.Add(textBox3);
      grbxCommands.Controls.Add(label3);
      grbxCommands.Controls.Add(textBox4);
      grbxCommands.Controls.Add(label4);
      grbxCommands.Controls.Add(textBox2);
      grbxCommands.Controls.Add(label2);
      grbxCommands.Controls.Add(textBox1);
      grbxCommands.Controls.Add(label1);
      grbxCommands.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      grbxCommands.Location = new Point(12, 12);
      grbxCommands.Name = "grbxCommands";
      grbxCommands.Size = new System.Drawing.Size(374, 345);
      grbxCommands.TabIndex = 81;
      grbxCommands.TabStop = false;
      grbxCommands.Text = "Commands";
      // 
      // textBox11
      // 
      textBox11.BackColor = Color.LightSteelBlue;
      textBox11.Font = new Font("Segoe UI", 9F);
      textBox11.Location = new Point(6, 312);
      textBox11.Name = "textBox11";
      textBox11.ReadOnly = true;
      textBox11.Size = new System.Drawing.Size(168, 23);
      textBox11.TabIndex = 98;
      textBox11.Text = "~SUBJ~";
      // 
      // label11
      // 
      label11.AutoSize = true;
      label11.Font = new Font("Segoe UI", 9F);
      label11.Location = new Point(180, 315);
      label11.Name = "label11";
      label11.Size = new System.Drawing.Size(176, 15);
      label11.TabIndex = 97;
      label11.Text = "casters name, targets name, etc.";
      // 
      // textBox10
      // 
      textBox10.BackColor = Color.LightSteelBlue;
      textBox10.Font = new Font("Segoe UI", 9F);
      textBox10.Location = new Point(6, 283);
      textBox10.Name = "textBox10";
      textBox10.ReadOnly = true;
      textBox10.Size = new System.Drawing.Size(168, 23);
      textBox10.TabIndex = 96;
      textBox10.Text = "~SEX2~";
      // 
      // label10
      // 
      label10.AutoSize = true;
      label10.Font = new Font("Segoe UI", 9F);
      label10.Location = new Point(180, 286);
      label10.Name = "label10";
      label10.Size = new System.Drawing.Size(184, 15);
      label10.TabIndex = 95;
      label10.Text = "gender specific pronouns: his/her";
      // 
      // textBox9
      // 
      textBox9.BackColor = Color.LightSteelBlue;
      textBox9.Font = new Font("Segoe UI", 9F);
      textBox9.Location = new Point(6, 254);
      textBox9.Name = "textBox9";
      textBox9.ReadOnly = true;
      textBox9.Size = new System.Drawing.Size(168, 23);
      textBox9.TabIndex = 94;
      textBox9.Text = "~SEX1~";
      // 
      // label9
      // 
      label9.AutoSize = true;
      label9.Font = new Font("Segoe UI", 9F);
      label9.Location = new Point(180, 257);
      label9.Name = "label9";
      label9.Size = new System.Drawing.Size(183, 15);
      label9.TabIndex = 93;
      label9.Text = "gender specific pronouns: he/she";
      // 
      // textBox8
      // 
      textBox8.BackColor = Color.LightSteelBlue;
      textBox8.Font = new Font("Segoe UI", 9F);
      textBox8.Location = new Point(6, 167);
      textBox8.Name = "textBox8";
      textBox8.ReadOnly = true;
      textBox8.Size = new System.Drawing.Size(168, 23);
      textBox8.TabIndex = 92;
      textBox8.Text = "~INVN~";
      // 
      // label8
      // 
      label8.AutoSize = true;
      label8.Font = new Font("Segoe UI", 9F);
      label8.Location = new Point(180, 169);
      label8.Name = "label8";
      label8.Size = new System.Drawing.Size(184, 15);
      label8.TabIndex = 91;
      label8.Text = "current inventory members name";
      // 
      // textBox7
      // 
      textBox7.BackColor = Color.LightSteelBlue;
      textBox7.Font = new Font("Segoe UI", 9F);
      textBox7.Location = new Point(6, 196);
      textBox7.Name = "textBox7";
      textBox7.ReadOnly = true;
      textBox7.Size = new System.Drawing.Size(168, 23);
      textBox7.TabIndex = 90;
      textBox7.Text = "~LEAD~";
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Font = new Font("Segoe UI", 9F);
      label7.Location = new Point(180, 198);
      label7.Name = "label7";
      label7.Size = new System.Drawing.Size(118, 15);
      label7.TabIndex = 89;
      label7.Text = "current leaders name";
      // 
      // textBox6
      // 
      textBox6.BackColor = Color.LightSteelBlue;
      textBox6.Font = new Font("Segoe UI", 9F);
      textBox6.Location = new Point(6, 225);
      textBox6.Name = "textBox6";
      textBox6.ReadOnly = true;
      textBox6.Size = new System.Drawing.Size(168, 23);
      textBox6.TabIndex = 88;
      textBox6.Text = "~SELF~";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Font = new Font("Segoe UI", 9F);
      label6.Location = new Point(180, 228);
      label6.Name = "label6";
      label6.Size = new System.Drawing.Size(75, 15);
      label6.TabIndex = 87;
      label6.Text = "heroes name";
      // 
      // textBox5
      // 
      textBox5.BackColor = Color.LightSteelBlue;
      textBox5.Font = new Font("Segoe UI", 9F);
      textBox5.Location = new Point(6, 138);
      textBox5.Name = "textBox5";
      textBox5.ReadOnly = true;
      textBox5.Size = new System.Drawing.Size(168, 23);
      textBox5.TabIndex = 86;
      textBox5.Text = "~CAST~";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Font = new Font("Segoe UI", 9F);
      label5.Location = new Point(180, 140);
      label5.Name = "label5";
      label5.Size = new System.Drawing.Size(117, 15);
      label5.TabIndex = 85;
      label5.Text = "current casters name";
      // 
      // textBox3
      // 
      textBox3.BackColor = Color.LightSteelBlue;
      textBox3.Font = new Font("Segoe UI", 9F);
      textBox3.Location = new Point(6, 109);
      textBox3.Name = "textBox3";
      textBox3.ReadOnly = true;
      textBox3.Size = new System.Drawing.Size(168, 23);
      textBox3.TabIndex = 84;
      textBox3.Text = "~RUN1~ some text ~NORM~";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new Font("Segoe UI", 9F);
      label3.Location = new Point(180, 111);
      label3.Name = "label3";
      label3.Size = new System.Drawing.Size(188, 15);
      label3.TabIndex = 83;
      label3.Text = "some text is displayed in rune font";
      // 
      // textBox4
      // 
      textBox4.BackColor = Color.LightSteelBlue;
      textBox4.Font = new Font("Segoe UI", 9F);
      textBox4.Location = new Point(6, 80);
      textBox4.Name = "textBox4";
      textBox4.ReadOnly = true;
      textBox4.Size = new System.Drawing.Size(168, 23);
      textBox4.TabIndex = 82;
      textBox4.Text = "~INK color~ some text";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Font = new Font("Segoe UI", 9F);
      label4.Location = new Point(180, 82);
      label4.Name = "label4";
      label4.Size = new System.Drawing.Size(160, 15);
      label4.TabIndex = 81;
      label4.Text = "sets color (0-31) of some text";
      // 
      // textBox2
      // 
      textBox2.BackColor = Color.LightSteelBlue;
      textBox2.Font = new Font("Segoe UI", 9F);
      textBox2.Location = new Point(6, 51);
      textBox2.Name = "textBox2";
      textBox2.ReadOnly = true;
      textBox2.Size = new System.Drawing.Size(168, 23);
      textBox2.TabIndex = 80;
      textBox2.Text = "^";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 9F);
      label2.Location = new Point(180, 53);
      label2.Name = "label2";
      label2.Size = new System.Drawing.Size(58, 15);
      label2.TabIndex = 79;
      label2.Text = "line break";
      // 
      // textBox1
      // 
      textBox1.BackColor = Color.LightSteelBlue;
      textBox1.Font = new Font("Segoe UI", 9F);
      textBox1.Location = new Point(6, 22);
      textBox1.Name = "textBox1";
      textBox1.ReadOnly = true;
      textBox1.Size = new System.Drawing.Size(168, 23);
      textBox1.TabIndex = 78;
      textBox1.Text = "$";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 9F);
      label1.Location = new Point(180, 24);
      label1.Name = "label1";
      label1.Size = new System.Drawing.Size(135, 15);
      label1.TabIndex = 5;
      label1.Text = "space without line break";
      // 
      // EditText
      // 
      AcceptButton = btnOK;
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = btnCancel;
      ClientSize = new System.Drawing.Size(1400, 398);
      Controls.Add(grbxCommands);
      Controls.Add(grbxInGame);
      Controls.Add(grbxCode);
      Controls.Add(lblSubindex);
      Controls.Add(tbxSubindex);
      Controls.Add(lblIndex);
      Controls.Add(tbxIndex);
      Controls.Add(btnCancel);
      Controls.Add(btnOK);
      Controls.Add(statusStrip);
      DoubleBuffered = true;
      Location = new Point(0, 0);
      MinimumSize = new System.Drawing.Size(1416, 437);
      Name = "EditText";
      ShowIcon = false;
      Text = "Text";
      grbxCode.ResumeLayout(false);
      grbxInGame.ResumeLayout(false);
      grbxInGame.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)pbxTextBorder).EndInit();
      grbxCommands.ResumeLayout(false);
      grbxCommands.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private Button btnOK;
    private Button btnCancel;
    private TextBox tbxIndex;
    private Label lblIndex;
    private StatusStrip statusStrip;
    private RichTextBox rtbxTextCode;
    private Label lblSubindex;
    private TextBox tbxSubindex;
    private GroupBox grbxCode;
    private GroupBox grbxInGame;
    private CustomRichTextBox rtbxTextInGame;
    private ExtendedPictureBox pbxTextBorder;
    private GroupBox grbxCommands;
    private Label label1;
    private TextBox textBox2;
    private Label label2;
    private TextBox textBox1;
    private TextBox textBox3;
    private Label label3;
    private TextBox textBox4;
    private Label label4;
    private TextBox textBox8;
    private Label label8;
    private TextBox textBox7;
    private Label label7;
    private TextBox textBox6;
    private Label label6;
    private TextBox textBox5;
    private Label label5;
    private TextBox textBox9;
    private Label label9;
    private TextBox textBox11;
    private Label label11;
    private TextBox textBox10;
    private Label label10;
    private CheckBox chbxFormat;
  }
}