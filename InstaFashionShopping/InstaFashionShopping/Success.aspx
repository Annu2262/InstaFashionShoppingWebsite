<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="InstaFashionShopping.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Styling for the success message container */
        .success-container {
            text-align: center;
            padding: 50px; /* Padding inside the container */
            margin-top: 100px; /* Increased margin above */
            margin-bottom: 100px; /* Increased margin below */
            border: 2px solid #e0e0e0;
            background-color: #f9f9f9;
            border-radius: 12px;
            box-shadow: 0px 0px 15px rgba(0, 0, 0, 0.1);
            max-width: 700px;
            margin-left: auto;
            margin-right: auto;
        }

        /* Heading styling */
        .success-container h1 {
            font-size: 3em; /* Increased font size */
            color: #4CAF50; /* Green color for success */
            margin-bottom: 20px;
        }

        /* Paragraph text */
        .success-container p {
            font-size: 1.8em; /* Increased font size */
            color: #333333;
            margin-bottom: 30px;
        }

        /* Button styling */
        .btn-continue {
            display: inline-block;
            margin-top: 20px;
            padding: 15px 30px;
            background-color: #4CAF50;
            color: #ffffff;
            text-decoration: none;
            font-size: 2em; /* Increased font size */
            border-radius: 8px;
            transition: background-color 0.3s ease;
        }

        /* Button hover effect */
        .btn-continue:hover {
            background-color: #45a049;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="success-container">
        <h1>Thank You For Your Purchase!</h1>
        <p>Your order has been placed successfully. You will receive an email confirmation shortly with your order details.</p>
        
        <!-- Button to continue shopping or navigate back -->
        <a href="UserHome.aspx" class="btn-continue">Go To Homepage</a>
    </div>
</asp:Content>
