using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSISSystem.ACent.BLL;
using FSISSystem.ACent.Entities;

namespace BigFootWebApp.ExercisePages
{
    public partial class MultipleRecordQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                BindTeamList();
            }
        }

        protected void BindTeamList()
        {
            try
            {
                TeamController sysmgr = new TeamController();
                List<Team> teamList = null;

                teamList = sysmgr.Team_List();
                teamList.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));

                TeamList.DataSource = teamList;
                TeamList.DataTextField = nameof(Team.TeamName);
                TeamList.DataValueField = nameof(Team.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0, "Select...");

            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (TeamList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a team to view its roster.";
            }
            else
            {
                int teamid = int.Parse(TeamList.SelectedValue);

                try
                {
                    TeamController teamMgr = new TeamController();
                    Team teamInfo = null;
                    teamInfo = teamMgr.Team_Find(teamid);

                    if (teamInfo == null)
                    {
                        MessageLabel.Text = "Team not found.";
                        Coach.Text = "";
                        AssistantCoach.Text = "";
                        Wins.Text = "";
                        Losses.Text = "";
                    }
                    else
                    {
                        Coach.Text = teamInfo.Coach;
                        AssistantCoach.Text = teamInfo.AssistantCoach;
                        Wins.Text = teamInfo.Wins.ToString() == "" ? "0" : teamInfo.Wins.ToString();
                        Losses.Text = teamInfo.Losses.ToString() == "" ? "0" : teamInfo.Losses.ToString();
                    }

                    PlayerController playerMgr = new PlayerController();
                    List<Player> info = null;

                    info = playerMgr.Player_GetByTeam(teamid);
                    info.Sort((x, y) => x.LastName.CompareTo(y.LastName));
                    TeamRoster.DataSource = info;

                    TeamRoster.DataBind();


                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void TeamRoster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TeamRoster.PageIndex = e.NewPageIndex;

            Search_Click(sender, new EventArgs());
        }
    }
}