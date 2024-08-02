<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AbhayNew.aspx.cs" Inherits="InstaFashionShopping.AbhayNew" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Insta-Fashion Shopping</title>
    <script src="JS/jquery-3.5.1.min.js" type="text/javascript"></script>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE-edge">
    <link href="StyleSheets/UserMaster.css" type="text/css"  rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="StyleSheets/all.min.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Merienda:wght@700&family=Satisfy&display=swap" rel="stylesheet">
    <style>
        .drop-menu {
                position: absolute;
                left: 0;
                width: 220px;
                height: fit-content;
                top: 43px;
                line-height: 35px;
                background: #ffffff;
                display: none;
            }
         header .navbar1 ul {
        list-style: none;
    }

        header .navbar1 ul li {
            position: relative;
            float: left
        }
        header .navbar1 ul li:focus-within > ul,
            header .navbar1 ul li:hover > ul {
                display: initial;
                background-color:whitesmoke;
            }
        .divider{
              border-top: 3px solid grey;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
                <input type="checkbox" name="" id="toggler">
                <label for="toggler" class="fas fa-bars"></label>

                <a style="text-decoration: none; font-family: 'Merienda', cursive" href="UserHome.aspx" class="logo">Insta-Fashion<span></span></a>

                <nav class="navbar1">
                    <ul>
                        <li><a href="#">Home</a></li>
                        <li><a href="#">Products</a>
                        <ul class="drop-menu">
                            <li><a href="AddProduct.aspx">Add Product</a></li>
                            <li><a href="EditProduct.aspx">Edit Product</a></li>
                            <li><a href="AddSizeQuantity.aspx">Add Size-Quantity</a></li>
                            <li><a href="EditSizeQuantity.aspx">Update Quantity</a></li>
                        </ul></li>
                        <li><a href="ManageUsers.aspx">Users</a>
                        </li>
                        <li><a href="#">Orders</a>
                        </li>
                        <li><a href="#">Manage</a>
                            <ul class="drop-menu">
                                <li><a href="AddBrand.aspx">Add Brand</a></li>
                                <li><a href="AddCategory.aspx">Add Category</a></li>
                                <li><a href="AddSubCategory.aspx">Add Sub-Category</a></li>
                                <li><a href="AddGender.aspx">Add Gender</a></li>
                                <li role="separator" class="divider "></li>
                                <li><a href="EditBrand.aspx">Edit Brand</a> </li>
                                <li><a href="EditCategory.aspx">Edit Category</a> </li>
                                <li><a href="EditSubCategory.aspx">Edit SubCategory</a> </li>
                                <li role="separator" class="divider "></li>
                                <li><a href="#">Report</a> </li>
                            </ul>
                        </li>
                    </ul>
                </nav>
               
                <div class="icons">
                    <asp:Label ID="Label1" runat="server" Text="Welcome Admin!" Font-Bold="True" Font-Italic="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                    <a style="text-decoration: none" href="UserProfile.aspx" class="fas fa-user"></a>
                    <a style="text-decoration: none" ><asp:Button ID="btnLogout" runat="server" Text="Logout"  CssClass="btnlogout"/></a>
                
                </div>

            </header>
        </div>
        <br /><br /><br />
                    <!-- footer section starts-->
            <div>
                <section class="footer">

                    <div class="box-container">

                        <div class="box">
                            <h1>zquick links</h1>
                            <a href="UserHome.aspx">home</a>
                            <a href="Mens.aspx">men</a>
                            <a href="Womens.aspx">women</a>
                            <a href="Kis.aspx">kids</a>
                        </div>

                        <div class="box">
                            <h1>User links</h1>
                            <a href="UserProfile.aspx">my account</a>
                            <a href="UserOrders.aspx">my order</a>
                            <a href="Wishlist.aspx">my wishlist</a>
                            <a href="ContactUs.aspx">kids</a>
                        </div>

                        <div class="box">
                            <h1>locations</h1>
                            <a >Mumbai</a>
                            <a >Thane</a>
                            <a >Surat</a>
                            <a >Pune</a>
                        </div>

                        <div class="box">
                            <h1>Contact Info</h1>
                            <a>9699287314</a>
                            <a>instafashion@gmail.com</a>
                            <a>mumbai, india - 400092</a>
                            <img src="imgs/payment.png" />
                        </div>
                    </div>
                    <div class="credit">created by <span>Annapurna Gupta </span>| © 2023 Copyright all rights reserved </div>
                </section>
            </div>
    </form>
</body>
</html>
