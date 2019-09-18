using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowMessage.Interceptor
{
    public interface IWmInterceptorService
    {
        void AddHandler(WmHandler wmHandler);
    }
}
