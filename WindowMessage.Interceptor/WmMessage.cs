using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowMessage.Interceptor
{
    public struct WmMessage
    {
        public static implicit operator WmMessage((IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam) value)
            => new WmMessage
            {
                Hwnd = value.hwnd,
                Message = value.message,
                WParam = value.wParam,
                LParam = value.lParam,
            };
        public IntPtr Hwnd { get; set; }
        public int Message { get; set; }
        public IntPtr WParam { get; set; }
        public IntPtr LParam { get; set; }
        public bool Handled { get; set; }
    }
}
