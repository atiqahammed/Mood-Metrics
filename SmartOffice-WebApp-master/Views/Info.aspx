<%@ Page Language="C#" MasterPageFile="~/SmartOffice.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="SmOffice.Views.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="height: 30px;">
        </div>
    <table align="center"; style="width: 500px;height: 300px" margin: auto; border: 5px solid white">
        <tr>
            <td class ="center">
            </td>
            <td class ="center">
                <asp:Image ID="imgReport" ImageURL="~/Images/Success.png" runat="server" />
            </td>
            <td class ="center">
            </td>
        </tr>
        <tr>
            <td class ="center">
            </td>
            <td class ="center">
                <asp:Label ID="lblSuccess" runat="server" Text="Submitted successfully!" style="color:#069;font-size:28px;font-weight:bold"></asp:Label>
            </td>
            <td class ="center">
            </td>
        </tr>
    </table>
    </asp:Content>
