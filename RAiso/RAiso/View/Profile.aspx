<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="RAiso.View.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Profile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="profileContainer">
            <div class="pictureContainer">
                <img class="picture" src="../Assets/ProfilePicture.jpg" alt="">
                <asp:Button CssClass="button" ID="UpdateBtn" runat="server" Text="Update Profile" OnClick="UpdateBtn_Click" />
            </div>
            <div class="identityContainer">
                <div class="credentials">
                    <asp:Label ID="Label1" CssClass="Label" runat="server" Text="Name"></asp:Label><p class="titikdua">:</p>
                    <asp:TextBox ID="TBName" CssClass="TB" runat="server"></asp:TextBox>
                </div>
                <div class="credentials">
                    <asp:Label ID="Label2" CssClass="Label" runat="server" Text="DOB"></asp:Label><p class="titikdua">:</p>
                    <asp:TextBox ID="TBDoB" CssClass="TB" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div class="credentials">
                    <asp:Label ID="Label3" CssClass="Label" runat="server" Text="Gender"></asp:Label><p class="titikdua">:</p>
                    <div class="RadioButton">
                        <asp:RadioButton ID="FemaleRadio" CssClass="NormalText" runat="server" Text="Female" GroupName="GenderGroup" />
                        <asp:RadioButton ID="MaleRadio" CssClass="NormalText" runat="server" Text="Male" GroupName="GenderGroup" />
                        
                    </div>
                </div>
                <div class="credentials">
                    <asp:Label ID="Label4" CssClass="Label" runat="server" Text="Address"></asp:Label><p class="titikdua">:</p>
                    <asp:TextBox ID="TBAddress" CssClass="TB" runat="server"></asp:TextBox>
                </div>
                <div class="credentials">
                    <asp:Label ID="Label5" CssClass="Label" runat="server" Text="Password"></asp:Label><p class="titikdua">:</p>
                    <asp:TextBox ID="TBPassword" CssClass="TB" runat="server"></asp:TextBox>
                </div>
                <div class="credentials">
                    <asp:Label ID="Label6" CssClass="Label" runat="server" Text="Phone Number"></asp:Label><p class="titikdua">:</p>
                    <asp:TextBox ID="TBPhone" CssClass="TB" runat="server"></asp:TextBox>
                </div>
                <div class="credentials">
                    <asp:Label ID="Error" CssClass="errortext" runat="server" Text=""></asp:Label>
                </div>


            </div>
        </div>
    </div>
</asp:Content>
