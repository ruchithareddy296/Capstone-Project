<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td style="text-align: right; width: 314px; height: 29px;">
                <asp:Label ID="Label1" runat="server" Text="FirstName:"></asp:Label>
            </td>
            <td style="height: 29px">
                <asp:TextBox ID="txtFname" runat="server" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 314px">
                <asp:Label ID="Label2" runat="server" Text="LastName:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLanme" runat="server" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 314px">
                <asp:Label ID="Label3" runat="server" Text="UserName:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUname" runat="server" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 314px">
                <asp:Label ID="Label4" runat="server" Text="Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPswd" runat="server" Height="25px" Width="200px" 
                    TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 314px">
                <asp:Label ID="Label5" runat="server" Text="MobileNo:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMobile" runat="server" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 314px">
                <asp:Label ID="Label6" runat="server" Text="EmailId:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmailID" runat="server" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 314px; height: 29px">
                <asp:Label ID="Label7" runat="server" Text="Address:"></asp:Label>
            </td>
            <td style="height: 29px">
                <asp:TextBox ID="txtAddress" runat="server" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 314px">
                <asp:Label ID="Label8" runat="server" Text="State:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtState" runat="server" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 314px">
                <asp:Label ID="Label9" runat="server" Text="Country:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCountry" runat="server" Height="25px" Width="200px" 
                   ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 314px">
                <asp:Label ID="Label10" runat="server" Text="ZipCode:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtZipCode" runat="server" Height="25px" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 314px">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td style="width: 314px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

