using Microsoft.AspNetCore.SignalR;
using SignalRAspNetCoreTest01x02.Contracts;
using SignalRAspNetCoreTest01x02.Services;

namespace SignalRAspNetCoreTest01x02.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ConnectionManager _registry;
        public ChatHub(ConnectionManager registry) => _registry = registry;

        //确保每条消息都有 Timestamp
        private void EnsureTimestamp(MessageDto msg)
        {
            if (string.IsNullOrEmpty(msg.Timestamp))
                msg.Timestamp = DateTime.UtcNow.ToString("O"); // ISO 8601
        }

        public override Task OnConnectedAsync()
        {
            var userId = Context.GetHttpContext()?.Request.Query["userId"];
            if (!string.IsNullOrEmpty(userId))
                _registry.AddConnection(userId!, Context.ConnectionId);

            // 告诉客户端当前 ConnectionId
            Clients.Caller.SendAsync("ConnectionAck", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? ex)
        {
            _registry.RemoveConnection(Context.ConnectionId);
            return base.OnDisconnectedAsync(ex);
        }

        // 广播消息
        public Task BroadcastMessage(MessageDto msg)
        {
            EnsureTimestamp(msg);
            return Clients.All.SendAsync("ReceiveMessage", msg);
        }

        // 单发消息
        public Task SendMessageToUser(string targetConnectionId, MessageDto msg)
        {
            EnsureTimestamp(msg);
            return Clients.Client(targetConnectionId).SendAsync("ReceiveMessage", msg);
        }

        // 加入组
        public Task JoinGroup(string groupName) => Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        
        // 退出组
        public Task LeaveGroup(string groupName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
        // 向组发送消息
        public Task SendMessageToGroup(string groupName, MessageDto msg)
        {
            EnsureTimestamp(msg);
            return Clients.Group(groupName).SendAsync("ReceiveMessage", msg);
        }
    }
}