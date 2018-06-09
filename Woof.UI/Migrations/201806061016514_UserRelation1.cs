namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRelation1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Animals");
            AlterColumn("dbo.Animals", "AnimalId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Animals", "AnimalId");
            CreateIndex("dbo.Animals", "AnimalId");
            AddForeignKey("dbo.Animals", "AnimalId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "AnimalId", "dbo.Users");
            DropIndex("dbo.Animals", new[] { "AnimalId" });
            DropPrimaryKey("dbo.Animals");
            AlterColumn("dbo.Animals", "AnimalId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Animals", "AnimalId");
        }
    }
}
