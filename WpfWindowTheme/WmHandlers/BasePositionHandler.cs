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
    internal abstract class BasePositionHandler : WmHandler
    {
        private const int MONITOR_DEFAULTTONEAREST = 0x00000002;

        protected (int X, int Y, int Width, int Height) MaxWindowPosition(IntPtr hwnd)
        {
            IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor == IntPtr.Zero) return (0, 0, 0, 0);

            MONITORINFO monitorInfo = new MONITORINFO();
            GetMonitorInfo(monitor, monitorInfo);

            RECT rcWorkArea = monitorInfo.rcWork;
            RECT rcMonitorArea = monitorInfo.rcMonitor;

            Thickness t = SystemParameters.WindowResizeBorderThickness;

            return (
                Math.Abs(rcWorkArea.Left - rcMonitorArea.Left) - (int)t.Left,
                Math.Abs(rcWorkArea.Top - rcMonitorArea.Top) - (int)t.Top,
                Math.Abs(rcWorkArea.Right - rcWorkArea.Left) + ((int)t.Right) * 2,
                Math.Abs(rcWorkArea.Bottom - rcWorkArea.Top) + ((int)t.Bottom) * 2);
        }

        [DllImport("user32.dll")]
        protected static extern IntPtr DefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("user32")]
        private static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        [StructLayout(LayoutKind.Sequential)]
        private class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf<MONITORINFO>();

            public RECT rcMonitor = new RECT();

            public RECT rcWork = new RECT();

            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public RECT(System.Drawing.Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom) { }

            public int X
            {
                get => Left;
                set
                {
                    Right -= (Left - value);
                    Left = value;
                }
            }

            public int Y
            {
                get => Top;
                set
                {
                    Bottom -= (Top - value);
                    Top = value;
                }
            }

            public int Height
            {
                get => Bottom - Top;
                set => Bottom = value + Top;
            }

            public int Width
            {
                get => Right - Left; 
                set => Right = value + Left;
            }

            public System.Drawing.Point Location
            {
                get => new System.Drawing.Point(Left, Top);
                set
                {
                    X = value.X;
                    Y = value.Y;
                }
            }

            public System.Drawing.Size Size
            {
                get => new System.Drawing.Size(Width, Height);
                set
                {
                    Width = value.Width;
                    Height = value.Height;
                }
            }

            public static implicit operator System.Drawing.Rectangle(RECT r)
                => new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);

            public static implicit operator RECT(System.Drawing.Rectangle r) => new RECT(r);

            public static bool operator ==(RECT r1, RECT r2) => r1.Equals(r2);

            public static bool operator !=(RECT r1, RECT r2) => !r1.Equals(r2);

            public bool Equals(RECT r) => r.Left == Left && r.Top == Top && r.Right == Right && r.Bottom == Bottom;

            public override bool Equals(object obj)
            {
                if (obj is RECT)
                    return Equals((RECT)obj);
                else if (obj is System.Drawing.Rectangle)
                    return Equals(new RECT((System.Drawing.Rectangle)obj));
                return false;
            }

            public override int GetHashCode() => ((System.Drawing.Rectangle)this).GetHashCode();

            public override string ToString() 
                => string.Format(System.Globalization.CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
        }
    }
}
