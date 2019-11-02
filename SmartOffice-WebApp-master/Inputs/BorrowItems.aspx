<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BorrowItems.aspx.cs" Inherits="SmOffice.Inputs.BorrowItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <div style="height: 40px;">
        <asp:Label ID="lblTitleBorrowItems" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="Borrow Items"></asp:Label>
        </div>
    <div style="height: 10px;"></div>
    <table align="center"; style="width: 1024px;height:300px" margin: auto; border: 5px solid white">      
        <tr>
            <td style="width: 250px">
                <asp:Label ID="Emp_name" runat="server" Text="Requester"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlRequesterEpNm" runat="server" DataSourceID="SqlDataSource2" DataTextField="EmpyName" DataValueField="EmpyName"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="dptnm" runat="server" Text="Department"></asp:Label></td>
            <td>        
                <asp:DropDownList ID="ddlDpmtName" runat="server" DataSourceID="SqlDataSource1" DataTextField="DpmtName" DataValueField="DpmtName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT [DpmtName] FROM [Department]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="Apnm" runat="server" Text="Approver"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlApproverEpNm" runat="server" DataSourceID="SqlDataSource2" DataTextField="EmpyName" DataValueField="EmpyName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT [EmpyName] FROM [Employee]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="itemName" runat="server" Text="Item"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlBAppItem" runat="server" DataSourceID="SqlDataSource3" DataTextField="ItemName" DataValueField="ItemName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT [ItemName] FROM [BorrowItemList]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="fromlbl" runat="server" Text="From"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtBAppStartDate" runat="server"></asp:TextBox>
                <asp:LinkButton ID="frmdtlkbtn" runat="server" OnClick="frmdtlkbtn_Click">Select Date</asp:LinkButton></td>
            <td>
                <asp:Calendar ID="CalFrom" runat="server" Height="150px" Visible="False" SelectionMode="Day" OnSelectionChanged="CalFrom_SelectionChanged" OnDayRender="CalFrom_DayRender" >
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
                <asp:Label ID="tolbl" runat="server" Text="To"></asp:Label></td></td>
            <td>
                <asp:TextBox ID="txtBAppEndDate" runat="server" CssClass="auto-style3" Width="192px"></asp:TextBox><asp:LinkButton ID="slctdttolkbtn" runat="server" OnClick="slctdttolkbtn_Click">Select Date</asp:LinkButton></td>
            <td>
                <asp:Calendar ID="CalTo" runat="server" Visible="False" SelectionMode="Day" OnSelectionChanged="calTo_SelectionChanged" OnDayRender="CalTo_DayRender">
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
                <asp:Label ID="detailslbl" runat="server" Text="Details"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtBDetails" style="width:200px;height:80px" runat="server"></asp:TextBox>
        </tr>        
        <tr>
            <td style="width: 250px"></td>                
            <td>
                <asp:Button ID="subbi" runat="server" CssClass="button button1" Text="Submit" OnClick="subbi_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="rstbi" runat="server" CssClass="button button1" Text="Reset" OnClick="rstbi_Click" />
            </td>
            <td></td>
        </tr>
    </table>

</asp:Content>