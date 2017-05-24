using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using MinskTS.Models;


namespace MinskTS.Views
{
    public sealed partial class Metros : Page
    {
        private int hour;
        private string DayofWeek;
        private string Metr { get; set; }
        private string Context = "ИНТЕРВАЛ ДВИЖЕНИЯ МЕТРО: ";
        private string Context2 = " мин. ";
        public Metros()
        {
            this.InitializeComponent();
            this.Loaded += Metro_Loaded;
        }
        private void Metro_Loaded(object sender, RoutedEventArgs e)
        {
            CompositionTarget.Rendering += Time;
            
        }

        private void Time(object sender, object e)
        {

            hour = Convert.ToInt32(DateTime.Now.ToString("HH"));
            DayofWeek = DateTime.Now.DayOfWeek.ToString();
            using (MetroContext db = new MetroContext())
            {
                switch (DayofWeek)
                {
                    case "Friday":
                        foreach (Models.Metro item in db.Metro)
                        {
                            if (item.Time == hour)
                            {
                                Metr = item.Friday.ToString();
                            }
                        }
                        break;
                    case "Saturday":
                        foreach (Models.Metro item in db.Metro)
                        {
                            if (item.Time == hour)
                            {
                                Metr = item.Saturday.ToString();
                            }
                        }

                        break;
                    case "Sunday":
                        foreach (Models.Metro item in db.Metro)
                        {
                            if (item.Time == hour)
                            {
                                Metr = item.Sunday.ToString();
                            }
                        }
                        break;
                    default:
                        foreach (Models.Metro item in db.Metro)
                        {
                            if (item.Time == hour)
                            {
                                Metr = item.WorkDays.ToString();
                            }
                        }
                        break;
                }
                bloText.Text = Context + Metr + Context2;
            }
            
        }
    }
}
