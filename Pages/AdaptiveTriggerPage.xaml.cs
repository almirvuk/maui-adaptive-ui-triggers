namespace TriggersShowcase.Pages;

public partial class AdaptiveTriggerPage : ContentPage
{
	public AdaptiveTriggerPage()
	{
		InitializeComponent();
	}

	// AdaptiveTrigger checks Window.Width, not the page width (the locked flyout eats ~260).
	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);

		if (Window is not null)
			widthLabel.Text = $"Window width: {Window.Width:0}";
	}
}
