<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OvertimeUnread.aspx.cs" Inherits="SmOffice.Views.Outputs.OvertimeUnread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="height: 40px;">
        <asp:Label ID="lblTitleOvertime" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="Overtime"></asp:Label>
        </div>
    <div style="height: 10px;"></div>
    <table align="center"; style="width: 1024px;height:300px" margin: auto; border: 5px solid white">
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblRequesterEpNm" runat="server" Text="Requester"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblRequesterEpNmC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
           <td style="width: 250px">
                <asp:Label ID="lblDpmtName" runat="server" Text="Department"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDpmtNameC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblApproverEpNm" runat="server" Text="Approver"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblApproverEpNmC" runat="server"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblPublicHolidayYN" runat="server" Text="Public Holiday"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPublicHolidayYNC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFromDateC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblToDateC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblReason" runat="server" Text="Reason"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblReasonC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
            </td>
            <td>
                <asp:Button ID="btnApprove" CssClass="button button1" runat="server" Text="Approve" OnClick="btnApprove_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReject" CssClass="button button1" runat="server" Text="Reject" OnClick="btnReject_Click"/>
            </td>
        </tr>
    </table>
    </asp:Content>
