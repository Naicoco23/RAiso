<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateCart.aspx.cs" Inherits="RAiso.View.UpdateCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/UpdateCart.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="parentContainer">
     <div class="whiteBG">
         <div class="LeftContainer">
             <div class="CenterContainer">
                 <asp:Label ID="AddStatLbl" CssClass="AddStatLbls" runat="server" Text="Update Cart"></asp:Label>
             </div>
             <asp:Label ID="lblStationery" CssClass="NormalText" runat="server" Text=""></asp:Label> <br />
             <asp:Label ID="lblPrice" CssClass="NormalText" runat="server" Text=""></asp:Label> <br />
             <asp:Label ID="lblQuantity" CssClass="NormalText" runat="server" Text="Quantity"></asp:Label> <br />
             <asp:TextBox ID="txtQty" CssClass="TextBoxes" runat="server" placeholder="Quantity" ></asp:TextBox> <br />
             <asp:Button ID="updateCartbtn" CssClass="AddStat" runat="server" Text="Update" OnClick="updateCartbtn_Click"/> <br />
             <asp:Label ID="Error" CssClass="NormalText" runat="server" Text="Error" Visible="false"></asp:Label> <br />
         </div>
     </div>
 </div>
</asp:Content>
