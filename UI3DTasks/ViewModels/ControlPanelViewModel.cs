using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI3DTasks.Abstract;
using UI3DTasks.ViewModels.Common;

namespace UI3DTasks.ViewModels
{
    internal class ControlPanelViewModel : IControlPanelViewModel
    {
        private readonly ITask3DViewModel _task3DViewModel;
        private readonly IModelImporter _modelImporter;

        public ControlPanelViewModel(ITask3DViewModel task3DViewModel, IModelImporter modelImporter)
        {
            _task3DViewModel = task3DViewModel;
            _modelImporter = modelImporter;
        }

        public ICommand LoadCommand => new ActionCommand(() =>
        {
            var openFileDialog = new OpenFileDialog { DefaultExt = ".obj", Filter = "3D Model|*.obj" };
            if (openFileDialog.ShowDialog() ?? false)
            {
                if (_task3DViewModel.Model3D != null) _task3DViewModel.Model3D = null;
                _task3DViewModel.Model3D = _modelImporter.Load(openFileDialog.FileName);
            }
        });

        public ICommand ClearCommand => new ActionCommand(() =>
        {
            _task3DViewModel.Model3D = null;
        });
    }
}
