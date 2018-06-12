namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewVersion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "FoodPoints", c => c.Int(nullable: false));
            AddColumn("dbo.Animals", "SleepPoints", c => c.Int(nullable: false));
            AddColumn("dbo.Animals", "PoopPoints", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "PoopPoints");
            DropColumn("dbo.Animals", "SleepPoints");
            DropColumn("dbo.Animals", "FoodPoints");
        }
    }
}
