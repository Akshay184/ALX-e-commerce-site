<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="ALX.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            margin-left: 15px;
        }
        .auto-style3 {
            margin-left: 83px;
        }
        </style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
    
        <h1>WELCOME</h1>
    
    </div>
        <h1>
        <asp:Button ID="Button1" runat="server" Text="LogOut" OnClick="Button1_Click" style="text-align: right" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Profile" />
            <br />
            <br />
            CATEGORIES</h1>
        <h1 class="auto-style1">
            <asp:TextBox ID="txtSearch" runat="server" Height="26px" OnTextChanged="txtSearch_TextChanged" Width="244px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" CssClass="auto-style2" OnClick="btnSearch_Click" Text="SEARCH" Width="104px" />
            <p>
            <asp:Button ID="btnFurniture" runat="server" OnClick="btnFurniture_Click" Text="Furniture" Width="93px" />
                </p>
            <p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBooks" runat="server" OnClick="btnBooks_Click" Text="Books" Width="99px" />
                <asp:DropDownList ID="DropDownListFilters" runat="server" AutoPostBack="True" CssClass="auto-style3" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Value="0">Filters</asp:ListItem>
                    <asp:ListItem Value="1">High-to-Low</asp:ListItem>
                    <asp:ListItem Value="2">Low-to-High</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button ID="btnElectronics" runat="server" OnClick="btnElectronics_Click" Text="Electronics" />
            </p>
        <p>
                <asp:Button ID="btnVehicles" runat="server" OnClick="btnVehicles_Click" Text="Vehicles" Width="94px" />
            </p>
        <p>
                <asp:Button ID="btnClothing" runat="server" OnClick="btnClothing_Click" Text="Clothing" Width="94px" />
            </p>
        </h1>
        
     <%-- <asp:Button ID="Button3" runat="server" Text="Books" OnClick="Button3_Click" />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Text="Vehicles" OnClick="Button4_Click" />
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" Text="others" OnClick="Button5_Click" />
        <br />
        <br />    --%>
        <asp:Repeater ID="rptProduct" runat="server">
            <ItemTemplate>
                <table style="border:1px solid black; background-color:aqua">
                    <tr>
                        <td style="width:300px">
                            <asp:Image ID="imgProducts" ImageUrl='<%# Eval("images") %>' runat="server" />
                        </td>
                        <td style="width:200px">
                            <table>
                                <tr>
                                    <td>ProductName:</td>
                                    <td>
                                        <asp:Label ID="lblProductName" Text='<%# Eval("ProductName") %>' runat="server">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Description:</td>
                                    <td>
                                        <%--<asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server">--%>
                                        <%--</asp:Label>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td >
                            <table>
                                <tr>
                                    <td>Price</td>
                                    <td>
                                        <asp:Label ID="lblPrice" Text='<%# Eval("price") %>' runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Owner Details:</td>
                                    <td>
                                        <asp:Label ID="lblOwnerDetails" Text="XYZ" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Owner Contact Number:</td>
                                    <td>
                                        <asp:Label ID="lblOwnerContactNumber" Text="XYZ" runat="server">

                                        </asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptPager" runat="server">
    <ItemTemplate>
        <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
            CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "page_enabled" : "page_disabled" %>'
            OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
           </ItemTemplate>
</asp:Repeater>
    </form>
</body>
</html>
