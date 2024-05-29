<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="RAiso.View.TransactionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label Class="center-content" ID="Try" runat="server" Text="THIS IS TRANSACTION DETAILS"></asp:Label>
        <div class="center-content">
            <asp:Repeater ID="Repeater" runat="server" OnItemCommand="RepeaterCard_Command">
                <ItemTemplate>
                    <div class="card-container">
                        <div class="card-info">
                            <asp:Label CssClass="TransId" ID="lblTransactionId" runat="server" Text='<%# "Transaction ID = " + Eval("TransactionID") %>'></asp:Label>
                            <asp:Label CssClass="StatId" ID="lblStatId" runat="server" Text='<%# "Stationery ID = " + Eval("StationeryID") %>'></asp:Label>
                            <asp:Label CssClass="Quantity" ID="lblQty" runat="server" Text='<%# "Qty = " + Eval("Quantity") %>'></asp:Label>
                        </div>
                        <div class="Button">
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div>
            </div>
        </div>
        <asp:Label ID="lblAlert" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>
