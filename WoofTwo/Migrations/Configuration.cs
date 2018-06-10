namespace WoofTwo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WoofTwo.Classes;

    internal sealed class Configuration : DbMigrationsConfiguration<WoofTwo.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WoofTwo.Context context)
        {
            
            AddFood(context, 10);
            AddFood(context, 15);
            AddFood(context, 20);
            AddFood(context, 25);
            AddFood(context, 30);
            AddFood(context, 35);
            AddPoop(context, 10);
            AddPoop(context, 15);
            AddPoop(context, 20);
            AddPoop(context, 25);
            AddPoop(context, 30);
            AddSleep(context, 35);
            AddSleep(context, 10);
            AddSleep(context, 15);
            AddSleep(context, 20);
            AddSleep(context, 25);
            AddSleep(context, 30);
            AddSleep(context, 35);

            AddSpeciesAndNeeds(context, "Dinosaur", 1, 1, 1);
            AddSpeciesAndNeeds(context, "Catbug", 1, 3, 2);
            AddSpeciesAndNeeds(context, "Rabbit", 4, 3, 2);
            AddSpeciesAndNeeds(context, "Dog", 3, 1, 4);
            AddSpeciesAndNeeds(context, "Fox", 1, 4, 2);
            AddSpeciesAndNeeds(context, "Deer", 2, 3, 2);

           
            AddUSerAndAnimal(context, "Moscow", DateTime.Now.AddDays(1), "email", 1, "a", "Alex", 1, "Foxxy", 5);


        }

        private void AddFood(WoofTwo.Context context, int _foodPoint)
        {
            context.FoodTable.AddOrUpdate(x => x.FoodPoints, new Classes.Food
            {
                FoodPoints = _foodPoint
            });
            context.SaveChanges();
        }

        private void AddPoop(WoofTwo.Context context, int _poopPoints)
        {
            context.PoopTable.AddOrUpdate(x => x.PoopPoints, new Classes.Poop
            {
                PoopPoints = _poopPoints
            });
            context.SaveChanges();
        }

        private void AddSleep(WoofTwo.Context context, int _sleepPoints)
        {
            context.SleepTable.AddOrUpdate(x => x.SleepPoints, new Classes.Sleep
            {
                SleepPoints = _sleepPoints
            });
            context.SaveChanges();
        }

        private void AddSpeciesAndNeeds(WoofTwo.Context context, string _speciesName, int _foodIdFK, int _poopIdFK, int _sleepIdFK)
        {
            context.SpeciesTable.AddOrUpdate(x => x.SpeciesName, new Classes.Species
            {
                SpeciesName = _speciesName
            });

            context.NeedsTable.AddOrUpdate(x => new { x.FoodIdFK, x.PoopIdFK, x.SleepIdFK }, new Relations.Needs
            {
                FoodIdFK = _foodIdFK,
                PoopIdFK = _poopIdFK,
                SleepIdFK = _sleepIdFK

            });
            context.SaveChanges();
            
        }

        private void AddUSerAndAnimal(WoofTwo.Context context, string _city, DateTime _dateOfRegistration, string _email,
            int _level, string _password, string _name, int _animalId, string _animalName, int _speciesId)
        {
            context.UserTable.AddOrUpdate(x => new { x.Name, x.Password }, new Classes.User
            {
                City = _city,
                DateOfRegistration = _dateOfRegistration,
                Email = _email,
                Level = _level,
                Password = _password,
                Name = _name,
                

            });
            context.SaveChanges();

            context.AnimalTable.AddOrUpdate(x => new { x.Name, x.SpeciesId }, new Classes.Animal
            {
                AnimalId = _animalId,
                Name =_animalName,
                SpeciesId = _speciesId
            });
            context.SaveChanges();
        }
    }
}
