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
    public class RentalsController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Rentals> Rentals_GetByMonthlyRange(double min, double max)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<Rentals> results =
                    context.Database.SqlQuery<Rentals>("Rentals_FindByMonthlyRateRange @minrange, @maxrange", new SqlParameter("minrange", min), new SqlParameter("maxrange", max));

                return results.ToList();
            }
        }

        public Rentals Rentals_FindByID(int rentalid)
        {
            using (var context = new StarTEDContext())
            {
                return context.Rentals.Find(rentalid);
            }
        }

        public List<Rentals> Rentals_FindByLandlord(int landlordid)
        {
            using (var context = new StarTEDContext())
            {
                IEnumerable<Rentals> results =
                    context.Database.SqlQuery<Rentals>("Rentals_FindByLandlord @landlordid", new SqlParameter("landlordid", landlordid));

                return results.ToList();
            }
        }

        public int Rentals_Add(Rentals item)
        {
            using (var context = new StarTEDContext())
            {
              
                context.Rentals.Add(item);
                context.SaveChanges();
                return item.RentalID;

            }
        }

        public int Rentals_Update(Rentals item)
        {
            using (var context = new StarTEDContext())
            {
                //Staging
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                //Commit and Feedback (rows affected)
                return context.SaveChanges();
            }
        }

        public int Rentals_Delete(int productid)
        {
            using (var context = new StarTEDContext())
            {
                //Physical Delete
                //the physical removal of a record from the database

                ////locate the instance of the entity to be removed
                var existing = context.Rentals.Find(productid);
                ////optional check to see if it is there
                ////if not throw an exception.
                ////this process can also be handled on the web form during feedback
                if (existing == null)
                {
                    throw new Exception("Record has already been removed from database");
                }

                ////Stage
                context.Rentals.Remove(existing);
                ////Commmit and feedback
                return context.SaveChanges();


            }
        }
    }
}


