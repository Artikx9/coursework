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
using Microsoft.EntityFrameworkCore;


namespace MinskTS.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Metro : Page
    {
        public int hour;
        public string DayofWeek;
        public string Metr { get; set; }
        public string Context = "ИНТЕРВАЛ ДВИЖЕНИЯ МЕТРО: ";
        public string Context2 = " мин. ";
        public Metro()
        {
            this.InitializeComponent();

            
            hour = Convert.ToInt32(DateTime.Now.ToString("HH"));
            DayofWeek = DateTime.Now.DayOfWeek.ToString();
            this.Loaded += Metro_Loaded;
        }



        private void Metro_Loaded(object sender, RoutedEventArgs e)
        {
            using (MetroContext db = new MetroContext())
            {
                switch (DayofWeek)
                {
                    case "Friday":
                        foreach (Metr item in db.Metro)
                        {
                            if (item.Time == hour)
                            {
                                Metr = item.Friday.ToString();
                            }
                        }
                        
                        break;
                    case "Saturday":
                        foreach (Metr item in db.Metro)
                        {
                            if (item.Time == hour)
                            {
                                Metr = item.Saturday.ToString();
                            }
                        }
                       
                        break;
                    case "Sunday":
                        foreach (Metr item in db.Metro)
                        {
                            if (item.Time == hour)
                            {
                                Metr = item.Sunday.ToString();
                            }
                        }
                        
                        break;
                    default:
                        foreach (Metr item in db.Metro)
                        {
                            if(item.Time==hour)
                            {
                               Metr = item.WorkDays.ToString();
                            }
                        }
                       

                        break;

                }
                        bloText.Text =Context + Metr + Context2;

            }


        }

    

    }


   







}
