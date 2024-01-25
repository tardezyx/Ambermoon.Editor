using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui;
using Ambermoon.Editor.Models;

namespace Ambermoon.Editor.Base {
  internal static class Program {
    [STAThread]
    static void Main() {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.

      Settings.ReadIni();

      if (Settings.AutoLoadRepository && Settings.DefaultPath.HasText()) {
        Repository.Current.Load(Settings.DefaultPath);
      }

      ApplicationConfiguration.Initialize();
      Application.Run(new MainForm());
    }
  }
}