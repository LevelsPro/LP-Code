<%@ Page Title="Role Management" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="RoleManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.RoleManagement" %>

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
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources,  ManageRoles %>"></asp:Label>
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
                            <asp:DataList ID="dlRole" runat="server" DataKeyField="Role_ID" Width="100%" OnItemCommand="dlRole_ItemCommand">
                                <ItemTemplate>
                                    <div class="adminprog-cont">
                                        <h1 class="admin-text ot">
                                            <asp:Literal ID="ltRolName" runat="server" Text='<%# Eval("Role_Name") %>' /></h1>
                                        <asp:Button ID="btnEditRole" runat="server" CssClass="green-btn admin-edit fr" CommandName="EditRole"
                                            CommandArgument='<%# Eval("Role_ID") %>' Text="<%$ Resources:TestSiteResources, Edit %>" />
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
                                <asp:Button ID="btnNewRole" class="green-btn create-reward" Text="<%$ Resources:TestSiteResources, CreateNewRole %>"
                                    runat="server" OnClick="btnNewRole_Click" />
                            </div>
        </div>    
    </div>
    <div class="clear">
    </div>

    
</asp:Content>
