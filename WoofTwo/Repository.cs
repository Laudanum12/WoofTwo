﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Additions;
using WoofTwo.Classes;
using WoofTwo.DTO;
using WoofTwo.Helpers;
using RestSharp;
using System.Xml.Linq;
using System.Net;

namespace WoofTwo
{
    public class Repository : IRepository
    {
        public List<User> _userRepository { get; set; }
        public List<Animal> _animalRepository { get; set; }
        public List<Species> _speciesRepository { get; set; }
        public List<City> _citiesRepository { get; set; }
        public User CurrentUser { get; set; }
        Context cntx = new Context();
        private const string _api = "AIzaSyAWCXeLdhMEZBwmQ2Eh6MTsq8usHPJmESA";

        public Repository()
        {
            RestoreUsers();
        }

        public void RestoreUsers()
        {
            _userRepository = Users;
            _animalRepository = Animals;
            _speciesRepository = Species;
            _citiesRepository = Cities;
        }

        public void RestoreInfo()
        {
            
        }


        public List<User> Users
        {
            get
            {
                using (var db = new Context())
                {
                    List<User> users = new List<User>();
                    foreach (var item in db.UserTable)
                    {
                        User user = new User
                        {
                            City = item.City,
                            DateOfRegistration = item.DateOfRegistration,
                            Email = item.Email,
                            Level = item.Level,
                            Name = item.Name,
                            Password = item.Password,
                            UserId = item.UserId,
                            Animal = item.Animal
                        };
                        users.Add(user);
                    }
                    db.SaveChanges();
                    return users;
                }
            }
        }
        public List<Animal> Animals
        {
            get
            {
                using (var db = new Context())
                {
                    List<Animal> animals = new List<Animal>();
                    foreach (var item in db.AnimalTable)
                    {
                        Animal animal = new Animal
                        {
                            AnimalId = item.AnimalId,
                            Name = item.Name,
                            SpeciesId = item.SpeciesId,
                            Species = item.Species
                        };
                        animals.Add(animal);
                    }
                    db.SaveChanges();
                    return animals;
                }
            }
        }

        public List<Species> Species
        {
            get
            {
                using (var db = new Context())
                {
                    List<Species> species = new List<Species>();
                    foreach (var item in db.SpeciesTable)
                    {
                        Species _species = new Species
                        {
                            Animals = item.Animals,
                            Needs = item.Needs,
                            SpeciesId = item.SpeciesId,
                            SpeciesName = item.SpeciesName
                        };
                        species.Add(_species);
                    }
                    db.SaveChanges();
                    return species;
                }

            }
        }

        public List<City> Cities
        {
            get
            {
                using (var db = new Context())
                {
                    List<City> cities = new List<City>();
                    foreach (var item in db.CityTable)
                    {
                        City city = new City
                        {
                            CityId = item.CityId,
                            CityName = item.CityName,
                            Latitude = item.Latitude,
                            Longitude = item.Longitude
                        };
                        cities.Add(city);
                    }
                    var newcities = cities.OrderBy(c => c.CityName).Select(f => new City { CityName = f.CityName, CityId = f.CityId, Latitude = f.Latitude, Longitude = f.Longitude }).ToList();
                    
                    return newcities;
                }
              
            }
        }
        public User UserInStorage(string name, string password)
        {
            string hashPassword = PasswordHelper.GetHash(password);
            using (var db = new Context())
            {
                User User = cntx.UserTable.FirstOrDefault(q => q.Name == name && q.Password == hashPassword);
                //if(User != null)
                    CurrentUser = User;
                return User;

            }
        }

        public bool CanAddUser(string name)
        {
            //using (var db = new Context())
            //{
                foreach (var i in cntx.UserTable)
                {
                    if (i.Name == name)
                        return false;
                }
                return true;
            //}
        }
        

        public void AddUSer( string _city, DateTime _dateOfRegistration, string _email, string _password, string _name)
        {
            //using (var context = new Context())
            //{

                cntx.UserTable.Add(new Classes.User
                {
                    City = _city,
                    DateOfRegistration = _dateOfRegistration,
                    Email = _email,
                    Level = 1,
                    Password = PasswordHelper.GetHash(_password),
                    Name = _name,
                });
                cntx.SaveChanges();
            //}
           
            
        }

        //public async Task<int> GetCurrentTime(City city)
        //{
        //    using (var client = new HttpClient())
        //    {

        //        var result = await client.GetStringAsync($"https://maps.googleapis.com/maps/api/timezone/json?location=city.Latitude,city.Longitude&timestamp=1331161200&key=_api");
        //        //Thread.Sleep(); заставить задержку
        //        var data = JsonConvert.DeserializeObject<Item>(result);

        //        return data.Items.Select(item => new SearchResult
        //        {
        //            Title = item.Title,
        //            Description = item.Snippet,
        //            Link = item.Link
        //        }).ToList();
        //    }

