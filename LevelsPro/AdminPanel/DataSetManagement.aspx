<%@ Page Title="Manage DataSets" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="DataSetManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.DataSetManagement" %>

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
            PostBackUrl="~/AdminPanel/MatchManagement.aspx" CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, ManageDataSets %>"></asp:Label>
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
                    <asp:DataList ID="dlDataSets" runat="server" Width="100%" OnItemCommand="dlDataSets_ItemCommand">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/AdminPanel/Images/remove-quiz.png"
                                class="fl mt30" Width="50" Height="50" OnClientClick="return confirm('Are you sure to delete DataSet.');"  CommandName="DeleteDataSet" CommandArgument='<%# Eval("DataSetID") %>' />&nbsp;
                            <div class="level-cont-grey32 fl">
                                <asp:LinkButton ID="lbtnEdit" CommandName="EditDataSet" ForeColor="Black" CommandArgument='<%# Eval("DataSetID") %>' runat="server">
                                    <asp:Image ID="imgDataSetImage" runat="server" ImageUrl='<%# Eval("DataSetImageThumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["DataSetThumbPath"].ToString() + Eval("DataSetImageThumbnail") :"Images/placeholder.png" %>'
                                        class="lvl-img32" Width="62" Height="46" />
                                    <div class="lvl-desc32 fl">
                                        <div class="desc32">
                                            <asp:Literal ID="ltDataSetText" runat="server" Text='<%# "Data Set " + (Container.ItemIndex + 1) %>' />
                                        </div>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </asp:LinkButton>
                            </div>
                            <div class="clear">
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="left-50 mt10">
             <asp:DropDownList ID="ddlFilterBy" runat="server" CssClass="sort-filter" 
                AutoPostBack="true" 
                onselectedindexchanged="ddlFilterBy_SelectedIndexChanged" >
                <asp:ListItem Text="Filter By..." Value="0" Selected="True">
                </asp:ListItem><asp:ListItem Text="Role" Value="1" ></asp:ListItem><asp:ListItem Text="Site" Value="2"></asp:ListItem></asp:DropDownList>&nbsp;&nbsp; <asp:DropDownList ID="ddlRole" runat="server" class="sort-filter" 
                onselectedindexchanged="ddlRole_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:DropDownList 
                ID="ddlLevel" runat="server" class="sort-filter" 
                AutoPostBack="true" onselectedindexchanged="ddlLevel_SelectedIndexChanged"></asp:DropDownList>

        </div>
        <div class="right-50-1 mt10">
            <asp:Button ID="btnAddDataSet" 
                runat="server" Text="<%$ Resources:TestSiteResources, AddDataSet %>" CssClass="green-btn create-reward p10lr fr" 
                onclick="btnAddDataSet_Click" />
        </div>
        <div class="clear">
            <asp:Literal ID="ltlBulk" runat="server" Text="Bulk Insert DataSets :"></asp:Literal>
            <asp:FileUpload ID="fpBulk" runat="server" />
            <asp:Button ID="btnBulkInsert" runat="server" onclick="btnBulkInsert_Click" Text="Upload" />
        </div>
    </div>
</asp:Content>
