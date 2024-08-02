<%@ Page Title="" Language="C#" MasterPageFile="~/Products.Master" AutoEventWireup="true" CodeBehind="Kids.aspx.cs" Inherits="InstaFashionShopping.Kids" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row" style="margin-left: 30px">
                <div class="col-md-12">
                    
                    <div class="midsize"> <a href="UserHome.aspx">Home</a> / <span>Kids</span></div>
                    <h3>
                        <asp:Label ID="Label1" runat="server" Text="Showing All Kids Products"></asp:Label>
                    </h3>

                    <hr />

                </div>
            </div>

            <div class="row" style="margin-left: 30px">

                <asp:TextBox ID="txtFilterGrid1Record" CssClass="form-control" runat="server"
                    placeholder="Search Products...." AutoPostBack="true"
                    OnTextChanged="txtFilterGrid1Record_TextChanged" Style="width: 90%"></asp:TextBox>
                <br />
                <hr />

                <!-- Shop Section Begin -->
                <div>
                    <div class="container-fluid ">
                        <div class="row" style="width:100%">
                            <div class="col1" style="float: left; width: 15%; padding: 10px;">
                                <div class="shop__sidebar">

                                    <div class="shop__sidebar__accordion">
                                        <div class="accordion" id="accordionExample">

                                            <div class="card">
                                                <div class="card-heading">
                                                    <asp:Label ID="lblcategories" runat="server" Text="Categories" Font-Size="20px"></asp:Label>
                                                </div>
                                                
                                                    <div class="card-body">
                                                        <div class="shop__sidebar__categories">
                                                            <ul class="nice-scroll">
                                                              
                                                            <li>&nbsp; <a href="AllProduct.aspx">All</a></li>
                                                                <li>&nbsp; <a href="Mens.aspx">Men</a></li>
                                                                <li>&nbsp; <a href="Womens.aspx">Women</a></li>
                                                                <li>&nbsp; <a href="Kids.aspx">Kids</a></li>
                                                                <li>&nbsp; <a href="Unisex.aspx">Unisex</a></li>

                                                            </ul>
                                                        </div>
                                                    </div>
                                                
                                            </div>

                                            <div class="card">
                                                <div class="card-heading">
                                                    <asp:Label ID="lblfilter" runat="server" Text="Filter Price" Font-Size="20px"></asp:Label>
                                                </div>
                                                
                                                    <div class="card-body">
                                                        <div class="shop__sidebar__price">
                                                            <ul>
                                                                <li>&nbsp; <asp:CheckBox ID="r1" runat="server" AutoPostBack="true" Text="0-500"  OnCheckedChanged="r1_CheckedChanged"/></li>
                                                                <li>&nbsp; <asp:CheckBox ID="r2" runat="server" AutoPostBack="true" Text=" 500-1000" OnCheckedChanged="r2_CheckedChanged" /></li>
                                                                <li>&nbsp; <asp:CheckBox ID="r3" runat="server" AutoPostBack="true" Text=" 1000-1500" OnCheckedChanged="r3_CheckedChanged" /></li>
                                                                <li>&nbsp; <asp:CheckBox ID="r4" runat="server"  AutoPostBack="true" Text=" 1500-2000" OnCheckedChanged="r4_CheckedChanged"/></li>
                                                                <li>&nbsp; <asp:CheckBox ID="r5" runat="server" AutoPostBack="true" Text=" 2000-2500" OnCheckedChanged="r5_CheckedChanged"  /></li>
                                                                <li>&nbsp; <asp:CheckBox ID="r6" runat="server" AutoPostBack="true" Text=" 2500 & Above" OnCheckedChanged="r6_CheckedChanged"/></li>
                                                            </ul>
                                                     
                                                        </div>
                                                    </div>
                                                
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col2" >

                                <asp:Repeater ID="rptrProducts" runat="server">
                                    <ItemTemplate>
                                        <div class="product-disp" >

                                            <a href="ProductView.aspx?PID=<%# Eval("PID") %>" class="text-decoration-none">
                                                <div class="card thumbnail" >

                                                    <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %>' alt='<%# Eval("ImageName") %>' class="card-img-top" style="height: 300px; width: 280px">
                                                    <div class="card-body">
                                                        <h5 class="card-title"><%# Eval("BrandName") %> </h5>
                                                        <p class="card-text"><%# Eval("PName") %> </p>
                                                        <div class="d-flex justify-content-between align-items-center">
                                                            <span class="proOgPrice"><%# Eval("PPrice","{0:0,00}") %> </span>
                                                            <span class="proPrice"><%# Eval("PSelPrice","{0:c}") %> </span>
                                                            <span class="proPriceDiscount">(<%# Eval("DiscAmount","{0:0,00}") %> Rs off) </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </div>
                        </div>
                    </div>
                </div>
                <!-- Shop Section End -->
            </div>
</asp:Content>
