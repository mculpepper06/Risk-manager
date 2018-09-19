using System.Collections.Generic;
using System.Linq;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManager.DataAccess
{
    public class IndustryRepository
    {
        public List<Industry> GetIndustries()
        {
            var context = PrmContext.BuildPrmContext();
            var industries = context.Industries.OrderBy(s => s.IndustryName).ToList();
            return industries;
        }
    }
}
