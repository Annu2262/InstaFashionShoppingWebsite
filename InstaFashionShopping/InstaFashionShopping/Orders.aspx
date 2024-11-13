<%@ Page Title="" Language="C#" MasterPageFile="~/Products.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="InstaFashionShopping.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .message-container {
            text-align: center;
            margin-top: 50px;
            font-family: Arial, sans-serif;
            color: #333;
        }
        .message-container h1 {
            font-size: 36px;
            color: #007BFF; /* Blue color for the heading */
        }
        .message-container p {
            font-size: 18px;
            color: #666; /* Gray color for additional text */
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="message-container">
        <h1>Coming Soon...</h1>
        <p>We are working hard to implement this page. Stay tuned!</p>
    </div>
</asp:Content>
