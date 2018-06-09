using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Classes;

namespace WoofTwo.Relations
{
    public class NeedsRelations
    {
        [Key]
        public int NeedsRelationId { get; set; }

        public int FoodIdFK { get; set; }
        public virtual Food Food { get; set; }

        public int PoopIdFK { get; set; }
        public virtual Poop Poop { get; set; }

        public int SleepIdFK { get; set; }
        public virtual Sleep Sleep { get; set; }

        public Species Species { get; set; }

    }
}
