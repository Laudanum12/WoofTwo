using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoofTwo.Classes
{
    public class Animal
    {
        //[ForeignKey("User")]
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public virtual Species Species { get; set; }
        public int SpeciesId { get; set; }

        public int FoodPoints { get; set; }
        public int SleepPoints { get; set; }
        public int PoopPoints { get; set; }

        public virtual User User { get; set; }
    }
}
