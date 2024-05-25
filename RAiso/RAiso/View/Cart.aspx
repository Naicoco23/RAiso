<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="RAiso.View.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/Cart.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center-content">

        <asp:Repeater ID="reptCart" runat="server" OnItemCommand="reptCart_ItemCommand">
            <ItemTemplate>
                <div class="card-container">
                    <img src="../Assets/StationeryHome.jpg" alt="Stationery Image">

                    <div class="card-info">
                        <asp:Label CssClass="statName" ID="lblStationeryName" runat="server" Text='<%# Eval("MsStationery.StationeryName") %>'></asp:Label>
                        <asp:Label CssClass="statPrice" ID="lblStationeryPrice" runat="server" Text='<%# "Rp. " + Eval("MsStationery.StationeryPrice") %>'></asp:Label>  
                        
                        <asp:Label CssClass="statQty" ID="lblStationeryQty" runat="server" Text='<%#"Quantity : " + Eval("Quantity") %>'></asp:Label>

                        <div class="action-button">
                            <asp:Button ID="btnRemove" CssClass="btn-remove" runat="server" Text="Remove" CommandName="Remove" CommandArgument='<%# Eval("UserID") + "|" + Eval("StationeryID") %>' />
                            <asp:Button ID="btnUpdate" CssClass="btn-update" runat="server" Text="Update" CommandName="Update" CommandArgument='<%# Eval("UserID") + "|" + Eval("StationeryID") %>' />
                        
                        </div>
                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>
        
        <div>
            <asp:Button ID="btnPurchase" runat="server" Text="Checkout" Visible="false" CssClass="btn-checkout" OnClick="btnPurchase_Click"/>

        </div>
        <asp:Label ID="lblAlert" runat="server" Text="" Visible="false"></asp:Label>

    </div>
</asp:Content>
