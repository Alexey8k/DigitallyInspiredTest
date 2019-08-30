using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace WpfWindowTheme.Services
{
    internal class WmInterceptorService
    {
        private readonly Dictionary<int, WmHandler> _messageHendlers = new Dictionary<int, WmHandler>();
        private readonly HwndSource _source;
        private readonly HwndSourceHook _hwndSourceHook;

        public WmInterceptorService(Window window)
        {
            _source = PresentationSource.FromVisual(window) as HwndSource;
            _hwndSourceHook = new HwndSourceHook(WindowProc);
            AddHook();
            window.Closed += window_Closed;
        }

        public void AddHandler(WmHandler wmHandler) => _messageHendlers.Add(wmHandler.Massage, wmHandler);

        private void AddHook() => _source?.AddHook(WindowProc);

        private void RemoveHook() => _source?.RemoveHook(_hwndSourceHook);

        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (_messageHendlers.TryGetValue(msg, out WmHandler wmHandler))
                wmHandler.Handler(hwnd, msg, wParam, lParam, ref handled);

            return IntPtr.Zero;
        }

        private void window_Closed(object sender, EventArgs e) => RemoveHook();
    }
}
