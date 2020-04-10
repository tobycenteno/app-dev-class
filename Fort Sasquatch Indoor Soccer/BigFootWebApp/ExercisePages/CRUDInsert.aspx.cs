using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSISSystem.ACent.BLL;
using FSISSystem.ACent.Entities;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

namespace BigFootWebApp.ExercisePages
{
    public partial class CRUDInsert : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();

            if (!Page.IsPostBack)
            {
                BindPlayerList();
                BindGuardianList();
                BindTeamList();
            }
        }

        protected void BindPlayerList()
        {

            try
            {
                PlayerController sysmgr = new PlayerController();
                List<Player> info = null;
                info = sysmgr.Player_List();
                info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                PlayerList.DataSource = info;
                PlayerList.DataTextField = nameof(Player.FullName);
                PlayerList.DataValueField = nameof(Player.PlayerID);
                PlayerList.DataBind();
                PlayerList.Items.Insert(0, "Select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindGuardianList()
        {

            try
            {
                GuardianController sysmgr = new GuardianController();
                List<Guardian> info = null;
                info = sysmgr.Guardian_List();
                info.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                GuardianList.DataSource = info;
                GuardianList.DataTextField = nameof(Guardian.FullName);
                GuardianList.DataValueField = nameof(Guardian.GuardianID);
                GuardianList.DataBind();
                GuardianList.Items.Insert(0, "Select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindTeamList()
        {

            try
            {
                TeamController sysmgr = new TeamController();
                List<Team> info = null;
                info = sysmgr.Team_List();
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = info;
                TeamList.DataTextField = nameof(Team.TeamName);
                TeamList.DataValueField = nameof(Team.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0, "Select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected Exception GetInnerException(Exception ex)
        {

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a player to maintain.");
                LoadMessageDisplay(errormsgs, "alert alert-danger");

                Clear_Click(sender, e);
            }
            else
            {

                try
                {
                    PlayerController sysmgr = new PlayerController();
                    Player info = null;
                    info = sysmgr.Player_Find(int.Parse(PlayerList.SelectedValue));
                    if (info == null)
                    {
                        errormsgs.Add("Cannot find player in database.");
                        LoadMessageDisplay(errormsgs, "alert alert-danger");

                        Clear_Click(sender, e);
                        BindPlayerList();
                    }
                    else
                    {
                        PlayerID.Text = info.PlayerID.ToString();
                        GuardianList.SelectedValue = info.GuardianID.ToString();
                        TeamList.SelectedValue = info.TeamID.ToString();
                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;
                        Age.Text = info.Age.ToString();
                        Gender.SelectedValue = info.Gender.ToString();
                        AlbertaHealthCareNumber.Text = info.AlbertaHealthCareNumber;
                        MedicalAlertDetails.Text = info.MedicalAlertDetails == null ? "" : info.MedicalAlertDetails;
                    }


                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            PlayerID.Text = "";
            GuardianList.ClearSelection();
            TeamList.ClearSelection();
            FirstName.Text = "";
            LastName.Text = "";
            Age.Text = "";
            Gender.ClearSelection();
            AlbertaHealthCareNumber.Text = "";
            MedicalAlertDetails.Text = "";

            PlayerList.ClearSelection();
        }

        protected void AddPlayer_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (GuardianList.SelectedIndex == 0)
                {
                    errormsgs.Add("Guardian is required");
                }

                if (TeamList.SelectedIndex == 0)
                {
                    errormsgs.Add("Team is required");
                }

                if (Gender.SelectedItem == null)
                {
                    errormsgs.Add("Gender is required");
                }

                //check if click event validation is good
                if (errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                else
                {
                    //assume taht the data is validate to our knowledge
                    try
                    {
                        PlayerController sysmgr = new PlayerController();
                        Player player = new Player();

                        player.GuardianID = int.Parse(GuardianList.SelectedValue);
                        player.TeamID = int.Parse(TeamList.SelectedValue);
                        player.FirstName = FirstName.Text.Trim();
                        player.LastName = LastName.Text.Trim();
                        player.Age = int.Parse(Age.Text.Trim());
                        player.Gender = Gender.SelectedValue;
                        player.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text.Trim();

                        if(string.IsNullOrEmpty(MedicalAlertDetails.Text))
                        {
                            player.MedicalAlertDetails = null;
                        } else
                        {
                            player.MedicalAlertDetails = MedicalAlertDetails.Text.Trim();
                        }

                        int newPlayerID = sysmgr.Player_Add(player);
                        PlayerID.Text = newPlayerID.ToString();

                        errormsgs.Add("Player has been added");
                        LoadMessageDisplay(errormsgs, "alert alert-success");

                        BindPlayerList();
                        PlayerList.SelectedValue = PlayerID.Text;
                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        if (updateException.InnerException != null)
                        {
                            errormsgs.Add(updateException.InnerException.Message.ToString());
                        }
                        else
                        {
                            errormsgs.Add(updateException.Message);
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                errormsgs.Add(validationError.ErrorMessage);
                            }
                        }
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                    catch (Exception ex)
                    {
                        errormsgs.Add(GetInnerException(ex).ToString());
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }
        }
    }
}