<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="LocationScoutApp.Member" %>

<%@ Register TagPrefix="header" TagName="PageHeaderControl" Src="~/PageHeaderControl.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Location Scout</title>
</head>
<body>
    <form id="form1" runat="server">
        <header:PageHeaderControl runat="server" />
        <p>
            Welcome,
            <asp:Label ID="LabelUsername" runat="server" Font-Bold="True" Text="Username"></asp:Label>
            <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonLogout" runat="server" Height="23px" OnClick="ButtonLogout_Click" Text="Logout" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonHome" runat="server" Height="22px" OnClick="ButtonHome_Click" Text="Home" />
                &nbsp;&nbsp;
            <br />
                <br />
                Services Offered to Members of Location Scout:- </strong>
        </p>
        <p>
            Enter Zipcode of a location (5 digits)* :
            <asp:TextBox ID="TextBoxZipcode" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelErrorZipcode" runat="server" ForeColor="Red" Text="LabelErrorZip" Visible="False"></asp:Label>
        </p>
        <p>
            1. Nearest Store Service (Finds the address of the store closest to the location entered above)<br />
            <br />
            &nbsp;Store Name* :
        <asp:TextBox ID="TextBoxStoreName" runat="server" Width="171px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Label ID="LabelErrorStoreName" runat="server" ForeColor="Red" Text="LabelErrorStoreName" Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            &nbsp;Nearest Store Address :
        <asp:Label ID="LabelStoreAddress" runat="server" Font-Bold="True" Text="Nearest Store Address" Visible="False"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Button ID="ButtonStoreAddress" runat="server" Text="Get Store Address" Width="152px" OnClick="ButtonStoreAddress_Click" />
        </p>
        <p>
            2. Weather Data Service (Returns min-max temperatur prediction for the upcoming week)<br />
            <br />
&nbsp;<asp:Button ID="ButtonWeatherData" runat="server" OnClick="ButtonWeatherData_Click" Text="Get Weather Data" />
            <br />
            <br />
&nbsp;<asp:ListBox ID="ListBoxWeatherData" runat="server" Height="199px" Width="571px"></asp:ListBox>
            &nbsp;
            <br />
        </p>
        <p>
            3. Earth Quake Index for the given location (Index - low, med, high) :
            <asp:Label ID="LabelQuakeIndex" runat="server" Font-Bold="True" Text="Quake Index" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonQuakeIndex" runat="server" OnClick="ButtonQuakeIndex_Click" Text="Get Quake Index" Width="161px" />
        </p>
        <p>
            4. News Focus Service (Finds the news articles URL&#39;s of the provided topic)<br />
            <br />
            &nbsp;Enter Topic :
            <asp:TextBox ID="TextBoxNewsTopic" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonNewsFocus" runat="server" Text="Get News" Width="155px" OnClick="ButtonNewsFocus_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="LabelNewsError" runat="server" ForeColor="Red" Text="LabelNewsError" Visible="False"></asp:Label>
            <br />
            <br />
            &nbsp;News URL&#39;s are listed below :-<br />
            <br />
            <asp:ListBox ID="ListBoxNewsData" runat="server" Height="153px" Width="577px"></asp:ListBox>
        </p>
        <p>
            5. Solar Energy Index for the given location (Index - low, med, high) :
            <asp:Label ID="LabelSolarIndex" runat="server" Font-Bold="True" Text="Solar Index" Visible="False"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Button ID="ButtonSolarIndex" runat="server" Text="Get Solar Index" Width="161px" OnClick="ButtonSolarIndex_Click" />
            <br />
        </p>
        <p>
            6.
            Wind Energy Index for the given location (Index - low, med, high) :
            <asp:Label ID="LabelWindIndex" runat="server" Font-Bold="True" Text="Wind Index" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonWindIndex" runat="server" Text="Get Wind Index" Width="164px" OnClick="ButtonWindIndex_Click" />
        </p>

    </form>

</body>
</html>
