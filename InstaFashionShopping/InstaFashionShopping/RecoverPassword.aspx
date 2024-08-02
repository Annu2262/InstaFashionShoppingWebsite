<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="InstaFashionShopping.RecoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="StyleSheets/ForgotPassword.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <div class="container" id="container">

        <form id="form1" runat="server">
            <h1 style="color: #9B59B6; font-family: Gabriola; font-size: 38px; font-weight: bolder;">Creating New Password</h1>
            <div class="user-login">
                <div class="input-box">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="New Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter New Password" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <div class="input-box">
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Confirm New Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter New Password" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox1" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Password enter does not match" ForeColor="Red"></asp:CompareValidator>
                    <br />
                </div>
            </div>

            <asp:Button ID="Button1" runat="server" Text="Reset Password" CssClass="button" OnClick="Button1_Click" />

            <br />
            
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        </form>
    </div>

</body>
</html>