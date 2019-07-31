using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Linq;
namespace WpfThemes
{
    /// <summary>
    /// Color 扩展
    /// </summary>
    public static class ColorExtension
    {


        // 新增的颜色
        private const string AccentDarkColor = "AccentDarkColor";
        private const string AccentLightColor = "AccentLightColor";
        private const string AccentDarkBrush = "AccentDarkBrush";
        private const string AccentLightBrush = "AccentLightBrush";



        private const string StaticBorderBrush = "Static.BorderBrush";
        private const string StaticBackgroundColor = "Static.BackgroundColor";
        private const string StaticForegroundColor = "Static.ForegroundColor";

        private const string MouseOverBorderBrush = "MouseOver.BorderBrush";
        private const string MouseOverBackgroundColor = "MouseOver.BackgroundColor";
        private const string MouseOverForegroundColor = "MouseOver.ForegroundColor";

        private const string PressedBackgroundColor = "Pressed.BackgroundColor";
        private const string PressedBorderBrush = "Pressed.BorderBrush";
        private const string PressedForegroundColor = "Pressed.ForegroundColorColor";

        private const string SelectedBackgroundColor = "Selected.BackgroundColor";
        private const string SelectedBorderBrush = "Selected.BorderBrush";
        private const string SelectedForegroundColor = "Selected.ForegroundColor";

        private const string PressedBackgroundColorDark = "Pressed.BackgroundColorDark";
        private const string PressedBorderBrushDark = "Pressed.BorderBrushDark";
        private const string PressedBorderColorDark = "Pressed.BorderColorDark";

        /// <summary>
        /// 创建主色
        /// </summary>
        public static void CreateAccentColors(this Color color)
        {
            ResourceDictionary dictionary = Application.Current.Resources;
            if (!dictionary.Contains(color.ToString()))
            {
                var resources = new ResourceDictionary();
                resources.AddResources(color);
                dictionary.MergedDictionaries.Insert(0, resources);
                dictionary.Add(color.ToString(), color);
            }
        }

        /// <summary>
        /// 添加颜色资源
        /// </summary>
        private static void AddResources(this ResourceDictionary resources, Color color)
        {
            // 判断颜色key是否存在，不存在则添加

            /*
            通用Dark,Light,分为四个不同的级别颜色。
            */
            if (!resources.Contains(AccentDarkColor))
                resources.Add(AccentDarkColor, color.GetAccentColor(250));
            if (!resources.Contains(AccentLightColor))
                resources.Add(AccentLightColor, color.GetAccentColor(160));
            if (!resources.Contains(AccentDarkBrush))
                resources.Add(AccentDarkBrush, color.GetAccentColor(80));
            if (!resources.Contains(AccentLightBrush))
                resources.Add(AccentLightBrush, color.GetAccentColor(20));





            // 默认 前景色
            if (!resources.Contains(StaticForegroundColor))
                resources.Add(StaticForegroundColor, color.GetStaticColor(220));
            // 默认 边框
            if (!resources.Contains(StaticBorderBrush))
                resources.Add(StaticBorderBrush, color.GetStaticColor(160));
            // 默认 背景色
            if (!resources.Contains(StaticBackgroundColor))
                resources.Add(StaticBackgroundColor, color.GetStaticColor(40));


            // MouseOver 鼠标悬浮 前景色
            if (!resources.Contains(MouseOverForegroundColor))
                resources.Add(MouseOverForegroundColor, color.GetMouseOverColor(20));
            // MouseOver 鼠标悬浮 边框色
            if (!resources.Contains(MouseOverBorderBrush))
                resources.Add(MouseOverBorderBrush, color.GetMouseOverColor(240));
            // MouseOver 鼠标悬浮 背景色
            if (!resources.Contains(MouseOverBackgroundColor))
                resources.Add(MouseOverBackgroundColor, color.GetMouseOverColor(100));


            // Pressed 按下 前景色
            if (!resources.Contains(PressedForegroundColor))
                resources.Add(PressedForegroundColor, color.GetPressedColor(60));
            // Pressed 按下 边框色
            if (!resources.Contains(PressedBorderBrush))
                resources.Add(PressedBorderBrush, color.GetPressedColor(180));
            // Pressed 按下 背景色
            if (!resources.Contains(PressedBackgroundColor))
                resources.Add(PressedBackgroundColor, color.GetPressedColor(140));

            // Selected 选中 前景色
            if (!resources.Contains(SelectedForegroundColor))
                resources.Add(SelectedForegroundColor, color.GetSelectedColor(30));
            // Selected 选中 边框色
            if (!resources.Contains(SelectedBorderBrush))
                resources.Add(SelectedBorderBrush, color.GetSelectedColor(140));
            // Selected 选中 背景色
            if (!resources.Contains(SelectedBackgroundColor))
                resources.Add(SelectedBackgroundColor, color.GetSelectedColor(200));
        }

        private static Color GetAccentColor(this Color color, int A = 220)
        {
            var c = Color.FromArgb((byte)A, color.R, color.G, color.B);
            return c.MakeOpaque();
        }



        /// <summary>
        /// 默认色
        /// </summary>
        private static Color GetStaticColor(this Color color, int A = 30)
        {
            var c = Color.FromArgb((byte)A, color.R, color.G, color.B);
            return c.MakeOpaque();
        }

        /// <summary>
        /// MouseOver 悬浮色
        /// </summary>
        private static Color GetMouseOverColor(this Color color, int A = 30)
        {
            var c = Color.FromArgb((byte)A, color.R, color.G, color.B);
            return c.MakeOpaque();
        }

        /// <summary>
        /// Pressed 按下色
        /// </summary>
        private static Color GetPressedColor(this Color color, int A = 30)
        {
            var c = Color.FromArgb((byte)A, color.R, color.G, color.B);
            return c.MakeOpaque();
        }

        /// <summary>
        /// Selected 选中色
        /// </summary>
        private static Color GetSelectedColor(this Color color, int A = 30)
        {
            var c = Color.FromArgb((byte)A, color.R, color.G, color.B);
            return c.MakeOpaque();
        }

        /// <summary>
        /// 混合颜色
        /// </summary>
        private static Color MakeOpaque(this Color color)
        {
            return MixColors(color, Colors.WhiteSmoke);
        }

        private static Color MixColors(Color color1, Color color2)
        {
            var r = (color1.R * color1.A / 255) + (color2.R * color2.A * (255 - color1.A) / (255 * 255));
            var g = (color1.G * color1.A / 255) + (color2.G * color2.A * (255 - color1.A) / (255 * 255));
            var b = (color1.B * color1.A / 255) + (color2.B * color2.A * (255 - color1.A) / (255 * 255));

            return Color.FromRgb((byte)r, (byte)g, (byte)b);
        }
    }
}