using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace WpfThemes.MsgBox
{
    /// <summary>
    /// MessageBoxDeleteForm.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxInfoForm : Window
    {

        /// <summary>
        /// 拥有窗体Location
        /// </summary>
        private double ownerLeft;
        private double ownerTop;

        private MessageBoxInfoForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        /// <param name="owner">拥有弹出窗体的窗体</param>
        /// <param name="caption">标题</param>
        /// <param name="message">提示信息</param>
        /// <param name="isShowCancel">是否显示“取消”按钮</param>
        public MessageBoxInfoForm(ContentControl contentControl, string caption, string message, bool isShowCancel = false, LoadedType loadType = LoadedType.LoadedScale)
           : this()
        {
            InforLabel.Text = message;
            groupbox.Header = caption;
            Window owner = null;
            if (contentControl is Window)
                owner = Application.Current.MainWindow;
            if (contentControl is UserControl)
                owner = VisualHelper.GetParentObject<Window>(contentControl);
            this.Owner = owner;
            this.Width = owner.ActualWidth;
            this.Height = owner.ActualHeight;
            this.ShowInTaskbar = false;
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            // 转换owner的坐标为屏幕坐标
            var location = new Point(owner.Left, owner.Top);// owner.PointToScreen(new Point(0, 0));
            double captionHeight = SystemParameters.WindowCaptionHeight;
            // 有边框计算top,left
            if (owner.WindowStyle != WindowStyle.None)
            {
                ownerLeft = location.X - 8;
                ownerTop = location.Y - captionHeight - 8;
            }
            // 无边框计算top/left,不允许透明
            if (owner.WindowStyle == WindowStyle.None && owner.AllowsTransparency == false)
            {
                ownerLeft = location.X - 8;
                ownerTop = location.Y - 8;
            }
            // 无边框计算top/left,允许透明
            if (owner.WindowStyle == WindowStyle.None && owner.AllowsTransparency == true)
            {
                ownerLeft = location.X;
                ownerTop = location.Y;
            }

            this.CancelButton.Visibility = isShowCancel ? Visibility.Visible : Visibility.Collapsed;

            this.Loaded += new RoutedEventHandler((m, n) =>
            {

                // 设置中间border的大小
                double width = (this.ActualWidth - border.ActualWidth) / 2;
                border.SetValue(Canvas.LeftProperty, width);
                double height = (this.ActualHeight - border.ActualHeight) / 2;
                border.SetValue(Canvas.TopProperty, height);
                // 设置窗体的Location
                this.Top = ownerTop;
                this.Left = ownerLeft;

                if (loadType == LoadedType.LoadedStretch)
                {
                    Storyboard sbLoadedStretch = this.FindResource("sbLoadedStretch") as Storyboard;
                    if (sbLoadedStretch != null)
                    {
                        sbLoadedStretch.Completed -= new EventHandler(sbLoadedStretchComplated);
                        sbLoadedStretch.Completed += new EventHandler(sbLoadedStretchComplated);
                        sbLoadedStretch.Begin();
                    }
                }
                if (loadType == LoadedType.LoadedScale)
                {
                    Storyboard sbLoadedScale = this.FindResource("sbLoadedScale") as Storyboard;
                    if (sbLoadedScale != null)
                    {
                        sbLoadedScale.Completed -= new EventHandler(sbLoadedStretchComplated);
                        sbLoadedScale.Completed += new EventHandler(sbLoadedStretchComplated);
                        sbLoadedScale.Begin();
                    }
                }

            });
            this.Closed += MessageBoxInfoForm_Closed;
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        private void MessageBoxInfoForm_Closed(object sender, EventArgs e)
        {
            rect.BeginAnimation(OpacityProperty, null);
        }

        /// <summary>
        /// 动画事件
        /// </summary>
        void sbLoadedStretchComplated(object sender, EventArgs e)
        {
            border.BeginAnimation(WidthProperty, null); // 释放动画
            border.BeginAnimation(HeightProperty, null);
            border.BeginAnimation(ScaleTransform.ScaleXProperty, null);
            border.BeginAnimation(ScaleTransform.ScaleYProperty, null);

        }


        /// <summary>
        /// 窗体加载
        /// </summary>
        void window_Loaded(object sender, RoutedEventArgs e)
        {
            // 设置中间border的大小
            double width = (this.ActualWidth - border.ActualWidth) / 2;
            border.SetValue(Canvas.LeftProperty, width);
            double height = (this.ActualHeight - border.ActualHeight) / 2;
            border.SetValue(Canvas.TopProperty, height);
            // 设置窗体的Location
            this.Top = ownerTop;
            this.Left = ownerLeft;
        }

        /// <summary>
        /// 点击“确定”或“是”按钮
        /// </summary>
        private void OkButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// 点击“取消”或“否”按钮
        /// </summary>
        private void CancelButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// 加载动画类型
        /// </summary>
        public enum LoadedType
        {
            LoadedStretch,
            LoadedScale,
        }
    }
}
