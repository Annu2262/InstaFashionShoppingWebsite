<%@ Page Title="" Language="C#" MasterPageFile="~/Products.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="InstaFashionShopping.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="StyleSheets/Product.css" rel="stylesheet" />
    <script>
        function openPaymentmethod(evt, method) {
            var i, tabcontent, tablinks;
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }
            document.getElementById(method).style.display = "block";
            evt.currentTarget.className += " active";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdCartAmount" runat="server" />
    <asp:HiddenField ID="hdCartDiscount" runat="server" />
    <asp:HiddenField ID="hdTotalPayed" runat="server" />
    <asp:HiddenField ID="hdPidSizeID" runat="server" />
    <div class="container">
        <div class="row" style="padding-top: 20px;">
            <div class="col-md-9">
                <h3>Delivery Address</h3>
                <hr />
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Name"></asp:Label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUsername" CssClass="text-danger" runat="server" ErrorMessage="Please Enter your Full Name" ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Address"></asp:Label>
                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="text-danger" runat="server" ErrorMessage="Please Enter your Full Address" ControlToValidate="txtAddress" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Pin Code"></asp:Label>
                    <asp:TextBox ID="txtPinCode" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="text-danger" runat="server" ErrorMessage="Please Enter your Pincode" ControlToValidate="txtPinCode" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="Mobile Number"></asp:Label>
                    <asp:TextBox ID="txtMobileNumber" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="Please Enter your Contact Number" ControlToValidate="txtMobileNumber" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div>
                </div>
                <div>
                    <asp:GridView ID="gvProducts" runat="server" CssClass="col-md-12" AutoGenerateColumns="false" Visible="false" CellPadding="6"
                        ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                        <Columns>
                            <asp:BoundField DataField="PID" HeaderText="Product ID" />
                            <asp:BoundField DataField="PName" HeaderText="Product Name" />
                            <asp:BoundField DataField="SizeID" HeaderText="Size ID" />
                            <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                        </Columns>
                    </asp:GridView>
                </div>
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
                </div>
            </div>
        </div>

        <div class="row" style="padding-top: 20px;">
            <div class="col-md-9">
                <h2>Payment Methods</h2>
                <p>Select Payment Method</p>
                <div class="tab">
                    <button class="tablinks" onclick="openPaymentmethod(event, 'COD');return false;">Cash on Delivery</button>
                    <button class="tablinks" onclick="openPaymentmethod(event, 'Card');return false;">Paytm</button>
                    <button class="tablinks" onclick="openPaymentmethod(event, 'NetBanking');return false;">NetBanking</button>
                </div>
                <br />
                <br />
                <br />
                <div id="COD" class="tabcontent">
                    <p></p>
                    <asp:Button ID="btnchceckoutcod" runat="server" Text="Proceed to checkout" CssClass="btn" OnClick="btnchceckoutcod_Click" CausesValidation="False" />
                </div>
                <div id="Card" class="tabcontent">
                    <div class="paymentcontainer">
                        <label for="fname">Accepted Cards</label>
                        <div class="icon-container">
                            <i class="fa fa-cc-visa" style="color: navy;"></i>
                            <i class="fa fa-cc-amex" style="color: blue;"></i>
                            <i class="fa fa-cc-mastercard" style="color: red;"></i>
                            <i class="fa fa-cc-discover" style="color: orange;"></i>
                        </div>
                        <asp:Label ID="lblname" runat="server" Text="Name on Card"></asp:Label>
                        <asp:TextBox ID="cname" runat="server" placeholder="John More Doe"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="cname" ErrorMessage="Name on Card is required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:Label ID="lblccnum" runat="server" Text="Credit card number"></asp:Label>
                        <asp:TextBox ID="ccnum" runat="server" placeholder="1111-2222-3333-4444"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCCNum" runat="server" ControlToValidate="ccnum" ErrorMessage="Credit card number is required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCCNum" runat="server" ControlToValidate="ccnum" ValidationExpression="^\d{4}-\d{4}-\d{4}-\d{4}$" ErrorMessage="Invalid credit card number format" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>

                        <asp:Label ID="lblmon" runat="server" Text="Exp Month"></asp:Label>
                        <asp:TextBox ID="expmonth" runat="server" placeholder="September"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvExpMonth" runat="server" ControlToValidate="expmonth" ErrorMessage="Expiration month is required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:Label ID="lblyear" runat="server" Text="Exp Year"></asp:Label>
                        <asp:TextBox ID="expyear" runat="server" placeholder="2018"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvExpYear" runat="server" ControlToValidate="expyear" ErrorMessage="Expiration year is required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revExpYear" runat="server" ControlToValidate="expyear" ValidationExpression="^\d{4}$" ErrorMessage="Invalid expiration year format" Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>

                        <asp:Label ID="lblcvv" runat="server" Text="CVV"></asp:Label>
                        <asp:TextBox ID="cvv" runat="server" placeholder="352" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCVV" runat="server" ControlToValidate="cvv" ErrorMessage="CVV is required" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:Button ID="btncardchceckout" runat="server" Text="Proceed to checkout" CssClass="btn" OnClick="btncardchceckout_Click" />
                    </div>
                </div>
                <div id="NetBanking" class="tabcontent">
                    <p>This just for Showing Purpose Will implement this in future </p>
                    <asp:Button ID="btnchcekoutnet" runat="server" Text="Proceed to checkout" CssClass="btn" CausesValidation="False" />
                </div>
            </div>
        </div>
    </div>
    <div style="height: 200px"></div>
</asp:Content>
