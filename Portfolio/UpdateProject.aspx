<%@ Page Title="" Language="C#" MasterPageFile="~/dashBoard.Master" AutoEventWireup="true" CodeBehind="UpdateProject.aspx.cs" Inherits="Portfolio.UpdateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Update Project Page</title>
    <link rel="stylesheet" href="updatestyle.css" />
    <link rel="stylesheet" href="mediaqueries.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="update-form">
    <label for="idField">Project Id(Unique) :</label>
    <div class="input-group">
    <asp:TextBox ID="idTextBox" runat="server"></asp:TextBox>
    </div>
    <label for="nameField">Project Name :</label>
    <div class="input-group">
        <asp:TextBox ID="ProjectNameTextBox" runat="server"></asp:TextBox>
    </div>
        <label>Path :</label>
    <div class="input-group">
    
    <asp:TextBox ID="FileUploadTextBox" runat="server"></asp:TextBox>
</div>

<div class="form-group">

<label for="pictureField">Project Demo Picture</label>
<div class="input-group">
    <asp:FileUpload ID="FileUpload1" runat="server" />
</div>
    <label for="gitHubField">Github Link:</label>
    <div class="input-group">
        <asp:TextBox ID="gitHubTextBox" runat="server"></asp:TextBox>
    </div>
    <label for="demoField">Live Demo Link:</label>
    <div class="input-group">
        <asp:TextBox ID="demoLinkTextBox" runat="server"></asp:TextBox>
    </div>

    <br />
    <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="admin-button" OnClick="updateButton_Click"/>

</div>
</asp:Content>
