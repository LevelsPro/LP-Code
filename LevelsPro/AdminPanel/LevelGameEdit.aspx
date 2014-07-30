<%@ Page Title="Level Game Edit" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="LevelGameEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.LevelGameEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" CssClass="green-btn btn fl" OnClick="btnHome_Click">
        </asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        <div class="lvl-desc edit-block">
            <h1 class="edit-name fl">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, GameName %>"></asp:Label>
                </h1>
            <h1 class="edit-desc2 fl">
                <asp:TextBox ID="txtGameName" runat="server"></asp:TextBox></h1>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGameName"
                Display="Dynamic" ErrorMessage="Provide Game Name" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
            <div class="clear">
            </div>
        </div>
        <div class="lvl-desc edit-block">
            <h1 class="edit-name fl">
            <asp:Label ID="Label5" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
                </h1>
            <h1 class="edit-desc2 fl">
                <asp:CheckBox ID="cbGame" runat="server" />
            </h1>
            <div class="clear">
            </div>
        </div>
        <div class="lvl-desc edit-block">
            <asp:Button ID="btnAddGame" runat="server" Text="<%$ Resources:TestSiteResources, AddGame%>" CssClass="green-btn add-del-goal fl"
                OnClick="btnAddGame_Click" ValidationGroup="Insertion" />
            <div class="clear">
            </div>
        </div>
        <div class="lvl-desc edit-block" id="divValueText" runat="server" visible="false">
            <h1 class="edit-name fl">
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, ValueName %>"></asp:Label>
                </h1>
            <h1 class="edit-desc2 fl">
                <asp:TextBox ID="txtValueName" runat="server"></asp:TextBox></h1>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtValueName"
                Display="Dynamic" ErrorMessage="Provide Value Name" SetFocusOnError="True" ValidationGroup="ddl"> * </asp:RequiredFieldValidator>
            <div class="clear">
            </div>
        </div>
        <div class="lvl-desc edit-block" id="divActiveText" runat="server" visible="false">
            <h1 class="edit-name fl">
               <asp:Label ID="Label3" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label></h1>
            <h1 class="edit-desc2 fl">
                <asp:CheckBox ID="cbGameDDL" runat="server" />
            </h1>
            <div class="clear">
            </div>
        </div>
        <div class="lvl-desc edit-block" id="divValueButton" runat="server" visible="false">
            <asp:Button ID="btnAddValue" runat="server" Text="<%$ Resources:TestSiteResources, AddValue %>" CssClass="green-btn add-del-goal fl"
                OnClick="btnAddValue_Click" ValidationGroup="ddl" />
            <div class="clear">
            </div>
        </div>
        <div class="gr-hr">
        </div>
        <div class="manager-cont" id="scrollbar1">
            <div class="scrollbar">
                <div class="track">
                    <div class="thumb">
                        <div class="end">
                        </div>
                    </div>
                </div>
            </div>
            <div class="viewport edit-levels">
                <div class="overview">
                   <%-- <asp:UpdatePanel ID="upLevelGamesDDL" runat="server">
                        <ContentTemplate>--%>
                            <asp:DataList ID="dlLevelGameDDL" runat="server" DataKeyField="GameDropdownID" Width="100%"
                                OnItemCommand="dlLevelGameDDL_ItemCommand">
                                <ItemTemplate>
                                    <div class="adminprog-cont">
                                        <h1 class="admin-text ot">
                                            <asp:Literal ID="ltActive" runat="server" Text='<%# Eval("GameDDLActive") %>' Visible="false" />
                                            <asp:Literal ID="ltGameName" runat="server" Text='<%# Eval("GameDropdownName") %>' /></h1>
                                        <asp:Button ID="btnEditGame" runat="server" CssClass="green-btn admin-edit fr" CommandName="EditGame"
                                            CommandArgument='<%# Eval("GameDropdownID") %>' Text="<%$ Resources:TestSiteResources, Edit %>" />
                                        <div class="clear">
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                            <div class="adminprog-cont crt-reward">
                                <asp:Button ID="btnNewGameDDL" class="green-btn create-reward" Text="<%$ Resources:TestSiteResources, CreateNewValue %>"
                                    runat="server" OnClick="btnNewGameDDL_Click" />
                            </div>                            
                        <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
