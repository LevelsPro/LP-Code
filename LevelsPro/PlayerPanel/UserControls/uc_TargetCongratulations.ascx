<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_TargetCongratulations.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_TargetCongratulations" %>

        <img src="Images/congratulations.png" class="congratulations-img"  />
        <div class="msg-cont name-msg">
            <asp:Literal ID="lblName" Text="Jenny J.!" runat="server"></asp:Literal></div>
        <div class="msg-cont lvl-cashier">
            Now you have next target :
             <%--<div class="star">--%>
               <asp:Literal ID="lblTarget" runat="server"></asp:Literal><%--</div>--%>

                <%--<div class="levels1">
					<img width="86" height="82" src="images/level-3.png">
				</div>

            <asp:Literal ID="lblRole" Text="Cashier!" runat="server"></asp:Literal>--%>
        </div>
        <div class="msg-cont det-msg">
            <p>
                You earned<img src="Images/star-orng.png" width="27" height="26" /><asp:Literal
                    ID="lblBonus1" Text="500" runat="server"></asp:Literal></p>
            <%--<p>You reached this level ahead of schedule, earning a <img src="../Images/star-orng.png" width="27" height="26" /> 50 bonus!</p>--%>
            <p>
                New options are available to you in the Redeem Points menu!</p>
            <p>
                A new set of goals await you!</p>
        </div>
        <div class="social-btns-cont">
            <asp:ImageButton ID="imgbtnFacebook" runat="server" src="images/post-on-facebook.png"
                Width="329" Height="62" />
            <asp:ImageButton ID="imgbtnTwiter" runat="server" src="images/post-on-twitter.png"
                Width="329" Height="62" />
            
            <div class="green-wrapper fr donebtn">
            <asp:Button ID="btnDone" runat="server" CssClass="green" Text="Done"
                OnClick="btnDone_Click" />
            </div>
        </div>

