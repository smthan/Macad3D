using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace Macad.Presentation;

[ContentProperty("Converters")]
public class GroupConverter : MarkupExtension, IValueConverter, IMultiValueConverter
{
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }

    //--------------------------------------------------------------------------------------------------

    public IMultiValueConverter MultiValueConverter { get; set; }

    public List<IValueConverter> Converters { get; set; } = new List<IValueConverter>();

    //--------------------------------------------------------------------------------------------------

    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return GroupConvert(value, Converters, parameter, culture);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var cvts = Converters.ToArray();
        cvts.Reverse();
        return GroupConvertBack(value, cvts, parameter, culture);
    }

    static object GroupConvert(object value, IEnumerable<IValueConverter> converters, object parameter, CultureInfo culture)
    {
        return converters.Aggregate(value, (acc, conv) => conv.Convert(acc, typeof(object), parameter, culture));
    }

    static object GroupConvertBack(object value, IEnumerable<IValueConverter> converters, object parameter, CultureInfo culture)
    {
        return converters.Aggregate(value, (acc, conv) => conv.ConvertBack(acc, typeof(object), parameter, culture));
    }

    #endregion

    #region IMultiValueConverter Members

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (MultiValueConverter == null) throw new InvalidOperationException("To use the converter as a MultiValueConverter the MultiValueConverter property needs to be set."); 
        var firstConvertedValue = MultiValueConverter.Convert(values, targetType, parameter, culture);
        return GroupConvert(firstConvertedValue, Converters, parameter, culture);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        if (MultiValueConverter == null) throw new InvalidOperationException("To use the converter as a MultiValueConverter the MultiValueConverter property needs to be set."); 
        var cvts = Converters.ToArray();
        cvts.Reverse();
        var tailConverted = GroupConvertBack(value, cvts, parameter, culture);
        return MultiValueConverter.ConvertBack(tailConverted, targetTypes, parameter, culture);
    }

    #endregion
}