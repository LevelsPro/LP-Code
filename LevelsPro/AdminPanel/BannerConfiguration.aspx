<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" AutoEventWireup="true" CodeBehind="BannerConfiguration.aspx.cs" Inherits="LevelsPro.AdminPanel.BannerConfiguration" %>
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
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/AdminHome.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl er">
            <asp:Label ID="lblHeading" runat="server" Text="Banner Settings"></asp:Label></div>

        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" onclick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>

    <div class="box brd2">
        <div class="fl-wrapper">
            <asp:Label ID="lblmessage" runat="server" Visible="false"></asp:Label>            
            <div class="clear">
            </div>
            <div class="strip">
                <asp:Label ID="lblLogoImage" runat="server" class="edit-left32" Text="Logo Image : "></asp:Label>
                <span class="edit-right32 tl">
                
                <asp:FileUpload ID="fpLogoImage" runat="server" ValidationGroup="Insertion"/>
                <asp:RequiredFieldValidator ID="rfvLogoImage" runat="server" ErrorMessage="Provide Logo Image"
                    ControlToValidate="fpLogoImage" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>  
                <asp:Label ID="lblLogoCond" runat="server" class="edit-left32" Text="(Size = 128*128 px)"></asp:Label>              
                </span>                
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblTextImage" runat="server" class="edit-left32" Text="Text Image : "></asp:Label>
                 <span class="edit-right32 tl">
                <asp:FileUpload ID="fpTextImage" runat="server" ValidationGroup="Insertion"/>
                <asp:RequiredFieldValidator ID="rfvTextImage" runat="server" ErrorMessage="Provide Text Image"
                    ControlToValidate="fpTextImage" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator> 
                <asp:Label ID="lblTextCond" runat="server" class="edit-left32" Text="(Size = 320*70 px)"></asp:Label>                              
                </span>
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblBannerImage" runat="server" class="edit-left32" Text="Banner Image : "></asp:Label>
                 <span class="edit-right32 tl">
                <asp:FileUpload ID="fpBannerImage" runat="server" ValidationGroup="Insertion"/>
                <asp:RequiredFieldValidator ID="rfvBannerImage" runat="server" ErrorMessage="Provide Banner Background Image"
                    ControlToValidate="fpBannerImage" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                <asp:Label ID="lblBennerCond" runat="server" class="edit-left32" Text="(Size = 3790*128 px)"></asp:Label>                  
                </span>
                <div class="clear">
                </div>
            </div>
            </div>
            <asp:Button ID="btnAddQuiz" runat="server" class="edit-left" CssClass="green-btn admin-edit fr"
            Text="Add" ValidationGroup="Insertion" onclick="btnAddQuiz_Click"/>
        &nbsp;
        <asp:Button ID="btnCancel" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
            Text="<%$ Resources:TestSiteResources, Cancel %>" 
            onclick="btnCancel_Click"/>
        <div class="clear">
        </div>
            </div>


</asp:Content>
