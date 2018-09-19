using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;
using System.Web.Http;
using PortfolioRiskManager.DataAccess;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManagerWeb.Controllers
{
    public class AddSecurityToPortfolioController : ApiController
    {
        // POST: api/AddSecurityToPortfolio
        public void Post(List<string> val)
        {
            var name = val[0];
            var symbol = val[1];
            var shares = int.Parse(val[2]);
            var portfolioId = int.Parse(val[3]);
            var industryId = int.Parse(val[4]);
            var countryId = int.Parse(val[5]);
            var marketcap = decimal.Parse(val[6]);

            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                var securityRepository = new SecurityRepository();
                var portfolioRepo = new PortfolioRepository();
                var priceRepository = new PriceRepository();
                var security = securityRepository.GetSecurityBySymbol(symbol);
                if (security == null) // need to add a new security
                {
                    security = new Security
                    {
                        SecurityId = 0,
                        Symbol = symbol,
                        SecurityName = name,
                        CountryId = countryId,
                        IndustryId = industryId,
                        MarketCap = marketcap
                    };
                    securityRepository.AddSecurity(security);
                }

                portfolioRepo.AddPosition(security, portfolioId, shares);
                priceRepository.RefreshForSecurity(security);
                scope.Complete();
            }
            Debug.WriteLine(val);
        }
    }
}
