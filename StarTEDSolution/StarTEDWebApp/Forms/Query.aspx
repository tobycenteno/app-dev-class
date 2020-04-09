<%@ Page Title="ODS - StarTED" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="StarTEDWebApp.Forms.Query" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h4>Query Form</h4>
    <hr />
    <br />
    <div class="container">
        <h5>Search Rentals by Monthly Range:</h5>
        <div class="row col-md-11">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Minimum:" CssClass="col-md-4 control-label"></asp:Label>
                <div class="col-sm-12">
                    <asp:TextBox id="MinRange" runat="server" type="number"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;to
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="label6" runat="server" Text="Maximum:" CssClass="col-md-4 control-label"></asp:Label>
                <div class="col-sm-12">
                    <asp:TextBox id="MaxRange" runat="server" type="number"></asp:TextBox>&nbsp;  
                     &nbsp;&nbsp;&nbsp;<asp:Button ID="FindRentalsByMonthlyRange" runat="server" Text="Search" OnClick="FindRentalsByMonthlyRange_Click" CausesValidation="false"/>
                    <asp:ObjectDataSource ID="RentalsDataSource" runat="server" TypeName="StarTEDSystem.BLL.RentalsController" OldValuesParameterFormatString="original_{0}" SelectMethod="Rentals_GetByMonthlyRange">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="MinRange" DefaultValue="0" Name="min" PropertyName="Text" Type="Double" />
                            <asp:ControlParameter ControlID="MaxRange" DefaultValue="0" Name="max" PropertyName="Text" Type="Double" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="AddressesDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Team_List" TypeName="StarTEDSystem.BLL.AddressesController"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="RentalTypesDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Team_List" TypeName="StarTEDSystem.BLL.RentalTypesController"></asp:ObjectDataSource>
                </div>
            </div>
        </div>
        <asp:DataList ID="Message" runat="server" Enabled="False">
                        <ItemTemplate>
                            <%# Container.DataItem %>
                        </ItemTemplate>
                    </asp:DataList>
        <br />
        <br />
  <asp:GridView ID="RentalsGridView" runat="server" OnDataBound="RentalsGridView_DataBound" AllowPaging="True" AutoGenerateColumns="False" BorderStyle="None" CssClass="table table-striped" DataSourceID="RentalsDataSource" GridLines="None" PageSize="25">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" SortExpression="RentalID" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("RentalID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address" SortExpression="AddressID">
                                <ItemTemplate>
                                    <asp:DropDownList ID="AddressDDL" runat="server" DataSourceID="AddressesDataSource" DataTextField="FullAddress" DataValueField="AddressID" SelectedValue='<%# Eval("AddressID") %>'>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rental Type" SortExpression="RentalTypeID">
                                <ItemTemplate>
                                    <asp:DropDownList ID="RentalTypesDDL" runat="server" DataSourceID="RentalTypesDataSource" DataTextField="Description" DataValueField="RentalTypeID" SelectedValue='<%# Eval("RentalTypeID") == null ? "0" : Eval("RentalTypeID") %>' AppendDataBoundItems="True">
                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Monthly Rent" SortExpression="MonthlyRent">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# string.Format("{0:0.00}", Eval("MonthlyRent")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Vacancies" SortExpression="Vacancies">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Vacancies") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Maximum Vacancy" SortExpression="MaxVacancy">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("MaxVacancy") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Damage Deposit" SortExpression="DamageDeposit">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# string.Format("{0:0.00}", Eval("DamageDeposit")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Available Date" SortExpression="AvailableDate">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("AvailableDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="5" />
                    </asp:GridView>
    </div>
</asp:Content>
