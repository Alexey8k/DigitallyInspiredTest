using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfWindowTheme.Services
{
    internal abstract class WmHandler
    {
        public abstract int Massage { get;}

        public abstract void Handler(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled);
    }
}
