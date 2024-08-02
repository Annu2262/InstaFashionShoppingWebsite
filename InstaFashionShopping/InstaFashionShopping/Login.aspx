<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InstaFashionShopping.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href="StyleSheets/Login.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Merienda:wght@700&family=Satisfy&display=swap" rel="stylesheet">
    <title></title>
</head>
<body>
	<div class="container" id="container">
		<div class="form-container log-in-container">
			<form id="form1" runat="server">
				<h1 style="color:#9B59B6; font-family: Gabriola; font-size: 50px; font-weight: bolder;">Sign In</h1>
				<div class="user-login">
				<div class="input-box">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Username" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Username" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
				  </div>
				  <div class="input-box">
					<asp:TextBox ID="TextBox2" runat="server" placeholder="Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter valid password" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
				  </div>
				  </div>
                <div>
                    <label for="rememberme">
                        <asp:CheckBox ID="CheckBox1" runat="server"/>
                        Remember Me
                    </label>

                </div>
                <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="button" OnClick="btnSignIn_click" />
                <a href="ForgotPassword.aspx">Forgot password?</a>
                   <p> Not Registered?<a href="UserSignUp.aspx"> Sign Up</a></p>
                <p> <asp:Label ID="Label1" runat="server" ForeColor="Red" Width="15px"></asp:Label></p>
			</form>
		</div>
		<div class="overlay-container">
			<div class="overlay">
				<div class="overlay-panel overlay-right">
                    <h1 style="font-family: Gabriola">Welcome Back!</h1>
                    <h1 style="font-family: Gabriola">Nice To see you again!</h1>
                    <img src="imgs/Loginimg.png" style="height: 60%;width: 125% "/>
					<p></p>
				</div>
			</div>
		</div>
	</div>
</body>
</html>


