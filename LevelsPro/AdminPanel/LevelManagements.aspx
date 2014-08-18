<%@ Page Title="Manage Levels" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="true" CodeBehind="LevelManagements.aspx.cs" Inherits="LevelsPro.AdminPanel.LevelManagements" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <!-- <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>-->
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
            <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <asp:Panel ID="pnlMain" runat="server">
            <div>
                <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
            </div>
            <div class="lvl-desc rolename">
                <%-- <asp:TextBox ID="txtRoleName" runat="server" class="admin-text ot" MaxLength="100" Width="242px"
                ValidationGroup="Insertion"></asp:TextBox>--%>
                <%-- <asp:Label ID="lblRoleName" runat="server" class="edit-name fl" 
                Text="<%$ Resources:TestSiteResources, RoleName %>" Width="135px"></asp:Label>--%>
                <asp:DropDownList ID="ddlRole" class="edit-right tl" runat="server" Width="280px"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                </asp:DropDownList>
                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Insertion"
                SetFocusOnError="true" ErrorMessage="Provide Role name" Display="Dynamic" ControlToValidate="txtRoleName">*</asp:RequiredFieldValidator>--%>
                <div class="clear">
                </div>
            </div>
            <%-- <div class="edit-block">
            <asp:Label ID="lblActive" class="edit-name fl" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
            <asp:CheckBox ID="cbActive" runat="server" class="edit-desc fl" />
            <div class="clear">
            </div>
        </div>
        <div class="edit-block">
            <asp:Button ID="btnAddRole" runat="server" class="edit-left" CssClass="green-btn admin-edit fr"
                Text="<%$ Resources:TestSiteResources, Add %>" OnClick="btnAddRoles_Click" ValidationGroup="Insertion" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="Insertion" />
            <div class="clear">
            </div>
        </div>--%>
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
                        <asp:Panel ID="pnlPlayergrid" runat="server" Visible="false">
                            <asp:DataList ID="dlLevel" runat="server" Width="100%" OnItemCommand="dlLevel_ItemCommand"
                                OnItemDataBound="dlLevel_ItemDataBound" 
                                ondeletecommand="dlLevel_DeleteCommand">
                                <ItemTemplate>
                                 <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/AdminPanel/Images/remove-quiz.png"
                                class="fl mt30" Width="50" Height="50" OnClientClick="return confirm('Are you sure to delete Level.');"  CommandName="DeleteLevel" CommandArgument='<%# Eval("Level_ID") + ";" + Eval("lvlPosition") + "&" +Eval("Role_ID")%>' />&nbsp;
                                    <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active") %>' Visible="false"></asp:Label>
                                    <div class="adminprog-cont">
                                        <h1 class="admin-text ot">
                                         <asp:Image ID="imgLevelImage" runat="server" ImageUrl='<%# Eval("ImageThumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["RoleThumbPath"].ToString() + Eval("ImageThumbnail") :"Images/placeholder.png" %>'
                                       class="fl" Width="72" Height="72" />&nbsp;
                                            <%# Eval("Level_Position")%>
                                            -
                                            <%# Eval("Level_Name")%></h1>
                                        <asp:Button ID="btnEditLevel" runat="server" CssClass="green-btn admin-edit fr" CommandName="EditLevel"
                                            CommandArgument='<%# Eval("Level_ID") %>' Text="<%$ Resources:TestSiteResources, Edit %>" />
                                        <div class="clear">
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </asp:Panel>
                        
                    </div>
                </div>
            </div>

            <div class="clear">
            </div>

            <div class="adminprog-cont crt-reward">
                            <asp:Button ID="btnNewLevel" class="green-btn create-reward" Text="<%$ Resources:TestSiteResources, CreateNewLevel %> "
                                runat="server" OnClick="btnNewLevel_Click" />
                        </div>
            <div class="left-50 mt46">
                <%-- <select class="sort-filter">
               <option>Active</option>
            </select>--%>
            </div>
            <div class="right-50 mt10">
                <%--<div class="green-btn create-reward fr rl">
                Delete Level</div>
            <br />--%>
                <%--<div class="green-btn create-reward fr rl">--%>
                <asp:Button ID="btnRearrangeLevels" Text="<%$ Resources:TestSiteResources, RearrangeLevels %>" CssClass="green-btn create-reward fr rl"
                    runat="server" OnClick="btnRearrangeLevels_Click" /><%--</div>--%>
            </div>
            <div class="clear">
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlSort" runat="server" Width="100%">
            <table width="49%">
                <caption>
                    <h1>
                        <asp:Label ID="lblLevelPosition" runat="server" Text="<%$ Resources:TestSiteResources, LevelPosition %>"></asp:Label></h1>
                    <asp:Label ID="lblInfo" runat="server" Font-Bold="true" Text="<%$ Resources:TestSiteResources, LevelUPDown %>"></asp:Label>
                    <br />
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td align="center">
                            <asp:ListBox ID="lstSelectedSections" runat="server" AutoPostBack="True" Rows="10"
                                SelectionMode="Multiple" />
                        </td>
                        <td>
                            <div class="relvls-right fr">
                                <asp:ImageButton ID="btnUp" runat="server" ImageUrl="~/AdminPanel/Images/arrow-gr-up.png"
                                    OnClick="btnUp_Click" Width="78" Height="78" />
                                <asp:ImageButton ID="btnDown" runat="server" ImageUrl="~/AdminPanel/Images/arrow-gr-down.png"
                                    OnClick="btnDown_Click" Width="78" Height="78" />
                            </div>
                            <div class="clear">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 150px">
                        </td>
                        <td>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnSet" runat="server" CssClass="green-btn create-reward fl mr10"
                                OnClick="btnSet_Click" Text="<%$ Resources:TestSiteResources, SetPosition %>" />
                            <asp:Button ID="btnCancelPriority" runat="server" CssClass="green-btn create-reward fl"
                                OnClick="btnCancelPriority_Click" Text="<%$ Resources:TestSiteResources, Cancel %>" />
                            <%--OnClick="btnCancelPriority_Click"--%>
                        </td>
                        <td>
                        </td>
                    </tr>
                </caption>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
