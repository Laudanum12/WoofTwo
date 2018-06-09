namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalId = c.Int(nullable: false),
                        Name = c.String(),
                        SpeciesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId)
                .ForeignKey("dbo.Species", t => t.SpeciesId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.AnimalId)
                .Index(t => t.AnimalId)
                .Index(t => t.SpeciesId);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        SpeciesName = c.String(),
                    })
                .PrimaryKey(t => t.SpeciesId);
            
            CreateTable(
                "dbo.NeedsRelations",
                c => new
                    {
                        NeedsRelationId = c.Int(nullable: false),
                        FoodIdFK = c.Int(nullable: false),
                        PoopIdFK = c.Int(nullable: false),
                        SleepIdFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NeedsRelationId)
                .ForeignKey("dbo.Foods", t => t.FoodIdFK, cascadeDelete: true)
                .ForeignKey("dbo.Poops", t => t.PoopIdFK, cascadeDelete: true)
                .ForeignKey("dbo.Sleeps", t => t.SleepIdFK, cascadeDelete: true)
                .ForeignKey("dbo.Species", t => t.NeedsRelationId)
                .Index(t => t.NeedsRelationId)
                .Index(t => t.FoodIdFK)
                .Index(t => t.PoopIdFK)
                .Index(t => t.SleepIdFK);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        FoodPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId);
            
            CreateTable(
                "dbo.Poops",
                c => new
                    {
                        PoopId = c.Int(nullable: false, identity: true),
                        PoopPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PoopId);
            
            CreateTable(
                "dbo.Sleeps",
                c => new
                    {
                        SleepId = c.Int(nullable: false, identity: true),
                        SleepPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SleepId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Level = c.Int(nullable: false),
                        DateOfRegistration = c.DateTime(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "AnimalId", "dbo.Users");
            DropForeignKey("dbo.NeedsRelations", "NeedsRelationId", "dbo.Species");
            DropForeignKey("dbo.NeedsRelations", "SleepIdFK", "dbo.Sleeps");
            DropForeignKey("dbo.NeedsRelations", "PoopIdFK", "dbo.Poops");
            DropForeignKey("dbo.NeedsRelations", "FoodIdFK", "dbo.Foods");
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropIndex("dbo.NeedsRelations", new[] { "SleepIdFK" });
            DropIndex("dbo.NeedsRelations", new[] { "PoopIdFK" });
            DropIndex("dbo.NeedsRelations", new[] { "FoodIdFK" });
            DropIndex("dbo.NeedsRelations", new[] { "NeedsRelationId" });
            DropIndex("dbo.Animals", new[] { "SpeciesId" });
            DropIndex("dbo.Animals", new[] { "AnimalId" });
            DropTable("dbo.Users");
            DropTable("dbo.Sleeps");
            DropTable("dbo.Poops");
            DropTable("dbo.Foods");
            DropTable("dbo.NeedsRelations");
            DropTable("dbo.Species");
            DropTable("dbo.Animals");
        }
    }
}
