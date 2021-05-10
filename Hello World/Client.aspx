<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="WebPage.Client" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>CLIENT PAGE</h2>
    <asp:Button ID="Logout" runat="server" Text="Log Out" OnClick="Logout_Click"/>
    <asp:label ID="prueba" runat="server" Text="Label">PRUEBA</asp:label>
</asp:Content>
