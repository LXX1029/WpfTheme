using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfThemes.BusyIndicator
{
    /// <summary>
    /// 动态进度条提示类
    /// </summary>
    public sealed class Busy
    {
        // 进度条窗口
        private Waiting waiting = null;
        /// <summary>
        /// 静态对象
        /// </summary>
        private static Busy _busyIndicator = null;
        static Busy()
        {
            _busyIndicator = new Busy();
        }

        /// <summary>
        /// 获得单例引用
        /// </summary>
        public static Busy GetInstance
        {
            get
            {
                return _busyIndicator;
            }
        }
        /// <summary>
        /// 当前线程调度器
        /// </summary>
        private readonly Dispatcher _dispatcher = Dispatcher.CurrentDispatcher;
        /// <summary>
        /// 设置提示文本
        /// </summary>
        /// <param name="message">提示文本值</param>
        public void SetMessage(string message)
        {
            waiting?.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                waiting?.SetMessage(message);
            }
                ));
        }

        /// <summary>
        /// 显示等待窗口
        /// </summary>
        /// <param name="parentWindow">拥有该窗口的父窗口,一般传入当前窗口：this</param>
        /// <param name="message">显示的文本</param>
        public void Show(Window parentWindow, string message = "请稍等")
        {
            if (waiting == null)
            {
                Task.Run(() =>
                {
                    // 更新UI显示
                    this._dispatcher?.BeginInvoke(new Action(delegate
                    {
                        waiting = new Waiting(parentWindow, message.ToString());
                        waiting.Show();
                    }));
                });
            }
        }
        /// <summary>
        /// 关闭等待窗口
        /// </summary>
        public void Close()
        {
            try
            {
                this._dispatcher?.BeginInvoke(new Action(delegate
                {
                    waiting?.Close();
                    waiting = null;
                }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
