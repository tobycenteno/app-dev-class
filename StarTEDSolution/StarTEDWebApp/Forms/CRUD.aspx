<%@ Page Title="CRUD - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="StarTEDWebApp.Forms.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>CRUD Form</h4>
    <hr />
    <br />
    <div class="container">
        <h5>Search Rentals:</h5>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="LandLords:" CssClass="col-md-4 control-label"></asp:Label>
            <div class="col-sm-8">
                <asp:DropDownList ID="LandLordList" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;   
                <asp:Button ID="FindAddressesByLandLord" runat="server" Text="Rental Addresses?" OnClick="FindAddressesByLandLord_Click"/>
            </div>
         </div>
        <div class="form-group">
            <asp:Label ID="label6" runat="server" Text="Address(es):"></asp:Label>
            <div class="col-sm-8">
                <asp:DropDownList ID="AddressList" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;   
                <asp:Button ID="FindRentalsByLandLord" runat="server" Text="Select" OnClick="FindRentalsByLandLord_Click"/>
            </div>
         </div>
    </div>
</asp:Content>
