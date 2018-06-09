namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnimalTableAnother : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "SpeciesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "SpeciesId");
        }
    }
}
