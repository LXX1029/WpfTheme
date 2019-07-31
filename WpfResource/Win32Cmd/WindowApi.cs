using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WpfThemes.Win32Cmd
{
    public class WindowApi
    {

        private readonly static WindowApi windowApi = new WindowApi();


        public static WindowApi GetInstance()
        {
            return windowApi;
        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);



        #region 获取Window窗体位置
        /// <summary>
        /// 获取Window窗体位置
        /// </summary>
        /// <param name="windowTitle">窗体Title名称</param>
        /// <returns>RECT</returns>
        public RECT GetWindowLocation(string windowTitle)
        {
            IntPtr hwnd = (IntPtr)FindWindow(null, windowTitle);
            RECT rect = new RECT();
            GetWindowRect(hwnd, ref rect);
            return rect;
        }
        #endregion

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;                             //最左坐标
        public int Top;                             //最上坐标
        public int Right;                           //最右坐标
        public int Bottom;                        //最下坐标
    }
}
