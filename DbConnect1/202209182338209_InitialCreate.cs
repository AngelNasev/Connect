namespace Connect.DbConnect
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        ConnectionId = c.Int(nullable: false, identity: true),
                        User1Id = c.String(),
                        User2Id = c.String(),
                    })
                .PrimaryKey(t => t.ConnectionId);
            
            CreateTable(
                "dbo.PendingRequests",
                c => new
                    {
                        ConnectionId = c.Int(nullable: false, identity: true),
                        User1Id = c.String(),
                        User2Id = c.String(),
                    })
                .PrimaryKey(t => t.ConnectionId);
            
            CreateTable(
                "dbo.CreatePosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        AuthorId = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Username = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Bio = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.CreatePosts");
            DropTable("dbo.PendingRequests");
            DropTable("dbo.Connections");
        }
    }
}
