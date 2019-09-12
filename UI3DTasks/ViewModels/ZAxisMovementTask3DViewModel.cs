using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI3DTasks.Abstract;
using UI3DTasks.ViewModels.Common;

namespace UI3DTasks.ViewModels
{
    internal class ZAxisMovementTask3DViewModel : Task3DViewModel, IZAxisMovementTask3DViewModel
    {
        public ZAxisMovementTask3DViewModel(
            string name,
            IControlPanelViewModelFactory ControlPanelViewModelFactory,
            IZAxisMovementControlPanelViewModel zAxisMovementControlPanelViewModel)
            : base(name, ControlPanelViewModelFactory)
            => ZAxisMovementControlPanelViewModel = zAxisMovementControlPanelViewModel;

        
        public IZAxisMovementControlPanelViewModel ZAxisMovementControlPanelViewModel { get; }
    }
}
