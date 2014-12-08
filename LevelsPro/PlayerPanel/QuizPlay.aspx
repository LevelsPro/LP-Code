<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="QuizPlay.aspx.cs" Inherits="LevelsPro.PlayerPanel.QuizPlay" %>

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
                <asp:Literal ID="ltlName" runat="server"></asp:Literal></div>
            <div class="green-wrapper logout">
                <asp:Button ID="btnLogout" runat="server" CssClass="green" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" OnClick="btnLogout_Click" />
            </div>
            <div class="clear">
            </div>
        </div>
        
        <div class="qbody">
        
              

            <asp:UpdatePanel ID="upQuiz" runat="server">
                <ContentTemplate>

                    <asp:Label ID="lblMainQuizTime" runat="server" Text="Label" Visible="False"></asp:Label>
                    
                    <asp:Timer
                            ID="TimerQuestion" runat="server" OnTick="TimerQuestion_Tick" Interval="1000">
                        </asp:Timer>

                    <div class="quiz-question">
                        
                        <div class="tophead">
                            <asp:Literal ID="ltlQuestionNumber" runat="server"></asp:Literal>
                        </div>                       
                        
                        <asp:Image ID="imgQuestion" Width="283" Height="188" CssClass="quiz-qimg fl"
                                        runat="server" AlternateText="Question" />

                        <div class="quiz-question-text">
                            <asp:Literal ID="ltQuestion" runat="server"></asp:Literal>
                        </div>
                        <div class="clear">
                        </div>
                        <div class="slide-cont">
                            <div class="slider">
                                <div class="knob">
                                   <%-- <asp:Literal ID="ltQuestionTime" runat="server"></asp:Literal>--%>
                                    <asp:Label ID="lblTimeQuestion" runat="server" Text="0"></asp:Label>
                                    </div>
                                <div id ="progressBar" runat="server" class="filled">

                                <%--<progress id="progressBar" value="100" max="100" style="width:100%;"></progress>--%>
                                <asp:HiddenField ID="hdDeductionTime" runat="server" />                                 
                                </div>                              

                            </div>
                      
                            <div class="my-points">
                                <asp:Label ID="ltScore" runat="server" Text="0"></asp:Label>&nbsp;<asp:Literal ID="ltP" runat="server" Text="<%$ Resources:TestSiteResources, Points %>" Visible="true"></asp:Literal>
                            </div>
                            
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    
                     <div class="qq-left-btns">
                        
                        <asp:Button ID="btnAnswer1" runat="server" OnClick="btnAnswer1_Click" Class="qbtn option" />
                        
                        <asp:Button ID="btnAnswer2" runat="server" Text="Answer2" OnClick="btnAnswer2_Click" Class="qbtn option" />
                        
                        <asp:Button ID="btnAnswer3" runat="server" Text="Answer3" OnClick="btnAnswer3_Click" Class="qbtn option" />
                        
                        <asp:Button ID="btnAnswer4" runat="server" Text="Answer4" OnClick="btnAnswer4_Click" Class="qbtn option" />
                    </div>
                    
                    <div class="qq-right-btns">
                    
                    <asp:ImageButton ID="AddSeconds" ImageUrl="images/plus-5-sec.png" width="85" 
                            height="137" runat="server" onclick="AddSeconds_Click" />
                     
                     <asp:ImageButton ID="ReplaceQuestion" ImageUrl="images/replace-question.png" 
                            width="85" height="137" runat="server" onclick="ReplaceQuestion_Click" />
                      
                      <asp:ImageButton ID="ReduceChoices" ImageUrl="images/reduce-choices.png" 
                            width="85" height="137" runat="server" onclick="ReduceChoices_Click" />
                    </div>

                   <div class="ans-cont" runat="server" id="explain" visible="false">
                    <asp:Label ID="lblExplain" runat="server" Visible="false"></asp:Label>
                    <asp:Button ID="btnNext" runat="server" class="next-btn" Visible="False" 
                        onclick="btnNext_Click" />
	               </div>
                    
                    <div class="clear">
                    </div>
                    <asp:Button ID="btnCnfrm" runat="server"  class="confirm-q fr"  OnClick="btnCnfrm_Click"
                        Visible="False" />

                </ContentTemplate>
            </asp:UpdatePanel>
                  
                    <%--<asp:Label ID="lblUserQuizTime" runat="server" Text="Label"></asp:Label>--%>
                


        </div>
    </div>
</asp:Content>
