using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace LoginDemo.App.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool Inverse { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // 'null' --> Collapse
            if (value == null)
                return Visibility.Collapsed;

            // True --> Visible
            // False --> Collapse
            if (!Inverse)
                return (bool)value
                    ? Visibility.Visible
                    : Visibility.Collapsed; 

            // True --> Collapse
            // False --> Collapse
            return (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
