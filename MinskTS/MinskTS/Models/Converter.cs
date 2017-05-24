using System;
using Windows.UI.Xaml.Data;

namespace MinskTS.Models
{


    public class Converter : IValueConverter
    {

            public object Convert(object value, Type targetType, object parameter, string language)
            {
                switch ((Types)value)
                {
                    case Types.Bus:
                        return "/Assets/bus.png";
                    case Types.Tramway:
                        return "/Assets/Tramway.png";
                    case Types.Trolleybus:
                        return "/Assets/Trolleybus.png";
                    default:
                        return null;
                }

            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
    }

}
