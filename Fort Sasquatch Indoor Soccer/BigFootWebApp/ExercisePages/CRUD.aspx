<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="BigFootWebApp.ExercisePages.CRUDInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="page-header">
        <h1>CRUD</h1>
    </div>

    <%-- validations --%>
    <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server" ErrorMessage="First name is required."
        Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="FirstName">
    </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredLastName" runat="server" ErrorMessage="Last name is required."
        Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="LastName">
    </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredAge" runat="server" ErrorMessage="Age is required."
        Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="Age">
    </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredAlbertaHealthCareNumber" runat="server" ErrorMessage="Alberta Health Care number is required."
        Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="AlbertaHealthCareNumber">
    </asp:RequiredFieldValidator>

    <asp:RangeValidator ID="RangeAge" runat="server" 
        ErrorMessage="Age of players must be between 6 and 14" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
         ControlToValidate="Age"  MaximumValue="14" MinimumValue="6" Type="Integer">
    </asp:RangeValidator>

    <asp:RegularExpressionValidator ID="RegularExpressionAHCNumber" runat="server" ErrorMessage="Alberta Health Care number must be 10 digits and starts with 1-9."
        Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="AlbertaHealthCareNumber"
        ValidationExpression="[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]">
    </asp:RegularExpressionValidator>

     <%-- validation summary control--%>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
         HeaderText="Address the following concerns with your entered data." CssClass="alert alert-danger"/>

    <div class="col-md-12"> 
        <asp:Label ID="PlayerListLabel" runat="server" Text="Select a Player:"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="PlayerList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Search" runat="server" CausesValidation="false"  OnClick="Search_Click" Font-Size="Medium" Text="Search"  />&nbsp;&nbsp;
        <asp:Button ID="Clear" runat="server" CausesValidation="false" OnClick="Clear_Click" Font-Size="Medium" Text="Clear"  />&nbsp;&nbsp;
        <asp:Button ID="AddPlayer" runat="server" OnClick="AddPlayer_Click" Font-Size="Medium" Text="Add"  />&nbsp;&nbsp;
        <asp:Button ID="UpdatePlayer" runat="server" OnClick="UpdatePlayer_Click" Font-Size="Medium" Text="Update"  />&nbsp;&nbsp;
        <asp:Button ID="DeletePlayer" runat="server"  OnClientClick="return confirm('Are you sure you wish to delete this player?')" OnClick="DeletePlayer_Click" Font-Size="Medium" Text="Delete"  CausesValidation="false" />&nbsp;&nbsp;
        <br /><br />
        
        <asp:DataList ID="Message" runat="server">
            <ItemTemplate>
                <%# Container.DataItem %>
            </ItemTemplate>
        </asp:DataList>
    </div>

    <div class ="row">
        <div class="col-md-6">
            <div class="labels text-right" >
                <asp:Label ID="Label12" runat="server" Text="ID" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label2" runat="server" Text="Guardian" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label3" runat="server" Text="Team" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label6" runat="server" Text="First Name" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label7" runat="server" Text="Last Name" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label8" runat="server" Text="Age" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label9" runat="server" Text="Gender" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label10" runat="server" Text="Alberta Health Care #" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
                <asp:Label ID="Label11" runat="server" Text="Medical Alert Details" Font-Size="Larger"></asp:Label>&nbsp;&nbsp;<br />
            </div>
        </div>
        <div class="col-md-6">
            <asp:Label ID="PlayerID" runat="server" ></asp:Label><br />
            <asp:DropDownList  ID="GuardianList" runat="server" Width="350px" style="margin-top: 5px;"></asp:DropDownList><br />
            <asp:DropDownList ID="TeamList" runat="server"  Width="350px"></asp:DropDownList><br />
            <asp:TextBox ID="FirstName" runat="server" ></asp:TextBox><br />
            <asp:TextBox ID="LastName" runat="server" ></asp:TextBox><br />
            <asp:TextBox ID="Age" runat="server" ></asp:TextBox><br />
            <asp:RadioButtonList ID="Gender" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text ="Male" Value="M"/>
                <asp:ListItem Text ="Female" Value="F" />
            </asp:RadioButtonList>
            <asp:TextBox ID="AlbertaHealthCareNumber" runat="server" ></asp:TextBox><br />
            <asp:TextBox ID="MedicalAlertDetails" runat="server" ></asp:TextBox><br />
        </div>
    </div>
    <script type=”text/javascript”>
    function confirmDelete() {
        if(confirm(“Are you sure you want to submit the page?”)) {
            return true;
        } else {
            return false;
        }
    }
</script>
</asp:Content>
