using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfThemes.OfficeThemeStyles
{
    public partial class ListBox
    {
        private ColorAnimation _colorAnimation = null;
        private ColorAnimationUsingKeyFrames _caukf = null;
        private SolidColorBrush _mouseOverColor = null;
        private SolidColorBrush _staticBackground = null;
        public ListBox()
        {
            _colorAnimation = new ColorAnimation();
            _colorAnimation.Name = "myColorAnimation";

            _caukf = new ColorAnimationUsingKeyFrames();
            _caukf.Name = "myCaukf";


        }
        static ListBox()
        {

        }

        private void Bd_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            /*
             <MultiTrigger>
                                        <MultiTrigger.Conditions>
                                            <Condition Property="IsSelected" Value="False"/>
                                            <Condition Property="IsMouseOver" Value="True"/>
                                        </MultiTrigger.Conditions>
                                        <MultiTrigger.EnterActions>
                                            <BeginStoryboard>
                                                <Storyboard >
                                                    <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="Background.(SolidColorBrush.Color)" Storyboard.TargetName="Bd">

                                                        <EasingColorKeyFrame KeyTime="0" Value="Transparent"></EasingColorKeyFrame>
                                                        <EasingColorKeyFrame KeyTime="0:0:1" Value="{Binding Source={StaticResource mouseovercolor} }"></EasingColorKeyFrame>


                                                    </ColorAnimationUsingKeyFrames>
                                                </Storyboard>
                                            </BeginStoryboard>
                                        </MultiTrigger.EnterActions>
                                        <!--<Setter  Property="Background" Value="{StaticResource Item.MouseOver.Background}"></Setter>-->
                                        <Setter Property="TextElement.Foreground" TargetName="cp" Value="{StaticResource Item.MouseOver.ForegroundColor}"/>
                                    </MultiTrigger>
            */
            Border border = sender as Border;
            if (Convert.ToBoolean(border.Tag))
            {
                return;
            }
            _mouseOverColor = _mouseOverColor ?? Application.Current.FindResource("Item.MouseOver.Background") as SolidColorBrush;
            _staticBackground = _staticBackground ?? Application.Current.FindResource("ListBox.Static.Background") as SolidColorBrush;


            //colorAnimation.From = Colors.Transparent;
            //SolidColorBrush color= Application.Current.FindResource("Item.MouseOver.Background") as SolidColorBrush;
            //colorAnimation.To = color.Color;
            //colorAnimation.Duration = TimeSpan.FromSeconds(0.5);
            //Storyboard storyBoard = new Storyboard();
            //Storyboard.SetTargetName(border, "myColorAnimation");
            //Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            //storyBoard.Children.Add(colorAnimation);
            //storyBoard.Begin(border);


            EasingColorKeyFrame color1 = new EasingColorKeyFrame(_staticBackground.Color, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)));
            EasingColorKeyFrame color2 = new EasingColorKeyFrame(_mouseOverColor.Color, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.3)));
            _caukf.KeyFrames.Add(color1);
            _caukf.KeyFrames.Add(color2);
            Storyboard storyBoard = new Storyboard();
            Storyboard.SetTargetName(border, "myCaukf");
            Storyboard.SetTargetProperty(_caukf, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            storyBoard.Children.Add(_caukf);
            storyBoard.Begin(border);

        }

        private void Bd_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Border border = sender as Border;
            //colorAnimation.From = Colors.Transparent;
            //SolidColorBrush color = Application.Current.FindResource("Accent.LightBrush") as SolidColorBrush;
            //_colorAnimation.To = Colors.Transparent;
            //_colorAnimation.Duration = TimeSpan.FromSeconds(0.5);
            //Storyboard storyBoard = new Storyboard();
            //Storyboard.SetTargetName(border, "myColorAnimation");
            //Storyboard.SetTargetProperty(_colorAnimation, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            //storyBoard.Children.Add(_colorAnimation);
            //storyBoard.Begin(border);
            if (Convert.ToBoolean(border.Tag))
            {
                return;
            }


            EasingColorKeyFrame color1 = new EasingColorKeyFrame(_mouseOverColor.Color, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)));
            EasingColorKeyFrame color2 = new EasingColorKeyFrame(_staticBackground.Color, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.3)));
            _caukf.KeyFrames.Add(color1);
            _caukf.KeyFrames.Add(color2);
            Storyboard storyBoard = new Storyboard();
            Storyboard.SetTargetName(border, "myCaukf");
            Storyboard.SetTargetProperty(_caukf, new PropertyPath("(Border.Background).(SolidColorBrush.Color)"));
            storyBoard.Children.Add(_caukf);
            storyBoard.Begin(border);
        }
    }
}
