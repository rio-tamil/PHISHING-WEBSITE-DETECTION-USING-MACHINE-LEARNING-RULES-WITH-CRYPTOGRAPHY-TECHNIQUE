<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="KeywordTranning.aspx.cs" Inherits="KeywordTranning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        <table width="100%">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server" 
                        style="font-weight: 700; font-size: medium; color: #000000" 
                        Text="Word Training"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" 
                        style="font-weight: 700; font-size: medium; color: #000000" Text="Block word"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td>
                    <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" 
                        CssClass="Gridview" DataKeyNames="id" HeaderStyle-BackColor="#61A6F8" 
                        HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" 
                        onrowcancelingedit="gvDetails_RowCancelingEdit" 
                        onrowcommand="gvDetails_RowCommand" onrowdeleting="gvDetails_RowDeleting" 
                        onrowediting="gvDetails_RowEditing" onrowupdating="gvDetails_RowUpdating" 
                        ShowFooter="true" style="font-weight: 700; color: #000000">
                        <Columns>
                            <asp:TemplateField>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="imgbtnUpdate" runat="server" CommandName="Update" 
                                        Height="20px" ImageUrl="~/Images/update.jpg" ToolTip="Update" Width="20px" />
                                    <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" 
                                        Height="20px" ImageUrl="~/Images/Cancel.jpg" ToolTip="Cancel" Width="20px" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgbtnEdit" runat="server" CommandName="Edit" 
                                        Height="20px" ImageUrl="~/Images/Edit.jpg" ToolTip="Edit" Width="20px" />
                                    <asp:ImageButton ID="imgbtnDelete" runat="server" CommandName="Delete" 
                                        Height="20px" ImageUrl="~/Images/delete.jpg" Text="Edit" ToolTip="Delete" 
                                        Width="20px" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:ImageButton ID="imgbtnAdd" runat="server" CommandName="AddNew" 
                                        Height="30px" ImageUrl="~/Images/AddNewitem.jpg" ToolTip="Add new User" 
                                        ValidationGroup="validaiton" Width="30px" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Block Word">
                                <EditItemTemplate>
                                    <asp:Label ID="lbleditusr" runat="server" Text='<%#Eval("com") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblitemUsr" runat="server" Text='<%#Eval("com") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtftrusrname" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfvusername" runat="server" 
                                        ControlToValidate="txtftrusrname" Text="*" ValidationGroup="validaiton" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="City">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtcity" runat="server" Text='<%#Eval("City") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblcity" runat="server" Text='<%#Eval("City") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtftrcity" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvcity" runat="server" 
                                    ControlToValidate="txtftrcity" Text="*" ValidationGroup="validaiton" />
                            </FooterTemplate>
                        </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="Designation">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtstate" runat="server" Text='<%#Eval("Designation") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblstate" runat="server" Text='<%#Eval("Designation") %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtftrDesignation" runat="server" />
                                <asp:RequiredFieldValidator ID="rfvdesignation" runat="server" 
                                    ControlToValidate="txtftrDesignation" Text="*" ValidationGroup="validaiton" />
                            </FooterTemplate>
                        </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblresult" runat="server" 
                        style="font-weight: 700; color: #000000"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

