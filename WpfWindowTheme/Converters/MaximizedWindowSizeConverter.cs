using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WpfWindowTheme.Converters
{
    internal class MaximizedWindowSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => new Thickness(
                SystemParameters.WorkArea.Left + SystemParameters.WindowResizeBorderThickness.Left - 1,
                SystemParameters.WorkArea.Top + SystemParameters.WindowResizeBorderThickness.Top - 1,
                (SystemParameters.PrimaryScreenWidth - SystemParameters.WorkArea.Right) + SystemParameters.WindowResizeBorderThickness.Right - 1,
                (SystemParameters.PrimaryScreenHeight - SystemParameters.WorkArea.Bottom) + SystemParameters.WindowResizeBorderThickness.Bottom - 1);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
