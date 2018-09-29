<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductsUpdate.aspx.cs" Inherits="ALX.ADMIN_PANEL.ProductsUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
         body{
             background-color:#9fd9e0;
         }
         #Heading{
             text-align:center;
             color:blue;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div id="Heading">
            <h2>Edit Content Here</h2>
            </div>
        <div id="EditContent">
           
            <table>
                <tr>
                    <td><h4>Product Name</h4></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><h4>Price</h4></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><h4>Description</h4></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server"  Text='<%# Eval("Description") %>' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><h4>Category</h4></td>
                    <td></td>
                    <td>
                        <asp:textbox id="txtCategory" runat="server"  Text='<%# Eval("Category") %>'></asp:textbox>
                    </td>
                </tr>
               
                </tr>

            </table>
            <p>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </p>
        </div>
    
    </div>
    </form>
</body>
</html>
