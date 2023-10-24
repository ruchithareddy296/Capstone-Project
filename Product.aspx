<%@ Page Title="" Language="C#" MasterPageFile="~/UserAccount/UserMasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="UserAccount_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <table  Width="100%">

      <tr>
            <td style="text-align: right; width: 266px;">
                <asp:Label ID="Label5" runat="server" Text="Category ItemType:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Height="25px" Width="200px" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">

                   
  
                </asp:DropDownList>
            </td>
        </tr>
      <tr>
            <td style="text-align: right; width: 266px;">
                <asp:Label ID="Label6" runat="server" Text="Subcategory ItemType:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" Height="25px" Width="200px">

                   
  
                </asp:DropDownList>
            </td>
        </tr>

  <tr>
<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Amount Range:</td>
<td>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>--Select--</asp:ListItem>
        <asp:ListItem>100</asp:ListItem>
        <asp:ListItem>500</asp:ListItem>
        <asp:ListItem>1000</asp:ListItem>
        <asp:ListItem Value="2000"></asp:ListItem>
        <asp:ListItem>5000</asp:ListItem>
        <asp:ListItem>10000</asp:ListItem>
        <asp:ListItem>50000</asp:ListItem>
        <asp:ListItem>100000</asp:ListItem>
        <asp:ListItem Value="150000"></asp:ListItem>
        <asp:ListItem Value="200000"></asp:ListItem>
    </asp:DropDownList>
    </td></tr>
<tr>
<td>&nbsp;</td>
<td>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Search" />
    </td></tr>
<tr>
<td colspan="2" style="height: 23px"></td></tr>
<tr>
<td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
        ID="lblmgs" runat="server" Visible="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">ViewCart</asp:LinkButton>
    </td></tr>
</table>
    <asp:DataList ID="dlItems" Visible="true" runat="server" RepeatColumns="4" CellSpacing="6"
                            Width="600px" onitemcommand="dlItems_ItemCommand" 
        Height="100%" >
                            <ItemTemplate>
                                <table class="dlcss">
                                    <tr style="margin-top: 10px;">
                                        <td align="center" colspan="2">
                    
                                           <%-- <img height="200px" width="200px" alt="" src='<%# "../Admin/" + Eval("ItemPath")%>'/>--%>
                                   
                                   <asp:Image ID="Image2" runat="server" Height="150px" 
                                        ImageUrl='<%# Eval("ItemPath") %>' Width="150px" />
                                      
                                        </td>
                                    </tr>
                                 <tr style="margin-top: 10px; margin-bottom: 10px;">
                                        <td style="color: green;">
                                            Price:
                                            <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("Rate")%>'></asp:Label>
                                            Dis:
                                            <asp:Label ID="lbldis" runat="server" Text='<%#Eval("DiscountPercentage")%>'></asp:Label>%
                                            <asp:Label ID="Label1" runat="server" Visible="false" Text='<%#Eval("ItemId")%>'></asp:Label>
                                            <%--Weight:
                                            <asp:Label ID="lblquantity" runat="server" Text='<%#Eval("quantity")%>'></asp:Label>--%>
                                              ItemName:
                                             <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ItemName")%>'></asp:Label>
                                        </td>
                                        
                                        <td>
                                         <asp:Label ID="lblUserId" runat="server" Visible="false" Text="Label"></asp:Label>
                                            <asp:Label ID="lbldate" runat="server" Visible="false" Text="Label"></asp:Label>
                                            <%--<asp:Button ID="Delete" runat="server" Text="-" />--%>
                                          <asp:Button ID="btnaddcart" runat="server" CommandName="Addcart" CommandArgument='<%# Eval("ItemId") %>' Text="ADD"/>
                                          <%--  <asp:Button ID="btndeletecart" runat="server" CommandName="deletecart" CommandArgument='<%# Eval("ItemId") %>' Text="_"/>--%>
                                         <%--   <asp:Button ID="addcartbtn" runat="server" Text="+" />--%>
                                            
                                            <%--<a style="color: red; text-decoration: none;" href="#" id="adid" onclick="ShowEditModalphoto('<%#Eval("id")%>')">
                                                View Details</a>--%>

<%--                                                <asp:LinkButton ID="lnkBtnEdit" CommandName="lnkBtnEdit" CommandArgument="<%#Eval("id")%>" runat="server" OnClientClick= "ShowEditModalphoto('+DataBinder.Eval(Container.DataItem,"id").ToString()+'%>">View Details</asp:LinkButton>
--%>                                        </td>
                                        
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
</asp:Content>

