<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InstaFashionShopping.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Insta-Fashion Shopping</title>
    <script src="JS/jquery-3.5.1.min.js" type="text/javascript"></script>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE-edge">
    <link href="StyleSheets/UserMaster.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="StyleSheets/all.min.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Merienda:wght@700&family=Satisfy&display=swap" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- header section starts  -->
            <header>
                <input type="checkbox" name="" id="toggler">
                <label for="toggler" class="fas fa-bars"></label>
                <a style="text-decoration: none; font-family: 'Merienda', cursive" href="UserHome.aspx" class="logo">Insta-Fashion<span></span></a>
                <nav class="navbar1">
                    <a href="Default.aspx">Home</a>
                    <a href="Login.aspx">All</a>
                    <a href="Login.aspx">Men</a>
                    <a href="Login.aspx">Women</a>
                    <a href="Login.aspx">Kids</a>
                    <a href="ContactUs.aspx">Contact</a>
                </nav>
                <div class="icons">
                    <a style="text-decoration: none" href="#" id="search-icon" class="fa fa-fw fa-search"></a>
                    <a style="text-decoration: none" href="Login.aspx" class="fas fa-heart"></a>
                    <a id="btnCart" style="text-decoration: none" href="Login.aspx" class="fas fa-shopping-cart">
                        <span class="cart-count" id="CartBadge" runat="server">0</span></a>
                    <asp:LinkButton ID="LinkButton1" runat="server" Style="text-decoration: none;font-family: 'Merienda', cursive" href="Login.aspx">SignIn</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" Style="text-decoration: none;font-family: 'Merienda', cursive" href="UserSignUp.aspx">SignUp</asp:LinkButton>
                </div>
            </header>
            <br />
            <br />
            <br />
            <br />
            <!-- header section ends -->
            <!-- Carousel Start -->
            <div id="carousel" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-indicators">
                    <button type="button" data-bs-target="#carousel" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                    <button type="button" data-bs-target="#carousel" data-bs-slide-to="1" aria-label="Slide 2"></button>
                    <button type="button" data-bs-target="#carousel" data-bs-slide-to="2" aria-label="Slide 3"></button>
                </div>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <a href="Login.aspx">
                            <img src="imgs/MenBanner.png" class="d-block w-100" alt="..."></a>
                    </div>
                    <div class="carousel-item">
                        <a href="Login.aspx">
                            <img src="imgs/WomenBanner.png" class="d-block w-100" alt="..."></a>
                    </div>
                    <div class="carousel-item">
                        <a href="Login.aspx">
                            <img src="imgs/KidsBanner.png" class="d-block w-100" alt="..."></a>
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carousel" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carousel" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>

            <!--Corosel end---->

            <!-- CATEGORIES TO BAG -->
            <div class="text-banner-container">
                <h1 class="text-banner-title">CATEGORIES TO BAG</h1>
            </div>

            <div class="img-link-container">
                <a href="Shirts.aspx">
                    <img src="imgs/CategoriesImage/Shirts.jpg" />
                </a>
                <a href="TShirts.aspx">
                    <img src="imgs/CategoriesImage/Tshirt.jpg" />
                </a>
                <a href="Jeans.aspx">
                    <img
                        src="imgs/CategoriesImage/Jeans.jpg" />
                </a>
                <a href="Kurtas.aspx">
                    <img src="imgs/CategoriesImage/Kurtas.jpg" />
                </a>
                <a href="Sarees.aspx">
                    <img src="imgs/CategoriesImage/Sarees.jpg" />
                </a>
                <a href="Dresses.aspx">
                    <img src="imgs/CategoriesImage/Dresses.jpg" />
                </a>
            </div>

            <!----Categories-------->

            <!-- EXPLORE TOP BRANDS -->

            <div class="text-banner-container">
                <h1 class="text-banner-title">Explore The Top Collections</h1>
            </div>

            <div class="img-link-container">
                <a href="Mens.aspx">
                    <img src="imgs/Mens.png" /></a>
                <a href="Womens.aspx">
                    <img src="imgs/Womens.png" /></a>
                <a href="Kids.aspx">
                    <img src="imgs/Kids.png" /></a>
                <a href="Mens.aspx">
                    <img src="imgs/Mens2.png" /></a>
                <a href="Womens.aspx">
                    <img src="imgs/Women2.png" /></a>
                <a href="Kids.aspx">
                    <img src="imgs/Kids2.png" /></a>
            </div>

            <!-- icons section starts  -->

            <section class="icons-container">

                <div class="icons">
                    <img src="imgs/icon-1.png" alt="">
                    <div class="info">
                        <h1><b>Free Delivery</b></h1>
                        <h3><span><b>On All Orders Above 499</b></span></h3>
                    </div>
                </div>

                <div class="icons">
                    <img src="imgs/icon-2.png" alt="">
                    <div class="info">
                        <h1><b>30 days Return</b></h1>
                        <h3><span><b>Moneyback Guarantee</b></span></h3>
                    </div>
                </div>

                <div class="icons">
                    <img src="imgs/icon-3.png" alt="">
                    <div class="info">
                        <h1><b>Offers and Gifts</b></h1>
                        <h3><span><b>On All Orders</b></span></h3>
                    </div>
                </div>

                <div class="icons">
                    <img src="imgs/icon-4.png" alt="">
                    <div class="info">
                        <h1><b>secure payment</b></h1>
                        <h3><span><b>protected by paypal</b></span></h3>
                    </div>
                </div>

            </section>

            <!-- icons section ends -->

            <!-- footer section starts-->
            <div>
                <section class="footer">

                    <div class="box-container">

                        <div class="box">
                            <h1>quick links</h1>
                            <a href="Default.aspx">home</a>
                            <a href="#">men</a>
                            <a href="#">women</a>
                            <a href="#">kids</a>
                            <a href="#">Contact Us</a>
                        </div>

                        <div class="box">
                            <h1>User links</h1>
                            <a href="Login.aspx">my account</a>
                            <a href="Login.aspx">my order</a>
                            <a href="Login.aspx">my wishlist</a>
                        </div>

                        <div class="box">
                            <h1>locations</h1>
                            <a>Mumbai</a>
                            <a>Thane</a>
                            <a>Surat</a>
                            <a>Pune</a>
                        </div>

                        <div class="box">
                            <h1>contact info</h1>
                            <a href="#">9699287314</a>
                            <a>instafashion@gmail.com</a>
                            <a>mumbai, india - 400092</a>
                            <img src="imgs/payment.png" />
                        </div>
                    </div>
                    <div class="credit">created by <span>Annapurna Gupta </span>| © 2023 Copyright all rights reserved </div>

                </section>
            </div>
            <!-- footer section ends -->

        </div>
    </form>
</body>
</html>
