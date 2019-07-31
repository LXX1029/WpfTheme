using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using WpfThemes;

namespace WpfThemesTest
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Dispatcher.ShutdownStarted += (m, n) =>
            {
                // 手动回收第0代无用资源
                GC.Collect(0, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
            };
        }

        public void ApplySkin(Uri skinDictionaryUri)
        {
            // Load the ResourceDictionary into memory.
            ResourceDictionary skinDict = Application.LoadComponent(skinDictionaryUri) as ResourceDictionary;

            Collection<ResourceDictionary> mergedDicts = base.Resources.MergedDictionaries;

            // Remove the existing skin dictionary, if one exists.
            // NOTE: In a real application, this logic might need
            // to be more complex, because there might be dictionaries
            // which should not be removed.
            if (mergedDicts.Count > 0)
                mergedDicts.Clear();

            // Apply the selected skin so that all elements in the
            // application will honor the new look and feel.
            mergedDicts.Add(skinDict);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // 调用设置皮肤方法
            SkinSettingControl.SetSkin();

            MainWindow mw = new WpfThemesTest.MainWindow();
            mw.Show();
            base.OnStartup(e);
        }
        protected override void OnLoadCompleted(NavigationEventArgs e)
        {
            base.OnLoadCompleted(e);
        }
    }
}
