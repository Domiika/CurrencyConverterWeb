using CurrencyConverter.Api.Enums;

namespace CurrencyConverter.Api.Dtos.Currency
{
    public class ConvertResponse
    {
        public CurrencyCode From { get; set; }
        public CurrencyCode To { get; set; }
        public decimal Amount { get; set; }
        public decimal Result { get; set; }
    }
}
