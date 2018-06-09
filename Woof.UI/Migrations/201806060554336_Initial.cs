namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sleeps");
            DropTable("dbo.Poops");
            DropTable("dbo.Needs");
            DropTable("dbo.Foods");
        }
    }
}
