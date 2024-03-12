namespace Ambermoon.Editor.Gui.Custom
{
	public partial class FilterControl : UserControl
	{
		public string Filter
		{
			get => textBoxFilter.Text;
			set => textBoxFilter.Text = value;
		}

		public event Action<string>? FilterChanged;

		public FilterControl()
		{
			InitializeComponent();

			textBoxFilter.TextChanged += (_, _) => FilterChanged?.Invoke(Filter);
		}
	}
}
