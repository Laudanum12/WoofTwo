using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Classes;

namespace WoofTwo
{
    public class Repository 
    {
        public List<User> _personRepository { get; set; }
        public List<Animal> _animalRepository { get; set; }
        public List<Species> _speciesRepository { get; set; }

        public Repository()
        {
            //Person n = new Person
            //{
            //    PersonId = 1,
            //    Email = "lovw",
            //    Level = 1,
            //    Name = "Vika",
            //    Password = Helpers.PasswordHelper.GetHash("poop"),
            //    Animal = new Animal
            //    {
            //        AnimalId = 1,
            //        Name = "Hedgehoggy"
            //    },

            //};

            //Person p = new Person
            //{
            //    PersonId = 2,
            //    Email = "dmitr",
            //    Level = 1,
            //    Name = "Dima",
            //    Password = Helpers.PasswordHelper.GetHash("poopy"),
            //    Animal = new Animal
            //    {
            //        AnimalId = 2,
            //        Name = "Catbuggy",

            //        Species = new Species
            //        {

            //            SpeciesId = 2,
            //            SpeciesName = "Catbug",
            //            Needs = new Needs
            //            {
            //                Food = new Food
            //                {
            //                    FoodId = 1,
            //                    FoodPoints = 20
            //                },
            //                Sleep = new Sleep
            //                {
            //                    SleepId = 1,
            //                    SleepPoints = 20
            //                },
            //                Poop = new Poop
            //                {
            //                    PoopId = 1,
            //                    PoopPoints = 30
            //                },
            //            },
            //        },
            //    },
            //};
            //List<Person> i = new List<Person> { n, p };
            //Animal q = new Animal
            //{
            //    AnimalId = 1,
            //    Species = new Species
            //    {

            //    }
            //};
            Species e = new Species
            {
                SpeciesId = 1,
                SpeciesName = "Hedgehog"
                
            };
            Species l = new Species
            {
                SpeciesId = 2,
                SpeciesName = "Catbug"
                
            };
            List<Species> species = new List<Species> { e, l };
            SaveList("Species.json", species);
            //SaveList("Users.json", i);
            //Food q = new Food()
            //{
            //    FoodId = 1,
            //    FoodPoints = 10
            //};
            //Food q1 = new Food()
            //{
            //    FoodId = 2,
            //    FoodPoints = 15
            //};
            //Food q2 = new Food()
            //{
            //    FoodId = 3,
            //    FoodPoints = 20
            //};
            //Food q3 = new Food()
            //{
            //    FoodId = 4,
            //    FoodPoints = 25
            //};
            //Food q4 = new Food()
            //{
            //    FoodId = 5,
            //    FoodPoints = 30
            //};
            //SaveList("Foods.json", new List<Food> { q, q1, q2, q3, q4 });

            //Sleep w = new Sleep ()
            //{
            //    SleepId = 1,
            //    SleepPoints = 10
            //};
            //Sleep w1 = new Sleep()
            //{
            //    SleepId = 2,
            //    SleepPoints = 15
            //};
            //Sleep w2 = new Sleep()
            //{
            //    SleepId = 3,
            //    SleepPoints = 20
            //};
            //Sleep w3 = new Sleep()
            //{
            //    SleepId = 4,
            //    SleepPoints = 25
            //};
            //Sleep w4 = new Sleep()
            //{
            //    SleepId = 5,
            //    SleepPoints = 30
            //};
            //Sleep w5 = new Sleep()
            //{
            //    SleepId = 6,
            //    SleepPoints = 35
            //};
            //Sleep w6 = new Sleep()
            //{
            //    SleepId = 7,
            //    SleepPoints = 40
            //};
            //SaveList("Sleeps.json", new List<Sleep> { w, w1, w2, w3, w4, w5, w6 });

            //Poop a = new Poop()
            //{
            //    PoopId = 1,
            //    PoopPoints = 10
            //};
            //Poop a1 = new Poop()
            //{
            //    PoopId = 2,
            //    PoopPoints = 15
            //};
            //Poop a2 = new Poop()
            //{
            //    PoopId = 3,
            //    PoopPoints = 20
            //};

            //Poop a3 = new Poop()
            //{
            //    PoopId = 4,
            //    PoopPoints = 25
            //};
            //Poop a4 = new Poop()
            //{
            //    PoopId = 5,
            //    PoopPoints = 30
            //};
            //SaveList("Poops.json", new List<Poop> { a, a1, a2, a3, a4 });

        }


        private void SaveList<T>(string fileName, List<T> list)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, list);
                }
            }
        }
    }
}
