using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Classes;

namespace WoofTwo
{
    class Context : DbContext
    {
        public DbSet<Food> FoodTable { get; set; }
        public DbSet<Sleep> SleepTable { get; set; }
        public DbSet<Poop> PoopTable { get; set; }

        public Context() : base("localsqll")
        {
            // To specify an explicit connection or DB name call the base class constructor
        }

    }
}
