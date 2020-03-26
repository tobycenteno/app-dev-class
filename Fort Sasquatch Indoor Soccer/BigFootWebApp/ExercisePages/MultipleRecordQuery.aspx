<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultipleRecordQuery.aspx.cs" Inherits="BigFootWebApp.ExercisePages.MultipleRecordQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
       <h2> Multiple Record Query - Code Behind</h2>
    </div>
      <div class="row col-md-12">
        <div class="alert alert-info">
            <p><strong>About: </strong> This page will demonstrate a multiple record query display to a GridView using code behind without using ObjectDataSource controls. 
                The page will demonstrate customization of the GridView covering templates, column selection, column headers, caption (with Bootstrap formatting), 
                dataset member referencing (Eval("")) and paging. The page will demonstrate the implementation of the paging event PageIndexChanging().</p>

        </div>
    </div>
    <div class="offset-2">
        <asp:Label ID="Label1" runat="server" Text="Teams: "></asp:Label>&nbsp;&nbsp;   
        <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Search" runat="server" Text="Search" 
             CausesValidation="false" OnClick="Search_Click"/>
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
        <br />
        <asp:Label runat="server" Text="Coach:"></asp:Label>&nbsp;&nbsp;
        <asp:Label id="Coach" runat="server" ></asp:Label>
        <br />
        <asp:Label runat="server" Text="Assistant Coach:"></asp:Label>&nbsp;&nbsp;
        <asp:Label id="AssistantCoach" runat="server" ></asp:Label>
         <br />
        <asp:Label runat="server" Text="Wins:"></asp:Label>&nbsp;&nbsp;
        <asp:Label id="Wins" runat="server" ></asp:Label>
         <br />
        <asp:Label runat="server" Text="Losses:"></asp:Label>&nbsp;&nbsp;
        <asp:Label id="Losses" runat="server" ></asp:Label>
        <br />
        <br />
        <br />
        <asp:GridView ID="TeamRoster" runat="server"></asp:GridView>
    </div>
</asp:Content>
