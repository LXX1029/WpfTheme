using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfThemes.UserControls
{
    /// <summary>
    /// ToolBarMinMaxClose.xaml 的交互逻辑
    /// </summary>
    public partial class ToolBarMinMaxClose : UserControl
    {
        public ToolBarMinMaxClose()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += ToolBarMinMaxClose_Loaded;
        }
        /// <summary>
        /// 拥有该控件的窗口
        /// </summary>
        private Window MainWindow { get; set; }

        public Visibility SetSkinVisibility
        {
            get { return (Visibility)GetValue(SetSkinVisibilityProperty); }
            set { SetValue(SetSkinVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetSkinVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetSkinVisibilityProperty =
            DependencyProperty.Register("SetSkinVisibility", typeof(Visibility), typeof(ToolBarMinMaxClose));


        private void ToolBarMinMaxClose_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow == null)
            {
                MainWindow = VisualHelper.GetParentObject<Window>(this);
                if (MainWindow != null)
                    MainWindow.StateChanged += (m, n) =>
                    {
                        tbtnMax.IsChecked = MainWindow.WindowState == WindowState.Normal
                        ? true : false;
                    };
            }
        }
        /// <summary>
        /// 最大化/还原/关闭
        /// </summary>
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button btn))
            {
                if (!(sender is ToggleButton tbtn))
                    return;
                if (tbtn.IsChecked == true)
                    MainWindow.WindowState = WindowState.Normal;
                else
                    MainWindow.WindowState = WindowState.Maximized;
                return;
            }

            string tag = btn.Tag.ToString();
            if (tag == "1")
            {
                MainWindow.WindowState = WindowState.Minimized;
            }
            else
            {
                if (Msg.ShowConfirmOkCancel("确定关闭窗口?", MainWindow))
                {
                    MainWindow.Close();
                    Application.Current.Shutdown();
                }
                string[] sArraySeparate;
                sArraySeparate = new[] { "", "", "", "" };
            }
        }
    }
}
