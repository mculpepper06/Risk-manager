using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioRiskManager.Domain;

namespace PorfolioRiskManager.Tests.Service
{
    [TestClass]
    public class PortfolioConstructionTests
    {
        [TestMethod]
        public void CalculateMarketValue()
        {
            var position = new Position
            {
                PositionId = 1,
                Shares = 10,
                Security = new Security
                {
                    SecurityId = 1,
                    SecurityName = "IBM",
                    Prices = new List<Price>(),
                }
            };
            position.Security.Prices.Add(new Price
            {
                PriceId = 1,
                SecurityPrice = 10m,
                AsOfDate = new DateTime(2018, 06, 01, 12, 00, 00)
            });
            Assert.AreEqual(100m, position.MarketValue());
        }


        [TestMethod]
        public void BuildAndCalculateWeightsWorksAsExpected()
        {
            List<Position> positions = new List<Position>();
            var position1 = new Position
            {
                PositionId = 1,
                Shares = 10,
                Security = new Security
                {
                    SecurityId = 1,
                    SecurityName = "IBM",
                    Prices = new List<Price>(),
                }
            };
            position1.Security.Prices.Add(new Price
            {
                PriceId = 1,
                SecurityPrice = 10m,
                AsOfDate = new DateTime(2018, 06, 01, 12, 00, 00)
            });

            positions.Add(position1);

            var position2 = new Position
            {
                PositionId = 2,
                Shares = 20,
                Security = new Security
                {
                    SecurityId = 2,
                    SecurityName = "MSFT",
                    Prices = new List<Price>()
                }
            };
            position2.Security.Prices.Add(new Price
            {
                PriceId = 2,
                SecurityPrice = 20m,
                AsOfDate = new DateTime(2018, 06, 01, 12, 00, 00)
            });

            positions.Add(position2);
            var portfolio = new Portfolio(positions);
            Assert.AreEqual(2, portfolio.Positions.Count);

            var weightedPositions = portfolio.Positions;
            Assert.AreEqual(.2m, weightedPositions[0].Weight);
            Assert.AreEqual(.8m, weightedPositions[1].Weight);
        }
    }
}
