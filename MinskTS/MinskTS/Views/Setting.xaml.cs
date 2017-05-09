using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace MinskTS.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Setting : Page
    {
        Windows.Storage.ApplicationDataContainer localSettings =
            Windows.Storage.ApplicationData.Current.LocalSettings;
        public Setting()
        {
            this.InitializeComponent();
            this.Loaded += Settings_Loaded; 
        }

        private void Settings_Loaded(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(localSettings.Values["TimeSwitch"]) == true) TimeSwitch.IsOn = true;
            else TimeSwitch.IsOn = false;
            localSettings.Values["TimeSwitch"] = TimeSwitch.IsOn;

        }

        private void TimeSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            switch (TimeSwitch.IsOn)
            {
                case true:
                    localSettings.Values["TimeSwitch"]  = true;
                    break;
                case false:
                    localSettings.Values["TimeSwitch"] = false;
                    break;
            }      
            
        }

        
    }
}
