<%@ Page Title="Player Rewards" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="PlayerRewards.aspx.cs" Inherits="LevelsPro.AdminPanel.PlayerRewards" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script type="text/javascript">
     $(document).ready(function () {
         $('#scrollbar1').tinyscrollbar();
     });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" CssClass="green-btn btn fl" OnClick="btnBack_Click" />
        <div class="user-nt fl ep">
            <asp:Literal ID="ltHeading" runat="server" Text="<%$ Resources:TestSiteResources, PlayerRewards %>"></asp:Literal></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" CssClass="green-btn btn fr"
            OnClick="btnLogout_Click"/>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        <div class="box admin-btns-cont">
            <asp:Button ID="btnMainInfo" runat="server" Text="<%$ Resources:TestSiteResources, MainInfo %>" 
                CssClass="green-btn ad-btns" onclick="btnMainInfo_Click" />
            <asp:Button ID="btnAwards" runat="server" Text="<%$ Resources:TestSiteResources, AwardsB %>" CssClass="green-btn ad-btns"
                OnClick="btnAwards_Click" />
            <asp:Button ID="btnProgress" runat="server" Text="<%$ Resources:TestSiteResources, Progress1 %>" CssClass="green-btn ad-btns"
                OnClick="btnProgress_Click" />
            <asp:Button ID="btnRewards" runat="server" Text="<%$ Resources:TestSiteResources, Reward %>" CssClass="yellow-btn ad-btns" />
        </div>
        <div class="usercont-right">
            <div class="fl-wrapper user-data np-user-data epr">
                <div class="strip">
                    <asp:Label ID="lblPoints" runat="server" Text="<%$ Resources:TestSiteResources, Points %>" CssClass="edit-left"></asp:Label>
                     <span class="edit-right">                        
                        <img src="images/star-small.png" width="24" height="24" alt="Star" />
                        <asp:TextBox ID="txtPoints" runat="server" CssClass="epr-in"></asp:TextBox>
                        </span>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="fl-wrapper user-data np-user-data epr">
                <div class="strip">
                    <asp:Label ID="lblUserID" runat="server" Text="<%$ Resources:TestSiteResources, UserID %>" CssClass="edit-left"></asp:Label> <asp:Label ID="lblUserIDValue" runat="server" CssClass="edit-right"></asp:Label>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblName" runat="server" Text="<%$ Resources:TestSiteResources, Name %>" CssClass="edit-left"></asp:Label> <asp:Label ID="lblNameValue" runat="server" CssClass="edit-right"></asp:Label>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:TestSiteResources, Update %>" 
            CssClass="green-btn btn fr" onclick="btnUpdate_Click" />
            <div class="clear">
            </div>
        </div>
        
        <div class="clear">
        </div>
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
                    <asp:DataList ID="dlRewards" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                        Width="100%">
                        <ItemTemplate>
                            <div class="adminprog-cont">
                             
                                <asp:Image ID="imgRewardImage" runat="server" ImageUrl='<%# Eval("Reward_Thumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["RewardsThumbPath"].ToString() + Eval("Reward_Thumbnail") :"Images/placeholder.png" %>'
                                       class="fl" Width="72" Height="72" />                                
                                <h1 class="prog-text">
                                    <%#Eval("Reward_Name")%>
                                    <br />
                                    <%# Convert.ToDateTime(Eval("Redeem_Date")).ToShortDateString() %>    
                                </h1>
                                
                               <%-- <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="green-btn prog-edit fr" />--%>
                                <div class="clear">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>

    </div><div class="clear">
        </div>
</asp:Content>
