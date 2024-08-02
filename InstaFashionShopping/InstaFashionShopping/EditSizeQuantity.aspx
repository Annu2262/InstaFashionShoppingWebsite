<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditSizeQuantity.aspx.cs" Inherits="InstaFashionShopping.EditSizeQuantity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ">
        <div class="form-horizontal ">
            <br />
            <br />

            <h2>Update Quantity</h2>
            <hr />

            <div class="form-group">
                <asp:label id="Label1" cssclass="col-md-2 control-label " runat="server" text="Size Name"></asp:label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlsize" cssclass="form-control" runat="server" AutoPostBack="true" ></asp:DropDownList>
                    <asp:requiredfieldvalidator id="RequiredFieldValidatorSize" runat="server" cssclass="text-danger " errormessage="*Please Select Size" controltovalidate="ddlsize" forecolor="Red"></asp:requiredfieldvalidator>
                </div>
            </div>

            <div class="form-group">
                <asp:label id="Label2" cssclass="col-md-2 control-label " runat="server" text="Product ID"></asp:label>
                <div class="col-md-3 ">
                    <asp:DropDownList ID="ddlproductid" cssclass="form-control" runat="server" AutoPostBack="true" ></asp:DropDownList>
                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" cssclass="text-danger " errormessage="*Please Select Product ID" controltovalidate="ddlsize" forecolor="Red"></asp:requiredfieldvalidator>
                </div>
            </div>

            

            <div class="form-group">
                <asp:label id="Label4" cssclass="col-md-2 control-label " runat="server" text="Quantity"></asp:label>
                <div class="col-md-3 ">

                    <asp:textbox id="txtquantity" cssclass="form-control" runat="server"></asp:textbox>
                    <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" cssclass="text-danger " errormessage="*Please Enter Quantity" controltovalidate="txtquantity" forecolor="Red"></asp:requiredfieldvalidator>
                </div>
            </div>

            
            <div class="form-group">
                <div class="col-md-2 "></div>
                <div class="col-md-4 ">
                    <asp:button id="btnUpdateQuantity" runat="server" text="Update" backcolor="#009900" font-bold="False" font-size="12pt" forecolor="White" height="38px" width="85px" border-radius="5px" OnClick="btnUpdateQuantity_Click"/>
                    <br />
                </div>
            </div>
        </div>
        <h1>Product Size Quantity </h1>
        <hr />
        <div class="panel panel-default">

            <div class="panel-heading">All Product Size Quantit</div>


            <asp:repeater id="rptrSizeQuantity" runat="server">

         <HeaderTemplate>
             <table class="table table-hover">
                  <thead>
                    <tr>
                        <th>Size</th>
                        <th>Product ID</th>
                         <th>Product Name</th>
                        <th>Quantity</th>
                    </tr>
                </thead>
            <tbody>
         </HeaderTemplate>
         <ItemTemplate>
             <tr>
                    <td><%# Eval("SizeName") %>   </td>
                 <td><%# Eval("PID") %>   </td>
                 <td><%# Eval("PName") %>   </td>
                 <td><%# Eval("Quantity") %>   </td>

 </tr>
         </ItemTemplate>
<FooterTemplate>
             </tbody>
</table>
         </FooterTemplate>
</asp:repeater>
        </div>
    </div>
</asp:Content>
