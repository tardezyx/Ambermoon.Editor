using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using System.Reflection;

namespace Ambermoon.Editor.Base {
  internal static partial class Settings {
    #region --- properties ------------------------------------------------------------------------
    public static bool   AutoLoadRepository { get; set; }
    public static string DefaultPath        { get; set; }         = string.Empty;
    public static bool   IsNotInDesignMode  { get; private set; } = false;
    #endregion
    
    #region --- get app namespace -----------------------------------------------------------------
    public static string GetAppNamespace() {
      string? result = Assembly
          .GetCallingAssembly()
          .EntryPoint?
          .DeclaringType?
          .Namespace;

      result ??= Assembly
        .GetExecutingAssembly()
        .GetName()
        .Name;

      result ??= string.Empty;

      return result;
    }
    #endregion
    #region --- get app path ----------------------------------------------------------------------
    public static string GetAppPath() {
      string? result = Assembly
        .GetEntryAssembly()?
        .Location
        .GetSubstringBeforeLastOccurrence('\\');

      result ??= string.Empty;

      return result;
    }
    #endregion
    #region --- read ini --------------------------------------------------------------------------
    public static void ReadIni() {
      IsNotInDesignMode = true; // disable design mode when app runs (to prevent visual studio designer to adopt values)

      List<string> result = [];

      string iniPath = @$"{GetAppPath()}\editor.ini";

      if (!File.Exists(iniPath)) {
        SetDefaults();
        return;
      }

      foreach (string line in File.ReadLines(iniPath)) {
        string parameter = line.GetSubstringBeforeOccurrence(':', 1);
        string value     = line.GetSubstringAfterOccurrence(':', 1).Trim();

        switch (parameter) { 
          case "Auto Load Repository": AutoLoadRepository = bool.Parse(value); break;
          case "Default Path":         DefaultPath        = value;             break;
        }
      }
    }
    #endregion
    #region --- set defaults ----------------------------------------------------------------------
    public static void SetDefaults() {
      AutoLoadRepository = false;
      DefaultPath        = string.Empty;

      WriteIni();
    }
    #endregion
    #region --- update ----------------------------------------------------------------------------
    public static void Update() {
      // ...
    }
    #endregion
    #region --- write ini -------------------------------------------------------------------------
    public static void WriteIni() {
      string iniPath = @$"{GetAppPath()}\editor.ini";

      string nl = Environment.NewLine;

      string content = $"# ================================================================================================={nl}"
                     + $"# Ambermoon.net: Editor Settings{nl}"
                     + $"# ================================================================================================={nl}"
                     + $"{nl}"
                     + $"Default Path:         {DefaultPath}{nl}"
                     + $"Auto Load Repository: {AutoLoadRepository}{nl}";

      try {
        File.WriteAllText(iniPath, content);
      } catch {
        MsgBox.Show(
          "File error",
          $"Default settings could not be written into file:{nl}"
          + $"{iniPath}{nl}{nl}"
          + "Please restart the editor as administrator!",
          MessageBoxButtons.OK
        );

        Environment.Exit(1);
      }    
    }
    #endregion
  }
}