using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Relations;

namespace WoofTwo.Classes
{
    public class Food
    {

        public int FoodId { get; set; }
        public int FoodPoints { get; set; }
        public virtual List<NeedsRelations> NeedsRelation { get; set; }

        
    }
}
