using System;
using System.Collections.Generic;

namespace Chat_API_SignalR.Models;

public partial class UserChat
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public bool? ConectedUser { get; set; }

    public virtual ICollection<MessageChat> MessageChats { get; set; } = new List<MessageChat>();
}
