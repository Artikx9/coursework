using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.EntityFrameworkCore;
using MinskTS.Models;

namespace MinskTS.Views
{

    public sealed partial class StopRoutes : Page
    {
        public StopRoutes()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                Times.St = (int)e.Parameter;
                using (ScheduleContext db = new ScheduleContext())
                {
                    var data= db.Stop.Include(c1 => c1.RouteStops)
                        .ThenInclude(c2 => c2.Route).ToList();

                    List<Route> tempList = new List<Route>();
                    foreach (var c in data)
                    {
                       var temp = from item in c.RouteStops
                                   where item.StopId == (int)e.Parameter
                                   select item.Route;

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
                Route select = (Route)e.ClickedItem;
                Times.Rt = select.Id;
                Frame.Navigate(typeof(Times));
            }
        }
    }

}

