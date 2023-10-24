<%@ Page Title="" Language="C#" MasterPageFile="~/UserAccount/UserMasterPage.master" AutoEventWireup="true" CodeFile="Mexican .aspx.cs" Inherits="UserAccount_Mexican" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table  Width="100%">
<tr>
<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
        ID="lblmgs" runat="server" Visible="False"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">ViewCart</asp:LinkButton>
    </td></tr>
</table>
    <asp:DataList ID="dlItems" Visible="true" runat="server" RepeatColumns="4" CellSpacing="6"
                            Width="600px" onitemcommand="dlItems_ItemCommand" 
        Height="100%" style="color: #009933" >
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
                                            <asp:Label ID="Label1" runat="server" Visible="false" Text='<%#Eval("ItemId")%>'></asp:Label>
                                           <%-- Weight:
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

