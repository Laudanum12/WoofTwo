using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Relations;

namespace WoofTwo.Classes
{
    public class Poop
    {
        public int PoopId { get; set; }
        public int PoopPoints { get; set; }
        public virtual List<NeedsRelations> NeedsRelation { get; set; }

    }
}
