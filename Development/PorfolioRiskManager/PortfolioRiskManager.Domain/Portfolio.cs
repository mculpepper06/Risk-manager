using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PortfolioRiskManager.Domain
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Portfolio
    {
        public Portfolio(List<Position> list)
        {
            Positions = new List<Position>();
            list.ForEach(p => Positions.Add(p));
            CalculateWeights();
        }

        /// <summary>
        /// EF required
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public Portfolio()
        {
        }

        public int PortfolioId { get; set; }

        public string PortfolioName { get; set; }

        public decimal? PortfolioBalance { get; set; }

        public decimal? Cash { get; set; }

        public List<Position> Positions { get; set; }

        public void CalculateWeights()
        {
            var totalMarketValue = 0m;
            foreach (var pos in Positions)
            {
                totalMarketValue = pos.MarketValue() + totalMarketValue;
            }

            foreach (var pos in Positions)
            {
                pos.Weight = pos.MarketValue() / totalMarketValue;
            }
        }

        public List<WeightValue> GetSectorWeights()
        {
            CalculateWeights();
            var results = Positions
                .GroupBy(p => p.Security.Industry.SectorName, p => p.Weight)
                .Select(g => new WeightValue(g.Key, g.Sum())).ToList();

            return results;
        }
        public class WeightValue
        {
            public WeightValue(string name, decimal weight)
            {
                Name = name;
                Weight = weight;
            }

            public string Name { get; set; }
            public decimal Weight { get; set; }
        }

        public void SetPositions(List<Position> positions)
        {
            Positions = positions;
        }

        public List<WeightValue> GetCountryWeights()
        {
            CalculateWeights();
            var results = Positions
                .GroupBy(p => p.Security.Country.Name, p => p.Weight)
                .OrderBy(p => p.Key)
                .Select(g => new WeightValue(g.Key, g.Sum())).ToList();

            return results;
        }
	}
}