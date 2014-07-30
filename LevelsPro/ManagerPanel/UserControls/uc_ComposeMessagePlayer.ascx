<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ComposeMessagePlayer.ascx.cs" Inherits="LevelsPro.ManagerPanel.UserControls.uc_ComposeMessagePlayer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    .opt
    {
        float: none !important;
        width: 225px !important;
    }
    .post-area
    {
      /*  width: 463px !important;*/
    }
</style>


<div class="box forums-popup">
    <div class="in-cont p-cont">
        <asp:UpdatePanel ID="upCompose" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <%--<asp:Label ID="lblSubject" Text="Subject:" runat="server" class="tr-in fl"></asp:Label>--%>
                <asp:TextBox ID="txtareaSubject" MaxLength="50" Height="40px" runat="server" class="input-style post-area pm"
                    TextMode="SingleLine" ForeColor="Black"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ErrorMessage="*" ControlToValidate="txtareaSubject"
                    Font-Size="25px" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Compose"
                    ToolTip="Enter Subject"></asp:RequiredFieldValidator>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                    TargetControlID="txtareaSubject" WatermarkText="Type your subject here">
                </asp:TextBoxWatermarkExtender>
                <br />
                <%--<asp:Label ID="lblMessage" Text="Message:" runat="server" class="tr-in fl"></asp:Label>--%>
                <asp:TextBox ID="txtareaMessage" runat="server" class="input-style post-area pm"
                    TextMode="MultiLine" ForeColor="Black"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ErrorMessage="*" ControlToValidate="txtareaMessage"
                    Font-Size="25px" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Compose"
                    ToolTip="Enter Message"></asp:RequiredFieldValidator>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                    TargetControlID="txtareaMessage" WatermarkText="Type your message here">
                </asp:TextBoxWatermarkExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="green-wrapper fl mc-canse m10px">
        <asp:Button ID="btnSend" runat="server" Text="<%$ Resources:TestSiteResources, Send %>" class="green" OnClick="btnSend_Click"
            ValidationGroup="Compose"></asp:Button>
    </div>
    <div class="green-wrapper fr mc-canse m10px">
        <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:TestSiteResources, Cancel %>" class="green" OnClick="btnCancel_Click">
        </asp:Button>
    </div>
</div>

