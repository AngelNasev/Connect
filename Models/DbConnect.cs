using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Connect.Models
{
    public class DbConnect : DbContext
    {
        public DbConnect() : base("name=DbConnect")
        {}
        public DbSet<CreatePost> Posts { get; set; }
        public DbSet<Connection> EstablishedConnections { get; set; }
        public DbSet<PendingRequests> PendingRequests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}