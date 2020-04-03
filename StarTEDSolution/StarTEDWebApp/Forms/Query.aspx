<%@ Page Title="ODS - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="StarTEDWebApp.Forms.Query" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h4>Query Form</h4>
    <hr />
    <br />
    <div class="container">
        <h5>Search Rentals by Monthly Range:</h5>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Minimum:" CssClass="col-md-4 control-label"></asp:Label>
            <div class="col-sm-8">
                <asp:TextBox id="MinRange" runat="server"></asp:TextBox>&nbsp;&nbsp;  
            </div>
         </div>
        <div class="form-group">
            <asp:Label ID="label6" runat="server" Text="Maximum:" CssClass="col-md-4 control-label"></asp:Label>
            <div class="col-sm-8">
                <asp:TextBox id="MaxRange" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;   
            </div>
         </div>
        <div class="form-group">
            &nbsp;&nbsp;&nbsp;<asp:Button ID="FindRentalsByMonthlyRange" runat="server" Text="Search" OnClick="FindRentalsByMonthlyRange_Click"/>
        </div>
    </div>
</asp:Content>
