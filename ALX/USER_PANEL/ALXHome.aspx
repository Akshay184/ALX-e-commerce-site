<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ALXHome.aspx.cs" Inherits="ALX.USER_PANEL.ALXHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=1" />
    <link href="CSS/style.css" rel="stylesheet" />
    <link href="CSS/log-nav.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU"
        crossorigin="anonymous" />
    <title>ALX</title>
    <script>
        function openSearch() {
            document.getElementById("myOverlay").style.display = "block";
        }

        function closeSearch() {
            document.getElementById("myOverlay").style.display = "none";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <!-- navigation -->
            <div class="navigation">
                <asp:HyperLink ID="HypHomePage" runat="server" NavigateUrl="~/USER_PANEL/ALXHome.aspx">
            <img class="logo" src="images/alx-logo.png">
                </asp:HyperLink>
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
                            <%--<asp:Button ID="btnSearch" runat="server" class="fa fa-search"  OnClientClick="openSearch(); return false;" />--%>
                            <button id="btnSearch" class="logo-btn" onclick="openSearch();return false;"><i class="fa fa-search"></i></button>
                        </li>


                        <li>
                            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/USER_PANEL/Login.aspx"><b><i class="fas fa-user-circle"></i></b></asp:HyperLink>

                            <ul id="ulLogin" runat="server" class="dropdown">
                                <p></p>
                                <p></p>
                                <p></p>
                            </ul>
                        </li>
                      
                        <li> <asp:HyperLink ID="hylAddToCart" runat="server" NavigateUrl="~/USER_PANEL/AddToCart.aspx"><i class="fa fa-shopping-cart"></i> </asp:HyperLink></li>
                    </ul>
                </div>
            </div>

            <div id="myOverlay" class="overlay ">
                <span class="closebtn" onclick="closeSearch()" title="Close Overlay">×</span>
                <div class="overlay-content animate">

                    <%--<input type="text" placeholder="Search.." name="search" />--%>
                                        <%--<button type="submit"><i class="fa fa-search"></i></button>--%>
                    <asp:TextBox ID="txtSearch" runat="server"  placeholder="Search.."></asp:TextBox>
                   <asp:Button ID="btnSearch1" runat="server" OnClick="btnSearch1_Click" Text="Search" />

                </div>
            </div>




            <!-- HEADER -->
            <div>
                <div class="slider">
                    <figure>

                        <img src="images/01.jpeg" />
                        <img src="images/17924-fashion-illustration-women-wallpapers.jpg" />
                        <img src="images/915801.jpg" />
                        <img src="images/interior-decor-background-colored-furniture-icons-cover.png" />
                        <img src="images/01.jpeg" />
                    </figure>
                </div>
            </div>



            <!-- Contents -->

            <div class="container">

                <div class="box">
                    <div class="thumb">
                        <img src="images/Cool-Books-Vector.jpg" height="250em" />
                    </div>
                    <div class="details">
                        <div class="content">
                            <i class="fas fa-book"></i>
                            <h3>Books</h3>
                            <asp:LinkButton ID="lnkBooks" runat="server" OnCommand="Books">BUY</asp:LinkButton>
                            <%--<asp:HyperLink ID="hylBooksBuy" runat="server" NavigateUrl="#">BUY</asp:HyperLink>--%>
                        </div>
                    </div>
                </div>


                <div class="box">
                    <div class="thumb">
                        <img src="images/vector_cartoon_children_clothes_hanger_drying_296255.jpg" height="250em" />
                    </div>
                    <div class="details">
                        <div class="content">
                            <i class="fas fa-tshirt"></i>
                            <h3>Clothing</h3>
                            <asp:LinkButton ID="lnkClothes2" runat="server" OnCommand="Clothes">BUY</asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="box">
                    <div class="thumb">
                        <img src="images/01.jpeg" height="250em">
                    </div>
                    <div class="details">
                        <div class="content">
                            <i class="fas fa-mobile-alt"></i>
                            <h3>Electronics</h3>
                            <asp:LinkButton ID="lnkElectronics2" runat="server" OnCommand="Electronics">BUY</asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="box">
                    <div class="thumb">
                        <img src="images/800px_COLOURBOX5227270.jpg" height="250em">
                    </div>
                    <div class="details">
                        <div class="content">
                            <i class="fas fa-desktop"></i>
                            <h3>Furniture</h3>
                            <asp:LinkButton ID="lnkFurniture2" runat="server" OnCommand="Furniture">BUY</asp:LinkButton>
                        </div>
                    </div>
                </div>

                <div class="box">
                    <div class="thumb">
                        <img src="images/car.jpg" height="250em">
                    </div>
                    <div class="details">
                        <div class="content">
                            <i class="fas fa-car"></i>
                            <h3>Vehicles</h3>
                            <asp:LinkButton ID="lnkVehicles2" runat="server" OnCommand="Vehicles">BUY</asp:LinkButton>
                        </div>
                    </div>
                </div>

            </div>


            <!-- Footer -->
            <div class="foot">
                <div class="foot-box ">
                    <h4 class="heading">BUYS</h4>
                    <ul>

                        <li>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="Books">BOOKS</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnCommand="Clothes">CLOTHING</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LinkButton3" runat="server" OnCommand="Electronics">ELECTRONICS</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LinkButton4" runat="server" OnCommand="Furniture">FURNITURE</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LinkButton5" runat="server" OnCommand="Vehicles">VEHICLES</asp:LinkButton></li>
                </div>

                <div class="foot-box">
                    <h4 class="heading">Team ALX</h4>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hyl5" runat="server" class="line">ALX?</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hylOurTeam5" runat="server" class="line">OurTeam</asp:HyperLink></li>
                    </ul>
                </div>

                <div class="foot-box">
                    <h4 class="heading">Contact US</h4>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hylFb" runat="server"><i class="fab fa-facebook-square"></i></asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hylInsta5" runat="server"><i class="fab fa-instagram"></i></asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hylTwitter5" runat="server"><i class="fab fa-twitter"></i></asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hylYouTube5" runat="server"><i class="fab fa-youtube"></i></asp:HyperLink></li>

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
