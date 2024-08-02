<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="InstaFashionShopping.UserSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp Page</title>
    <link href="StyleSheets/SignUp.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Merienda:wght@700&family=Satisfy&display=swap" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
    <div class="container">
        <div class="title">Sign Up</div>
        <div class="content">
            <form id="form1" runat="server">
                <div class="user-details">
                    <div class="input-box">
                        <span class="details">Full Name</span>
                        <asp:TextBox ID="name_txt" runat="server" placeholder="Enter your name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter your name" ControlToValidate="name_txt" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                    <div class="input-box">
                        <span class="details">E-mail</span><asp:TextBox ID="email_txt" runat="server" placeholder="Enter your email" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter your email" ControlToValidate="email_txt" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email_txt" ErrorMessage="Enter correct email" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:Label ID="lblemailerr" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="input-box">
                        <span class="details">Phone Number</span><asp:TextBox ID="phone_txt" runat="server" placeholder="Enter your number" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter your number" ControlToValidate="phone_txt" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="phone_txt" ErrorMessage="Enter correct phone number" Display="Dynamic" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                    </div>
                    <div class="input-box">
                        <span class="details">Username</span>
                        <asp:TextBox ID="username_txt" runat="server" placeholder="Enter your username"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter your username" ControlToValidate="username_txt" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblunameerr" runat="server" ForeColor="Red"></asp:Label>                   
                    </div>
                    <div class="input-box">
                        <span class="details">Password</span>
                        <asp:TextBox ID="pass_txt" runat="server" placeholder="Enter your password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter your password" ControlToValidate="pass_txt" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regExPassword" runat="server" ControlToValidate="pass_txt" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$" ErrorMessage="Password must contain at least 1 uppercase letter, 1 lowercase letter, 1 digit, 1 special character, and be at least 8 characters long." Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="input-box">
                        <span class="details">Confirm Password</span>
                        <asp:TextBox ID="confirmpass_txt" runat="server" placeholder="Re-enter your password" TextMode="Password"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password entered is not same" ControlToCompare="pass_txt" ControlToValidate="confirmpass_txt" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter your password" ControlToValidate="confirmpass_txt" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="button">
                    <asp:Button ID="Button1" runat="server" Text="Sign Up" OnClick="Register" />
                </div>
                    <p style="text-align:center"> Already have an account? <a href="Login.aspx" style="text-decoration:none">Sign In</a></p>
            </form>
        </div>
    </div>
</body>
</html>
