using Ambermoon.Editor.Extensions;

namespace Ambermoon.Editor.Gui.Custom {
  internal class MsgBox {
    #region --- center to parent ------------------------------------------------------------------
    public static void CenterToParent(Form msgBox) {
      Screen screen = Screen.FromControl(msgBox);

      int centerX = msgBox.Owner != null
        ? msgBox.Owner.Location.X + msgBox.Owner.Width / 2
        : screen.WorkingArea.Width / 2;

      int centerY = msgBox.Owner != null
        ? msgBox.Owner.Location.Y + msgBox.Owner.Height / 2
        : screen.WorkingArea.Height / 2;

      int locationX = centerX - msgBox.Width / 2 > 0
        ? centerX - msgBox.Width / 2
        : 0;

      int locationY = centerY - msgBox.Height / 2 > 0
        ? centerY - msgBox.Height / 2
        : 0;

      if (locationX > screen.WorkingArea.Width)  { locationX = screen.WorkingArea.Width  - msgBox.Width; }
      if (locationY > screen.WorkingArea.Height) { locationY = screen.WorkingArea.Height - msgBox.Height; }

      msgBox.Location = new(locationX, locationY);
    }
    #endregion
    #region --- show ------------------------------------------------------------------------------
    public static DialogResult Show(
      string            title,
      string            text,
      MessageBoxButtons type        = MessageBoxButtons.OK,
      string            button1Text = "",
      string            button2Text = "",
      Form?             owner       = null
    ) {
      Form msgBox = new() {
        FormBorderStyle = FormBorderStyle.FixedToolWindow,
        MaximizeBox     = false,
        MinimizeBox     = false,
        Owner           = owner,
        ShowInTaskbar   = false,
        SizeGripStyle   = SizeGripStyle.Hide,
        StartPosition   = FormStartPosition.CenterParent,
        Text            = title
      };

      Label label = new() {
        AutoSize    = true,
        BorderStyle = BorderStyle.None,
        BackColor   = msgBox.BackColor,
        ForeColor   = msgBox.ForeColor,
        //Font = Settings.Current.Theme.GetFont(FontCategory.V1),
        //TextAlign   = ContentAlignment.MiddleCenter;
        Text        = text
      };

      if (button1Text.HasText() && button2Text.HasText()) {
        if (type == MessageBoxButtons.YesNo)       { msgBox = Prepare2CustomButtons(msgBox, label, button1Text, button2Text); }
        if (type == MessageBoxButtons.YesNoCancel) { msgBox = Prepare3CustomButtons(msgBox, label, button1Text, button2Text); }
      } else {
        switch (type) {
          case MessageBoxButtons.AbortRetryIgnore: msgBox = Prepare3Buttons(msgBox, label, DialogResult.Abort, DialogResult.Retry, DialogResult.Ignore); break;
          case MessageBoxButtons.OK:               msgBox = Prepare1Button( msgBox, label, DialogResult.OK);                                             break;
          case MessageBoxButtons.OKCancel:         msgBox = Prepare2Buttons(msgBox, label, DialogResult.OK,    DialogResult.Cancel);                     break;
          case MessageBoxButtons.RetryCancel:      msgBox = Prepare2Buttons(msgBox, label, DialogResult.Retry, DialogResult.Cancel);                     break;
          case MessageBoxButtons.YesNo:            msgBox = Prepare2Buttons(msgBox, label, DialogResult.Yes,   DialogResult.No);                         break;
          case MessageBoxButtons.YesNoCancel:      msgBox = Prepare3Buttons(msgBox, label, DialogResult.Yes,   DialogResult.No,    DialogResult.Cancel); break;
        }
      }

      CenterToParent(msgBox);

      return msgBox.ShowDialog();
    }
    #endregion
    #region --- prepare 1 button ------------------------------------------------------------------
    private static Form Prepare1Button(Form msgBox, Label label, DialogResult dr) {
      Button btn = new() {
        DialogResult = dr,
        Text = dr.ToString()
      };

      // complex sizing and positioning
      msgBox.MinimumSize = new(240, 60);
      label.MaximumSize = new(420, 0);
      System.Drawing.Size size = TextRenderer.MeasureText(label.Text, label.Font, new(label.MaximumSize.Width, 500), TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
      label.Size = new(size.Width, size.Height);
      msgBox.Size = new(label.Width + 40, label.Height + 100);
      label.Location = new Point((msgBox.Width - label.Width) / 2, 12);
      btn.Location = new Point(msgBox.Width / 2 - btn.Width / 2, msgBox.Height - btn.Height - 50);

      msgBox.Controls.Add(label);
      msgBox.Controls.Add(btn);
      return msgBox;
    }
    #endregion
    #region --- prepare 2 buttons -----------------------------------------------------------------
    private static Form Prepare2Buttons(Form msgBox, Label label, DialogResult dr1, DialogResult dr2) {
      Button btn1 = new() {
        DialogResult = dr1,
        Text = dr1.ToString()
      };

      Button btn2 = new() {
        DialogResult = dr2,
        Text = dr2.ToString()
      };

      // complex sizing and positioning
      msgBox.MinimumSize = new(240, 60);
      label.MaximumSize = new(420, 0);
      System.Drawing.Size size = TextRenderer.MeasureText(label.Text, label.Font, new(label.MaximumSize.Width, 500), TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
      label.Size = new(size.Width, size.Height);
      msgBox.Size = new(label.Width + 40, label.Height + 100);
      label.Location = new Point((msgBox.Width - label.Width) / 2, 12);
      btn1.Location = new Point(msgBox.Width / 2 - btn1.Width - 10, msgBox.Height - btn1.Height - 50);
      btn2.Location = new Point(msgBox.Width / 2 + 10, btn1.Location.Y);

      msgBox.Controls.Add(label);
      msgBox.Controls.Add(btn1);
      msgBox.Controls.Add(btn2);
      return msgBox;
    }
    #endregion
    #region --- prepare 2 custom buttons ----------------------------------------------------------
    private static Form Prepare2CustomButtons(Form msgBox, Label label, string btn1Text, string btn2Text) {
      Button btn1 = new() {
        DialogResult = DialogResult.Yes,
        Text = btn1Text
      };

      Button btn2 = new() {
        DialogResult = DialogResult.No,
        Text = btn2Text
      };

      // complex sizing and positioning
      msgBox.MinimumSize = new(240, 60);
      label.MaximumSize = new(420, 0);
      System.Drawing.Size size = TextRenderer.MeasureText(label.Text, label.Font, new(label.MaximumSize.Width, 500), TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
      label.Size = new(size.Width, size.Height);
      msgBox.Size = new(label.Width + 40, label.Height + 100);
      label.Location = new Point((msgBox.Width - label.Width) / 2, 12);
      btn1.Location = new Point(msgBox.Width / 2 - btn1.Width - 10, msgBox.Height - btn1.Height - 50);
      btn2.Location = new Point(msgBox.Width / 2 + 10, btn1.Location.Y);

      msgBox.Controls.Add(label);
      msgBox.Controls.Add(btn1);
      msgBox.Controls.Add(btn2);
      return msgBox;
    }
    #endregion
    #region --- prepare 3 buttons -----------------------------------------------------------------
    private static Form Prepare3Buttons(Form msgBox, Label label, DialogResult dr1, DialogResult dr2, DialogResult dr3) {
      Button btn1 = new() {
        DialogResult = dr1,
        Text = dr1.ToString()
      };

      Button btn2 = new() {
        DialogResult = dr2,
        Text = dr2.ToString()
      };

      Button btn3 = new() {
        DialogResult = dr3,
        Text = dr3.ToString()
      };

      // complex sizing and positioning
      msgBox.MinimumSize = new(320, 60);
      label.MaximumSize = new(420, 0);
      System.Drawing.Size size = TextRenderer.MeasureText(label.Text, label.Font, new(label.MaximumSize.Width, 500), TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
      label.Size = new(size.Width, size.Height);
      msgBox.Size = new(label.Width + 40, label.Height + 100);
      label.Location = new Point((msgBox.Width - label.Width) / 2, 12);
      btn1.Location = new Point(msgBox.Width / 2 - 6 - (btn1.Width + btn2.Width + btn3.Width + 40) / 2, msgBox.Height - btn1.Height - 50);
      btn2.Location = new Point(btn1.Location.X + btn1.Width + 20, btn1.Location.Y);
      btn3.Location = new Point(btn2.Location.X + btn2.Width + 20, btn2.Location.Y);

      msgBox.Controls.Add(label);
      msgBox.Controls.Add(btn1);
      msgBox.Controls.Add(btn2);
      msgBox.Controls.Add(btn3);
      return msgBox;
    }
    #endregion
    #region --- prepare 3 custom buttons ----------------------------------------------------------
    private static Form Prepare3CustomButtons(Form msgBox, Label label, string btn1Text, string btn2Text) {
      Button btn1 = new() {
        DialogResult = DialogResult.Yes,
        Text = btn1Text
      };

      Button btn2 = new() {
        DialogResult = DialogResult.No,
        Text = btn2Text
      };

      Button btn3 = new() {
        DialogResult = DialogResult.Cancel,
        Text = DialogResult.Cancel.ToString()
      };

      // complex sizing and positioning
      msgBox.MinimumSize = new(420, 60);
      label.MaximumSize = new(520, 0);
      System.Drawing.Size size = TextRenderer.MeasureText(label.Text, label.Font, new(label.MaximumSize.Width, 500), TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
      label.Size = new(size.Width, size.Height);
      msgBox.Size = new(label.Width + 40, label.Height + 100);
      label.Location = new Point((msgBox.Width - label.Width) / 2, 12);
      btn1.Location = new Point(msgBox.Width / 2 - 6 - (btn1.Width + btn2.Width + btn3.Width + 40) / 2, msgBox.Height - btn1.Height - 50);
      btn2.Location = new Point(btn1.Location.X + btn1.Width + 20, btn1.Location.Y);
      btn3.Location = new Point(btn2.Location.X + btn2.Width + 20, btn2.Location.Y);

      msgBox.Controls.Add(label);
      msgBox.Controls.Add(btn1);
      msgBox.Controls.Add(btn2);
      msgBox.Controls.Add(btn3);
      return msgBox;
    }
    #endregion
  }
}