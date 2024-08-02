<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddGender.aspx.cs" Inherits="InstaFashionShopping.AddGender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ">
        <br />
        <br />
        <div class="form-horizontal ">
            <h2>Add Gender</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="Label1" CssClass="col-md-2 control-label " runat="server" Text="Gender Type"></asp:Label>
                <div class="col-md-3 ">

                    <asp:textbox id="txtGender" cssclass="form-control" runat="server"></asp:textbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" CssClass ="text-danger " ErrorMessage="*Please Enter Gender" ControlToValidate="txtGender" ForeColor="Red"></asp:RequiredFieldValidator>
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
        <h1>Gender</h1>
        <hr />
        <div class="panel panel-default">
            <div class="panel-heading">All Gender</div>
            <asp:Repeater ID="rptrGender" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Gender Type</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th><%# Eval("GenderID") %> </th>
                        <td><%# Eval("GenderName") %>   </td>
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