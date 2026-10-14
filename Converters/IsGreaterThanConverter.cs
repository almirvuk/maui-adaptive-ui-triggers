using System.Globalization;

namespace TriggersShowcase.Converters;

// value > ConverterParameter  →  true
public class IsGreaterThanConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        double number = value switch
        {
            double d => d,
            int i => i,
            _ => double.NaN
        };

        double limit = double.Parse(parameter?.ToString() ?? "0", CultureInfo.InvariantCulture);
        return number > limit;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
