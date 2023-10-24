<%@ Page Title="" Language="C#" MasterPageFile="~/UserAccount/UserMasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="UserAccount_Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label2" runat="server" Text="CustomerId"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label1" runat="server" Text="Feedback"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
                style="height: 26px" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="lblFeedback" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

