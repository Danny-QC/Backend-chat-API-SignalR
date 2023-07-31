using System;
using System.Collections.Generic;

namespace Chat_API_SignalR.Models;

public partial class GroupDetailChat
{
    public int? IdUser { get; set; }

    public int? IdGroupChat { get; set; }

    public DateTime? Joined { get; set; }

    public DateTime? Left { get; set; }

    public virtual GroupChat? IdGroupChatNavigation { get; set; }

    public virtual UserChat? IdUserNavigation { get; set; }
}
