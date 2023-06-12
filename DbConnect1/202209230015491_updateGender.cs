namespace Connect.DbConnect
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGender : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Gender");
        }
        
        public override void Down()
        {
        }
    }
}
