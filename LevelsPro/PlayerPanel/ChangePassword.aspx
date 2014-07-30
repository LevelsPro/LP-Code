<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="LevelsPro.PlayerPanel.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="4" cellspacing="0" width="700px">
        <tr>
            <td colspan="2" align="left">
                <asp:Label ID="lblHeading" runat="server" Text="<%$ Resources:TestSiteResources, ChangePassword %>" Font-Bold="true" Font-Size="18px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblMeassage" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="20%">
                <asp:Label ID="lblOldPassword" runat="server" Text="<%$ Resources:TestSiteResources, OldPassword %>"></asp:Label>
            </td>
            <td width="70%">
                <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ErrorMessage="*" ValidationGroup="Change"
                    ControlToValidate="txtOldPassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNewPassword" runat="server" Text="<%$ Resources:TestSiteResources, NewPassword %> "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ErrorMessage="*" ValidationGroup="Change"
                    ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblConfirmPassword" runat="server" Text="<%$ Resources:TestSiteResources, ConfirmPassword %> "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ValidationGroup="Change" ControlToValidate="txtConfirmPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password does not match."
                    ValidationGroup="Change" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" Operator="Equal"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td align="left">
                <asp:Button ID="btnUpdatePassword" runat="server" Text="<%$ Resources:TestSiteResources, ChangePasswordB %>" 
                    ValidationGroup="Change" onclick="btnUpdatePassword_Click" />
                &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:TestSiteResources, Cancel %>" PostBackUrl="~/PlayerPanel/PlayerHome.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
