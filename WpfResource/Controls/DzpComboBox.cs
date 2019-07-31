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
    public partial class DzpComboBox : ComboBox
    {
        /// <summary>
        /// 文本名称
        /// </summary>
        public static DependencyProperty LabNameProperty;
        static DzpComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DzpComboBox), new FrameworkPropertyMetadata(typeof(DzpComboBox)));

            LabNameProperty =
          DependencyProperty.Register("LabName", typeof(string), typeof(DzpComboBox));
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
            DependencyProperty.Register("ContentWidth", typeof(int), typeof(DzpComboBox), new PropertyMetadata(120));


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
