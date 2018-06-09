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
        }

        public void RestoreInfo()
        {
            _animalRepository = Animals;
            _speciesRepository = Species;
        }
        public List<User> Users
        {
            get
            {
                using (var db = new Context())
                {
                    List<User> users = new List<User>();
                    foreach(var item in db.UserTable)
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
                    //_userRepository = users;
                    return users;
                }
            }
        } 
        public List<Animal> Animals
        {
            get
            {
                using( var db = new Context())
                {
                    List<Animal> animals = new List<Animal>();
                    foreach(var item in db.AnimalTable)
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
                    // _animalRepository = animals;
                    return animals;
                }
            }
        }

        public List<Species> Species
        {
            get
            {
                using(var db = new Context())
                {
                    List<Species> species = new List<Species>();
                    foreach(var item in db.SpeciesTable)
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
                    //_speciesRepository = species;
                    return species;
                }

            }
        }

        public User UserInStorage(string name, string password)
        {
            string hashPassword = PasswordHelper.GetHash(password);
            using (var db = new Context())
            {
                User User = db.UserTable.FirstOrDefault
                    (q => q.Name == name && q.Password == hashPassword);
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

        public void AddUser(string name, string email, string password,string city, DateTime dateTime, int level)
        {
            using (var db = new Context())
            {
                var person = new User(name.Trim(),password, email.Trim(), dateTime, level,city);
                db.UserTable.Add(person);
                db.SaveChanges();
            }
        }
    }
}
