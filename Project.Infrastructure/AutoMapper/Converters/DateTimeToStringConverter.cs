using AutoMapper;
using System;

namespace Project.Infrastructure.AutoMapper.Converters
{
    /// <summary>
    /// Convert datetime to string
    /// </summary>
    public class DateTimeToStringConverter : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime source, ResolutionContext context)
            => source.ToString("yyyy-MM-dd HH:mm:ss");
    }
}