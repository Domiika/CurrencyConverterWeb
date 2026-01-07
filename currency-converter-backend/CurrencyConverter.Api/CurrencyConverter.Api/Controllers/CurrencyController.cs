using Microsoft.AspNetCore.Mvc;
using CurrencyConverter.Api.Enums;
using CurrencyConverter.Api.Dtos.Currency;

namespace CurrencyConverter.Api.Controllers
{
    [ApiController]
    [Route("api/currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyConverter _converter;

        public CurrencyController(ICurrencyConverter converter)
        {
            _converter = converter;
        }

        [HttpGet("info")]
        public IActionResult Info()
        {
            var supportedCurrencies = _converter.SupportedCurrencies.Select(c => c.ToString());
            var validityDate = _converter.ValidityDate;
            return Ok(new CurrencyInfoResponse
            {
                SupportedCurrencies = supportedCurrencies,
                ValidityDate = validityDate
            });
        }

        [HttpGet("convert")]
        public IActionResult Convert(
            [FromQuery] CurrencyCode from,
            [FromQuery] CurrencyCode to,
            [FromQuery] decimal amount = 1)
        {
            var result = _converter.Convert(from, to, amount);

            return Ok(new ConvertResponse
            {
                From = from,
                To = to,
                Amount = amount,
                Result = result
            });
        }
    }
}
