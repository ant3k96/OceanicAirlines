namespace OceanicAirlines.Infrastructue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dbinitialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        IsBlacklisted = c.Boolean(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FromId = c.Guid(nullable: false),
                        ToId = c.Guid(nullable: false),
                        PackageSize = c.Int(nullable: false),
                        PackageWeight = c.Int(nullable: false),
                        PackageType = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Duration = c.Double(nullable: false),
                        From_Id = c.String(maxLength: 128),
                        To_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.From_Id)
                .ForeignKey("dbo.Cities", t => t.To_Id)
                .Index(t => t.From_Id)
                .Index(t => t.To_Id);
            
            CreateTable(
                "dbo.RouteCities",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RouteId = c.Guid(nullable: false),
                        CityId = c.Guid(nullable: false),
                        City_Id = c.String(maxLength: 128),
                        Route_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Route_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteCities", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.RouteCities", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Routes", "To_Id", "dbo.Cities");
            DropForeignKey("dbo.Routes", "From_Id", "dbo.Cities");
            DropIndex("dbo.RouteCities", new[] { "Route_Id" });
            DropIndex("dbo.RouteCities", new[] { "City_Id" });
            DropIndex("dbo.Routes", new[] { "To_Id" });
            DropIndex("dbo.Routes", new[] { "From_Id" });
            DropTable("dbo.RouteCities");
            DropTable("dbo.Routes");
            DropTable("dbo.Cities");
        }
    }
}
