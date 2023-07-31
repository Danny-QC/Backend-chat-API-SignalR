using System;
using System.Collections.Generic;

namespace Chat_API_SignalR.Models;

public partial class MessageType
{
    public int IdMessageType { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<MessageChat> MessageChats { get; set; } = new List<MessageChat>();
}
