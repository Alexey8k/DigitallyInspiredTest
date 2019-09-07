using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI3DTasks.ViewModels.Common
{
    public interface IZAxisMovementControlPanelViewModel
    {
        double ZMin { get; set; }

        double ZMax { get; set; }
    }
}
