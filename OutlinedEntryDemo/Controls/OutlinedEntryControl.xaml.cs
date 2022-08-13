using static System.Net.Mime.MediaTypeNames;

namespace OutlinedEntryDemo.Controls
{
	public partial class OutlinedEntryControl : Grid
	{
		public OutlinedEntryControl()
		{
			InitializeComponent();
		}


		public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
			propertyName: nameof(Placeholder),
			returnType: typeof(string),
			declaringType: typeof(OutlinedEntryControl),
			defaultValue:null,
			defaultBindingMode: BindingMode.OneWay
			);

		public string Placeholder
		{
			get => (string)GetValue(PlaceholderProperty);
			set { SetValue(PlaceholderProperty, value); }

		}

	public static readonly BindableProperty TextProperty = BindableProperty.Create(
		propertyName: nameof(Text),
		returnType: typeof(string),
		declaringType: typeof(OutlinedEntryControl),
		defaultValue: null,
		defaultBindingMode: BindingMode.TwoWay
		);

		public string Text
		{
			get => (string)GetValue(TextProperty);
			set { SetValue(TextProperty, value); }
		}

        void txtEntry_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
        {
		
			lblPlaceholder.FontSize = 11;
			lblPlaceholder.TranslateTo(0, -26, 80, Easing.Linear);
			
        }

        void txtEntry_Unfocused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
        {
			if (!string.IsNullOrWhiteSpace(Text))
			{
                lblPlaceholder.FontSize = 11;
                lblPlaceholder.TranslateTo(0, -26, 80, Easing.Linear);
            }
			else
			{
				lblPlaceholder.FontSize = 15;
				lblPlaceholder.TranslateTo(0, 0, 80, Easing.Linear);
			}
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
			txtEntry.Focus();
        }
    }
}