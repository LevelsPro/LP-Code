<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="LevelsPro.ManagerPanel.ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                <asp:Label ID="lblOldPassword" runat="server" Text="<%$ Resources:TestSiteResources, OldPassword %> "></asp:Label>
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
                <asp:Label ID="lblConfirmPassword" runat="server" Text="<%$ Resources:TestSiteResources, ConfirmPassword %>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ValidationGroup="Change" ControlToValidate="txtNewPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password does not match."
                    ValidationGroup="Change" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td align="left">
                <asp:Button ID="btnUpdatePassword" runat="server" Text="<%$ Resources:TestSiteResources, ChangePasswordB %>" 
                    ValidationGroup="Change" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
