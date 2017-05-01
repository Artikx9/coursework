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
    public sealed partial class Time : Page
    {
        private static int rt;
        private static int st;
        public static int St { get => st; set => st = value; }
        public static int Rt { get => rt; set => rt = value; }
        Dictionary<string,string> str = new Dictionary<string,string>();
        List<string> lst = new List<string>();
        List<string> lst2 = new List<string>();
        public Time()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           using (ScheduleContext db = new ScheduleContext())
           {
            
                foreach (TT item in db.TimeTable)
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
            }
           
        }


    }
}
