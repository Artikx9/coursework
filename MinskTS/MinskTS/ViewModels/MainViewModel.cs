using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using MinskTS.Models;
using System.Collections.ObjectModel;
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
            set { selectedMenuItem = value; RaisePropertyChanged(); MainPage.Title = "";}
        }

        private List<MenuItem> GetMenuItems()
        {
            
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem() { Title = "Главная", SymbolIcon = "", NavigateTo = typeof(Home) },
                new MenuItem() { Title = "Остановки", SymbolIcon = "", NavigateTo = typeof(Stops) },
                new MenuItem() { Title = "Маршруты", SymbolIcon = "", NavigateTo = typeof(Routes) },
                new MenuItem() { Title = "Метро", SymbolIcon = "", NavigateTo = typeof(Metros) },
                new MenuItem() { Title = "Настройки", SymbolIcon = "", NavigateTo = typeof(Setting) }
            };
            return menuItems;
        }

    }
}
