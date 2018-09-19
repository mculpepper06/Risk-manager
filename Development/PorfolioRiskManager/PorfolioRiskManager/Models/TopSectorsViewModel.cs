using System.Collections.Generic;
using PortfolioRiskManager.Domain;

namespace PorfolioRiskManager.Models
{
    public class TopSectorsViewModel
    {
        public List<PortfolioViewModel> Portfolios = new List<PortfolioViewModel>();

        public TopSectorsViewModel(List<Portfolio> portfolios)
        {
            portfolios.ForEach(p => 
                Portfolios.Add(
                    new PortfolioViewModel
                    {
                        PortfolioId = p.PortfolioId,
                        Name = p.PortfolioName
                    } ));
        }

        
    }

    public class PortfolioViewModel
    {
        public int PortfolioId { get; set; }
        public string Name { get; set; }
    }
}