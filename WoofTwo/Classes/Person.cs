using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoofTwo.Classes
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public Animal Animal { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Level { get; set; }
        public DateTime DateOfRegistration { get; set; }
        //public int Age { get; set; }
    }
}
