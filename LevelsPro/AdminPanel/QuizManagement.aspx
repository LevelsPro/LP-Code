<%@ Page Title="Manage Quiz" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="QuizManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.QuizManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <style type="text/css">
        .btnq
        {
            margin-top:5px !important; 
            margin-right:13px !important;   
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>"
            PostBackUrl="~/AdminPanel/AdminHome.aspx" CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, QuizManagement %>"></asp:Label>
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
            <div class="viewport progadminquiz">
                <div class="overview">
                    <asp:DataList ID="dlQuiz" runat="server" Width="100%" OnItemCommand="dlQuiz_ItemCommand">
                        <ItemTemplate>
                            <div class="adminprog-cont">
                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/AdminPanel/Images/del-img.png"
                                    class="fl mt30" Width="50" Height="50" OnClientClick="return confirm('Are you sure to delete Quiz.');" CommandName="DeleteQuiz" CommandArgument='<%# Eval("QuizID") %>' />&nbsp;
                                <div class="level-cont-grey32 fl" style="width:442px;">
                                    <asp:LinkButton ID="lbtnEdit" CommandName="EditQuiz" CommandArgument='<%# Eval("QuizID") %>'
                                        ForeColor="Black" runat="server">
                                        <asp:Image ID="imgQuizImage" runat="server" ImageUrl='<%# Eval("QuizImageThumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["QuizThumbPath"].ToString() + Eval("QuizImageThumbnail") :"Images/placeholder.png" %>'
                                            class="lvl-img32" Width="58" Height="46" />
                                        <div class="lvl-desc32 fl" style="width:76%;">
                                            <div class="desc32">
                                                <asp:Literal ID="ltQuizName" runat="server" Text='<%# Eval("QuizName") %>' />
                                                <asp:Button ID="btnManageQuestions" runat="server" CssClass="green-btn admin-edit fr btnq"
                                                    CommandName="ManageQuestions" Width="100px" CommandArgument='<%# Eval("QuizID") %>'
                                                    Text="<%$ Resources:TestSiteResources, Questions %>" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="clear">
                                        </div>
                                    </asp:LinkButton></div>
                                <div class="clear">
                                </div>
                        </ItemTemplate>
                    </asp:DataList>
                   
                </div>
            </div>
        </div>
         <div class="adminprog-cont crt-reward">
                        <asp:Button ID="btnNewQuiz" class="green-btn  create-reward" Text="<%$ Resources:TestSiteResources, CreateQuiz %>" runat="server"
                            OnClick="btnNewQuiz_Click" />
                    </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
