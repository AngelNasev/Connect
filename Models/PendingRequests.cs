using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Connect.Models
{
    public class PendingRequests
    {
        [Key]
        public int ConnectionId { get; set; }
        public string User1Id { get; set; }
        public string User2Id { get; set; }
    }
}