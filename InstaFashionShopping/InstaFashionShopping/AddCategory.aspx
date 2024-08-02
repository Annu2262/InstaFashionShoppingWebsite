<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="InstaFashionShopping.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container ">
        <br />
        <br />
        <div class="form-horizontal ">
            <h2>Add Category</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-2 control-label " runat="server" Text="Category Name"></asp:Label>
                <div class="col-md-3 ">

                    <asp:TextBox ID="txtCategory" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtCategoryName" runat="server" CssClass="text-danger " ErrorMessage="*Please Enter Categoryname" ControlToValidate="txtCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2 "></div>
                <div class="col-md-4 ">
                    <asp:Button ID="btnAddCategory" runat="server" Text="Add" BackColor="#009900" Font-Bold="False" Font-Size="12pt" ForeColor="White" Height="38px" Width="85px" border-radius="5px" OnClick="btnAddCategory_Click" />
                    <br />
                </div>
            </div>
        </div>
        <h1>Category</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading">All Categories</div>
            <asp:Repeater ID="rptrCategory" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Categories</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("CatID") %> </th>
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
