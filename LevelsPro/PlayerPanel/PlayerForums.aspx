<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="PlayerForums.aspx.cs" Inherits="LevelsPro.PlayerPanel.PlayerForums"
    EnableEventValidation="false" %>

<%@ Register TagPrefix="uc" TagName="Profile" Src="~/PlayerPanel/UserControls/uc_Profile.ascx" %>
<%@ Register TagPrefix="uc" TagName="ucCreatePost" Src="~/PlayerPanel/UserControls/uc_CreatePost.ascx" %>
<%@ Register TagPrefix="uc" TagName="ucSearchForum" Src="~/PlayerPanel/UserControls/uc_FourmSearch.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-1.6.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.uniform.js" type="text/javascript"></script>    
    <script src="Scripts/fontResizer.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);
            //	$('.filled-area').slideRight();


        });
    </script>
    <script type="text/javascript">
        $(function () {
            var $min;

            $(".styleThese").find("select").not(".skipThese").uniform();
        });
		</script>
    <link href="Styles/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="top-b">
        <div class="green-ar-wrapper fl">
            <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, HomeAdmin %>"
            PostBackUrl="~/PlayerPanel/PlayerHome.aspx" CssClass="green-ar"></asp:Button>            
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
        <uc:Profile ID="ViewProfile" runat="server" />
        <div class="box brd prel mt10 m10px p10px">
            <div class="btn-nav">
                <div class="green-wrapper fl maw mtb10px">
                    <asp:Button ID="btnCreatePost" runat="server" Text="<%$ Resources:TestSiteResources, CreatePost %>"
                OnClick="btnCreatePost_Click" CssClass="green"></asp:Button>
                </div>
                <div class="nav-cont">
                    <asp:Button ID="btnFirstPage1" runat="server" CssClass="first-page fl" OnClick="btnFirstPage_Click" />                    
                    <asp:Button ID="btnBackPage1" runat="server"
                         OnClick="btnBackPage_Click" CssClass="back-page fl" />                                        
                    <div class="simple-btn fl">
                        <asp:Literal ID="lblCurrPage" runat="server" /></div>
                    <asp:Button ID="btnNextPage1" runat="server"
                         OnClick="btnNextPage_Click" CssClass="next-page fl" />
                    <asp:Button ID="btnLastPage1" runat="server"
                     OnClick="btnLastPage_Click" CssClass="last-page fl" />                                        
                    <div class="clear">
                    </div>
                </div>
                <div class="green-wrapper sposition maw m10px">
                    <asp:Button ID="btnSearch" runat="server" OnClientClick="return false;" Text="<%$ Resources:TestSiteResources, Search %>"
                        CssClass="green" OnClick="btnSearch_Click"></asp:Button>
                </div>
                <div class="clear">
                </div>
            </div>
            <asp:HiddenField ID="hdnRowNum" runat="server" />
            <asp:UpdatePanel ID="upForum" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvPosts" runat="server" EmptyDataText="No Record Found." AutoGenerateColumns="false"
                CssClass="forums-grid" GridLines="None" Width="100%" OnRowCreated="gvPosts_RowCreated"
                OnRowDataBound="gvPosts_RowDataBound" PageSize="3">
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="Label4" lD="lblPostID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="<%$ Resources:TestSiteResources, Topic %>" DataField="Topic"
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="65%">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="65%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="<%$ Resources:TestSiteResources, Replies %>" DataField="Replies"
                        ItemStyle-HorizontalAlign="Center" ItemStyle-Width="8%">
                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="<%$ Resources:TestSiteResources, Likes %>" DataField="Likes"
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="8%">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="8%" />
                    </asp:BoundField>
                    <%--<asp:BoundField HeaderText="<%$ Resources:TestSiteResources, LastReply %>" DataField="LastReply"
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30%" />--%>
                    <asp:TemplateField HeaderText="<%$ Resources:TestSiteResources, LastReply %>">
                        <ItemTemplate>
                            <asp:Label ID="Label7" lD="lblLatestDate" runat="server" Text='<%# GetTimeDiff(Convert.ToInt32(Eval("LatestDate")),Eval("LastReply").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings FirstPageImageUrl="~/PlayerPanel/Images/da-left.png" LastPageImageUrl="~/PlayerPanel/Images/da-right.png"
                    Mode="NextPreviousFirstLast" NextPageImageUrl="~/PlayerPanel/Images/sa-right.png"
                    Position="Top" PreviousPageImageUrl="~/PlayerPanel/Images/sa-left.png" />
                <PagerStyle BorderColor="#333300" BorderStyle="Groove" BorderWidth="2px" Height="10px"
                    HorizontalAlign="Center" VerticalAlign="Top" />
                <RowStyle CssClass="even" />
                <AlternatingRowStyle CssClass="odd" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>            
        </div>
    </div>
                       
    <asp:Button ID="_editPopupButton" runat="server" Text="Edit Contact" Style="display: none" />
    <asp:ModalPopupExtender ID="mpeCreatePost" runat="server" BackgroundCssClass="modalBackground"
        RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
        PopupControlID="_CreatePostDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
        BehaviorID="EditModalPopupPost">
    </asp:ModalPopupExtender>
    <div class="_popupButtons" style="display: none">
        <input id="_okPopupButton" value="OK" type="button" />
        <input id="_cancelPopupButton" value="Cancel" type="button" />
    </div>
    <asp:UpdatePanel ID="upCreatePost" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="_CreatePostDiv" class="box forums-popup" style="display: none;">
                <uc:ucCreatePost ID="ucCreatePost" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="_editPopupButtonSearch" runat="server" Text="Edit Contact" Style="display: none" />
    <asp:ModalPopupExtender ID="mpeSearchForum" runat="server" BackgroundCssClass="modalBackground"
        RepositionMode="None" TargetControlID="_editPopupButtonSearch" ClientIDMode="AutoID"
        PopupControlID="_SearchForumDiv" OkControlID="_okPopupButtonSearch" CancelControlID="_cancelPopupButtonSearch"
        BehaviorID="EditModalPopupSearch">
    </asp:ModalPopupExtender>
    <div class="_popupButtons" style="display: none">
        <input id="_okPopupButtonSearch" value="OK" type="button" />
        <input id="_cancelPopupButtonSearch" value="Cancel" type="button" />
    </div>
    <asp:UpdatePanel ID="upSearchForum" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="_SearchForumDiv" class="box forums-popup" style="display: none;">
                <%--<uc:ucSearchForum ID="ucSearchForum" runat="server" />--%>
                <div class="in-cont p-cont">
                    Keyword
                    <br />
                    <br />
                    <asp:TextBox ID="txtKeyword" runat="server" class="input-style post-area" Height="20px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="weKeyword" runat="server" TargetControlID="txtKeyword"
                        WatermarkText="Search">
                    </asp:TextBoxWatermarkExtender>
                    <asp:Label ID="Label1" runat="server" Text="Type:" class="tr-in fl"></asp:Label>
                    <asp:Label ID="Label2" runat="server" class="tr-in fl">
                        <asp:DropDownList ID="ddlType" runat="Server" class="opt">
                            <asp:ListItem Text="Select" Value="-1" />
                        </asp:DropDownList>
                    </asp:Label>
                    <asp:Label ID="lblrole" Text="Role" runat="server" class="tr-in fl"></asp:Label>
                    <asp:Label ID="Label3" runat="server" class="tr-in fl">
                        <asp:DropDownList ID="ddlRole" runat="Server" class="opt">
                            <asp:ListItem Text="Select" Value="-1" />
                        </asp:DropDownList>
                    </asp:Label>
                    <asp:Label ID="lblPlayer" Text="Player" runat="server" class="tr-in fl"></asp:Label>
                    <asp:Label ID="Label5" runat="server" class="tr-in fl">
                        <asp:DropDownList ID="ddlPlayer" runat="Server" class="opt">
                            <asp:ListItem Text="Select" Value="-1" />
                        </asp:DropDownList>
                    </asp:Label>
                    <asp:Label ID="lblDate" Text="Date" runat="server" class="tr-in fl"></asp:Label>
                    <asp:Label ID="Label6" runat="server" class="tr-in fl">
                        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                        <asp:CalendarExtender ID="ceDate" runat="server" TargetControlID="txtDate" Format="yyyy/MM/dd"
                            PopupPosition="BottomRight" FirstDayOfWeek="Monday">
                        </asp:CalendarExtender>
                    </asp:Label>
                    <div class="clear">
                    </div>
                </div>
                <asp:Button ID="btnSearchBy" runat="server" Text="Search" class="green-btn btn fl ps"
                    OnClick="btnSearchBy_Click"></asp:Button>
                &nbsp;
                <asp:Button ID="btnClose" runat="server" Text="Close" class="green-btn btn fl ps">
                </asp:Button>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
