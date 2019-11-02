<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportUnread.aspx.cs" Inherits="SmOffice.Views.Outputs.ReportUnread" %>

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
                <asp:Label ID="lblLogTypeC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
           <td style="width: 250px">
                <asp:Label ID="lblComplete" runat="server" Text="Complete"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCompleteC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblIncomplete" runat="server" Text="Incomplete"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblIncompleteC" runat="server"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblPending" runat="server" Text="Pending"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPendingC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblNextPlan" runat="server" Text="Next Plan"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNextPlanC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblNote" runat="server" Text="Note"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblNoteC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblReporterEpNm" runat="server" Text="Reporter"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblReporterEpNmC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblRecipientEpNm" runat="server" Text="Recipient"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblRecipientEpNmC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblComments" runat="server" Text="Comments"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtComments" style="width:600px;height:150px" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblReadStatus" runat="server" Text="Mark as read"></asp:Label>
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
            </td>
            <td>
                <asp:Button ID="btnSubmit" CssClass="button button1" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
            </td>
        </tr>
    </table>
    </asp:Content>

