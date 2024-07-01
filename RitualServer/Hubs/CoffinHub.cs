using Microsoft.AspNetCore.SignalR;

namespace RitualServer.Hubs
{
    public class CoffinHub : Hub
    {
        public async Task UpdateCoffins(double minPrice, double maxPrice)
        {
            await Clients.Caller.SendAsync("ReceiveCoffinsUpdate", minPrice, maxPrice);
        }
    }
}
