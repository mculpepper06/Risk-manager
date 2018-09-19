using Microsoft.AspNet.SignalR;

namespace PortfolioRiskManagerWeb.ClientUpdate
{
    public class ContosoChatHub : Hub
    {
        public void NewContosoChatMessage(string name, string message)
        {
            Clients.All.addContosoChatMessageToPage(name, message);
        }
    }
}