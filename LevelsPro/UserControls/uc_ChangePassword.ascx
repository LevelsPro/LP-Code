<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ChangePassword.ascx.cs"
    Inherits="LevelsPro.UserControls.uc_ChangePassword" %>
<%--<div class="opac-wrap">
	
	</div>--%>
<!-- START: Change Password -->
<div class="cyan-head">
 <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, ChangePassword %>"></asp:Label>
</div>
<div class="styleThese">
    <div class="left-label fl">
        <asp:Label ID="lblOldPassword" runat="server" Text="<%$ Resources:TestSiteResources, OldPassword %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <asp:TextBox ID="txtOldPass" runat="server" CssClass="input-pop" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ErrorMessage="*" ValidationGroup="Change"
            ControlToValidate="txtOldPass"></asp:RequiredFieldValidator>
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblNewPassword" runat="server" Text="<%$ Resources:TestSiteResources, NewPassword %> "></asp:Label>
    </div>
    <div class="right-label fl">
        <asp:TextBox ID="txtNewPass" runat="server" CssClass="input-pop" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ErrorMessage="*" ValidationGroup="Change"
            ControlToValidate="txtNewPass"></asp:RequiredFieldValidator>
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblConfirmPassword" runat="server" Text="<%$ Resources:TestSiteResources, ConfirmPassword %> "></asp:Label>
    </div>
    <div class="right-label fl">
        <asp:TextBox ID="txtConfirmPass" runat="server" CssClass="input-pop" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
            ValidationGroup="Change" ControlToValidate="txtConfirmPass" Display="Dynamic"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password does not match."
            ValidationGroup="Change" ControlToCompare="txtNewPass" ControlToValidate="txtConfirmPass"
            Operator="Equal"></asp:CompareValidator>
    </div>
    <div class="clear">
        <asp:Label ID="lblMeassage" runat="server" Visible="false"></asp:Label>
    </div>
    <div class="clear">
    </div>
    <div class="btn-pop">
        <div class="green-wrapper pop-btn">
            <asp:Button ID="btnChangePass" runat="server" CssClass="green" OnClick="btnChangePass_Click" ValidationGroup="Change"
                Text="<%$ Resources:TestSiteResources, ChangePassword %>" />
        </div>
        <div class="green-wrapper pop-btn">
            <asp:Button ID="btnCancel" runat="server" CssClass="green" OnClick="btnCancel_Click"
                Text="<%$ Resources:TestSiteResources, Cancel %>" />
        </div>
    </div>
</div>
<!--   END: Change Password -->
