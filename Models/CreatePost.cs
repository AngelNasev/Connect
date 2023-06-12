using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Connect.Models
{
    public class CreatePost
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please write something before you post it")]
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}