using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfThemes.Controls
{
    public partial class DzpGroupBox : GroupBox
    {
        public Visibility HeaderEllipseVisibility
        {
            get { return (Visibility)GetValue(HeaderEllipseVisibilityProperty); }
            set { SetValue(HeaderEllipseVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeaderEllipseVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderEllipseVisibilityProperty =
            DependencyProperty.Register("HeaderEllipseVisibility", typeof(Visibility), typeof(DzpGroupBox), new PropertyMetadata(Visibility.Visible));



    }
}
