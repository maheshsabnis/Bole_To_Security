<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClerkUI.aspx.cs" Inherits="Bole_To_Security.Clerk.ClerkUI" %>
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
                <asp:LinkButton ID="lnkbtndept" runat="server"
                    OnClick="lnkbtndept_Click">Deparetment</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="lnkbtnemp" runat="server" 
                    OnClick="lnkbtnemp_Click">Employee</asp:LinkButton>
            </td>
             
        </tr>
        
    </table>
</asp:Content>
