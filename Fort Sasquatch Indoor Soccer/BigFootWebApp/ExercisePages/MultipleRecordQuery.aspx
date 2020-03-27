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
    <div>
        <asp:Label ID="Label1" runat="server" Text="Teams: "></asp:Label>&nbsp;&nbsp;   
        <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Search" runat="server" Text="Search" 
             CausesValidation="false" OnClick="Search_Click"/>
        <br />
            <asp:Label style="color: red" ID="MessageLabel" runat="server" ></asp:Label>
        <br /><br />
        <asp:Label runat="server" Text="Coach:" class="font-weight-bold"></asp:Label>&nbsp;&nbsp;
        <asp:Label id="Coach" runat="server" ></asp:Label>
        <br />
        <asp:Label runat="server" Text="Assistant Coach:" class="font-weight-bold"></asp:Label>&nbsp;&nbsp;
        <asp:Label id="AssistantCoach" runat="server" ></asp:Label>
         <br />
        <asp:Label runat="server" Text="Wins:" class="font-weight-bold"></asp:Label>&nbsp;&nbsp;
        <asp:Label id="Wins" runat="server"></asp:Label>
         <br />
        <asp:Label runat="server" Text="Losses:" class="font-weight-bold"></asp:Label>&nbsp;&nbsp;
        <asp:Label id="Losses" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <asp:GridView ID="TeamRoster" 
            OnPageIndexChanging="TeamRoster_PageIndexChanging" runat="server" 
            AllowPaging="True" BorderStyle="None" CssClass="table table-striped" 
            GridLines="None" PageSize="5" AutoGenerateColumns="False" 
            EmptyDataText="No data available at this time."
            Caption="Team Roster"
             style="caption-side:top;">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="FullName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age">
                    <ItemTemplate>
                        <asp:Label ID="Age" runat="server" Text='<%# Eval("Age") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:Label ID="Gender" runat="server" Text='<%# (string)Eval("Gender") == "M" ? "Male" : "Female" %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Med Alert">
                    <ItemTemplate>
                        <asp:Label ID="MedicalAlertDetails" runat="server" Text='<%# Eval("MedicalAlertDetails") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="5" />
        </asp:GridView>
    </div>
</asp:Content>
