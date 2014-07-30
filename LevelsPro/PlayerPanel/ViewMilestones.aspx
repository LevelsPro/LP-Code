<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="ViewMilestones.aspx.cs" Inherits="LevelsPro.PlayerPanel.ViewMilestones" %>

<%@ Register TagPrefix="uc" TagName="Profile" Src="~/PlayerPanel/UserControls/uc_Profile.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="Styles/theme-3.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
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
                        PostBackUrl="~/PlayerPanel/ViewAwards.aspx" class="green"></asp:Button>
                </div>
                <div class="orange-wrapper fl maw m10px">
                    <asp:Button ID="btnMilestones" runat="server" Text="<%$ Resources:TestSiteResources, MilestonesB %>"
                        PostBackUrl="~/PlayerPanel/ViewMilestones.aspx" class="orange"></asp:Button>
                </div>
                <div class="green-wrapper fl maw m10px">
                    <asp:Button ID="btnManagerAwards" runat="server" Text="<%$ Resources:TestSiteResources, Manager %> "
                        class="green" PostBackUrl="~/PlayerPanel/ViewManagerAwards.aspx"></asp:Button>
                </div>
                <div class="green-wrapper fl maw m10px">
                    <asp:Button ID="Button2" runat="server" Text="<%$ Resources:TestSiteResources, Levels %> "
                        class="green" PostBackUrl="~/PlayerPanel/ViewLevelAwards.aspx"></asp:Button>
                </div>
                <div class="green-wrapper fl maw m10px">
                    <asp:Button ID="Button3" runat="server" Text="<%$ Resources:TestSiteResources, Performance %> "
                        class="green" PostBackUrl="~/PlayerPanel/ViewPerformanceAwards.aspx"></asp:Button>
                </div>
                <div class="green-wrapper fl maw m10px">
                    <asp:Button ID="Button4" runat="server" Text="<%$ Resources:TestSiteResources, Contest %> " PostBackUrl="~/PlayerPanel/ViewContestAwards.aspx"
                        class="green"></asp:Button>
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
                <div class="viewport msgs">
                    <div class="overview">
                        <asp:DataList ID="dlViewAwards" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                            RepeatLayout="Table" Width="100%" OnItemDataBound="dlViewAwards_ItemDataBound">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgAwards" class="fl" Width="139" Height="148" runat="server" ImageUrl='<%# Eval("Award_Image").ToString().Trim() != "" ? ConfigurationSettings.AppSettings["AwardsPath"].ToString() + Eval("Award_Image") : "Images/placeholder.png" %>' />
                                        </td>
                                        <td>
                                            <div class="aw-desc fl">
                                                <asp:Label ID="lblTargetScore" runat="server" Text='<%# Eval("Target_Value") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblAchievedScore" runat="server" Text='<%# Eval("Scores") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblManual" runat="server" Text='<%# Eval("Award_Manual") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblAwardID" runat="server" Text='<%# Eval("Award_ID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblAwardName" runat="server" Text='<%# Eval("Award_Name") %>' class="heading"></asp:Label><br />
                                                <asp:Label ID="lblAwardDesc" runat="server" Text='<%# Eval("Award_Desc") %>' class="joined"></asp:Label><br />
                                                <%--<asp:Label ID="lblAwardDate" runat="server" Text='<%# Eval("awarded_date") %>' class="date"></asp:Label><br />--%>
                                                <div class="blue-bar">
                                                    <asp:Label ID="lblPercentage" runat="server" class="filled" Text='<%# Eval("Percentage") %>'></asp:Label>
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <ItemStyle CssClass="award-cont" />
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
