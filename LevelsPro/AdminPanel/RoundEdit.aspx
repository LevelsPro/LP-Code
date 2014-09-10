<%@ Page Title="<%$ Resources:TestSiteResources, EditRound %>" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" AutoEventWireup="true" CodeBehind="RoundEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.RoundEdit" %>
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

    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="lblHeading" runat="server" Text="<%$ Resources:TestSiteResources, EditRound %>"></asp:Label>
        </div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>

    <div class="box brd2">
        <div class="fl-wrapper">
            <asp:Label ID="lblmessage" runat="server" Visible="false"></asp:Label>            
            <div class="clear">
            </div>
            <div class="strip">
                <asp:Label ID="lblMatchID" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, MatchID %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtMatchID" runat="server" class="qq-admin" Enabled="false"></asp:TextBox></span>
                <div class="clear">
                </div>
            </div><!-- MatchID-->
            <div class="strip">
                <asp:Label ID="lblRoundNumber" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, RoundNumber %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtRoundNumber" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRoundNumber" runat="server" ErrorMessage="Provide an Round Number"
                    ControlToValidate="txtRoundNumber" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revRoundNumber" runat="server" ControlToValidate="txtRoundNumber"
                    Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>
                </span>
                <div class="clear">
                </div>
            </div><!-- RoundNumber-->
            <div class="strip">
                <asp:Label ID="lblRoundName" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, RoundName %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtRoundName" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRoundName" runat="server" ErrorMessage="Provide an Round Name"
                    ControlToValidate="txtRoundName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                </span>
                <div class="clear">
                </div>
            </div><!-- RoundName-->
            <div class="strip">
                <asp:Label ID="lblNoOfDataSets" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, NoOfDataSets %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtNoOfDataSets" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoOfDataSets" runat="server" ErrorMessage="Provide a Number of Data Sets"
                    ControlToValidate="txtNoOfDataSets" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNoOFDataSets" runat="server" ControlToValidate="txtNoOfDataSets"
                    Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>
                </span>
                <div class="clear">
                </div>
            </div><!-- NoOfDataSets-->
            <div class="strip">
                <asp:Label ID="lblTimePerRound" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, TimePerRound %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtTimePerRound" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTimePerRound" runat="server" ErrorMessage="Provide a Time Allowed per Round"
                    ControlToValidate="txtTimePerRound" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTimePerRound" runat="server" ControlToValidate="txtTimePerRound"
                    Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>
                </span>
                <div class="clear">
                </div>
            </div><!-- TimePerRound-->
            <div class="strip">
                <asp:Label ID="lblPointsPerRound" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, PointsPerRound %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtPointsPerRound" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPointsPerRound" runat="server" ErrorMessage="Provide the Points per Round"
                    ControlToValidate="txtPointsPerRound" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPointsPerRound" runat="server" ControlToValidate="txtPointsPerRound"
                    Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>
                </span>
                <div class="clear">
                </div>
            </div><!-- PointsPerRound-->
            <div class="strip">
                <asp:Label ID="lblShowHint" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, ShowHint %>"></asp:Label>
                <span class="edit-right32 tl">
                    <asp:CheckBox ID="chkShowHint" runat="server" ValidationGroup="Insertion" />
                </span>
                <div class="clear">
                </div>
            </div><!-- ShowHint-->
        </div>
    </div>                                
    <asp:Button ID="btnAddMatchRound" runat="server" class="edit-left" CssClass="green-btn admin-edit fr wa"
        Text="<%$ Resources:TestSiteResources, AddMatchRound %>" ValidationGroup="Insertion" onclick="btnAddMatchRound_Click" />
    &nbsp;
    <asp:Button ID="btnCancel" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
        Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
    <div class="clear">
    </div>
</asp:Content>
