using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Classes;
using WoofTwo.Helpers;

namespace WoofTwo
{
    public class Repository : IRepository
    {
        public List<User> _userRepository { get; set; }
        public List<Animal> _animalRepository { get; set; }
        public List<Species> _speciesRepository { get; set; }
        public User CurrentUser { get; set; }

        public Repository()
        {
            RestoreUsers();
        }

        public void RestoreUsers()
        {
            _userRepository = Users;
            _animalRepository = Animals;
            _speciesRepository = Species;
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
                    return species;
                }

            }
        }

        public User UserInStorage(string name, string password)
        {
           // string hashPassword = PasswordHelper.GetHash(password);
            using (var db = new Context())
            {
                User User = db.UserTable.FirstOrDefault
                    (q => q.Name == name && q.Password == password);
                CurrentUser = User;
                return User;

            }
        }

        public bool CanAddUser(string name)
        {
            using (var db = new Context())
            {

                foreach (var i in db.UserTable)
                {
                    if (i.Name == name)
                        return true;
                }
                return false;
            }
        }

        public void AddUser(string name, string email, string password, string city, DateTime dateTime, int level)
        {
            using (var db = new Context())
            {
                var person = new User(name.Trim(), password, email.Trim(), dateTime, level, city);
                db.UserTable.Add(person);
                db.SaveChanges();
            }
        }

        public string FindImages()
        {
            using (var db = new Context())
            {
                var t = db.UserTable.First();
                var y = db.SpeciesTable.First().Needs;
               // var i = db.UserTable.First().Animal.AnimalId;
                if (db.UserTable.First().Animal.Species.SpeciesName == "Dinosaur")
                {
                    string imgPath = Path.GetFullPath(@"..\..\Images\pets\динозавр.png");
                    return imgPath;
                }
                return null;
            }

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
            else return null;

        }
        //формирование соответствия png 
        //api city time the on 
        //про

        public Species FindSpecies(string name)
        {
            using (var db = new Context())
            {
                foreach(var species in db.SpeciesTable)
                {
                    if (species.SpeciesName == name)
                    {
                        return species;
                    }
                   
                }
                return null;

            }
        }

        public Animal FindAnimal(User us)
        {
            using (var db = new Context())
            {
                foreach(var animal in db.AnimalTable)
                {
                    if (animal.Name == us.Animal.Name)
                        return animal;
                }
                return null;
            }
        }

        public string GetImageHelper(Animal an)
        {
            using (var db = new Context())
            {
                var pp = db.SpeciesTable.FirstOrDefault(x => x.SpeciesId == an.SpeciesId).SpeciesName;
                return pp;
            }
        }
        public void AddAnAnimal(Animal animal)
        {
            using (var db = new Context())
            {
                db.AnimalTable.Add(animal);
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
