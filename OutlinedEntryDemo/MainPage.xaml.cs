using Microsoft.Maui.Platform;
using OutlinedEntryDemo.Handlers;

namespace OutlinedEntryDemo;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
		ModifyEntry();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    void ModifyEntry()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            //handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
			handler.PlatformView.BorderBrush = Colors.Transparent.ToPlatform();
#endif
        });
    }
}


