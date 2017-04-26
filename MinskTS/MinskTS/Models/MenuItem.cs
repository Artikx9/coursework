using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml.Controls;

namespace MinskTS.Models
{
    class MenuItem : ViewModelBase
    {
        public string Title { get; set; }

        public string SymbolIcon { get; set; }

        public Type NavigateTo { get; set; }

        public int Timer { get; set; }
    }
}
