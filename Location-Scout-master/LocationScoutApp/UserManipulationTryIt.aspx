<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManipulationTryIt.aspx.cs" Inherits="LocationScoutApp.UserManipulationTryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Location Scout</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 201px">
            &nbsp;Username&nbsp;:
        <asp:TextBox ID="txtUsername" runat="server" Width="274px"></asp:TextBox>
            <br />
            &nbsp;<br />
            &nbsp;Password :
        <asp:TextBox ID="txtPassword" runat="server" Width="275px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAuthenticateUser" runat="server" OnClick="btnAuthenticateUser_Click" Text="Authenticate User" Width="166px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add User Credential" Width="140px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblAuthMsg" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAddUserMsg" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
