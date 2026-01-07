using CsvHelper;
using CsvHelper.Configuration;
using CurrencyConverter.Api;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverter.Api.Enums;
using CurrencyConverter.Api.Models;


namespace CurrencyConverter.Api
{
    public class CNBCurrencyConverter : ICurrencyConverter
    {
        private readonly HttpClient _httpClient;
        string url = "https://www.cnb.cz/cs/financni-trhy/devizovy-trh/kurzy-devizoveho-trhu/kurzy-devizoveho-trhu/denni_kurz.txt";
        IDictionary<CurrencyCode, decimal> _rates = new Dictionary<CurrencyCode, decimal>();
        public IEnumerable<CurrencyCode> SupportedCurrencies => _rates.Keys;
        public DateTime ValidityDate { get; private set; }

        public CNBCurrencyConverter(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Refresh();
        }

        public void Refresh()
        {
            try
            {
                using (var result = _httpClient.GetAsync(url).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var response = result.Content.ReadAsStringAsync().Result;
                        ValidityDate = DateTime.ParseExact(response.Substring(0, 10), "dd.MM.yyyy", null).AddHours(14).AddMinutes(30);
                        //ParseToDict(response);

                        _rates = new Dictionary<CurrencyCode, decimal>();

                        var config = new CsvConfiguration(new CultureInfo("cs-CZ"))
                        {
                            Delimiter = "|",
                            HasHeaderRecord = true
                        };

                        using var reader = new StringReader(response);
                        using var csv = new CsvReader(reader, config);

                        csv.Read();

                        var records = csv.GetRecords<CurrencyRecord>().ToList();

                        foreach (var record in records)
                        {
                            _rates[record.currency] = record.rate / record.amount;
                        }

                        _rates[CurrencyCode.CZK] = 1;
                    }
                }
            }
            catch (HostNotReachedException)
            {
                Console.WriteLine("Host could not be reached");
            }
        }

        //public void parsetodict(string response)
        //{
        //    var lines = response.split('\n');

        //    foreach (string l in lines.skip(2))
        //    {
        //        var parts = l.trim().split('|');
        //        if (parts.length != 5) continue;

        //        decimal amount = decimal.parse(parts[2], cultureinfo.invariantculture);
        //        decimal rate = decimal.parse(parts[4], new cultureinfo("cs-cz"));

        //        _rates[parts[3]] = rate / amount;
        //    }
        //}

        public decimal ConversionRate(CurrencyCode fromRate, CurrencyCode toRate)
        {
            if (!_rates.ContainsKey(fromRate))
            {
                throw new CurrencyNotSupported($"{fromRate} is not supported");
            }
            if (!_rates.ContainsKey(toRate))
            {
                throw new CurrencyNotSupported($"{toRate} is not supported");
            }

            return _rates[fromRate] / _rates[toRate];
        }

        public decimal Convert(CurrencyCode fromRate, CurrencyCode toRate, decimal amount = 1)
        {
            decimal result = ConversionRate(fromRate, toRate) * amount;
            return result;
        }
    }
}
