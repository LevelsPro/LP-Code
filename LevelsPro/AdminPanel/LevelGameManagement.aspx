<%@ Page Title="Level Game Management" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" AutoEventWireup="true" CodeBehind="LevelGameManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.LevelGameManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <link href="Styles/admin-theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/admin-website.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/AdminHome.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources,  ManageLevelGame%>"></asp:Label>
          </div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        <div class="manager-cont" id="scrollbar1">
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
                    <asp:UpdatePanel ID="upLevelGames" runat="server">
                        <ContentTemplate>
                            <asp:DataList ID="dlLevelGame" runat="server" DataKeyField="GameID" Width="100%" OnItemCommand="dlLevelGame_ItemCommand">
                                <ItemTemplate>
                                    <div class="adminprog-cont">
                                        <h1 class="admin-text ot">
                                            <asp:Literal ID="ltGameName" runat="server" Text='<%# Eval("GameName") %>' /></h1>
                                        <asp:Button ID="btnEditGame" runat="server" CssClass="green-btn admin-edit fr" CommandName="EditGame"
                                            CommandArgument='<%# Eval("GameID") %>' Text="<%$ Resources:TestSiteResources, Edit %>" />
                                        <div class="clear">
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                            <div class="adminprog-cont crt-reward">
                                <asp:Button ID="btnNewGame" class="green-btn create-reward" Text="<%$ Resources:TestSiteResources,  CreateNewGame %>"
                                    runat="server" OnClick="btnNewGame_Click" />
                            </div>                                                       
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
