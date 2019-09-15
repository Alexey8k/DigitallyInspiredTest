using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfWindowTheme.WmHandlers
{
    internal class WmWindowPosChangedHandler : BasePositionHandler
    {
        private const int WM_WINDOWPOSCHANGED = 0x0047;
        private const int SW_MAXIMIZE = 3;

        public override int Massage => WM_WINDOWPOSCHANGED;

        public override void Handler(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            var windowPlacement = new WINDOWPLACEMENT { length = Marshal.SizeOf<WINDOWPLACEMENT>() };
            var IsMaximizeWindowState = GetWindowPlacement(hwnd, ref windowPlacement);

            if (windowPlacement.showCmd != SW_MAXIMIZE) return;

            var wp = Marshal.PtrToStructure<WINDOWPOS>(lParam);
            var maxPosition = MaxWindowPosition(hwnd);

            wp.x = maxPosition.X;
            wp.y = maxPosition.Y;
            wp.cx = maxPosition.Width;
            wp.cy = maxPosition.Height;

            SetWindowPos(wp.hwnd, wp.hwndInsertAfter, wp.x, wp.y, wp.cx, wp.cy, wp.flags);

            handled = false;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }

        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }
    }
}
