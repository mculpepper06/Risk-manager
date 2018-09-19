using System.Web.Http;
using PortfolioRiskManager.DataAccess;
using PortfolioRiskManagerWeb.Models;

namespace PortfolioRiskManagerWeb.Controllers
{
    public class CountryInfoController : ApiController
    {
        public TopFactorViewModel GetCountryWeights(int id)
        {
            var repo = new PortfolioRepository();
            var portfolio = repo.GetPortfoliosById(id);
            var sectorWeights = portfolio.GetCountryWeights();
            return new TopFactorViewModel(sectorWeights, portfolio.Positions);
        }
    }
}
