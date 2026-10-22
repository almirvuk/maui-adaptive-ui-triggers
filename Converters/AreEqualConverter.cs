using System.Globalization;

namespace TriggersShowcase.Converters;

// True when both values are the same object
public class AreEqualConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
        => values.Length == 2 && Equals(values[0], values[1]);

    public object[] ConvertBack(object value, Type[] targetTypes, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
