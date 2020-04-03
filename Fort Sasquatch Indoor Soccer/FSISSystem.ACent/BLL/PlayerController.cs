using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using FSISSystem.ACent.DAL;
using FSISSystem.ACent.Entities;
using System.ComponentModel;

namespace FSISSystem.ACent.BLL
{
    [DataObject]
    public class PlayerController
    {
        public List<Player> Player_GetByTeam(int teamid)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results =
                    context.Database.SqlQuery<Player>("Player_GetByTeam @TeamID", new SqlParameter("TeamID", teamid));

                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Player> Player_GetByAgeGender(int age, string gender)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results =
                    context.Database.SqlQuery<Player>("Player_GetByAgeGender @Age, @Gender", new SqlParameter("Age", age), new SqlParameter("Gender", gender));

                return results.ToList();
            }
        }
    }
}
