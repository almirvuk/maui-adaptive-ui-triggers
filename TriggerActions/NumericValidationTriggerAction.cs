namespace TriggersShowcase.TriggerActions;

// Runs on every TextChanged. Event triggers are one-way: nothing is undone for you.
public class NumericValidationTriggerAction : TriggerAction<Entry>
{
    protected override void Invoke(Entry entry)
    {
        bool isValid = string.IsNullOrEmpty(entry.Text) || double.TryParse(entry.Text, out _);
        entry.TextColor = isValid ? Colors.Black : Colors.Red;
    }
}
