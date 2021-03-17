namespace LapTimer.Forms.UI.Converters
{
    using MvvmCross.Forms.Converters;
    using System;
    using System.Globalization;

    /// <summary>
    /// TimeSpanToStringConverter.
    /// </summary>
    /// <seealso cref="MvvmCross.Forms.Converters.MvxFormsValueConverter{System.TimeSpan, System.String}" />
    public class TimeSpanToStringConverter : MvxFormsValueConverter<TimeSpan, string>
    {
        private const string DEFAULT_FORMAT = @"mm\:ss";

        protected override string Convert(TimeSpan value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(parameter is string format))
            {
                format = DEFAULT_FORMAT;
            }
            return value.ToString(format);
        }
    }
}