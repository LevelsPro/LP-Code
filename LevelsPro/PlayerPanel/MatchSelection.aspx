<%@ Page Title="Matching Games" Language="C#" MasterPageFile="~/PlayerPanel/Player.master"
    AutoEventWireup="true" CodeBehind="MatchSelection.aspx.cs" Inherits="LevelsPro.PlayerPanel.MatchSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);
            //	$('.filled-area').slideRight();

            var h = $('.scrollbar').height();
            h = h - 11;
            $('.scrollbar').css("height", h);

        });
    </script>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="top-b">
            <div class="green-ar-wrapper fl">
                <asp:Button ID="btnHome" runat="server" CssClass="green-ar" Text="<%$ Resources:TestSiteResources, HomeAdmin %>" OnClick="btnHome_Click" />
            </div>
            <div class="user-nt">
                <asp:Literal ID="lblUserName" runat="server"></asp:Literal></div>
            <div class="green-wrapper logout">
                <asp:Button ID="btnLogOut" runat="server" CssClass="green" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" OnClick="btnLogOut_Click" />
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="body-cont">
         <asp:Label ID="mes" Visible="false" runat="server" BackColor="White"></asp:Label>
            <div class="quiz-selection">
                <div class="tophead">
                <asp:Label ID="lblMatch" runat="server" Text="<%$ Resources:TestSiteResources, MatchGames %>" ></asp:Label>
                   </div>
                <div class="qs-cont" id="scrollbar1">
                    <div class="scrollbar">
                        <div class="track">
                            <div class="thumb">
                                <div class="end">
                                </div>
                            </div>
                        </div>
                   </div>
                    <div class="viewport msgs2">
                        <div class="overview">
                            <asp:DataList ID="dlGame" runat="server" Width="100%" OnItemCommand="dlGame_ItemCommand"
                                OnItemDataBound="dlGame_ItemDataBound" >
                                <ItemTemplate>
                                    <div class="qs-item qs-game-ny" runat="server" id="dlDiv" >
                                        <asp:Image ID="imgMatch" ImageUrl='<%# Eval("MatchImageThumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["MatchThumbPath"].ToString() + Eval("MatchImageThumbnail") :"Images/placeholder.png" %>' Width="73" Height="72" CssClass="fl" runat="server" />
                                        <div class="qs-mid">
                                            <span class="sh">
                                                <asp:Literal ID="ltMatchID" runat="server" Text='<%# Eval("MatchID")%>' Visible="false" />
                                                <asp:Literal ID="ltMatchName" runat="server" Text='<%# Eval("MatchName")%>' />
                                            </span>
                                            <br />
                                            <asp:Literal ID="ltPlayableLimit" runat="server" Text='<%# Eval("MaxPlaysPerDay")%>' Visible="false" />
                                            <asp:Label ID="lblMatch1" runat="server" Text="<%$ Resources:TestSiteResources, YourBest %>" ></asp:Label> 
                                            <asp:Literal ID="ltUserBest" runat="server" />
                                            <br />
                                            <asp:Label ID="lblMatch" runat="server" Text="<%$ Resources:TestSiteResources, TopScore %>" ></asp:Label>
                                            <asp:Literal ID="ltTopScore" runat="server" />
                                        </div>
                                        <div class="already-played" runat ="server" visible="false" id="Played">
                                            <asp:Literal ID="ltDone" runat="server" Text="<%$ Resources:TestSiteResources, youAlreadyPlayed %>"/>
                                        </div>
                                        <div class="green-wrapper fr play-game" runat ="server" id="Play" visible="true">
                                            <asp:Button ID="btnStartMatch" runat="server" CommandName="StartGame" CommandArgument='<%# Eval("MatchID")%>'
                                                Text="<%$ Resources:TestSiteResources, PlayGame %>" CssClass="green" />
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                </ItemTemplate>                                
                            </asp:DataList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
