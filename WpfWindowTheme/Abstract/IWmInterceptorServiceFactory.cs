using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowMessage.Interceptor;

namespace WpfWindowTheme.Abstract
{
    public interface IWmInterceptorServiceFactory
    {
        IWmInterceptorService Create(Window window);
    }
}
