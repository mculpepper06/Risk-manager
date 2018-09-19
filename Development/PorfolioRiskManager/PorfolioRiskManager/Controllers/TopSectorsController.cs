using System.Web.Mvc;
using PorfolioRiskManager.Models;
using PortfolioRiskManager.DataAccess;

namespace PorfolioRiskManager.Controllers
{
    public class TopSectorsController : Controller
    {
        // GET: TopSectors
        public ActionResult Index()
        {
            var repo = new PortfolioRepository();
            var portfolios = repo.GetAllPortfolios();
            var model = new TopSectorsViewModel(portfolios);
            return View(model);
        }
    }
}