<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="StationeryDetails.aspx.cs" Inherits="RAiso.View.StationeryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/StationeryDetails.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="CenterBox">
        <div class="container1180px">
            <div class="imgcontainer">
                <img src="../Assets/StationeryHome.jpg" alt="">
            </div>
            <div class="flexcolumn detailcontainer">
                <asp:Label ID="Name" CssClass="StatName" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="Price" CssClass="StatPrice" runat="server" Text="Rp.10000"></asp:Label>
                <asp:Label ID="Description" CssClass="wrap-text Descriptions" runat="server" Text="RAiso is your premier destination for top-quality stationery, offering a vast selection to meet all your needs. Whether you're a student, professional, or creative enthusiast, RAiso provides carefully selected products that combine functionality with style, from elegant pens and pencils to stylish notebooks and planners."></asp:Label>

                <asp:Panel ID="BtnContainer" runat="server" CssClass="flexcolumn btncontainer">
                    <asp:Label ID="Utility1" CssClass="Utility1" Visible="false" runat="server" Text="Specify Quantity"></asp:Label>
                    <asp:TextBox ID="Quantity" CssClass="QuantityBox" Visible="false" runat="server" Text="1" TextMode="Number"></asp:TextBox>
                    <asp:Button ID="AddCartBtn" CssClass="cardbtn1" Visible="false" runat="server" Text="Add to Cart" OnClick="AddCartBtn_Click" />
                    <asp:Button ID="PurchaseBtn" CssClass="cardbtn2" Visible="false" runat="server" Text="Purchase" OnClick="PurchaseBtn_Click" />
                    <asp:Label ID="lblAlert" runat="server" Visible="false" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
