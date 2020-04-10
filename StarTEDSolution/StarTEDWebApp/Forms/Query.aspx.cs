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
            if (string.IsNullOrEmpty(MinRange.Text) && string.IsNullOrEmpty(MaxRange.Text))
            {
                errormsgs.Add("Minimum and Maximum range are required.");
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            else if (string.IsNullOrEmpty(MinRange.Text))
            {
                errormsgs.Add("Minimum range is required.");
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            else if (string.IsNullOrEmpty(MaxRange.Text))
            {
                errormsgs.Add("Maximum range is required.");
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            else
            {
                if (double.Parse(MinRange.Text) < 0 || double.Parse(MaxRange.Text) < 0)
                {
                    errormsgs.Add("Minimum or Maximum Range should be greater or equal to 0.");
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                else
                {
                    if (double.Parse(MinRange.Text) > double.Parse(MaxRange.Text))
                    {
                        errormsgs.Add("Minimum range should be less than maximum range.");
                        LoadMessageDisplay(errormsgs, "alert alert-danger");
                    }
                }
            }

            if (errormsgs.Count != 0 )
            {
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