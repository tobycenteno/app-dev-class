<%@ Page Title="CRUD - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="StarTEDWebApp.Forms.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h4>CRUD Form</h4>
    <hr />
    <br />

    <asp:RequiredFieldValidator ID="RequiredAddress" runat="server"
        ErrorMessage="Address is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="SelectedAddress"> </asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredMonthlyRent" runat="server"
        ErrorMessage="Monthly Rent is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="MonthlyRent"> </asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredVacancies" runat="server"
        ErrorMessage="Vacancies is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="Vacancies"> </asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredMaxVacancy" runat="server"
        ErrorMessage="Maximum Vacancy is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="MaxVacancy"> </asp:RequiredFieldValidator>
    
    
    <asp:CompareValidator ID="CompareMonthlyRent" runat="server" ErrorMessage="Monthly Rent should be greater than 0." ForeColor="Firebrick"
        Operator="GreaterThan" ValueToCompare="0" ControlToValidate="MonthlyRent" Display="None"></asp:CompareValidator>
    <asp:CompareValidator ID="CompareMaxVacancy" runat="server" ErrorMessage="Max Vacancy should be greater than 0." ForeColor="Firebrick"
        Operator="GreaterThan" ValueToCompare="0" ControlToValidate="MaxVacancy" Display="None"></asp:CompareValidator>
    <asp:CompareValidator ID="CompareDamageDeposit" runat="server" ErrorMessage="Damage deposit should be greater than 0." ForeColor="Firebrick"
        Operator="GreaterThan" ValueToCompare="0" ControlToValidate="DamageDeposit" Display="None"></asp:CompareValidator>

    <asp:CompareValidator ID="CompareVacancies" runat="server" ErrorMessage="Vacancies should be equal or greater than 0." ForeColor="Firebrick"
        Operator="GreaterThanEqual" ValueToCompare="0" ControlToValidate="Vacancies" Display="None"></asp:CompareValidator>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
         HeaderText="Address the following concerns with your entered data." CssClass="alert alert-danger"/>
    <asp:DataList ID="Message" runat="server">
                <ItemTemplate>
                    <%# Container.DataItem %>
                </ItemTemplate>
             </asp:DataList>
    <div class="col-md-12"> 
        <asp:Label ID="Label5" runat="server" Text="Search Rentals: "></asp:Label><br /><br />
        <asp:Label ID="Label3" runat="server" Text="LandLords:"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="LandlordList" runat="server" AppendDataBoundItems="True" DataSourceID="LandLordsDataSource" DataTextField="Name" DataValueField="LandlordID">
        <asp:ListItem Value="">Select a Landlord</asp:ListItem>
        </asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="FindRentalAddresses" runat="server" Text="Rental Address(es)?" OnClick="FindRentalAddresses_Click" CausesValidation="false"/><br /><br />
        <asp:Label ID="label6" runat="server" Text="Address(es):"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="AddressSearchList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="FindRental" runat="server" Text="Select" OnClick="FindRental_Click" CausesValidation="false"  />&nbsp;&nbsp;
        <asp:Button ID="Clear" runat="server" Text="Clear" OnClick="Clear_Click" CausesValidation="false" />&nbsp;&nbsp;
        <asp:Button ID="AddRental" runat="server" Text="Add" OnClick="AddRental_Click"   />&nbsp;&nbsp;
        <asp:Button ID="UpdateRental" runat="server" Text="Update" OnClick="UpdateRental_Click"  />&nbsp;&nbsp;
        <asp:Button ID="DeleteRental" runat="server" Text="Delete" CausesValidation="false" OnClick="DeleteRental_Click" />
             <br />
        <asp:ObjectDataSource ID="LandLordsDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="LandLords_List" TypeName="StarTEDSystem.BLL.PropertyOwnersController"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="AddressDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Address_List" TypeName="StarTEDSystem.BLL.AddressesController"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="RentalTypeDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="RentalType_List" TypeName="StarTEDSystem.BLL.RentalTypesController"></asp:ObjectDataSource>
        <br />
             
        </div>
    <div class ="row">
            <div class="col-md-6">
                <div class="text-right" >
                <asp:Label ID="Label12" runat="server" Text="Rental ID:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label2" runat="server" Text="Number:" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label1" runat="server" Text="Street:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                
                <asp:Label ID="Label4" runat="server" Text="Address:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label14" runat="server" Text="Selected Address:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label7" runat="server" Text="Rental Type:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label13" runat="server" Text="Monthly Rent:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label8" runat="server" Text="Vacancies:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label9" runat="server" Text="Maximum Vacancy:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label10" runat="server" Text="Damage Deposit:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label11" runat="server" Text="Available Date:" Font-Size="Larger" ></asp:Label>&nbsp;&nbsp;<br />
                </div>
             </div>
            <div class="col-md-6 ">
                <asp:Label ID="RentalID" runat="server" ></asp:Label><br />
                <asp:TextBox ID="AddressNumber" runat="server" ></asp:TextBox><br />
                <asp:TextBox ID="AddressStreet" runat="server" ></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="FindByPartialStreetAddress" runat="server" Text="Address?" OnClick="FindByPartialStreetAddress_Click" CausesValidation="false" /><br />
                <asp:DropDownList ID="AddressDetailList" runat="server" Width="350px">
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:Button ID="SelectAddress" runat="server" Text="Select" OnClick="SelectAddress_Click" CausesValidation="false" /><br />
                <asp:TextBox ID="SelectedAddress" runat="server" Enabled="False"></asp:TextBox><asp:Label ID="AddressID" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp; <asp:Button ID="ClearAddress" runat="server" Text="Clear Address" OnClick="ClearAddress_Click" CausesValidation="false" /><br />
                <asp:DropDownList ID="RentalTypeList" runat="server"  Width="350px" DataSourceID="RentalTypeDataSource" DataTextField="Description" DataValueField="RentalTypeID" AppendDataBoundItems="True">
                    <asp:ListItem>Select a Rental Type...</asp:ListItem>
                </asp:DropDownList><br />
                <asp:TextBox type="number" ID="MonthlyRent" runat="server" ></asp:TextBox><br />
                <asp:TextBox type="number" ID="Vacancies" runat="server" ></asp:TextBox><br />
                <asp:TextBox type="number" ID="MaxVacancy" runat="server" ></asp:TextBox><br />
                <asp:TextBox type="number" ID="DamageDeposit" runat="server" ></asp:TextBox><br />
                <asp:TextBox type="date" ID="AvailableDate" runat="server" ></asp:TextBox><br />
            </div>
        </div>
</asp:Content>
