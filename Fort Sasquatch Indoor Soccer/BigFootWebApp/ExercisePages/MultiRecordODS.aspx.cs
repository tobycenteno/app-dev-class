using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace BigFootWebApp.ExercisePages
{
    
    public partial class MultiRecordODS : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();

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

        protected void SearchPlayers_Click(object sender, EventArgs e)
        {
            // check age if null/empty
            if (string.IsNullOrEmpty(Age.Text))
             {
                 errormsgs.Add("Age is required.");
                 LoadMessageDisplay(errormsgs, "alert alert-danger");
                 PlayerGridView.DataSource = null;
                 PlayerGridView.DataBind();
             } else
             {  
                // check age if numeric
                if (!Regex.IsMatch(Age.Text, @"^\d+$"))
                {
                    Age.Text = null;
                    errormsgs.Add("Age should be numeric value.");
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                    PlayerGridView.DataSource = null;
                    PlayerGridView.DataBind();
                } else
                {
                    // check age if greater than 0
                    if (int.Parse(Age.Text) <= 0)
                    {
                        errormsgs.Add("Age should be greater than 0.");
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                        PlayerGridView.DataSource = null;
                        PlayerGridView.DataBind();
                    }
                }
             }

             // check if gender is selected
             if (Gender.SelectedIndex < 0) 
             {
                 errormsgs.Add("Gender is required.");
                 LoadMessageDisplay(errormsgs, "alert alert-danger");
                 PlayerGridView.DataSource = null;
                 PlayerGridView.DataBind();
             }
        }

        protected void PlayerGridView_DataBound(object sender, EventArgs e)
        {
            if (Page.IsPostBack && PlayerGridView.Rows.Count == 0 && Message.DataSource == null)
            {
                errormsgs.Add("No data available at this time.");
                LoadMessageDisplay(errormsgs, "alert alert-info");

            }
        }
    }
}