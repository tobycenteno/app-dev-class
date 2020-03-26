using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using FSISSystem.ACent.DAL;
using FSISSystem.ACent.Entities;

namespace FSISSystem.ACent.BLL
{
    public class PlayerController
    {
        public List<Player> Player_GetByTeam(int teamid)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results =
                    context.Database.SqlQuery<Player>("SELECT PlayerID, GuardianID, TeamID, FirstName, LastName, Age, Gender, AlbertaHealthCareNumber, MedicalAlertDetails from Player WHERE TeamID=@TeamID", new SqlParameter("TeamID", teamid));

                return results.ToList();
            }
        }
    }
}
