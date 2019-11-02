<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="SmOffice.Inputs.Contract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="height: 40px;">
        <asp:Label ID="lblTitleContract" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="Contract"></asp:Label>
        </div>
    <div style="height: 10px;"></div>
    <table align="center"; style="width: 1024px;height: 300px" margin: auto; border: 5px solid white">
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblDpmtName" runat="server" Text="Department"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDpmtName" runat="server" DataSourceID="SqlDataSource1" DataTextField="DpmtName" DataValueField="DpmtName"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT [DpmtName] FROM [Department]"></asp:SqlDataSource>
            </td>
            <td></td>
        </tr>
        <tr>
           <td style="width: 250px">
                <asp:Label ID="lblSignDate" runat="server" Text="Sign Date"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSignDate" runat="server"></asp:TextBox>
                <asp:LinkButton ID="frmdtlkbtn" runat="server" OnClick="frmdtlkbtn_Click">Select Date</asp:LinkButton>
            </td>
            <td>
                <asp:Calendar ID="CalSignDate" runat="server" Height="150px" Visible="False" SelectionMode="Day" OnSelectionChanged="CalSignDate_SelectionChanged" OnDayRender="CalSignDate_DayRender" >
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
                <asp:Label ID="lblMyPartyName" runat="server" Text="My Party"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMyPartyName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblMyPartyEpName" runat="server" Text="My Party Employee"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMyPartyEpNm" runat="server" DataSourceID="SqlDataSource2" DataTextField="EmpyName" DataValueField="EmpyName"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT [EmpyName] FROM [Employee]"></asp:SqlDataSource>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblOppPartyName" runat="server" Text="Opposite Party"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOppPartyName" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblOppPartyEpNm" runat="server" Text="Opposite Party Employee"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOppPartyEpNm" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblContent" runat="server" Text="Content"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtContent" style="width: 240px;height:150px" runat="server"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblRequesterEpNm" runat="server" Text="Requester"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlRequesterEpNm" runat="server" DataSourceID="SqlDataSource2" DataTextField="EmpyName" DataValueField="EmpyName"></asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblApproverEpNm" runat="server" Text="Approver"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlApproverEpNm" runat="server" DataSourceID="SqlDataSource2" DataTextField="EmpyName" DataValueField="EmpyName">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
         <tr>
            <td style="width: 250px">
            </td>
            <td>
                <asp:Button ID="btnSubmit" CssClass="button button1" runat="server" Text="Submit" OnClick="subbi_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="rstbi" runat="server" CssClass="button button1" Text="Reset" OnClick="rstbi_Click" />
            </td>
             <td></td>
        </tr>
    </table>
    </asp:Content>
