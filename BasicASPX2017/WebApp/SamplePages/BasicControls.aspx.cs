using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        public static List<DDLClass> DataCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if you need to reset fields on each pass (process) of the page
            // you can do it here
            //page initialization can be done here under the IsPostBack flag

            //the ID= attribute on your control is the name that is use in
            //  your code to reference the control
            //the ID= name is unique to the form
            //each control is an object and behaves as an object
            MessageLabel.Text = "";

            //the test for posting a form back to the web server is IsPostBack
            if (!Page.IsPostBack)
            {
                //load the DropDownList (DDL) only on the first pass of the page
                //In this example a locally create List<T> will act
                //   as the data source for the DDL
                DataCollection = new List<DDLClass>();

                //add instances to the list
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "DMIT1508"));
                DataCollection.Add(new DDLClass(3, "CPSC1517"));
                DataCollection.Add(new DDLClass(4, "DMIT2018"));

                //place the data in the DDL in alphabetic order (ascending)
                //(x,y) represent any two rows in the collection DataCollection
                //Compare x.DisplayField to y.DisplayField, ascending
                //Compare y.DisplayField to x.DisplayField, descending
                DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));

                //to place a collection into the DDL control we need to do 4 steps
                //a) assign the collection to the control's DataSource property
                CollectionList.DataSource = DataCollection;

                //b) assign field names to the properties DataTextField and DataValueField
                //the DataTextField contents the data seen by the user
                //the DataValueField is the data returned by the control on access*
                CollectionList.DataTextField = "DisplayField";
                CollectionList.DataValueField = "ValueField";

                //c) Bind the information and data to your control
                CollectionList.DataBind();

                //d) optional, assign a prompt to your control
                //such that it appears before the data
                CollectionList.Items.Insert(0, "select....");
            }

        }

        protected void SubmitButtonChoice_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "you press the submit button";
        }

        protected void LinkButtonSubmitChoice_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "you press the linkbutton button";
        }
    }
}