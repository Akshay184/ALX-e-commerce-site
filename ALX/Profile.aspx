<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ALX.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 76px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 style="text-align: center">USER PROFILE<asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="141px" style="margin-bottom: 0px" Width="240px">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            <asp:Button ID="btnEditProfle" runat="server" CssClass="auto-style1" OnClick="btnEditProfle_Click" Text="Edit Profile" Width="156px" />
        </h1>
        <p style="text-align: center">
            &nbsp;</p>
    
    </div>
        <p style="text-align: center">
            &nbsp;</p>
        <p style="text-align: center">
            &nbsp;</p>
        <p style="text-align: center">
            &nbsp;</p>
        <p style="text-align: center">
            <asp:FileUpload ID="fileuploadProducts" runat="server" />
        </p>
        <p style="text-align: left">
            Product Name<asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
        </p>
        <p style="text-align: left">
            Price<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>



            <asp:DropDownList ID="DropDownList1" runat="server" style="margin-bottom: 33px">
                <asp:ListItem Value="1" Text="Furniture"></asp:ListItem>
                <asp:ListItem Value="2" Text="Books"></asp:ListItem>
                <asp:ListItem Value="3" Text="Vehicles"></asp:ListItem>
                <asp:ListItem Value="4" Text="Electronics"></asp:ListItem>
                <asp:ListItem Value="5" Text="Clothing"></asp:ListItem>
            </asp:DropDownList> 
        </p>
        <p style="text-align: left">
            Description
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        </p>
        <p style="text-align: left">
            &nbsp;</p>



        <p style="text-align: left">
            &nbsp;</p>
        <p style="text-align: left">
&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="text-align: center" Text="Upoad" />
        </p>
    </form>
</body>
</html>
