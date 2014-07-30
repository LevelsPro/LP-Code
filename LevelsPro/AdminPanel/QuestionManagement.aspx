<%@ Page Title="Manage Questions" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="QuestionManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.QuestionManagement" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>"
            PostBackUrl="~/AdminPanel/QuizManagement.aspx" CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, ManageQuestions %>"></asp:Label>
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
            <div class="viewport progadmin">
                <div class="overview">
                    <asp:DataList ID="dlQuestions" runat="server" Width="100%" OnItemCommand="dlQuestions_ItemCommand">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/AdminPanel/Images/remove-quiz.png"
                                class="fl mt30" Width="50" Height="50" OnClientClick="return confirm('Are you sure to delete Question.');"  CommandName="DeleteQuestion" CommandArgument='<%# Eval("QuestionID") %>' />&nbsp;
                            <div class="level-cont-grey32 fl">
                                <asp:LinkButton ID="lbtnEdit" CommandName="EditQuestion" ForeColor="Black" CommandArgument='<%# Eval("QuestionID") %>'
                                    runat="server">
                                    <asp:Image ID="imgQuestionImage" runat="server" ImageUrl='<%# Eval("QuestionImageThumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["QuestionThumbPath"].ToString() + Eval("QuestionImageThumbnail") :"Images/placeholder.png" %>'
                                        class="lvl-img32" Width="62" Height="46" />
                                    <div class="lvl-desc32 fl">
                                        <div class="desc32">
                                            <asp:Literal ID="ltQuestionText" runat="server" Text='<%# Eval("QuestionText") %>' /></div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </asp:LinkButton></div><div class="clear">
                            </div>
                            <%--<asp:Button ID="btnEdit" runat="server" CssClass="green-btn admin-edit fr" CommandName="EditQuestion"
                                CommandArgument='<%# Eval("QuestionID") %>' Width="170px" Text="Edit" />--%>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="left-50 mt10">
           <%-- <select class="sort-filter">
                <option>Sort by...</option>
            </select><br />
            <select class="sort-filter">
                <option>Filter by...</option>
            </select>--%> 
             <asp:DropDownList ID="ddlFilterBy" runat="server" CssClass="sort-filter" 
                AutoPostBack="true" 
                onselectedindexchanged="ddlFilterBy_SelectedIndexChanged" >
                <asp:ListItem Text="Filter By..." Value="0" Selected="True">
                </asp:ListItem><asp:ListItem Text="Role" Value="1" ></asp:ListItem><asp:ListItem Text="Site" Value="2"></asp:ListItem></asp:DropDownList>&nbsp;&nbsp; <asp:DropDownList ID="ddlRole" runat="server" class="sort-filter" 
                onselectedindexchanged="ddlRole_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:DropDownList 
                ID="ddlLevel" runat="server" class="sort-filter" 
                AutoPostBack="true" onselectedindexchanged="ddlLevel_SelectedIndexChanged"></asp:DropDownList>

          <%--  <select class="sort-filter">
                <option>Filter By Type</option>
            </select>--%> </div><div class="right-50-1 mt10">
            <asp:Button ID="btnAddQuestion" 
                runat="server" Text="<%$ Resources:TestSiteResources, AddQuestion %>" CssClass="green-btn create-reward p10lr fr" 
                onclick="btnAddQuestion_Click" /></div>
        <div class="clear">
        <asp:Literal ID="ltlBulk" runat="server" 
                Text="Bulk Insert Questions :   "></asp:Literal><asp:FileUpload ID="fpBulk" 
                runat="server" /><asp:Button ID="btnBulkInsert" runat="server" 
                onclick="btnBulkInsert_Click" Text="Upload" /></div>
    </div>
</asp:Content>
