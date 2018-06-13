namespace WoofTwo.Migrations
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using WoofTwo.Additions;
    using WoofTwo.Classes;

    internal sealed class Configuration : DbMigrationsConfiguration<WoofTwo.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WoofTwo.Context context)
        {
            
            AddFood(context, 100);
            AddFood(context, 120);
            AddFood(context, 140);
            AddFood(context, 160);
            AddFood(context, 180);
            AddFood(context, 200);

            AddPoop(context, 100);
            AddPoop(context, 110);
            AddPoop(context, 120);
            AddPoop(context, 130);
            AddPoop(context, 140);
            AddPoop(context, 150);

            AddSleep(context, 50);
            AddSleep(context, 60);
            AddSleep(context, 70);
            AddSleep(context, 80);
            AddSleep(context, 90);
            AddSleep(context, 100);
           

            AddSpeciesAndNeeds(context, "Dinosaur", 5, 3, 3);
            AddSpeciesAndNeeds(context, "Catbug", 4, 3, 6);
            AddSpeciesAndNeeds(context, "Rabbit", 4, 2, 2);
            AddSpeciesAndNeeds(context, "Dog", 3, 1, 4);
            AddSpeciesAndNeeds(context, "Fox", 2, 1, 2);
            AddSpeciesAndNeeds(context, "Deer", 1, 3, 2);

           
            AddUSerAndAnimal(context, "Moscow", DateTime.Now.AddDays(1), "email", 1, "a", "Alex", 1, "Foxxy", 5);

            GetCities(context);
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

        private void GetCities(WoofTwo.Context context)
        {
            var cityJsonAll =
                GetEmbeddedResourceAsString("WoofTwo.Data.City.json");

            JArray jsonValCities = JArray.Parse(cityJsonAll) as JArray;
            dynamic citiesData = jsonValCities;
            foreach (dynamic city in citiesData)
            {
                context.CityTable.AddOrUpdate(new City
                {
                    CityName = city.CityName,
                    Latitude = city.Latitude,
                    Longitude = city.Longitude
                });
            }
        }

            private string GetEmbeddedResourceAsString(string resourceName)
            {
                var assembly = Assembly.GetExecutingAssembly();

                //var names = assembly.GetManifestResourceNames();

                string result;
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
                return result;
            }
        
    }
}
