namespace TriggersShowcase.Models;

// A session on the agenda page
public class Session
{
	public required string Title { get; init; }
	public required string Speaker { get; init; }
	public required string Track { get; init; }
	public required string Time { get; init; }
	public required string Room { get; init; }
	public required string Abstract { get; init; }
	public required Color TrackColor { get; init; }

	// Speaker avatar initials
	public string SpeakerInitials => string.Concat(Speaker.Split(' ').Select(part => part[0]));
}
