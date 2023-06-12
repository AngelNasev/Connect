using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Connect.Models
{
    public class PendingAndEstablishedVM
    {
        public string UserId { get; set; }
        public IEnumerable<PendingVM> PendingVM { get; set; }
        public IEnumerable<ConnectionVM> ConnectionVM { get; set; }
    }
}