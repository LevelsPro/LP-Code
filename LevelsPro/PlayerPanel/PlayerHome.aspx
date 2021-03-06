﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="PlayerHome.aspx.cs" Inherits="LevelsPro.PlayerPanel.PlayerHome" %>

<%@ Register TagPrefix="uc" TagName="Contests" Src="~/PlayerPanel/UserControls/uc_Contests.ascx" %>
<%@ Register TagPrefix="uc" TagName="Awards" Src="~/PlayerPanel/UserControls/uc_Awards.ascx" %>
<%@ Register TagPrefix="uc" TagName="Map" Src="~/PlayerPanel/UserControls/uc_Map.ascx" %>
<%@ Register TagPrefix="uc" TagName="Congrats" Src="~/PlayerPanel/UserControls/uc_Congratulations.ascx" %>
<%@ Register TagPrefix="uc" TagName="ChangePassword" Src="../UserControls/uc_ChangePassword.ascx" %>
<%--<%@ Register TagPrefix="uc" TagName="TargetCongrats" Src="~/PlayerPanel/UserControls/uc_TargetCongratulations.ascx" %>--%>
<%@ Register TagPrefix="uc" TagName="AwardCongrats" Src="~/PlayerPanel/UserControls/uc_AwardCongratulations.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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

    <script type="text/javascript">

        function windowpop(url) {

            var leftPosition, topPosition;
            //Allow for borders.
            leftPosition = (window.screen.width / 2) - ((600 / 2) + 10);
            //Allow for title and status bars.
            topPosition = (window.screen.height / 2) - ((440 / 2) + 50);
            //Open the window.
            window.open(url, "Window2", "status=no,height=" + 440 + ",width=" + 600 + ",resizable=yes,left=" + leftPosition + ",top=" + topPosition + ",screenX=" + leftPosition + ",screenY=" + topPosition + ",toolbar=no,menubar=no,scrollbars=no,location=no,directories=no");

        }

    </script>
    <%--<link href="Styles/theme-3.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />--%>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.ba-resize.min.js" type="text/javascript"></script>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>
    <%-- <link href="Styles/theme-3.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="Styles/theme-2.css" rel="stylesheet" type="text/css" />
    <link href="Styles/theme-3.css" rel="stylesheet" type="text/css" />--%>
    <%--<script type="text/javascript" src="Scripts/jquery.min.js"></script>--%>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
   
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
	</script>--%>
    <script type="text/javascript">
        $.fn.digits = function () {
            return this.each(function () {
                $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
            })
        }
        $(document).ready(function () {

            var setScrollBar = function () {
                $('#scrollbar2').tinyscrollbar({ axis: "x" });
            }

            setScrollBar();
            $('.grpoints .grey').digits();

            var faw = $('.filled-area').text();
            $('.filled-area').css('width', faw);

            var dh = $(document).height();
            $('.opac-wrap').height(dh);

            $(window).resize(function () {
                setScrollBar();
            });
            //	$('.filled-area').slideRight();

            //var lof = $('.lof').outerHeight();
            // $('.lm').height(lof);

            /*
            var pos = $(".mcr").offsetParent();
            var ppp = pos.position();
            var position = $('.mcr').position();
            $('.pic-holder').css({ 'top': position.top, 'left': position.left });
                      
            var mcr = $(".mcr").position();
            var map = $(".map").position();
            var top = parseInt(map.top) - parseInt(mcr.top) - 18;
            var left = parseInt(mcr.left) - parseInt(map.left)-18;

            $('.pic-holder').css({ 'top': top });

            $(window).resize(function () {

            var mcr = $(".mcr").position();
            var map = $(".map").position();
            var top = parseInt(map.top) - parseInt(mcr.top) - 18;
            var left = parseInt(mcr.left) - parseInt(map.left) - 18;

            $('.pic-holder').css({ 'top': top });
            //$('.pic-holder').css({ 'top': top, 'left': left });
            //alert("pos");
            }); */
        });

        function ondivclick() {
            __doPostBack('ctl00$ContentPlaceHolder1$LinkButton1', '')
        }
        
    </script>   
    <script type="text/javascript" src="Scripts/canvas-draw.js"></script>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Button ID="_editPopupButton" runat="server" Text="Edit Contact" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeCongratsMessageDiv" runat="server" BackgroundCssClass="modalBackground"
            RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
            PopupControlID="_CongratsMessageDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
            BehaviorID="EditModalPopupMessage">
        </asp:ModalPopupExtender>
        <div class="_popupButtons" style="display: none">
            <input id="_okPopupButton" value="OK" type="button" />
            <input id="_cancelPopupButton" value="Cancel" type="button" />
        </div>
        <div id="_CongratsMessageDiv" class="congrats-cont" style="display: none;">
            <uc:Congrats ID="ucCongratsMessage" runat="server" />
        </div>

        <%--popup for target congratulations--%>
        <%--<asp:Button ID="_editPopupButton1" runat="server" Text="Edit Contact" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeTargetCongratsMessageDiv" runat="server" BackgroundCssClass="modalBackground"
            RepositionMode="None" TargetControlID="_editPopupButton1" ClientIDMode="AutoID"
            PopupControlID="_TargetCongratsMessageDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
            BehaviorID="EditModalPopupTargetMessage">
        </asp:ModalPopupExtender>
        <div class="_popupButtons" style="display: none">
            <input id="_okPopupButton1" value="OK" type="button" />
            <input id="_cancelPopupButton1" value="Cancel" type="button" />
        </div>
        <div id="_TargetCongratsMessageDiv" class="congrats-cont" style="display: none;">
            <uc:TargetCongrats ID="ucTargetCongratsMessage" runat="server" />
        </div>--%>
        <%--end popup for target congratulations--%>
        <%--popup for award congratulations--%>
        <asp:Button ID="_editPopupButton2" runat="server" Text="Edit Contact" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeAwardCongratsMessageDiv" runat="server" BackgroundCssClass="modalBackground"
            RepositionMode="None" TargetControlID="_editPopupButton2" ClientIDMode="AutoID"
            PopupControlID="_AwardCongratsMessageDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
            BehaviorID="EditModalPopupAwardMessage">
        </asp:ModalPopupExtender>
        <div class="_popupButtons" style="display: none">
            <input id="_okPopupButton2" value="OK" type="button" />
            <input id="_cancelPopupButton2" value="Cancel" type="button" />
        </div>
        <div id="_AwardCongratsMessageDiv" class="congrats-cont" style="display: none;">
            <uc:AwardCongrats ID="ucAwardCongrats" runat="server" />
        </div>
        <%--end popup for award congratulations--%>

        <%--popup for password change--%>
        <asp:Button ID="_editPopupChangePass" runat="server" Text="Edit Password" Style="display: none" />
        <asp:ModalPopupExtender ID="mpeChangePassDiv" runat="server" BackgroundCssClass="modalBackground"
            RepositionMode="None" TargetControlID="_editPopupChangePass" ClientIDMode="AutoID"
            PopupControlID="_ChangePassMessageDiv" OkControlID="Button2" CancelControlID="Button3"
            BehaviorID="ChangePasswordMessage">
        </asp:ModalPopupExtender>
        <div class="_popupButtons" style="display: none">
            <input id="Button2" value="OK" type="button" />
            <input id="Button3" value="Cancel" type="button" />
        </div>
        <div id="_ChangePassMessageDiv" style="display: none;" class="popup-cyan">
            <uc:ChangePassword ID="ucChangePassword"  runat="server" />
        </div>
        <%--end popup for password change--%>

        <div class="top-banner">
            <div class="logo">
                <img src="images/logo.png" />
            </div>
            <div class="banner">
                <div style="color: White;position:relative;">
                    <asp:LinkButton ID="lkbChang" runat="server" Text="<%$ Resources:TestSiteResources, ChangePassword %>"
                        OnClick="lkbChang_Click" ForeColor="White"></asp:LinkButton>
                    |
                    <%--                            <asp:LinkButton ID="lnkbtnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
                        OnClick="lnkbtnLogout_Click" ForeColor="White" PostBackUrl="~/Login.aspx"></asp:LinkButton>--%>
                    <div class="green-wrapper edit anch-btn">
                        <asp:LinkButton ID="lnkbtnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
                            CssClass="green" Width="70px" OnClick="lnkbtnLogout_Click1">LinkButton</asp:LinkButton>
                    </div>
                </div>
                <!--<div class="acme-inc">
                </div>-->
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="body-cont">
            <div class="sec-left">
                <div class="avatar">
                    <asp:Image ID="imgCurrentImage" runat="server" ImageUrl="~/PlayerPanel/Images/imagesNo.jpeg"
                        Width="96px" Height="96px" />
                </div>
            </div>
            <div class="sec-right">
                <div class="profile-cont">
                    <div class="block1">
                        <div class="user-n">
                            <asp:Literal ID="lblFullName" runat="server"></asp:Literal></div>
                        <div class="user-edit">
                            <asp:Label ID="lblUserRole" runat="server"></asp:Label>
                            <div class="green-wrapper edit">
                                <asp:Button ID="btnEditProfile" runat="server" Text="<%$ Resources:TestSiteResources, EditB %>"
                                    OnClick="btnEditProfile_Click" CssClass="green" Width="70px"></asp:Button>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="false">LinkButton</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="profile-right">
                    </div>
                    <div class="inbox">
                        <asp:Button ID="btnMessages" runat="server" OnClick="btnMessages_Click" ToolTip="Send Message">
                        </asp:Button>
                        <div class="noti" id="noti" runat="server">
                            <asp:Literal ID="lblMessageNotification" runat="server"></asp:Literal>
                        </div>
                    </div>                            
                    <div class="clear">
                    </div>
                </div>
                <div class="fl-cont">
                    <div class="filling">
                        <div class="filled-area" style="width: 5%;">
                            <asp:Literal ID="lblPerformance" runat="server" Text=""></asp:Literal>
                        </div>
                    </div>
                    <div class="levels levels-home">
                        <%--<asp:Label ID="lblLevel" runat="server" Text="Level 1" Visible="false"></asp:Label>
                        <img src="images/level-3.png" width="86" height="82" />     ImageUrl="images/star_yellow_1.png"--%>
                        <asp:Image ID="LevelStar" runat="server" width="86" height="82" AlternateText="No Image"  />
                    </div>
                    <div class="fl-right">
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
            <div class="sec-left tm">
                <div class="box rel lm awpoints">
                    <uc:Awards ID="ViewAwards" runat="server" />
                    <div class="clear">
                    </div>
                    <div class="total">
                        <asp:Literal ID="lblTotal" runat="server" Text=""></asp:Literal></div>
                    <div class="green-wrapper fl awards">
                        <asp:Button ID="lbtnAwards" runat="server" Text="<%$ Resources:TestSiteResources, AwardsB %>"
                            CssClass="green" OnClick="lbtnAwards_Click"></asp:Button>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="upHome" runat="server">
                <ContentTemplate>
                    <div class="sec-right tm lof mr10pxi">
                        <div class="box-2 mapb">
                            <div class="map" onclick="ondivclick();" style="cursor: pointer;">
                                <canvas id="myCanvas"> </canvas>
                                <img id="MapImage" runat="server" class="my-map" />
                                <uc:Map ID="ucMap" runat="server" />
                            </div>
                            <div class="mainbox tm mlm13px mrm10btm">
                                <div class="green-wrapper fl pag">
                                    <asp:Button class="green" ID="btnGame" Text="<%$ Resources:TestSiteResources, PlayAGame %>"
                                        runat="server" OnClick="btnGame_Click" />
                                    <%--OnClientClick="return false;"--%>
                                </div>
                                <div class="green-wrapper fl pag">
                                    <asp:Button ID="btnRedeemPoints" runat="server" CssClass="green" Text="<%$ Resources:TestSiteResources, RedeemPoints %>"
                                        OnClick="btnRedeemPoints_Click" />
                                </div>
                                <div class="mainbox-right">
                                </div>
                                <div class="grey-wrapper fr grpoints">
                                    <asp:Label ID="lblScore" runat="server" Text="0" CssClass="grey"></asp:Label>
                                    <%-- <asp:Button ID="lblScore" runat="server" Text="0" CssClass="grey" OnClientClick="return false;">--%>
                                    <%--  </asp:Button>--%>
                                    <%--<input type="button" class="grey" value="1,203" />--%>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="clear">
                    </div>
                   
                        <asp:Panel runat="server">
                            <div  class="contest-footer-container" id="scrollbar2">
                                <div class="viewport">
                                    <uc:Contests ID="Contest1" runat="server" />
                                </div>
                                <div class="scrollbar">
                                    <div class="track">
                                        <div class="thumb">
                                            <div class="end">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                        </asp:Panel>
                    <asp:UpdateProgress ID="uprogressHome" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="upHome">
                        <ProgressTemplate>
                            <div style="background-color: Teal; filter: alpha(opacity=80); opacity: 0.80; width: 100%;
                                top: 0px; left: 0px; position: fixed; height: 100%; z-index:9999;">
                            </div>
                            <div class="updateProgress">
                                <table width="100%">
                                    <tr>scro
                                        <td style="width: 30%">
                                            <img src="../Images/loading-small.gif" alt="wait" />
                                        </td>
                                        <td style="width: 70%" align="left">
                                            <span style="font-size: medium; font-weight: bold; color: #FFFFFF">
                                                <asp:Literal ID="ltProcessing" runat="server" Text="<%$ Resources:TestSiteResources, Processing %>"></asp:Literal>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

