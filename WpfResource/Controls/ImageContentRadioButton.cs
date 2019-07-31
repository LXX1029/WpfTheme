using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfThemes.Controls
{
    public class ImageContentRadioButton: RadioButton
    {
        static ImageContentRadioButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageContentRadioButton), new FrameworkPropertyMetadata(typeof(ImageContentRadioButton)));
        }
        public static readonly DependencyProperty ImageSorceProperty = DependencyProperty.Register("ImageSorce", typeof(ImageSource), typeof(ImageContentRadioButton));
        /// <summary>
        /// 图片资源
        /// </summary>
        public ImageSource ImageSorce
        {
            get { return (ImageSource)GetValue(ImageContentRadioButton.ImageSorceProperty); }
            set { SetValue(ImageContentRadioButton.ImageSorceProperty, value); }
        }
    }
}
