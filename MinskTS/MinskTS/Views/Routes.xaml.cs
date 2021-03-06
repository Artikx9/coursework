﻿using MinskTS.Models;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MinskTS.Views
{
    public sealed partial class Routes : Page
    {
        public  Routes()
        {
            this.InitializeComponent();
            this.Loaded +=  Rout_Loaded;
        }
        
        private void Rout_Loaded(object sender, RoutedEventArgs e)
        {

            using (ScheduleContext  db =  new ScheduleContext())
            {
                 scheduleRoute.ItemsSource =   db.Route.ToList();
                comboBox.ItemsSource =  Enum.GetValues(typeof(Types));
                comboBox.SelectedIndex =  0;
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
                                .Where(c => c.Type == Types.Bus)
                                .Where(x => x.RouteName.Contains(suggestRoute.Text) || x.Number.Contains(suggestRoute.Text));
                        }
                        else
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(x => x.Type == Types.Bus);
                        }
                        break;
                    case 2:
                        if (senderText.Length > 0)
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(c => c.Type == Types.Tramway)
                                .Where(x => x.RouteName.Contains(suggestRoute.Text) || x.Number.Contains(suggestRoute.Text));
                        }
                        else
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(x => x.Type == Types.Tramway);
                        }
                        break;
                    case 3:
                        if (senderText.Length > 0)
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(c => c.Type == Types.Trolleybus)
                                .Where(x => x.RouteName.Contains(suggestRoute.Text) || x.Number.Contains(suggestRoute.Text));
                        }
                        else
                        {
                            scheduleRoute.ItemsSource = db.Route
                                .Where(x => x.Type == Types.Trolleybus);
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
            MainPage.Title = "Выберите остановку";
        }
    }

}
