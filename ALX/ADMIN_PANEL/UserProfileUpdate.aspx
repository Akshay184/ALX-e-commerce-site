<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfileUpdate.aspx.cs" Inherits="ALX.ADMIN_PANEL.Editing" %>

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
         #btnUpload{
          
             
         }
        
    </style>
    <script>
        function noDisplay() {
            document.getElementById("txtProductName").style.display = "none";
        }
       
    </script>
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
                    <td><h4>UserName</h4></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><h4>Email</h4></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("Email") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><h4>Contact Number</h4></td>
                    <td></td>
                    <td>
                        <asp:TextBox ID="txtContactNumber" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <%--<tr>
                    <td><h4>ProductName</h4></td>
                    <td></td>
                    <td>
                        <asp:textbox id="txtProductName" runat="server" OnTextChanged="txtProductName_TextChanged"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td><h4>Description</h4></td>
                    <td></td>
                    <td>
                        <asp:textbox id="txtDescription" runat="server"></asp:textbox>
                    </td>
                </tr>--%>

            </table>
            <p>
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </p>
        </div>
    
    </div>
    </form>
</body>
</html>
