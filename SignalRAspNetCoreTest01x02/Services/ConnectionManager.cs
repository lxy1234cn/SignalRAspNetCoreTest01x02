using System.Collections.Concurrent;
namespace SignalRAspNetCoreTest01x02.Services
{
    public class ConnectionManager
    {
        // userId -> connectionId
        private readonly ConcurrentDictionary<string, string> _userConnections = new();

        public void AddConnection(string userId, string connectionId)
        {
            _userConnections[userId] = connectionId;
        }

        public void RemoveConnection(string connectionId)
        {
            var user = _userConnections.FirstOrDefault(x => x.Value == connectionId);
            if (!string.IsNullOrEmpty(user.Key))
            {
                _userConnections.TryRemove(user.Key, out _);
            }
        }

        public string? GetConnection(string userId)
        {
            return _userConnections.TryGetValue(userId, out var connId)
                ? connId
                : null;
        }
    }
}
