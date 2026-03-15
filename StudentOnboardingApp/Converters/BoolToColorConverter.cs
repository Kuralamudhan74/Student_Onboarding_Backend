using System.Globalization;

namespace StudentOnboardingApp.Converters;

public class BoolToColorConverter : IValueConverter
{
<<<<<<< HEAD
    public Color? TrueColor { get; set; }
    public Color? FalseColor { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool b)
            return b ? TrueColor : FalseColor;
        return FalseColor;
=======
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool b && b)
        {
            return parameter is string colorKey
                ? Application.Current?.Resources.TryGetValue(colorKey, out var color) == true ? color : Colors.Green
                : Colors.Green;
        }
        return Colors.Gray;
>>>>>>> b21a7ff56f4c42af96a63212093eb3710ea26fd8
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
