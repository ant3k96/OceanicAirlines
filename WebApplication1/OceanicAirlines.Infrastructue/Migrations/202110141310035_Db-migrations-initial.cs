namespace OceanicAirlines.Infrastructue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dbmigrationsinitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        FromId = c.String(nullable: false),
                        ToId = c.String(nullable: false),
                        PackageSize = c.Int(nullable: false),
                        PackageWeight = c.Int(nullable: false),
                        PackageType = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Duration = c.Double(nullable: false),
                        From_Id = c.Int(),
                        To_Id = c.Int(),
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
                        Id = c.Guid(nullable: false),
                        RouteId = c.String(nullable: false, maxLength: 128),
                        CityId = c.String(nullable: false),
                        City_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: true)
                .Index(t => t.RouteId)
                .Index(t => t.City_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteCities", "RouteId", "dbo.Routes");
            DropForeignKey("dbo.RouteCities", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Routes", "To_Id", "dbo.Cities");
            DropForeignKey("dbo.Routes", "From_Id", "dbo.Cities");
            DropIndex("dbo.RouteCities", new[] { "City_Id" });
            DropIndex("dbo.RouteCities", new[] { "RouteId" });
            DropIndex("dbo.Routes", new[] { "To_Id" });
            DropIndex("dbo.Routes", new[] { "From_Id" });
            DropTable("dbo.RouteCities");
            DropTable("dbo.Routes");
            DropTable("dbo.Cities");
        }
    }
}
