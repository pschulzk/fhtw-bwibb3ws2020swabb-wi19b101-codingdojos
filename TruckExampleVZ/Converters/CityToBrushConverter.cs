using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TruckExampleVZ.Converters
{
    class CityToBrushConverter : IValueConverter
    {
        readonly Brush green = new SolidColorBrush(Colors.Green);
        readonly Brush yellow = new SolidColorBrush(Colors.Yellow);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string city = value.ToString();
            switch (city)
            {
                case "Salzburg":
                    return green;
                case "Graz":
                    return yellow;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