        private async Task<DateTime> GetConvertedDateTimeBasedOnAddress(City city, long timestamp)
        {
            using(var client = new HttpClient())
            {
                var resultt = await client.GetStringAsync($"https://maps.googleapis.com/maps/api/timezone/json?location=city.Latitude,city.Longitude&timestamp=timespa&key=_api");

                var data = JsonConvert.DeserializeObject<Item>(resultt);
                DateTime dt = GetDateTimeFromUnixTimeStamp(Convert.ToDouble(timestamp) + Convert.ToDouble(data.OffsetForSummer) + Convert.ToDouble(data.OffsetFromUTC));
                return dt;
            }
            
        }
        private long GetUnixTimeStampFromDateTime(DateTime dt)
        {
            DateTime epochDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan ts = dt - epochDate;
            return (int)ts.TotalSeconds;
        }

        private DateTime GetDateTimeFromUnixTimeStamp(double unixTimeStamp)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(unixTimeStamp);
            return dt;
        }

        public string GetAPath(string species)
        {
            
            if (species == "Dinosaur")
            {
                string imgPath = Path.GetFullPath(@"..\..\Images\pets\динозавр.png");
                return imgPath;
            }
            else if (species == "Catbug")
            {
                string imgPath = Path.GetFullPath(@"..\..\Images\pets\котожук.png");
                return imgPath;
            }
            else if (species == "Rabbit")
            {
                string imgPath = Path.GetFullPath(@"..\..\Images\pets\кролик.png");
                return imgPath;
            }
            else if (species == "Fox")
            {
                string imgPath = Path.GetFullPath(@"..\..\Images\pets\лиса.png");
                return imgPath;
            }
            else if (species == "Deer")
            {
                string imgPath = Path.GetFullPath(@"..\..\Images\pets\олень.png");
                return imgPath;
            }
            else if (species == "Dog")
            {
                string imgPath = Path.GetFullPath(@"..\..\Images\pets\скотч.png");
                return imgPath;
            }
            else
                return null;

        }
       

        public Species FindSpecies(string name)
        {
            
                foreach(var species in cntx.SpeciesTable)
                {
                    if (species.SpeciesName == name)
                    {
                        
                        return species;
                    }
                }
               // cntx.SaveChanges();
                return null;


        }

        public Animal FindAnimal(User us)
        {
            //using (var db = new Context())
            //{
                foreach(var animal in cntx.AnimalTable)
                {
                    if (animal.Name == us.Animal.Name)
                    {
                        //cntx.SaveChanges();
                        return animal;

                    }
                }
                return null;
            //}
        }

        public int FindFoodPoints(Species species)
        {
            //using (var db = new Context())
            //{
                foreach (var item in _speciesRepository)
                {
                    if (species.SpeciesName == item.SpeciesName)
                    {
                        foreach(var food in cntx.FoodTable)
                        {
                            if(food.FoodId == item.Needs.FoodIdFK)
                            {
                                //cntx.SaveChanges();

                                return food.FoodPoints;
                            }
                        }
                    }
                }
                //cntx.SaveChanges();

            //}

            return 100;
        }

        public int FindSleepPoints(Species species)
        {

            //using (var db = new Context())
            //{
                foreach (var item in _speciesRepository)
                {
                    if (species.SpeciesName == item.SpeciesName)
                    {
                        foreach (var sleep in cntx.SleepTable)
                        {
                            if (sleep.SleepId == item.Needs.SleepIdFK)
                            {
                                

                                return sleep.SleepPoints;
                            }
                        }

                    }
                }
                //cntx.SaveChanges();

            //}
            return 100;
        }

        public int FindPoopPoints(Species species)
        {
            //using (var db = new Context())
            //{
                foreach (var item in _speciesRepository)
                {
                    if (species.SpeciesName == item.SpeciesName)
                    {
                        foreach (var poop in cntx.PoopTable)
                        {
                            if (poop.PoopId == item.Needs.PoopIdFK)
                            {
                                

                                return poop.PoopPoints;
                            }
                        }

                    }
                }
                

           // }
            return 100;
        }

        public string GetImageHelper(Animal an)
        {
            //using (var db = new Context())
            //{
                foreach (var item in cntx.SpeciesTable)
                {
                    if (item.SpeciesId == an.SpeciesId)
                    {
                        
                        return item.SpeciesName;
                    }
                    
                }
               
                return null;
            //}
        }
        
        

        public Animal AddIncompleteAnimal(string name)
        {
            using(var db = new Context())
            {
                Species species = FindSpecies(name);
                var animal = new Animal
                {
                    Species = FindSpecies(name),
                    SpeciesId = FindSpecies(name).SpeciesId,
                    FoodPoints =  FindFoodPoints(species),
                    PoopPoints = FindPoopPoints(species),
                    SleepPoints = FindSleepPoints(species)
                };
                db.SaveChanges();
                return animal;
            }
           
        }

        public void AddAnAnimal(Animal animal)
        {
            using (var db = new Context())
            {
                animal.AnimalId = CurrentUser.UserId;
                db.AnimalTable.Add(animal);
                db.SaveChanges();
            }
        }


        //public int IncreaseFoodValue(int points)
        //{
        //    using (var db = new Context())
        //    {
        //        int value;
        //        value = db.AnimalTable.Hunger + points;
        //    return value;
        //    }

        //}

    }
}
