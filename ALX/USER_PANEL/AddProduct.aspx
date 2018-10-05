<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="ALX.USER_PANEL.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=1">
    <link href="CSS/style.css" rel="stylesheet" />
    <link href="CSS/log-nav.css" rel="stylesheet" />
    <link href="CSS/account.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU"
        crossorigin="anonymous" />
    <title>Account</title>
</head>
<script>
    function openSearch() {
        document.getElementById("myOverlay").style.display = "block";
    }

    function closeSearch() {
        document.getElementById("myOverlay").style.display = "none";
    }


</script>
<body>
    <form id="form1" runat="server">
        <div>

            <!-- navigation -->
            <div class="navigation">
                <a href="alx.html">
                    <img class="logo" src="images/alx-logo.png"></a>
                <div class="menu">
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnkBooks2" runat="server" Class="line" OnCommand="Books">BOOKS</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnlClothes" runat="server" Class="line" OnCommand="Clothes">CLOTHING</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkElectronics" runat="server" CssClass="line" OnCommand="Electronics">ELECTRONICS</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkFurniture" runat="server" CssClass="line" OnCommand="Furniture">FURNITURE</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnkVehicles" runat="server" CssClass="line" OnCommand="Vehicles">VEHICLES</asp:LinkButton></li>
                        <%--<asp:Button ID="btnSearch" runat="server"  OnClick="openSearch()" />--%>
                        <li>
                            <button class="logo-btn" onclick="openSearch();return false;"><i class="fa fa-search"></i></button>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/USER_PANEL/Login.aspx"><b><i class="fas fa-user-circle"></i></b></asp:HyperLink>
                               <ul id="ulLogin" runat="server"  class="dropdown">
                        <p></p><p></p><p></p>      
                    </ul>
                        </li>

                    </ul>
                </div>
            </div>

            <div id="myOverlay" class="overlay ">
                <span class="closebtn" onclick="closeSearch()" title="Close Overlay">×</span>
                <div class="overlay-content animate">

                     <asp:TextBox ID="txtSearch" runat="server"  placeholder="Search.."></asp:TextBox>
                   <asp:Button ID="btnSearch1" runat="server" OnClick="btnSearch1_Click" Text="Search" />

                </div>
            </div>

            <!-- upload form -->
            <div class="sell">



                <div class="head">
                    <h2>SELL IT!</h2>
                </div>
                <div class="inputbox">

                    <asp:TextBox ID="txtTitle" runat="server" placeholder="Title"></asp:TextBox>

                </div>
                <div class="inputbox">

                    <asp:TextBox ID="txtDescription" runat="server" placeholder="Description..." TextMode="MultiLine"></asp:TextBox>


                </div>
                <div class="inputbox">

                    <asp:TextBox ID="txtPrice" runat="server" placeholder="Price"></asp:TextBox>

                </div>
                <div class="inputbox">
                    <%--<select name="products">
                            <option value="books">Books</option>
                            <option value="furniture">Furniture</option>
                            <option value="clothes">Clothes</option>
                            <option value="vehicles">Vehicles</option>
                            <option value="electronics">Electronics</option>
                        </select>--%>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Text="Furniture"></asp:ListItem>
                        <asp:ListItem Text="Electronics"></asp:ListItem>
                        <asp:ListItem Text="Books"></asp:ListItem>
                        <asp:ListItem Text="Clothes"></asp:ListItem>
                        <asp:ListItem Text="Vehicles"></asp:ListItem>
                    </asp:DropDownList>




                </div>
                <div class="upload">
                    <p>Upload image:</p>
                    <asp:FileUpload ID="fileuploadProducts" runat="server" />
                </div>
                <div>
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                </div>
    </form>
    </div>

            <!-- Footer -->
    <div class="foot">
        <div class="foot-box ">
            <h4 class="heading">BUYS</h4>
            <ul>
                <li><a href="products.html">Books</a></li>
                <li><a href="products.html">Clothes</a></li>
                <li><a href="products.html">Electronics</a></li>
                <li><a href="products.html">Furniture</a></li>
                <li><a href="products.html">Vehicles</a></li>
            </ul>
        </div>

        <div class="foot-box">
            <h4 class="heading">Team ALX</h4>
            <ul>
                <li><a href="#">ALX?</a></li>
                <li><a href="#">Our Team</a></li>
            </ul>
        </div>

        <div class="foot-box">
            <h4 class="heading">Contact US</h4>
            <ul>
                <li><a href="#"><i class="fab fa-facebook-square"></i></a></li>
                <li><a href="#"><i class="fab fa-instagram"></i></a></li>
                <li><a href="#"><i class="fab fa-twitter"></i></a></li>
                <li><a href="#"><i class="fab fa-youtube"></i></a></li>

            </ul>
        </div>

        <div class="foot-box" id="fourth">
            <h4 class="heading">Address</h4>
            <p id="top">27th KM Milestone,</p>
            <p>Delhi - Hapur Bypass Road,</p>
            <p>PO Adhyatmik Nagar, Ghaziabad,</p>
            <p>Uttar Pradesh 201009</p>

        </div>


    </div>

    <div class="end-foot">
        <div class="end-logo">
            <i class="far fa-copyright"></i>
        </div>

        <div class="txt">
            <p>2018 www.alx.com.All Rights Reserved</p>
        </div>


    </div>

    </div>
    </form>
</body>
</html>
