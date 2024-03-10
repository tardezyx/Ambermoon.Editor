namespace Ambermoon.Editor.Gui.Custom
{
	partial class FilterControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			labelFilter = new Label();
			textBoxFilter = new TextBox();
			SuspendLayout();
			// 
			// labelFilter
			// 
			labelFilter.AutoSize = true;
			labelFilter.Location = new Point(3, 8);
			labelFilter.Name = "labelFilter";
			labelFilter.Size = new System.Drawing.Size(36, 15);
			labelFilter.TabIndex = 0;
			labelFilter.Text = "Filter:";
			// 
			// textBoxFilter
			// 
			textBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			textBoxFilter.Location = new Point(45, 4);
			textBoxFilter.Name = "textBoxFilter";
			textBoxFilter.Size = new System.Drawing.Size(239, 23);
			textBoxFilter.TabIndex = 1;
			// 
			// FilterControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(textBoxFilter);
			Controls.Add(labelFilter);
			Name = "FilterControl";
			Size = new System.Drawing.Size(287, 30);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelFilter;
		private TextBox textBoxFilter;
	}
}
