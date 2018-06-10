using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Relations;

namespace WoofTwo.Classes
{
    public class Species
    {
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public virtual Needs Needs { get; set; }
        public virtual List<Animal> Animals { get; set; }
    }
}
