<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsUploaded.aspx.cs" Inherits="ALX.ADMIN_PANEL.ProductsUploaded" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color:#9fd9e0;
        }
        #UploadedProductText{
            text-align:center;
            color:blue;
            margin-top:3%;
        }
         #navBar{
            background-color:#8080ff;
            color:white;
        }
          #UploadedProducts table, tr ,td,th  {
          border:1px solid black;
          border-collapse:collapse;
          font-size:105%;
       }
        #navBar ul li{
            display:inline-block;
            margin:20px;
            font-size:130%;
        }
         #hylUserHome,#hylUserProfile,#hylUploadedProducts,#hylAdminHome{
            text-decoration:none;
            color:white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="navBar">
        <ul >
            <li><asp:HyperLink ID="hylUserHome" runat="server" NavigateUrl="~/Welcome.aspx">User Home</asp:HyperLink></li> 
                        <li><asp:HyperLink ID="hylAdminHome" runat="server" NavigateUrl="~/ADMIN_PANEL/adminHome.aspx">Admin Home</asp:HyperLink></li>          
            <li><asp:HyperLink ID="hylUserProfile" runat="server" NavigateUrl="~/ADMIN_PANEL/UserProfile.aspx">User Profile</asp:HyperLink></li>
            <li><asp:HyperLink ID="hylUploadedProducts" runat="server" NavigateUrl="~/ADMIN_PANEL/ProductsUploaded.aspx">Products Uploaded</asp:HyperLink></li>
        </ul>
            </div>
        <div id="UploadedProductText">
            <h2>Welcome To Products Section</h2>
        </div>
        <div id="UploadedProducts">
            <center>
                <table>
                    <tr>
                        <th>User ID</th>
                        <th>Product Id</th>
                        <th>Category</th>
                        <th>Product Name</th>
                        <th>Price</th>
                        <th>Description</th>
                        <th>Images</th>
                        <th colspan="2">Edit/Delete</th>
                    </tr>
                    <asp:Repeater ID="rptUploadedProducts" runat="server">
                <ItemTemplate>
                    <tr>
                       <td>
                           <asp:Label ID="lblUserId" runat="server" Text='<%# Eval("UserId") %>'></asp:Label>
                       </td>
                        <td>
                             <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label>
                        </td>
                        <td>
                             <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("CATEGORY") %>'></asp:Label>
                        </td>
                        <td>
                             <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                        </td>
                        <td>
                             <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                        </td>
                        <td>
                             <asp:Image ID="imgProducts" ImageUrl='<%# Eval("images") %>' runat="server" />
                        </td>
                        <td>
                            <asp:LinkButton ID="btnEdit" runat="server" Text="Edit"  OnCommand="Edit" CommandArgument='<%# Eval("ProductId") %>' ></asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnDelete" runat="server" Text="Delete"  OnCommand="Delete" CommandArgument= '<%# Eval("ProductId") %>'></asp:LinkButton>

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
