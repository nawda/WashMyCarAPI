namespace WashMyCar.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        VehicleTypeId = c.Int(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DetailerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId)
                .ForeignKey("dbo.Detailers", t => t.DetailerId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.CustomerId)
                .Index(t => t.DetailerId);
            
            CreateTable(
                "dbo.AppointmentServices",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AppointmentId, t.ServiceId })
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId)
                .Index(t => t.AppointmentId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        DetailerId = c.Int(nullable: false),
                        ServiceType = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.Detailers", t => t.DetailerId, cascadeDelete: true)
                .Index(t => t.DetailerId);
            
            CreateTable(
                "dbo.Detailers",
                c => new
                    {
                        DetailerId = c.Int(nullable: false, identity: true),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Cellphone = c.String(),
                        Address = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DetailerId);
            
            CreateTable(
                "dbo.DetailerAvailabilities",
                c => new
                    {
                        DetailerId = c.Int(nullable: false),
                        DayOfWeekId = c.Int(nullable: false),
                        Start = c.DateTime(),
                        End = c.DateTime(),
                        Multiplier = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.DetailerId, t.DayOfWeekId })
                .ForeignKey("dbo.DayOfWeeks", t => t.DayOfWeekId, cascadeDelete: true)
                .ForeignKey("dbo.Detailers", t => t.DetailerId, cascadeDelete: true)
                .Index(t => t.DetailerId)
                .Index(t => t.DayOfWeekId);
            
            CreateTable(
                "dbo.DayOfWeeks",
                c => new
                    {
                        DayOfWeekId = c.Int(nullable: false, identity: true),
                        Weekday = c.String(),
                    })
                .PrimaryKey(t => t.DayOfWeekId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Cellphone = c.String(),
                        Address = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        AppointmentId = c.Int(nullable: false),
                        AmountReceived = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Appointments", t => t.AppointmentId, cascadeDelete: true)
                .Index(t => t.AppointmentId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        VehicleTypeId = c.Int(nullable: false, identity: true),
                        VehicleSize = c.String(),
                        Multiplier = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VehicleTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Payments", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Appointments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.AppointmentServices", "AppointmentId", "dbo.Appointments");
            DropForeignKey("dbo.Services", "DetailerId", "dbo.Detailers");
            DropForeignKey("dbo.DetailerAvailabilities", "DetailerId", "dbo.Detailers");
            DropForeignKey("dbo.DetailerAvailabilities", "DayOfWeekId", "dbo.DayOfWeeks");
            DropForeignKey("dbo.Appointments", "DetailerId", "dbo.Detailers");
            DropForeignKey("dbo.AppointmentServices", "ServiceId", "dbo.Services");
            DropIndex("dbo.Payments", new[] { "AppointmentId" });
            DropIndex("dbo.DetailerAvailabilities", new[] { "DayOfWeekId" });
            DropIndex("dbo.DetailerAvailabilities", new[] { "DetailerId" });
            DropIndex("dbo.Services", new[] { "DetailerId" });
            DropIndex("dbo.AppointmentServices", new[] { "ServiceId" });
            DropIndex("dbo.AppointmentServices", new[] { "AppointmentId" });
            DropIndex("dbo.Appointments", new[] { "DetailerId" });
            DropIndex("dbo.Appointments", new[] { "CustomerId" });
            DropIndex("dbo.Appointments", new[] { "VehicleTypeId" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Payments");
            DropTable("dbo.Customers");
            DropTable("dbo.DayOfWeeks");
            DropTable("dbo.DetailerAvailabilities");
            DropTable("dbo.Detailers");
            DropTable("dbo.Services");
            DropTable("dbo.AppointmentServices");
            DropTable("dbo.Appointments");
        }
    }
}
