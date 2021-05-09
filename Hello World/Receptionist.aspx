<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Receptionist.aspx.cs" Inherits="WebPage.Receptionist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>RECEPTIONIST PAGE</h2>
    <asp:Button ID="btnReservation" runat="server" Text="Make Reservation" OnClick="btnReservation_Click"/>
    <asp:label ID="pruebaRcp" runat="server" Text="Label">PRUEBA</asp:label>
</asp:Content>
