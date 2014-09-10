<%@ Page Title="<%$ Resources:TestSiteResources, EditDataElement %>" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" AutoEventWireup="true" CodeBehind="DataElementEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.DataElementEdit" %>
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
            <asp:Label ID="lblHeading" runat="server" Text="<%$ Resources:TestSiteResources, EditDataElement %>"></asp:Label>
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
                <asp:Label ID="lblElementName" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, ElementName %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtElementName" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="50" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvElementName" runat="server" ErrorMessage="Provide an Element Name"
                    ControlToValidate="txtElementName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                </span>
                <div class="clear">
                </div>
            </div><!-- ElementName-->
            <div class="strip">
                <asp:Label ID="lblIsPicture" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, IsPicture %>"></asp:Label>
                <span class="edit-right32 tl">
                    <asp:CheckBox ID="chkIsPicture" runat="server" ValidationGroup="Insertion" />
                </span>
                <div class="clear">
                </div>
            </div><!-- IsPicture-->
        </div>
    </div>                                
    <asp:Button ID="btnAddMatchDataElement" runat="server" class="edit-left" CssClass="green-btn admin-edit fr wa"
        Text="<%$ Resources:TestSiteResources, AddMatchDataElement %>" ValidationGroup="Insertion" onclick="btnAddMatchDataSet_Click" />
    &nbsp;
    <asp:Button ID="btnCancel" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
        Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
    <div class="clear">
    </div>
</asp:Content>
