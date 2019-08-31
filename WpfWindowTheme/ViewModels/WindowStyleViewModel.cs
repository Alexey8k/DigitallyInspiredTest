using Microsoft.Expression.Interactivity.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfWindowTheme.Models;
using WpfWindowTheme.Services;
using WpfWindowTheme.ViewModels.Common;
using WpfWindowTheme.WmHandlers;

namespace WpfWindowTheme.ViewModels
{
    internal class WindowStyleViewModel : BaseViewModel
    {
        private WmInterceptorService _wmInterceptorService;

        public WindowCaption WindowCaption { get; private set; } = new WindowCaption
        {
            Height = 32,
            Background = Brushes.RoyalBlue,
            Foreground = Brushes.LightCyan
        };

        public ICommand CloseWindowCommand => new ActionCommand(
            sender => InvokeIfIsWindow(sender, window => SystemCommands.CloseWindow(window)));

        public ICommand MinimizeWindowCommand => new ActionCommand(
            sender => InvokeIfIsWindow(sender, window => SystemCommands.MinimizeWindow(window)));

        public ICommand MaximizeWindowCommand => new ActionCommand(
            sender => InvokeIfIsWindow(sender, window => SystemCommands.MaximizeWindow(window)));

        public ICommand RestoreWindowCommand => new ActionCommand(
            sender => InvokeIfIsWindow(sender, window => SystemCommands.RestoreWindow(window)));

        public ICommand MouseLeftButtonDownOnIconCommand => new ActionCommand(
            sender => InvokeIfIsWindow(sender, window => ShowSystemMenu(window)));

        public ICommand MouseRightButtonUpOnIconCommand => new ActionCommand(
            sender => InvokeIfIsWindow(sender, window => ShowSystemMenu(window, false)));

        public ICommand WindowCaptionLoadedCommand => new ActionCommand(
            sender => InvokeIfIsWindow(sender, window => InitWmInterceptorService(window)));

        private void InitWmInterceptorService(Window window)
        {
            _wmInterceptorService = new WmInterceptorService(window);
            _wmInterceptorService.AddHandler(new WmWindowPosChangedHandler());
            _wmInterceptorService.AddHandler(new WmGetMinMaxInfoHandler());
        }

        private void ShowSystemMenu(Window window, bool isLeftButtonClick = true)
            => SystemCommands.ShowSystemMenu(window,
                window.PointToScreen(isLeftButtonClick
                    ? new Point(SystemParameters.WindowResizeBorderThickness.Left, WindowCaption.Height + SystemParameters.WindowResizeBorderThickness.Top)
                    : Mouse.GetPosition(window)));

        private void InvokeIfIsWindow(object sender, Action<Window> action)
        {
            if (sender is Window window) action(window);
        }
    }
}
