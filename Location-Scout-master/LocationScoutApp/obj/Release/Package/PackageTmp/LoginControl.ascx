<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs" Inherits="LocationScoutApp.LoginControl" %>

<style type="text/css">
    .auto-style1 {
        width: 302px;
    }

    .auto-style2 {
        width: 94px;
    }
</style>
<table id="LoginTable" cellpadding="10" runat="server" style="width: 496px">
    <tr>
        <td class="auto-style2">User Name:</td>
        <td class="auto-style1">
            <asp:TextBox ID="MyUserName" runat="server" Width="246px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Password:</td>
        <td class="auto-style1">
            <asp:TextBox ID="MyPassword" TextMode="password" runat="server" Width="245px" />
        </td>
    </tr>

</table>

<script language="C#" runat="server">
    public string BackColor
    {
        get { return LoginTable.BgColor; }
        set { LoginTable.BgColor = value; }
    }
    public string UserName
    {
        get { return MyUserName.Text; }
        set { MyUserName.Text = value; }
    }
    public string Password
    {
        get { return MyPassword.Text; }
        set { MyPassword.Text = value; }
    }
</script>
