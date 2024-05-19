<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateStationery.aspx.cs" Inherits="RAiso.View.UpdateStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/UpdateStationery.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="parentContainer">
        <div class="whiteBG">
            <div class="LeftContainer">
                <div class="CenterContainer">
                    <asp:Label ID="AddStatLbl" CssClass="AddStatLbls" runat="server" Text="Update Stationery"></asp:Label>
                </div>
                <asp:Label ID="StationeryLbl" CssClass="NormalText" runat="server" Text="Stationery Name"></asp:Label> <br />
                <asp:TextBox ID="Name" CssClass="TextBoxes" runat="server" placeholder="Stationery Name"></asp:TextBox> <br />
                <asp:Label ID="PriceLbl" CssClass="NormalText" runat="server" Text="Price"></asp:Label> <br />
                <asp:TextBox ID="Price" CssClass="TextBoxes" runat="server" placeholder="Rp. Price" ></asp:TextBox> <br />
                <asp:Button ID="UpdateStationeryBtn" CssClass="AddStat" runat="server" Text="Update Stationery" OnClick="UpdateStationeryBtn_Click" /> <br />
                <asp:Label ID="Error" CssClass="NormalText" runat="server" Text="Error" Visible="false"></asp:Label> <br />
            </div>
        </div>
    </div>
</asp:Content>
