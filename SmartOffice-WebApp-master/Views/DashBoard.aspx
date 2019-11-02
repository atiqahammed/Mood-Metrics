<%@ Page Language="C#" MasterPageFile="~/SmartOffice.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="SmOffice.Views.DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="height: 30px;">
        </div>
    <table align="center"; style="width: 500px;height: 300px" margin: auto; border: 5px solid white">
        <tr>
            <td class ="center">
                <asp:Image ID="imgOvertime" ImageURL="~/Images/Overtime.png" runat="server" />
            </td>
            <td class ="center">
                <asp:Image ID="imgReport" ImageURL="~/Images/Report.png" runat="server" />
            </td>
            <td class ="center">
                <asp:Image ID="imgBorrowItems" ImageURL="~/Images/BorrowItems.png" runat="server" />
            </td>
        </tr>
        <tr>
            <td class ="center">
                <asp:Button ID="btnOvertime" CssClass="button button4" runat="server" Text="Overtime" OnClick="btnOvertime_Click"/>
            </td>
            <td class ="center">
                <asp:Button ID="btnReport" CssClass="button button4" runat="server" Text="Report" OnClick="btnReport_Click"/>
            </td>
            <td class ="center">
                <asp:Button ID="btnBorrowItems" CssClass="button button4" runat="server" Text="Borrow Items" OnClick="btnBorrowItems_Click"/>
            </td>
        </tr>
        <tr>
            <td class ="center">
                <asp:Image ID="imgContract" ImageURL="~/Images/Contract.png" runat="server" />
            </td>
            <td class ="center">
                <asp:Image ID="imgPaidTimeOff" ImageURL="~/Images/PaidTimeOff.png" runat="server" />
            </td>
            <td class ="center">
                <asp:Image ID="imgReimbursement" ImageURL="~/Images/Reimbursement.png" runat="server" />
            </td>
        </tr>
        <tr>
            <td class ="center">
                <asp:Button ID="btnContract" CssClass="button button4" runat="server" Text="Contract" OnClick="btnContract_Click"/>
            </td>
            <td class ="center">
                <asp:Button ID="btnPaidTimeOff" CssClass="button button4" runat="server" Text="Paid Time Off" OnClick="btnPaidTimeOff_Click"/>
            </td>
            <td class ="center">
                <asp:Button ID="btnReimbursement" CssClass="button button4" runat="server" Text="Reimbursement" OnClick="btnReimbursement_Click"/>
            </td>
        </tr>
    </table>
    </asp:Content>