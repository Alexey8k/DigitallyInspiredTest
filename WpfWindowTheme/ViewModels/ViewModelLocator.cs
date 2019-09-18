using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWindowTheme.Infrastructure;

namespace WpfWindowTheme.ViewModels
{
    internal static class ViewModelLocator
    {
        public static WindowStyleViewModel WindowStyleViewModel => _kernel.Get<WindowStyleViewModel>();

        private static readonly IKernel _kernel = new StandardKernel();

        static ViewModelLocator()
        {
            _kernel.Load(new WpfWindowThemeModule());
        }
    }
}
