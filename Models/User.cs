using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Connect.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string Username { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        [MaxLength(150)]
        public string Bio { get; set; }
        public List<CreatePost> Posts = new List<CreatePost>();
        public List<Connection> Connections = new List<Connection>();
        public List<PendingRequests> PendingRequests = new List<PendingRequests>();

    }

        
}