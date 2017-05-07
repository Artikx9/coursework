using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using MinskTS.Models;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Imaging;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace MinskTS
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string Title { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            

        }
        
        private  void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            MenuGrid_Tapped(null, null);
            Settings.Schowtime = true;
            CompositionTarget.Rendering += Time;
            CompositionTarget.Rendering += Titles;
        }

        

        private void MenuGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (NavigationPane.IsPaneOpen)
                NavigationPane.IsPaneOpen = !NavigationPane.IsPaneOpen;

            if (LeftMenu.SelectedItem is MenuItem menu)
            {
                if (menu.NavigateTo != null)
                    CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { FrameContent.Navigate(menu.NavigateTo); });
            }
        }
        
        private void Time(object sender, object e)
        {
         
            if (Settings.Schowtime == true)
            {
                Timepanel.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else { Timepanel.Text = ""; }
        }

        private void Titles(object sender, object e)
        {
            titletwo.Text = Title;
          
        }

    }

}




