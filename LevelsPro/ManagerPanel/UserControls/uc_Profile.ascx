<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Profile.ascx.cs" Inherits="LevelsPro.ManagerPanel.UserControls.uc_Profile" %>
 <div class="sec-left">
			<div class="avatar">
        <asp:Image ID="imgPhoto" runat="server" Width="94px" Height="94px" ImageUrl="~/PlayerPanel/Images/imagesNo.jpeg" />
    </div>
    </div>
    <div class="sec-right">
		<div class="profile-bcont">
    <div class="levels lvls-c">
    <img src="images/level-3.png" width="86" height="82" />
        <asp:Label ID="lblLevelName" runat="server" Visible="false" CssClass="star fl" style="float:left;"></asp:Label>
        </div>
       <div class="usern">
            <asp:Label ID="lblName" runat="server"></asp:Label><br />
            <asp:Label ID="lblRoleName" runat="server"></asp:Label>
        </div>
        <div class="scores sposition">
            <span class="wc"><asp:Label ID="lblContest" runat="server" Text="<%$ Resources:TestSiteResources, YouHave %>"></asp:Label></span><br />
            <img src="images/star-small.png" width="24" height="24" alt="Star" />
            <asp:Label ID="lblPoints" runat="server"></asp:Label></div>
          <div class="profile-bright"></div>
        <div class="clear">
        </div>
    </div>
    
    <div class="clear">
    </div>
</div>

