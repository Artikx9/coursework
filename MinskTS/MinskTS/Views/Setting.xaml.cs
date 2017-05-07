using MinskTS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace MinskTS.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Setting : Page
    {
        public Setting()
        {
            this.InitializeComponent();
            this.Loaded += Settings_Loaded; 
        }

        private void Settings_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Schowtime == true) TimeSwitch.IsOn = true;
            else TimeSwitch.IsOn = false;
            
        }

        private void TimeSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            switch (TimeSwitch.IsOn)
            {
                case true:
                    Settings.Schowtime = true;
                    break;
                case false:
                    Settings.Schowtime = false;
                    break;
            }      
            
        }

        
    }
}
