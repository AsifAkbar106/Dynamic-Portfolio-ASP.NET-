<%@ Page Title="" Language="C#" MasterPageFile="~/dashBoard.Master" AutoEventWireup="true" CodeBehind="experience.aspx.cs" Inherits="Portfolio.experience" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta charset="UTF-8" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0" />
     <title>Experience Page</title>
     <link rel="stylesheet" href="updatestyle.css" />
     <link rel="stylesheet" href="mediaqueries.css" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="update-form">
            <div><label for="typeField">Experience About :</label></div>
            <asp:DropDownList ID="DropDownList1" runat="server">

                <asp:ListItem Text="Frontend" Value="frontend"></asp:ListItem>
                <asp:ListItem Text="Backend" Value="backend"></asp:ListItem>

            </asp:DropDownList>

        <div><label for="SkillField">Skill:</label></div>
        <div class="input-group">
            <asp:TextBox ID="SkillNameTextBox" runat="server"></asp:TextBox>
        </div>
            <div><label for="\SkillField">Skill Level:</label></div>
        <asp:DropDownList ID="DropDownList2" runat="server">

        <asp:ListItem Text="Basic" Value="basic"></asp:ListItem>
        <asp:ListItem Text="Intermediate" Value="intermediate"></asp:ListItem>
        <asp:ListItem Text="Experienced" Value="experienced"></asp:ListItem>

        </asp:DropDownList>
    <div class="form-group">
    <label for="pictureField">Demo Picture :</label>
    <div class="input-group">
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>
       
        <br />
        <asp:Label ID="LabelMessage" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="updateButton" runat="server" Text="Include" CssClass="admin-button" OnClick="includeButton_Click" />

    </div>
</div>
    <div class="table-responsive">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            
            <asp:BoundField DataField="type" HeaderText="Frontend/Backend" />
            <asp:BoundField DataField="skillname" HeaderText="Skills" />
            <asp:BoundField DataField="skillLevel" HeaderText="Skill Level" />
            
            <asp:TemplateField HeaderText="Associated Image">
                <ItemTemplate>
                    <img src="<%#Eval("skillImage")%>" style="width:100px;height:100px" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton ID="UpdateLinkButton" CommandName="upd" CommandArgument='<%# Eval("skillname") %>' runat="server" >Update</asp:LinkButton>
                    <asp:LinkButton ID="DeleteLinkButton" CommandName="del" CommandArgument='<%# Eval("skillname") %>' OnClientClick="return confirm('are you sure you want to delete this skill?');" runat="server" >Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>


        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView> 
</div>
    
</asp:Content>
