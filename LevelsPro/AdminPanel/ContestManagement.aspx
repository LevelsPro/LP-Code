<%@ Page Title="Manage Contest" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="ContestManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.ContestManagement" %>

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
    <style type="text/css">
        .btnq
        {
            margin-top:5px !important; 
            margin-right:13px !important;   
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>"
            PostBackUrl="~/AdminPanel/AdminHome.aspx" CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, ContestManagement %>"></asp:Label>
        </div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
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
                    <asp:DataList ID="dlContest" runat="server" Width="100%" 
                        OnItemCommand="dlContest_ItemCommand" onitemdatabound="dlContest_ItemDataBound">
                        <ItemTemplate>
                            <div class="level-cont-grey32 fl" style="width:512px;">
                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/AdminPanel/Images/del-img.png"
                                class="fl" Width="50" Height="50" OnClientClick="return confirm('Are you sure to delete this Contest.');" CommandName="DeleteContest" CommandArgument='<%# Eval("ContestID") %>' />&nbsp;
                                <asp:ImageButton ID="imgDuplicate" runat="server" ImageUrl="~/AdminPanel/Images/upd-img.png"
                                class="fl" Width="50" Height="50" OnClientClick="return confirm('Are you sure to duplicate this Contest.');" CommandName="DuplicateContest" CommandArgument='<%# Eval("ContestID") %>' />&nbsp;
                                <asp:Literal ID="ltToDate" runat="server" Visible="false" Text='<%# Eval("ToDate") %>' />
                                <div class="lvl-desc32 fl" style="width:70%;">
                                    <div class="desc32">
                                        <asp:Literal ID="ltContestName" runat="server" Text='<%# Eval("ContestName") %>' />
                                        <asp:Button ID="btnManageContests" runat="server" CssClass="green-btn admin-edit fr btnq"
                                            CommandName="EditContest" Width="100px" CommandArgument='<%# Eval("ContestID") %>'
                                            Text="<%$ Resources:TestSiteResources, Edit %>" />
                                    </div>
                                </div>
                                <br />
                                <div class="clear">
                                </div>
                            </div>
                            <div class="clear"></div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
        <div class="adminprog-cont crt-reward">
            <asp:Button ID="btnNewContest" class="green-btn  create-reward" Text="<%$ Resources:TestSiteResources, CreateNewContest %>" runat="server"
                OnClick="btnNewContest_Click" />
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
