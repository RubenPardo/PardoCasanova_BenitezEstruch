<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebPage.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="mainContent">
        <h2>Welcome to the hotel</h2>
    <br />
    <p>This is the best hotel in the world! (Description about the hotel)
        Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,
        when an unknown printer took a galley of type and scrambled it to make a type specimen book.
    </p>
    <br />

    <asp:Button ID="CTA_button" runat="server" Text="Reserve" OnClick="CTA_button_Click" />
    </div>
   
</asp:Content>
