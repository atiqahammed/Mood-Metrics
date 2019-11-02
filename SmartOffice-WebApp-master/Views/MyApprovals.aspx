<%@ Page Language="C#" MasterPageFile="~/SmartOffice.Master" AutoEventWireup="true" CodeBehind="MyApprovals.aspx.cs" Inherits="SmOffice.Views.MyApprovals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 111px;
        }
        .auto-style3 {
            margin-left: 1em;
            width: 111px;
        }
        .auto-style4 {
            width: 263px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="height: 40px;">
        <asp:Label ID="lblTitleMyApproval" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="My Approvals"></asp:Label>
        </div>
    <table align="center"; style="width: 1024px;height: 300px" margin: auto; border: 5px solid white">
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style4"></td>
            <td class="auto-style4" style="text-align:center">
                <asp:Label ID="lblRead" runat="server" style="color: #069;font-weight: bold" Text="Read"></asp:Label></td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblUnread" runat="server" style="color: #069;font-weight: bold" Text="Unread"></asp:Label></td>               
        </tr>
        <tr>
            <td class ="auto-style3">
                <asp:Image ID="imgOvertime" ImageURL="~/Images/Overtime.png" runat="server" /> 
            </td>
            <td class="auto-style4">
            <asp:Label ID="lblOvertime" runat="server" style="color: #069;font-weight: bold" Text="Overtime"></asp:Label></td>
            <td class="auto-style4">
                <asp:Repeater ID="RepeaterOvertimeRead" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/OvertimeRead?OAppId=<%# Eval("OAppId") %>.aspx' target="_blank"><%#Eval("OAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
            <td>
                <asp:Repeater ID="RepeaterOvertimeUnread" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/OvertimeUnreadS?OAppId=<%# Eval("OAppId") %>.aspx'><%#Eval("OAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>            
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Image ID="imgReport" ImageURL="~/Images/Report.png" runat="server" />
            </td>
            <td class="auto-style4">
            <asp:Label ID="lblReport" runat="server" style="color: #069;font-weight: bold" Text="Report"></asp:Label></td>
            <td class="auto-style4">
                <asp:Repeater ID="RepeaterReportRead" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/ReportRead?LogId=<%# Eval("LogId") %>.aspx' target="_blank"><%#Eval("LogTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
            <td>
                <asp:Repeater ID="RepeaterReportUnread" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/ReportUnreadS?LogId=<%# Eval("LogId") %>.aspx'><%#Eval("LogTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>            
        </tr>
        <tr>
            <td class ="auto-style3">
                <asp:Image ID="imgBorrowItems" ImageURL="~/Images/BorrowItems.png" runat="server" />
            </td>
            <td class="auto-style4">
            <asp:Label ID="lblBorrowItems" runat="server" style="color: #069;font-weight: bold" Text="Borrow Items"></asp:Label></td>
            <td class="auto-style4">
                <asp:Repeater ID="RepeaterBorrowItemsRead" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/BorrowItemsRead?BAppId=<%# Eval("BAppId") %>.aspx' target="_blank"><%#Eval("BAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
            <td>
                <asp:Repeater ID="RepeaterBorrowItemsUnread" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/BorrowItemsUnreadS?BAppId=<%# Eval("BAppId") %>.aspx'><%#Eval("BAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>          
        </tr>       
        <tr>
            <td class ="auto-style3">
                <asp:Image ID="imgContract" ImageURL="~/Images/Contract.png" runat="server" />
            </td>
            <td class="auto-style4">
            <asp:Label ID="lblContract" runat="server" style="color: #069;font-weight: bold" Text="Contract"></asp:Label></td>
            <td class="auto-style4">
                <asp:Repeater ID="RepeaterContractRead" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/ContractRead?CAppId=<%# Eval("CAppId") %>.aspx' target="_blank"><%#Eval("CAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
            <td>
                <asp:Repeater ID="RepeaterContractUnread" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/ContractUnreadS?CAppId=<%# Eval("CAppId") %>.aspx'><%#Eval("CAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>            
        </tr>
        <tr>
            <td class ="auto-style3">
                <asp:Image ID="imgPaidTimeOff" ImageURL="~/Images/PaidTimeOff.png" runat="server" />
            </td>
            <td class="auto-style4">
            <asp:Label ID="lblPaidTimeOff" runat="server" style="color: #069;font-weight: bold" Text="Paid Time Off"></asp:Label></td>
            <td class="auto-style4">
                <asp:Repeater ID="RepeaterPaidTimeOffRead" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/PaidTimeOffRead?LAppId=<%# Eval("LAppId") %>.aspx' target="_blank"><%#Eval("LAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
            <td>
                <asp:Repeater ID="RepeaterPaidTimeOffUnread" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/PaidTimeOffUnreadS?LAppId=<%# Eval("LAppId") %>.aspx'><%#Eval("LAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>            
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Image ID="imgReimbursement" ImageURL="~/Images/Reimbursement.png" runat="server" />
            </td>
            <td class="auto-style4">
            <asp:Label ID="lblReimbursement" runat="server" style="color: #069;font-weight: bold" Text="Reimbursement"></asp:Label></td>
            <td class="auto-style4">
                <asp:Repeater ID="RepeaterReimbursementRead" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/ReimbursementRead?RAppId=<%# Eval("RAppId") %>.aspx' target="_blank"><%#Eval("RAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
            <td>
                <asp:Repeater ID="RepeaterReimbursementUnread" runat="server">
                    <HeaderTemplate>
                    <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                    <li><a href='Outputs/ReimbursementUnreadS?RAppId=<%# Eval("RAppId") %>.aspx'><%#Eval("RAppTime") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                    </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>            
        </tr>
    </table>
    </asp:Content>
