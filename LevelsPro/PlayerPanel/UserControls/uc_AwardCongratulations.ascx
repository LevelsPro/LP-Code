<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_AwardCongratulations.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_AwardCongratulations" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<img src="Images/congratulations.png" class="congratulations-img" />
<div class="msg-cont name-msg">
    <asp:Literal ID="lblName" Text="Jenny J.!" runat="server"></asp:Literal></div>
<div class="msg-cont lvl-cashier">
    You have achieved award :
    <asp:Literal ID="lblAward" runat="server"></asp:Literal></div>
<%--<div class="levels1">
    <img width="86" height="82" src="images/level-3.png">
</div>--%>
<div class="msg-cont det-msg" id="awardtext" runat="server">   
    <p>
        New options are available to you in the Redeem Points menu!</p>
    <p>
        A new set of goals await you!</p>
</div>
<div class="success-msg det-msg" id="successDiv" runat="server" visible="false">
    <p>
        You have successfully shared on facebook.</p>
</div>
<div class="success-msg det-msg" id="TweeterSuccessDiv" runat="server" visible="false">
    <p>
        You have successfully tweeted.</p>
</div>
<div class="error-msg det-msg" id="FailureDiv" runat="server" visible="false">
    <p>
        Cannot share on facebook, please try later!</p>
</div>
<div class="error-msg det-msg" id="TweeterFailureDiv" runat="server" visible="false">
    <p>
        Cannot tweet, please try later</p>
</div>
 <div class="social-btns-cont">
     <div class="green-wrapper fr donebtn">
            <asp:Button ID="btnDone" runat="server" CssClass="green" Text="Done"
                OnClick="btnDone_Click" />
            </div>
</div>
