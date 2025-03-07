using System.Globalization;
using System.Windows.Data;

namespace DefaultWPFBlueprint.Converters;

public class NullToBoolConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value != null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? new object() : null;
        }

        return null;
    }
}