namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WoofTwo.Context>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WoofTwo.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodId = 1,
                FoodPoints = 10
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodId = 2,
                FoodPoints = 15
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodId = 3,
                FoodPoints = 20
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodId = 4,
                FoodPoints = 25
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodId = 5,
                FoodPoints = 30
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodId = 6,
                FoodPoints = 35
            });
            context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopId = 1,
                PoopPoints = 10
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopId = 2,
                PoopPoints = 15
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopId = 3,
                PoopPoints = 20
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopId = 4,
                PoopPoints = 25
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopId = 5,
                PoopPoints = 30
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopId = 6,
                PoopPoints = 35
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepId = 1,
                SleepPoints = 10
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepId = 2,
                SleepPoints = 15
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepId = 3,
                SleepPoints = 20
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepId = 4,
                SleepPoints = 25
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepId = 5,
                SleepPoints = 30
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepId = 6,
                SleepPoints = 35
            });

            context.Needs.AddOrUpdate( new Classes.Needs
            {
                NeedsId = 1
            });

            context.NeedsTable.AddOrUpdate(new Relations.NeedsRelations
            {
                FoodIdFK = 1,
                NeedsIdFK = 1,
                NeedsRelationId = 1,
                PoopIdFK = 1,
                SleepIdFK = 1
            });

        }
    }
}
