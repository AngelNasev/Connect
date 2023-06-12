using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Models
{
    public class PendingVM
    {
        public int ConnectionId { get; set; }
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public string FriendUsername { get; set; }
        public bool FromMe { get; set; }
    }
}