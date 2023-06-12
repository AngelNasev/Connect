using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Connect.Models
{
    public class ProfileVM
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        [MaxLength(50)]
        public string Bio { get; set; }
        [Display(Name = "Number of connections")]
        public int NumConnections { get; set; } = 0;
        public IEnumerable<CreatePost> Posts = new List<CreatePost>();
        public IEnumerable<string> Friends = new List<string>();
        public IEnumerable<string> Pending = new List<string>();
    }
}