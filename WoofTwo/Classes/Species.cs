using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoofTwo.Classes
{
    public class Species
    {
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public Needs Needs { get; set; }
        //public List<Animal> Animals { get; set; }
                                           //  public Need Food { get; set; }
                                           //  public Need Poop { get; set; }
                                           //  public Need Sleep { get; set; }
    }
}
