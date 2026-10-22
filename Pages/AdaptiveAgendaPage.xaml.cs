namespace TriggersShowcase.Pages;

public partial class AdaptiveAgendaPage : ContentPage
{
	public AdaptiveAgendaPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		// Close the flyout left open when coming from a page with a locked flyout
		if (Shell.Current is { } shell)
			Dispatcher.Dispatch(() => shell.FlyoutIsPresented = false);

		// Same width read-out as page 17
		if (Window is not null)
		{
			Window.SizeChanged += OnWindowSizeChanged;
			UpdateWidthLabel();
		}
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();

		if (Window is not null)
			Window.SizeChanged -= OnWindowSizeChanged;
	}

	void OnWindowSizeChanged(object? sender, EventArgs e) => UpdateWidthLabel();

	void UpdateWidthLabel() => widthLabel.Text = $"Window width: {Window?.Width:0}";
}
