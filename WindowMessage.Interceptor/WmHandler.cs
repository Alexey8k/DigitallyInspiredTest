using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowMessage.Interceptor
{
    public abstract class WmHandler
    {
        public IntPtr ReturnValue { get; protected set; } = IntPtr.Zero;

        public abstract int Massage { get; }

        public abstract void Handler(ref WmMessage wmMessage);
    }
}
