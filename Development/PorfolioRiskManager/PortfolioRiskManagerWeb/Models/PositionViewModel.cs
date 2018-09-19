using System.Globalization;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManagerWeb.Models
{
    public class PositionViewModel
    {
        public PositionViewModel(Position position)
        {
            MarketValue = $"{position.MarketValue():C}";
            SecurityName = position.Security.SecurityName;
            MarketCap = position.Security.MarketCap.ToString("#,##0,,M", CultureInfo.InvariantCulture);
            SectorName = position.Security.Industry.SectorName;
            IndustryName = position.Security.Industry.IndustryName;
            Price = $"{position.Security.LastPrice:C}";
            Weight = position.Weight;
            CountryName = position.Security.Country.Name;
            Volume = position.Security.Volume;
            Shares = position.Shares;
        }

        public decimal Shares { get; set; }
        public string MarketCap { get; set; }
        public int Volume { get; set; }
        public string SecurityName { get; set; }
        public string SectorName { get; set; }
        public string IndustryName { get; set; }
        public string CountryName { get; set; }
        public string Price { get; set; }
        public decimal Weight { get; set; }
        public string MarketValue { get; set; }
    }
}