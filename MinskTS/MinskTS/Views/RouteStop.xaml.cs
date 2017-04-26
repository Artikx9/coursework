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
    public sealed partial class RouteStop : Page
    {
    
        List<int> lst = new List<int>();
        List<string> lst2 = new List<string>();
        public RouteStop()
        {
            this.InitializeComponent();
        }

       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
              
                using (ScheduleContext db = new ScheduleContext())
                {

                    foreach (RS item in db.RouteStop)
                    {
                        if (item.RouteId == (int)e.Parameter)
                        {
                        
                            lst.AddRange(item.StopId.Split(',').Select(int.Parse));
                        }
                    }

                    foreach (int i in lst)
                    {
                        foreach (Stops item2 in db.Stop)
                        {
                            if (item2.Id == i)
                            {
                                lst2.Add(item2.Name.ToString());
                            }
                        }

                    }


                    scheduleRS.ItemsSource = lst2;
                }
            }
        }
    }
}
