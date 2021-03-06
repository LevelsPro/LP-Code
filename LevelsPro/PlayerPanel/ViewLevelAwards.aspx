﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="ViewLevelAwards.aspx.cs" Inherits="LevelsPro.PlayerPanel.ViewLevelAwards" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="Profile" Src="~/PlayerPanel/UserControls/uc_Profile.ascx" %>
<%@ Register TagPrefix="uc" TagName="AwardDetails" Src="~/PlayerPanel/UserControls/uc_AwardDetails.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-57350527-1', 'auto');
        ga('send', 'pageview');

    </script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="top-b">
            <div class="green-ar-wrapper fl">
                <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, HomeAdmin %>"
                    PostBackUrl="~/PlayerPanel/PlayerHome.aspx" class="green-ar"></asp:Button>
            </div>
            <asp:Label ID="lblName" runat="server" class="user-nt"></asp:Label>
            <div class="green-wrapper logout">
                <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
                    class="green" OnClick="btnLogout_Click"></asp:Button>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="body-cont">
            <uc:Profile ID="ViewProfile" runat="server" />
            <div class="box brd mt10 m10px p10px">
                <div class="green-wrapper fl maw m10px">                   
                    <asp:Button ID="btnMyAwards" runat="server" Text="<%$ Resources:TestSiteResources, MyAwardsB %>"
                        CssClass="green" PostBackUrl="~/PlayerPanel/ViewAwards.aspx" />
                </div>
                <div class="green-wrapper fl maw m10px">
                    <asp:Button ID="btnMilestones" runat="server" Text="<%$ Resources:TestSiteResources, MilestonesB %>"
                        PostBackUrl="~/PlayerPanel/ViewMilestones.aspx" class="green"></asp:Button>
                </div>
                <div class="green-wrapper fl maw m10px">
                    <asp:Button ID="btnManagerAwards" runat="server" Text="<%$ Resources:TestSiteResources, Manager %> "
                        PostBackUrl="~/PlayerPanel/ViewManagerAwards.aspx" class="green"></asp:Button>
                </div>
                <div class="orange-wrapper fl maw m10px">
                    <asp:Button ID="Button2" runat="server" Text="<%$ Resources:TestSiteResources, Levels %> "
                        PostBackUrl="~/PlayerPanel/ViewLevelAwards.aspx" class="orange"></asp:Button>
                </div>
                <div class="green-wrapper fl maw m10px">
                    <asp:Button ID="Button3" runat="server" Text="<%$ Resources:TestSiteResources, Performance %> "
                        PostBackUrl="~/PlayerPanel/ViewPerformanceAwards.aspx" class="green"></asp:Button>
                </div>
                <div class="green-wrapper fl maw m10px">
                    <asp:Button ID="Button4" runat="server" Text="<%$ Resources:TestSiteResources, Contest %> "
                        PostBackUrl="~/PlayerPanel/ViewContestAwards.aspx" class="green"></asp:Button>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="manager-cont fl-wrapper" id="scrollbar1">
                <div class="scrollbar">
                    <div class="track">
                        <div class="thumb">
                            <div class="end">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="viewport">
                    <div class="overview">
                        <asp:DataList ID="dlViewAwards" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                            RepeatLayout="Table" OnItemDataBound="dlViewAwards_ItemDataBound" OnItemCommand="dlViewAwards_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnView" runat="server" CommandName="ViewPopup" CommandArgument='<%# Eval("Award_ID")%>'
                                    ForeColor="Black" Font-Underline="false">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="187px" valign="top" align="center">
                                                <br />
                                                <asp:Image ID="imgAwards" runat="server" ImageUrl='<%# Eval("Award_Image").ToString().Trim() != "" ? ConfigurationSettings.AppSettings["AwardsPath"].ToString() + Eval("Award_Image") : "Images/placeholder.png" %>'
                                                    Width="70px" Height="70px" /><br />
                                                <asp:Label ID="lblAwardName" runat="server" Text='<%# Eval("Award_Name") %>' Font-Bold="true"></asp:Label><br />
                                                <%--<asp:Label ID="lblAwardDesc" runat="server" Text='<%# Eval("Award_Desc") %>' Font-Bold="true"></asp:Label><br />--%>
                                                <asp:Label ID="lblAwardDate" runat="server" Text='<%# Eval("awarded_date") %>' Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:LinkButton>
                                <div class="clear">
                                </div>
                            </ItemTemplate>
                            <ItemStyle CssClass="award-cont" VerticalAlign="Top" BorderWidth="0px" />
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="_editPopupButton" runat="server" Text="Edit Contact" Style="display: none" />
    <asp:ModalPopupExtender ID="mpeAwardDetails" runat="server" BackgroundCssClass="modalBackground"
        RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
        PopupControlID="_ViewAwardDetailsDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
        BehaviorID="EditModalPopupPost">
    </asp:ModalPopupExtender>
    <div class="_popupButtons" style="display: none">
        <input id="_okPopupButton" value="OK" type="button" />
        <input id="_cancelPopupButton" value="Cancel" type="button" />
    </div>
    <asp:UpdatePanel ID="upViewAwardDetails" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="_ViewAwardDetailsDiv" class="box pd-popup" style="display: none;">
                <uc:AwardDetails ID="ucAwardDetails" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
