namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeedsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NeedsRelations",
                c => new
                    {
                        NeedsRelationId = c.Int(nullable: false, identity: true),
                        NeedsIdFK = c.Int(nullable: false),
                        FoodIdFK = c.Int(nullable: false),
                        PoopIdFK = c.Int(nullable: false),
                        SleepIdFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NeedsRelationId)
                .ForeignKey("dbo.Needs", t => t.NeedsIdFK, cascadeDelete: true)
                .ForeignKey("dbo.Poops", t => t.PoopIdFK, cascadeDelete: true)
                .ForeignKey("dbo.Sleeps", t => t.SleepIdFK, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodIdFK, cascadeDelete: true)
                .Index(t => t.NeedsIdFK)
                .Index(t => t.FoodIdFK)
                .Index(t => t.PoopIdFK)
                .Index(t => t.SleepIdFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NeedsRelations", "FoodIdFK", "dbo.Foods");
            DropForeignKey("dbo.NeedsRelations", "SleepIdFK", "dbo.Sleeps");
            DropForeignKey("dbo.NeedsRelations", "PoopIdFK", "dbo.Poops");
            DropForeignKey("dbo.NeedsRelations", "NeedsIdFK", "dbo.Needs");
            DropIndex("dbo.NeedsRelations", new[] { "SleepIdFK" });
            DropIndex("dbo.NeedsRelations", new[] { "PoopIdFK" });
            DropIndex("dbo.NeedsRelations", new[] { "FoodIdFK" });
            DropIndex("dbo.NeedsRelations", new[] { "NeedsIdFK" });
            DropTable("dbo.NeedsRelations");
        }
    }
}
