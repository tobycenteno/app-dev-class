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
    public class TeamController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
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
