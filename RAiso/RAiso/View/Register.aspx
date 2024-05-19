<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RAiso.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Register.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="parentContainer">
            <div class="whiteBG">
                <div class="LeftContainer">
                    <div class="CenterContainer">
                        <asp:Label ID="LoginLbl" runat="server" Text="Register"></asp:Label>
                    </div>
                    <asp:Label ID="NameLbl" CssClass="NormalText" runat="server" Text="Name"></asp:Label> <br />
                    <asp:TextBox ID="Name" CssClass="TextBoxes" runat="server" placeholder="Name"></asp:TextBox> <br />

                    <asp:Label ID="DateLbl" CssClass="NormalText" runat="server" Text="Date Of Birth"></asp:Label> <br />
                    <asp:TextBox ID="Date" CssClass="TextBoxes" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox> <br />

                    <asp:Label ID="GenderLbl" CssClass="NormalText" runat="server" Text="Gender"></asp:Label> <br />
                    <div class="RadioButton">
                        <asp:RadioButton ID="FemaleRadio" CssClass="NormalText" runat="server" Text="Female" GroupName="GenderGroup" />
                        <asp:RadioButton ID="MaleRadio" CssClass="NormalText" runat="server" Text="Male" GroupName="GenderGroup" /> <br />
                    </div>

                    <asp:Label ID="AddressLbl" CssClass="NormalText" runat="server" Text="Address"></asp:Label> <br />
                    <asp:TextBox ID="Address" CssClass="TextBoxes" runat="server" placeholder="Address"></asp:TextBox> <br />

                    <asp:Label ID="PasswordLbl" CssClass="NormalText" runat="server" Text="Password"></asp:Label> <br />
                    <asp:TextBox ID="Password" CssClass="TextBoxes" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox> <br />

                    <asp:Label ID="PhoneNumberLbl" CssClass="NormalText" runat="server" Text="Phone Number"></asp:Label> <br />
                    <asp:TextBox ID="PhoneNumber" CssClass="TextBoxes" runat="server" placeholder="081x xxxx xxxx"></asp:TextBox> <br />

                    <asp:Button ID="RegisterBtn" CssClass="Login" runat="server" Text="Register" OnClick="RegisterBtn_Click"/> <br />
                    <asp:Label ID="Error" CssClass="NormalText" runat="server" Text="Error" Visible="false"></asp:Label> <br />
                    <asp:Label ID="RegisterLbl" CssClass="NormalText" runat="server" Text="Already have an account?"></asp:Label>
                    <asp:LinkButton ID="Login" OnClick="Login_Click" runat="server">LOGIN</asp:LinkButton>
                </div>
                <div>
                    <asp:Image ID="RightContainer" runat="server" ImageUrl="../Assets/Stationery.jpg"/>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
