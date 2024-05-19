<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RAiso.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="LoginForm" runat="server">

        <div class="parentContainer">
            <div class="whiteBG">
                <div class="LeftContainer">
                    <div class="CenterContainer">
                        <asp:Label ID="LoginLbl" runat="server" Text="Login"></asp:Label>
                    </div>
                    <asp:Label ID="NameLbl" CssClass="NormalText" runat="server" Text="Name"></asp:Label> <br />
                    <asp:TextBox ID="Name" CssClass="TextBoxes" runat="server" placeholder="Name"></asp:TextBox> <br />
                    <asp:Label ID="PasswordLbl" CssClass="NormalText" runat="server" Text="Password"></asp:Label> <br />
                    <asp:TextBox ID="Password" CssClass="TextBoxes" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox> <br />
                    <asp:CheckBox ID="RememberMe" CssClass="RememberMe" runat="server" Text="Remember Me"/> <br />
                    <asp:Button ID="LoginBtn" CssClass="Login" runat="server" Text="Login" OnClick="LoginBtn_Click"/> <br />
                    <asp:Label ID="Error" CssClass="NormalText" runat="server" Text="Error" Visible="false"></asp:Label> <br />
                    <asp:Label ID="RegisterLbl" CssClass="NormalText" runat="server" Text="Don't have an account?"></asp:Label>
                    <asp:LinkButton ID="RegisterLink" OnClick="RegisterLinks_Click" runat="server">REGISTER</asp:LinkButton>
                </div>
                <div>
                    <asp:Image ID="RightContainer" runat="server" ImageUrl="../Assets/Stationery.jpg"/>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
