using MinskTS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MinskTS.Views
{
    public sealed partial class Routes : Page
    {
        public   Routes()
        {
            this.InitializeComponent();
            this.Loaded += Rout_Loaded;  
        }

        private  void Rout_Loaded(object sender, RoutedEventArgs e)
        {
            
            using (ScheduleContext db = new ScheduleContext())
            {
                scheduleRoute.ItemsSource = db.Route.ToList();
                comboBox.ItemsSource = Enum.GetValues(typeof(Types));
                comboBox.SelectedIndex = 0;
            }
        }

        private  void  SortFunction(string senderText)
        {
            using (ScheduleContext db = new ScheduleContext())
            {
               if(comboBox.SelectedValue == null)
                {
                    if (senderText.Length > 0)
                    {
                        scheduleRoute.ItemsSource = db.Route.
                            Where(x => x.RouteName.Contains(suggestRoute.Text) || x.Number.Contains(suggestRoute.Text));
                    }
                    else
                    {
                        scheduleRoute.ItemsSource = db.Route.ToList();
                    }
                    return;
                }
                switch (Convert.ToInt32((Types)comboBox.SelectedValue))
                {
                    case 1:
                        if (senderText.Length > 0)
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(c => c.Type == Types.Автобус)
                                .Where(x => x.RouteName.Contains(suggestRoute.Text) || x.Number.Contains(suggestRoute.Text));
                        }
                        else
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(x => x.Type == Types.Автобус);
                        }
                        break;
                    case 2:
                        if (senderText.Length > 0)
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(c => c.Type == Types.Трамвай)
                                .Where(x => x.RouteName.Contains(suggestRoute.Text) || x.Number.Contains(suggestRoute.Text));
                        }
                        else
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(x => x.Type == Types.Трамвай);
                        }
                        break;
                    case 3:
                        if (senderText.Length > 0)
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(c => c.Type == Types.Тролейбус)
                                .Where(x => x.RouteName.Contains(suggestRoute.Text) || x.Number.Contains(suggestRoute.Text));
                        }
                        else
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(x => x.Type == Types.Тролейбус);
                        }
                        break;
                    default:
                        if (senderText.Length > 0)
                        {
                            scheduleRoute.ItemsSource = db.Route.
                                Where(x => x.RouteName.Contains(suggestRoute.Text) || x.Number.Contains(suggestRoute.Text));
                        }
                        else
                        {
                            scheduleRoute.ItemsSource = db.Route.ToList();
                        }
                        break;
                }
            }
        }

        public void SuggestBox_TextChanged2(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                SortFunction(sender.Text);
            }
        }
     
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            SortFunction(senderComboBox.SelectedItem.ToString());
        }

        private void ScheduleList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Route selected = (Route)e.ClickedItem;
            Frame.Navigate(typeof(RouteStops), selected.Id);
            MainPage.Title = "→выберите остановку";
        }
    }

}
