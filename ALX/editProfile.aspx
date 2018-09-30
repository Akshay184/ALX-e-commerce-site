<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editProfile.aspx.cs" Inherits="ALX.editProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: xx-large;
        }
        .auto-style2 {
            font-size: x-large;
        }
        .auto-style3 {
            margin-left: 27px;
        }
        .auto-style4 {
            margin-left: 314px;
        }
        .auto-style5 {
            margin-left: 85px;
        }
        .auto-style6 {
            margin-left: 103px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <strong>EDIT PROFILE<br />
        </strong>
    
    </div>
        <p class="auto-style2">
            <strong>Contact Number<asp:TextBox ID="txtEditContacct" runat="server" CssClass="auto-style3" Height="24px" OnTextChanged="txtEditContacct_TextChanged" Width="247px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorContactNumber" runat="server" ControlToValidate="txtEditContacct" ErrorMessage="Please Enter your Contact Number" ForeColor="Red"></asp:RequiredFieldValidator>
            </strong>
        </p>
        <p class="auto-style2">
            <strong>User Name<asp:TextBox ID="txtUsername" runat="server" CssClass="auto-style5" Height="24px" OnTextChanged="txtUsername_TextChanged" Width="248px" Enabled="False"></asp:TextBox>
            </strong>
        </p>
        <p class="auto-style2">
            <strong>Email ID<asp:TextBox ID="txtEmail" runat="server" CssClass="auto-style6" Height="27px" OnTextChanged="txtEmail_TextChanged" Width="247px" Enabled="False"></asp:TextBox>
            </strong>
        </p>
        <p class="auto-style2">
            <asp:Button ID="btnUpdate" runat="server" CssClass="auto-style4" OnClick="btnUpdate_Click" Text="UPDATE" Width="173px" />
        </p>
    </form>
</body>
</html>
