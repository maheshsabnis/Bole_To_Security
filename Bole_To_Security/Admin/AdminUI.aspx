<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUI.aspx.cs" Inherits="Bole_To_Security.Admin.AdminUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>The Admn Page</h1>
    <table class="table table-bordered table-striped">
         <tr>
            <td colspan="4">
                <asp:Label ID="lblusername" runat="server"></asp:Label>
                <asp:LinkButton ID="lnkbtnlogout" runat="server" 
                    OnClick="lnkbtnlogout_Click">Logout</asp:LinkButton>
            </td>
        </tr>
        <tr>

            <td>
                <asp:LinkButton ID="lnkbtnassignroletouser" runat="server" OnClick="lnkbtnassignroletouser_Click">Assign Role to User</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lnkbtncreaterole" runat="server" OnClick="lnkbtncreaterole_Click">Create Role</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lnkbtndeptcrud" runat="server" OnClick="lnkbtndeptcrud_Click">Department CRUD</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lnkbtnempcrud" runat="server" OnClick="lnkbtnempcrud_Click">Employee Create</asp:LinkButton>
            </td>
        </tr>
    </table>
    <hr/>
     <table class="table table-bordered table-striped">

     </table>
</asp:Content>
