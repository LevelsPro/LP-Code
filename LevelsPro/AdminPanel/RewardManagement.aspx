<%@ Page Title="Reward Management" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="RewardManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.RewardManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/admin-theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/admin-website.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <link href="../Styles/lightbox.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.smooth-scroll.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script src="../Scripts/lightbox.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>"  PostBackUrl="~/AdminPanel/AdminHome.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, ManageRewards %>"></asp:Label>
            </div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <div class="manager-cont" id="scrollbar1">
            <div class="scrollbar">
                <div class="track">
                    <div class="thumb">
                        <div class="end">
                        </div>
                    </div>
                </div>
            </div>
            <div class="viewport progadmin">
                <div class="overview">
                    <asp:UpdatePanel ID="upgvRoles" runat="server">
                        <ContentTemplate>
                            <asp:DataList ID="dlReward" runat="server" DataKeyField="Reward_ID" OnItemCommand="dlReward_ItemCommand"
                                Width="100%">
                                <ItemTemplate>
                                    <div class="adminprog-cont">
                                        <asp:Image ID="imgRewardImage" runat="server" ImageUrl='<%#ConfigurationSettings.AppSettings["RewardsThumbPath"].ToString()+Eval("Reward_Thumbnail")%>'
                                            class="fl" Width="72" Height="72" />
                                        <h1 class="admin-text">
                                            <asp:Literal ID="ltRewardName" runat="server" Text='<%# Eval("Reward_Name") %>' /></h1>
                                        <asp:Button ID="btnEditReward" runat="server" CssClass="green-btn admin-edit fr"
                                            CommandName="EditReward" CommandArgument='<%# Eval("Reward_ID") %>' Text="<%$ Resources:TestSiteResources, Edit %>" />
                                        <div class="clear">
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="adminprog-cont crt-reward">
                                <asp:Button ID="btnNewReward" class="green-btn create-reward" Text="<%$ Resources:TestSiteResources, CreateNewReward %>"
                                    runat="server" OnClick="btnNewReward_Click" />
                            </div>
        <div class="clear">
        </div>
       <%-- <div class="clear">
        </div>--%>
    </div>
</asp:Content>
