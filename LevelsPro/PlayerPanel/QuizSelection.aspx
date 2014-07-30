<%@ Page Title="Quizzes And Games" Language="C#" MasterPageFile="~/PlayerPanel/Player.master"
    AutoEventWireup="true" CodeBehind="QuizSelection.aspx.cs" Inherits="LevelsPro.PlayerPanel.QuizSelection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">    
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);
            //	$('.filled-area').slideRight();


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
                <asp:Label ID="lblQuiz" runat="server" Text="<%$ Resources:TestSiteResources, QuizGames1 %>" ></asp:Label>
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
                                    <asp:Image ID="imgQuiz" ImageUrl='<%# Eval("QuizImageThumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["QuizThumbPath"].ToString() + Eval("QuizImageThumbnail") :"Images/placeholder.png" %>' Width="73" Height="72" CssClass="fl"
                                        runat="server" />
                                    <div class="qs-mid">
                                        <span class="sh">
                                            <asp:Literal ID="ltQuizID" runat="server" Text='<%# Eval("QuizID")%>' Visible="false" />
                                            <asp:Literal ID="ltQuizName" runat="server" Text='<%# Eval("QuizName")%>' /></span><br />
                                             <asp:Literal ID="ltPlayableLimit" runat="server" Text='<%# Eval("TimesPlayablePerDay")%>' Visible="false" />
                                      <asp:Label ID="lblQuiz1" runat="server" Text="<%$ Resources:TestSiteResources, YourBest %>" ></asp:Label> 
                                        <asp:Literal ID="ltUserBest" runat="server" />
                                        <br />
                                        <asp:Label ID="lblQuiz" runat="server" Text="<%$ Resources:TestSiteResources, TopScore %>" ></asp:Label> 
                                        
                                        <asp:Literal ID="ltTopScore" runat="server" />
                                    </div>
                                    <div class="already-played" runat ="server" visible="false" id="Played">
                                        <asp:Literal ID="ltDone" runat="server" Text="<%$ Resources:TestSiteResources, youAlreadyPlayed %>"/>
                                    </div>
                                    <div class="green-wrapper fr play-game" runat ="server" id="Play" visible="true">
                                        <asp:Button ID="btnStartQuiz" runat="server" CommandName="StartGame" CommandArgument='<%# Eval("QuizID")%>'
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
