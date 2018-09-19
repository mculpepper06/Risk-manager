using System;
using System.Linq;

namespace PortfolioRiskManager.Domain
{
    public class Position
    {
        public int PositionId { get; set; }
        public int SecurityId { get; set; }
        public Security Security { get; set; }

        public decimal Shares { get; set; }
        public decimal Weight { get; set; }
        public int PortFolioId { get; set; }
        public Portfolio PortFolio { get; set; }

        public decimal MarketValue()
        {
            if (Security == null)
                throw new Exception("Security cannot be null");

            if (Security.Prices == null)
                throw new Exception("no prices");

            return Security.LastPrice * Shares;
        }
    }
}