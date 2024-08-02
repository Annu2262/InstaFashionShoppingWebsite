<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="InstaFashionShopping.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="StyleSheets/ForgotPassword.css" rel="stylesheet" />
    <title>Retrieve Password</title>
</head>
<body>
	<div class="container" id="container">
			<form id="form" runat="server">
				<h2 style="color:#9B59B6; font-family: Gabriola; font-size: 50px; font-weight: bolder;">Retrieve Password</h2>
                <p>Enter your email and we'll send your password to your registered email.</p>
				<br />
                <div class="input-box">
                    <asp:TextBox ID="username" runat="server" placeholder="Enter your username" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Your Email" ControlToValidate="username" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                 <div class="input-box">
                    <asp:TextBox ID="emailtxt" runat="server" placeholder="Enter your Email" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Your Email" ControlToValidate="emailtxt" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="emailtxt" Display="Dynamic" ErrorMessage="Please enter a valid Email Id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
               <br />
                <asp:Button ID="Button1" runat="server" Text="Send Link" CssClass="button" OnClick="Button1_Click"/>
               
                   <br />
               
                <asp:Label ID="msg" runat="server" ForeColor="Green"></asp:Label>
                <asp:Label ID="msg1" runat="server" ForeColor="Red"></asp:Label>
			</form>
	</div>
</body>
</html>
