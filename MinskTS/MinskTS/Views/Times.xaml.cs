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
    public sealed partial class Times : Page
    {
        private static int rt;
        private static int st;
        public static int St { get => st; set => st = value; }
        public static int Rt { get => rt; set => rt = value; }
        private string StopName { get; set; }
        private string RouteNumber { get; set; }
        private Types Icon { get; set; }
        Dictionary<string,string> str = new Dictionary<string,string>();
        List<string> lst = new List<string>();
        List<string> lst2 = new List<string>();
        public Times()
        {
            this.InitializeComponent();
            this.Loaded += Time_Loaded;
            
        }

        private void Time_Loaded(object sender, RoutedEventArgs e)
        {
            
            using (ScheduleContext db = new ScheduleContext())
            {
                var route = db.Route.Where(x => x.Id == rt);
                    foreach (var item in route)
                    {
                      RouteNumber = item.Number;
                      Icon = item.Type;
                    }
                var stop = db.Stop.Where(x => x.Id == st).Select(x => x.Name);
                    foreach (var item2 in stop)
                    {
                     StopName = item2;
                    }
            }
            MainPage.Title = "→Расписание " + RouteNumber + " " +Icon;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
           using (ScheduleContext db = new ScheduleContext())
           {
            
                foreach (TimeTable item in db.TimeTable)
                {
                    if (item.RouteId == rt && item.StopId == st)
                    {

                            lst.AddRange(item.Hour.Split(','));
                            lst2.AddRange(item.Minutes.Split(','));
                        for (int i = 0; i < lst.Count; i++)
                            str.Add(lst[i], lst2[i]);

                    }
                }

                scheduleTime.ItemsSource = str;
               // scheduleTime.SelectedIndex = 2;
            }
        }
    }
}
