using Ninject.Extensions.Factory;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI3DTasks.Abstract;
using UI3DTasks.Concret;
using UI3DTasks.ViewModels;
using UI3DTasks.ViewModels.Common;

namespace UI3DTasks.Infrastructure
{
    public class UITask3DModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IModelImporter>().To<ModelImporter>();

            Bind<IControlPanelViewModel>().To<ControlPanelViewModel>();
            Bind<IControlPanelViewModelFactory>().ToFactory();
            Bind<IZAxisMovementControlPanelViewModel>().To<ZAxisMovementControlPanelViewModel>();

            Bind<ITask3DViewModel>().To<Task3DViewModel>();
            Bind<IZAxisMovementTask3DViewModel>().To<ZAxisMovementTask3DViewModel>();
            Bind<ITask3DViewModelFactory>().ToFactory();
        }
    }
}
