<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddSubCategory.aspx.cs" Inherits="InstaFashionShopping.AddSubCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container ">
        <br />
        <br />
        <div class="form-horizontal ">
            <h2>Add Sub-Category</h2>
            <hr />
            <div class ="form-group">
                    <asp:Label ID="Label2" CssClass ="col-md-2 control-label " runat="server" Text="Main CategoryID"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:DropDownList ID="ddlMainCatID" CssClass ="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMainCatID" runat="server" CssClass ="text-danger " ErrorMessage="*Please Enter Main CategoryID" ControlToValidate="ddlMainCatID" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-2 control-label " runat="server" Text="Sub-Category Name"></asp:Label>
                <div class="col-md-3 ">

                    <asp:TextBox ID="txtSubCategory" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtSubCategoryName" runat="server" CssClass="text-danger " ErrorMessage="*Please Enter Sub-Category Name" ControlToValidate="txtSubCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2 "></div>
                <div class="col-md-4 ">
                    <asp:Button ID="btnAddSubCategory" runat="server" Text="Add" BackColor="#009900" Font-Bold="False" Font-Size="12pt" ForeColor="White" Height="38px" Width="85px" border-radius="5px" OnClick="btnAddSubCategory_Click" />
                    <br />
                </div>
            </div>
        </div>
        <h1>Category</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading">All Sub-Categories</div>
            <asp:Repeater ID="rptrSubCategory" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Sub-Category</th>
                                <th>Main Category ID</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("SubCatID") %> </th>
                        <td><%# Eval("SubCatName") %>   </td>
                        <td><%# Eval("CatName") %>   </td>
                        <td>Edit</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
              </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <hr />
    </div>
</asp:Content>
