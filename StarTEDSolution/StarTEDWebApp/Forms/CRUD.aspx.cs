using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using StarTEDSystem.Entities;
using StarTEDSystem.BLL;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

namespace StarTEDWebApp.Forms
{
    public partial class CRUD : System.Web.UI.Page
    {
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {

            }
        }

        protected void BindRentalsList()
        {
            //standard lookup
            try
            {
                RentalsController sysmgr = new RentalsController();
                List<Rentals> info = null;
                info = sysmgr.Rentals_FindByLandlord(int.Parse(LandlordList.SelectedValue));
                info.Sort((x, y) => x.AddressID.CompareTo(y.AddressID));
                AddressSearchList.DataSource = info;
                AddressSearchList.DataTextField = nameof(Rentals.AddressID);
                AddressSearchList.DataValueField = nameof(Rentals.RentalID);
                AddressSearchList.DataBind();
                AddressSearchList.Items.Insert(0, "Select an Address...");

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
            //drill down to the inner most exception
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void FindRentalAddresses_Click(object sender, EventArgs e)
        {
            if (LandlordList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a landlord to obtain rental address/es.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                AddressSearchList.DataSource = null;
                AddressSearchList.DataBind();
            }
            else
            {
                try
                {
                   // Clear_Click(sender, e);
                    RentalsController sysmgr = new RentalsController();
                    List<Rentals> info = sysmgr.Rentals_FindByLandlord(int.Parse(LandlordList.SelectedValue));

                    AddressesController addControl = new AddressesController();

                    foreach (Rentals item in info) // Loop through List with foreach
                    {
                        item.AddressName = (addControl.Addresses_FindByID(item.AddressID)).FullAddress;
                    }

                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the landlord");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        AddressSearchList.DataSource = null;
                        AddressSearchList.DataBind();
                    }
                    else
                    {
                        info.Sort((x, y) => x.AddressID.CompareTo(y.AddressID));
                        AddressSearchList.DataSource = info;
                        AddressSearchList.DataTextField = nameof(Rentals.AddressName);
                        AddressSearchList.DataValueField = nameof(Rentals.RentalID);
                        AddressSearchList.DataBind();
                        AddressSearchList.Items.Insert(0, "Select an Address...");


                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void FindRental_Click(object sender, EventArgs e)
        {
            if (AddressSearchList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a rental to maintain");
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    RentalsController rentalsctrlr = new RentalsController();
                    Rentals info = null;
                    info = rentalsctrlr.Rentals_FindByID(int.Parse(AddressSearchList.SelectedValue));

                    AddressesController addressctrlr = new AddressesController();
                    Addresses address = null;
                    List<Addresses> alladdresses = addressctrlr.Address_List();

                    address = addressctrlr.Addresses_FindByID(info.AddressID);

                    if (info == null)
                    {
                        errormsgs.Add("Cannot find Rental in database.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        RentalID.Text = info.RentalID.ToString();

                        AddressNumber.Text = address.Number;
                        AddressStreet.Text = address.Street;

                        alladdresses.Sort((x, y) => x.FullAddress.CompareTo(y.FullAddress));
                        AddressDetailList.DataSource = alladdresses;
                        AddressDetailList.DataTextField = nameof(Addresses.FullAddress);
                        AddressDetailList.DataValueField = nameof(Addresses.AddressID);
                        AddressDetailList.DataBind();
                        AddressDetailList.Items.Insert(0, "Select an Address...");
                        AddressDetailList.SelectedValue = address.AddressID.ToString();

                        AddressID.Text = address.AddressID.ToString();
                        SelectedAddress.Text = address.FullAddress;

                        if (info.RentalTypeID.HasValue)
                        {
                            RentalTypeList.SelectedValue = info.RentalTypeID.ToString();
                        }
                        else
                        {
                            RentalTypeList.SelectedIndex = 0;
                        }

                        MonthlyRent.Text = string.Format("{0:0.00}", info.MonthlyRent);
                        Vacancies.Text = info.Vacancies.ToString();
                        MaxVacancy.Text = info.MaxVacancy.ToString();
                        DamageDeposit.Text = string.IsNullOrEmpty(info.DamageDeposit.ToString()) ? "" : string.Format("{0:0.00}", info.DamageDeposit);
                        AvailableDate.Text = string.IsNullOrEmpty(info.AvailableDate.ToString()) ? "" : info.AvailableDate.Value.ToString("yyyy-MM-dd");
                    }


                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void FindByPartialStreetAddress_Click(object sender, EventArgs e)
        {
            AddressDetailList.DataSource = null;
            AddressDetailList.DataBind();

            if (string.IsNullOrEmpty(AddressNumber.Text) || string.IsNullOrEmpty(AddressStreet.Text))
            {
                errormsgs.Add("Please provide Number and Street to search.");
                LoadMessageDisplay(errormsgs, "alert alert-info");

            }
            else
            {
                try
                {
                    AddressesController sysmgr = new AddressesController();
                    List<Addresses> info = sysmgr.Addresses_FindByPartialStreetAddress(AddressNumber.Text, AddressStreet.Text);


                    if (info.Count == 0)
                    {
                        errormsgs.Add("No data found for the supplied number and street.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        AddressDetailList.DataSource = null;
                        AddressDetailList.DataBind();
                    }
                    else
                    {
                        info.Sort((x, y) => x.FullAddress.CompareTo(y.FullAddress));
                        //Second Dropdown list drill down
                        AddressDetailList.DataSource = info;
                        AddressDetailList.DataTextField = nameof(Addresses.FullAddress);
                        AddressDetailList.DataValueField = nameof(Addresses.AddressID);
                        AddressDetailList.DataBind();
                        AddressDetailList.Items.Insert(0, "Select an Address...");


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
            LandlordList.ClearSelection();
            AddressSearchList.Items.Clear();
            RentalID.Text = "";
            AddressNumber.Text = "";
            AddressStreet.Text = "";
            AddressDetailList.Items.Clear();
            SelectedAddress.Text = "";
            AddressID.Text = "";
            RentalTypeList.ClearSelection();
            MonthlyRent.Text = "";
            Vacancies.Text = "";
            MaxVacancy.Text = "";
            DamageDeposit.Text = "";
            AvailableDate.Text = "";
        }

        protected void SelectAddress_Click(object sender, EventArgs e)
        {
            if (AddressDetailList.SelectedIndex <= 0)
            {
                errormsgs.Add("No address is selected.");
                LoadMessageDisplay(errormsgs, "alert alert-info");
                AddressID.Text = "";
                SelectedAddress.Text = "";

            }
            else
            {
                AddressID.Text = AddressDetailList.SelectedIndex.ToString();
                SelectedAddress.Text = AddressDetailList.SelectedItem.Text;
            }
        }

        protected void AddRental_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (string.IsNullOrEmpty(AddressID.Text))
                {
                    errormsgs.Add("Address is required.");
                }

                if (errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {
                    try
                    {
                        RentalsController sysmgr = new RentalsController();
                        Rentals item = new Rentals();

                        item.AddressID = int.Parse(AddressID.Text);

                        if (RentalTypeList.SelectedIndex == 0)
                        {
                            item.RentalTypeID = null;
                        }
                        else
                        {
                            item.RentalTypeID = int.Parse(RentalTypeList.SelectedValue);
                        }
                        item.MonthlyRent = decimal.Parse(MonthlyRent.Text);
                        item.Vacancies = byte.Parse(Vacancies.Text);
                        item.MaxVacancy = byte.Parse(MaxVacancy.Text);

                        if (string.IsNullOrEmpty(DamageDeposit.Text))
                        {
                            item.DamageDeposit = null;
                        }
                        else
                        {
                            item.DamageDeposit = decimal.Parse(DamageDeposit.Text);
                        }

                        if (string.IsNullOrEmpty(AvailableDate.Text))
                        {
                            item.AvailableDate = null;
                        }
                        else
                        {
                            item.AvailableDate = DateTime.Parse(AvailableDate.Text);
                        }

                        int newRentalID = sysmgr.Rentals_Add(item);

                        RentalID.Text = newRentalID.ToString();
                        errormsgs.Add("Rental has been added");
                        LoadMessageDisplay(errormsgs, "alert alert-success");

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

        protected void UpdateRental_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                if (string.IsNullOrEmpty(AddressID.Text))
                {
                    errormsgs.Add("Address is required.");
                }

                int rentalid = 0;
                if (string.IsNullOrEmpty(RentalID.Text))
                {
                    errormsgs.Add("Search for a rental to update");
                }
                else if (!int.TryParse(RentalID.Text, out rentalid))
                {
                    errormsgs.Add("Rental id is invalid");
                }
                else if (rentalid < 1)
                {
                    errormsgs.Add("Rental id is invalid");
                }

                if (errormsgs.Count > 0)
                {
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
                else
                {

                    try
                    {

                        RentalsController sysmgr = new RentalsController();
                        Rentals item = new Rentals();

                        item.RentalID = rentalid;
                        item.AddressID = int.Parse(AddressID.Text);

                        if (RentalTypeList.SelectedIndex == 0)
                        {
                            item.RentalTypeID = null;
                        }
                        else
                        {
                            item.RentalTypeID = int.Parse(RentalTypeList.SelectedValue);
                        }
                        item.MonthlyRent = decimal.Parse(MonthlyRent.Text);
                        item.Vacancies = byte.Parse(Vacancies.Text);
                        item.MaxVacancy = byte.Parse(MaxVacancy.Text);

                        if (string.IsNullOrEmpty(DamageDeposit.Text))
                        {
                            item.DamageDeposit = null;
                        }
                        else
                        {
                            item.DamageDeposit = decimal.Parse(DamageDeposit.Text);
                        }

                        if (string.IsNullOrEmpty(AvailableDate.Text))
                        {
                            item.AvailableDate = null;
                        }
                        else
                        {
                            item.AvailableDate = DateTime.Parse(AvailableDate.Text);
                        }

                        int rowsaffected = sysmgr.Rentals_Update(item);

                        if (rowsaffected > 0)
                        {

                            errormsgs.Add("Rental has been updated");
                            LoadMessageDisplay(errormsgs, "alert alert-success");

                            BindRentalsList(); 
                            AddressSearchList.SelectedValue = RentalID.Text;
                        }
                        else
                        {
                            errormsgs.Add("Rental has not been updated. Rental was not found.");
                            LoadMessageDisplay(errormsgs, "alert alert-info");
                            BindRentalsList(); 

                        }

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

        protected void DeleteRental_Click(object sender, EventArgs e)
        {

              int rentalid = 0;
              if (string.IsNullOrEmpty(RentalID.Text))
              {
                  errormsgs.Add("Search for a rental to Remove");
              }
              else if (!int.TryParse(RentalID.Text, out rentalid))
              {
                  errormsgs.Add("Rental id is invalid");
              }
              else if (rentalid < 1)
              {
                  errormsgs.Add("Rental id is invalid");
              }

              if (errormsgs.Count > 0)
              {
                  LoadMessageDisplay(errormsgs, "alert alert-info");
              }
              else
              {

                  try
                  {
                      RentalsController sysmgr = new RentalsController();

                      //issue the BLL call
                      int rowsaffected = sysmgr.Rentals_Delete(rentalid);
                      //give feedback
                      if (rowsaffected > 0)
                      {

                          errormsgs.Add("Rental has been removed.");
                          LoadMessageDisplay(errormsgs, "alert alert-success");
                          BindRentalsList(); //by default, list will be at index 0
                        Clear_Click(sender, e);
                    }
                      else
                      {
                          errormsgs.Add("Rental has not been removed. Rental was not found.");
                          LoadMessageDisplay(errormsgs, "alert alert-warning");
                        BindRentalsList(); 
                        Clear_Click(sender, e);
                    }

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