using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfThemes
{
    /// <summary>
    /// SkinSettingControl.xaml 的交互逻辑
    /// </summary>
    public partial class SkinSettingControl : UserControl
    {
        public SkinSettingControl()
        {
            InitializeComponent();
            this.Loaded += SkinSettingControl_Loaded;
            this.DataContext = this;

        }
        static SkinSettingControl()
        {
            EventManager.RegisterRoutedEvent("SetSkinEventHandler", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SkinSettingControl));
        }

        public static readonly RoutedEvent SetSkinRoutedEvent;
        public event RoutedEventHandler SetSkinEventHandler
        {
            add
            {
                AddHandler(SetSkinRoutedEvent, value);
            }
            remove
            {
                RemoveHandler(SetSkinRoutedEvent, value);
            }
        }

        #region 皮肤字典列表
        private static List<SkinTheme> skinList = new List<SkinTheme>()
        {
            new SkinTheme("雨林绿", "#228B22", true),
            new SkinTheme("青金色", "#0077B8"),
            new SkinTheme("瑠璃色", "#2A5CAA"),
            new SkinTheme("孔雀绿", "#0096B0"),
            new SkinTheme("中国红", "#DB4527"),
            new SkinTheme("钴绿色", "#008080"),
        };
        public static List<SkinTheme> SkinList
        {
            get
            {
                return skinList;
            }
        }
        #endregion

        #region 皮肤名称
        /// <summary>
        /// 默认皮肤名称
        /// </summary>
        internal static string DefaultSkinName
        {
            get
            {
                return skinList.FirstOrDefault(s => s.IsItemSelected).skinName;
            }
        }

        /// <summary>
        /// 选中的皮肤名称
        /// </summary>
        public static string SelectedSkinTheme { get; set; }
        #endregion

        #region 加载事件
        /// <summary>
        /// 皮肤选择改变事件
        /// </summary>
        private void SkinSettingControl_Loaded(object sender, RoutedEventArgs e)
        {
            lbSkins.SelectionChanged += (s, m) =>
            {
                popup.IsOpen = false;
                SelectedSkinTheme = ((SkinTheme)lbSkins.SelectedItem).skinName;
            };
            // 弹出popup窗口事件
            popup.Opened += (m, n) =>
            {
                if (!isGenerated)
                    GeneratePathData();
            };
            popup.Closed += (m, n) =>
            {
                // 调用设置默认皮肤
                SetSkin(SelectedSkinTheme);
            };
        }
        #endregion

        #region 设置皮肤
        /// <summary>
        /// 设置皮肤
        /// 调用在app.cs 中的OnStartup方法里。
        /// </summary>
        /// <param name="resourceName">主题名称</param>
        public static void SetSkin(string resourceName = "钴绿色")
        {
            try
            {
                if (!skinList.Any(a => a.skinName == resourceName))
                    resourceName = "钴绿色";
                SkinTheme theme = skinList.SingleOrDefault(s => s.skinName == resourceName);
                // 清空资源
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Clear();

                // 生成主色
                Color customColor = (Color)ColorConverter.ConvertFromString(theme.skinValue);
                var accentBrush = new SolidColorBrush(customColor);
                accentBrush.Color.CreateAccentColors();

                // 设置当前App的ResourceDictionary
                ResourceDictionary skin =
                    Application.LoadComponent(new Uri("/WpfThemes;component/Themes/Generics.xaml", UriKind.Relative)) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(skin);

                // 设置选中项
                if (DefaultSkinName != resourceName)
                {
                    SkinTheme defaultSkinTheme = skinList.SingleOrDefault(s => s.skinName == DefaultSkinName);
                    if (defaultSkinTheme != null)
                        defaultSkinTheme.IsItemSelected = false;
                    if (theme != null)
                        theme.IsItemSelected = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 生成边框Path

        private bool isGenerated = false;
        private void GeneratePathData()
        {
            pathBorder.Data = null;
            // 获取ListBox 宽,高
            int lwidth = Convert.ToInt32(lbSkins.ActualWidth) + 25;
            int lheight = Convert.ToInt32(lbSkins.ActualHeight) + 15;

            PathFigure pthFigure = new PathFigure();
            pthFigure.IsClosed = true;
            pthFigure.StartPoint = new Point(0, 0);
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, lheight); // 计算第二个点
            Point p3 = new Point(lwidth, lheight);
            Point p4 = new Point(lwidth, 22); // 22=lheight * 0.15;
            Point p5 = new Point(lwidth * 1.03, 15); // 15=lheight * 0.1
            Point p6 = new Point(lwidth, 8); // 8=lheight * 0.05
            Point p7 = new Point(lwidth, 0);

            PolyLineSegment plineSeg = new PolyLineSegment();
            plineSeg.Points.Add(p1);
            plineSeg.Points.Add(p2);
            plineSeg.Points.Add(p3);
            plineSeg.Points.Add(p4);
            plineSeg.Points.Add(p5);
            plineSeg.Points.Add(p6);
            plineSeg.Points.Add(p7);
            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(plineSeg);
            pthFigure.Segments = myPathSegmentCollection;
            PathFigureCollection pthFigureCollection = new PathFigureCollection();
            pthFigureCollection.Add(pthFigure);
            PathGeometry pthGeometry = new PathGeometry();
            pthGeometry.Figures = pthFigureCollection;

            pathBorder.Data = pthGeometry;
            isGenerated = true;
        }
        #endregion

    }

    /// <summary>
    /// 皮肤类
    /// </summary>
    public class SkinTheme : INotifyPropertyChanged
    {
        public SkinTheme(string name, string value, bool isSelected = false)
        {
            this.skinName = name;
            this.skinValue = value;
            this.IsItemSelected = isSelected;

        }

        public string skinName { get; set; }

        public string skinValue { get; set; }
        private bool isItemSelected = false;
        public bool IsItemSelected
        {
            get
            {
                return isItemSelected;
            }
            set
            {
                isItemSelected = value;
                OnPropertyChanged("IsItemSelected");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    /// <summary>
    /// 选择匹配改变事件
    /// </summary>
    public class SkinChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 皮肤名称
        /// </summary>
        public string skinName { get; set; }
    }
}
