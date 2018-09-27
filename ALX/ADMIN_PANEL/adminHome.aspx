<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminHome.aspx.cs" Inherits="ALX.ADMIN_PANEL.adminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:	 #9fd9e0;
        }

        
        #navBar{
            background-color:#8080ff;
            color:white;
        }
        #navBar ul li{
            display:inline-block;
            margin:20px;
            font-size:130%;
        }
        #hylUserHome,#hylUserProfile{
            text-decoration:none;
            color:white;
        }
        #adminText{
            text-align:center;
        }
        #adminLogin{
            text-align:center;
            margin-top:10%;
        }
        #adminLogin table tr td{
            font-size:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >
        <div id="navBar">
        <ul >
            <li><asp:HyperLink ID="hylUserHome" runat="server" NavigateUrl="~/Welcome.aspx">User Home</asp:HyperLink></li> 
                        <li>Login</li>          
            <li><asp:HyperLink ID="hylUserProfile" runat="server" NavigateUrl="~/ADMIN_PANEL/UserProfile.aspx">User Profile</asp:HyperLink></li>
            <li>Products Uploaded</li>
        </ul>
            </div>
        <div id="adminText">
            <h1>Welcome To Admin</h1>
        </div>
        <div id="adminLogin">
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
                    <td> <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
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
                    <td colspan="2"> <center><asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" /></center></td>
                </tr>
            </table>
               
                </center>
        </div>
        
    </div>
    </form>
</body>
</html>
