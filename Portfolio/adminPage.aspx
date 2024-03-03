<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="Portfolio.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Admin Panel</title>
    <link rel="stylesheet" href="adminStyle.css" />
    <link rel="stylesheet" href="mediaqueries.css" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="admin-panel">
            <h2>Admin Panel</h2>
            <div class="form-group">
                <label for="username">Username:</label>
                <input type="text" id="username" name="username" runat="server" class="form-control" />
            </div>
            <div class="form-group">
                <label for="password">Password:</label>
                <input type="password" id="password" name="password" runat="server" class="form-control" />
                
            </div>
            <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="admin-button" OnClick="LoginButton_Click" />
             <div>
             <asp:Label ID="keep" runat="server" Text="Keep Me Signed In"></asp:Label>
             <asp:CheckBox ID="CheckBox1" runat="server" />
             </div>
             
        </div>
    </form>
</body>
</html>
