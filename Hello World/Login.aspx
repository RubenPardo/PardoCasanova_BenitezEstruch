<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebPage.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section>
        <h2>Login Page</h2>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <input id="txtUserName" type="text" runat="server">
            <br />
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <input id="txtUserPass" type="password" runat="server">
            
        </div>
         <asp:Label ID="Warninglogin" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
    </section>
    
</asp:Content>
