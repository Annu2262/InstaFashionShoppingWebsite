<%@ Page Title="" Language="C#" MasterPageFile="~/Products.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="InstaFashionShopping.ProductView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row" style="margin-left: 30px">
        <div class="col-md-12">
            <asp:Repeater ID="rptrmap" runat="server">
                <ItemTemplate>
                    <div class="midsize"><a href="UserHome.aspx">Home</a> / <a href="<%# Eval("GenderName")%>.aspx"><%# Eval("GenderName")%></a> / <span><%# Eval("PName") %> </span></div>
                </ItemTemplate>
            </asp:Repeater>
            <hr />

        </div>
    </div>

    <div >
        <!--- Success Alert --->
        <div id="divSuccess" runat="server" class="alert alert-success alert-dismissible fade in h4">
            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
            <strong>Success! </strong>Item successfully added to cart. <a href="Cart.aspx">View Cart</a>
        </div>
        <div class="row">
            <div class="col-md-5">
                <br />
                <div style="max-width: 480px; margin-left: 70px" class="thumbnail">
                    <%--   for proImage slider--%>
                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                            <asp:Repeater ID="rptrImage" runat="server">
                                <ItemTemplate>
                                    <div class="item <%#GetActiveImgClass(Container.ItemIndex) %>">
                                        <img id="imgProduct" src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %>' class="card-img-top" style="height: 540px; width: 504px">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <!-- Controls -->
                        <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>

                    <%--   for proImage slider ends --%>
                </div>
            </div>

            <div class="col-md-5">
                <asp:Repeater ID="rptrProductDetails" runat="server" OnItemDataBound="rptrProductDetails_ItemDataBound" OnItemCommand="rptrProductDetails_ItemCommand">
                    <ItemTemplate>
                        <div class="divDet1">
                            <h1 class="proNameView"><%# Eval("PName") %> </h1>
                            <span class="proOgPriceView" style="text-decoration:line-through">Rs.<%#Eval("PPrice","{0:c}") %></span><span class="proPriceDiscountView"> Off Rs.<%# string.Format("{0}",Convert.ToInt64(Eval("PPrice"))-Convert.ToInt64(Eval("PSelPrice"))) %></span><p class="proPriceView">Rs. <%#Eval("PSelPrice","{0:c}") %></p>
                        </div>
                        <div>
                            <h5 class="h5size">SIZE</h5>
                            <div>
                                <asp:RadioButtonList ID="rblSize" runat="server" RepeatDirection="Horizontal" >
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="divDet1">
                            <div style="display: flex; align-items: center">
                                <asp:Button ID="btnAddtoCart" CssClass="mainButton" runat="server" Text="ADD TO CART" OnClick="btnAddtoCart_Click" />
                                <asp:Label ID="lblError" CssClass="text-danger " runat="server"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btnAddtoWishlist" runat="server" Height="35px" ImageUrl="~/imgs/HeartGray.png" Width="45px" OnClick="btnAddtoWishlist_Click" />
                            </div>
                            <br />
                            <br />
                        </div>
                        <div class="divDet1">
                            <h5 class="h5size">Description</h5>
                            <p><%#Eval("PDescription") %>          </p>

                            <h5 class="h5size">Product Details</h5>
                            <p><%#Eval("PProductDetails") %>     </p>
                            <h5 class="h5size">Material & Care</h5>
                            <p><%#Eval("PMaterialCare") %></p>
                        </div>
                        <div>
                            <p>Free Delivery</p>
                            <p>30 Days Returns </p>
                            <p>Available Cash On Delivery</p>
                        </div>
                        <asp:HiddenField ID="hfCatID" runat="server" Value='<%# Eval("PcategoryID") %>' />
                        <asp:HiddenField ID="hfSubCatID" runat="server" Value='<%# Eval("PSubCatID") %>' />
                        <asp:HiddenField ID="hfGenderID" runat="server" Value='<%# Eval("PGender") %>' />
                        <asp:HiddenField ID="hfBrandID" runat="server" Value='<%# Eval("PBrandID") %>' />

                    </ItemTemplate>
                </asp:Repeater>
                <asp:TextBox ID="qt" runat="server"></asp:TextBox>


            </div>
        </div>

    </div>
    <!----ProductView Ends---->
</asp:Content>
