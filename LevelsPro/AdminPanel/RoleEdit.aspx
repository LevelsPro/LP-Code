<%@ Page Title="Edit Role" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="RoleEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.RoleEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="Scripts/jquery.min.js" type="text/javascript"></script>--%>
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
     <script src="../Scripts/lightbox.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.smooth-scroll.min.js" type="text/javascript"></script>
     <link href="../Styles/lightbox.css" rel="stylesheet" type="text/css" />
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
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/RoleManagement.aspx"
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
        <div>
            <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
        </div>
         <div class="strip">
            <asp:Label ID="lblRoleName" runat="server" class="edit-name fl" Text="<%$ Resources:TestSiteResources, RoleName %>"></asp:Label>
            <asp:TextBox ID="txtRoleName" runat="server" class="edit-right" MaxLength="100" 
                ValidationGroup="Insertion"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Insertion"
                SetFocusOnError="true" ErrorMessage="Provide Role name" Display="Dynamic" ControlToValidate="txtRoleName">*</asp:RequiredFieldValidator>
            <div class="clear">
            </div>
        </div>
        <div class="strip">
       
                    <asp:Label ID="lblImageName" runat="server" class="edit-name fl" Text="Progress Map"></asp:Label>
                
                    <asp:FileUpload ID="fileQuizImage" runat="server" CssClass="FUImage" />
                     <asp:RequiredFieldValidator ID="rfvGraphic" runat="server" ErrorMessage=" Graphic is required."
                        ControlToValidate="fileQuizImage" Display="Static" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileQuizImage"
                        Display="Dynamic" ErrorMessage=".jpeg, .jpg, .bmp, .png, .tif & gif formats are allowed"
                        SetFocusOnError="True" ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Jj][Pp][Ee][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Pp][Nn][Gg])|.+\.([Gg][Ii][Ff])|.+\.([Tt][Ii][Ff]))"
                        ValidationGroup="Insertion" ToolTip=".jpeg, .jpg, .bmp, .png, .tif & gif formats are allowed"
                        Font-Size="36px" ForeColor="Red">*</asp:RegularExpressionValidator>
                        <asp:HyperLink ID="hplView" runat="server" Text="<%$ Resources:TestSiteResources, View %>" rel="lightbox" Visible="false"></asp:HyperLink>
                          <div class="clear">
            </div>
        </div>
              
         <div class="strip">
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
        </div>
        </div>
         <%-- <div class="manager-cont" id="scrollbar1">
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
                        <asp:DataList ID="dlLevel" runat="server" Width="100%" 
                            onitemcommand="dlLevel_ItemCommand" 
                            onitemdatabound="dlLevel_ItemDataBound">
                            <ItemTemplate>
                                <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active") %>' Visible="false"></asp:Label>
                                <div class="adminprog-cont">
                                    <h1 class="admin-text ot">
                                        <%# Eval("Level_Position")%>
                                        -
                                        <%# Eval("Level_Name")%></h1>
                                    <asp:Button ID="btnEditLevel" runat="server" CssClass="green-btn admin-edit fr" CommandName="EditLevel"
                                        CommandArgument='<%# Eval("Level_ID") %>' Text="Edit" />
                                    <div class="clear">
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </asp:Panel>
                    <div class="adminprog-cont crt-reward">
                        <asp:Button ID="btnNewLevel" class="green-btn create-reward" Text=" Create New Level"
                            runat="server" onclick="btnNewLevel_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="left-50 mt46">
            <select class="sort-filter">
                <option>Active</option>
            </select>
        </div>
        <div class="right-50 mt10">
            <div class="green-btn create-reward fr rl">
                Delete Level</div>
            <br />
            <div class="green-btn create-reward fr rl">
                Rearrange Levels</div>
        </div>
        <div class="clear">
        </div>--%>
    </div>    
</asp:Content>
