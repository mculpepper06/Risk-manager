namespace PortfolioRiskManagerWeb.Models
{
    public class PortfolioViewModel
    {
        public PortfolioViewModel(int portfolioId, string name)
        {
            PortfolioId = portfolioId;
            Name = name;
        }

        public string Name { get; set; }
        public decimal PortfolioId { get; set; }
    }
}