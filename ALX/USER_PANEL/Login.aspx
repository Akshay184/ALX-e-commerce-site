<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ALX.USER_PANEL.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=1" />
    <link href="CSS/login.css" rel="stylesheet" />
    <link href="CSS/log-nav.css" rel="stylesheet" />
    <link href="CSS/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU"
        crossorigin="anonymous" />
    <title>login</title>
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
    <form id="form1" runat="server"  >
        <div>
            <!-- navigation -->
            <div class="navigation">
                <asp:HyperLink ID="HypHomePage" runat="server" NavigateUrl="~/USER_PANEL/ALXHome.aspx">
            <img class="logo" src="images/alx-logo.png">
                </asp:HyperLink>

                <div class="menu">
                    <ul>
                          <li>
                            <b><asp:LinkButton ID="lnkBooks2" runat="server" Class="line" OnCommand="Books">BOOKS</asp:LinkButton></b></li>
                        <li>
                           <b>  <asp:LinkButton ID="lnlClothes" runat="server" Class="line" OnCommand="Clothes">CLOTHING</asp:LinkButton></b></li>
                        <li>
                            <b> <asp:LinkButton ID="lnkElectronics" runat="server" CssClass="line" OnCommand="Electronics">ELECTRONICS</asp:LinkButton></b></li>
                        <li>
                            <b> <asp:LinkButton ID="lnkFurniture" runat="server" CssClass="line" OnCommand="Furniture">FURNITURE</asp:LinkButton></b></li>
                        <li>
                           <b>  <asp:LinkButton ID="lnkVehicles" runat="server" CssClass="line" OnCommand="Vehicles">VEHICLES</asp:LinkButton></b></li>
                        <%--<asp:Button ID="btnSearch" runat="server"  OnClick="openSearch()" />--%>
                        <li>
                            <%--<asp:Button ID="btnSearch" runat="server"   OnClientClick="openSearch(); return false;" />--%>
                           <%--<asp:Button id="btnSearch" class="logo-btn" />--%>
                            <%--<asp:Button ID="btnSearch"  runat="server" OnClientClick="openSearch();return false;" useSubmitBehavior="false" > <i class="fa fa-search"></i></asp:Button>--%>
                            <asp:LinkButton ID="lnkSearch" runat="server" OnClientClick="openSearch();return false;"  useSubmitBehavior="false"><i class="fa fa-search"></i></asp:LinkButton>
                        </li>


                        <li>
                            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/USER_PANEL/Login.aspx"><b><i class="fas fa-user-circle"></i></b></asp:HyperLink>
                               <ul id="ulLogin" runat="server"  class="dropdown">
                        <p></p><p></p><p></p>      
                    </ul>
                        </li>
                         <li> <asp:HyperLink ID="hylAddToCart" runat="server" NavigateUrl="~/USER_PANEL/AddToCart.aspx"><i class="fa fa-shopping-cart"></i> </asp:HyperLink></li>

                    </ul>
                </div>


                  <div id="myOverlay" class="overlay ">
                <span class="closebtn" onclick="closeSearch()" title="Close Overlay">×</span>
                <div class="overlay-content animate">

                     <asp:TextBox ID="txtSearch" runat="server"  placeholder="Search.." ></asp:TextBox>
                   <asp:Button ID="btnSearch1" runat="server" OnClick="btnSearch1_Click" Text="Search" />

                </div>
            </div>

            </div>
            <h2>
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </h2>
            <!-- login modal -->
            <div class="box">
                <asp:Label ID="lblEmailVerified" runat="server"></asp:Label>
                <div class="align">
                    <h2>Login</h2>

                </div>


                <div class="inputbox">
                    <asp:TextBox ID="txtUserName" runat="server" AutoCompleteType="Disabled" CssClass="input"  onkeydown="return (event.KeyCode!=13);"></asp:TextBox>
                    <%--<input type="text" name="" runat="server" id="txtUserName11" />--%>
                    <asp:Label ID="lblUserName" Text="Email" runat="server"></asp:Label>

                </div>
                <div class="inputbox">
                    <asp:TextBox ID="txtPassword" Type="Password" runat="server"  onkeydown="return (event.KeyCode!=13);"></asp:TextBox>
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>

                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />

                <div class="align-txt">
                    <p>New to ALX?</p>
                    <asp:HyperLink ID="hylSignup" runat="server" NavigateUrl="~/USER_PANEL/Signup.aspx">Sign-Up!</asp:HyperLink>
                    <%--<a href="sign-up.html">Sign-Up!</a>--%>
                </div>
            </div>

            <%--   <div id="myOverlay" class="overlay ">
                <span class="closebtn" onclick="closeSearch()" title="Close Overlay">×</span>
                <div class="overlay-content animate">
                    <form >
                        <input type="text" placeholder="Search.." name="search" />
                        <button type="submit"><i class="fa fa-search"></i></button>
                    </form>
                </div>
            </div>--%>

            <!-- Footer -->
            <div class="foot">
                <div class="foot-box">
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
                    </ul>
                </div>

                <div class="foot-box">
                    <h4 class="heading">Team ALX</h4>
                    <ul>
                        <li>
                            <asp:HyperLink ID="HyperLink6" runat="server" class="line">ALX?</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink7" runat="server" class="line">OurTeam</asp:HyperLink></li>
                    </ul>
                </div>

                <div class="foot-box">
                    <h4 class="heading">Contact US</h4>
                    <ul>
                        <li>
                            <asp:HyperLink ID="hylFb" runat="server"><i class="fab fa-facebook-square"></i></asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hylInsta" runat="server"><i class="fab fa-instagram"></i></asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hylTwitter" runat="server"><i class="fab fa-twitter"></i></asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hylYouTube" runat="server"><i class="fab fa-youtube"></i></asp:HyperLink></li>



                    </ul>
                </div>

                <div class="foot-box">
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
