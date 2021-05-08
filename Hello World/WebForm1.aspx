<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Hello_World.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			
			<asp:TextBox runat="server" ID="txtResult1" />
			<asp:Button ID="btnOk" Text="Button" runat="server" OnClick="btnOk_Click"/>
			<span ID="spResult1" runat="server"></span>
            <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />
        </div>
    </form>
</body>
</html>
