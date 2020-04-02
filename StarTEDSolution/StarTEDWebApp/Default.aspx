<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StarTEDWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <br />
    <h5>Form Description</h5>
    <ul>
        <li>CRUD.aspx</li>
        <li>Query.aspx</li>
    </ul>
    <br />
    <h5>Known Bugs</h5>
    <br />
    <h5>Entity Relationship Diagram</h5>
    <asp:Image ID="ERD" runat="server" ImageUrl="images/A15-ERD.jpg" />
    <br />
    <h5>Class Diagrams</h5>
    <h6>Entities</h6>
    <asp:Image ID="EntitiesClassDiagram" runat="server" ImageUrl="images/class-diagram-entities.jpg" />
    <h6>BLL</h6>
    <br />
    <h5>Stored Procedures</h5>
    <ul>
        <li><code>Rentals_FindByLandlord</code> - Returns zero or more Rentals records for the supplied landlord id</li>
        <li><code>Addresses_FindByPartialStreetAddress</code> - Returns zero or more Addresses whos Number and Street contains the supplied values.</li>
        <li><code>Rentals_FindByMontlyRateRange</code> - Returns zero or more Rentals whos MonthlyRent is within a specified range.</li>
    </ul>
    <br />
</asp:Content>
