using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverter.Api.Enums;

namespace CurrencyConverter.Api
{
    public interface ICurrencyConverter
    {
        DateTime ValidityDate { get; }
        IEnumerable<CurrencyCode> SupportedCurrencies { get; }
        decimal ConversionRate(CurrencyCode fromRate, CurrencyCode toRate);
        decimal Convert(CurrencyCode fromRate, CurrencyCode toRate, decimal amount = 1);
    }
}
