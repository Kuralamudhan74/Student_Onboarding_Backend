using System.Globalization;

namespace StudentOnboardingApp.Converters;

public class BoolToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool b && b)
        {
            return parameter is string colorKey
                ? Application.Current?.Resources.TryGetValue(colorKey, out var color) == true ? color : Colors.Green
                : Colors.Green;
        }
        return Colors.Gray;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
