using System;
using System.Threading;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using PortfolioRiskManager.DataAccess;
using PortfolioRiskManagerWeb.ClientUpdate;

namespace PortfolioRiskManagerWeb.Controllers
{
    /******************************************
	* Author: Fabian Valencia******************
	* Start: 07/23/18**************************
	* Update: 08/04/18*************************
	******************************************/
    [System.Web.Mvc.Authorize]
    public class PriceRefreshController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Submit()
        {
            var repo = new SecurityRepository();
            var securities = repo.GetAllSecurities();
            var priceRepo = new PriceRepository();

            foreach (var security in securities)
            {
                priceRepo.RefreshForSecurity(security);
                Thread.Sleep(3000);
            }

            var context = GlobalHost.ConnectionManager.GetHubContext<ContosoChatHub>();
            context.Clients.All.addContosoChatMessageToPage("Prices have been updated successfully at: " + DateTime.Now);

            return View();
        }
    }
}