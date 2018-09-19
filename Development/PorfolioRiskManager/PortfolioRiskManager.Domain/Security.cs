using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PortfolioRiskManager.Domain
{
    public class Security
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SecurityId { get; set; }
        public List<Price> Prices { get; set; }

        public Country Country { get; set; }
        public Industry Industry { get; set; }
        public string SecurityName { get; set; }
        public int IndustryId { get; set; }
        public int CountryId { get; set; }
        public decimal MarketCap { get; set; }

        public int Volume
        {
            get
            {
                var lastPrice = Prices.OrderByDescending(p => p.AsOfDate).FirstOrDefault();
                if (lastPrice == null)
                    return 0;
                return lastPrice.Volume;
            }
        }

        public string Symbol { get; set; }

        public decimal LastPrice
        {
            get
            {
                var lastPrice = Prices.OrderByDescending(p => p.AsOfDate).FirstOrDefault();
                if (lastPrice == null)
                    return 0;
                return lastPrice.SecurityPrice;
            }
        }

        
    }
}