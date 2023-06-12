using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Models
{
    public class ConnectionVM
    {
        public int ConnectionId { get; set; }
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public string FriendUsername { get; set; }
    }
}