<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JobApplication.aspx.cs" Inherits="WebApp.SamplePages.JobApplication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Job Application</h1>
    <%--create a 2 column form--%>
   
        <div class="col-sm-6">
            <fieldset class="form-horizontal">
                <legend>Job Application Form</legend> 
                <asp:Label ID="Label1" runat="server" Text="Name"
                     AssociatedControlID="FullName"></asp:Label>
                <asp:TextBox ID="FullName" runat="server"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Email"
                     AssociatedControlID="EmailAddress"></asp:Label>
                <asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Text="Phone"
                     AssociatedControlID="PhoneNumber"></asp:Label>
                <asp:TextBox ID="PhoneNumber" runat="server"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Time"
                     AssociatedControlID="FullOrPartTime"></asp:Label>
                <asp:RadioButtonList ID="FullOrPartTime" runat="server"
                     RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem>Full Time&nbsp;&nbsp;</asp:ListItem>
                    <asp:ListItem>Part Time</asp:ListItem>
                </asp:RadioButtonList>
        
                <asp:Label ID="Label5" runat="server" Text="Jobs"
                     AssociatedControlID="Jobs"></asp:Label>
                <asp:CheckBoxList ID="Jobs" runat="server"
                     RepeatLayout="Flow" RepeatDirection="Vertical">
                    <asp:ListItem>Sales</asp:ListItem>
                    <asp:ListItem>Manufacturing</asp:ListItem>
                    <asp:ListItem>Accounting</asp:ListItem>
                    <asp:ListItem>Shipping/Receiving</asp:ListItem>
                </asp:CheckBoxList>
            </fieldset>
        </div>
        <div class="col-sm-6">
            <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />&nbsp;&nbsp;
            <asp:Button ID="clear" runat="server" Text="Clear" height="26px" width="63px" OnClick="clear_Click"
                           /><br />
            <asp:Label ID="Message" runat="server" ></asp:Label>
        </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>

</asp:Content>
