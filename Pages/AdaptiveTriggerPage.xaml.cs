namespace TriggersShowcase.Pages;

public partial class AdaptiveTriggerPage : ContentPage
{
	public AdaptiveTriggerPage()
	{
		InitializeComponent();
	}

	// AdaptiveTrigger checks Window.Width, not the page width (the locked flyout eats ~260).
	// Updated on Window.SizeChanged so it matches what the trigger sees.
	protected override void OnAppearing()
	{
		base.OnAppearing();

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
