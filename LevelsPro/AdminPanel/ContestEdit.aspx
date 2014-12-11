<%@ Page Title="<%$ Resources:TestSiteResources, EditContest %>" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" AutoEventWireup="true" CodeBehind="ContestEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.ContestEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    $(document).ready(function () {
        $('#scrollbar1').tinyscrollbar();
    });

    function disableautocompletion(id) {
        var passwordControl = document.getElementById(id);
        passwordControl.setAttribute("autocomplete", "off");
    }    

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar bottom-space">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/ContestManagement.aspx"
            CssClass="green-btn btn fl"></asp:Button>        
        <div class="user-nt fl er">
            <asp:Label ID="lblHeading" runat="server" Text="<%$ Resources:TestSiteResources, EditContest %>"></asp:Label>
        </div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box top-b leaderboard">
        <asp:Button ID="btnLeaderBoard" runat="server" 
            Text='<%$ Resources:TestSiteResources, LeaderBoards %>' 
            CssClass="green-btn btn fr" onclick="btnLeaderBoard_Click" />
    </div>
    <div class="box brd3 bottom-space">
        <asp:Label ID="lblNewContest" runat="server" CssClass="bold" Text="<%$ Resources:TestSiteResources, NewContest %>"></asp:Label>
        <div class="fl-sub-wrapper">
            <asp:Label ID="lblmessage" runat="server" Visible="false"></asp:Label>
            <div class="clear">
            </div>
            <div class="strip">
                <asp:Label ID="lblContestName" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, ContestName %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtContestName" runat="server"  class="qq-admin" MaxLength="100"
                    ValidationGroup="Insertion" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContestName" runat="server" ErrorMessage="Provide Contest Name"
                    ControlToValidate="txtContestName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>    </span>            
                <div class="clear">
                </div>
            </div><!-- ContestName-->
            <div class="strip">
                <asp:Label ID="lblFromDate" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, FromDate %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtFromDate" runat="server" class="qq-admin"  ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="ceLoanFromDate" runat="server" Format="MM/dd/yyyy" 
                    PopupButtonID="txtFromDate" TargetControlID="txtFromDate">
                </ajaxToolkit:CalendarExtender>
                <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ErrorMessage="Provide From Date"
                    ControlToValidate="txtFromDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                </span>
                <div class="clear">
                </div>
            </div><!-- FromDate -->
            <div class="strip no-bottom-border">
                <asp:Label ID="lblToDate" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, ToDate %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtToDate" runat="server" class="qq-admin"  ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="ceLoanToDate" runat="server" Format="MM/dd/yyyy" 
                    PopupButtonID="txtToDate" TargetControlID="txtToDate">
                </ajaxToolkit:CalendarExtender>
                <asp:RequiredFieldValidator ID="rfvToDate" runat="server" ErrorMessage="Provide To Date"
                    ControlToValidate="txtToDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvToDate" runat="server" ControlToCompare="txtFromDate" ControlToValidate="txtToDate" CultureInvariantValues="true"
                    ErrorMessage="To Date should be greater than From Date." Operator="GreaterThanEqual" SetFocusOnError="true" Type="Date"></asp:CompareValidator>
                </span>
                <div class="clear">
                </div>
            </div><!-- ToDate -->
        </div>
     </div>
    <div class="box brd3 bottom-space">
        <asp:Label ID="lblContestParameters" runat="server" CssClass="bold" Text="<%$ Resources:TestSiteResources, ContestParameters %>"></asp:Label>
        <div class="fl-sub-wrapper">
            <div class="strip">
                <asp:Label ID="lblKPIName" runat="server" class="edit-left32" Text="KPI Measure"></asp:Label>
                <span class="edit-right32 tl">
                    <asp:DropDownList ID="ddlKPI_ID" runat="server" CssClass="combo-fw" ValidationGroup="Insertion"
                        MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"
                        OnSelectedIndexChanged="ddlKPI_ID_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </span>
                <div class="clear">
                </div>
            </div>
            <!-- KPI -->
            <div class="strip">
                <asp:Label ID="lblStoreName" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, Location %>"></asp:Label>
                <span class="edit-right32 tl">
                    <asp:DropDownList ID="ddlStore_ID" runat="server" CssClass="combo-fw" ValidationGroup="Insertion"
                        MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);">
                    </asp:DropDownList>
                </span>
                <div class="clear">
                </div>
            </div>
            <!-- Store -->
            <div class="strip no-bottom-border">
                <asp:Label ID="lblRolesName" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, Role %>"></asp:Label>
                <span class="edit-right32 tl">
                    <asp:DropDownList ID="ddlRoles_ID" runat="server" CssClass="combo-fw" ValidationGroup="Insertion"
                        MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);">
                    </asp:DropDownList>
                </span>
                <div class="clear">
                </div>
            </div>
            <!-- Roles -->
        </div>
    </div>
    <div class="box brd3">
        <asp:Label ID="lblPointsAwards" runat="server" CssClass="bold" Text="<%$ Resources:TestSiteResources, ContestAwards %>"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="flWrapper" runat="server" class="fl-sub-wrapper">
                    <div class="strip">
                        <span class="edit-full tl">
                            <asp:Label ID="lbl1Place" runat="server" class="edit-left20" Text="<%$ Resources:TestSiteResources, FPlace %>"></asp:Label>
                            <asp:TextBox ID="txt1Place" runat="server" class="txtPoints edit-left20 qq-admin"
                                MaxLength="5" ValidationGroup="Insertion" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:Label ID="lbl1Points" runat="server" class="lblPoints edit-left20" Text="<%$ Resources:TestSiteResources, Points %>"></asp:Label>
                            <asp:RequiredFieldValidator ID="rf1Place" runat="server" ErrorMessage="Provide 1st Place"
                                ControlToValidate="txt1Place" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl1Place" runat="server" CssClass="ddlPoints edit-left20 combo-fw"
                                ValidationGroup="Insertion" MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hf1Place" runat="server" Value="0" />
                        </span>
                        <div class="clear">
                        </div>
                    </div>
                    <!-- 1Place-->
                    <div class="strip">
                        <span class="edit-full tl">
                            <asp:Label ID="lbl2Place" runat="server" class="edit-left20" Text="<%$ Resources:TestSiteResources, SPlace %>"></asp:Label>
                            <asp:TextBox ID="txt2Place" runat="server" class="txtPoints edit-left20 qq-admin"
                                MaxLength="5" ValidationGroup="Insertion" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:Label ID="lbl2Points" runat="server" class="lblPoints edit-left32" Text="<%$ Resources:TestSiteResources, Points %>"></asp:Label>
                            <asp:RequiredFieldValidator ID="rf2Place" runat="server" ErrorMessage="Provide 2nd Place"
                                ControlToValidate="txt2Place" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl2Place" runat="server" CssClass="ddlPoints edit-left20 combo-fw"
                                ValidationGroup="Insertion" MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hf2Place" runat="server" Value="1" />
                        </span>
                        <div class="clear">
                        </div>
                    </div>
                    <!-- 2Place-->
                    <div class="strip no-bottom-border">
                        <span class="edit-full tl">
                            <asp:Label ID="lbl3Place" runat="server" class="edit-left20" Text="<%$ Resources:TestSiteResources, TPlace %>"></asp:Label>
                            <asp:TextBox ID="txt3Place" runat="server" class="txtPoints edit-left20 qq-admin"
                                MaxLength="5" ValidationGroup="Insertion" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:Label ID="lbl3Points" runat="server" class="lblPoints edit-left32" Text="<%$ Resources:TestSiteResources, Points %>"></asp:Label>
                            <asp:RequiredFieldValidator ID="rf3Place" runat="server" ErrorMessage="Provide 3rd Place"
                                ControlToValidate="txt3Place" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl3Place" runat="server" CssClass="ddlPoints edit-left20 combo-fw"
                                ValidationGroup="Insertion" MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hf3Place" runat="server" Value="2" />
                        </span>
                        <div class="clear">
                        </div>
                    </div>
                    <!-- 3Place-->
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlKPI_ID" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnAddPlace" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="overview" style="display:none;">
            <asp:Button ID="btnRemovePlace" runat="server" class="edit-left" CssClass="green-btn admin-edit fr wa custom-contest-btn"
                Text="<%$ Resources:TestSiteResources, RemovePlace %>" OnClick="btnRemovePlace_Click" />
            &nbsp;
            <asp:Button ID="btnAddPlace" class="edit-left" CssClass="green-btn admin-edit fr mr10 custom-contest-btn"
                Text="<%$ Resources:TestSiteResources, AddPlace %>" runat="server" OnClick="btnAddPlace_Click" />
            <div class="clear">
            </div>
        </div>
    </div>                                
    <asp:Button ID="btnAddContest" runat="server" class="edit-left" CssClass="green-btn admin-edit fr wa"
        Text="<%$ Resources:TestSiteResources, CreateContest %>" ValidationGroup="Insertion" onclick="btnAddContest_Click" />
    &nbsp;
    <asp:Button ID="btnCancel" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
        Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
    <div class="clear">
    </div>
</asp:Content>
