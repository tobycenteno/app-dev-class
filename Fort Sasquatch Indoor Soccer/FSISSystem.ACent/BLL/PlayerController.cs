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
        public List<Player> Player_List()
        {
            using (var context = new FSISContext())
            {
                return context.Players.ToList();
            }
        }
        public Player Player_Find(int playerid)
        {
            using (var context = new FSISContext())
            {
                return context.Players.Find(playerid);
            }
        }

        public int Player_Add(Player player)
        {
            using (var context = new FSISContext())
            {
                context.Players.Add(player);
                context.SaveChanges();
                return player.PlayerID;
            }
        }
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

        public int Player_Update(Player player)
        {
            using (var context = new FSISContext())
            {
                context.Entry(player).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }

        }

        public int Player_Delete(int playerid)
        {
            using (var context = new FSISContext())
            {
                var existing = context.Players.Find(playerid);
                context.Players.Remove(existing);
                return context.SaveChanges();
            }
        }
    }
}
