<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Congratulations.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_Congratulations" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<%--<link href="../Styles/theme-3.css" rel="stylesheet" type="text/css" />--%>
<img src="Images/congratulations.png" class="congratulations-img" />
<div class="msg-cont name-msg">
    <asp:Literal ID="lblName" Text="Jenny J.!" runat="server"></asp:Literal></div>
<div class="msg-cont lvl-cashier">
    You Have Completed
    <div class="star" style="display: none;">
        <asp:Literal ID="lblLevel" Text="Level 4" runat="server" Visible="false"></asp:Literal></div>
    <div class="levels1">
       <%-- <img width="86" height="82" src="images/level-3.png">--%>
        <asp:Image ID="LevelStar" runat="server" width="86" height="82" AlternateText="No Image"  />
    </div>
    <asp:Literal ID="lblRole" Text="Cashier!" runat="server"></asp:Literal>
</div>
<div class="msg-cont det-msg">
    <p>
        You earned<img src="Images/star-orng.png" width="27" height="26" /><asp:Literal ID="lblBonus1"
            Text="500" runat="server"></asp:Literal></p>
    <%--<p>You reached this level ahead of schedule, earning a <img src="../Images/star-orng.png" width="27" height="26" /> 50 bonus!</p>--%>
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
    <asp:ImageButton ID="imgbtnFacebook" runat="server" src="images/post-on-facebook.png"
        Width="329" Height="62" OnClick="imgbtnFacebook_Click" Visible="False" />
    <asp:ImageButton ID="imgbtnTwiter" runat="server" src="images/post-on-twitter.png"
        Width="329" Height="62" OnClick="imgbtnTwiter_Click" Visible="False" />
    <div class="green-wrapper frdb donebtn">
        <asp:Button ID="btnDone" runat="server" CssClass="green" Text="Done" OnClick="btnDone_Click" />
    </div>
</div>
<%--<div class="social-btns-cont">
		
				<img src="images/post-on-facebook.png" width="329" height="62" alt="Post on Facebook" />
				<img src="images/post-on-twitter.png" width="329" height="62" alt="Post on Twitter" />
				
				<div class="green-btn fr donebtn">Done</div> 
						
		</div>--%>
