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
                FoodPoints = 10
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodPoints = 15
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodPoints = 20
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {

                FoodPoints = 25
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodPoints = 30
            });
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodPoints = 35
            });
            context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopPoints = 10
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopPoints = 15
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopPoints = 20
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopPoints = 25
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopPoints = 30
            }); context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopPoints = 35
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepPoints = 10
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepPoints = 15
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepPoints = 20
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepPoints = 25
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepPoints = 30
            });
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepPoints = 35
            });
            context.SaveChanges();

            
            context.SpeciesTable.AddOrUpdate(new Classes.Species
            {
                SpeciesName = "Fox"
            });
           
            context.NeedsTable.AddOrUpdate(new Relations.NeedsRelations
            {
                FoodIdFK = 1,
                PoopIdFK = 1,
                SleepIdFK = 1

            });
            context.SaveChanges();

            context.UserTable.AddOrUpdate(new Classes.User
            {
                City = "A",
                DateOfRegistration = DateTime.Now.AddDays(1),
                Email = "sa",
                Level = 1,
                Password = "asa",
                Name = "aaaa"

            });

            context.AnimalTable.AddOrUpdate(new Classes.Animal
            {
                Name = "Foxxy",
                SpeciesId = 1,

            });
        }
    }
}
