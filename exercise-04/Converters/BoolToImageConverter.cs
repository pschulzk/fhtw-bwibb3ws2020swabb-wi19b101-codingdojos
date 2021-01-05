using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace exercise_04.Converters
{
    class BoolToImageConverter : IValueConverter
    {
        private readonly BitmapImage meatImage = new BitmapImage(new Uri(@".\Images\fleisch.png", UriKind.Relative));
        private readonly BitmapImage veganImage = new BitmapImage(new Uri(@".\Images\vegan.png", UriKind.Relative));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool temp = (bool) value;
            if (temp) return meatImage;
            else return veganImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool temp = (bool) value;
            if (temp) return veganImage;
            else return meatImage;
        }
    }
}
