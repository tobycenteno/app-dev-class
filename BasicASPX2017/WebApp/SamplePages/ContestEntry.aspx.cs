using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        private static List<Entry> contestentries = new List<Entry>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            PostalCode.Text = "";
            EmailAddress.Text = "";
            CheckAnswer.Text = "";
            Province.SelectedValue = "0";



        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if(Terms.Checked)
                {
                    Entry theentry = new Entry();

                    theentry.FirstName = FirstName.Text;
                    theentry.LastName = LastName.Text;
                    theentry.StreetAddress1 = StreetAddress1.Text;
                    theentry.StreetAddress2 = string.IsNullOrEmpty(StreetAddress2.Text) ? null : StreetAddress2.Text;
                    theentry.City = City.Text;
                    theentry.EmailAddress = EmailAddress.Text;
                    theentry.PostalCode = PostalCode.Text;
                    theentry.Province = Province.SelectedValue;

                    contestentries.Add(theentry);

                    GridViewContestEntries.DataSource = contestentries;
                    GridViewContestEntries.DataBind();
                }
                else
                {
                    Message.Text = "You did not agree to the Terms. Entry rejected.";
                }
            }
        }
    }
}