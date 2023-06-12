namespace Connect.Default
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationApplicationDbContext : DbMigrationsConfiguration<Connect.Models.ApplicationDbContext>
    {
        public ConfigurationApplicationDbContext()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Default";
            ContextKey = "Connect.Models.ApplicationDbContext";
        }

        protected override void Seed(Connect.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
