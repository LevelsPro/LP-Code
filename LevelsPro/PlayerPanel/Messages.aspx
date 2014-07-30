<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="Messages.aspx.cs" Inherits="LevelsPro.PlayerPanel.Messages" %>

<%@ Register TagPrefix="uc" TagName="Profile" Src="~/PlayerPanel/UserControls/uc_Profile.ascx" %>
<%@ Register TagPrefix="uc" TagName="MessageDetails" Src="~/PlayerPanel/UserControls/uc_MessageDetails.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="ucComposeMessage" Src="~/PlayerPanel/UserControls/uc_ComposeMessage.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script src="Scripts/fontResizer.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);
            //	$('.filled-area').slideRight();


        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
    </script>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="top-b">
            <div class="green-ar-wrapper fl">
                <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, HomeAdmin %>"
                    PostBackUrl="~/PlayerPanel/PlayerHome.aspx" CssClass="green-ar"></asp:Button>
            </div>
            <div class="user-nt">
                <asp:Label ID="lblName" runat="server"></asp:Label></div>
            <div class="green-wrapper logout">
                <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
                    CssClass="green" OnClick="btnLogout_Click"></asp:Button>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="body-cont">
            <uc:Profile ID="ViewProfile" runat="server" />
            <asp:HiddenField ID="hfShowAll" runat="server" />
            <div class="clear">
            </div>
            <div class="box brd mt10 m10px p10px">
                <div class="orange-wrapper show-all fl">
                    <asp:Button ID="btnShowAll" Text="<%$ Resources:TestSiteResources, ShowAll %>" runat="server" OnClick="btnShowAll_Click"
                        CssClass="orange"></asp:Button>
                </div>
                <div class="green-wrapper fl pag">
                    <asp:Button ID="btnShowUnRead" Text="<%$ Resources:TestSiteResources, ShowUnread %>" runat="server" OnClick="btnShowUnRead_Click"
                        CssClass="green"></asp:Button>
                </div>
                <div class="green-wrapper fr cm">
                    <asp:Button ID="btnComposeMessage" Text="<%$ Resources:TestSiteResources, ComposeMessage %>" runat="server" OnClick="btnComposeMessage_Click"
                        CssClass="green"></asp:Button>
                </div>
                <div class="clear">
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
                            <asp:DataList ID="dlMessages" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                                Width="100%" OnItemCommand="dlMessages_ItemCommand" OnItemDataBound="dlMessages_ItemDataBound">
                                <ItemTemplate>
                                    <div class="msgs-item">
                                        <asp:Image ID="imgUser" runat="server" Width="70px" Height="70px" CssClass="msg-ico"
                                            ImageUrl='<%# Eval("Player_Thumbnail").ToString().Trim() != "" ? ConfigurationManager.AppSettings["PlayersThumbPath"].ToString() + Eval("Player_Thumbnail") : "Images/imagesNo.jpeg"  %>' />
                                        <%--ImageUrl='<%# "~/view-file.aspx?type=userid&userid=" + Eval("From_UserID") %>'--%>
                                        <asp:LinkButton ID="lbtnView" runat="server" CommandName="ViewPopup" CommandArgument='<%# Eval("ID")%>'
                                            ForeColor="Black">
                                            <div class="msg-det">
                                                 <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, From %>"></asp:Label>
                                                <asp:Literal ID="lblFrom" runat="server" Text='<%# Eval("FullName") %>'></asp:Literal><br />
                                                  <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, Subject %>"></asp:Label>
                                                <asp:Literal ID="lblSubject" runat="server" Text='<%#Eval("Message_Subject")%>'></asp:Literal><br />
                                               <asp:Label ID="Label3" runat="server" Text="<%$ Resources:TestSiteResources, Date %>"></asp:Label> 
                                                <asp:Literal ID="lblDate" runat="server" Text='<%# Convert.ToDateTime(Eval("Sent_Date")).ToString("MMMM dd,yyyy") %>'></asp:Literal>
                                            </div>
                                        </asp:LinkButton>
                                        <asp:Label ID="lblIsRead" runat="server" Text='<%#Eval("IsRead")%>' Visible="false"></asp:Label>
                                        <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="DeleteMsg" CommandArgument='<%# Eval("ID")%>'
                                            ImageUrl="Images/close.png" CssClass="ca-img" Visible="false" OnClientClick="return confirm('Are you sure you want to delete this message?')" />
                                        <asp:Image ID="imgUnread" runat="server" ImageUrl="Images/alert.png" CssClass="ca-img" />
                                        <%--<img src="images/alert.png" class="ca-img" />--%>
                                        <div class="clear">
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <%--<ItemStyle CssClass="award-cont" />--%>
                            </asp:DataList>
                        </div>
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
                    <%--<asp:UpdatePanel ID="upComposeMessages" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
                    <div id="_ComposeMessageDiv" class="box pd-popup" style="display: none;">
                        <uc:ucComposeMessage ID="ucComposeMessage" runat="server" />
                    </div>
                    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
                    <asp:Button ID="Button1" runat="server" Text="Edit Contact" Style="display: none" />
                    <asp:ModalPopupExtender ID="mpeViewMessageDetailsDiv" runat="server" BackgroundCssClass="modalBackground"
                        RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
                        PopupControlID="_ViewMessageDetailsDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
                        BehaviorID="EditModalPopupDetails">
                    </asp:ModalPopupExtender>
                    <div class="_popupButtons" style="display: none">
                        <input id="Button2" value="OK" type="button" />
                        <input id="Button3" value="Cancel" type="button" />
                    </div>
                    <%--<asp:UpdatePanel ID="upViewMessageDetails" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
                    <div id="_ViewMessageDetailsDiv" class="box pd-popup" style="display: none;">
                        <uc:MessageDetails ID="ucViewMessageDetails" runat="server" />
                    </div>
                    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
