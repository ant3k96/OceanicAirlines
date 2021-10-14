namespace OceanicAirlines.Infrastructue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dbmigration_ver3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        IsBlacklisted = c.Boolean(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CityCityConnections",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FromId = c.String(nullable: false, maxLength: 128),
                        ToId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.FromId, cascadeDelete: false)
                .ForeignKey("dbo.Cities", t => t.ToId, cascadeDelete: false)
                .Index(t => t.FromId)
                .Index(t => t.ToId);
            
            CreateTable(
                "dbo.RouteCities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RouteId = c.String(maxLength: 128),
                        CityId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .ForeignKey("dbo.Routes", t => t.RouteId)
                .Index(t => t.RouteId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FromId = c.String(),
                        ToId = c.String(),
                        PackageSize = c.Int(nullable: false),
                        PackageWeight = c.Int(nullable: false),
                        PackageType = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Duration = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteCities", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.RouteCities", "CityId", "dbo.Cities");
            DropForeignKey("dbo.CityCityConnections", "ToId", "dbo.Cities");
            DropForeignKey("dbo.CityCityConnections", "FromId", "dbo.Cities");
            DropIndex("dbo.RouteCities", new[] { "CityId" });
            DropIndex("dbo.RouteCities", new[] { "RouteId" });
            DropIndex("dbo.CityCityConnections", new[] { "ToId" });
            DropIndex("dbo.CityCityConnections", new[] { "FromId" });
            DropTable("dbo.Routes");
            DropTable("dbo.RouteCities");
            DropTable("dbo.CityCityConnections");
            DropTable("dbo.Cities");
        }
    }
}
