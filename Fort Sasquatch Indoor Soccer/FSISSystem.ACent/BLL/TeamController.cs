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
    public class TeamController
    {
        public List<Team> Team_List()
        {
            using(var context = new FSISContext())
            {
                return context.Teams.ToList();
            }
        }

        public Team Team_Find(int teamid)
        {
            using (var context = new FSISContext())
            {
                return context.Teams.Find(teamid);
            }
        }
    }
}
