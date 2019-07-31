using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

using WpfThemes;
using System.Windows.Controls;

namespace WpfThemesTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            this.Loaded += (m, n) =>
            {
                ColorList.Add(new ColorClass { IsChecked = false, Name = "#313131" });
            };


            btnPopup.PreviewMouseLeftButtonDown += (m, n) =>
            {
                Msg.ShowInfor("bbbbBBBBBB-------------------------------------------------------BBBBBBBBBBBBBBBBBBBBBBBBBBBBfdsafgadfgdfgffffffffffffffffffffffffffffffffffffff");
            };
            dg.SelectionChanged += Dg_SelectionChanged;
        }
        private void Dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 1)
            {
                ColorClass colorClass = (ColorClass)e.AddedItems[0];
                colorClass.IsChecked = !colorClass.IsChecked;
            }

        }
        private ObservableCollection<ColorClass> _colorList = new ObservableCollection<ColorClass>();

        public ObservableCollection<ColorClass> ColorList
        {
            get
            {
                return _colorList;
            }

            set
            {
                _colorList = value;
            }
        }

        private async void btnShowPb_Click(object sender, RoutedEventArgs e)
        {
            WpfThemes.BusyIndicator.Busy.GetInstance.Show(this);
            //DZPLoadingControl.BusyIndicator.GetInstance.Show(this);
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
            });
            //DZPLoadingControl.BusyIndicator.GetInstance.SetMessage("线程已挂起5s");
            WpfThemes.BusyIndicator.Busy.GetInstance.SetMessage("线程挂起2s");
            await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
            });
            //DZPLoadingControl.BusyIndicator.GetInstance.Close();
            WpfThemes.BusyIndicator.Busy.GetInstance.Close();


        }
      
    }
}
