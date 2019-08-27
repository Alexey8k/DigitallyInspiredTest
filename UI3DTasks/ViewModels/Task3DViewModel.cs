using HelixToolkit.Wpf;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace UI3DTasks.ViewModels
{
    internal class Task3DViewModel
    {
        public Model3DGroup Model3D { get; private set; }

        public ICommand LoadCommand => new ActionCommand(() =>
        {
            var openFileDialog = new OpenFileDialog { DefaultExt = ".obj", Filter = "3D Model|*.obj" };
            if (openFileDialog.ShowDialog() ?? false)
            {
                if (Model3D != null) Model3D = null;
                Model3D = new ModelImporter().Load(openFileDialog.FileName);
            }
        });

        public ICommand ClearCommand => new ActionCommand(() =>
        {
            Model3D = null;
        });
    }
}
