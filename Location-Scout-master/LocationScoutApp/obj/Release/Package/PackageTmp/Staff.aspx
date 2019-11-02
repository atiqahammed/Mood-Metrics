<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="LocationScoutApp.Staff" %>

<%@ Register TagPrefix="header" TagName="PageHeaderControl" Src="~/PageHeaderControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Location Scout</title>
</head>
<body>
    <form id="form1" runat="server">
        <header:PageHeaderControl runat="server" />
        <h3>Staff Page</h3>
        <div>
            Welcome,
            <asp:Label ID="LabelUsername" runat="server" Font-Bold="True" Text="Username"></asp:Label>
            <br />
            <br />
            This is the staff page for staff to perform the necessary operations. Its construction is in Progress, thank you for your patience.<br />
            <br />
&nbsp;<asp:Button ID="HomeButton" runat="server" OnClick="HomeButton_Click" Text="Home" Width="119px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" Width="110px" />
        </div>
    </form>
</body>
</html>
