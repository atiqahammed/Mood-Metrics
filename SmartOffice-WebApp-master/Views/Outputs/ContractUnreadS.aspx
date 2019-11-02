<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractUnreadS.aspx.cs" Inherits="SmOffice.Views.Outputs.ContractUnreadS" %>

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
                <asp:Label ID="lblDpmtNameS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
           <td style="width: 250px">
                <asp:Label ID="lblSignDate" runat="server" Text="Sign Date"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSignDateS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblMyPartyName" runat="server" Text="My Party"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMyPartyNameS" runat="server"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblMyPartyEpNm" runat="server" Text="My Party Employee"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblMyPartyEpNmS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblOppPartyName" runat="server" Text="Opposite Party"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblOppPartyNameS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblOppPartyEpNm" runat="server" Text="Opposite Party Employee"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblOppPartyEpNmS" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblContent" runat="server" Text="Content"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblContentS" runat="server"></asp:Label>
            </td>
        </tr>
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
                <asp:Label ID="lblApproverEpNm" runat="server" Text="Approver"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblApproverEpNmS" runat="server"></asp:Label>
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