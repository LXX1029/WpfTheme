using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WpfThemes
{
    /// <summary>
    /// 定义外部程序集引用的dll中的进度条资源
    /// </summary>
    public partial class MyProgressBar
    {
        public static ComponentResourceKey PbForegroundKey
        {
            get
            {
                return new ComponentResourceKey(typeof(MyProgressBar), "PbForeground");
            }
           
        }
        public static ComponentResourceKey PbBackgroundKey
        {
            get
            {
                return new ComponentResourceKey(typeof(MyProgressBar), "PbBackground");
            }
        }
        public static ComponentResourceKey PbThumbBackgroundKey
        {
            get
            {
                return new ComponentResourceKey(typeof(MyProgressBar), "PbThumbBackground");
            }
        }
    }
}
