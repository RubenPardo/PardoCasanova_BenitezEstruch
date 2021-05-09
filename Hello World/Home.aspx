<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebPage.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to the hotel</h2>
    <span>This is the best hotel in the world! (Description about the hotel)</span>
    <p></p>
    <asp:Button ID="CTA_button" runat="server" Text="Reserve" OnClick="CTA_button_Click" />
</asp:Content>
