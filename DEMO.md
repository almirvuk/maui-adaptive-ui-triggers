# Presenter runbook

## Before the talk

- Launch **both** apps before you go on stage:
  - Mac: `dotnet build -t:Run -f net10.0-maccatalyst`
  - iOS Simulator: `dotnet build -t:Run -f net10.0-ios` on an **iPhone** simulator (not iPad, where the flyout locks and orientation behaves like a tablet).
- Rotate the simulator with **Cmd+←** / **Cmd+→**.
- An iPhone in landscape is wider than 800, so it can also cross the AdaptiveTrigger breakpoint and flip page 17 to horizontal. Expected, not a bug.
- Have the backup recording open in another window. **If a demo doesn't work within ~15 s, play the recording instead of debugging.**
- Leave the Mac window wider than 1100 before page 17 (see the note there).

---

# Demo 1: Triggers (pages 06–12)

## 06 · Property trigger (slides 6–7)

- **Open:** `Pages/PropertyTriggerPage.xaml`
- **Highlight:** lines 33–40 (inline `Entry.Triggers`), then lines 10–19 (implicit `Style` in `ContentPage.Resources`).
- **Click:** each of the three fields in turn, or Tab between them.
- **Expect:** the focused field turns yellow and goes back when it loses focus. Email and Phone get it without any trigger of their own.
- **Say:** "A property trigger watches the control's own property, and the undo is free."

## 08 · Data trigger (slide 8)

- **Open:** `Pages/DataTriggerPage.xaml`
- **Highlight:** line 20–22 (`Text=""`) + lines 24–32, then line 44–45 (broken Entry, no `Text`).
- **Click:** nothing at first. Point at both Save buttons. Then type a letter in the second field and delete it.
- **Expect:** the top Save is disabled; the bottom Save is **enabled** on an empty field. After type + delete, the bottom one is disabled too.
- **Say:** "Without `Text=""` the Text is null, `Text.Length` is never 0, and the bug fixes itself the moment a tester types, which is why it ships."

## 09 · Converter (slide 9)

- **Open:** `Pages/ConverterTriggerPage.xaml` (and `Converters/IsGreaterThanConverter.cs`)
- **Highlight:** line 10 (converter resource) + lines 30–38 (`Converter={StaticResource gt}, ConverterParameter=10`, `Value="True"`).
- **Click:** the stepper's + from 8 up to 11, then back down.
- **Expect:** at 11 the number turns red and "Over the limit!" appears; at 10 or below both revert.
- **Say:** "Triggers only test equality; a converter turns 'greater than 10' into a plain True."

## 10 · Event trigger (slide 10)

- **Open:** `Pages/EventTriggerPage.xaml` (and `TriggerActions/NumericValidationTriggerAction.cs`)
- **Highlight:** lines 22–26 (`EventTrigger Event="TextChanged"`), then the action's `Invoke`.
- **Click:** type `42`, then `42a`, then delete the `a`.
- **Expect:** text goes red on `42a` and black again only because the action runs again on the next keystroke.
- **Say:** "Event triggers are one-way. Nothing is undone for you, so your action has to put things back itself."

## 11 · Multi-trigger (slide 11)

- **Open:** `Pages/MultiTriggerPage.xaml`
- **Highlight:** lines 18–23 (`Text=""` on both) + lines 26–41 (two `BindingCondition`s).
- **Click:** type only in Phone; clear it; type only in Email.
- **Expect:** Save is disabled only while **both** fields are empty.
- **Say:** "All conditions must be true to apply the setter, so this reads 'at least one contact method', not 'both required'."

## 12 · Enter / exit actions (slide 12)

- **Open:** `Pages/EnterExitActionsPage.xaml` (and `TriggerActions/FadeTriggerAction.cs`)
- **Highlight:** lines 21–31 (`EnterActions` / `ExitActions` with `StartsFrom`).
- **Click:** the job-title field, then the second field.
- **Expect:** a 1-second fade to magenta on focus, and back to white on blur.
- **Say:** "FadeTriggerAction isn't built in. It's a ten-line TriggerAction you write yourself."

---

# Demo 2: State triggers (pages 16–19)

## 16 · StateTrigger (slide 16)

- **Open:** `Pages/StateTriggerPage.xaml`
- **Highlight:** lines 26–48: the two `StateTrigger IsActive` bindings (line 30 and line 40 with the inverse converter) and the `Setter TargetName="stateLabel"` lines.
- **Click:** the switch, a few times.
- **Expect:** the card goes dark with white "State: On", then back to light "State: Off".
- **Say:** "A visual state applies while its trigger is active, and TargetName lets one state restyle other elements."

## 17 · AdaptiveTrigger (slide 17): the climax

- **Open:** `Pages/AdaptiveTriggerPage.xaml` (and `AdaptiveTriggerPage.xaml.cs` if asked)
- **Highlight:** lines 22–44: groups attached directly to `RootStack`, `MinWindowWidth="0"` and `MinWindowWidth="800"`.
- **Click:** drag the Mac window's edge slowly across 800 while watching "Window width".
- **Expect:** below 800 the cards stack; at 800 and above they sit side by side. The state line updates with them.
- **Note:** the trigger checks **Window** width, not page width. The locked flyout takes 260, so just past 800 the page is only ~540 wide and the second card is clipped on the right until the window is about 1000+. Do the drag from ~700 to ~1100 so the end state looks clean.
- **Say:** "No code, no size handler: the breakpoint lives in XAML, and the same page is the phone layout and the desktop layout."

## 18 · Orientation (slide 18)

- **Open:** `Pages/OrientationTriggerPage.xaml`
- **Highlight:** lines 20–42 (two `OrientationStateTrigger`s).
- **Click:** on the iPhone simulator, Cmd+← / Cmd+→.
- **Expect:** "Portrait" with stacked cards; "Landscape" in pink with cards side by side. On Mac it always says Landscape.
- **Say:** "AdaptiveTrigger reacts to window size; OrientationStateTrigger reacts to how the device is held."

## 19 · Device & Compare (slide 19)

- **Open:** `Pages/DeviceCompareTriggerPage.xaml`
- **Highlight:** lines 18–57 (`DeviceStateTrigger` per platform), then lines 75–99 (`CompareStateTrigger` bound to `checkBox.IsChecked`).
- **Click:** show the Mac and the simulator side by side; then tick the CheckBox.
- **Expect:** pink "Running on Mac Catalyst" vs blue "Running on iOS"; the inner box goes dark "Checked" and back to "Unchecked".
- **Say:** "Same XAML, different platform, different state, plus a no-converter way to say 'when this property equals that value'."
