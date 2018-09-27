<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="ALX.ADMIN_PANEL.UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:#9fd9e0;
        }
       #UserProfileText{
           text-align:center;
           color:blue;
       }
       #UserProfile{
           margin-top:8%;
       }
       #UserProfile table, tr ,td,th  {
          border:1px solid black;
          border-collapse:collapse;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="UserProfileText">
            <h2>Welcome To User Profile Section</h2>
        </div>   
        <div id="UserProfile">
            
           
            <center>
                <table>
                     <tr>
                    <th>User ID</th>
                    <th>User Name</th>
                    <th>User Email</th>
                    <th>Contact Number</th>
                    <th>Email Verified</th>
                </tr>
                     <asp:Repeater ID="rptUserProfile" runat="server">
                <ItemTemplate>
                    <tr>
                       <td>
                           <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserId") %>'></asp:Label>
                       </td>
                        <td>
                             <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                        </td>
                        <td>
                             <asp:Label ID="lblUserEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </td>
                        <td>
                             <asp:Label ID="lblContactNumbar" runat="server" Text='<%# Eval("ContactNumber") %>'></asp:Label>
                        </td>
                        <td>
                             <asp:Label ID="lblEmailVerification" runat="server" Text='<%# Eval("EmailVerified") %>'></asp:Label>
                        </td>
                    </tr>
                        </ItemTemplate>
                </asp:Repeater>
                </table>
            </center>
                
        </div>
    </div>
    </form>
</body>
</html>
