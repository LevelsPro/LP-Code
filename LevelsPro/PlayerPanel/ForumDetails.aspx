<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="ForumDetails.aspx.cs" Inherits="LevelsPro.PlayerPanel.ForumDetails" %>

<%@ Register TagPrefix="uc" TagName="Profile" Src="~/PlayerPanel/UserControls/uc_Profile.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/jquery.tinyscrollbar.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);
            //	$('.filled-area').slideRight();


        });
    </script>
    <link href="Styles/theme-2.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b">
        <%--<div class="green-btn btn fl">--%>
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, HomeAdmin %>"
            PostBackUrl="~/PlayerPanel/PlayerHome.aspx" CssClass="green-btn btn fl"></asp:Button><%--</div>--%>
        <%--<div class="user-nt fl">--%>
        <asp:Label ID="lblName" runat="server" CssClass="user-nt fl"></asp:Label><%--</div>--%>
        <%--div class="green-btn btn fr">--%>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button><%--</div>--%>
        <div class="clear">
        </div>
    </div>
    <uc:Profile ID="ViewProfile" runat="server" />
    <div class="box brd mt10">
        <div class="btn-nav">
            <asp:Button ID="btnBack" runat="server" CssClass="green-btn btn fl index-btn" Text="Back" PostBackUrl="~/PlayerPanel/PlayerForums.aspx" />
            <asp:Label ID="lblQuestion" CssClass="question-ind fl" runat="server">
            </asp:Label>
        </div>
        <div class="in-cont" id="scrollbar1">
            <div class="scrollbar">
                <div class="track">
                    <div class="thumb">
                        <div class="end">
                        </div>
                    </div>
                </div>
            </div>
            <div class="viewport forum-cont">
                <div class="overview">
                    <asp:DataList ID="dlPostDetails" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                        RepeatLayout="Table" Width="730px" 
                        onitemdatabound="dlPostDetails_ItemDataBound" 
                        onitemcommand="dlPostDetails_ItemCommand" >
                        <ItemTemplate>
                            <table class="f-item-cont" width="100%">
                                <tr>
                                    <td width="20%" align="center" valign="middle">
                                        <asp:Image ID="imgUser" runat="server" ImageUrl='<%# "~/view-file.aspx?type=userid&userid=" + Eval("RepliedBy") %>'
                                            Width="70px" Height="70px" CssClass="fl" />
                                    </td>
                                    <td class="fans-text fl">
                                        <asp:Label ID="RepliedByName" runat="server" Text='<%# Eval("RepliedByName") %>'></asp:Label>
                                        <asp:Label ID="lblReplyDate" runat="server" Text='<%# "(" + Eval("ReplyDate") + ")" %>'></asp:Label><br />
                                        <asp:Label ID="lblReplyMessage" runat="server" Text='<%# Eval("ReplyMessage") %>'></asp:Label><br />
                                    </td>
                                    <td class="like-cont">
                                        <asp:Label ID="lblLikes" runat="server" Text='<%# Eval("Likes")+" Likes" %>'></asp:Label><br />
                                        <asp:Button ID="btnLike" runat="server" Text="Like" CssClass="green-btn like-btn" Enabled='<%#GetLikeStatus(Convert.ToInt32(Eval("ReplyID")))%>' CommandName="Like" CommandArgument='<%#Eval("ReplyID")%>' />
                                    </td>
                                </tr>
                            </table>
                            <div class="clear">
                            </div>
                        </ItemTemplate>
                        <ItemStyle CssClass="award-cont" />
                    </asp:DataList>
                </div>
            </div>
        </div>
        <div class="post-msg-cont">
            <asp:TextBox ID="txtReply" TextMode="MultiLine" CssClass="input-style post-area pm"
                runat="server"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                TargetControlID="txtReply" WatermarkText="Your Answer">
            </asp:TextBoxWatermarkExtender>
            <br />
            <asp:Label ID="lblMsgCount" runat="server" CssClass="msg-count fl">0/200</asp:Label>
            <asp:Button ID="btnReply" runat="server" CssClass="green-btn fr reply-msg" Text="Reply"
                OnClick="btnReply_Click"></asp:Button>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
