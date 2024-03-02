<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Portfolio.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Update Page</title>
    <link rel="stylesheet" href="updatestyle.css" />
    <link rel="stylesheet" href="mediaqueries.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="update-form">
            
            <div class="form-group">
                <label for="aboutMeText">About Me:</label>
                <asp:TextBox ID="aboutMeTextBox" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="admin-button" OnClick="updateButton_Click" />
        </div>
    </form>
</body>
</html>
