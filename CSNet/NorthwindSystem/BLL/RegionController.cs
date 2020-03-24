using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NorthWindSystem.DAL;
using NorthWindSystem.Entities;

namespace NorthwindSystem.BLL
{
    public class RegionController
    {
        public List<Region> Regions_List()
        {

        }

        public Region Regions_FindByID(int regionid)
        {
            using(var context = new NorthwindContext())
            {
                return context.Regions.Find(regionid);
            }
        }

    }



}
