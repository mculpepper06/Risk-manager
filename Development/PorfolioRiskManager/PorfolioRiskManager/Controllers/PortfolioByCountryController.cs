using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioRiskManager.DataAccess;
using PortfolioRiskManager.Domain;

namespace PorfolioRiskManager.Controllers
{
    public class PortfolioByCountryController : Controller
    {
        // GET: PortfolioByCountry
        public ActionResult Index()
        {
            Portfolio portfolio = new PortfolioRepository().GetPortfoliosById(1);
            var countryWegiths = portfolio.Positions.GroupBy(p => p.Security.Country)
                .Select(s => new {Country = s.Key, Weight = s.Sum(p => p.Weight)});
            return View(countryWegiths);
        }
    }
}