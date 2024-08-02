
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="InstaFashionShopping.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="container">
       <div class ="form-horizontal">
           
           <br />
           <br />
           <h2>Edit Product</h2>
           <hr style="height: 0px" />

           <div class="form-group">
                <asp:label id="lblpid" cssclass="col-md-2 control-label " runat="server" text="Select a Product"></asp:label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlproductid" cssclass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlproductid_SelectedIndexChanged" ></asp:DropDownList>
                   
                    
                </div>
            </div>

           <div class ="form-group">
               <asp:Label ID="lblpname" runat="server" CssClass ="col-md-2 control-label" Text="Proudct Name"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtProductName" CssClass ="form-control" runat="server"></asp:TextBox>


               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="lblprice" runat="server" CssClass ="col-md-2 control-label" Text="Price"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtPrice" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="lblselprice" runat="server" CssClass ="col-md-2 control-label" Text="SellingPrice"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtsellPrice" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="lblbrand" runat="server" CssClass ="col-md-2 control-label" Text="Brand"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
               </div>
           </div>



           <div class ="form-group">
               <asp:Label ID="lblcat" runat="server" CssClass ="col-md-2 control-label" Text="Category"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlCategory" CssClass ="form-control" AutoPostBack ="true"  runat="server" ></asp:DropDownList>
               </div>
           </div>


           <div class ="form-group">
               <asp:Label ID="lblsubcat" runat="server" CssClass ="col-md-2 control-label" Text="SubCategory"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlSubCategory" CssClass ="form-control" runat="server" AutoPostBack="True" ></asp:DropDownList>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="lblgen" runat="server" CssClass ="col-md-2 control-label" Text="Gender"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlGender" CssClass ="form-control" runat="server" AutoPostBack="True" ></asp:DropDownList>
               </div>
           </div>

           

            <div class ="form-group">
               <asp:Label ID="lbldes" runat="server" CssClass ="col-md-2 control-label" Text="Description"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtDescription" TextMode ="MultiLine"  CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="lblpdetails" runat="server" CssClass ="col-md-2 control-label" Text="Product Details"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtPDetail" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

           
            <div class ="form-group">
               <asp:Label ID="lblmatcare" runat="server" CssClass ="col-md-2 control-label" Text="Materials and Care"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtMatCare" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="lblimg1" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg01" CssClass ="form-control" runat="server" />
               </div>
           </div>
           <div class ="form-group">
               <asp:Label ID="lblimg2" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg02" CssClass ="form-control" runat="server" />
               </div>
           </div>
           <div class ="form-group">
               <asp:Label ID="lblimg3" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg03" CssClass ="form-control" runat="server" />
               </div>
           </div>
           

           

            <div class ="form-group">
               <asp:Label ID="lblfreedel" runat="server" CssClass ="col-md-2 control-label" Text="Free Delivery"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="chFD" runat="server" />
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="lblcod" runat="server" CssClass ="col-md-2 control-label" Text="COD"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="cbCOD" runat="server" />
               </div>
           </div>


           <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btnUpdate" runat="server" Text="Update" BackColor="#009900" Font-Bold="False" Font-Size="12pt" ForeColor="White" Height="38px" Width="85px" border-radius="5px"  OnClick="btnUpdate_Click" />
                    
                    </div>
                </div>

       </div>

    </div>

    <div class="container">
   
   <hr />
</div>
</asp:Content>


