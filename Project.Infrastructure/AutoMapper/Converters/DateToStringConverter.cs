using AutoMapper;
using System;

namespace Project.Infrastructure.AutoMapper.Converters
{
    /// <summary>
    /// Convert date to string
    /// </summary>
    public class DateToStringConverter : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime source, ResolutionContext context)
            => source.ToString("yyyy-MM-dd");
    }
}