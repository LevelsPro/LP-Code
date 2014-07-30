<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="SiteEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.SiteEdit" %>

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
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/SiteManagement.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <div class="fl-wrapper">
            <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
            <div class="strip">
                <asp:Label ID="lblSiteName" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, NameL %>"></asp:Label>
                <asp:TextBox ID="txtSiteName" runat="server" class="edit-right" MaxLength="50" ValidationGroup="Insertion"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSiteName" runat="server" ValidationGroup="Insertion"
                    SetFocusOnError="true" ErrorMessage="Provide Site Name" Display="Dynamic" ControlToValidate="txtSiteName">*</asp:RequiredFieldValidator>
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblSiteType" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Type %>"></asp:Label>
                <asp:DropDownList ID="ddlSiteType" class="edit-right wbg" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvSiteType" runat="server" ErrorMessage="Provide Site Type"
                    ControlToValidate="ddlSiteType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"
                    InitialValue="0"> * </asp:RequiredFieldValidator>
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblSiteAddress" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Address %>"></asp:Label>
                <asp:TextBox ID="txtSiteAddress" runat="server" class="edit-right" ValidationGroup="Insertion"
                    MaxLength="150" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSiteAddress" runat="server" ErrorMessage="Provide Site Address"
                    ControlToValidate="txtSiteAddress" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblActive" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
                <asp:CheckBox ID="cbActive" class="edit-right" runat="server" />
                <div class="clear">
                </div>
            </div>
            <asp:Button ID="btnAddSite" runat="server" class="edit-left" CssClass="green-btn admin-edit fr"
                Text="<%$ Resources:TestSiteResources, Add %>" ValidationGroup="Insertion" OnClick="btnAddSite_Click" />
            &nbsp;
            <asp:Button ID="btnCancelSite" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
                Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancelSite_Click" />
            <div class="clear">
            </div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="Insertion" />
        </div>
    </div>
</asp:Content>
