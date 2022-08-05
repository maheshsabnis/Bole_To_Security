<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerUI.aspx.cs" Inherits="Bole_To_Security.Manager.ManagerUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-bordered table-striped">
        <tr>
            <td colspan="2">
                 <asp:LinkButton ID="lnkbtnlogout" runat="server" 
                    OnClick="lnkbtnlogout_Click">Logout</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkbtndeptcrud" runat="server" OnClick="lnkbtndeptcrud_Click">Deparetment CRUD</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lnkbtnempcrud" runat="server" 
                    OnClick="lnkbtnempcrud_Click">Employee CRUD</asp:LinkButton>
            </td>
             
        </tr>
        
    </table>
</asp:Content>
