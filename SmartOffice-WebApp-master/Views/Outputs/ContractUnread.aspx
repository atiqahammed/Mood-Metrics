<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractUnread.aspx.cs" Inherits="SmOffice.Views.Outputs.ContractUnread" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="height: 40px;">
        <asp:Label ID="lblTitleContract" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="Contract"></asp:Label>
        </div>
    <div style="height: 10px;"></div>
    <table align="center"; style="width: 1024px;height:300px" margin: auto; border: 5px solid white">
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
                <asp:Label ID="lblSignDate" runat="server" Text="Sign Date"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSignDateC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblMyPartyName" runat="server" Text="My Party"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMyPartyNameC" runat="server"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblMyPartyEpNm" runat="server" Text="My Party Employee"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMyPartyEpNmC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblOppPartyName" runat="server" Text="Opposite Party"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblOppPartyNameC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblOppPartyEpNm" runat="server" Text="Opposite Party Employee"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblOppPartyEpNmC" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblContent" runat="server" Text="Content"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblContentC" runat="server"></asp:Label>
            </td>
        </tr>
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
                <asp:Label ID="lblApproverEpNm" runat="server" Text="Approver"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblApproverEpNmC" runat="server"></asp:Label>
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
