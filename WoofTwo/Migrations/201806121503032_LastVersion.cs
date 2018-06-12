namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastVersion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cities");
        }
    }
}
