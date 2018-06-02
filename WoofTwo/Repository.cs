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
    class Repository 
    {
        public List<Person> _personRepository { get; set; }
        public List<Animal> _animalRepository { get; set; }
        public List<Species> _speciesRepository { get; set; }

        public Repository()
        {
            Person n = new Person
            {
                PersonId = 1,
                Email = "lovw",
                Level = 1,
                Name = "Vika",
                Password = Helpers.PasswordHelper.GetHash("poop"),
                Animal = new Animal
                {
                    AnimalId = 1,
                    Name = "Hedgehoggy",
                    Species = new Species
                    {

                        SpeciesId = 1,
                        SpeciesName = "Hedgehog",
                        Needs = new Needs
                        {
                            Food = new Food
                            {
                                FoodId = 1,
                                FoodPoints = 20
                            },
                            Sleep = new Sleep
                            {
                                SleepId = 1,
                                SleepPoints = 20
                            },
                            Poop = new Poop
                            {
                                PoopId = 1,
                                PoopPoints = 30
                            },
                        },
                    },
                },
                
            };

            Person p = new Person
            {
                PersonId = 2,
                Email = "dmitr",
                Level = 1,
                Name = "Dima",
                Password = Helpers.PasswordHelper.GetHash("poopy"),
                Animal = new Animal
                {
                    AnimalId = 2,
                    Name = "Catbuggy",
                    
                    Species = new Species
                    {

                        SpeciesId = 2,
                        SpeciesName = "Catbug",
                        Needs = new Needs
                        {
                            Food = new Food
                            {
                                FoodId = 1,
                                FoodPoints = 20
                            },
                            Sleep = new Sleep
                            {
                                SleepId = 1,
                                SleepPoints = 20
                            },
                            Poop = new Poop
                            {
                                PoopId = 1,
                                PoopPoints = 30
                            },
                        },
                    },
                },
            };
            List<Person> i = new List<Person> { n, p };
            Animal q = new Animal
            {
                AnimalId = 1,
                Species = new Species
                {

                }
            };
            Species e = new Species
            {

            };
            SaveList("person.json", i);
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
