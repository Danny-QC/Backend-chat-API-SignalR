using System;
using System.Collections.Generic;

namespace Chat_API_SignalR.Models;

public partial class MessageChat
{
    public int? IdUser { get; set; }

    public int MessageId { get; set; }

    public string? TextMessage { get; set; }

    public int? IdMessageType { get; set; }

    public DateTime? SentHour { get; set; }

    public int? IdGroupChat { get; set; }

    public virtual GroupChat? IdGroupChatNavigation { get; set; }

    public virtual MessageType? IdMessageTypeNavigation { get; set; }

    public virtual UserChat? IdUserNavigation { get; set; }
}
