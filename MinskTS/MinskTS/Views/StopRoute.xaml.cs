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
using MinskTS.Models;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace MinskTS.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class StopRoute : Page
    {
        List<int> lst = new List<int>();
        Dictionary<int,string> lst2 = new Dictionary<int, string>();
        public StopRoute()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                Time.St = (int)e.Parameter;
                using (ScheduleContext db = new ScheduleContext())
                {
                    foreach (RS item in db.RouteStop)
                    {
                        if (item.StopId.Split(',').Contains(e.Parameter.ToString()))
                        {

                            lst.Add(item.RouteId);
                          
                        }
                    }
                    foreach (int i in lst)
                    {
                        foreach (Rou item2 in db.Route)
                        {
                            if (item2.Id == i)
                            {
                                lst2.Add(item2.Id,item2.Number.ToString());
                            }
                        }

                    }


                    scheduleRS.ItemsSource = lst2;
                }
            }
        }

        private void ScheduleList_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (ScheduleContext db = new ScheduleContext())
            {
                KeyValuePair<int, string> select = (KeyValuePair<int, string>)e.ClickedItem;
                Time.Rt = select.Key;
                Frame.Navigate(typeof(Time));
            }


        }
    }

}

