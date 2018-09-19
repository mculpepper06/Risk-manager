using System.Web.Http;
using PortfolioRiskManager.DataAccess;
using PortfolioRiskManagerWeb.Models;

namespace PortfolioRiskManagerWeb.Controllers
{
    public class PortfolioInfoController : ApiController
    {
        public TopFactorViewModel GetSectorWeights(int id)
        {
            var repo = new PortfolioRepository();
            var portfolio = repo.GetPortfoliosById(id);
            var sectorWeights = portfolio.GetSectorWeights();
            
            return new TopFactorViewModel(sectorWeights, portfolio.Positions);
        }


        public TopFactorViewModel GetCountryWeights(int portoflioId)
        {
            var repo = new PortfolioRepository();
            var portfolio = repo.GetPortfoliosById(portoflioId);
            var sectorWeights = portfolio.GetCountryWeights();
            return new TopFactorViewModel(sectorWeights, portfolio.Positions);
        }

	
	}
}
