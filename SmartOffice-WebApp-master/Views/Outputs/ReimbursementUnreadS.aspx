<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReimbursementUnreadS.aspx.cs" Inherits="SmOffice.Views.Outputs.ReimbursementUnreadS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="height: 40px;">
        <asp:Label ID="lblTitleReimbursement" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="Reimbursement"></asp:Label>
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
                <asp:Label ID="lblAmount" runat="server" Text="Amount (in $)"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAmountC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblDetails" runat="server" Text="Details"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDetailsC" runat="server"></asp:Label>
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
