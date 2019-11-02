<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="LocationScoutApp.StaffLogin" %>

<%@ Register TagPrefix="header" TagName="PageHeaderControl" Src="~/PageHeaderControl.ascx" %>
<%@ Register TagPrefix="user" TagName="LoginControl" Src="~/LoginControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Location Scout</title>
</head>
<body>
    <header:PageHeaderControl runat="server" />
    <h3>Staff Login</h3>
    <hr />
    <form id="form1" runat="server" visible="True">

        <user:LoginControl ID="loginControl" BackColor="#ccccff" runat="server" />

        &nbsp;&nbsp;<asp:Label ID="LabelLoginError" runat="server" ForeColor="Red" Text="LabelLoginError" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:CheckBox ID="CheckBoxSaveUsername" runat="server" Text="Save Username" />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonLogin" runat="server" Text="Log In" OnClick="ButtonLogin_Click" Width="104px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonHome" runat="server" OnClick="ButtonHome_Click" Text="Home" Width="99px" />
        <br />
        <br />
        &nbsp;<asp:Label ID="LabelCookie" runat="server" Text="Username saved successfully" Visible="False"></asp:Label>
        <hr />
    </form>
</body>
</html>

