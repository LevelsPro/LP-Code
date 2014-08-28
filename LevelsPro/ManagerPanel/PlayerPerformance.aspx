<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerPanel/Manager.master" AutoEventWireup="true"
    CodeBehind="PlayerPerformance.aspx.cs" Inherits="LevelsPro.ManagerPanel.PlayerPerformance" EnableEventValidation="false" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <%@ Register TagPrefix="uc" TagName="ucComposeMessage" Src="~/ManagerPanel/UserControls/uc_ComposeMessagePlayer.ascx" %>
    <%@ Register TagPrefix="uc" TagName="ucViewProgressDetails" Src="~/ManagerPanel/UserControls/uc_KpiUpdate.ascx" %>
   <%--  <%@ Register TagPrefix="uc" TagName="MessageDetails" Src="~/ManagerPanel/UserControls/uc_AssignAwards.ascx" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.uniform.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#scrollbar1').tinyscrollbar();
            $('#scrollbar2').tinyscrollbar();

            
            var h = $('.scrollbar').height();
            h = h - 11;
            $('.scrollbar').css("height", h);

            var stripw = $('.profile-cont').width();
            $('.block1').width(stripw - 92);

            $(window).resize(function () {
                var stripw = $('.profile-cont').width();
                $('.block1').width(stripw - 92);
            });

        });
    </script>
    <script type="text/javascript">
    
        $(function () {
            var $min;

            $(".styleThese").find("select").not(".skipThese").uniform();\
           
            

        });
    </script>
   
    <%-- <style type="text/css">
        .blue-bar
        {
            background: #000;
            width:80%;
            float:left;
        }
        
        .blue-bar .filled
        {
            font-size: 24px;
            color: #FFF;
            display: block;
            padding: 3px 10px;
            background: #00abff; /* Old browsers */ /* IE9 SVG, needs conditional override of 'filter' to 'none' */
            background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iIzAwYWJmZiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiMwMDU1ZmYiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
            background: -moz-linear-gradient(top, #00abff 0%, #0055ff 100%); /* FF3.6+ */
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#00abff), color-stop(100%,#0055ff)); /* Chrome,Safari4+ */
            background: -webkit-linear-gradient(top, #00abff 0%,#0055ff 100%); /* Chrome10+,Safari5.1+ */
            background: -o-linear-gradient(top, #00abff 0%,#0055ff 100%); /* Opera 11.10+ */
            background: -ms-linear-gradient(top, #00abff 0%,#0055ff 100%); /* IE10+ */
            background: linear-gradient(to bottom, #00abff 0%,#0055ff 100%); /* W3C */
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#00abff', endColorstr='#0055ff',GradientType=0 ); /* IE6-8 */
        }
        
        .award-cont
        {
            margin-bottom: 23px;
            padding-bottom: 23px;
            width: 100%;
        }--%>
    <%--</style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


       
    <div class="container">
        <div class="top-b">
            <div class="green-ar-wrapper fl">
                <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, HomeAdmin %>"
                    PostBackUrl="~/ManagerPanel/TeamPerformance.aspx" CssClass="green-ar"></asp:Button>
            </div>
            <div class="user-nt">
                <asp:Literal ID="lblName" runat="server"></asp:Literal></div>
            <div class="green-wrapper logout">
                <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
                    CssClass="green" OnClick="btnLogout_Click"></asp:Button>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="body-cont">
            <div>
                <div class="sec-left">
                    <div class="avatar">
                        <asp:Image ID="imgCurrentImage" runat="server" Width="96px" Height="96px" ImageUrl="~/ManagerPanel/Images/imagesNo.jpeg" />
                    </div>
                </div>
                <div class="sec-right">
                    <div class="profile-cont">
                        <div class="block1">
                            <div class="user-n">
                                <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                                </div>
                            <div class="user-edit">
                            <div class="green-wrapper edit">
                                    <asp:Button ID="btnEditProfile" runat="server" Text="<%$ Resources:TestSiteResources, EditB %>"
                                        CssClass="green" Width="70px" OnClick="btnEditProfile_Click"></asp:Button>
                                </div>
                                <span><asp:Label ID="lblUserRole" runat="server"></asp:Label></span>
                            </div>
                        </div>
                       
                        <div class="profile-right">
                        </div>
                        <div class="inbox">
                        <asp:Button ID="btnMessages" runat="server" OnClick="btnMessages_Click" 
                                ToolTip="Send Messages" />

                            <div class="noti"><asp:Literal ID="lblMessageNotification" runat="server"></asp:Literal></div>
                        </div>
                        <%--<asp:Button ID="btnMessages" runat="server" CssClass="inbox" 
                            onclick="btnMessages_Click">
                            </asp:Button>--%>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="box brd mt10 m10px p10px">
                    <div class="green-ar-wrapper fl m10px">
                        <asp:Button ID="btnBack1" runat="server" Text="<%$ Resources:TestSiteResources, Back %>"
                            PostBackUrl="~/ManagerPanel/TeamPerformance.aspx" class="green-ar" >
                        </asp:Button>
                    </div>
                    <div class="green-wrapper fr pag m10pxer">
                    <asp:Button  ID="btnMes" runat="server" class="green" 
                            Text="Send Message" onclick="btnMes_Click" />
                            <%--<%$ Resources:TestSiteResources, Messages %>--%>
                       <%-- <input type="button" class="green" value="<%$ Resources:TestSiteResources, Messages %>">--%>
                    </div>
                    <div class="green-wrapper fr pag m10px">
                    <asp:Button  ID="btnawrd" runat="server" class="green" 
                            Text="<%$ Resources:TestSiteResources, AwardsB %>" onclick="btnawrd_Click" />
                        <%--<input type="button" class="green" value="<%$ Resources:TestSiteResources, AwardsB %>">--%>
                    </div>
                    <div class="clear">
                    </div>
                    <div id ="MainColor" runat ="server" class="level-cont-red">
                        <asp:Image ID="Image1" class="lvl-img" runat="server" Width="75" Height="75" ImageUrl="~/ManagerPanel/Images/imagesNo.jpeg" />
                        <div class="lvl-desc">
                            <h1 class="lvl">
                                <asp:Literal ID="lblPlayerName1" runat="server" /><span></span></h1>
                            <%--<div class="desc">
                                Expectation of completion: 45%</div>--%>
                                <h1 class="lvl">
                               <asp:Literal ID="lblLevel1"
                                    runat="server" />
                                </h1>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <%-- <h2>
       <asp:Label ID="lblPlayerPerformance" runat="server" Text="<%$ Resources:TestSiteResources, PlayerPerformance %>"></asp:Label> 
    </h2>--%>
                    <%-- <br />--%>
                    <%--   <div style="width: 600px;text-align:right;">
        <asp:Label ID="lblPlayerName1" runat="server" Font-Bold="true"></asp:Label>
    </div>    
    <br />
    <div style="width: 600px;text-align:center;">
        <asp:Label ID="lblLevel1" runat="server" Font-Bold="true"></asp:Label>
    </div>
    <br />
    <br />--%>
                    <%--<div style="width: 40%; font-weight: bold; float: left;text-align:right;">
                   <asp:Label ID="lblGoal" runat="server" Text="<%$ Resources:TestSiteResources, Goal %>"></asp:Label> 
                    <%# Eval("Target_Value")%></div>
                <div style="float:left; width:20%;text-align:center;font-weight: bold;">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, ToGo %>"></asp:Label> 
                </div>--%>
                    <%-- <div style="width: 600px;text-align:center;">
        <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" onclick="btnBack_Click" />
    </div>--%>
                    <div class="manager-cont" id="scrollbar1">
                        <div class="scrollbar">
                            <div class="track">
                                <div class="thumb">
                                    <div class="end">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="viewport mo" style="height:300px">
                            <div class="overview">
                                <asp:DataList ID="dlProgressDetail" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                                    RepeatLayout="Table" Width="100%" 
                                    OnItemDataBound="dlProgressDetail_ItemDataBound" 
                                    onitemcommand="dlProgressDetail_ItemCommand" >
                                    <ItemTemplate>
                                    <asp:LinkButton ID="lbtnView" runat="server" CommandName="ViewPopup" CommandArgument='<%# Eval("Target_ID") + ";" + Eval("score")  + "&" +Eval("Target_Value")  + "(" +Eval("KPI_name") + ")" +Eval("KPI_ID") + "^" +Eval("Points") %>' Font-Underline="false" ForeColor="Black">
                                        <div class="exp fl">
                                            <asp:Label ID="lblname" Text='<%# Eval("KPI_name")%>' runat="server"></asp:Label>
                                            <asp:Label ID="lblTargetValue" Text='<%# Eval("Target_Value")%>' runat="server" Visible="false"></asp:Label>
                                        </div>
                                        <div class="mo-filling fl">
                                            <asp:Label ID="lblCurrent" runat="server" Text='<%# Eval("current_percentage")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("PlayerStatus")%>' Visible="false"></asp:Label>
                                            <span id="lblclass" runat="server" class="red-bar">
                                                <%--<%# Eval("current_percentage")%>%--%>
                                            </span>
                                        </div>
                                        <div class="mo-perc fl">
                                            <%# Eval("current_percentage")%>%
                                        </div>
                                        <div class="clear">
                                        </div>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="mo-cont" />
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                    <div class="mo-hr">
                    </div>
                  <div class="mo-cont">
                     
                        <div class="mo-lltext fl">
                        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources,  RemainingHours %>"></asp:Label>
                           </div>
                        <div class="mo-perc fl">
                            <asp:Label ID="lblHours" runat="server"></asp:Label>
                        <div class="clear">
                        </div>
                    </div>
                    
                    <div class="mo-cont">
                     
                        <div class="mo-lltext fl">
                         <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources,  ExpectationTime %>"></asp:Label>
                          </div>
                        <div class="mo-perc fl">
                            <asp:Label ID="lblLike" runat="server" ></asp:Label></div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional"><ContentTemplate>
 
 <asp:Button ID="Button1" runat="server" Text="Edit Contact" Style="display: none" />
    <asp:ModalPopupExtender ID="mpeViewProgressDetailsDiv" runat="server" BackgroundCssClass="modalBackground"
        RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
        PopupControlID="_ViewProgressDetailsDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
        BehaviorID="EditModalPopupPost">
    </asp:ModalPopupExtender>
    <div class="_popupButtons" style="display: none">
        <input id="Button2" value="OK" type="button" />
        <input id="Button3" value="Cancel" type="button" />
    </div>
   
            <div id="_ViewProgressDetailsDiv" class="box pd-popup" style="display: none;">
                <uc:ucViewProgressDetails ID="ucViewProgressDetails" runat="server" />
            </div>

     <asp:Button ID="_editPopupButton" runat="server" Text="Edit Contact" Style="display: none" />
                    <asp:ModalPopupExtender ID="mpeComposeMessageDiv" runat="server" BackgroundCssClass="modalBackground"
                        RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
                        PopupControlID="_ComposeMessageDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
                        BehaviorID="EditModalPopupMessage">
                    </asp:ModalPopupExtender>
                    <div class="_popupButtons" style="display: none">
                        <input id="_okPopupButton" value="OK" type="button" />
                        <input id="_cancelPopupButton" value="Cancel" type="button" />
                    </div>
                    
                    <div id="_ComposeMessageDiv" class="box pd-popup" style="display: none;">
                        <uc:ucComposeMessage ID="ucComposeMessage" runat="server" />
                    </div>
                  

     
  <%--  <asp:Button ID="Button1" runat="server" Text="Edit Contact" Style="display: none" />
                    <asp:ModalPopupExtender ID="mpeViewMessageDetailsDiv" runat="server" BackgroundCssClass="modalBackground"
                        RepositionMode="None" TargetControlID="Button1" ClientIDMode="AutoID"
                        PopupControlID="_ViewMessageDetailsDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
                        BehaviorID="EditModalPopupDetails">
                    </asp:ModalPopupExtender>
                    <div class="_popupButtons" style="display: none">
                        <input id="Button2" value="OK" type="button" />
                        <input id="Button3" value="Cancel" type="button" />
                    </div>

                    <div id="_ViewMessageDetailsDiv" class="box pd-popup" style="display: none;">
                        <uc:MessageDetails ID="ucViewMessageDetails" runat="server" />
                    </div>--%>
                 
                </ContentTemplate></asp:UpdatePanel>
               
</asp:Content>
