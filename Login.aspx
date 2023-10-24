<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:89%; border:1px solid #808080; margin-left: 127px;">
        <tr>
            <td style="text-align: right; font-size: x-large; width: 295px;">
                &nbsp;</td>
            <td style="font-size: medium; text-align: left">&nbsp;</td>
        </tr>
       
        <tr>
            <td style="text-align: right; width: 295px;">
                <b>
                <asp:Label ID="Label1" runat="server" Text="User Name:" style="font-size: medium" Font-Bold="False" Font-Names="Century Gothic"></asp:Label>
                </b>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtuname" runat="server" Height="25px" 
                    style="font-size: medium; font-weight: bold" Width="200px" 
                    placeholder="User Name"></asp:TextBox>
            &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; width: 295px;"><b>
                <asp:Label ID="Label2" runat="server" Text="Password:" style="font-size: medium" Font-Bold="False" Font-Names="Century Gothic"></asp:Label>
                &nbsp;&nbsp;
                </b></td>
            <td style="text-align: left">
                <asp:TextBox ID="txtpwd" runat="server" Height="25px" 
                    style="font-size: medium; font-weight: bold" Width="200px" 
                    placeholder="Password" TextMode="Password"></asp:TextBox>
            &nbsp;</td>
        </tr>
        <tr>
            <td style="text-align: right; font-size: x-large; width: 295px;">
                <b>
                <asp:Label ID="Label4" runat="server" Text="Select Type:" 
                    style="font-size: medium" Font-Bold="False" Font-Names="Century Gothic"></asp:Label>
                </b>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="200px">
                    <asp:ListItem>---Select---</asp:ListItem>
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; font-size: x-large;" colspan="2">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnsubmit" runat="server" OnClick="Button6_Click" Text="Login" style="font-size: large; font-weight: bold" Height="37px" Width="96px" Font-Bold="False" Font-Names="Century Gothic" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnreset" runat="server" Height="37px" style="font-size: large; font-weight: 700" Text="Reset" Width="102px" OnClick="btnreset_Click" Font-Bold="False" Font-Names="Century Gothic" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right; font-size: x-large; width: 295px;">&nbsp;</td>
            <td style="text-align: left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">New User?</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; font-size: x-large; width: 295px;">
                <asp:Label ID="lblCustname" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblCustid" runat="server" Visible="False"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:Label ID="lblid" runat="server"></asp:Label>
                <asp:Label ID="lblType" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

