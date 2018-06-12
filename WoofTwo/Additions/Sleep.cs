using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Relations;

namespace WoofTwo.Classes
{
    public class Sleep
    {
        public int SleepId { get; set; }
        public int SleepPoints { get; set; }
        public virtual List<Needs> NeedsRelation { get; set; }


    }
}
