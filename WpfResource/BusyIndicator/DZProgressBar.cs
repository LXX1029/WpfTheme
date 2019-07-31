using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfThemes.BusyIndicator
{
    /// <summary>
    /// 自定义Bar
    /// </summary>
    partial class DZProgressBar : ProgressBar
    {
        /// <summary>
        /// 进度条显示的内容
        /// </summary>
        public string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// 注册依赖项
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(DZProgressBar), new PropertyMetadata("正在处理...."));


    }
}
