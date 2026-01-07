using System.Collections;
using CurrencyConverter.Api.Enums;

namespace CurrencyConverter.Api.Dtos.Currency
{
    public class CurrencyInfoResponse
    {
        public IEnumerable<string> SupportedCurrencies { get; set; }
        public DateTime ValidityDate { get; set; }
    }
}
