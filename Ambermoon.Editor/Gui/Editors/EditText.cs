using Ambermoon.Data.GameDataRepository;
using Ambermoon.Data.GameDataRepository.Collections;
using Ambermoon.Editor.Gui.Custom;
using System.Text.RegularExpressions;
using static Ambermoon.Editor.Extensions.User32;

namespace Ambermoon.Editor.Gui.Editors {
  public partial class EditText : CustomForm {
    #region --- fields ----------------------------------------------------------------------------
    private readonly int                      _index;
    private readonly int                      _subindex;
    private          string                   _text = string.Empty;
    private readonly DictionaryList<TextList> _texts;

    [GeneratedRegex(@"\s+")] private static partial Regex RegexWhitespace();
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public EditText(DictionaryList<TextList> texts, int index, int subindex) {
      InitializeComponent();

      _index    = index;
      _subindex = subindex;
      _texts    = texts;
    }
    #endregion
    #region --- on load ---------------------------------------------------------------------------
    protected override void OnLoad(EventArgs e) {
      base.OnLoad(e);

      CenterToParent();
      WireEvents();
      SetControls();

      MapItemTextToControls();
    }
    #endregion
    #region --- set controls ----------------------------------------------------------------------
    private void SetControls() {
      pbxTextBorder.Image = new Bitmap(Properties.Resources.background_text);
      rtbxTextInGame.FormatOutput(true);
    }
    #endregion
    #region --- wire events -----------------------------------------------------------------------
    private void WireEvents() {
      btnCancel.Click += (s, e) => Close();

      btnOK.Click += (s, e) => {
        MapControlsToItemText();
        DialogResult = DialogResult.OK;
        Close();
      };

      chbxFormat.CheckStateChanged += (s, e) => rtbxTextInGame.FormatOutput(chbxFormat.Checked);

      rtbxTextCode.KeyPress += (s, e) => {
        if (e.KeyChar is
          >= (char)97 and <= (char)122 // a-z
          or (char)228                 // ä
          or (char)246                 // ö
          or (char)252                 // ü
        ) {
          e.KeyChar = (char)((int)e.KeyChar - 32); // to upper
        }

        if (e.KeyChar is
             (>= (char)32 and <= (char)47) // space ! " # $ % & ' ( ) * + , - . /
          or (>= (char)48 and <= (char)57) // 0-9
          or (>= (char)58 and <= (char)63) // : ; < = > ?
          or (>= (char)65 and <= (char)90) // A-Z
          or (char)94                      // ^
          or (char)95                      // _
          or (char)126                     // ~
          or (char)196                     // Ä
          or (char)214                     // Ö
          or (char)220                     // Ü
          or (char)223                     // ß
        ) {
          return;
        }

        e.Handled = true;
      };

      rtbxTextCode.TextChanged += (s, e) => {
        int verticalScrollbarPosition = GetScrollPos(
          rtbxTextInGame.Handle,
          (int)ScrollBarType.Vertical
        );

        rtbxTextInGame.Text = rtbxTextCode.Text;

        _ = SendMessage(
          rtbxTextInGame.Handle,
          (int)WindowMessages.VerticalScroll,
          true,
          verticalScrollbarPosition
        );
      };
    }
    #endregion

    #region --- map controls to item text ---------------------------------------------------------
    private void MapControlsToItemText() {
      _text = RegexWhitespace()
        .Replace(rtbxTextCode.Text, " ");

      if (_texts.TryGetValue((uint)_index, out TextList? textList)) {
        textList[_subindex] = _text;
      }
    }
    #endregion
    #region --- map item text to controls ---------------------------------------------------------
    private void MapItemTextToControls() {
      if (_texts.TryGetValue((uint)_index, out TextList? textList) && _subindex < textList.Count) {
        _text = textList[_subindex];
      }

      rtbxTextCode.Text   = _text;
      rtbxTextInGame.Text = _text;
      tbxIndex.Text       = _index.ToString();
      tbxSubindex.Text    = _subindex.ToString();
    }
    #endregion
  }
}