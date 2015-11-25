<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="RedeemPoints.aspx.cs" Inherits="LevelsPro.PlayerPanel.RedeemPoints" %>

<%@ Register TagPrefix="uc" TagName="Profile" Src="~/PlayerPanel/UserControls/uc_Profile.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="”text/css”">
        .imgclass
        {
            background-color: #000000;
            text-align: center;
        }
        .imgclass map
        {
            margin: auto;
        }
        img
        {
            display: block;
        }
        
    </style>
    <style type="text/css">
        .tbl-processing
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.50;
        }
        
        
        
        
        .updateProgress
        {
            color: #FFFFFF;
            font-family: Trebuchet MS;
            font-size: small;
            margin: auto;
            opacity: 1;
            position: fixed;
            left: 50%;
            top: 50%;
            vertical-align: middle;
            margin-left: -150px;
            margin-top: -100px;
        }
    </style>

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
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <link href="Styles/theme-3.css" rel="stylesheet" type="text/css" />
  	<link href="Styles/theme.css" rel="stylesheet" type="text/css" />
	<link href="Styles/website.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $.fn.digits = function () {
            return this.each(function () {
                $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
            })
        }

        $(document).ready(function () {
           // $('#scrollbar1').tinyscrollbar();
            $('.amount').digits();

           // var h = $('.scrollbar').height();
           // h = h - 11;
           // $('.scrollbar').css("height", h);

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upRedeem" runat="server">
<ContentTemplate>
<div class="container">
	<div class="top-b">
	
		<div class="green-ar-wrapper home-btn">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, HomeAdmin %>" 
            PostBackUrl="~/PlayerPanel/PlayerHome.aspx" class="green-ar"></asp:Button>
		</div>
		<div class="user-nt"><asp:Label ID="lblName" runat="server" ></asp:Label></div>
		
		<div class="green-wrapper logout">
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
           class="green" OnClick="btnLogout_Click"></asp:Button>
		</div>
		
		<div class="clear"></div>
	</div>
    <div class="body-cont">
	<uc:Profile ID="ViewProfile" runat="server" />
	
    
		<div class="redemption-holder redemption">
				
		<div class="viewport redemption">
            <div style="width:100px;position:absolute; top:-50px; height:100px; right:-50px;"></div>
            <div style="width:100px;position:absolute; bottom:-50px; height:100px; right:-50px;"></div>
			 <div class="overview">
				
			<asp:DataList ID="dlRewards" runat="server" DataKeyField="Reward_ID" OnItemCommand="dlRewards_ItemCommand"
                        OnItemDataBound="dlRewards_ItemDataBound">
                        <ItemTemplate>
                            <div class="red-cont box">
                                <asp:Image Width="100px" Height="100px" ID="imgGraphics" CssClass="fl" runat="server"
                                    ImageUrl='<%# ConfigurationSettings.AppSettings["RewardsPath"].ToString() + Eval("Reward_Image") %>' />
                                <div class="desc">
                                    <h2 class="red-heading">
                                        <%# Eval("Reward_Name") %></h2>
                                    <div class="text">
                                        <%# Eval("Reward_Descp")%></div>
                                    <div class="btn-holder">

                                    <asp:LinkButton ID="lbtnRedeem" runat="server" Font-Overline="false" OnClientClick='<%# Eval("Reward_Name", "return confirm(\"Are you sure you want to redeem the {0}.\");") %>' CommandName="redeem" CommandArgument='<%# Eval("Reward_Cost") %>'>
                                        <div class="rdmption-btn" id="divscore" runat="server">                                       
                                            <%--<img src="images/arrow-redmp.png" width="23" height="31" alt="arrow" class="arrow" />--%>
                                            <img src="Images/star.png" class="btn-star" alt="star" />
                                            <asp:Label ID="lblRewardName" runat="server" Visible="false"  CssClass="amount" Text='<%# Eval("Reward_Name") %>'></asp:Label>
                                            <asp:Label ID="lblRedeem" runat="server" Font-Size="X-Large" CssClass="amount" Font-Bold="true" ForeColor="Black" Text='<%# Eval("Reward_Cost") %>'></asp:Label>
                                            <%--<asp:Button BackColor="Transparent" BorderColor="Transparent"  Font-Size="X-Large" Font-Bold="true" ID="btnRedeem" alt="star" runat="server" Text='<%# Eval("Reward_Cost") %>'
                                                />--%>
                                        </div>
                                    </asp:LinkButton>
                                    
                                    </div>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
	<asp:UpdateProgress ID="uprogressHome" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="upRedeem">
                <ProgressTemplate>
                    <div style="background-color: Teal; filter: alpha(opacity=80); opacity: 0.80; width: 100%;
                        top: 0px; left: 0px; position: fixed; height: 100%; z-index:9999;">
                    </div>
                    <div class="updateProgress">
                        <table width="100%">
                            <tr>
                                <td style="width: 30%">
                                    <img src="../Images/loading-small.gif" alt="wait" />
                                </td>
                                <td style="width: 70%" align="left">
                                    <span style="font-family: Georgia; font-size: medium; font-weight: bold; color: #FFFFFF">
                                        <asp:Literal ID="ltProcessing" runat="server" Text="<%$ Resources:TestSiteResources, Processing %>"></asp:Literal></span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            </ContentTemplate>
            </asp:UpdatePanel>

</asp:Content>
