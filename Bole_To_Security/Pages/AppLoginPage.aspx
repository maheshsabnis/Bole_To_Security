<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AppLoginPage.aspx.cs" Inherits="Bole_To_Security.Pages.AppLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table CssClass="table table-bordered table-striped">
        <tr>
            <td>
               User Nme
            </td>
            <td>
                 <asp:TextBox runat="server" ID="txtename" CssClass="form-control"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                 <asp:TextBox runat="server" ID="txtpwd" CssClass="form-control"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        
         <tr>
            <td>
                <asp:Button runat="server" Text="Clear" ID="btnClear" CssClass="btn btn-primary" OnClick="btnClear_Click"/>
            </td>
            <td>
                <asp:Button runat="server" Text="Login" ID="btnLogin" CssClass="btn btn-success" OnClick="btnLogin_Click"/>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
