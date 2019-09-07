using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace UI3DTasks.ViewModels.Common
{
    public interface ITask3DViewModel
    {
        string Name { get; }

        Model3DGroup Model3D { get; set; }

        IControlPanelViewModel ControlPanelViewModel { get; }
    }
}
