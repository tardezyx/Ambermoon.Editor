using Ambermoon.Editor.Base;

namespace AmbermoonMapEditor2D
{
	internal class ImageExportDialog(string title, string? defaultExtension = null)
	{
		private readonly string title = title ?? "Save image";
		private readonly string defaultExtension = defaultExtension ?? "png";

		public string Filter { get; set; } = "";
		public string FileName { get; set; } = "";

		public DialogResult ShowDialog()
		{
			return Show(dialog => dialog.ShowDialog());
		}

		public DialogResult ShowDialog(IWin32Window owner)
		{
			return Show(dialog => dialog.ShowDialog(owner));
		}

		private DialogResult Show(Func<SaveFileDialog, DialogResult> showMethod)
		{
			string savePath = Settings.DefaultImageExportPath;
			string saveDirectory = "";
			string saveFileName = "";

			if (!string.IsNullOrWhiteSpace(FileName))
			{
				if (Path.IsPathRooted(FileName))
					saveDirectory = Path.GetDirectoryName(FileName)!;
				else if (!string.IsNullOrWhiteSpace(savePath) && Path.IsPathRooted(savePath))
					saveDirectory = Path.GetDirectoryName(savePath)!;

				saveFileName = Path.GetFileName(FileName);
			}
			else if (!string.IsNullOrWhiteSpace(savePath))
			{
				if (Path.IsPathRooted(savePath))
					saveDirectory = Path.GetDirectoryName(savePath)!;

				saveFileName = Path.GetFileName(savePath);
			}

			var dialog = new SaveFileDialog
			{
				DefaultExt = defaultExtension,
				AddExtension = defaultExtension != null,
				CheckFileExists = false,
				CheckPathExists = false,
				CreatePrompt = false,
				Filter = Filter,
				FilterIndex = 0,
				OverwritePrompt = true,
				RestoreDirectory = false,
				Title = title,
				InitialDirectory = saveDirectory,
				FileName = saveFileName
			};

			var result = showMethod(dialog);

			if (result == DialogResult.OK)
			{
				FileName = dialog.FileName;
				Settings.DefaultImageExportPath = Path.GetDirectoryName(FileName)!;
			}

			return result;
		}
	}
}
