using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Helpers;

namespace WoofTwo.Classes
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Level { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string City { get; set; }
        //public int Age { get; set; }

        public User() { }
        public User(string name, string password, string email, DateTime dateTime, int level, string city)
        {
            Name = name;
            Password = PasswordHelper.GetHash(password);
            Email = email;
            Level = level;
            DateOfRegistration = dateTime;
            City = city;
            Animal = new Animal();
        }
        public virtual Animal Animal { get; set; }

    }
}
