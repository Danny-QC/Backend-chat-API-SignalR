using System;
using System.Collections.Generic;

namespace Chat_API_SignalR.Models;

public partial class GroupChat
{
    public int IdGroupChat { get; set; }

    public string? GroupName { get; set; }

    public DateTime? GroupCreation { get; set; }

    public virtual ICollection<MessageChat> MessageChats { get; set; } = new List<MessageChat>();
}
