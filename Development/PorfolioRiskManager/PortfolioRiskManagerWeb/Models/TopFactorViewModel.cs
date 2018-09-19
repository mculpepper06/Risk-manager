using System.Collections.Generic;
using System.Linq;
using PortfolioRiskManager.Domain;

namespace PortfolioRiskManagerWeb.Models
{
    public class TopFactorViewModel
    {
        public TopFactorViewModel(List<Portfolio.WeightValue> weights, List<Position> portfolioPositions)
        {
            Weights = weights;
            Positions = new List<PositionViewModel>();
            foreach (var portfolioPosition in portfolioPositions.OrderBy(p => p.Security.SecurityName))
            {
                Positions.Add(new PositionViewModel(portfolioPosition));
            }
        }

        public List<Portfolio.WeightValue> Weights { get; set; }
        public List<PositionViewModel> Positions { get; set; }

    }
}