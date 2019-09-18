using Ninject.Extensions.Factory;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowMessage.Interceptor;
using WpfWindowTheme.Abstract;

namespace WpfWindowTheme.Infrastructure
{
    internal class WpfWindowThemeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWmInterceptorService>().To<WmInterceptorService>();
            Bind<IWmInterceptorServiceFactory>().ToFactory();
        }
    }
}
