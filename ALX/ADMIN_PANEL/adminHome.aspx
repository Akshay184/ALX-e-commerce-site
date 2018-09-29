<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="ALX.ADMIN_PANEL.adminLogin" %>

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
        #hylUserHome,#hylUserProfile,#hylUploadedProducts,#hylAdminHome,#btnLogout{
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
                        <li>
                            <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout"></asp:LinkButton>
                            <%--<asp:HyperLink ID="hylAdminHome" runat="server" NavigateUrl="~/ADMIN_PANEL/adminHome.aspx">Admin Home</asp:HyperLink></li>--%>          
            <li><asp:HyperLink ID="hylUserProfile" runat="server" NavigateUrl="~/ADMIN_PANEL/UserProfile.aspx">User Profile</asp:HyperLink></li>
            <li><asp:HyperLink ID="hylUploadedProducts" runat="server" NavigateUrl="~/ADMIN_PANEL/ProductsUploaded.aspx">Products Uploaded</asp:HyperLink></li>
        </ul>
            </div>
        <div id="adminText">
            <h1>Welcome To Admin</h1>
        </div>
            </div>
    </form>
</body>
</html>
