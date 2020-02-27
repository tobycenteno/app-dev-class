<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <h3 runat="server" id="h3Text"> showing splitting view</h3>
    <p>
        <input id="btnHTMLButton" type="button" value="HTML Button" />
    </p>
    <p>
        <asp:Button ID="Button2" runat="server" Text="ASP Button" onclick="Button2_Click"/>
    </p>
    <p>
        <input id="Button1" type="submit" value="HTML server control" runat="server" />
    </p>
</asp:Content>
