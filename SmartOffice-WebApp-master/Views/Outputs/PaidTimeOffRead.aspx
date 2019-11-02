<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaidTimeOffRead.aspx.cs" Inherits="SmOffice.Views.Outputs.PaidTimeOffRead" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="height: 40px;">
        <asp:Label ID="lblTitlePaidTimeOff" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="Paid Time Off"></asp:Label>
        </div>
    <div style="height: 10px;"></div>
    <table align="center"; style="width: 1024px;height:300px" margin: auto; border: 5px solid white">
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblRequesterEpNm" runat="server" Text="Requester"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblRequesterEpNmS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
           <td style="width: 250px">
                <asp:Label ID="lblDpmtName" runat="server" Text="Department"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDpmtNameS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblApproverEpNm" runat="server" Text="Approver"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblApproverEpNmS" runat="server"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblLeaveType" runat="server" Text="Leave Type"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblLeaveTypeS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblFromDateS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblToDateS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblDestination" runat="server" Text="Destination"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDestinationS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblReason" runat="server" Text="Reason"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblReasonS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblDecisionStatus" runat="server" Text="Decision Status"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDecisionStatusS" runat="server" style="color: #990000;font-size:28px;font-weight:bold"></asp:Label>
            </td>
        </tr>
    </table>
    </asp:Content>