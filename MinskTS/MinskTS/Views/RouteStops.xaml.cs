using MinskTS.Models;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.EntityFrameworkCore;

namespace MinskTS.Views
{

    public sealed partial class RouteStops : Page
    {
    
    
        public RouteStops()
        {
            this.InitializeComponent();
        }
       
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                Times.Rt = (int)e.Parameter;
                using (ScheduleContext db = new ScheduleContext())
                {
                    var data = db.Route.Include(c1 => c1.RouteStops)
                    .ThenInclude(c2 => c2.Stop).ToList();

                    List<Stop> tempList = new List<Stop>();
                    foreach (var c in data)
                    {
                        var temp = from item in c.RouteStops
                                   where item.RouteId == (int)e.Parameter
                                   select item.Stop;

                        tempList.AddRange(temp);
                    }
                    scheduleRS.ItemsSource = tempList;


                }
            }
        }

        private void ScheduleList_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (ScheduleContext db = new ScheduleContext())
            {
                Stop select = (Stop)e.ClickedItem;
                Times.St =  select.Id;
                Frame.Navigate(typeof(Times));
               
            }         
        }
    }
}
