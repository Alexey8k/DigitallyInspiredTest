using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using UI3DTasks.Abstract;

namespace UI3DTasks.Concret
{
    class ModelImporter : IModelImporter
    {
        public Model3DGroup Load(string filePath) => new HelixToolkit.Wpf.ModelImporter().Load(filePath);
    }
}
