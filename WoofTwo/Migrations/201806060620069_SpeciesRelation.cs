namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeciesRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NeedsRelations", "NeedsIdFK", "dbo.Needs");
            DropPrimaryKey("dbo.Needs");
            AlterColumn("dbo.Needs", "NeedsId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Needs", "NeedsId");
            CreateIndex("dbo.Needs", "NeedsId");
            AddForeignKey("dbo.Needs", "NeedsId", "dbo.Species", "SpeciesId");
            AddForeignKey("dbo.NeedsRelations", "NeedsIdFK", "dbo.Needs", "NeedsId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NeedsRelations", "NeedsIdFK", "dbo.Needs");
            DropForeignKey("dbo.Needs", "NeedsId", "dbo.Species");
            DropIndex("dbo.Needs", new[] { "NeedsId" });
            DropPrimaryKey("dbo.Needs");
            AlterColumn("dbo.Needs", "NeedsId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Needs", "NeedsId");
            AddForeignKey("dbo.NeedsRelations", "NeedsIdFK", "dbo.Needs", "NeedsId", cascadeDelete: true);
        }
    }
}
