using System;

namespace PortfolioRiskManager.Domain
{
    public class Price
    {
        public int PriceId { get; set; }
        public int SecurityId { get;set; }
        public decimal SecurityPrice { get; set; }
        public DateTime AsOfDate { get; set; }
        public Security Security{ get; set; }
        public int Volume { get; set; }
    }
}