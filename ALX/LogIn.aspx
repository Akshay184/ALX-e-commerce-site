<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ALX.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h3 style="text-align: center">LOG IN</h3>
    <p style="text-align: left">
        USERNAME
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </p>
    <p style="text-align: left">
        PASSWORD
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        <p>
            <asp:Button ID="btnLogIn" runat="server" OnClick="btnLogIn_Click" Text="Log In" />
        </p>
    </p>
    </form>
    </body>
</html>
