namespace WashMyCar.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Detailers", "Latitude", c => c.Double());
            AlterColumn("dbo.Detailers", "Longitude", c => c.Double());
            AlterColumn("dbo.Customers", "Latitude", c => c.Double());
            AlterColumn("dbo.Customers", "Longitude", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Detailers", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Detailers", "Latitude", c => c.Double(nullable: false));
        }
    }
}
