using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfThemes.Controls
{
    /// <summary>
    /// 带文本的TextBox
    /// </summary>
    public partial class DzpTextBox : TextBox
    {
        /// <summary>
        /// 文本名称
        /// </summary>
        public static DependencyProperty LabNameProperty;
        static DzpTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DzpTextBox), new FrameworkPropertyMetadata(typeof(DzpTextBox)));

            LabNameProperty =
          DependencyProperty.Register("LabName", typeof(string), typeof(DzpTextBox));
        }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string LabName
        {
            get { return GetValue(LabNameProperty).ToString(); }
            set
            {
                SetValue(LabNameProperty, value);
            }
        }




        public int ContentWidth
        {
            get { return (int)GetValue(ContentWidthProperty); }
            set { SetValue(ContentWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentWidthProperty =
            DependencyProperty.Register("ContentWidth", typeof(int), typeof(DzpTextBox), new PropertyMetadata(120));


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
