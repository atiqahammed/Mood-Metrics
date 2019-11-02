<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Overtime.aspx.cs" Inherits="SmOffice.Inputs.Overtime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div style="height: 40px;">
        <asp:Label ID="lblTitleOverTime" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="Overtime"></asp:Label>
        </div>
    <div style="height: 10px;"></div>
    <table align="center"; style="width: 1024px;height:300px" margin: auto; border: 5px solid white">
        <tr>
            <td style="width: 250px">
                <asp:Label ID="Emp_name" runat="server" Text="Requester"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlRequesterEpNm" runat="server" DataSourceID="SqlDataSource4" DataTextField="EmpyName" DataValueField="EmpyName"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="dptnm" runat="server" Text="Department"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlDpmtName" runat="server" DataSourceID="SqlDataSource3" DataTextField="DpmtName" DataValueField="DpmtName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT [DpmtName] FROM [Department]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="Apnm" runat="server" Text="Approver"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlApproverEpNm" runat="server" DataSourceID="SqlDataSource4" DataTextField="EmpyName" DataValueField="EmpyName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT [EmpyName] FROM [Employee]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblpublicHoliday" runat="server" Text="Public Holiday"></asp:Label>
            </td>
            <td>
                <br />
                <asp:RadioButton ID="rbtnyes" runat="server" Text="Yes" />
                <asp:RadioButton ID="rbtnno" runat="server" Text="No" />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="fromlbl" runat="server" Text="from"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtOAppStartTime" runat="server"></asp:TextBox>
                <asp:LinkButton ID="OTselectfrmdtlkbtn" runat="server" OnClick="OTselectfrmdtlkbtn_Click">Select Date</asp:LinkButton></td>
            <td>
                <asp:Calendar ID="OTCalFrom" runat="server" Height="150px" Visible="False" OnSelectionChanged="OTCalFrom_SelectionChanged" OnDayRender="OTCalFrom_DayRender">
                    <DayHeaderStyle
                        BackColor="DodgerBlue" />
                    <DayStyle
                        BackColor="Crimson"
                        BorderColor="IndianRed"
                        BorderWidth="1"
                        Font-Bold="true"
                        Font-Italic="true" />
                    <NextPrevStyle
                        Font-Italic="true"
                        Font-Names="Arial CE" />
                    <SelectedDayStyle
                        BackColor="Green"
                        BorderColor="SpringGreen" />
                    <OtherMonthDayStyle BackColor="DarkRed" />
                    <TitleStyle
                        BackColor="MidnightBlue"
                        Height="36"
                        Font-Size="Large"
                        Font-Names="Courier New Baltic" />
                </asp:Calendar>
            </td>
            <td>
                <asp:Label ID="tolbl" runat="server" Text="to"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtOAppEndTime" runat="server" CssClass="auto-style3" Width="192px"></asp:TextBox>
                <asp:LinkButton ID="OTselectTodtlkbtn" runat="server" OnClick="OTselectTodtlkbtn_Click">Select Date</asp:LinkButton></td>
            <td>
                <asp:Calendar ID="OTCalTo" runat="server" Visible="False" SelectionMode="Day" OnSelectionChanged="OTCalTo_SelectionChanged" OnDayRender="OTCalTo_DayRender">
                    <DayHeaderStyle
                        BackColor="DodgerBlue" />
                    <DayStyle
                        BackColor="Crimson"
                        BorderColor="IndianRed"
                        BorderWidth="1"
                        Font-Bold="true"
                        Font-Italic="true" />
                    <NextPrevStyle
                        Font-Italic="true"
                        Font-Names="Arial CE" />
                    <SelectedDayStyle
                        BackColor="Green"
                        BorderColor="SpringGreen" />
                    <OtherMonthDayStyle BackColor="DarkRed" />
                    <TitleStyle
                        BackColor="MidnightBlue"
                        Height="36"
                        Font-Size="Large"
                        Font-Names="Courier New Baltic" />
                </asp:Calendar>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblReason" runat="server" Text="Reason"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOReason" style="width:300px;height:150px" runat="server"></asp:TextBox>
        </tr>
        <tr>
            <td style="width: 250px">
                </td>
            <td>
                <asp:Button ID="subbi" runat="server" CssClass="button button1" Text="Submit" OnClick="subbi_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="rstbi" runat="server" CssClass="button button1" Text="Reset" OnClick="rstbi_Click" />
            </td>
            <td></td>
        </tr>
    </table>

</asp:Content>