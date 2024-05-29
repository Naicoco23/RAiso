<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="RAiso.View.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label Class ="center-content" ID="Try" runat="server" Text="THIS IS TRANSACTION"></asp:Label>
    <div class="center-content">
        <asp:Repeater ID="Repeater" runat="server" OnItemCommand="RepeaterCard_Command">
            <ItemTemplate>
                <div class="card-container">
                    <div class="card-info">
                        <asp:Label CssClass="TransId" ID="lblTransactionId" runat="server" Text='<%# "Transaction ID = " + Eval("TransactionID") %>'></asp:Label>
                        <asp:Label CssClass="UserName" ID="lblUserName" runat="server" Text='<%# "User ID = " + Eval("MsUser.UserID") %>'></asp:Label>
                        <asp:Label CssClass="TransactionDate" ID="lblTransactionDate" runat="server" Text='<%# "Transaction Date = " + Eval("TransactionDate") %>'></asp:Label>
                    </div>
                    <div class="Button">
                        <asp:Button ID="BtnDetail" runat="server" CommandName="Detail" CommandArgument='<%# Eval("TransactionID") %>' Text="View Details" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div>
        </div>
            <asp:Label ID="lblAlert" runat="server" Text="" Visible="false"></asp:Label>

    </div>
</asp:Content>
