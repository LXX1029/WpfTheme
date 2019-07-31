using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfThemes.OfficeThemeStyles
{
    public partial class WindowUserControl
    {
        /// <summary>
        /// 鼠标相对于屏幕的位置
        /// </summary>
        private POINT _clickPoint;

        #region 鼠标按下
        private void titleGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FrameworkElement fe = (FrameworkElement)sender;
            Window win = (Window)(fe).TemplatedParent;
            if (e.ClickCount == 1)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    _clickPoint = new POINT();
                    GetCursorPos(out _clickPoint);
                    // Debug.WriteLine($"MouseClick1---X-{_clickPoint.X} Y-{_clickPoint.Y}");
                    win.DragMove();
                }
            }
            // 双击改变窗口状态
            if (e.ClickCount == 2 && win != null)
            {
                win.WindowState = win.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            }
            fe.ReleaseMouseCapture();

        }
        #endregion

        private void titleGrid_MouseMove(object sender, MouseEventArgs e)
        {
            FrameworkElement fe = (FrameworkElement)sender;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (fe == null) return;
                Window win = (Window)(fe).TemplatedParent;
                if (win == null) return;
                POINT movePoint = new POINT();
                GetCursorPos(out movePoint);
                //Debug.WriteLine($"MouseMove---X-{movePoint.X} Y-{movePoint.Y}");
                if (movePoint.X != _clickPoint.X || movePoint.Y != _clickPoint.Y)
                {
                    if (win.WindowState != WindowState.Normal)
                    {
                        win.WindowState = WindowState.Normal;
                        win.Top = movePoint.Y - fe.ActualHeight / 2;
                        win.Left = movePoint.X - fe.ActualWidth / 2; // 按下鼠标左键拖动时，鼠标在窗口中间位置
                        MouseButtonEventArgs args = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left);
                        titleGrid_MouseLeftButtonDown(sender, args);
                    }
                }
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);
    }

}
