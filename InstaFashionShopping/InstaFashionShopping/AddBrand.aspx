<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddBrand.aspx.cs" Inherits="InstaFashionShopping.AddBrand" %>

<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ">
        <br />
        <br />
        <div class="form-horizontal ">
            <h2>Add Brand</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-2 control-label " runat="server" Text="BrandName"></asp:Label>
                <div class="col-md-3 ">

                    <asp:TextBox ID="txtBrand" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorBrandName" runat="server" CssClass="text-danger " ErrorMessage="*plz Enter Brandname" ControlToValidate="txtBrand" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-2 "></div>
                <div class="col-md-4 ">
                    <asp:Button ID="Button1" runat="server" Text="Add" BackColor="#009900" Font-Bold="False" Font-Size="12pt" ForeColor="White" Height="38px" Width="85px" border-radius="5px" OnClick="Button1_Click" />
                    <br />
                </div>
            </div>
        </div>
        <h1>Brands</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading">All Brands</div>
            <asp:Repeater ID="rptrBrands" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Brand</th>
                                <th>Edit</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("BrandID") %> </th>
                        <td><%# Eval("Name") %>   </td>
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

