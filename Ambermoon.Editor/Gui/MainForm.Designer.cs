﻿namespace Ambermoon.Editor.Gui
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			TreeNode treeNode1 = new TreeNode("Info");
			TreeNode treeNode2 = new TreeNode("Monsters");
			TreeNode treeNode3 = new TreeNode("Monster Groups");
			TreeNode treeNode4 = new TreeNode("NPCs");
			TreeNode treeNode5 = new TreeNode("Characters", new TreeNode[] { treeNode2, treeNode3, treeNode4 });
			TreeNode treeNode6 = new TreeNode("Items");
			TreeNode treeNode7 = new TreeNode("Maps");
			menu = new MenuStrip();
			repositoryToolStripMenuItem = new ToolStripMenuItem();
			menuItemLoad = new ToolStripMenuItem();
			menuItemUnload = new ToolStripMenuItem();
			menuItemSave = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			menuItemSettings = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			menuItemExit = new ToolStripMenuItem();
			splitContainer = new SplitContainer();
			trv = new TreeView();
			statusStrip = new StatusStrip();
			menu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
			splitContainer.Panel1.SuspendLayout();
			splitContainer.SuspendLayout();
			SuspendLayout();
			// 
			// menu
			// 
			menu.Items.AddRange(new ToolStripItem[] { repositoryToolStripMenuItem });
			menu.Location = new Point(0, 0);
			menu.Name = "menu";
			menu.Size = new System.Drawing.Size(828, 24);
			menu.TabIndex = 0;
			menu.Text = "menu";
			// 
			// repositoryToolStripMenuItem
			// 
			repositoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItemLoad, menuItemUnload, menuItemSave, toolStripSeparator2, menuItemSettings, toolStripSeparator1, menuItemExit });
			repositoryToolStripMenuItem.Name = "repositoryToolStripMenuItem";
			repositoryToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			repositoryToolStripMenuItem.Text = "Repository";
			// 
			// menuItemLoad
			// 
			menuItemLoad.Name = "menuItemLoad";
			menuItemLoad.ShortcutKeys = Keys.Control | Keys.L;
			menuItemLoad.Size = new System.Drawing.Size(154, 22);
			menuItemLoad.Text = "Load";
			// 
			// menuItemUnload
			// 
			menuItemUnload.Enabled = false;
			menuItemUnload.Name = "menuItemUnload";
			menuItemUnload.ShortcutKeys = Keys.Control | Keys.U;
			menuItemUnload.Size = new System.Drawing.Size(154, 22);
			menuItemUnload.Text = "Unload";
			// 
			// menuItemSave
			// 
			menuItemSave.Enabled = false;
			menuItemSave.Name = "menuItemSave";
			menuItemSave.ShortcutKeys = Keys.Control | Keys.S;
			menuItemSave.Size = new System.Drawing.Size(154, 22);
			menuItemSave.Text = "Save";
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
			// 
			// menuItemSettings
			// 
			menuItemSettings.Name = "menuItemSettings";
			menuItemSettings.ShortcutKeys = Keys.F2;
			menuItemSettings.Size = new System.Drawing.Size(154, 22);
			menuItemSettings.Text = "Settings";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
			// 
			// menuItemExit
			// 
			menuItemExit.Name = "menuItemExit";
			menuItemExit.ShortcutKeys = Keys.Control | Keys.Q;
			menuItemExit.Size = new System.Drawing.Size(154, 22);
			menuItemExit.Text = "Exit";
			// 
			// splitContainer
			// 
			splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			splitContainer.BackColor = Color.Transparent;
			splitContainer.FixedPanel = FixedPanel.Panel1;
			splitContainer.Location = new Point(0, 24);
			splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			splitContainer.Panel1.Controls.Add(trv);
			// 
			// splitContainer.Panel2
			// 
			splitContainer.Panel2.BackColor = Color.Transparent;
			splitContainer.Size = new System.Drawing.Size(828, 537);
			splitContainer.SplitterDistance = 160;
			splitContainer.TabIndex = 2;
			// 
			// trv
			// 
			trv.Dock = DockStyle.Fill;
			trv.ForeColor = SystemColors.ControlText;
			trv.Location = new Point(0, 0);
			trv.Name = "trv";
			treeNode1.Name = "trvNodeInfo";
			treeNode1.Text = "Info";
			treeNode2.Name = "trvNodeCharactersMonsters";
			treeNode2.Text = "Monsters";
			treeNode3.Name = "trvNodeCharactersMonsterGroups";
			treeNode3.Text = "Monster Groups";
			treeNode4.Name = "trvNodeCharactersNPCs";
			treeNode4.Text = "NPCs";
			treeNode5.Name = "trvNodeCharacters";
			treeNode5.Text = "Characters";
			treeNode6.Name = "trvNodeItems";
			treeNode6.Text = "Items";
			treeNode7.Name = "trvNodeMaps";
			treeNode7.Text = "Maps";
			trv.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode5, treeNode6, treeNode7 });
			trv.Size = new System.Drawing.Size(160, 537);
			trv.TabIndex = 0;
			// 
			// statusStrip
			// 
			statusStrip.Location = new Point(0, 564);
			statusStrip.Name = "statusStrip";
			statusStrip.Size = new System.Drawing.Size(828, 22);
			statusStrip.TabIndex = 3;
			statusStrip.Text = "statusStrip1";
			// 
			// MainForm
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(828, 586);
			Controls.Add(statusStrip);
			Controls.Add(splitContainer);
			Controls.Add(menu);
			DoubleBuffered = true;
			Location = new Point(0, 0);
			MainMenuStrip = menu;
			MinimumSize = new System.Drawing.Size(600, 400);
			Name = "MainForm";
			Text = "Ambermoon Editor";
			DragDrop += MainForm_DragDrop;
			DragOver += MainForm_DragOver;
			menu.ResumeLayout(false);
			menu.PerformLayout();
			splitContainer.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
			splitContainer.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menu;
		private ToolStripMenuItem repositoryToolStripMenuItem;
		private ToolStripMenuItem menuItemLoad;
		private ToolStripMenuItem menuItemSave;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem menuItemExit;
		private ToolStripMenuItem menuItemUnload;
		private SplitContainer splitContainer;
		private TreeView trv;
		private StatusStrip statusStrip;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem menuItemSettings;
	}
}