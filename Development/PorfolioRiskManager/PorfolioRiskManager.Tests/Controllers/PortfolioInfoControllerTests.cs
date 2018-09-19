using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioRiskManagerWeb.Controllers;

namespace PorfolioRiskManager.Tests.Controllers
{
    [TestClass]
    public class PortfolioInfoControllerTests
    {
        [TestMethod]
        public void PortfolioInfoControllerWorksAsExpected()
        {
            var controller = new PortfolioInfoController();
            var results = controller.GetSectorWeights(1);
        }
    }
}
