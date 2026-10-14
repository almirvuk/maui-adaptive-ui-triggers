# TriggersShowcase

Demo app for the talk **"One Screen, Every Device: State Triggers and the Visual State Manager in .NET MAUI"**.

One page per trigger type, numbered to match the slides. Every page is short and self-contained: open the XAML, highlight the trigger, run the page.

## Prerequisites

- macOS with Xcode (and its iOS Simulator runtimes) installed
- .NET 10 SDK
- MAUI workload: `dotnet workload install maui`

## Run

Mac Catalyst:

```bash
dotnet build -t:Run -f net10.0-maccatalyst
```

iOS Simulator (use an **iPhone**, not an iPad):

```bash
# list simulators and copy an iPhone UDID
xcrun simctl list devices available | grep iPhone

dotnet build -t:Run -f net10.0-ios -p:_DeviceName=:v2:udid=<UDID>
```

If you leave out `-p:_DeviceName=...`, the default simulator is used.

## Slide → page → file

| Slide | Flyout entry | Page | File |
|---|---|---|---|
| 6–7 | 06 · Property trigger | `PropertyTriggerPage` | [Pages/PropertyTriggerPage.xaml](Pages/PropertyTriggerPage.xaml) |
| 8 | 08 · Data trigger | `DataTriggerPage` | [Pages/DataTriggerPage.xaml](Pages/DataTriggerPage.xaml) |
| 9 | 09 · Converter | `ConverterTriggerPage` | [Pages/ConverterTriggerPage.xaml](Pages/ConverterTriggerPage.xaml), [Converters/IsGreaterThanConverter.cs](Converters/IsGreaterThanConverter.cs) |
| 10 | 10 · Event trigger | `EventTriggerPage` | [Pages/EventTriggerPage.xaml](Pages/EventTriggerPage.xaml), [TriggerActions/NumericValidationTriggerAction.cs](TriggerActions/NumericValidationTriggerAction.cs) |
| 11 | 11 · Multi-trigger | `MultiTriggerPage` | [Pages/MultiTriggerPage.xaml](Pages/MultiTriggerPage.xaml) |
| 12 | 12 · Enter / exit | `EnterExitActionsPage` | [Pages/EnterExitActionsPage.xaml](Pages/EnterExitActionsPage.xaml), [TriggerActions/FadeTriggerAction.cs](TriggerActions/FadeTriggerAction.cs) |
| 16 | 16 · StateTrigger | `StateTriggerPage` | [Pages/StateTriggerPage.xaml](Pages/StateTriggerPage.xaml), [Converters/InverseBoolConverter.cs](Converters/InverseBoolConverter.cs) |
| 17 | 17 · AdaptiveTrigger | `AdaptiveTriggerPage` | [Pages/AdaptiveTriggerPage.xaml](Pages/AdaptiveTriggerPage.xaml), [Pages/AdaptiveTriggerPage.xaml.cs](Pages/AdaptiveTriggerPage.xaml.cs) |
| 18 | 18 · Orientation | `OrientationTriggerPage` | [Pages/OrientationTriggerPage.xaml](Pages/OrientationTriggerPage.xaml) |
| 19 | 19 · Device & Compare | `DeviceCompareTriggerPage` | [Pages/DeviceCompareTriggerPage.xaml](Pages/DeviceCompareTriggerPage.xaml) |

## Layout

```
Pages/            one ContentPage per slide
TriggerActions/   NumericValidationTriggerAction, FadeTriggerAction
Converters/       IsGreaterThanConverter, InverseBoolConverter
Resources/Styles/ Colors.xaml (palette), Styles.xaml (look only, no triggers)
AppShell.xaml     flyout: Part 1 · Triggers, Part 2 · State triggers
```

The presenter runbook is in [DEMO.md](DEMO.md).

References:
[Triggers](https://learn.microsoft.com/dotnet/maui/fundamentals/triggers?view=net-maui-10.0) ·
[Visual states](https://learn.microsoft.com/dotnet/maui/user-interface/visual-states?view=net-maui-10.0)
