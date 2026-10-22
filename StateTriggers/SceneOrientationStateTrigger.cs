namespace TriggersShowcase.StateTriggers;

// Same as OrientationStateTrigger, but works on iOS 27: reads the orientation from the window scene
// instead of the deprecated status bar orientation, which stays on Portrait.
public sealed class SceneOrientationStateTrigger : StateTriggerBase
{
	public static readonly BindableProperty OrientationProperty =
		BindableProperty.Create(nameof(Orientation), typeof(DisplayOrientation), typeof(SceneOrientationStateTrigger),
			DisplayOrientation.Unknown, propertyChanged: (bindable, _, _) => ((SceneOrientationStateTrigger)bindable).UpdateState());

	public DisplayOrientation Orientation
	{
		get => (DisplayOrientation)GetValue(OrientationProperty);
		set => SetValue(OrientationProperty, value);
	}

	Window? _window;

	protected override void OnAttached()
	{
		base.OnAttached();

		_window = Application.Current?.Windows.FirstOrDefault();
		if (_window is not null)
			_window.SizeChanged += OnChanged;
		DeviceDisplay.Current.MainDisplayInfoChanged += OnChanged;

		UpdateState(knownAttached: true);
	}

	protected override void OnDetached()
	{
		base.OnDetached();

		if (_window is not null)
			_window.SizeChanged -= OnChanged;
		DeviceDisplay.Current.MainDisplayInfoChanged -= OnChanged;
		_window = null;
	}

	void OnChanged(object? sender, EventArgs e) => UpdateState();

	void UpdateState(bool knownAttached = false)
	{
		if (!knownAttached && !IsAttached)
			return;

		SetActive(Orientation != DisplayOrientation.Unknown && CurrentOrientation() == Orientation);
	}

	DisplayOrientation CurrentOrientation()
	{
#if IOS
		if (_window?.Handler?.PlatformView is UIKit.UIWindow { WindowScene: { } scene })
		{
			var orientation = OperatingSystem.IsIOSVersionAtLeast(16)
				? scene.EffectiveGeometry.InterfaceOrientation
				: scene.InterfaceOrientation;

			switch (orientation)
			{
				case UIKit.UIInterfaceOrientation.LandscapeLeft:
				case UIKit.UIInterfaceOrientation.LandscapeRight:
					return DisplayOrientation.Landscape;
				case UIKit.UIInterfaceOrientation.Portrait:
				case UIKit.UIInterfaceOrientation.PortraitUpsideDown:
					return DisplayOrientation.Portrait;
			}
		}
#endif
		return DeviceDisplay.Current.MainDisplayInfo.Orientation;
	}
}
