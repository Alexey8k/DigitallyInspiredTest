using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace UI3DTasks.Abstract
{
    interface IModelImporter
    {
        Model3DGroup Load(string filePath);
    }
}
