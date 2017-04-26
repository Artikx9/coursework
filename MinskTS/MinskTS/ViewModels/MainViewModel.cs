using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MinskTS.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using MinskTS.Views;

namespace MinskTS.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            MenuItems = new ObservableCollection<MenuItem>(GetMenuItems());
            SelectedMenuItem = MenuItems.FirstOrDefault();
        }

        public ObservableCollection<MenuItem> MenuItems { get; set; }

        private MenuItem selectedMenuItem;

        public MenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set { selectedMenuItem = value; RaisePropertyChanged(); }
        }

        private List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem() { Title = "Главная", SymbolIcon = "", NavigateTo = typeof(Home) });
            menuItems.Add(new MenuItem() { Title = "Остановки", SymbolIcon = "", NavigateTo = typeof(Stop) });
            menuItems.Add(new MenuItem() { Title = "Маршруты", SymbolIcon = "", NavigateTo = typeof(Route) });
            menuItems.Add(new MenuItem() { Title = "Метро", SymbolIcon = "", NavigateTo = typeof(Metro)  });
       



            return menuItems;
        }

    }
}
