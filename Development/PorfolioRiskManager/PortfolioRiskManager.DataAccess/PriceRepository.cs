using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManager.DataAccess
{
    public class PriceRepository
    {
        private const string _url = @"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&datatype=csv&symbol={0}&apikey=LAFULKFPHB4JM7FA";

        private static PrmContext BuildPrmContext()
        {
            var repo = new PrmContext();
            return repo;
        }

        public void UpdatePrice(Price newPrice)
        {
            var repo = BuildPrmContext();
            var price = repo.Prices.FirstOrDefault(p => p.AsOfDate == newPrice.AsOfDate && p.SecurityId == newPrice.SecurityId);
            if (price == null) // new price
            {
                repo.Prices.Add(newPrice);
                repo.SaveChanges();
            }
            else // existing price
            {
                price.SecurityPrice = newPrice.SecurityPrice;
            }
        }

        public Price GetLastPrice(Security security)
        {
            return BuildPrmContext().Prices
                .Where(p => p.SecurityId == security.SecurityId)
                .OrderByDescending(p => p.AsOfDate)
                .FirstOrDefault();
        }

        public void RefreshForSecurity(Security security)
        {
            try
            {
                var lastPrice = GetLastPrice(security);
                if (lastPrice != null && lastPrice.AsOfDate == DateTime.Today)
                    return;

                WebClient request = new WebClient();

                var address = string.Format(_url, security.Symbol);
                var response = request.DownloadString(address);

                var content = Regex.Split(response, @"\r\n");
                if (content.Length >= 2 && content[1] != null)
                {
                    //timestamp,open,high,low,close,volume
                    var priceInfo = content[1].Split(',');
                    var timestamp = DateTime.Parse(priceInfo[0]);
                    var close = Decimal.Parse(priceInfo[4]);
                    var volume = int.Parse(priceInfo[5]);

                    // save price
                    Price price = new Price
                    {
                        SecurityPrice = close,
                        SecurityId = security.SecurityId,
                        AsOfDate = timestamp,
                        Volume = volume
                    };
                    UpdatePrice(price);
                }
                else
                {
                    Debug.WriteLine(@"Data not loaded for security: {0}", security.Symbol);
                }
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}