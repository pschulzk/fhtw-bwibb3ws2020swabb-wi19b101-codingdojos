using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ExerciseSimpleMultiVM.Converters
{
    class ImageToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // System.Diagnostics.Debug.WriteLine("ImageToStringConverter -> Convert.value: " + value.ToString());
            if (value is BitmapImage img) return img.UriSource.AbsoluteUri;
            else return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Diagnostics.Debug.WriteLine("ImageToStringConverter -> ConvertBack.value: " + value.ToString());
            string uri = value.ToString();
            try
            {
                return new BitmapImage(new Uri(uri));
            }
            catch
            {
                return new object();
            }
        }
    }
}
