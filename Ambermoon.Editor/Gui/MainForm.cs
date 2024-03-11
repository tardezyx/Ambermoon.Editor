using Ambermoon.Editor.Base;
using Ambermoon.Editor.Extensions;
using Ambermoon.Editor.Gui.Custom;
using Ambermoon.Editor.Gui.Overviews;
using Ambermoon.Editor.Models;
using System.Windows.Forms;
using static SonicArranger.Instrument;

namespace Ambermoon.Editor.Gui {
	public partial class MainForm : CustomForm
	{
		#region --- fields ----------------------------------------------------------------------------
#pragma warning disable CS0649 // wrong warning as forms are set within ShowForm()
		//private readonly InfoForm?          _infoForm;
		private readonly MapsForm? _mapsForm;
		private readonly MonstersForm? _monstersForm;
		private readonly MonsterGroupsForm? _monsterGroupsForm;
		private readonly NPCsForm? _npcsForm;
#pragma warning restore CS0649
		#endregion
		#region --- local enum: entity type -----------------------------------------------------------
		private enum EntityType
		{
			Maps,
			Monsters,
			MonsterGroups,
			NPCs,
		}
		#endregion

		#region --- constructor -----------------------------------------------------------------------
		public MainForm()
		{
			InitializeComponent();
		}
		#endregion
		#region --- on load ---------------------------------------------------------------------------
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			Settings.ReadIni();

			if (Settings.AutoLoadRepository && Settings.DefaultPath.HasText())
			{
				Repository.Current.Load(Settings.DefaultPath);
			}

			trv.ExpandAll();
			CenterToScreen();
			UpdateControls();
			WireEvents();
		}
		#endregion
		#region --- update controls -------------------------------------------------------------------
		private void UpdateControls()
		{
			menuItemLoad.Enabled = Repository.Current.GameData is null;
			menuItemSave.Enabled =
			menuItemUnload.Enabled =
			splitContainer.Enabled = Repository.Current.GameData is not null;
		}
		#endregion
		#region --- wire events -----------------------------------------------------------------------
		private void WireEvents()
		{
			menuItemExit.Click += (s, e) => { Repository.Current.Save(); Application.Exit(); };
			menuItemLoad.Click += (s, e) => LoadRepository();
			menuItemSave.Click += (s, e) => Repository.Current.Save();
			menuItemSettings.Click += (s, e) => { SettingsForm form = new(); form.Show(); };
			menuItemUnload.Click += (s, e) => UnloadRepository();
			trv.AfterSelect += (s, e) => NodeSelected(e.Node?.Name);
		}
		#endregion

		#region --- load repository -------------------------------------------------------------------
		private void LoadRepository()
		{
			FolderBrowserDialog folderBrowserDialog = new()
			{
				AutoUpgradeEnabled = true,
				Description = "Where is your Ambermoon data folder (i.e. Amberfiles)?",
				ShowNewFolderButton = false,
				UseDescriptionForTitle = true
			};

			if (Repository.Current.Folder.HasText())
			{
				folderBrowserDialog.InitialDirectory = Repository.Current.Folder;
			}

			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				Repository.Current.Load(folderBrowserDialog.SelectedPath);
			}

			UpdateControls();
		}
		#endregion
		#region --- unload repository -----------------------------------------------------------------
		private void UnloadRepository()
		{
			Repository.Current.Unload();

			for (int i = splitContainer.Panel2.Controls.Count - 1; i > -1; i--)
			{
				if (splitContainer.Panel2.Controls[i] is Form form)
				{
					splitContainer.Panel2.Controls.Remove(form);
					form.Close();
				}
			}

			UpdateControls();
		}
		#endregion

		#region --- node selected ---------------------------------------------------------------------
		private void NodeSelected(string? nodeName)
		{
			if (nodeName.IsNullOrEmpty())
			{
				return;
			}

			switch (nodeName)
			{
				//case "trvNodeInfo":                    ShowForm(EntityType.Maps);          break;
				case "trvNodeMaps": ShowForm(EntityType.Maps); break;
				case "trvNodeCharactersMonsters": ShowForm(EntityType.Monsters); break;
				case "trvNodeCharactersMonsterGroups": ShowForm(EntityType.MonsterGroups); break;
				case "trvNodeCharactersNPCs": ShowForm(EntityType.NPCs); break;
			}
		}
		#endregion
		#region --- show form -------------------------------------------------------------------------
		private void ShowForm(EntityType type)
		{
			if (Repository.Current.GameData is not null)
			{
				Form? form = type switch
				{
					EntityType.Maps => _mapsForm,
					EntityType.Monsters => _monstersForm,
					EntityType.MonsterGroups => _monsterGroupsForm,
					EntityType.NPCs => _npcsForm,
					_ => throw new NotImplementedException(),
				};

				if (form is null || form.IsDisposed)
				{
					form = type switch
					{
						EntityType.Maps => new MapsForm(),
						EntityType.Monsters => new MonstersForm(),
						EntityType.MonsterGroups => new MonsterGroupsForm(),
						EntityType.NPCs => new NPCsForm(),
						_ => throw new NotImplementedException(),
					};

					form.Dock = DockStyle.Fill;
					form.TopLevel = false;
					splitContainer.Panel2.Controls.Add(form);
				}

				foreach (Control control in splitContainer.Panel2.Controls)
				{
					if (control is Form && control != form)
					{
						control.Hide();
						control.SendToBack();
					}
				}

				form.Show();
				form.BringToFront();
			}
		}
		#endregion

		#region --- drag & drop ------------------------------------------------------------------------
		private void MainForm_DragOver(object sender, DragEventArgs e)
		{
			DragDropEffects effects = DragDropEffects.None;

			if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
			{
				var path = ((string[])e.Data.GetData(DataFormats.FileDrop)!)[0];

				if (Directory.Exists(path))
					effects = DragDropEffects.Copy;
			}

			e.Effect = effects;
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Effect == DragDropEffects.Copy && e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
			{
				var path = ((string[])e.Data.GetData(DataFormats.FileDrop)!)[0];

				if (Repository.Current.Load(path))
				{
					UpdateControls();
				}
			}
		}
		#endregion
	}
}