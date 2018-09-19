using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManager.DataAccess
{
    public class SecurityRepository
    {
        private static PrmContext BuildPrmContext()
        {
            var repo = new PrmContext();
            return repo;
        }

        public List<Security> GetAllSecurities()
        {
            var repo = BuildPrmContext();
            return repo.Securities.ToList();
        }


        public Security GetSecurityBySymbol(string symbol)
        {
            return BuildPrmContext().Securities.FirstOrDefault(s => s.Symbol == symbol);
        }

        public void AddSecurity(Security security)
        {
            var repo = BuildPrmContext();
            repo.Securities.Add(security);
            repo.SaveChanges();
        }
    }
}
