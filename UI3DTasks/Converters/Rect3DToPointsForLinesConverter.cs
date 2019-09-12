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
    internal class Rect3DToPointsForLinesConverter : IValueConverter
    {
        public double LineLength { get; set; } = 3;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var rect3d = (Rect3D)value;
            var lineLength = (rect3d.SizeX + rect3d.SizeY + rect3d.SizeZ) / 3 / 2;
            var pointX = Point3D.Add(rect3d.Location, new Vector3D(rect3d.SizeX, 0, 0));
            var pointY = Point3D.Add(rect3d.Location, new Vector3D(0, rect3d.SizeY, 0));
            var pointZ = Point3D.Add(rect3d.Location, new Vector3D(0, 0, rect3d.SizeZ));

            var pointXZ = new Point3D((pointX.X + pointZ.X) / 2, (pointX.Y + pointZ.Y) / 2, (pointX.Z + pointZ.Z) / 2);
            var pointXY = new Point3D((pointX.X + pointY.X) / 2, (pointX.Y + pointY.Y) / 2, (pointX.Z + pointY.Z) / 2);
            var pointZY = new Point3D((pointZ.X + pointY.X) / 2, (pointZ.Y + pointY.Y) / 2, (pointZ.Z + pointY.Z) / 2);

            return new Point3DCollection(new[] {
                pointXZ,
                Point3D.Subtract(pointXZ, new Vector3D(0, lineLength, 0)),
                pointXY,
                Point3D.Subtract(pointXY, new Vector3D(0, 0, lineLength)),
                pointZY,
                Point3D.Subtract(pointZY, new Vector3D(lineLength, 0, 0)),
                Point3D.Add(pointXZ, new Vector3D(0, rect3d.SizeY, 0)),
                Point3D.Add(pointXZ, new Vector3D(0, rect3d.SizeY + lineLength, 0)),
                Point3D.Add(pointXY, new Vector3D(0, 0, rect3d.SizeZ)),
                Point3D.Add(pointXY, new Vector3D(0, 0, rect3d.SizeZ + lineLength)),
                Point3D.Add(pointZY, new Vector3D(rect3d.SizeX, 0, 0)),
                Point3D.Add(pointZY, new Vector3D(rect3d.SizeX + lineLength, 0, 0))
            });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
