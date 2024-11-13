<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="InstaFashionShopping.AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        /* General page styling */
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f9f9f9; /* Light background for clean look */
            margin: 0;
            padding: 0;
        }

        /* Centered message container */
        .welcome-container {
            text-align: center;
            margin-top: 20px; /* Increased top margin */
            padding: 20px;
        }

        /* Styling for welcome message */
        .welcome-container h1 {
            font-size: 3.5rem; /* Larger font for the heading */
            color: #007bff; /* Blue color for visibility */
            margin-bottom: 15px;
            font-weight: bold; /* Bold text for emphasis */
        }

        /* Styling for sub message (Optional for further clarity) */
        .welcome-container p {
            font-size: 2.3rem;
            color: #555; /* Dark gray text for the message */
        }
    </style>

    <div class="welcome-container">
        <h1>Welcome Admin!!!</h1>
        <p>Manage your store efficiently with the tools available here.</p>
    </div>
</asp:Content>
