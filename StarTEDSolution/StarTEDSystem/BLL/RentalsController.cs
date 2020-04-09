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
    }
}
