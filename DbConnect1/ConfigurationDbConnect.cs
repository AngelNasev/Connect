namespace Connect.DbConnect
{
    using Connect.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationDbConnect : DbMigrationsConfiguration<Connect.Models.DbConnect>
    {
        public ConfigurationDbConnect()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DbConnect1";
            ContextKey = "Connect.Models.DbConnect";
        }

        protected override void Seed(Connect.Models.DbConnect context)
        {
            context.Posts.AddOrUpdate(i => i.Id,
                new CreatePost() { Id = 1, Text = "This is my first Post", AuthorId = "asd", CreatedAt = DateTime.Now },
                new CreatePost() { Id = 2, Text = "Hi Connect!", AuthorId = "1", CreatedAt = DateTime.Now });
            context.EstablishedConnections.AddOrUpdate(i => i.ConnectionId,
                new Connection() { ConnectionId = 1, User1Id = "1", User2Id = "1db221eb-059b-402a-8b12-d1b16b80ec7e" },
                new Connection() { ConnectionId = 2, User1Id = "1", User2Id = "1827d319-8007-4eb3-bdf4-c52330f280e9" },
                new Connection() { ConnectionId = 3, User1Id = "1", User2Id = "6db112c3-0931-4811-b85e-551934b94953" },
                new Connection() { ConnectionId = 4, User1Id = "1", User2Id = "91f102cd-b7ec-468a-bfda-fc495745ee91" });
            context.PendingRequests.AddOrUpdate(i => i.ConnectionId,
                new PendingRequests() { ConnectionId = 1, User1Id = "1db221eb-059b-402a-8b12-d1b16b80ec7e", User2Id = "1827d319-8007-4eb3-bdf4-c52330f280e9" },
                new PendingRequests() { ConnectionId = 2, User1Id = "6db112c3-0931-4811-b85e-551934b94953", User2Id = "1827d319-8007-4eb3-bdf4-c52330f280e9" });
            
        }
    }
}
