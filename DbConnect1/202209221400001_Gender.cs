namespace Connect.DbConnect
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
        }
    }
}
