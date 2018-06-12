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

        public void AddUser(string name, string email, string password, string city, DateTime dateTime, int level)
        {
            using (var db = new Context())
            {
                var person = new User(name.Trim(), password, email.Trim(), dateTime, level, city);
                db.UserTable.Add(person);
                db.SaveChanges();
            }
        }

        public void AddUSer(string _city, DateTime _dateOfRegistration, string _email,
           int _level, string _password, string _name)
        {
            using (var db = new Context())
            {
                if (_userRepository.Exists(x => x.Name == _name && x.Password == PasswordHelper.GetHash(_password)) == false)
                db.UserTable.Add(new Classes.User
                {
                    City = _city,
                    DateOfRegistration = _dateOfRegistration, //сделать
                    Email = _email,
                    Level = 1,
                    Password = PasswordHelper.GetHash(_password),
                    Name = _name,
                });
                db.SaveChanges();
            }
          

           
        }
        private void AddFood(int _foodPoint)
        {
            using (var db = new Context())
            {
                db.FoodTable.Add(new Classes.Food
                {
                    FoodPoints = _foodPoint
                });
                db.SaveChanges();
            }
            
        }

        private void AddPoop( int _poopPoints)
        {
            using (var db = new Context())
            {
                db.PoopTable.Add( new Classes.Poop
                {
                    PoopPoints = _poopPoints
                });
                db.SaveChanges();
            }
            
           
        }

        private void AddSleep( int _sleepPoints)
        {
            using (var db = new Context())
            {
                db.SleepTable.Add( new Classes.Sleep
                {
                    SleepPoints = _sleepPoints
                });
                db.SaveChanges();
            }
           
        }

        private void AddSpeciesAndNeeds(string _speciesName, int _foodIdFK, int _poopIdFK, int _sleepIdFK)
        {
            using (var db = new Context())
            {
                if(_speciesRepository.Exists(x => x.SpeciesName == _speciesName) == false)
                {
                    db.SpeciesTable.Add(new Classes.Species
                    {
                        SpeciesName = _speciesName
                    });

                    db.NeedsTable.Add(new Relations.Needs
                    {
                        FoodIdFK = _foodIdFK,
                        PoopIdFK = _poopIdFK,
                        SleepIdFK = _sleepIdFK

                    });
                    db.SaveChanges();
                }
            }
                

        }

    
        public string FindImages()
        {
            if(CurrentUser.Animal != null)
            {

                if (CurrentUser.Animal.Species.SpeciesName == "Dinosaur")
                {
                    string imgPath = Path.GetFullPath(@"..\..\Images\pets\динозавр.png");
                    return imgPath;
                }
                if (CurrentUser.Animal.Species.SpeciesName == "Catbug")
                {
                    string imgPath = Path.GetFullPath(@"..\..\Images\pets\котожук.png");
                    return imgPath;
                }
                if (CurrentUser.Animal.Species.SpeciesName == "Rabbit")
                {
                    string imgPath = Path.GetFullPath(@"..\..\Images\pets\кролик.png");
                    return imgPath;
                }
                if (CurrentUser.Animal.Species.SpeciesName == "Dog")
                {
                    string imgPath = Path.GetFullPath(@"..\..\Images\pets\скотч.png");
                    return imgPath;
                }
                if (CurrentUser.Animal.Species.SpeciesName == "Deer")
                {
                    string imgPath = Path.GetFullPath(@"..\..\Images\pets\олень.png");
                    return imgPath;
                }
            }
                return null;
            

        }
        //формирование соответствия png 
        //api city time the on 
        //про

        public Species FindSpecies(string name)
        {
            using (var db = new Context())
            {
                var sp = db.SpeciesTable.FirstOrDefault(x => x.SpeciesName == name);
                return sp;
            }
        }

        public void AddAnAnimal(Animal animal)
        {
            using (var db = new Context())
            {
                db.AnimalTable.Add(animal);
            }
        }

        //public int FoodValue()
        //{
        //    int value = 0;
        //    return value;
        //}
    }
}
