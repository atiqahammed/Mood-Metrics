<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="SmOffice.Inputs.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="height: 40px;">
        <asp:Label ID="lblTitleReport" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="Report"></asp:Label>
        </div>
    <div style="height: 10px;"></div>
    <table align="center"; style="width: 1024px;height:300px" margin: auto; border: 5px solid white">
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblLogType" runat="server" Text="Log Type"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLogType" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
           <td style="width: 250px">
                <asp:Label ID="lblComplete" runat="server" Text="Complete"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtComplete" style="width:600px;height:150px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblIncomplete" runat="server" Text="Incomplete"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtIncomplete" style="width:600px;height:150px" runat="server"></asp:TextBox>
            </td>
        </tr>       
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblPending" runat="server" Text="Pending"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPending" style="width:600px;height:150px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblNextPlan" runat="server" Text="Next Plan"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNextPlan" style="width:600px;height:150px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblNote" runat="server" Text="Note"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNote" style="width:600px;height:150px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblReporterEpNm" runat="server" Text="Reporter"></asp:Label>
            </td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>
                <asp:DropDownList ID="ddlReporterEpNm" runat="server" DataSourceID="SqlDataSource" DataTextField="EmpyName" DataValueField="EmpyName"></asp:DropDownList>                
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblRecipientEpNm" runat="server" Text="Recipient"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlRecipientEpNm" runat="server" DataSourceID="SqlDataSource" DataTextField="EmpyName" DataValueField="EmpyName">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
            </td>
            <td>
                <asp:Button ID="btnSubmit" CssClass="button button1" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="rstbi" runat="server" CssClass="button button1" Text="Reset" OnClick="rstbi_Click" />
            </td>
        </tr>
    </table>
    </asp:Content>
