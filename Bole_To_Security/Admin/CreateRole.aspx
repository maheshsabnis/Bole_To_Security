
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRole.aspx.cs" Inherits="Bole_To_Security.Admin.CreateRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
               Role Name
            </td>
            <td>
                 <asp:TextBox runat="server" ID="txtrolename" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Button runat="server" Text="Clear" ID="btnClear" CssClass="btn btn-primary" OnClick="btnClear_Click"/>
            </td>
            <td>
                <asp:Button runat="server" Text="Save" ID="btn_Save" CssClass="btn btn-success" OnClick="btn_Save_Click"/>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <hr />
    <asp:Label ID="lblstatus" runat="server"></asp:Label>
</asp:Content>
