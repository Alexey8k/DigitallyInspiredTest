using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowMessage.Interceptor;

namespace WpfWindowTheme.WmHandlers
{
    internal class WmGetMinMaxInfoHandler : BasePositionHandler
    {
        private const int WM_GETMINMAXINFO = 0x0024;

        public override int Massage => WM_GETMINMAXINFO;

        public override void Handler(ref WmMessage wmMessage)
        {
            var mmi = Marshal.PtrToStructure<MINMAXINFO>(wmMessage.LParam);
            var maxPosition = MaxWindowPosition(wmMessage.Hwnd);

            mmi.ptMaxPosition.X = maxPosition.X;
            mmi.ptMaxPosition.Y = maxPosition.Y;
            mmi.ptMaxSize.X = maxPosition.Width;
            mmi.ptMaxSize.Y = maxPosition.Height;

            Marshal.StructureToPtr(mmi, wmMessage.LParam, true);

            wmMessage.Handled = true;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
                => new System.Drawing.Point(p.X, p.Y);

            public static implicit operator POINT(System.Drawing.Point p)
                => new POINT(p.X, p.Y);
        }
    }
}
