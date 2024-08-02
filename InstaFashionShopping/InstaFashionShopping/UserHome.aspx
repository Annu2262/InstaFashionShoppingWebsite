<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="InstaFashionShopping.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        .text-banner-title {
            text-transform: uppercase;
            color: black;
            letter-spacing: 0.12em;
            font-size: 3em;
            margin: 50px 30px;
            max-height: 5em;
            font-weight: 600;
            text-align: center;
        }

        img {
            display: block;
        }

        .img-link-container img {
            width: 100%;
            height: 90%;
        }

        .img-link-container {
            margin-left: 3.5%;
            margin-right: 3.5%;
            display: inline-flex;
            grid-template-columns: repeat(6, 15%);
        }

        .img-link-container-2 img {
            width: 100%;
        }

        .corousel-item {
            margin-top: 70px;
        }

        @media (max-width: 770px) {
            .img-link-container {
                display: flex;
                flex-wrap: wrap;
                justify-content: space-between;
            }

                .img-link-container a {
                    width: calc(33.33% - 10px);
                    margin-bottom: 20px;
                }
        }

        @media (max-width: 600px) {
            .text-banner-title {
                letter-spacing: 0.09em;
                font-size: 2em;
                max-height: 4em;
                font-weight: 600;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <!-- Carousel Start -->
    <div id="carousel" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carousel" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carousel" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carousel" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <a href="Mens.aspx">
                    <img src="imgs/MenBanner.png" class="d-block w-100" alt="..."></a>
            </div>
            <div class="carousel-item">
                <a href="Womens.aspx">
                    <img src="imgs/WomenBanner.png" class="d-block w-100" alt="..."></a>
            </div>
            <div class="carousel-item">
                <a href="Kids.aspx">
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
        <a href="Kurta.aspx">
            <img src="imgs/CategoriesImage/Kurtas.jpg" />
        </a>
        <a href="Saree.aspx">
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

    <!-- Icons section starts  -->

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

    <!-----------Ethenic Wear---------->
</asp:Content>
