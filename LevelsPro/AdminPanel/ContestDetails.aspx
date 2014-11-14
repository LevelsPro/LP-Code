<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" AutoEventWireup="true"
    CodeBehind="ContestDetails.aspx.cs" Inherits="LevelsPro.AdminPanel.ContestDetails" %>

<%@ Register TagPrefix="uc" TagName="Contests" Src="~/AdminPanel/UserControls/uc_Contests.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $.fn.digits = function () {
            return this.each(function () {
                $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
            })
        }

        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
            $('#scrollbar2').tinyscrollbar({ axis: "x" });

            $('.points-label').digits();


            $('.green-wrapper').each(function () {
                if ($(this).text().match(/^\s*$/) && !$(this).children().length>0) {
                    $(this).hide();
                }
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
    <div class="box top-b options-bar bottom-space">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>"
                PostBackUrl="~/AdminPanel/ContestEdit.aspx"  class="green-btn btn fl"></asp:Button>
        <div class="user-nt fl er">
        <%if (ViewState["userid"] != null) 
          {%>
              <div class="user-nt"><span><%= Session["HeaderName"].ToString() %></span></div>
        <% } %>
        </div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
                class="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <div class="body-container">
            <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="sort-filter" 
                AutoPostBack="true" 
                onselectedindexchanged="ddlSortBy_SelectedIndexChanged" style="display:none;">
                <asp:ListItem Text="Sort By..." Value="0" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Position" Value="PositionClear" ></asp:ListItem>
                <asp:ListItem Text="Name" Value="U_Name"></asp:ListItem>
                <asp:ListItem Text="Points" Value="Score"></asp:ListItem>
            </asp:DropDownList>
            <div class="manager-cont" id="scrollbar1">
                <div class="scrollbar">
                    <div class="track">
                        <div class="thumb">
                            <div class="end">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="viewport progadmincontest">
                    <div class="overview">
                        <asp:DataList ID="dlPlayers" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                            Width="100%" onitemdatabound="dlPlayers_ItemDataBound" 
                            onitemcommand="dlPlayers_ItemCommand1">
                            <ItemTemplate>
                                <div id="itemContainer" runat="server" class="level-cont-grey">
                                    <asp:LinkButton ID="lbtnPlayer" CommandName="LoadPlayer" CommandArgument='<%# Eval("User_ID") %>'
                                    ForeColor="Black" runat="server">
                                        <asp:Image ID="imgPlayer" runat="server" ImageUrl='<%# Eval("Player_Thumbnail").ToString().Trim() != "" ? ConfigurationManager.AppSettings["PlayersThumbPath"].ToString() + Eval("Player_Thumbnail") : "Images/imagesNo.jpeg"  %>' CssClass="lvl-img" Width="75px" Height="75px" />
                                        <div class="lvl-desc fl">
                                        <div class="strip">
                                            <div class="msg-r">
                                                <span class="st <%#Eval("cssClass")%>">
                                                    <asp:Label ID="lblRank1" runat="server" Text='<%#Eval("Position")%>'></asp:Label>
                                                </span>
                                            </div>
                                        </div>
                                        <asp:Label ID="lblUName" CssClass="lvl fl" runat="server" Text='<%#Eval("U_Name")%>'></asp:Label>
                                        <div class="desc fl">
                                            <%#Eval("Role_Name")%>
                                            -
                                            <%#Eval("Site_Name")%>
                                        </div>
                                        <div class="lvl-points fl">
                                            <%#Eval("Score")%>
                                            <br/>
                                            <%#Eval("KPI_measure")%>
                                        </div>
                                    </div>
                                        <div class="clear">
                                        </div>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
        <div class="contest-footer-container" id="scrollbar2">
            <asp:Label ID="lblContestLbl" CssClass="contest-title" runat="server" Text="<%$ Resources:TestSiteResources, Contests %>"></asp:Label>
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
    </div>
</div>
</asp:Content>
