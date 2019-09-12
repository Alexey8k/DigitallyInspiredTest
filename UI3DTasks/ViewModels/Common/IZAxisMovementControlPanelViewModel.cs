using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI3DTasks.ViewModels.Common
{
    public interface IZAxisMovementControlPanelViewModel
    {
        double ZMin { get; set; }

        double ZMax { get; set; }

        bool IsMoveModel3D { get; set; }
    }
}
