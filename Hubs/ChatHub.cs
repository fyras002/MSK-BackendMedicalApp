using Microsoft.AspNetCore.SignalR;

namespace MedicalAppBackend.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinChat(string chatId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task LeaveChat(string chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task SendMessage(string chatId, int senderId, string senderName, string message)
        {
            await Clients.Group(chatId).SendAsync("ReceiveMessage", new
            {
                senderId,
                senderName,
                message,
                timestamp = DateTime.UtcNow
            });
        }
    }
}