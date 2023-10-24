<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Admin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 667px; margin-left: 126px;border:1px solid #808080 ">
    <tr>
        <td style="text-align: right">
            USER NAME
        </td>
        <td>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            OLD PASSWORD:</td>
        <td>
            <asp:TextBox ID="txtOldpassword" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            NEW PASSWORD:</td>
        <td>
            <asp:TextBox ID="txtNewpassword" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            CONFIRM NEW PASSWORD:</td>
        <td>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="txtNewpassword" ControlToValidate="txtConfirmPassword" 
                ErrorMessage="Plz enter Same Password" Font-Bold="True" ForeColor="#FF0066"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="SUBMIT" />
            <asp:Label ID="lblRres" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

