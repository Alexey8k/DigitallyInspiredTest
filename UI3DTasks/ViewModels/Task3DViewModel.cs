using HelixToolkit.Wpf;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using UI3DTasks.Abstract;
using UI3DTasks.ViewModels.Common;

namespace UI3DTasks.ViewModels
{
    internal class Task3DViewModel : BaseViewModel, ITask3DViewModel
    {
        public Task3DViewModel(string name, IControlPanelViewModelFactory factoryControlPanelViewModel)
        {
            Name = name;
            ControlPanelViewModel = factoryControlPanelViewModel.Create(this);
        }

        public string Name { get; private set; }

        private Model3DGroup _model3D;
        public Model3DGroup Model3D
        {
            get => _model3D;
            set
            {
                _model3D = value;
                OnPropertyChanged();
            }
        }

        public IControlPanelViewModel ControlPanelViewModel { get; private set; }
    }
}
