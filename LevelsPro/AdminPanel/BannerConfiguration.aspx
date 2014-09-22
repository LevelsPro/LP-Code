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
    function readURL(input) {

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                /*$('#<%=hdImage.ClientID%>').val(e.target.result)*/
                $('#imgQuiz').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/AdminHome.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl er">
            <asp:Label ID="lblHeading" runat="server" Text="Banner Configuration Settings"></asp:Label></div>

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
                <asp:TextBox ID="txtQuizName" runat="server"  class="qq-admin" MaxLength="100"
                    ValidationGroup="Insertion" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuizName" runat="server" ErrorMessage="Provide Quiz Name"
                    ControlToValidate="txtQuizName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>    </span>            
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblTextImage" runat="server" class="edit-left32" Text="Text Image : "></asp:Label>
                 <span class="edit-right32 tl">
                <asp:TextBox ID="txtNoOfQuestions" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="200" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoOfQuestions" runat="server" ErrorMessage="Provide No. of Questions"
                    ControlToValidate="txtNoOfQuestions" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator> </span>               
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblBannerImage" runat="server" class="edit-left32" Text="Banner Image : "></asp:Label>
                 <span class="edit-right32 tl">
                <asp:TextBox ID="txtNoOfTimesPerDay" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoOfTimesPerDay" runat="server" ErrorMessage="Provide No. of Questions Per Day"
                    ControlToValidate="txtNoOfTimesPerDay" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                <asp:RegularExpressionValidator ID="revNoOfTimesPerDay" runat="server" ControlToValidate="txtNoOfTimesPerDay"
                    Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>   </span>             
                <div class="clear">
                </div>
            </div>
            </div>
            </div>


</asp:Content>
