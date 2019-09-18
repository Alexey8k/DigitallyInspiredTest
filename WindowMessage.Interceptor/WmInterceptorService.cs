using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace WindowMessage.Interceptor
{
    public class WmInterceptorService : IWmInterceptorService
    {
        private readonly Dictionary<int, WmHandler> _messageHendlers = new Dictionary<int, WmHandler>();
        private readonly HwndSourceHook _hwndSourceHook;
        private HwndSource _source;

        public WmInterceptorService(Window window)
        {
            _hwndSourceHook = new HwndSourceHook(WindowProc);
            AddHook(window);
            window.Closed += window_Closed;
        }

        public void AddHandler(WmHandler wmHandler) => _messageHendlers.Add(wmHandler.Massage, wmHandler);

        private void AddHook(Window window)
            => (_source = PresentationSource.FromVisual(window) as HwndSource)?.AddHook(_hwndSourceHook);

        private void RemoveHook() => _source?.RemoveHook(_hwndSourceHook);

        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            var wmMessage = new WmMessage
            {
                Hwnd = hwnd,
                Message = msg,
                WParam = wParam,
                LParam = lParam
            };

            if (_messageHendlers.TryGetValue(msg, out WmHandler wmHandler))
                wmHandler.Handler(ref wmMessage);

            handled = wmMessage.Handled;

            return wmHandler?.ReturnValue ?? IntPtr.Zero;
        }

        private void window_Closed(object sender, EventArgs e) => RemoveHook();
    }
}
