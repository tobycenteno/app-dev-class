using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using NorthWindSystem.DAL.Entities;

namespace NorthWindSystem.DAL
{
    internal class FSISContext:DBContext
    {
        public FSISContext() : base("myconnectionstringname")
        {

        }

        public DBSet<Product> Products { get; set; }
        public DBSet<Region> Products { get; set; }
    }
}
