<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerPanel/Manager.master" AutoEventWireup="true"
    CodeBehind="TeamPerformance.aspx.cs" Inherits="LevelsPro.ManagerPanel.TeamPerformance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="ChangePassword" Src="../UserControls/uc_ChangePassword.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <link href="Styles/theme-3.css" rel="stylesheet" type="text/css" />--%>
    <script src="Scripts/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.uniform.js" type="text/javascript">
    </script>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
            $('div.noti:empty').hide();
//            $('.green-wrapper').hover(function () {

//                $(this).css({ 'background-image': 'url("images/btn-spr-right.png")', 'background-position': 'bottom right' });
//                $(this).find('input').css({ 'background-image': 'url("images/btn-spr-left.png")', 'background-position': 'bottom left' });
//            },
//                   function () {

//                       $(this).css({ 'background-image': 'url("images/btn-spr-right.png")', 'background-position': 'top right' });
//                       $(this).find('input').css({ 'background-image': 'url("images/btn-spr-left.png")', 'background-position': 'top left' });

//                   });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            var $min;

            $(".styleThese").find("select").not(".skipThese").uniform();
            var h = $('.scrollbar').height();
            h = h - 11;
            $('.scrollbar').css("height", h);

        });

         
                        
                        

                     
         
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LinkButton ID="lkbChang" runat="server" Text="<%$ Resources:TestSiteResources, ChangePassword %>"
        OnClick="lkbChang_Click" Visible="false"></asp:LinkButton>
    <%--<div class="container-2">
        
        <div class="body-cont">
            <div class="user-info">
                <div class="box avatar brd fl">
                    
                </div>
                <div class="box profile secfl">
                    <div class="block1">
                        <div class="user-n">
                            </div>
                        <div class="user-edit">
                            
                        </div>
                    </div>
                    <div class="block2">
                        <div class="inbox">
                            <div class="noti">
                                222</div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="box brd mt10">
                <p class="ciate-text">
                     associates requiring attention.</p>
                <div class="manager-cont" id="scrollbar1">
                    <div class="scrollbar">
                        <div class="track">
                            <div class="thumb">
                                <div class="end">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="viewport lvl-exp">
                        <div class="overview">
                                                        
                        </div>
                    </div>
                </div>
                <select class="manager-sortby">
                    <option>Sort By</option>
                </select>
            </div>
        </div>
    </div>--%>
    <%--popup for password change--%>
    <asp:Button ID="_editPopupChangePass" runat="server" Text="Edit Password" Style="display: none" />
    <asp:ModalPopupExtender ID="mpeChangePassDiv" runat="server" BackgroundCssClass="modalBackground"
        RepositionMode="None" TargetControlID="_editPopupChangePass" ClientIDMode="AutoID"
        PopupControlID="_ChangePassMessageDiv" OkControlID="Button2" CancelControlID="Button3"
        BehaviorID="ChangePasswordManager">
    </asp:ModalPopupExtender>
    <div class="_popupButtons" style="display: none">
        <input id="Button2" value="OK" type="button" />
        <input id="Button3" value="Cancel" type="button" />
    </div>
    <div id="_ChangePassMessageDiv" class="popup-cyan" style="display: none;">
        <uc:ChangePassword ID="ucChangePassword" runat="server" />
    </div>
    <%--end popup for password change--%>
    <div class="container">
        <div class="top-b">
            <div class="green-ar-wrapper homebtn">
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
                    <p class="ciate-text">
                        <asp:Literal ID="ltAttentionCount" runat="server" />
                       <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources,  Associates %>"></asp:Label>
                        </p>
                    <div class="manager-cont" id="scrollbar1">
                        <div class="scrollbar">
                            <div class="track">
                                <div class="thumb">
                                    <div class="end">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <style>
                            .lvl-desc
                            {
                                width:auto;
                                margin-left:94px;
                               
                                }
                                
                             .msgs2 a{text-decoration:none;}
                                
                             .level-desk{}
                        </style>
                        <div class="viewport msgs2">
                            <div class="overview">
                                <asp:DataList ID="dlTeam" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                                    Width="100%" RepeatLayout="Table" OnItemCommand="dlTeam_ItemCommand">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnView" runat="server" CommandName="ViewPlayer" CommandArgument='<%# Eval("UserID")%>'
                                            Style="color: Black;">
                                            <asp:Label ID="lbllike" runat="server" Visible="false" Text='<%# Eval("Likelihood")%>'></asp:Label>
                                            <asp:Label ID="lblRemain" runat="server" Visible="false" Text='<%# Eval("remainingHours")%>'></asp:Label>
                                            <asp:Label ID="lblBase" runat="server" Visible="false" Text='<%# Eval("BaseHours")%>'></asp:Label>
                                                <asp:Label ID="lbllevelid" runat="server" Visible="false" Text='<%# Eval("Level_ID")%>'></asp:Label>
                                            <div class='level-cont-<%# Eval("PlayerStatus").ToString().ToLower() %>'>
                                                <asp:Image ID="imgPlayer" runat="server" ImageUrl='<%# Eval("Player_Thumbnail").ToString().Trim() != "" ? ConfigurationManager.AppSettings["PlayersThumbPath"].ToString() + Eval("Player_Thumbnail") : "Images/imagesNo.jpeg"  %>'                                                 
                                                    CssClass="lvl-img" Width="75px" Height="75px" />
                                                <div class="lvl-desc">
                                                    <h1 class="lvl">
                                                        <asp:Literal ID="ltName" runat="server" Text='<%# Eval("PlayerName")%>' />
                                                        <span>
                                                            <asp:Literal ID="ltRole" runat="server" Text='<%# Eval("Role_Name")%>' />
                                                            -
                                                            <asp:Literal ID="lblLevel" runat="server" Text='<%# "Level " + Eval("Level_Position")%>' /></span></h1>
                                                    <div class="desc">
                                                     <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources,  Expectation %>"></asp:Label>
                                                       
                                                        <asp:Label ID="lblPercentage" runat="server" Text='<%#string.Format("{0:0}%", Eval("Likelihood")) %>' /></div>
                                                </div>
                                                <div class="clear">
                                                </div>
                                            </div>
                                        </asp:LinkButton></ItemTemplate><%--<ItemStyle CssClass="level-cont-red" />--%></asp:DataList><%--<div class="level-cont-red">
                                    <img src="images/c1.png" class="lvl-img" width="75" height="75" />
                                    <div class="lvl-desc fl">
                                        <h1 class="lvl">
                                            Jason Johnson <span>Cashier - Level 1</span></h1>
                                        <div class="desc">
                                            Expectation of completion: 45%</div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="level-cont-red">
                                    <img src="images/c2.png" class="lvl-img" width="75" height="75" />
                                    <div class="lvl-desc fl">
                                        <h1 class="lvl">
                                            Jason Johnson <span>Cashier - Level 1</span></h1>
                                        <div class="desc">
                                            Expectation of completion: 45%</div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="level-cont-yellow">
                                    <img src="images/c3.png" class="lvl-img" width="75" height="75" />
                                    <div class="lvl-desc fl">
                                        <h1 class="lvl">
                                            Sam Smith <span>Sales - Level 2</span></h1>
                                        <div class="desc">
                                            Expectation of completion: 65%</div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="level-cont-green">
                                    <img src="images/c4.png" class="lvl-img" width="75" height="75" />
                                    <div class="lvl-desc fl">
                                        <h1 class="lvl">
                                            Sarah White <span>Cashier - Level 1</span></h1>
                                        <div class="desc">
                                            Expectation of completion: 93%</div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="level-cont-green">
                                    <img src="images/c5.png" class="lvl-img" width="75" height="75" />
                                    <div class="lvl-desc fl">
                                        <h1 class="lvl">
                                            James Williams <span>Sales - Level 5</span></h1>
                                        <div class="desc">
                                            Expectation of completion: 100%</div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>
                                <div class="level-cont-green">
                                    <img src="images/c5.png" class="lvl-img" width="75" height="75" />
                                    <div class="lvl-desc fl">
                                        <h1 class="lvl">
                                            Jane Walters <span>Sales - Level 4</span></h1>
                                        <div class="desc">
                                            Expectation of completion: 100%</div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </div>--%></div></div></div><form class="styleThese">
                     </form></div></div></div></div></asp:Content>



                    