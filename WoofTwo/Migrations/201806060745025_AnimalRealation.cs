namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalRealation : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Animals", "SpeciesId");
            AddForeignKey("dbo.Animals", "SpeciesId", "dbo.Species", "SpeciesId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "SpeciesId", "dbo.Species");
            DropIndex("dbo.Animals", new[] { "SpeciesId" });
        }
    }
}
