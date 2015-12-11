using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

using static System.Windows.Visibility;

namespace Coolkit.Converters
{
    public class BooleanToVisibilityConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is bool))
                return DependencyProperty.UnsetValue;

            var castedValue = (bool)value;
            return castedValue ? Visible : Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => DependencyProperty.UnsetValue;

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}