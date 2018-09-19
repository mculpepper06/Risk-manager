using System.Collections.Generic;
using System.Linq;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManager.DataAccess
{
    public class CountryRepository
    {
        public List<Country> GetCountries()
        {
            var context = PrmContext.BuildPrmContext();
            var countries = context.Countries.OrderBy(c => c.Name).ToList();
            return countries;
        }
    }
}
