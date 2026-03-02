namespace SignalRAspNetCoreTest01x02.Contracts
{
    /// <summary>
    /// SignalR 消息数据传输对象
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// 消息发送人
        /// </summary>
        public string Sender { get; set; } = string.Empty;

        /// <summary>
        /// 私聊接收人ID（私聊时使用）
        /// </summary>
        public string? Receiver { get; set; } = string.Empty;

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 消息时间戳（UTC 字符串）
        /// </summary>
        public string Timestamp { get; set; } = DateTime.UtcNow.ToString("O"); // ISO 8601 字符串

        /// <summary>
        /// 可选：消息类型，比如 "chat" / "system" / "notification"
        /// </summary>
        public string? MessageType { get; set; } = string.Empty;

        /// <summary>
        /// 可选：分组或房间
        /// </summary>
        public string? Group { get; set; } = string.Empty;
    }
}