<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiRecordODS.aspx.cs" Inherits="BigFootWebApp.ExercisePages.MultiRecordODS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
       <h2>Players: Age/Gender</h2>
    </div>
      <div class="col-md-12">
        <div class="alert alert-info">
            <p><strong>About: </strong> Multiple record query using ODS.</p>
        </div>
    </div>
    <div class="form-group row col-md-12">
        <asp:Label ID="label2" runat="server" Text="Enter age:"></asp:Label>&nbsp;
        <asp:TextBox ID="Age" runat="server" class="form-control" placeholder="Enter player age"></asp:TextBox>&nbsp;&nbsp;  
            <asp:RadioButtonList ID="Gender" runat="server" RepeatColumns="2">
            <asp:ListItem Text ="Male" Value="M" Selected="True"></asp:ListItem>
            <asp:ListItem Text ="Female" Value="F"></asp:ListItem>
        </asp:RadioButtonList>&nbsp;&nbsp;  
        <asp:Button ID="SearchPlayers" runat="server" Text="Search"  OnClick="SearchPlayers_Click" />
                    <asp:ObjectDataSource ID="GVDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Player_GetByAgeGender" TypeName="FSISSystem.ACent.BLL.PlayerController">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Age" DefaultValue="0" Name="age" PropertyName="Text" Type="Int32" />
                            <asp:ControlParameter ControlID="Gender" DefaultValue="M" Name="gender" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="TeamListDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Team_List" TypeName="FSISSystem.ACent.BLL.TeamController"></asp:ObjectDataSource>
        </div>
                    <br />
        <asp:GridView ID="PlayerGridView" runat="server" OnDataBound="PlayerGridView_DataBound" AutoGenerateColumns="False" DataSourceID="GVDataSource" AllowPaging="True" CssClass="table table-striped" GridLines="None" PageSize="5">
            <Columns>
                <asp:TemplateField HeaderText="ID" SortExpression="PlayerID">
                    <ItemTemplate>
                        <asp:Label ID="PlayerID" runat="server" Text='<%# Eval("PlayerID") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" SortExpression="FullName">
                    <ItemTemplate>
                        <asp:Label ID="FullName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Team" SortExpression="TeamID">
                    <ItemTemplate>
                        <asp:DropDownList ID="TeamDDL" runat="server" DataSourceID="TeamListDataSource" DataTextField="TeamName" DataValueField="TeamID" SelectedValue='<%# Eval("TeamID") %>'>
                        </asp:DropDownList>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
            <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="5" />
        </asp:GridView>

    <asp:DataList ID="Message" runat="server" Enabled="False">
        <ItemTemplate>
            <%# Container.DataItem %>
        </ItemTemplate>
    </asp:DataList>
    
</asp:Content>
