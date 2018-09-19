using System.Collections.Generic;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManagerWeb.Models
{
    public class NewSecurityModel
    {
        public List<Country> Countries { get; set; }
        public List<Industry> Industries { get; set; }
        public List<PortfolioViewModel> Portfolios { get; set; }
    }
}