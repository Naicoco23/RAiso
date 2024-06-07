<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RAiso.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Home.css" rel="stylesheet" />
    <script src="../Script/Home.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="SearchBar">
        <div class="left-container">
            <asp:Label ID="SearchLbl" CssClass="SearchLbls" runat="server" Text="Search Your Stationery"></asp:Label>
        </div>
        <div class="mid-container">
            <asp:TextBox ID="SearchInput" CssClass="SearchInputs" runat="server" placeholder="Search"></asp:TextBox>
            <asp:Button ID="Search" CssClass="SearchBtn" runat="server" Text="Search" OnClick="Search_Click"/>
        </div>
        <div class="right-container">
            <asp:Button ID="AddStationery" CssClass="AddStationeryBtn" runat="server" Text="Add Stationery" Visible="false" OnClick="AddStationery_Click" />
        </div>
    </div>

    <div class="CenterBox">
        <div class="carouselContainer">
            <div class="carousel">
                <div class="carouselbtn left hide">
                    <img class="btnImg" src="../Assets/Left.png" alt="">
                </div>

                <div class="container">
                    <ol class="track">
                        <li class="slide current">
                            <img src="../Assets/Carousel1.jpg" alt="" class="image">
                        </li>
                        <li class="slide current">
                            <img src="../Assets/Carousel2.jpg" alt="" class="image">
                        </li>
                    </ol>
                </div>

                <div class="carouselbtn right">
                    <img class="btnImg" src="../Assets/Right.png" alt="">
                </div>
            </div>
        </div>
    </div>

    <div class="CenterBox">
        <div class="container1180px">
            <asp:Repeater ID="StationeryRepeater" runat="server" OnItemDataBound="StationeryRepeater_ItemDataBound" OnItemCommand="StationeryRepeater_ItemCommand1">
                <ItemTemplate>
                    <div class="card" stationeryID='<%# Eval("StationeryID") %>' onclick="redirectToStationeryDetails(this)">
                        <img src="../Assets/StationeryHome.jpg" alt="">
                        <asp:Label ID="StationeryNameLbl" CssClass="StatName" runat="server" Text='<%# Eval("StationeryName") %>'></asp:Label>
                        <asp:Label ID="StationeryPriceLbl" CssClass="StatPrice" runat="server" Text='<%# "Rp."+Eval("StationeryPrice") %>'></asp:Label>
                        <div class="cart_purchase">
                            <asp:Button ID="CartBtnUser" CssClass="cardbtn1 cartbtn" runat="server" Text="Add Cart" CommandName="AddCart" CommandArgument='<%# Eval("StationeryID") %>' />
                            <asp:Button ID="PurchaseBtnUser" CssClass="cardbtn2 purchasebtn" runat="server" Text="Purchase" CommandName="Purchase" CommandArgument='<%# Eval("StationeryID") %>' />
                            <asp:Button ID="UpdateBtnAdmin" CssClass="cardbtn1 cartbtn" runat="server" Text="Update" Visible="false" CommandName="Update" CommandArgument='<%# Eval("StationeryID") %>' />
                            <asp:Button ID="DeleteBtnAdmin" CssClass="cardbtn2 purchasebtn" runat="server" Text="Delete" Visible="false" CommandName="Delete" CommandArgument='<%# Eval("StationeryID") %>' />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

</asp:Content>
