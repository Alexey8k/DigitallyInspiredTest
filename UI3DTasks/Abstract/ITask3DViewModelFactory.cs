using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI3DTasks.ViewModels.Common;

namespace UI3DTasks.Abstract
{
    public interface ITask3DViewModelFactory
    {
        ITask3DViewModel CreateTask3DViewModel(string name);

        IZAxisMovementTas3DViewModel CreateZAxisMovementTas3DViewModel(string name);
    }
}
