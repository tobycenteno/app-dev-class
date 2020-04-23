using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using StarTEDSystem.DAL;
using StarTEDSystem.Entities;
using System.ComponentModel;

namespace StarTEDSystem.BLL
{
    [DataObject(true)]
    public class AddressesController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Addresses> Address_List()
        {
            using (var context = new StarTEDContext())
            {
                return context.Addresses.ToList();
            }
        }

        public List<Addresses> Address_FindByLandlord(int landlordid)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<Addresses> results =
                    context.Database.SqlQuery<Addresses>("Addresses_FindByLandLord @landlordid", new SqlParameter("landlordid", landlordid));

                return results.ToList();
            }
        }

        public Addresses Addresses_FindByID(int addressid)
        {
            using (var context = new StarTEDContext())
            {
                return context.Addresses.Find(addressid);
            }
        }

        

        public List<Addresses> Addresses_FindByPartialStreetAddress(string number, string street)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<Addresses> results =
                    context.Database.SqlQuery<Addresses>("Addresses_FindByPartialStreetAddress @number,@street", new SqlParameter("number", number), new SqlParameter("street", street));

                return results.ToList();
            }
        }

    }
}
