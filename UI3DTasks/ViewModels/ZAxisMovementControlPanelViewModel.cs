using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI3DTasks.ViewModels.Common;

namespace UI3DTasks.ViewModels
{
    class ZAxisMovementControlPanelViewModel : IZAxisMovementControlPanelViewModel
    {
        public double ZMin { get; set; }
        public double ZMax { get; set; }
    }
}
