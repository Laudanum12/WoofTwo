using Newtonsoft.Json;
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
//using System.Threading;
//using System.Timers;
using System.Threading;
using System.Windows.Threading;

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

        private const int _intervalDecrease = 1000 * 15;
        public const int _intervalNormalizePoop = 2000;
        public const int _intervalSleepIncrease = 15000;
        private const string _api = "AIzaSyAWCXeLdhMEZBwmQ2Eh6MTsq8usHPJmESA";

        public Repository()
        {
            RestoreUsers();
        }

        public void RestoreUsers()
        {
            _userRepository = Users;

        }

        public void RestoreInfo()
        {
            _animalRepository = Animals;
            _speciesRepository = Species;
            _citiesRepository = Cities;
        }


        public List<User> Users
        {
            get
            {
                //using (var db = new Context())
                //{
                List<User> users = new List<User>();
                foreach (var item in cntx.UserTable)
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
                cntx.SaveChanges();
                return users;
                //}
            }
        }
        public List<Animal> Animals
        {
            get
            {
                
                List<Animal> animals = new List<Animal>();
                foreach (var item in cntx.AnimalTable)
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

                return animals;
                
            }
        }

        public List<Species> Species
        {
            get
            {
                using (var db = new Context())
                {
                    List<Species> species = new List<Species>();
                    foreach (var item in cntx.SpeciesTable)
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
                    foreach (var item in cntx.CityTable)
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
           
            User User = cntx.UserTable.FirstOrDefault(q => q.Name == name && q.Password == hashPassword);
            CurrentUser = User;
            return User;

          
        }

        public bool CanAddUser(string name)
        {
            
            foreach (var i in cntx.UserTable)
            {
                if (i.Name == name)
                    return false;
            }
            return true;
        }


        public void AddUSer(string _city, DateTime _dateOfRegistration, string _email, string _password, string _name)
        {
            
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
        }

        public City FindCity(string city)
        {
            foreach(var item in cntx.CityTable)
            {

                if(item.CityName == city)
                {
                    return item;
                }
            }
            return null;
        }

        public async Task<DateTime> GetConvertedDateTimeBasedOnAddress(string cityName)
        {
            using (var client = new HttpClient())
            {
                var timestamp = GetUnixTimeStampFromDateTime(DateTime.UtcNow);
                var city = FindCity(cityName);
                var result = await client.GetStringAsync($"https://maps.googleapis.com/maps/api/timezone/json?location=city.Latitude,city.Longitude&timestamp=timestamp&key=_api");

                var data = JsonConvert.DeserializeObject<Item>(result);
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
          
            foreach (var species in cntx.SpeciesTable)
            {
                if (species.SpeciesName == name)
                {

                    return species;
                }
            }

            return null;
        }

        public Animal FindAnimal(User us)
        {
            foreach (var animal in cntx.AnimalTable)
            {
                if (animal.Name == us.Animal.Name)
                {
                    return animal;

                }
            }
            return null;
           
        }

        public int FindFoodPoints(Species species)
        {
            foreach (var item in _speciesRepository)
            {
                if (species.SpeciesName == item.SpeciesName)
                {
                    foreach (var food in cntx.FoodTable)
                    {
                        if (food.FoodId == item.Needs.FoodIdFK)
                        {
                            return food.FoodPoints;
                        }
                    }
                }
            }
            return 100;
        }

        public int FindSleepPoints(Species species)
        {
            foreach (var item in _speciesRepository)
            {
                if (species.SpeciesName == item.SpeciesName)
                {
                    foreach (var sleep in cntx.SleepTable)
                    {
                        if (sleep.SleepId == item.Needs.SleepIdFK)
                        {

                            cntx.SaveChanges();

                            return sleep.SleepPoints;
                        }
                    }

                }
            }
            cntx.SaveChanges();
            return 100;
        }

        public int FindPoopPoints(Species species)
        {
            
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
            return 100;
        }

        public string GetImageHelper(Animal an)
        {
            foreach (var item in cntx.SpeciesTable)
            {
                if (item.SpeciesId == an.SpeciesId)
                {

                    return item.SpeciesName;
                }
            }
            return null;
        }
        
        public Animal AddIncompleteAnimal(string name)
        {
            Species species = FindSpecies(name);
            var animal = new Animal
            {
                Species = FindSpecies(name),
                SpeciesId = FindSpecies(name).SpeciesId,
                FoodPoints = FindFoodPoints(species),
                PoopPoints = FindPoopPoints(species),
                SleepPoints = FindSleepPoints(species)
            };
            cntx.SaveChanges();
            return animal;
        }

        public void AddAnAnimal(Animal animal)
        {
            animal.AnimalId = CurrentUser.UserId;
            cntx.AnimalTable.Add(animal);
            cntx.SaveChanges();
        }
        
        public void DecreaseNeeds()
        {
            DispatcherTimer a = new DispatcherTimer();
            a.Tick += NeedsDecrease;
            a.Interval = new TimeSpan(0, 0, 30);
            a.Start();
        }

        public void NeedsDecrease(object sender, EventArgs e)
        {
            foreach (var item in cntx.AnimalTable)
            {
                if (CurrentUser.UserId == item.AnimalId && CurrentUser.Animal.PoopPoints > 0 &&
                    CurrentUser.Animal.FoodPoints > 0 && CurrentUser.Animal.SleepPoints > 0)
                {
                    item.PoopPoints -= 1;
                    item.SleepPoints -= 1;
                    item.FoodPoints -= 1;
                    CurrentUser.Animal.PoopPoints -= 1;
                    CurrentUser.Animal.SleepPoints -= 1;
                    CurrentUser.Animal.FoodPoints -= 1;
                    break;
                }
            }
            cntx.SaveChanges();
        }

        public void Sleep_Increase(object sender, EventArgs e)
        {
            foreach (var item in cntx.AnimalTable)
            {
                if (CurrentUser.UserId == item.AnimalId && FindSleepPoints(CurrentUser.Animal.Species) >= item.SleepPoints)
                {
                    item.SleepPoints += 5;
                    CurrentUser.Animal.SleepPoints += 5;
                }
            }
            cntx.SaveChanges();

        }

        public void IncreaseFoodValue(int points)
        {
            foreach (var item in cntx.AnimalTable)
            {
             
                if (CurrentUser.UserId == item.AnimalId && FindFoodPoints(CurrentUser.Animal.Species) >= item.FoodPoints + points)
                {
                    item.FoodPoints += points;
                    CurrentUser.Animal.FoodPoints += points;
                }
            }
            cntx.SaveChanges();
        }

        public void Poop_Normalize(object sender, EventArgs e)
        {
            foreach (var item in cntx.AnimalTable)
            {
                if (CurrentUser.UserId == item.AnimalId && FindPoopPoints(CurrentUser.Animal.Species) >= item.PoopPoints)
                {
                    item.PoopPoints += 5;
                    CurrentUser.Animal.FoodPoints += 5;
                }
               
            }
            cntx.SaveChanges();
        }


        public bool IsAnimalDead()
        {
            if(CurrentUser.Animal.PoopPoints == 0 || CurrentUser.Animal.SleepPoints == 0 || CurrentUser.Animal.FoodPoints == 0)
            {
                return true;
            }
            return false;
        }

        public void AnimalIsDead()
        {
            foreach(var item in cntx.AnimalTable)
            {
                if(CurrentUser.Animal.Name == item.Name)
                {
                    cntx.AnimalTable.Remove(item);
                }
            }
            cntx.SaveChanges();
        }
    }
}
