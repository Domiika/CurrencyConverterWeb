using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyConverter.Api.Enums;


namespace CurrencyConverter.Api.Models
{
    public class CurrencyRecord
    {
        [Index(2)]
        public int amount { get; set; }

        [Index(3)]
        public CurrencyCode currency { get; set; }

        [Index(4)]
        public decimal rate { get; set; }
    }
}
