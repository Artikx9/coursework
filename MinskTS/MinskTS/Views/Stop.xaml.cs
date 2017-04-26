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
using System.Threading.Tasks;
// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace MinskTS.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Stop : Page
    {

       string items { get; set; }


        public Stop()
        {
            this.InitializeComponent();
            this.Loaded += Stop_Loaded;

        }
       
        private void Stop_Loaded(object sender, RoutedEventArgs e)
        {
            using (ScheduleContext db = new ScheduleContext())
            {
              scheduleList.ItemsSource = db.Stop.ToList();
              
            }
        }
        

      

        private  void suggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            using (ScheduleContext db = new ScheduleContext())
            {
                if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    
                    if (sender.Text.Length > 1)
                    {
                        List<string> list1 = new List<string>();
                       
                        scheduleList.ItemsSource = db.Stop.Where(x => x.Name.Contains(suggestBox.Text));
                    }
                    else
                    {
                        scheduleList.ItemsSource = db.Stop.ToList();
                    }
                }
            }
        }
        
        private  void ScheduleList_ItemClick(object sender, ItemClickEventArgs e2)
        {
            Stops selected = (Stops)e2.ClickedItem;
            Frame.Navigate(typeof(StopRoute), selected.Id);

        }



    }
}
