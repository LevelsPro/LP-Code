<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ForgotPassword.ascx.cs" Inherits="LevelsPro.UserControls.uc_ForgotPassword" %>
             <%--<uc:AwardDetails ID="ucAwardDetails" runat="server" />--%>
 <div class="opac-wrap">
</div>
<div class="popup-cyan">

    <div class="cyan-head">
     <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, ForgotPasswordH %>"></asp:Label>
        
    </div>
   <%-- <form class="styleThese">--%>
   <asp:Label ID="lblmessage" runat="server" Text="Request Sent to Admin Successfully and on next login you will have a set new password option "></asp:Label>
    <div class="answer-title at-forgot">
        <asp:Label ID="lblUser" runat="server" Text="<%$ Resources:TestSiteResources, UserName %>"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ValidationGroup="forgetpass"
            ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
    </div>
    <div class="answer-title at-forgot">
    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, Wouldyoulike %>"></asp:Label>
       
    </div>
    <div class="btn-pop pt47">
        <div class="green-wrapper pop-btn">
          <asp:Button ID="btnReset" runat="server" class="green" 
                Text="<%$ Resources:TestSiteResources, RequestReset %>" 
                onclick="btnReset_Click" Visible="False" />
           <%-- <input type="button" class="green" value="Request Reset" />--%>
        </div>
        <div class="green-wrapper pop-btn">
            <asp:Button ID="btnSecurity" runat="server" class="green" Text="Request Reset" ValidationGroup="forgetpass"
                OnClick="btnSecurity_Click" />
        </div>
        <div class="green-wrapper pop-btn">
            <asp:Button ID="btnCancel" runat="server" class="green" Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
        </div>
    </div>
     <div class="answer-title">
        <asp:Label ID="lblMeassage" runat="server"></asp:Label>
    </div>
    <%--</form>--%>
</div>
