<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="ALX.USER_PANEL.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" charset="utf-8" content="width=device-width, initial-scale=1" />
    <link href="CSS/style.css" rel="stylesheet" />
    <link href="CSS/sign-up.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU"
        crossorigin="anonymous" />
    <title>login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="navigation">
                <asp:HyperLink ID="HypHomePage" runat="server" NavigateUrl="~/USER_PANEL/ALXHome.aspx">
            <img class="logo" src="images/alx-logo.png">
            </asp:HyperLink>

                <div class="menu">
                    <ul>

                          <li> <asp:LinkButton ID="lnkBooks2" runat="server"  CssClass="line" OnCommand="Books">BOOKS</asp:LinkButton></li>
                 <li>   <asp:LinkButton ID="lnlClothes" runat="server" class="line" OnCommand="Clothes">CLOTHING</asp:LinkButton></li>
                   <li> <asp:LinkButton ID="lnkElectronics" runat="server" class="line" OnCommand="Electronics">ELECTRONICS</asp:LinkButton></li>
                   <li> <asp:LinkButton ID="lnkFurniture" runat="server" class="line" OnCommand="Furniture">FURNITURE</asp:LinkButton></li>
                  <li>  <asp:LinkButton ID="lnkVehicles" runat="server" class="line" OnCommand="Vehicles">VEHICLES</asp:LinkButton></li>
                           <li> <button class="logo-btn" onclick="openSearch()"><i class="fa fa-search"></i></button></li>
                        
                        <li>
                            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/USER_PANEL/Login.aspx"><b><i class="fas fa-user-circle"></i></b></asp:HyperLink></li>

                    </ul>
                </div>
            </div>

            <!-- login modal -->
            <div class="box">
                <!-- <div class="align2">
                    
                    </div> -->
                <div class="align">

                    <h2>Sign Up</h2>
                </div>


                <div class="inputbox">
                    <asp:TextBox ID="txtName" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:Label ID="lblName" Text="Name" runat="server"></asp:Label>
                    <p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="This Field Is REQUIED" ControlToValidate="txtName" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </p>

                </div>
                <div class="inputbox">
                    <asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:Label ID="lblEmail" Text="Email" runat="server"></asp:Label>
                    <p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ErrorMessage="This Field Is REQUIED" ControlToValidate="txtEmail" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                      <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ErrorMessage="Email Address Not Valid" ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="[a-zA-Z0-9.-]+@[a-zA-Z0-9]+\.com"
                            Display="Dynamic">--%>

                        </asp:RegularExpressionValidator>
                    </p>
                </div>
                <div class="inputbox">
                    <asp:TextBox ID="txtUserName" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:Label ID="lblUserName" Text="Username" runat="server"></asp:Label>
                    <p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="This Field Is REQUIED" ControlToValidate="txtUserName" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </p>
                </div>
                <div class="inputbox">
                    <asp:TextBox ID="txtPassword" runat="server" Type="Password"></asp:TextBox>
                    <asp:Label ID="lblPassword" Text="Password" runat="server"></asp:Label>
                    <p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="This Field Is REQUIED" ControlToValidate="txtPassword" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ErrorMessage="Type Valid Password" ControlToValidate="txtPassword" ForeColor="Red"
                            Display="Dynamic" ValidationExpression="[A-Z]+[A-Za-z0-9\W]+\W+[0-9]+[A-Za-z0-9]*"
                            runat="server">

                        </asp:RegularExpressionValidator>
                    </p>
                </div>
                <div class="inputbox">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" Type="Password"></asp:TextBox>
                    <asp:Label ID="lblConfirmPassword" Text="Confirm Password" runat="server"></asp:Label>
                    <p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ErrorMessage="This Field Is REQUIED" ControlToValidate="txtConfirmPassword" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                            ErrorMessage="Password does not match" FortColor="Red" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword"
                            Operator="Equal" Type="String" Display="Dynamic" ForeColor="Red" ></asp:CompareValidator>
                    </p>
                </div>
                <div class="inputbox">
                    <asp:TextBox ID="txtContactNumber" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    <asp:Label ID="lblContactNumber" Text="Contact Number" runat="server"></asp:Label>
                    <p>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ErrorMessage="This Field Is REQUIED" ControlToValidate="txtContactNumber" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Only 10 digits number are allowed"
                         ControlToValidate="txtContactNumber" ForeColor="Red" ValidationExpression="\d\d\d\d\d\d\d\d\d\d"> 

            </asp:RegularExpressionValidator>
                    </p>
                </div>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />


                <div class="align-txt">
                    <p>Already have an account?</p>
                    <asp:HyperLink ID="hylLogin" runat="server" NavigateUrl="~/USER_PANEL/Login.aspx">Login!</asp:HyperLink>

                </div>
            </div>

            <%-- <div id="myOverlay" class="overlay ">
                <span class="closebtn" onclick="closeSearch()" title="Close Overlay">×</span>
                <div class="overlay-content animate">
                    <form action="/action_page.php">
                        <input type="text" placeholder="Search.." name="search">
                        <button type="submit"><i class="fa fa-search"></i></button>
                    </form>
                </div>
            </div>--%>

            <!-- Footer -->
            <div class="foot">
                <div class="foot-box">
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
                        <li>
                            <asp:HyperLink ID="hyl1" runat="server" >ALX?</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="hylOurTeam" runat="server" >OurTeam</asp:HyperLink></li>
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
