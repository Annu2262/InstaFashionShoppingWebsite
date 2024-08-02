<%@ Page Title="" Language="C#" MasterPageFile="~/Products.Master" AutoEventWireup="true" CodeBehind="Wishlist.aspx.cs" Inherits="InstaFashionShopping.Wishlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-left: 30px">
        <div class="col-md-12">
            <div class="midsize"><a href="UserHome.aspx">Home</a> / <a href="UserProfile.aspx">My Account</a> / <span>All</span></div>
            <h3>
                <asp:Label ID="Label1" runat="server" Text="Showing All Products"></asp:Label>
            </h3>
            <hr />
        </div>
    </div>

        <!-- Shop Section Begin -->
        <div>
            <div class="container-fluid ">
                <div class="row" style="width: 100%">
                    <asp:Repeater ID="rptrWishlist" runat="server" OnItemCommand="rptrWishlist_ItemCommand1">
                        <ItemTemplate>
                            <div class="product-disp">
                                <a href="ProductView.aspx?PID=<%# Eval("PID") %>" class="text-decoration-none">
                                    <div class="card thumbnail">
                                        <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %>' alt='<%# Eval("ImageName") %>' class="card-img-top" style="height: 300px; width: 280px">
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval("BrandName") %> </h5>
                                            <p class="card-text"><%# Eval("PName") %> </p>
                                            <div class="d-flex justify-content-between align-items-center">
                                                <span class="proOgPrice"><%# Eval("PPrice","{0:0,00}") %> </span>
                                                <span class="proPrice"><%# Eval("PSelPrice","{0:c}") %> </span>
                                                <span class="proPriceDiscount">(<%# Eval("DiscAmount","{0:0,00}") %>Rs off) </span>
                                            </div>
                                            <p>
                                                <asp:Button CommandArgument='<%#Eval("PID") %>' CommandName="RemoveFromWishlist" ID="btnRemove" CssClass="RemoveButton1" runat="server" Text="Remove" />
                                                <asp:Button CommandArgument='<%#Eval("PID") %>' CommandName="Addtocart" ID="Button1" CssClass="RemoveButton1" runat="server" Text="Add to cart" />
                                                <br />
                                            </p>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <!-- Shop Section End -->
</asp:Content>

