<%@ Page Title="Player Progress" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="PlayerProgress.aspx.cs" Inherits="LevelsPro.AdminPanel.PlayerProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" CssClass="green-btn btn fl" OnClick="btnBack_Click" />
        <div class="user-nt fl ep">
            <asp:Literal ID="ltHeading" runat="server" Text="<%$ Resources:TestSiteResources, PlayerProgress %>"></asp:Literal></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" CssClass="green-btn btn fr"
            OnClick="btnLogout_Click" />
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        <div class="box admin-btns-cont">
            <asp:Button ID="btnMainInfo" runat="server" Text="<%$ Resources:TestSiteResources, MainInfo %>" 
                CssClass="green-btn ad-btns" onclick="btnMainInfo_Click" />
            <asp:Button ID="btnAwards" runat="server" Text="<%$ Resources:TestSiteResources, AwardsB %>" CssClass="green-btn ad-btns"
                OnClick="btnAwards_Click" />
            <asp:Button ID="btnProgress" runat="server" Text="<%$ Resources:TestSiteResources, Progress1 %>" 
                CssClass="yellow-btn ad-btns" onclick="btnProgress_Click" />
            <asp:Button ID="btnRewards" runat="server" Text="<%$ Resources:TestSiteResources, Reward %>" 
                CssClass="green-btn ad-btns" onclick="btnRewards_Click" />
        </div>
        <div class="usercont-right">
            <div class="fl-wrapper user-data np-user-data epr">
                <div class="strip">
                    <asp:Label ID="lblRoleLevel" runat="server" Text="<%$ Resources:TestSiteResources, UserID %>"
                        CssClass="edit-left p42"></asp:Label>
                    <asp:Label ID="lblLevelName" runat="server" CssClass="edit-right p50"></asp:Label>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="fl-wrapper user-data np-user-data epr">
                <div class="strip">
                    <asp:Label ID="lblUserID" runat="server" CssClass="edit-left" Text="<%$ Resources:TestSiteResources, UserID %>"></asp:Label>
                    <asp:Label ID="lblUserIDValue" runat="server" CssClass="edit-right"></asp:Label>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblName" runat="server" CssClass="edit-left" Text="<%$ Resources:TestSiteResources, Name %>"></asp:Label>
                    <asp:Label ID="lblNameValue" runat="server" CssClass="edit-right"></asp:Label>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="manager-cont fl-wrapper flw-epp" id="scrollbar1">
            <div class="scrollbar">
                <div class="track">
                    <div class="thumb">
                        <div class="end">
                        </div>
                    </div>
                </div>
            </div>
            <div class="viewport progadmin">
                <div class="overview">
                    <asp:DataList ID="dlProgress" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                        Width="100%">
                        <ItemTemplate>
                            <div class="epp">
                                <div class="text">
                                    <asp:Label ID="lblKPIID" runat="server" Visible="false" Text='<%# Eval("KPI_ID") %>'></asp:Label>
                                    <asp:Label ID="lblLevelID" runat="server" Visible="false" Text='<%# Eval("Level_ID") %>'></asp:Label>
                                    <%# Eval("KPI_name") %>
                                    <%--Score 100 Points in the Quiz Game--%></div>
                                <asp:TextBox ID="txtScore" runat="server" CssClass="cp" Text='<%# Eval("score") %>'></asp:TextBox>                                
                                <div class="clear">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>                   
                </div>
            </div>
            <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:TestSiteResources, Update %>" CssClass="green-btn btn fr"
                onclick="btnUpdate_Click" />
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
