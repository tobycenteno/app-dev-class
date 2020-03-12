using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using FSISSystem.ACent.Entities;

namespace FSISSystem.ACent.DAL
{
    internal class FSISContext:DbContext
    {
        public FSISContext() : base("myconnectionstringname")
        {

        }

        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}
