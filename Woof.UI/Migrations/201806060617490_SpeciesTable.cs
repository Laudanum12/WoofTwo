namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeciesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesId = c.Int(nullable: false, identity: true),
                        SpeciesName = c.String(),
                    })
                .PrimaryKey(t => t.SpeciesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Species");
        }
    }
}
