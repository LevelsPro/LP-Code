<%@ Page Title="Site Management" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="SiteManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.SiteManagement" %>

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
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, ManageSites %>"></asp:Label>
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
            <div class="viewport progadmin">
                <div class="overview">
                    <asp:UpdatePanel ID="upgvRoles" runat="server">
                        <ContentTemplate>
                            <asp:DataList ID="dlSite" runat="server" DataKeyField="site_id" Width="100%" OnItemCommand="dlSite_ItemCommand">
                                <ItemTemplate>
                                    <div class="adminprog-cont">
                                        <h1 class="admin-text ot">
                                            <asp:Literal ID="ltSiteName" runat="server" Text='<%# Eval("site_name") %>' />
                                            &nbsp;
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("site_type") %>' /></h1>
                                        <asp:Button ID="btnEditSite" runat="server" CssClass="green-btn admin-edit fr" CommandName="EditSite"
                                            CommandArgument='<%# Eval("site_id") %>' Text="<%$ Resources:TestSiteResources, Edit %>" />
                                        <div class="clear">
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                            
                               
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
             <div class="adminprog-cont crt-reward">
                                    <asp:Button ID="btnNewSite" class="green-btn create-reward" Text="<%$ Resources:TestSiteResources, CreateNewSite %>"
                                        runat="server" OnClick="btnNewSite_Click" />
                                </div>
        </div>
        
                           
    </div>
    <div class="clear">
    </div>

    
</asp:Content>
