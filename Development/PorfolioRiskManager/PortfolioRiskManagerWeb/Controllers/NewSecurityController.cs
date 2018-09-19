using System.Linq;
using System.Web.Mvc;
using PortfolioRiskManager.DataAccess;
using PortfolioRiskManagerWeb.Models;

namespace PortfolioRiskManagerWeb.Controllers
{
    /******************************************
	* Author: Fabian Valencia******************
	* Start: 08/19/18 **************************
	* Update: 08/20/18 *************************
	******************************************/
    [Authorize]
    public class NewSecurityController : Controller
    {
        // GET: NewSecurity
        public ActionResult Index()
        {
            var newSecurityModel = new NewSecurityModel();
            var countryRepo = new CountryRepository();
            var industryRepo = new IndustryRepository();
            var portfolioRepository = new PortfolioRepository();
            newSecurityModel.Industries = industryRepo.GetIndustries();
            newSecurityModel.Countries = countryRepo.GetCountries();
            newSecurityModel.Portfolios = portfolioRepository.GetAllPortfolios().Select(p => new PortfolioViewModel(p.PortfolioId, p.PortfolioName)).ToList();
            return View(newSecurityModel);
        }
    }


}