using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Additions;
using WoofTwo.Classes;
using WoofTwo.Relations;

namespace WoofTwo
{
    class Context : DbContext
    {
        public DbSet<Food> FoodTable { get; set; }
        public DbSet<Sleep> SleepTable { get; set; }
        public DbSet<Poop> PoopTable { get; set; }
        public DbSet<Needs> NeedsTable { get; set; }
       // public DbSet<NeedsRelations> NeedRelationTable { get; set; }
        public DbSet<Species> SpeciesTable { get; set; }
        public DbSet<Animal> AnimalTable { get; set; }
        public DbSet<User> UserTable { get; set; }
        public DbSet<City> CityTable { get; set; }

        public Context() : base("localsqll")
        {
            // To specify an explicit connection or DB name call the base class constructor
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>()
                        .HasMany(te => te.NeedsRelation)
                        .WithRequired(t => t.Food)
                        .HasForeignKey(tr => tr.FoodIdFK);

            modelBuilder.Entity<Poop>()
                        .HasMany(c => c.NeedsRelation)
                        .WithRequired(c => c.Poop)
                        .HasForeignKey(c => c.PoopIdFK);

            modelBuilder.Entity<Sleep>()
                        .HasMany(c => c.NeedsRelation)
                        .WithRequired(c => c.Sleep)
                        .HasForeignKey(c => c.SleepIdFK);

            modelBuilder.Entity<Species>()
                        .HasRequired(c => c.Needs)
                        .WithRequiredPrincipal(c => c.Species);

            modelBuilder.Entity<Species>()
                        .HasMany(c => c.Animals)
                        .WithRequired(p => p.Species)
                        .HasForeignKey(c => c.SpeciesId);

            modelBuilder.Entity<User>()
                        .HasOptional(c => c.Animal)
                        .WithRequired(c => c.User);

            base.OnModelCreating(modelBuilder);
        }


    }
}
