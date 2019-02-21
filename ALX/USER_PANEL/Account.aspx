<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="ALX.USER_PANEL.Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=1" /> 
    
    <link href="CSS/log-nav.css" rel="stylesheet" />
    <link href="CSS/style.css" rel="stylesheet" />
    <link href="CSS/products.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU"
        crossorigin="anonymous" />
    <title>Account</title>
</head>
<body>
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
                            <%--<asp:Button ID="btnSearch" runat="server" class="fa fa-search"  OnClientClick="openSearch(); return false;" />--%>
                            <button id="btnSearch" class="logo-btn" onclick="openSearch();return false;"><i class="fa fa-search"></i></button>
                        </li>
                    
                    
                   <li> <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/USER_PANEL/Login.aspx"><b><i class="fas fa-user-circle"></i></b></asp:HyperLink>
                          <ul id="ulLogin" runat="server"  >
                        <p></p><p></p><p></p>      
                    </ul>
                   </li>
             
                 <li> <asp:HyperLink ID="hylAddToCart" runat="server" NavigateUrl="~/USER_PANEL/AddToCart.aspx"><i class="fa fa-shopping-cart"></i> </asp:HyperLink></li>

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
        <h1 class="heading1">
        <asp:Label ID="lblHeading" runat="server"></asp:Label>
            </h1>
         <div class="dropdown">
            
           <%-- <button class="dropbtn">Sort </button>
            
            <div class="dropdown-content">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="1" Text="Price:Low-High"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Price:High-Low"></asp:ListItem>
                </asp:DropDownList>
              --%>
             
            </div>
    </div>
         <!-- products -->  
    <p></p>
    <div class="card1">
        <asp:Repeater ID="rptProducts" runat="server" >
                <ItemTemplate>
        <div class="card">
             <asp:LinkButton ID="lnkDescription" runat="server" OnCommand="Description" CommandArgument='<%# Eval("ProductId") %>'>
                    
                     <asp:Image ID="ImgProducts" runat="server" ImageUrl='<%# Eval("images") %>'  class="fit" />
                    <h1> <asp:Label ID="lblProducuNmae" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label></h1>
                    <p> <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label></p>

                    <%--<p > <asp:Button ID="btnAddToCart" runat="server"  OnCommand="AddToCart1" CommandArgument='<%# Eval("ProductId") %>' Text="Add to Cart" />     </p>--%>
                     
                 </asp:LinkButton>
            </div>
                </ItemTemplate>
            </asp:Repeater>
           
        
      <%--  
        <div class="card">
              <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#">
                <img src="images/Cool-Books-Vector.jpg" alt="Denim Jeans" style="width:100%" />
                <h1>Tailored Jeans</h1>
                <p class="price">$19.99</p>
                
                <p><button>Add to Cart</button></p>
            </asp:HyperLink>
        </div>
        <div class="card">
              <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#">
                <img src="images/Cool-Books-Vector.jpg" alt="Denim Jeans" style="width:100%" />
                <h1>Tailored Jeans</h1>
                <p class="price">$19.99</p>
                
                <p><button>Add to Cart</button></p>
            </asp:HyperLink>
        </div>
        <div class="card">
              <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#">
                <img src="images/Cool-Books-Vector.jpg" alt="Denim Jeans" style="width:100%" />
                <h1>Tailored Jeans</h1>
                <p class="price">$19.99</p>
                
                <p><button>Add to Cart</button></p>
           </asp:HyperLink>
        </div> --%>
    </div>

        <!-- Pagination -->


           <!-- Footer -->  
        <div class="foot">
            <div class="foot-box ">
                <h4 class="heading">BUYS</h4>
                <ul>
                  <li> <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="Books">BOOKS</asp:LinkButton></li>
                 <li>   <asp:LinkButton ID="LinkButton2" runat="server"  OnCommand="Clothes">CLOTHING</asp:LinkButton></li>
                   <li> <asp:LinkButton ID="LinkButton3" runat="server"  OnCommand="Electronics">ELECTRONICS</asp:LinkButton></li>
                   <li> <asp:LinkButton ID="LinkButton4" runat="server"  OnCommand="Furniture">FURNITURE</asp:LinkButton></li>
                  <li>  <asp:LinkButton ID="LinkButton5" runat="server" OnCommand="Vehicles">VEHICLES</asp:LinkButton></li>
                </ul>
            </div>

            <div class="foot-box">
                <h4 class="heading">Team ALX</h4>
                <ul>
                    <li><asp:HyperLink ID="hyl5" runat="server" class="line">ALX?</asp:HyperLink></li>
                        <li><asp:HyperLink ID="hylOurTeam5" runat="server" class="line">OurTeam</asp:HyperLink></li>
                </ul>
            </div>

            <div class="foot-box">
                <h4 class="heading">Contact US</h4>
                <ul>
                     <li><asp:HyperLink ID="hylFb" runat="server" ><i class="fab fa-facebook-square"></i></asp:HyperLink></li> 
                            <li><asp:HyperLink ID="hylInsta5" runat="server" ><i class="fab fa-instagram"></i></asp:HyperLink></li> 
                            <li><asp:HyperLink ID="hylTwitter5" runat="server" ><i class="fab fa-twitter"></i></asp:HyperLink></li> 
                            <li><asp:HyperLink ID="hylYouTube5" runat="server" ><i class="fab fa-youtube"></i></asp:HyperLink></li> 
                    
                </ul>
            </div>

            <div class="foot-box" id="fourth">
                    <h4 class="heading">Address</h4>
                    <p id="top">27th KM Milestone,</p>
                        <p> Delhi - Hapur Bypass Road,</p>
                        <p>PO Adhyatmik Nagar, Ghaziabad,</p>
                        <p> Uttar Pradesh 201009</p>
                    
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
