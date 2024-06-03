using Microsoft.AspNetCore.SignalR;

namespace ProjectVet.SignalR
{
    public class RandevuHub :Hub
    {
        public async Task SendRandevuCreatedNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveRandevuCreatedNotification", message);
        }
    }
}
