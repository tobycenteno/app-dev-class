<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="BasicControls.aspx.cs" Inherits="WebApp.SamplePages.BasicControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Basic Controls</h1>
    <table align="center" style="width: 80%">
        <tr>
            <td align="right">TextBox:</td>
            <td>
                <asp:TextBox ID="TextBoxNumberChoice" runat="server" 
                    ></asp:TextBox>
                &nbsp;<asp:Button ID="SubmitButtonChoice" runat="server" 
                    Text="Submit Choice" OnClick="SubmitButtonChoice_Click" />
                &nbsp;Enter a number from 1 to 4</td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                         Font-Size="Medium" 
                    ForeColor="#33CC33" Text="Choice: RadioButtonList"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListChoice" runat="server"
                      RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1">&nbsp;COMP1008&nbsp;</asp:ListItem>
                    <asp:ListItem Value="2">&nbsp;DMIT1508&nbsp;</asp:ListItem>
                    <asp:ListItem Value="3">&nbsp;CPSC1517&nbsp;</asp:ListItem>
                    <asp:ListItem Value="4">&nbsp;DMIT2018&nbsp;</asp:ListItem>

                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Literal ID="Literal1" runat="server" 
                   Text="Choice: CheckBox"></asp:Literal>
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxChoice" runat="server" 
                         Font-Bold="True" Text="Programming Course" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" 
                          Text="Display Label"></asp:Label></td>
            <td>
                <asp:Label ID="DisplayDataReadOnly" runat="server" ></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label4" runat="server" 
                     Text="View Collection"></asp:Label></td>
            <td>
                <asp:DropDownList ID="CollectionList" runat="server"> 
                     </asp:DropDownList>&nbsp;
                <asp:LinkButton ID="LinkButtonSubmitChoice" runat="server" OnClick="LinkButtonSubmitChoice_Click" >
                            Submit Collection Choice</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="MessageLabel" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
