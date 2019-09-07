using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UI3DTasks.ViewModels
{
    internal class ViewModelLocator
    {
        public UITask3DViewModel UITask3DViewModel => _kernel.Get<UITask3DViewModel>();

        private static readonly IKernel _kernel = new StandardKernel();

        static ViewModelLocator()
        {
            _kernel.Load(Assembly.GetExecutingAssembly());
        }
    }
}
