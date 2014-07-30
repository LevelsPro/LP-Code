<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlayerManagement.aspx.cs"
    Inherits="LevelsPro.AdminPanel.PlayerManagement" MasterPageFile="~/AdminPanel/Administrator.master"
    Title="Player Management" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="Scripts/jquery.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        function Toggle(divID, imgID) {
            var el = document.getElementById(divID);
            var e2 = document.getElementById(imgID);

            if (el.style.display != 'none') {
                $("#divSearch").slideToggle(400);
                e2.src = 'Images/Plus.png';
                document.getElementById('<%=hdnDivState.ClientID%>').value = 0;
            }
            else {
                $("#divSearch").slideToggle(400);
                //el.style.display = '';
                e2.src = 'Images/Minus.png';
                document.getElementById('<%=hdnDivState.ClientID%>').value = 1;
            }
        }
        $(document).ready(function () {

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_pageLoaded(function () {
                var e2 = document.getElementById('imgSearch');
                var state = document.getElementById('<%=hdnDivState.ClientID%>').value;
                if (parseInt(state) == parseInt(0)) {
                    $("#divSearch").hide();
                    e2.src = 'Images/Plus.png';
                }
                else if (parseInt(state) == parseInt(1)) {
                    $("#divSearch").show();
                    e2.src = 'Images/Minus.png';
                }
            });

            prm.add_pageLoaded(function () {
                $('#scrollbar1').tinyscrollbar();                
            });
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upgvPlayerInfo" runat="server">
        <ContentTemplate>
            <div class="box top-b options-bar">
                <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:TestSiteResources, Back %>"  CssClass="green-btn btn fl" OnClick="btnBack_Click" />
                <div class="user-nt fl">
                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, ManagePlayers %>"></asp:Label></div>
                <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" CssClass="green-btn btn fr"
                    OnClick="btnLogout_Click"/>
                <div class="clear">
                </div>
            </div>
            <div class="box brd2">
                <div>
                    <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
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
                            <asp:DataList ID="dlPlayers" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
                                Width="100%" OnItemCommand="dlPlayers_ItemCommand">
                                <ItemTemplate>
                                    <div class="level-cont-grey">
                                        <%--<asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>' Visible="false"></asp:Label>--%>
                                        <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active") %>' Visible="false"></asp:Label>
                                        <asp:CheckBox ID="chkmass" runat="server" CssClass="checkbox" />
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="EditPlayer" CommandArgument='<%# Eval("UserID") %>'
                                            ForeColor="Black">
                                            <asp:Image ID="imgPlayer" runat="server" ImageUrl='<%# Eval("Player_Thumbnail").ToString().Trim() != "" ? ConfigurationManager.AppSettings["PlayersThumbPath"].ToString() + Eval("Player_Thumbnail") : "Images/imagesNo.jpeg"  %>' CssClass="lvl-img" Width="75px" Height="75px" />
                                            <%--<img src="images/jenny-3.png" class="lvl-img" width="75" height="75" />--%>
                                            <div class="lvl-desc fl">
                                                <h1 class="lvl">
                                                    <%#Eval("FullName")%></h1>
                                                <div class="desc">
                                                    <%#Eval("Role_Name")%>
                                                    -
                                                    <%# "Level " + Eval("Level")%></div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="left-50 mt10">
                    <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="sort-filter" 
                        AutoPostBack="true" 
                        onselectedindexchanged="ddlSortBy_SelectedIndexChanged">
                        <asp:ListItem Text="Sort By..." Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="First Name" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Last Name" Value="2"></asp:ListItem>                        
                    </asp:DropDownList><br />
                    <asp:DropDownList ID="ddlFilterBy" runat="server" CssClass="sort-filter" 
                        AutoPostBack="true" onselectedindexchanged="ddlFilterBy_SelectedIndexChanged">
                        <asp:ListItem Text="Filter By..." Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Role" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Manager" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Location" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Active" Value="4"></asp:ListItem>
                    </asp:DropDownList><br />
                    <asp:DropDownList ID="ddlFilterExp" runat="server" CssClass="sort-filter" AutoPostBack="true" 
                        onselectedindexchanged="ddlFilterExp_SelectedIndexChanged">                        
                    </asp:DropDownList>
                </div>
                <div class="right-50 mt10">
                    <%--<select class="sort-filter fr">
                        <option>Bulk Actions</option>
                    </select><br />--%>
                    <asp:Button ID="btnCreatePlayer" runat="server" Text="<%$ Resources:TestSiteResources, CreateNewPlayer %>" CssClass="green-btn create-reward fr"
                        OnClick="btnCreatePlayer_Click" />
                    <%--<div class="green-btn create-reward fr">
                        Apply</div>--%>
                </div>
                <div class="clear">
                </div>
            </div>
            <div style="width: 70%; display: none;" align="right">
                <asp:HiddenField runat="server" ID="hdnSortCheck" Value="0" />
                <asp:HiddenField runat="server" ID="hdnDivState" Value="0" />
                <img id="imgSearch" alt="" onclick="Toggle('divSearch','imgSearch')" src="Images/Plus.png"
                    width="12px" height="12px" />
                &nbsp;<a onclick="Toggle('divSearch','imgSearch')" style="cursor: pointer;"><asp:Label
                    ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, ShowHideFilter %>"></asp:Label>
                </a>
            </div>
            <div style="width: 70%; display: none; border: 1px solid black;" align="center" id="divSearch">
                <table border="0" cellspacing="7" cellpadding="0">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFilterUserID" runat="server" Text="<%$ Resources:TestSiteResources, UserID %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFilterUserID" runat="server" ValidationGroup="Insertion" MaxLength="50"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblFilterFirstName" runat="server" Text="<%$ Resources:TestSiteResources, FirstName %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFilterFirstName" runat="server" ValidationGroup="Insertion" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFilterLastName" runat="server" Text="<%$ Resources:TestSiteResources, LastName %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFilterLastName" runat="server" ValidationGroup="Insertion" MaxLength="50"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblFilterNickName" runat="server" Text="<%$ Resources:TestSiteResources, NickName %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFilterNickName" runat="server" ValidationGroup="Insertion" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFilterEmail" runat="server" Text="<%$ Resources:TestSiteResources, Email %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFilterEmail" runat="server" ValidationGroup="Insertion" MaxLength="50"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblFilterSite" runat="server" Text="<%$ Resources:TestSiteResources, Site %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFilterSite" runat="server" Width="139px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFilterAppRole" runat="server" Text="<%$ Resources:TestSiteResources, ApplicationRole %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFilterAppRole" runat="server" Width="139px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblFilterRole" runat="server" Text="<%$ Resources:TestSiteResources, Role %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFilterRole" runat="server" Width="139px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblFilterManager" runat="server" Text="<%$ Resources:TestSiteResources, Manager %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFilterManager" runat="server" Width="139px">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblFilterActive" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlFilterActive" runat="server" Width="139px">
                                <asp:ListItem Text="<%$ Resources:TestSiteResources, Select %>" Value="-1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:TestSiteResources, ActiveH %>" Value="1"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:TestSiteResources, InActive %>" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                        </td>
                        <td align="right">
                        </td>
                        <td align="left">
                            <asp:Button ID="btnSearch" runat="server" Text="<%$ Resources:TestSiteResources, Search %>"
                                OnClick="btnSearch_Click" />&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="<%$ Resources:TestSiteResources, Reset %>"
                                OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <%--<asp:GridView ID="gvPlayerInfo" runat="server" ForeColor="#333333" Width="70%" CaptionAlign="Top"
                CellPadding="4" EmptyDataText="No Records Found" DataKeyNames="UserID" AutoGenerateColumns="False"
                AllowSorting="true" OnSelectedIndexChanged="gvPlayerInfo_SelectedIndexChanged"
                OnRowDataBound="gvPlayerInfo_RowDataBound" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvPlayerInfo_PageIndexChanging"
                OnSorting="gvPlayerInfo_Sorting">                
                <Columns>
                   
                    <asp:TemplateField ItemStyle-Width="8%">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" runat="server" AlternateText="<%$ Resources:TestSiteResources, Edit %>"
                                Height="17px" ImageUrl="images/btn_edit.gif" Width="15px" CommandName="Select"
                                ToolTip="Click to edit the record" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="S.No." ItemStyle-Width="3%">
                        <ItemTemplate>
                            <asp:Literal ID="ltsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TestSiteResources, Name %>" ItemStyle-Width="200px"
                        ItemStyle-HorizontalAlign="Center" SortExpression="FullName">                        
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <%#Eval("FullName")%>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:BoundField DataField="U_Email" HeaderText="<%$ Resources:TestSiteResources, EmailH %>"
                        ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" SortExpression="U_Email" />
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
            <asp:GridView ID="gvPlayerScore" runat="server" ForeColor="#333333" Width="70%" CaptionAlign="Top"
                CellPadding="4" AutoGenerateColumns="false" OnSelectedIndexChanged="gvPlayerScore_SelectedIndexChanged">
                <FooterStyle BackColor="#348ec2" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#348EC2" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#348ec2" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblKPIID" runat="server" Text='<%# Eval("KPI_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="8%">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" runat="server" AlternateText="<%$ Resources:TestSiteResources, Edit %>"
                                Height="17px" ImageUrl="images/btn_edit.gif" Width="15px" CommandName="Select"
                                ToolTip="Click to edit the record" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="S.No." ItemStyle-Width="3%">
                        <ItemTemplate>
                            <asp:Literal ID="ltsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="Target_Scores" HeaderText="<%$ Resources:TestSiteResources, TargetScore %>"
                                ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />--%>
                    <asp:BoundField DataField="Target_Value" HeaderText="<%$ Resources:TestSiteResources, TargetValue %>"
                        ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Score" HeaderText="<%$ Resources:TestSiteResources, AchievedScore %>"
                        ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="KPI_name" HeaderText="<%$ Resources:TestSiteResources, KPI %>"
                        ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Level_Name" HeaderText="<%$ Resources:TestSiteResources, Level %>"
                        ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
            <%--<asp:Button ID="btnRefresh" runat="server" Text="<%$ Resources:TestSiteResources, Refresh %>" OnClick="btnRefresh_Click" />--%>
            <asp:Button ID="_editPopupButton" runat="server" Text="Edit Contact" Style="display: none" />
            <asp:ModalPopupExtender ID="mpeManualScore" runat="server" BackgroundCssClass="modalBackground"
                RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
                PopupControlID="_CreatePostDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
                BehaviorID="EditModalPopupPost">
            </asp:ModalPopupExtender>
            <div class="_popupButtons" style="display: none">
                <input id="_okPopupButton" value="OK" type="button" />
                <input id="_cancelPopupButton" value="Cancel" type="button" />
            </div>
            <asp:UpdatePanel ID="upManualScore" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="dg-tbl" style="border-width: 0px;">
                <tr>
                    <td>--%>
                    <div id="_CreatePostDiv" class="box forums-popup" style="background-color: Gray;
                        height: 25%;">
                        <%--<table width="100%" border="0" cellspacing="0" cellpadding="0" class="dg-tbl" style="border-width: 0px;
                                padding: 0;">
                                <tr>
                                    <th align="left">
                                        <div style="text-align: right; float: right; height: 15px;">
                                            <img src="Images/close.png" height="25px" width="25px" style="cursor: pointer;" alt="Close"
                                                id="img1" onclick="hideModalPopupViaClient(event);" />
                                        </div>
                                    </th>
                                </tr>
                            </table>--%>
                        Enter Score Manually :
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblScore" runat="server" Text="Score:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtScore" runat="server"></asp:TextBox>
                                    &nbsp;<asp:RegularExpressionValidator ID="revScore" runat="server" ControlToValidate="txtScore"
                                        Display="Dynamic" ErrorMessage="Enter only Numeric value for Score" SetFocusOnError="True"
                                        ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                                    <asp:Label ID="lblcheck" runat="server" Text="Enter in a limit" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnScore" runat="server" Text="<%$ Resources:TestSiteResources, Save %>"
                                        OnClick="btnScore_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btncancel" runat="server" Text="<%$ Resources:TestSiteResources, Cancel %>"
                                        OnClick="btncancel_Click" />
                                </td>
                            </tr>
                        </table>
                        <%--<div style="overflow-y: auto; height: 300px; width: 300px;">
                                
                            </div>--%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
