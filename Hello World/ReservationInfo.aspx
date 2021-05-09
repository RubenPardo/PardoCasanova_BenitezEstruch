<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReservationInfo.aspx.cs" Inherits="WebPage.CreateReservation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form action="formReservation" method="post">
        <table>
            <tr>
                <td>Reservation Name: </td>
                <td><input type="text" id="txtName" runat="server"/></td>
            </tr>

             <tr>
                <td>Arrival Date: </td>
                <td><input type="date" id="txtDate" runat="server" /></td>
            </tr>

             <tr>
                <td>Nights: </td>
                <td><input type="number" id="txtNights" runat="server"/></td>
            </tr>
            
            <tr>
                <td>Room: </td>
                <td>
                    <select runat='server' id="slctRoom" name="Select Room">
                    </select>

                </td>
            </tr>

             <tr>
                <td>Client: </td>
                <td>
                    <select runat='server' id="slctUser" name="Select Client">
                    </select>

                </td>
            </tr>
            
            <tr>
                <td colspan="2" id="btnForms" runat="server">
                    <asp:Button ID="btnForm" runat="server" Text="Make Reservation" autoPostBack="false" OnClick="onSumbitForm" />

                </td>
            </tr>
        </table>
    </form>

    <asp:Label ID="lblRes" runat="server" Text="Label"></asp:Label>

</asp:Content>
