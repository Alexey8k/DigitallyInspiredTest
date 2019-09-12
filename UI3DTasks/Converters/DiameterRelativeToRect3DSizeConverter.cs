using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Media3D;

namespace UI3DTasks.Converters
{
    internal class DiameterRelativeToRect3DSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => MaxLengthRect3D((Rect3D)value) / 1000 + 0.01;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private double MaxLengthRect3D(Rect3D rect3D)
            => rect3D.SizeX > rect3D.SizeY
            ? (rect3D.SizeX > rect3D.SizeZ ? rect3D.SizeX : rect3D.SizeZ)
            : (rect3D.SizeY > rect3D.SizeZ ? rect3D.SizeY : rect3D.SizeZ);
    }
}
