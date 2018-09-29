<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="ALX.ADMIN_PANEL.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color: #9fd9e0;
        }
        #LoginText{
            text-align:center;
            color:blue;
        }
        #AdminLogin{
            margin-top:7%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div id="LoginText">
           <h1>Welecome To Admin Login</h1>
       </div>
        <div id="AdminLogin">
            <center>
            <table>
                <tr >
                    <th colspan="2" style="text-align:center;font-size:30px" >Admin Login</th>
                </tr>
                <tr>
                    <td>Username</td>
                    
                    <td><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td> <asp:TextBox ID="txtPassword" runat="server" Type="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="2"> <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" /></td>
                </tr>
            </table>
             </center>  
            
        </div>
        <center>
              <asp:Label ID="lblLoginText" runat="server" Text=""></asp:Label>
         </center>

    </div>
    </form>
</body>
</html>
