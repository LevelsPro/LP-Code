<%@ Page Title="KPI Management" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="KPIManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.KPIManagement" %>

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
    <script type="text/javascript">
        function AllowOnlyAlphabets(e) {
            isIE = document.all ? true : false;
            keyEntry = (!isIE) ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || keyEntry == '45' || keyEntry == '0' || keyEntry == '8' || keyEntry == '32')

                return true;
            else
                return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/AdminHome.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
          <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources,  ManageKPI %>"></asp:Label>
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
            <div class="viewport progadminkpi">
                <div class="overview">
                    <asp:UpdatePanel ID="upgvRoles" runat="server">
                        <ContentTemplate>
                            <asp:DataList ID="dlKPI" runat="server" DataKeyField="KPI_ID" Width="100%" OnItemCommand="dlKPI_ItemCommand">
                                <ItemTemplate>
                                    <div class="adminprog-cont">
                                        <h1 class="admin-text ot">
                                            <asp:Literal ID="ltKPIName" runat="server" Text='<%# Eval("KPI_name") %>' /></h1>
                                        <asp:Button ID="btnEditKPI" runat="server" CssClass="green-btn admin-edit fr" CommandName="EditKPI"
                                            CommandArgument='<%# Eval("KPI_ID") %>' Text="<%$ Resources:TestSiteResources, Edit %>" />
                                        <div class="clear">
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                           
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="clear"></div>
        <div class="clear"></div> <div class="adminprog-cont crt-reward">
                                <asp:Button ID="btnNewKPI" class="green-btn create-reward" Text="<%$ Resources:TestSiteResources,  CreateNewKPI %>"
                                    runat="server" OnClick="btnNewKPI_Click" />
                            </div>
    </div>
	<div class="clear"></div>
		
</asp:Content>
