<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DatabaseTrain.aspx.cs" Inherits="DatabaseTrain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <br />
</p>
<table style="width: 100%">
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Phishing Website Training"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            <asp:Label ID="Label2" runat="server" Text="Website Type"></asp:Label>
        </td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">Normal</asp:ListItem>
                <asp:ListItem>Phishing</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            <asp:Label ID="Label3" runat="server" Text="Website Url"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
&nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Clear" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 242px">
            &nbsp;</td>
        <td style="width: 132px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>

