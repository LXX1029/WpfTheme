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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfThemes.UserControls
{
    /// <summary>
    /// ToolBarIconAndTitle.xaml 的交互逻辑
    /// </summary>
    public partial class ToolBarIconAndTitle : UserControl
    {
        public ToolBarIconAndTitle()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        /// <summary>
        /// Title
        /// </summary>
        public string ToolBarTitle
        {
            get { return (string)GetValue(ToolBarTitleProperty); }
            set { SetValue(ToolBarTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ToolBarTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ToolBarTitleProperty =
            DependencyProperty.Register("ToolBarTitle", typeof(string), typeof(ToolBarIconAndTitle), new PropertyMetadata(""));



        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(ToolBarIconAndTitle), new PropertyMetadata("/WpfThemes;component/Images/Bug.ico"));


    }
}
