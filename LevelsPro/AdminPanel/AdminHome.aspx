<%@ Page Title="Admin Home" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="LevelsPro.AdminPanel.AdminHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register TagPrefix="uc" TagName="ChangePassword" Src="../UserControls/uc_ChangePassword.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <%--popup for password change--%>
                <asp:Button ID="_editPopupChangePass" runat="server" Text="Edit Password" Style="display: none" />
                <asp:ModalPopupExtender ID="mpeChangePassDiv" runat="server" BackgroundCssClass="modalBackground"
                    RepositionMode="None" TargetControlID="_editPopupChangePass" ClientIDMode="AutoID"
                    PopupControlID="_ChangePassMessageDiv" OkControlID="Button2" CancelControlID="Button3"
                    BehaviorID="ChangePasswordManager">
                </asp:ModalPopupExtender>
                <div class="_popupButtons" style="display: none">
                    <input id="Button2" value="OK" type="button" />
                    <input id="Button3" value="Cancel" type="button" />
                </div>
                <div id="_ChangePassMessageDiv" class="popup-cyan" style="display: none;">
                    <uc:ChangePassword ID="ucChangePassword" runat="server" />
                </div>
    <%--end popup for password change--%>
    <%-- <h2><asp:Label ID="lblWelcomeHome" runat="server" Text="<%$ Resources:TestSiteResources, WelcomeHomeAdmin %>"></asp:Label></h2>--%>
    <div class="box top-b options-bar">
       <%-- <div class="green-btn btn fl">
            Back</div>--%>
        <div class="user-nt fl ep">
         <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, MainPanel %>"></asp:Label>
            </div>       
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" CssClass="green-btn btn fr"
                    OnClick="btnLogout_Click"/>
        <div class="clear">
                            
                                <asp:LinkButton ID="lkbChang" runat="server" 
                                    Text="<%$ Resources:TestSiteResources, ChangePassword %>" 
                                    onclick="lkbChang_Click" Visible="false"></asp:LinkButton>
        </div>
    </div>
    <div class="box brd2 main-panel">  
    
        <asp:Button ID="btnManageLocations" runat="server" Text="<%$ Resources:TestSiteResources, ManageSites %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/SiteManagement.aspx" />       
        <asp:Button ID="btnManageRoles" runat="server" Text="<%$ Resources:TestSiteResources, ManageRoles %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/RoleManagement.aspx" />        
        <asp:Button ID="btnManageKPI" runat="server" Text="<%$ Resources:TestSiteResources, ManageKPI %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/KPIManagement.aspx" />         
        <asp:Button ID="btnManageLevels" runat="server" Text="<%$ Resources:TestSiteResources, ManageLevels %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/LevelManagements.aspx" />        
        <asp:Button ID="btnManageAwards" runat="server" Text="<%$ Resources:TestSiteResources, ManageAwards %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/AwardManagement.aspx" />
        <asp:Button ID="btnManageRewards" runat="server" Text="<%$ Resources:TestSiteResources, ManageRewards %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/RewardManagement.aspx" />
        <asp:Button ID="btnManageContests" runat="server" Text="<%$ Resources:TestSiteResources, ManageContests %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/ContestManagement.aspx" />
        <asp:Button ID="btnManagePlayers" runat="server" Text="<%$ Resources:TestSiteResources, ManagePlayers %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/PlayerManagement.aspx" />
        <asp:Button ID="btnManageLevelGame" runat="server" Text="<%$ Resources:TestSiteResources, ManageLevelGame %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/LevelGameManagement.aspx" />
        <asp:Button ID="btnAPI" runat="server" Text="<%$ Resources:TestSiteResources, APIImportSheet %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/APIExportSheet.aspx" />
       <%-- <asp:Button ID="Button1" runat="server" Enabled="true" Text="<%$ Resources:TestSiteResources, ManageGame %>" CssClass="green-btn mp-btns" PostBackUrl="" /> --%>
        <asp:Button ID="btnManageGames" runat="server" Enabled="true" Text="<%$ Resources:TestSiteResources, ManageQuiz %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/QuizManagement.aspx" />
        <asp:Button ID="btnManageMatch" runat="server" Enabled="true" Text="<%$ Resources:TestSiteResources, ManageMatch %>" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/MatchManagement.aspx" />
        <asp:Button ID="btnConfigureBanner" runat="server" Enabled="true" Text="Configure Banner" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/BannerConfiguration.aspx" />
        <%--<asp:Button ID="btnAssignAwards" runat="server" Text="Assign Award" CssClass="green-btn mp-btns" PostBackUrl="~/AdminPanel/AssignAwards.aspx" />--%>        
        <%--<asp:Button ID="btnManageAppearance" runat="server" Enabled="false" Text="Manage Appearance" CssClass="green-btn mp-btns" />--%>        
    </div>
</asp:Content>
