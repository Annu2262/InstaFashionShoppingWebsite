<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="InstaFashionShopping.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        * {
            box-sizing: border-box;
        }

        .column1 {
            float: left;
            width: 40%;
            padding: 10px;
        }

        .column2 {
            float: right;
            width: 60%;
            padding: 10px;
        }

        .row:after {
            content: "";
            display: table;
            clear: both;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container">

        <hr />
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h2>All Users</h2>
            </div>
            <div class="panel-body">
                <div class="col-md-12">
                    <div class="form-group">
                        <div class="table table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting" >
                                <Columns>

                                    <asp:BoundField DataField="user_id" HeaderText="S.No." />
                                    <asp:BoundField DataField="full_name" HeaderText="Name" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="Phone" HeaderText="Phone No" />
                                    <asp:BoundField DataField="Username" HeaderText="Username" />
                                    <asp:BoundField DataField="Password" HeaderText="Password" />
                                    <asp:BoundField DataField="UserType" HeaderText="UserType" />
                                    <asp:CommandField ShowEditButton="true" HeaderText="Edit" />
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>

                </div>


            </div>
        </div>
        <div class="panel-footer"></div>
    </div>
</asp:Content>
