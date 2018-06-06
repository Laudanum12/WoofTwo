using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Relations;

namespace WoofTwo.Classes
{
    public class Needs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NeedsId { get; set; }
        [NotMapped]
        public List<Food> Foods { get; set; }
        [NotMapped]
        public List<Sleep> Sleeps { get; set; }
        [NotMapped]
        public List<Poop> Poops { get; set; }
        public virtual List<NeedsRelations> NeedsRelation { get; set; }
        public Species Species { get; set; }
    }
}
