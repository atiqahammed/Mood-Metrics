<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SmOffice.Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" Runat="Server">
    <div style="position: relative">
        <div style="height: 80px;">
        </div>
        <table align="center"; style="width: 400px;height: 200px" margin: auto; border: 5px solid white">
            <tr>
                <td style="width: 180px">
                    <asp:Label ID="Label1" runat="server" Text="Employee Email Address"></asp:Label></td>
                <td>                            
                    <asp:TextBox ID="txtEmpyEmail" style="width:200px" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:RequiredFieldValidator ID="rfvEmpyEmail" runat="server" ErrorMessage="Employee email should not be null!" forecolor="Red" font-size= "8" ControlToValidate="txtEmpyEmail"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 180px">
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtEmpyPwd" style="width:200px" runat="server" TextMode="Password"></asp:TextBox></td>
            <tr>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator display="Dynamic" ID="revEmpyPwd" runat="server" ErrorMessage="Password must be 8-10 characters long with at least one numeric, one uppercase alphabet, one lowercase alphabet, and one special character." forecolor="Red" font-size= "8" ValidationExpression= "^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[~!@#$%^&*_]).{8,10}$" ControlToValidate="txtEmpyPwd"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:RequiredFieldValidator ID="rfvEmpyPwd" runat="server" ErrorMessage="Password should not be null!" forecolor="Red" font-size= "8" ControlToValidate="txtEmpyPwd"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 180px">
                    <asp:HyperLink ID="HyperLink1" runat="server" style ="text-decoration: underline" NavigateUrl="~/Views/ChangePassword.aspx">Change Password</asp:HyperLink></td>
                <td class ="center">
                    <asp:Button ID="btnLogin" runat="server" CssClass="button button2" Text="Login" OnClick="btnLogin_Click"/></td>
            </tr>
            <tr style="width: 180px">
                <td></td>
                <td class ="right">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect User Credentials!" ForeColor="Red" font-size= "8"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
