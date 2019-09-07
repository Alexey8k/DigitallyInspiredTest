using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UI3DTasks.Abstract;
using UI3DTasks.ViewModels.Common;

namespace UI3DTasks.ViewModels
{
    class UITask3DViewModel
    {
        public UITask3DViewModel(ITask3DViewModelFactory factoryTask3DViewModel)
        {
            Tasks = new List<ITask3DViewModel>
            {
                factoryTask3DViewModel.CreateTask3DViewModel("Task 3"),
                factoryTask3DViewModel.CreateTask3DViewModel("Task 4"),
                (ITask3DViewModel)factoryTask3DViewModel.CreateZAxisMovementTas3DViewModel("Task 5")
            };
        }

        public List<ITask3DViewModel> Tasks { get; private set; }
    }
}
