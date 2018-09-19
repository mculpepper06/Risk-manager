using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManager.DataAccess
{
    public class PortfolioRepository
    {
        public List<Portfolio> GetPortfoliosByName(string portfolioName)
        {
            var repo = BuildPrmContext();
            var portfolios = repo.Portfolio.
                Where(p => p.PortfolioName.StartsWith(portfolioName)).
                ToList();
            return portfolios;
        }

        public List<Portfolio> GetAllPortfolios()
        {
            var repo = BuildPrmContext();
            var portfolios = repo.Portfolio.AsEnumerable().ToList();
            return portfolios;
        }

        private static PrmContext BuildPrmContext()
        {
            var repo = new PrmContext();
            return repo;
        }

        public Portfolio GetPortfoliosById(int portfolioId)
        {
            var repo = BuildPrmContext();
            var portfolio = repo.Portfolio.
                Include(portf => portf.Positions).
                    ThenInclude(pos => pos.Security).
                        ThenInclude(sec => sec.Prices).
                Include(portf => portf.Positions).
                    ThenInclude(pos => pos.Security).
                        ThenInclude(sec => sec.Industry).
                Include(portf => portf.Positions).
                    ThenInclude(pos => pos.Security).
                        ThenInclude(sec => sec.Country).
                First(p => p.PortfolioId == portfolioId);

            portfolio.CalculateWeights();

            return portfolio;
        }

        public void AddPosition(Security security, int portfolioId, int shares)
        {
            var repo = BuildPrmContext();
            repo.Position.Add(new Position
            {
                PortFolioId = portfolioId,
                SecurityId = security.SecurityId,
                Shares = shares
            });
            repo.SaveChanges();
        }
    }
}
