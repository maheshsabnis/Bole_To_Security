<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="Bole_To_Security.RegisterUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table CssClass="table table-bordered table-striped">
        <tr>
            <td>
               User Name
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
                Confirm Password
            </td>
            <td>
                 <asp:TextBox runat="server" ID="txtconfirmpwd" CssClass="form-control"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
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
    <asp:Label runat="server" ID="lblstatus"></asp:Label>
</asp:Content>
