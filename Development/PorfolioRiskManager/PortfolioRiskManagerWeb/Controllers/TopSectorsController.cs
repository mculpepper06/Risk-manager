using System.Linq;
using System.Web.Mvc;
using PortfolioRiskManager.DataAccess;
using PortfolioRiskManagerWeb.Models;

namespace PortfolioRiskManagerWeb.Controllers
{
    public class TopSectorsController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var repo = new PortfolioRepository();
            var portfolios = repo.GetAllPortfolios().Select(p => new PortfolioViewModel(p.PortfolioId, p.PortfolioName)).ToList();
            portfolios.Insert(0, new PortfolioViewModel(0, "Please select a portfolio"));
            return View(portfolios);
        }
    }
}