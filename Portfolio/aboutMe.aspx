<%@ Page Title="" Language="C#" MasterPageFile="~/dashBoard.Master" AutoEventWireup="true" CodeBehind="aboutMe.aspx.cs" Inherits="Portfolio.aboutMe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<meta charset="UTF-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<title>Update Page</title>
<link rel="stylesheet" href="updatestyle.css" />
<link rel="stylesheet" href="mediaqueries.css" />
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="update-form">
    
    <div class="form-group">
        
        <asp:TextBox ID="aboutMeTextBox" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="admin-button" OnClick="updateButton_Click" />
    </div>
</asp:Content>
