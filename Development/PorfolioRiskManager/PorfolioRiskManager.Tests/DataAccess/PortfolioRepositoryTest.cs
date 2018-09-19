using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioRiskManager.DataAccess;

namespace PorfolioRiskManager.Tests.DataAccess
{
    [TestClass]
    public class PortfolioRepositoryTest
    {
        [TestMethod]
        public void GetPortoliosWorksAsExpected()
        {
            var repo = new PortfolioRepository();
            var portfolios = repo.GetPortfoliosByName("Mi");
            Assert.IsTrue(portfolios.Count > 0);
        }

        [TestMethod]
        public void GetAllPortfoliosWorksAsExpected()
        {
            PortfolioRepository portfolioRepository = new PortfolioRepository();
            var portfolios = portfolioRepository.GetAllPortfolios();
            Assert.AreEqual(5, portfolios.Count);
            Assert.AreEqual("Miranda Holdings", portfolios[0].PortfolioName);
        }

        [TestMethod]
        public void GetPortfolioByPortfolioIdWorksAsExpected()
        {
            PortfolioRepository portfolioRepository = new PortfolioRepository();
            var portfolio = portfolioRepository.GetPortfoliosById(1);
            Assert.AreEqual("Miranda Holdings", portfolio.PortfolioName);
            Assert.AreEqual(2, portfolio.Positions.Count);
        }
    }
}
