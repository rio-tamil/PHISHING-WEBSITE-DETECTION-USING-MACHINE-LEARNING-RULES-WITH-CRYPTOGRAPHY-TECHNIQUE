<%@ Page Title="" Language="C#" MasterPageFile="~/User.master" AutoEventWireup="true" CodeFile="KeywordSearch.aspx.cs" Inherits="KeywordSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    </p>
    <table style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td colspan="2">
                <asp:Label ID="Label4" runat="server" Text="Search Keyword"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 179px">
            <asp:Label ID="Label3" runat="server" Text="Keyword  Search"></asp:Label>
            </td>
            <td style="width: 333px">
            <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Search" onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 179px">
                &nbsp;</td>
            <td style="width: 333px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 179px">
                &nbsp;</td>
            <td style="width: 333px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    ForeColor="Black" Width="919px">
                    <Columns>
                        <asp:TemplateField HeaderText="Data">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

