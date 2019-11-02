<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="LocationScoutApp.AdminLogin" %>

<%@ Register TagPrefix="user" TagName="LoginControl" Src="~/LoginControl.ascx" %>
<%@ Register TagPrefix="header" TagName="PageHeaderControl" Src="~/PageHeaderControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Location Scout</title>
</head>
<body>
    <header:PageHeaderControl runat="server" />
    <h3>Admin Login&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h3>
    <hr />
    <form id="form1" runat="server">
        <user:LoginControl ID="loginControl" BackColor="#ccccff" runat="server" />
        &nbsp;&nbsp; &nbsp;<asp:Label ID="LabelLoginError" runat="server" ForeColor="Red" Text="LabelLoginError" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        &nbsp;
        <asp:Button ID="ButtonLogin" runat="server" Text="Log In" OnClick="ButtonLogin_Click" Width="104px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonHome" runat="server" OnClick="ButtonHome_Click" Text="Home" Width="85px" />
        <br />
        &nbsp;<hr />
    </form>
</body>
</html>
