using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfThemes.Win32Cmd;

namespace WpfThemes.BusyIndicator
{
    /// <summary>
    /// Waiting.xaml 的交互逻辑
    /// </summary>
     partial class Waiting : Window
    {

        /// <summary>
        /// 显示位置顶部值
        /// </summary>
        private double top { get; set; } = 0;
        /// <summary>
        /// 显示位置左侧值
        /// </summary>
        private double left { get; set; } = 0;
        /// <summary>
        /// 默认函数
        /// </summary>
        /// <param name="parentWindow">父窗口</param>
        /// <param name="message">显示的内容</param>
        public Waiting(Window parentWindow, string message)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            if (parentWindow == null)
                parentWindow = Application.Current.MainWindow;
            this.Owner = parentWindow;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //this.ProgressBar1.Content = message;
            this.Width = parentWindow.ActualWidth;
            this.Height = parentWindow.ActualHeight;

            //top = parentWindow.Top;
            //left = parentWindow.Left;
            RECT rect= WindowApi.GetInstance().GetWindowLocation(parentWindow.Title);
            top = rect.Top;
            left = rect.Left;

            this.Loaded += Waiting_Loaded;
        }

        private void Waiting_Loaded(object sender, RoutedEventArgs e)
        {
           


            this.Top = top;
            this.Left = left;
        }

        /// <summary>
        /// 设置提示文字
        /// </summary>
        /// <param name="message">提示信息</param>
        public void SetMessage(string message)
        {
            this.ProgressBar1.Content = message;
        }
        private SolidColorBrush ConvertColorStringToBrush(string colorStr)
        {
            System.Windows.Media.Color customColor = (System.Windows.Media.Color)ColorConverter.ConvertFromString(colorStr);
            return new SolidColorBrush(customColor);
        }
    }
}
