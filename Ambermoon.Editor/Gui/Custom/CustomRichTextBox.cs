using Ambermoon.Data.GameDataRepository.Windows;
using Ambermoon.Editor.Base;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Models;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static Ambermoon.Editor.Extensions.User32;
using Color = System.Drawing.Color;

namespace Ambermoon.Editor.Gui.Custom {
  internal partial class CustomRichTextBox : RichTextBox {
    #region --- local class: text color -----------------------------------------------------------
    private class TextColor() { 
      public Color Color;
      public int   Index;
    }
    #endregion
    #region --- local class: text font ------------------------------------------------------------
    private class TextFont() { 
      public Font Font = Settings.GetFont(6);
      public int  Index;
    }
    #endregion
    #region --- field -----------------------------------------------------------------------------
    private bool   _doFormatting       = true;
    private bool   _idleWithFormatting = false;
    private string _originalText       = string.Empty;
    
    [GeneratedRegex(@"~INK \d\d~\s")] private static partial Regex RegexInkDouble();
    [GeneratedRegex(@"~INK \d~\s")]   private static partial Regex RegexInkSingle();
    [GeneratedRegex(@"\s+")]          private static partial Regex RegexWhitespace();
    #endregion

    #region --- constructor -----------------------------------------------------------------------
    public CustomRichTextBox() : base() {
      if (!Settings.IsNotInDesignMode) {
        return;
      }

      BackColor = Color.FromArgb(255, 102, 102, 85);
      ForeColor = Color.FromArgb(255, 204, 204, 187);
    }
    #endregion
    #region --- format output ---------------------------------------------------------------------
    public void FormatOutput(bool? formatting = null) {
      if (formatting is not null) {
        _doFormatting = (bool)formatting;
      }

      _idleWithFormatting = true;

      /*
       * $ ist ein Leerzeichen ohne Umbruch.
       * ^ ist ein Zeilenumbruch.
       * ~INK 0~ bis ~INK 31~ setzt die Schriftfarbe auf Palettenfarbe X (Color Index). Von der UI Palette.
       * ~RUN1~ startet Runen
       * ~NORM~ beendet Runen
       * 
       * ~CAST~ ist der aktuelle Caster
       * ~INVN~ ist der Spieler des aktiv geöffneten Inventars. Nützlich wenn man Items benutzt.
       * ~LEAD~ ist der aktive Spieler
       * ~SELF~ der Heldenname (z.B. Thalion)
       * ~SEX1~ ist ER oder SIE je nach Geschlecht
       * ~SEX2~ ist SEINE oder IHRE je nach Geschlecht
       * ~SUBJ~ ist unterschiedlich. Spellcaster, Spelltarget, aktiver Spieler, etc
      */

      #region --- unformatted ---------------------------------------------------------------------
      if (!_doFormatting) {
        Text = _originalText;

        if (Text.IsNullOrEmpty()) {
          return;
        }

        Color highlightColor = Color.FromArgb(255, 255, 0, 0);
        List<TextColor> commmandColors = [];

        List<int> commands = [];
        commands.AddRange(Text.GetAllIndexesOf("^"));
        commands.AddRange(Text.GetAllIndexesOf("$"));

        foreach (int index in commands) {
          commmandColors.Add(
            new() {
              Color = highlightColor,
              Index = index
            }
          );

          commmandColors.Add(
            new() {
              Color = Color.FromArgb(255, 204, 204, 187),
              Index = index + 1
            }
          );
        }

        commands.Clear();
        commands.AddRange(Text.GetAllIndexesOf("~CAST~ "));
        commands.AddRange(Text.GetAllIndexesOf("~INVN~ "));
        commands.AddRange(Text.GetAllIndexesOf("~LEAD~ "));
        commands.AddRange(Text.GetAllIndexesOf("~NORM~ "));
        commands.AddRange(Text.GetAllIndexesOf("~RUN1~ "));
        commands.AddRange(Text.GetAllIndexesOf("~SELF~ "));
        commands.AddRange(Text.GetAllIndexesOf("~SEX1~ "));
        commands.AddRange(Text.GetAllIndexesOf("~SEX2~ "));
        commands.AddRange(Text.GetAllIndexesOf("~SUBJ~ "));

        foreach (int index in commands) {
          commmandColors.Add(
            new() {
              Color = highlightColor,
              Index = index
            }
          );

          commmandColors.Add(
            new() {
              Color = Color.FromArgb(255, 204, 204, 187),
              Index = index + 6
            }
          );
        }

        foreach (Match match in RegexInkSingle().Matches(Text).Cast<Match>()) {
          commmandColors.Add(
            new() {
              Color = highlightColor,
              Index = match.Index
            }
          );

          commmandColors.Add(
            new() {
              Color = Color.FromArgb(255, 204, 204, 187),
              Index = match.Index + 7
            }
          );
        }

        foreach (Match match in RegexInkDouble().Matches(Text).Cast<Match>()) {
          commmandColors.Add(
            new() {
              Color = highlightColor,
              Index = match.Index
            }
          );

          commmandColors.Add(
            new() {
              Color = Color.FromArgb(255, 204, 204, 187),
              Index = match.Index + 8
            }
          );
        }

        foreach (TextColor commmandColor in commmandColors.OrderBy(x => x.Index)) {
          SelectionStart  = commmandColor.Index;
          SelectionLength = Text.Length - commmandColor.Index;
          SelectionColor  = commmandColor.Color;
          SelectionLength = 0;
        }

        SelectionStart  = 0;
        SelectionLength = Text.Length;
        SelectionFont   = Settings.GetFont(6);
        SelectionLength = 0;

        _idleWithFormatting = false;
        return;
      }
      #endregion
      #region --- formatted -----------------------------------------------------------------------
      string text = RegexWhitespace()
        .Replace(Text, " ")
        .Replace("^ ", Environment.NewLine)
        .Replace("^", Environment.NewLine)
        .Replace('$', ' ')
        .Replace("~CAST~", "<CASTER>")
        .Replace("~INVN~", "<OWNER>")
        .Replace("~LEAD~", "<LEADER>")
        .Replace("~SELF~", "<HERO>")
        .Replace("~SEX1~", $"<{Repository.Current.GameData!.UITexts[1]}/{Repository.Current.GameData!.UITexts[2]}>")
        .Replace("~SEX2~", $"<{Repository.Current.GameData!.UITexts[3]}/{Repository.Current.GameData!.UITexts[4]}>")
        .Replace("~SUBJ~", "<SUBJECT>");

      List<TextColor> textColors = [];

      while (text.IndexOf("~INK", StringComparison.OrdinalIgnoreCase) is int startPlaceholderIndex && startPlaceholderIndex != -1) {
        int endPlaceholderIndex = startPlaceholderIndex + text[(startPlaceholderIndex + 1)..]
          .IndexOf('~', StringComparison.OrdinalIgnoreCase) + 3;

        string colorIndexAsString = text[startPlaceholderIndex..(endPlaceholderIndex - 2)]
          .GetSubstringAfterString("INK").Trim();

        if (
          int.TryParse(colorIndexAsString, out int colorIndex)
          && colorIndex > -1
          && colorIndex < 32
        ) {
          textColors.Add(
            new() {
              Color = WindowsExtensions.ToColor(Repository.Current.GameData!.UserInterfacePalette, (uint)colorIndex),
              Index = startPlaceholderIndex - Regex.Matches(text[..startPlaceholderIndex], Environment.NewLine).Count,
            }
          );
        }

        text = text[..startPlaceholderIndex] + text[endPlaceholderIndex..];
      }

      List<TextFont> textFonts = [];

      while (text.IndexOf("~RUN1~ ", StringComparison.OrdinalIgnoreCase) is int startPlaceholderIndex && startPlaceholderIndex != -1) {
        int endPlaceholderIndex = startPlaceholderIndex + 6;

        textFonts.Add(
          new() {
            Font = Settings.GetFont(6, true),
            Index = startPlaceholderIndex - Regex.Matches(text[..startPlaceholderIndex], Environment.NewLine).Count,
          }
        );

        foreach (TextColor textColor in textColors.Where(x => x.Index > endPlaceholderIndex)) {
          textColor.Index -= 6;
        }

        text = text[..startPlaceholderIndex] + text[endPlaceholderIndex..];

        startPlaceholderIndex = text.IndexOf("~NORM~", StringComparison.OrdinalIgnoreCase);
        if (startPlaceholderIndex > -1) {
          endPlaceholderIndex   = startPlaceholderIndex + 6;

          textFonts.Add(
            new() {
              Index = startPlaceholderIndex - Regex.Matches(text[..startPlaceholderIndex], Environment.NewLine).Count,
            }
          );

          foreach (TextColor textColor in textColors.Where(x => x.Index > endPlaceholderIndex)) {
            textColor.Index -= 6;
          }

          text = text[..startPlaceholderIndex] + text[endPlaceholderIndex..];
        }
      }

      Text = text;

      foreach (TextColor textColor in textColors) {
        SelectionStart  = textColor.Index;
        SelectionLength = text.Length - textColor.Index;
        SelectionColor  = textColor.Color;
        SelectionLength = 0;
      }

      if (textFonts.Count == 0 || textFonts[0].Index != 0) {
        SelectionStart  = 0;
        SelectionLength = Text.Length;
        SelectionFont   = Settings.GetFont(6);
        SelectionLength = 0;
      }

      foreach (TextFont textFont in textFonts) {
        SelectionStart  = textFont.Index;
        SelectionLength = Text.Length - textFont.Index;
        SelectionFont   = textFont.Font;
        SelectionLength = 0;
      }

      _idleWithFormatting = false;
      #endregion
    }
    #endregion
    #region --- on text changed -------------------------------------------------------------------
    protected override void OnTextChanged(EventArgs e) {
      base.OnTextChanged(e);

      SetLineFormat(1, 3);

      if (_idleWithFormatting) {
        return;
      }

      _originalText = Text;
      FormatOutput();
      SetLineFormat(1, 3);
      DeselectAll();
    }
    #endregion
    #region --- set line format -------------------------------------------------------------------
    private void SetLineFormat(byte rule, int space) {
      PARAFORMAT fmt       = new();
      fmt.cbSize           = Marshal.SizeOf(fmt);
      fmt.dwMask           = PFM_LINESPACING;
      fmt.dyLineSpacing    = space;
      fmt.bLineSpacingRule = rule;

      SelectAll();

      SendMessage(
        new HandleRef(
          this,
          Handle
        ),
        EM_SETPARAFORMAT,
        SCF_SELECTION,
        ref fmt
      );
    }
    #endregion
  }
}