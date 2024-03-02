<%@ Page Title="" Language="C#" MasterPageFile="~/dashBoard.Master" AutoEventWireup="true" CodeBehind="UpdateExperience.aspx.cs" Inherits="Portfolio.UpdateExperience" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="UTF-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
     <title>Experience Page</title>
     <link rel="stylesheet" href="updatestyle.css" />
     <link rel="stylesheet" href="mediaqueries.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="update-form">

        <label for="typeField">Experience About :</label>
        <asp:DropDownList ID="typeDropDownList" runat="server">

            <asp:ListItem Text="Frontend" Value="frontend"></asp:ListItem>
            <asp:ListItem Text="Backend" Value="backend"></asp:ListItem>

        </asp:DropDownList>

    
    <label for="SkillField">Skill :</label>
    <div class="input-group">
        <asp:TextBox ID="SkillNameTextBox" runat="server"></asp:TextBox>
    </div>
        <label for="SkillField">Skill Level:</label>
    <asp:DropDownList ID="levelDropDownList" runat="server">

    <asp:ListItem Text="Basic" Value="basic"></asp:ListItem>
    <asp:ListItem Text="Intermediate" Value="intermediate"></asp:ListItem>
    <asp:ListItem Text="Experienced" Value="experienced"></asp:ListItem>

    </asp:DropDownList>
<div class="form-group">
<label for="pictureField">Demo Picture</label>
<label>Path :</label>
<asp:TextBox ID="imagePathTextBox" runat="server"></asp:TextBox>
<div class="input-group">
    
    <asp:FileUpload ID="FileUpload1" runat="server" />
</div>
   
    <br />
    <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>
    <br />
    <asp:Button ID="updateButton" runat="server" Text="Include" CssClass="admin-button" OnClick="updateButton_Click" />

</div>

</asp:Content>
