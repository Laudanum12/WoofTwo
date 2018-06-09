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
        [ForeignKey("User")]
        [Key]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public int SpeciesId { get; set; }
        
        public User User { get; set; }
    }
}
