using TriggersShowcase.Models;

namespace TriggersShowcase.Data;

// Sample agenda. Speakers are F1 drivers, sessions are made up.
public static class SampleSessions
{
	public static Color MobileColor { get; } = Color.FromArgb("#512BD4");
	public static Color WebColor { get; } = Color.FromArgb("#0E9F8E");
	public static Color CloudColor { get; } = Color.FromArgb("#2F7DE1");
	public static Color AIColor { get; } = Color.FromArgb("#FF5C8A");

	public static IReadOnlyList<Session> All { get; } =
	[
		new()
		{
			Title = "One UI for phone, tablet and desktop",
			Speaker = "Max Verstappen",
			Track = "Mobile", TrackColor = MobileColor,
			Time = "09:30", Room = "Room A",
			Abstract = "A tour of a .NET MAUI app that ships the same XAML to a 6-inch phone and a 32-inch monitor. "
				+ "We look at where adaptive layouts pay off, where they don't, and how to keep the breakpoints readable.",
		},
		new()
		{
			Title = "Blazor Hybrid without the hand-waving",
			Speaker = "Lewis Hamilton",
			Track = "Web", TrackColor = WebColor,
			Time = "09:30", Room = "Room B",
			Abstract = "Sharing Razor components between a web app and a native shell sounds simple until you hit navigation, "
				+ "auth and offline. A practical checklist from two production apps.",
		},
		new()
		{
			Title = "From laptop to production with Aspire",
			Speaker = "Charles Leclerc",
			Track = "Cloud", TrackColor = CloudColor,
			Time = "10:30", Room = "Room C",
			Abstract = "Start with a dashboard on your machine and end with a deployed, observable system. "
				+ "We wire up service discovery, health checks and telemetry live, then break things on purpose.",
		},
		new()
		{
			Title = "Prompting is a UI problem",
			Speaker = "Lando Norris",
			Track = "AI", TrackColor = AIColor,
			Time = "10:30", Room = "Room D",
			Abstract = "Most failed AI features fail at the input box. Patterns for guiding users toward good requests, "
				+ "showing progress honestly and recovering from a wrong answer.",
		},
		new()
		{
			Title = "Visual states that scale",
			Speaker = "Oscar Piastri",
			Track = "Mobile", TrackColor = MobileColor,
			Time = "11:30", Room = "Room A",
			Abstract = "The Visual State Manager beyond Pressed and Disabled: state triggers, TargetName setters and how to "
				+ "structure a page so that a designer can read the breakpoints straight from the XAML.",
		},
		new()
		{
			Title = "Cold starts are a product decision",
			Speaker = "George Russell",
			Track = "Cloud", TrackColor = CloudColor,
			Time = "11:30", Room = "Room C",
			Abstract = "Serverless latency is a trade-off you choose, not a bug you fix. Measuring it, explaining it to "
				+ "stakeholders and picking the cheapest option that still feels fast.",
		},
		new()
		{
			Title = "On-device models in .NET apps",
			Speaker = "Fernando Alonso",
			Track = "AI", TrackColor = AIColor,
			Time = "13:30", Room = "Room D",
			Abstract = "Running small language and vision models locally on phones and laptops: packaging, memory budgets, "
				+ "and when a round trip to the cloud is still the better call.",
		},
		new()
		{
			Title = "Accessibility audits in 30 minutes",
			Speaker = "Carlos Sainz",
			Track = "Web", TrackColor = WebColor,
			Time = "13:30", Room = "Room B",
			Abstract = "A repeatable half-hour routine with a screen reader, a keyboard and a contrast checker that catches "
				+ "most of the issues users actually report.",
		},
		new()
		{
			Title = "Offline-first sync that survives airplanes",
			Speaker = "Kimi Antonelli",
			Track = "Mobile", TrackColor = MobileColor,
			Time = "14:30", Room = "Room A",
			Abstract = "Conflict resolution, retry queues and the UI that tells users what is saved where. "
				+ "Lessons from an inspection app used in basements and on oil rigs.",
		},
		new()
		{
			Title = "Testing LLM features like regular code",
			Speaker = "Pierre Gasly",
			Track = "AI", TrackColor = AIColor,
			Time = "15:30", Room = "Room D",
			Abstract = "Evaluation sets, golden answers and regression gates for features whose output is never quite the same "
				+ "twice. How to put them in CI without slowing the team down.",
		},
	];

	// Selected at start so the detail pane isn't empty
	public static Session First => All[0];
}
