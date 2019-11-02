<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reimbursement.aspx.cs" Inherits="SmOffice.Inputs.Reimbursement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div style="height: 40px;">
        <asp:Label ID="lblTitleReimbersement" runat="server" style="color: #069;font-size:28px;font-weight:bold" Text="Reimbersement"></asp:Label>
        </div>
    <div style="height: 10px;"></div>
    <table align="center"; style="width: 1024px;height:300px" margin: auto; border: 5px solid white">
        <tr>
            <td style="width: 250px">
                <asp:Label ID="Emp_name" runat="server" Text="Requester"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlRequesterEpNm" runat="server" DataSourceID="SqlDataSource2" DataTextField="EmpyName" DataValueField="EmpyName"></asp:DropDownList> 
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="dptnm" runat="server" Text="Department"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlDpmtName" runat="server" DataSourceID="SqlDataSource1" DataTextField="DpmtName" DataValueField="DpmtName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT [DpmtName] FROM [Department]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="Apnm" runat="server" Text="Approver"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlApproverEpNm" runat="server" DataSourceID="SqlDataSource2" DataTextField="EmpyName" DataValueField="EmpyName">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblRAppAmount" runat="server" Text="Amount (in $)"></asp:Label>
            </td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:SmartOffice_ConnectionString %>" SelectCommand="SELECT [EmpyName] FROM [Employee]"></asp:SqlDataSource>
                <br />
                <asp:TextBox ID="txtRAppAmount" runat="server"></asp:TextBox>
                <br />
            </td>
        <tr>
            <td style="width: 250px">
                <asp:Label ID="lblRADetails" runat="server" Text="Details"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtRExpDetails" style="width:300px;height:150px" runat="server"></asp:TextBox>
        </tr>
        <tr>
            <td style="width: 250px"></td>
            <td>
                <asp:Button ID="subbi" runat="server" CssClass="button button1" Text="Submit" OnClick="subbi_Click1"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="rstbi" runat="server" CssClass="button button1" Text="Reset" OnClick="rstbi_Click" />
            </td>
            <td></td>
        </tr>
    </table>

</asp:Content>
