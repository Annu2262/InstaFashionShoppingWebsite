<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="InstaFashionShopping.AddProduct" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="container">
       <div class ="form-horizontal">
           
           <br />
           <br />
           <h2>Add Product</h2>
           <hr style="height: 0px" />

           <div class ="form-group">
               <asp:Label ID="Label1" runat="server" CssClass ="col-md-2 control-label" Text="Proudct Name"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtProductName" CssClass ="form-control" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Product Name" ControlToValidate="txtProductName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label2" runat="server" CssClass ="col-md-2 control-label" Text="Price"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtPrice" CssClass ="form-control" runat="server" AutoPostBack="True"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Price" ControlToValidate="txtPrice" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>


           <div class="form-group">
               <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label" Text="DiscountPrice"></asp:Label>
               <div class="col-md-3"> 
                   <asp:TextBox ID="txtsellPrice" CssClass="form-control" runat="server" AutoPostBack="True" ></asp:TextBox>
                   <asp:CompareValidator ID="ValidatetxtSellPrice" runat="server" ErrorMessage="Discount price cannot be greater than price" ControlToValidate="txtsellPrice"  ForeColor="Red" ControlToCompare="txtPrice" Operator="LessThan" ValueToCompare="0" Display="Dynamic"></asp:CompareValidator>
                   
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label4" runat="server" CssClass ="col-md-2 control-label" Text="Brand"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlBrand" CssClass ="form-control" runat="server"></asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Brand" ControlToValidate="ddlBrand" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label5" runat="server" CssClass ="col-md-2 control-label" Text="Category"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlCategory" CssClass ="form-control" AutoPostBack ="true"  runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Category" ControlToValidate="ddlCategory" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label6" runat="server" CssClass ="col-md-2 control-label" Text="SubCategory"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlSubCategory" CssClass ="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged"></asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Select SubCategory" ControlToValidate="ddlSubCategory" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label19" runat="server" CssClass ="col-md-2 control-label" Text="Gender"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="ddlGender" CssClass ="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGender_SelectedIndexChanged" ></asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select Gender" ControlToValidate="ddlGender" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label8" runat="server" CssClass ="col-md-2 control-label" Text="Description"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtDescription" TextMode ="MultiLine"  CssClass ="form-control" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Product Description" ControlToValidate="txtDescription" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label9" runat="server" CssClass ="col-md-2 control-label" Text="Product Details"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtPDetail" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Product Details" ControlToValidate="txtPDetail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

           
            <div class ="form-group">
               <asp:Label ID="Label10" runat="server" CssClass ="col-md-2 control-label" Text="Materials and Care"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtMatCare" TextMode ="MultiLine" CssClass ="form-control" runat="server"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Product Material" ControlToValidate="txtMatCare" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label11" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg01" CssClass ="form-control" runat="server" />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Upload Image" ControlToValidate="fuImg01" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label12" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>
               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg02" CssClass ="form-control" runat="server" />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Upload Image" ControlToValidate="fuImg02" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>

           <div class ="form-group">
               <asp:Label ID="Label13" runat="server" CssClass ="col-md-2 control-label" Text="Upload Image"></asp:Label>

               <div class ="col-md-3">
                   <asp:FileUpload ID="fuImg03" CssClass ="form-control" runat="server" />
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please Upload Image" ControlToValidate="fuImg03" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
               </div>
           </div>
           
            <div class ="form-group">
               <asp:Label ID="Label16" runat="server" CssClass ="col-md-2 control-label" Text="Free Delivery"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="chFD" runat="server" />
               </div>
           </div>


            <div class ="form-group">
               <asp:Label ID="Label18" runat="server" CssClass ="col-md-2 control-label" Text="COD"></asp:Label>
               <div class ="col-md-3">
                   <asp:CheckBox ID="cbCOD" runat="server" />
               </div>
           </div>

           <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="Button1" runat="server" Text="Add" BackColor="#009900" Font-Bold="False" Font-Size="12pt" ForeColor="White" Height="38px" Width="85px" border-radius="5px" OnClick="Button1_Click" />
                    
                    </div>
                </div>

       </div>

    </div>

    <div class="container">
   
   <hr />
    <div class="panel panel-primary">
      <div class="panel-heading"><h2>Product Report</h2> </div>
      <div class="panel-body">
           <div class="col-md-12">
              <div class="form-group">
                <div class="table table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false">
                    <Columns>  
                        <asp:BoundField DataField="PID" HeaderText="S.No." />  
                        <asp:BoundField DataField="PName" HeaderText="PName" />  
                        <asp:BoundField DataField="PPrice" HeaderText="Price" />  
                        <asp:BoundField DataField="PSelPrice" HeaderText="SellPrice" />  
                        <asp:BoundField DataField="Brand" HeaderText="Brand" />  
                        <asp:BoundField DataField="CatName" HeaderText="Category" />  
                        <asp:BoundField DataField="SubCatName" HeaderText="SubCategory" />

                        <asp:BoundField DataField="gender" HeaderText="gender" />
                        
                        <asp:TemplateField HeaderText="Photo">  
                    <ItemTemplate>  
                    <img src='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %>'style="height: 55px; width: 50px">   
                    </ItemTemplate>  
                </asp:TemplateField> 

                       <%-- <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" />--%>
                        
                         </Columns> 
                    </asp:GridView>
                </div>
              
              </div>
           
           </div>
      
      
      </div>
      <div class="panel-footer">Panel Footer</div>
    </div>
    
</div>
</asp:Content>
