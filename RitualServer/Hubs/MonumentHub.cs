using Microsoft.AspNetCore.SignalR;

namespace RitualServer.Hubs
{
    public class MonumentHub : Hub
    {
        public async Task UpdateMonuments(double minPrice, double maxPrice)
        {
            await Clients.Caller.SendAsync("ReceiveMonumentsUpdate", minPrice, maxPrice);
        }
    }
}
