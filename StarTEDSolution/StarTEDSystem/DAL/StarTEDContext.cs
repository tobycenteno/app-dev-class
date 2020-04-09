using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using StarTEDSystem.Entities;

namespace StarTEDSystem.DAL
{
    internal class StarTEDContext : DbContext
    {
        public StarTEDContext() : base("StarTED_db")
        {

        }

        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<PropertyOwners> PropertyOwners { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<RentalTypes> RentalTypes { get; set; }
    }
}
