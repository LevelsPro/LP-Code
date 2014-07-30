<%@ Page Title="Player Awards" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="PlayerAward.aspx.cs" Inherits="LevelsPro.AdminPanel.PlayerAward" %>

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
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, PlayerAwards %>"></asp:Label>
            </div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" CssClass="green-btn btn fr"
            OnClick="btnLogout_Click" />
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <div>
            <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
        </div>
        <div class="box admin-btns-cont">
            <asp:Button ID="btnMainInfo" runat="server" Text="<%$ Resources:TestSiteResources, MainInfo %>" 
                CssClass="green-btn ad-btns" onclick="btnMainInfo_Click" />
            <asp:Button ID="btnAwards" runat="server" Text="<%$ Resources:TestSiteResources, AwardsB %>" CssClass="yellow-btn ad-btns" />
            <asp:Button ID="btnProgress" runat="server" Text="<%$ Resources:TestSiteResources, Progress1 %>" 
                CssClass="green-btn ad-btns" onclick="btnProgress_Click" />
            <asp:Button ID="btnRewards" runat="server" Text="<%$ Resources:TestSiteResources, Reward %>" 
                CssClass="green-btn ad-btns" onclick="btnRewards_Click" />
        </div>
        <div class="usercont-right">
            <div class="fl-wrapper user-data">
                <asp:Label ID="lblFirstName" runat="server" Text="<%$ Resources:TestSiteResources, FirstName %>"
                    CssClass="flabel"></asp:Label>
                <asp:Label ID="lblFirstNameValue" runat="server" CssClass="fdata"></asp:Label>
                <div class="clear">
                </div>
                <asp:Label ID="lblLastName" runat="server" Text="<%$ Resources:TestSiteResources, LastName %>"
                    CssClass="flabel"></asp:Label>
                <asp:Label ID="lblLastNameValue" runat="server" CssClass="fdata"></asp:Label>
                <div class="clear">
                </div>
            </div>
            <p class="assign-text">
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, AssignAward1 %>"></asp:Label>
              </p>
            <asp:DropDownList ID="ddlAward" runat="server" CssClass="assign-combo">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvAward" runat="server" ErrorMessage="Provide Award"
                ControlToValidate="ddlAward" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"
                InitialValue="0"> * </asp:RequiredFieldValidator>
            <asp:Button ID="btnAssignAward" runat="server" Text="<%$ Resources:TestSiteResources, AssignAwardB %>"
                CssClass="green-btn assign" OnClick="btnAssignAward_Click" ValidationGroup="Insertion" />
        </div>
        <div class="clear">
        </div>
        <div class="black-hr">
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
            <div class="viewport progadmin">
                <div class="overview">
                    <asp:DataList ID="dlAwards" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                        Width="100%" onitemcommand="dlAwards_ItemCommand">
                        <ItemTemplate>
                            <div class="adminprog-cont">
                             <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/AdminPanel/Images/remove-quiz.png"
                                class="fl mt30" Width="50" Height="50" OnClientClick="return confirm('Are you sure to delete Award.');"  CommandName="DeleteAward" CommandArgument='<%# Eval("userAwardsId") %>' />
                                <asp:Image ID="imgAwardImage" runat="server" ImageUrl='<%# Eval("Award_Thumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["AwardsThumbPath"].ToString() + Eval("Award_Thumbnail") :"Images/placeholder.png" %>'
                                       class="fl" Width="72" Height="72" />                                
                                <h1 class="prog-text">
                                    <%#Eval("Award_Name")%>
                                    <br />
                                    <%# Convert.ToDateTime(Eval("awarded_date")).ToShortDateString() %>    
                                </h1>
                                
                               <%-- <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="green-btn prog-edit fr" />--%>
                                <div class="clear">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
