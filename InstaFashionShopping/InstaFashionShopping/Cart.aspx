<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="InstaFashionShopping.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="StyleSheets/Product.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div>
                    <div class="col-md-9">
                        <h4 class="proNameViewCart" runat="server" id="h4NoItems"></h4>
                        <div id="divQtyError" runat="server" class="alert alert-success alert-dismissible fade in h4">
                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                            <strong>Oops! </strong>Quantity cannot be less than 1.
                        </div>
                        <asp:Repeater ID="rptrCartProducts" OnItemCommand="rptrCartProducts_ItemCommand" runat="server">
                            <ItemTemplate>
                                <%--Show cart details start--%>
                                <div class="media" style="border: 1px solid black;">
                                    <div class="media-left">
                                        <a href="ProductView.aspx?PID=<%# Eval("PID") %>" target="_blank">
                                            <img class="media-object" style="width: 100px" src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %>' onerror="this.src='Images/NoImg.png'">
                                        </a>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                    <div class="media-body">
                                        <input type="text" id="txtPID" runat="server" class="proPriceDiscountView" value='<%#Eval("PID") %>' style="display: none" />
                                        <h4 class="media-heading proNameViewCart"><%# Eval("PName") %></h4>
                                        <input type="text" id="pSizeId" runat="server" class="proPriceDiscountView" value='<%#Eval("SizeID") %>' readonly style="display: none" />
                                        <span class="ProPriceViewCart">&nbsp<%#Eval("SizeName") %></span><br /><span class="ProPriceViewCart">Rs.&nbsp <%# Eval("PSelPrice","{0:0.00}") %></span>
                                        <span class="proOgPriceView" style="text-decoration: line-through">Rs.&nbsp <%# Eval("PPrice","{0:0.00}") %></span>

                                        <span class="proPriceDiscountView">Off Rs.<%# string.Format("{0}",Convert.ToInt64(Eval("PPrice"))-Convert.ToInt64(Eval("PSelPrice"))) %></span><div class="pull-right form-inline">
                                            <asp:Label ID="lblQty" runat="server" Text="Quantity:" Font-Size="Large"></asp:Label>
                                            <asp:Button ID="BtnMinus" CommandArgument='<%# Eval("PID") %>' CommandName="DoMinus" Font-Size="Large" runat="server" Text="-" Width="25px" BackColor="White" />&nbsp
                                    <asp:TextBox ID="txtQty" runat="server" Width="40" Font-Size="Large" TextMode="SingleLine" Style="text-align: center; padding: 6px;" ReadOnly Text='<%# Eval("Qty") %>'></asp:TextBox>&nbsp
                                     <asp:Button ID="BtnPlus" CommandArgument='<%# Eval("PID") %>' CommandName="DoPlus" runat="server" Text="+" Font-Size="Large" Width="25px" BackColor="White" BorderColor="White" />&nbsp&nbsp&nbsp                                          
                                        </div>
                                        <br />
                                        <p>
                                            <asp:Button CommandArgument='<%#Eval("CartID") %>' CommandName="RemoveThisCart" ID="btnRemoveCart" CssClass="RemoveButton1" runat="server" Text="Remove" />
                                            <br />
                                            <span class="proNameViewCart pull-right">SubTotal: Rs.&nbsp <%# Eval("SubSAmount","{0:0.00}") %></span>
                                        </p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--Show cart details Ending--%>
                    </div>

                    <div class="col-md-3" runat="server" id="divAmountSect">
                        <div style="border-bottom: 1px solid #eaeaec;">
                            <h5 class=" proNameViewCart">Price Details</h5>
                            <div>
                                <label class=" ">Total</label>
                                <span class="pull-right priceGray" runat="server" id="spanCartTotal"></span>
                            </div>
                            <div>
                                <label class=" ">Cart Discount</label>
                                <span class="pull-right priceGreen" runat="server" id="spanDiscount"></span>
                            </div>
                            <div>
                                <label class=" ">Convenience Fee</label>
                                <span class="pull-right priceGreen" runat="server" id="ConFee"></span>
                            </div>
                        </div>
                        <div>
                            <div class="cartTotal">
                                <label>Cart Total</label>
                                <span class="pull-right " runat="server" id="spanTotal"></span>
                            </div>

                            <div>
                                <asp:Button ID="btnBuyNow" CssClass="buyNowbtn" runat="server" OnClick="btnBuyNow_Click" Text="BUY NOW" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="height: 200px"></div>
</asp:Content>
