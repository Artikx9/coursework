using System;
using GalaSoft.MvvmLight;

namespace MinskTS.Models
{
    class MenuItem : ViewModelBase
    {
        public string Title { get; set; }
        public string SymbolIcon { get; set; }
        public Type NavigateTo { get; set; }
        
    }
}
