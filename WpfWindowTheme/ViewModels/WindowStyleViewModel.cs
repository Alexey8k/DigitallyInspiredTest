using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfWindowTheme.Models;

namespace WpfWindowTheme.ViewModels
{
    internal class WindowStyleViewModel
    {
        public WindowCaption WindowCaption { get; private set; } = new WindowCaption
        {
            Height = 32,
            Background = Brushes.RoyalBlue,
            Foreground = Brushes.Black
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
