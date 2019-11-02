<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LocationScoutApp.Default" %>

<%@ Register TagPrefix="header" TagName="PageHeaderControl" Src="~/PageHeaderControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Location Scout</title>
    <style type="text/css">
        
        .auto-style2 {
            font-size: large;
        }
    </style>
</head>
<body>
    <div style="background-color: #FFCC66">
        <h2 style="text-align: center">Location Scout</h2>
    </div>
    <form id="form1" runat="server">
        <p>
            <span id="docs-internal-guid-6d4ecdb8-1c88-af28-1bb9-6bc7b9ed3109" class="auto-style2" style="font-family: 'Times New Roman'; color: #000000; background-color: transparent; font-weight: 400; font-style: normal; font-variant: normal; text-decoration: none; vertical-align: baseline;"><strong>This web application offers location based services that are listed below:-</strong></span>
        </p>
        <asp:BulletedList ID="BulletedList1" runat="server">
            <asp:ListItem>Solar Intensity</asp:ListItem>
            <asp:ListItem>Wind Intensity</asp:ListItem>
            <asp:ListItem>Nearest Store</asp:ListItem>
            <asp:ListItem>Earthquake Index</asp:ListItem>
            <asp:ListItem>News Focus</asp:ListItem>
            <asp:ListItem>Weather Data</asp:ListItem>
        </asp:BulletedList>

        <asp:Button ID="ButtonMemLogin" runat="server" Text="Member Login" Width="136px" OnClick="ButtonMemLogin_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonMemPage" runat="server" Text="Member Page" Width="152px" OnClick="ButtonMemPage_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonMemRegister" runat="server" Text="Member Registeration" Width="187px" OnClick="ButtonMemRegister_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonStaffLogin" runat="server" Text="Staff Login" Width="134px" OnClick="ButtonStaffLogin_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonStaffPage" runat="server" Text="Staff Page" Width="151px" OnClick="ButtonStaffPage_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonAdminLogin" runat="server" Text="Admin Login" Width="149px" OnClick="ButtonAdminLogin_Click" />
        <br />
        <br />
        &nbsp;Session Count :
        <asp:Label ID="LabelSessionCount" runat="server" Font-Bold="True" Text="globalSessionCount"></asp:Label>
    </form>
</body>
</html>
