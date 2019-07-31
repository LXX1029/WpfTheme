using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfThemes.Controls
{
    /// <summary>
    /// 只显示下划线的TextBox
    /// </summary>
    public partial class TextBoxUnderLine : TextBox
    {
        public static DependencyProperty LabNameProperty;
        static TextBoxUnderLine()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxUnderLine), new FrameworkPropertyMetadata(typeof(TextBoxUnderLine)));

            LabNameProperty =
          DependencyProperty.Register("LabName", typeof(string), typeof(TextBoxUnderLine));
        }

        public TextBoxUnderLine()
        {

        }
        public string LabName
        {
            get { return GetValue(LabNameProperty).ToString(); }
            set
            {
                SetValue(LabNameProperty, value);
            }
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
