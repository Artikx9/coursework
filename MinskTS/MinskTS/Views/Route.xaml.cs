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
    public sealed partial class Route : Page
    {
        public Route()
        {
            this.InitializeComponent();
            this.Loaded += Rout_Loaded;
        }

        private void Rout_Loaded(object sender, RoutedEventArgs e)
        {
            using (ScheduleContext db = new ScheduleContext())
            {
                scheduleRoute.ItemsSource = db.Route.ToList();

            }
        }


        private void suggestBox_TextChanged2(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            using (ScheduleContext db = new ScheduleContext())
            {
                if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {

                    if (sender.Text.Length > 0)
                    {
                        scheduleRoute.ItemsSource = db.Route.Where(x => x.RouteName.Contains(suggestRoute.Text) ||  x.Number.Contains(suggestRoute.Text));
                           
                    } 
                    else
                    {
                        scheduleRoute.ItemsSource = db.Route.ToList();
                    }
                }
            }
        }
      
     
        private void ScheduleList_ItemClick(object sender,  ItemClickEventArgs e)
        {
            Rou selected = (Rou)e.ClickedItem;
            Frame.Navigate(typeof(RouteStop), selected.Id);
            
        }

    }
}
