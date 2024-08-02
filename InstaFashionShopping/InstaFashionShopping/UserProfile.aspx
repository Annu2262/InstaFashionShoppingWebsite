<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="InstaFashionShopping.UserProfile" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title> Profile</title> 
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
    <link rel="stylesheet" type="text/css" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="StyleSheets/UserProfile.css" rel="stylesheet" />
    
</head>
<body>
    <form runat="server">
        <section>
            <div class="container-fluid">
                <div class="bg-white d-sm-flex">
                    <div class="profile-tab-nav border-right">
                        <div class="p-4">
                            <div class="img-circle text-center mb-3">
                                <img src="imgs/User.png" alt="Image" class="shadow">
                            </div>
                            <asp:Label ID="lblname" class="text-center" style="display:flow-root" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="nav flex-column nav-pills" aria-orientation="vertical">
                            <a class="nav-link active" id="account-tab" data-toggle="pill" href="UserProfile.aspx">
                                <i class="fa fa-user text-center mr-1"></i>
                                Account
                            </a>
                            <a class="nav-link" href="Orders.aspx" role="button">
                                <i class="fa fa-shopping-bag text-center mr-1"></i>
                                Orders
                            </a>
                            <a class="nav-link" href="Wishlist.aspx" role="button">
                                <i class="fa fa-heart text-center mr-1"></i>
                                WishList
                            </a>
                            <a class="nav-link" href="UserHome.aspx" role="button">
                                <i class="fa fa-home text-center mr-1"></i>
                                Home
                            </a>
                            <a class="nav-link" href="ContactUs.aspx" role="button">
                                <i class="fa fa-address-book text-center mr-1"></i>
                                Contact Us
                            </a>
                            <a class="nav-link" role="button">
                                <i class="fa fa-user text-center mr-1"></i>
                                <asp:Button ID="btnlogout" runat="server" Text="Logout" BackColor="White" BorderStyle="None" OnClick="btnlogout_Click" />
                            </a>
                        </div>
                    </div>
                    <div class="tab-content p-4 p-md-5" id="v-pills-tabContent">
                        <div class="tab-pane fade show active" id="account" aria-labelledby="account-tab">
                            <h3 class="mb-4">My Account</h3>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblfullname" runat="server" Text="Full Name"></asp:Label>
                                        <asp:TextBox ID="txtfname" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter name" ControlToValidate="txtfname" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblusername" runat="server" Text="Username"></asp:Label>
                                        <asp:TextBox ID="txtuname" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter Username" ControlToValidate="txtuname" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblphone" runat="server" Text="Phone Number"></asp:Label>
                                        <asp:TextBox ID="txtphone" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Enter Phone Number" ControlToValidate="txtphone" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtphone"  ErrorMessage="Enter correct phone number" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Label ID="lblemail" runat="server" Text="E-mail"></asp:Label>
                                        <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="txtemail" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter Correct Email" ControlToValidate="txtemail" Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group">
                                        <asp:Label ID="Label1" runat="server" Text="Address"></asp:Label>
                                        <asp:TextBox ID="txtadd" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            

                            <div>
                                <asp:Button ID="update"  CssClass="btn btn-success" runat="server" Text="Update"   OnClick="update_Click"/>
                                <asp:Button ID="btncanceluserupdate"  CssClass="btn btn-light" runat="server" Text="Cancel" onclick="btncanceluserupdate_Click" />
                            </div>
                        </div>
                        <br />
                        <div>
                            <h3 class="mb-4">Password Settings</h3>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Old password</label>
                                        <asp:TextBox ID="txtoldpass" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>New password</label>
                                        <asp:TextBox ID="txtnewpass" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Confirm new password</label>
                                        <asp:TextBox ID="txtconfpass" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match " ControlToCompare="txtnewpass" ControlToValidate="txtconfpass" Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <asp:Button ID="btnupadatepass"  CssClass="btn btn-success" runat="server" Text="Update" onclick="btnupadatepass_Click"/>
                                <asp:Button ID="btncancel"  CssClass="btn btn-light" runat="server" Text="Cancel"  onclick="btncancel_Click"/>
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                
                                
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>


        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
