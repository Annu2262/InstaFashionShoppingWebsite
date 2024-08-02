<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="InstaFashionShopping.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br /><br /><br />
    <div>
    <div class="text-banner-container">
        <h1 class="title">Contact Us</h1>
    </div>
    <div class="row1">
<div class="container">
<div class="coloumn-left">
    <img src="imgs/ContactUs.png" alt="Contact Us" class="imgcontact" style="height: 400px; width: 100%;">
</div>
<div class="coloumn-right">
    <asp:Label ID="lblfullname" runat="server" Text="Full Name" Font-Names="'merienda', cursive;" Font-Size="16px"></asp:Label>
    <asp:TextBox ID="txtfirstname" runat="server"  placeholder="Your name"></asp:TextBox>
    
   <asp:Label ID="lblsubject" runat="server" Text="Subject" Font-Names="'merienda', cursive;" Font-Size="16px"></asp:Label>
    <asp:TextBox ID="txtsubject" runat="server" placeholder="Subject"></asp:TextBox>

   <asp:Label ID="lblmess" runat="server" Text="Message" Font-Names="'merienda', cursive;" Font-Size="16px"></asp:Label>
   <asp:TextBox ID="txtmess" runat="server" placeholder="Write your message here." TextMode="MultiLine" Height="150px"></asp:TextBox>

    <asp:Button ID="btnsubmit" runat="server" CssClass="btnsubmit" Text="Submit" Onclick="btnsubmit_Click"/>
  </div>

</div>
    </div>
        </div>
</asp:Content>
