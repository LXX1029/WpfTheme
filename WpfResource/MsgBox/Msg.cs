using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfThemes.MsgBox;

namespace WpfThemes
{
    /// <summary>
    /// 提示框类
    /// </summary>
    public static class Msg
    {
        private static readonly string Msg_Infor = "提示信息";
        private static readonly string Msg_Warning = "警告信息";
        private static readonly string Msg_Confirm = "确定信息";
        private static readonly string Msg_Error = "错误信息";
        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param name="owner">拥有弹出窗体的窗体</param>
        /// <param name="message">提示信息</param>
        public static bool ShowInfor(string message, ContentControl owner = null)
        {
            MessageBoxInfoForm frm = new MessageBoxInfoForm(owner, Msg_Infor, message, false);
            string imgPath = "pack://application:,,,/WpfThemes;component/Images/Information.png";
            frm.Img.Source = ConvertToBitmapImage(imgPath);
            return frm.ShowDialog().Value;
        }

        /// <summary>
        /// 确认提示，包含“确认”，“取消”按钮
        /// </summary>
        /// <param name="owner">拥有弹出窗体的窗体</param>
        /// <param name="message">提示信息</param>
        public static bool ShowConfirmOkCancel(string message, ContentControl owner = null)
        {
            MessageBoxInfoForm frm = new MessageBoxInfoForm(owner, Msg_Confirm, message, true);
            string imgPath = "pack://application:,,,/WpfThemes;component/Images/Warning.png";
            frm.Img.Source = ConvertToBitmapImage(imgPath);
            return frm.ShowDialog().Value;
        }


        /// <summary>
        /// 确认提示，包含“是”，“否”按钮
        /// </summary>
        /// <param name="owner">拥有弹出窗体的窗体</param>
        /// <param name="message">提示信息</param>
        public static bool ShowConfirmYesNo(string message, ContentControl owner = null)
        {
            MessageBoxInfoForm frm = new MessageBoxInfoForm(owner, Msg_Confirm, message, true);
            string imgPath = "pack://application:,,,/WpfThemes;component/Images/Warning.png";
            frm.Img.Source = ConvertToBitmapImage(imgPath);
            frm.OkButton.Content = "是";
            frm.CancelButton.Content = "否";
            return frm.ShowDialog().Value;
        }

        /// <summary>
        /// 警告提示，包含“确定”，“取消”按钮
        /// </summary>
        /// <param name="owner">拥有弹出窗体的窗体</param>
        /// <param name="message">提示信息</param>
        public static bool ShowWarning(string message, ContentControl owner = null)
        {
            MessageBoxInfoForm frm = new MessageBoxInfoForm(owner, Msg_Warning, message, true);
            string imgPath = "pack://application:,,,/WpfThemes;component/Images/Warning.png";
            frm.Img.Source = ConvertToBitmapImage(imgPath);
            return frm.ShowDialog().Value;
        }

        /// <summary>
        /// 错误提示，包含“确定”按钮
        /// </summary>
        /// <param name="owner">拥有弹出窗体的窗体</param>
        /// <param name="message">提示信息</param>
        public static bool ShowError(string message, ContentControl owner = null)
        {
            MessageBoxInfoForm frm = new MessageBoxInfoForm(owner, Msg_Error, message);
            string imgPath = "pack://application:,,,/WpfThemes;component/Images/Warning.png";
            frm.Img.Source = ConvertToBitmapImage(imgPath);
            return frm.ShowDialog().Value;
        }

        /// <summary>
        /// 程序退出提示
        /// </summary>
        /// <param name="owner">拥有弹出窗体的窗体</param>
        /// <param name="message">提示信息</param>
        public static bool ShowShutDown(string message, Window owner = null)
        {
            MessageBoxInfoForm frm = new MessageBoxInfoForm(owner, Msg_Confirm, message, true, MessageBoxInfoForm.LoadedType.LoadedStretch);
            string imgPath = "pack://application:,,,/WpfThemes;component/Images/Shutdown.png";
            frm.Img.Source = ConvertToBitmapImage(imgPath);
            frm.OkButton.Content = "是";
            frm.CancelButton.Content = "否";
            return frm.ShowDialog().Value;
        }

        /// <summary>
        /// 根据路径转换为ImageSource
        /// </summary>
        /// <param name="imgPath">图片路径</param>
        /// <returns>ImageSource</returns>
        private static ImageSource ConvertToBitmapImage(string imgPath)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnDemand;
            image.UriSource = new Uri(imgPath);
            image.EndInit();
            return image;
        }

    }
}
