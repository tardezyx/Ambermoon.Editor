using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using System.Drawing.Text;
using System.Reflection;
using System.Text.Json;

namespace Ambermoon.Editor.Base
{
	internal static partial class Settings
	{
		private class StoredSettings
		{
			public bool AutoLoadRepository { get; set; } = false;
			public string DefaultPath { get; set; } = string.Empty;
			public string DefaultImageExportPath { get; set; } = string.Empty;
		}
		#region --- fields ----------------------------------------------------------------------------
		private static readonly PrivateFontCollection _fontCollection = new();
		private static StoredSettings storedSettings = new();
		#endregion
		#region --- properties ------------------------------------------------------------------------
		private static string SettingsPath => @$"{GetAppPath()}\editor.config";
		public static bool AutoLoadRepository
		{
			get => storedSettings.AutoLoadRepository;
			set => storedSettings.AutoLoadRepository = value;
		}
		public static string DefaultPath
		{
			get => storedSettings.DefaultPath;
			set => storedSettings.DefaultPath = value;
		}
		/// <summary>
		/// Path where images are exported. Like map or tile PNGs, etc.
		/// </summary>
		public static string DefaultImageExportPath
		{
			get => storedSettings.DefaultImageExportPath;
			set => storedSettings.DefaultImageExportPath = value;
		}
		public static bool IsNotInDesignMode { get; private set; } = false;
		#endregion
		#region --- get app namespace -----------------------------------------------------------------
		public static string GetAppNamespace()
		{
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
		public static string GetAppPath()
		{
			string? result = Assembly
			  .GetEntryAssembly()?
			  .Location
			  .GetSubstringBeforeLastOccurrence('\\');

			result ??= string.Empty;

			return result;
		}
		#endregion
		#region --- get font --------------------------------------------------------------------------
		public static Font GetFont(float size, bool runes = false)
		{
			FontFamily fontFamily = new(
			  runes
				? "Ambermoon-rune"
				: "Ambermoon-game",
			  _fontCollection
			);

			return new(fontFamily, size);
		}
		#endregion
		#region --- read fonts ------------------------------------------------------------------------
		public static void ReadFonts()
		{
			_fontCollection.AddFontFile(Path.Combine(GetAppPath(), "Fonts", "ambermoon-game.ttf"));
			_fontCollection.AddFontFile(Path.Combine(GetAppPath(), "Fonts", "ambermoon-rune.ttf"));
		}
		#endregion
		#region --- load config -----------------------------------------------------------------------
		public static void Load()
		{
			string settingsPath = SettingsPath;

			if (!File.Exists(settingsPath))
			{
				SetDefaults();
				return;
			}

			try
			{
				string json = File.ReadAllText(settingsPath);
				storedSettings = JsonSerializer.Deserialize<StoredSettings>(json)!;
			}
			catch
			{
				SetDefaults();
			}
		}
		#endregion
		#region --- set defaults ----------------------------------------------------------------------
		public static void SetDefaults()
		{
			AutoLoadRepository = false;
			DefaultPath = string.Empty;

			Save();
		}
		#endregion
		#region --- update ----------------------------------------------------------------------------
		public static void Update()
		{
			// ...
		}
		#endregion
		#region --- write ini -------------------------------------------------------------------------
		public static void Save()
		{
			string settingsPath = SettingsPath;

			try
			{
				string json = JsonSerializer.Serialize(storedSettings);
				File.WriteAllText(settingsPath, json);
			}
			catch
			{
				string nl = Environment.NewLine;

				MsgBox.Show(
				  "File error",
				  $"Default settings could not be written into file:{nl}"
				  + $"{settingsPath}{nl}{nl}"
				  + "Please restart the editor as administrator!",
				  MessageBoxButtons.OK
				);

				Environment.Exit(1);
			}
		}
		#endregion
	}
}