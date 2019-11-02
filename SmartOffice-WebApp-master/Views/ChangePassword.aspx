<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SmOffice.Views.ChangePassword" %>

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
                <td><asp:RequiredFieldValidator ID="rfvEmpyEmail" runat="server" ErrorMessage="Employee full name should not be null!" ForeColor="Red" font-size= "8" ControlToValidate="txtEmpyEmail"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 180px">
                    <asp:Label ID="Label2" runat="server" Text="New Password"></asp:Label></td>
                <td>                            
                    <asp:TextBox ID="txtNewEmpyPwd" style="width:200px" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RegularExpressionValidator display="Dynamic" ID="revNewEmpyPwd" runat="server" ErrorMessage="Password must be 8-10 characters long with at least one numeric, one uppercase alphabet, one lowercase alphabet, and one special character." ForeColor="Red" font-size= "8" ValidationExpression= "^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[~!@#$%^&*_]).{8,10}$" ControlToValidate="txtNewEmpyPwd"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Password should not be null!" ForeColor="Red" font-size= "8" ControlToValidate="txtNewEmpyPwd"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 180px">
                    <asp:Label ID="Label3" runat="server" Text="Confirm New Password"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtConNewEmpyPwd" style="width:200px" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:RegularExpressionValidator display="Dynamic" ID="revConNewEmpyPwd" runat="server" ErrorMessage="Password must be 8-10 characters long with at least one numeric, one uppercase alphabet, one lowercase alphabet, and one special character." ForeColor="Red" font-size= "8" ValidationExpression= "^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[~!@#$%^&*_]).{8,10}$" ControlToValidate="txtConNewEmpyPwd"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:RequiredFieldValidator ID="rfvConNewEmpyPwd" runat="server" ErrorMessage="Password should not be null!" ForeColor="Red" font-size= "8" ControlToValidate="txtConNewEmpyPwd"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 180px">
                    <asp:Label ID="Label4" runat="server" ForeColor="#990000" font-size= "8" font-family= Arial Text="Password must be 8-10 characters long with at least one numeric,</br> one alphabet and one special character."></asp:Label>
                </td>
                <td class ="center">
                    <asp:Button ID="btnSubmit" CssClass="button button2" runat="server" Text="Submit" OnClick="btnSubmit_Click"/></td>
            </tr>
            <tr>
                <td style="width: 180px"></td>
                <td class ="right">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="Password is not the same!" ForeColor="Red" font-size= "8"></asp:Label></td>
            </tr>
        </table>
    </div>
    </asp:Content>