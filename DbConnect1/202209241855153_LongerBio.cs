namespace Connect.DbConnect
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LongerBio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Bio", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Bio", c => c.String(maxLength: 50));
        }
    }
}
