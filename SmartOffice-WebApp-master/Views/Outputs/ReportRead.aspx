<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportRead.aspx.cs" Inherits="SmOffice.Views.Outputs.ReportRead" %>

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
                <asp:Label ID="lblLogTypeS" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
           <td style="width: 250px">
                <asp:Label ID="lblComplete" runat="server" Text="Complete"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCompleteS" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblIncomplete" runat="server" Text="Incomplete"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblIncompleteS" runat="server" Text=""></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblPending" runat="server" Text="Pending"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPendingS" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblNextPlan" runat="server" Text="Next Plan"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNextPlanS" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblNote" runat="server" Text="Note"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNoteS" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblReporterEpNm" runat="server" Text="Reporter"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblReporterEpNmS" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblRecipientEpNm" runat="server" Text="Recipient"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblRecipientEpNmS" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblComments" runat="server" Text="Comments"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCommentsS" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </asp:Content>

