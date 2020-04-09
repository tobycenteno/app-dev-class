using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarTEDWebApp.Forms
{
    public partial class Query : System.Web.UI.Page
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

        protected void FindRentalsByMonthlyRange_Click(object sender, EventArgs e)
        {
            // check age if null/empty
            if (string.IsNullOrEmpty(MinRange.Text) || string.IsNullOrEmpty(MaxRange.Text))
            {
                errormsgs.Add("Minimum and Maximum range are required.");
                LoadMessageDisplay(errormsgs, "alert alert-danger");
                RentalsGridView.DataSource = null;
                RentalsGridView.DataBind();
            }

        }

        protected void RentalsGridView_DataBound(object sender, EventArgs e)
        {
            if (Page.IsPostBack && RentalsGridView.Rows.Count == 0 && Message.DataSource == null)
            {
                errormsgs.Add("No data available at this time.");
                LoadMessageDisplay(errormsgs, "alert alert-info");

            }
        }
    }
}