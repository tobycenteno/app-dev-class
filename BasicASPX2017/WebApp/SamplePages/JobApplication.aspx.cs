using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clear_Click(object sender, EventArgs e)
        {
            FullName.Text = "";
            EmailAddress.Text = "";
            PhoneNumber.Text = "";
            FullOrPartTime.SelectedIndex = -1; //or
            Jobs.ClearSelection();

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string message = "";
            message += "Name: " + FullName.Text;
            message += " Email: " + EmailAddress.Text;
            message += " Phone: " + PhoneNumber.Text;
            message += " Time: " + FullOrPartTime.SelectedValue;

            //traverse the checkboxlist, review one item
            //at a time and add those items to the message
            //IF no items were choosen then add a message stating
            //that no items were choosen to the message

            message += " Jobs: ";

            bool found = false;

            foreach (ListItem jobrow in Jobs.Items)
            {
                if (jobrow.Selected)
                {
                    message += jobrow.Text + " ";
                    found = true;
                }
            }

            if (!found)
            {
                message += " you did not select a job. Application rejected.";
            }

            Message.Text = message;

        }
    }
}