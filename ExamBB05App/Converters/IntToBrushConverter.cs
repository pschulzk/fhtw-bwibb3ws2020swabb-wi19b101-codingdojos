using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace ExamBB05App.Converters
{
    class IntToBrushConverter : IValueConverter
    {
        readonly Brush yellow = new SolidColorBrush(Colors.Yellow);
        readonly Brush green = new SolidColorBrush(Colors.Green);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int) value > 1)
            {
                return green;
            }
            else {
                return yellow;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
