<%@ Page Title="Edit Level" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" MaintainScrollPositionOnPostback="true"
    AutoEventWireup="true" CodeBehind="LevelEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.LevelEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" CssClass="green-btn btn fl" OnClick="btnHome_Click">
        </asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <div class="hei">
        <asp:Label ID="lblmessage" runat="server"></asp:Label>
            <div class="lvls-e1 fl">
                <asp:Label ID="lblRoleName" runat="server"></asp:Label>
                -
                <asp:Label ID="lblLevelName" runat="server"></asp:Label>
                <%-- Cashier - Level 3--%></div>
            <div class="lvls-e2 fl">
                <%--<select class="lvls-e2">
                <option>350 hours</option>
            </select>--%>
                <asp:Label ID="lblbasehours" runat="server" Text="<%$ Resources:TestSiteResources, BaseHoursH %>" ></asp:Label>
                <asp:TextBox ID="txtBaseHours" runat="server" MaxLength="10" ValidationGroup="Insertion"
                    CssClass="lvls-e2"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBaseHours"
                    Display="Dynamic" ErrorMessage="Enter only Numeric value for Measure" SetFocusOnError="True"
                    ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvBaseHour" runat="server" ControlToValidate="txtBaseHours"
                    Display="Dynamic" ErrorMessage="Provide Level Base Hours" SetFocusOnError="True"
                    ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
            </div>
            <div class="lvls-e3 fl">
                <%--<select class="lvls-e3">
                <option>500 bonus</option>
            </select>--%>
                <asp:Label ID="lbllevelpoints" runat="server"  Text="<%$ Resources:TestSiteResources, Bonush %>" ></asp:Label>
                <asp:TextBox ID="txtlevelPoints" runat="server" MaxLength="10" ValidationGroup="Insertion"
                    CssClass="lvls-e3"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtlevelPoints"
                    Display="Dynamic" ErrorMessage="Enter only Numeric value for Measure" SetFocusOnError="True"
                    ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtlevelPoints"
                    Display="Dynamic" ErrorMessage="Provide Level Base Hours" SetFocusOnError="True"
                    ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
            </div>
        </div>
    <div class="clear">
    </div>
    <div class="lvl-desc edit-block">
        <h1 class="edit-name fl">
         <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, LevelName %>"></asp:Label>
            </h1>
        <h1 class="edit-desc2 fl">
            <asp:TextBox ID="txtLevelName" runat="server" Width="100%"></asp:TextBox></h1>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLevelName"
            Display="Dynamic" ErrorMessage="Provide Level Name" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
        <div class="clear">
        </div>
    </div>
    <div class="lvl-desc edit-block">
        <h1 class="edit-name fl">
          <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, Game %>"></asp:Label>
            </h1>
        <h1 class="edit-desc2 fl">
            <asp:DropDownList ID="ddlGame" runat="server" OnSelectedIndexChanged="ddlGame_SelectedIndexChanged"
                AutoPostBack="true" CssClass="combo-fw">
            </asp:DropDownList>
        </h1>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlGame"
            Display="Dynamic" ErrorMessage="Provide Game Name" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
        <div class="clear">
        </div>
    </div>
    <div class="lvl-desc edit-block">
        <h1 class="edit-name fl">
         <asp:Label ID="Label3" runat="server" Text="<%$ Resources:TestSiteResources, YouAreIn %>"></asp:Label>
            </h1>
        <h1 class="edit-desc2 fl">
            <asp:DropDownList ID="ddlYouIn" runat="server" CssClass="combo-fw">
            </asp:DropDownList>
        </h1>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlYouIn"
            Display="Dynamic" ErrorMessage="Provide You are in." SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
        <div class="clear">
        </div>
    </div>
    <div class="lvl-desc edit-block">
        <h1 class="edit-name fl">
        <asp:Label ID="Label4" runat="server" Text="<%$ Resources:TestSiteResources, HeadingTo %>"></asp:Label>
            </h1>
        <h1 class="edit-desc2 fl">
            <asp:DropDownList ID="ddlHeadingTo" runat="server" CssClass="combo-fw">
            </asp:DropDownList>
        </h1>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlHeadingTo"
            Display="Dynamic" ErrorMessage="Provide Heading to." SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
        <div class="clear">
        </div>
    </div>
    <div class="lvl-desc edit-block">
        <h1 class="edit-name fl">
         <asp:Label ID="Label5" runat="server" Text="<%$ Resources:TestSiteResources,  DimensionLeft1 %>"></asp:Label>
           </h1>
        <h1 class="edit-desc2 fl">
            <asp:TextBox ID="txtDimension_left" runat="server" Width="100%"></asp:TextBox></h1>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDimension_left"
            Display="Dynamic" ErrorMessage="Provide Dimension Left." SetFocusOnError="True"
            ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
        <div class="clear">
        </div>
    </div>
    <div class="lvl-desc edit-block">
        <h1 class="edit-name fl">
        <asp:Label ID="Label6" runat="server" Text="<%$ Resources:TestSiteResources,  DimensionTop1 %>"></asp:Label>
            </h1>
        <h1 class="edit-desc2 fl">
            <asp:TextBox ID="txtDimension_top" runat="server" Width="100%"></asp:TextBox></h1>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDimension_top"
            Display="Dynamic" ErrorMessage="Provide Dimension Top." SetFocusOnError="True"
            ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
        <div class="clear">
        </div>
    </div>
    <div class="gr-hr">
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
        <div class="viewport edit-levels">
            <asp:GridView ID="gvTarget" runat="server" CaptionAlign="Top" CssClass="overview"
                DataKeyNames="Target_ID" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gvTarget_RowDataBound">
                <%--OnSelectedIndexChanged="gvTarget_SelectedIndexChanged"
                    OnRowDataBound="gvTarget_RowDataBound"--%>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkDelete" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KPI" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblTargetID" runat="server" Visible="false" Text='<%# Eval("Target_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KPI" HeaderStyle-Width="290px" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblddlKPIValue" runat="server" Visible="false" Text='<%# Eval("KPI_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="KPI" HeaderStyle-Width="290px">
                        <ItemTemplate>
                            <%--<asp:Label ID="lblRoleID" runat="server" Text='<%# Eval("Role_ID") %>'></asp:Label>--%>
                            <asp:DropDownList ID="ddlKPI" runat="server" CssClass="combo-fw">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <HeaderStyle CssClass="kpi fl" />
                        <ItemStyle CssClass="kpi fl" Width="290px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TestSiteResources,  Value %>">
                        <ItemTemplate>
                            <%--<asp:Label ID="lblActive" ru nat="server" Text='<%# Eval("Active") %>'></asp:Label>--%>
                            <asp:TextBox ID="txtTargetValue" Text='<%# Eval("Target_Value") %>' runat="server"
                                MaxLength="100" ValidationGroup="Insertion" CssClass="combo-fw"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revTargetValue" runat="server" ControlToValidate="txtTargetValue"
                                Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                        </ItemTemplate>
                        <HeaderStyle CssClass="value fl" Width="80px" />
                        <ItemStyle CssClass="value fl" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$ Resources:TestSiteResources,  Reward %>">
                        <ItemTemplate>
                            <%--<asp:Label ID="lblKPIID" runat="server" Text='<%# Eval("KPI_ID") %>'></asp:Label>--%>
                            <asp:TextBox ID="txtPoints" runat="server" MaxLength="100" Text='<%# Eval("TPoints") %>'
                                ValidationGroup="Insertion" CssClass="combo-fw"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPoints"
                                Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                                ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                        </ItemTemplate>
                        <HeaderStyle CssClass="reward fl" Width="95px" />
                        <ItemStyle CssClass="reward fl" Width="95px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="pnlAddGoal" runat="server" Visible="false">
            <div>
                <div>
                    <div class="kpi fl">
                         KPI</div>
                    <div class="value fl">
                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:TestSiteResources,  Value %>"></asp:Label>
                        </div>
                    <div class="reward fl">
                      <asp:Label ID="Label8" runat="server" Text="<%$ Resources:TestSiteResources,  Reward %>"></asp:Label>
                        </div>
                    <div class="clear">
                    </div>
                    <div class="kpi fl">
                        <asp:DropDownList ID="ddlKPI" runat="server" CssClass="combo-fw">
                        </asp:DropDownList>
                    </div>
                    <div class="value fl">
                        <asp:TextBox ID="txtTargetValue" Text='<%# Eval("Target_Value") %>' runat="server"
                            MaxLength="100" ValidationGroup="Insertion" CssClass="combo-fw"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTargetValue" runat="server" ErrorMessage="Provide Target Value"
                            ControlToValidate="txtTargetValue" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTargetValue" runat="server" ControlToValidate="txtTargetValue"
                            Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                            ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                    </div>
                    <div class="value fl">
                        <asp:TextBox ID="txtPoints" runat="server" MaxLength="100" Text='<%# Eval("TPoints") %>'
                            ValidationGroup="Insertion" CssClass="combo-fw"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPoints"
                            Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                            ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                    </div>
                    <div class="fl">
                        <asp:ImageButton ID="ImgCancel" ImageUrl="~/AdminPanel/Images/del-img.png" Width="26px"
                    Height="26px" runat="server" onclick="ImgCancel_Click" />
                    </div>
                </div>
                 
            </div>
        </asp:Panel>
    </div>
    <br />
    <br />
    <div class="fl-wrapper img-r mt10" style="height: 50px">
        <div class="nav-cont fl" style="height: 50px">
            <div class="green-btn fl first-page">
                <%--<img src="images/sa-left.png" width="7" height="12">--%>
                <asp:ImageButton ID="imgbtnleft" ImageUrl="~/AdminPanel/Images/sa-left.png" Width="7"
                    Height="12" runat="server" OnClick="imgbtnleft_Click" />
            </div>
            <div class="simple-btn fl back-page">
                <%-- Level 3 of 8--%>
                Level
                <asp:Label ID="lbllevel" runat="server"></asp:Label>
                of
                <asp:Label ID="lblTotallevel" runat="server"></asp:Label></div>
            <div class="green-btn fl last-page">
                <%--<img src="images/sa-right.png" width="7" height="12">--%>
                <asp:ImageButton ID="imgbtnright" ImageUrl="~/AdminPanel/Images/sa-right.png" Width="7"
                    Height="12" runat="server" OnClick="imgbtnright_Click" /></div>
        </div>
        <div class="right-50 frm">
            <%-- <div class="green-btn add-del-goal fl">
                    Add Goal
                </div>--%>
            <asp:Button ID="btnUpdate" runat="server" Text="<%$ Resources:TestSiteResources,  Update %>" CssClass="green-btn add-del-goal fl"
                OnClick="btnUpdate_Click" Width="80px" ValidationGroup="Insertion" />
            <asp:Button ID="btnAddGoal" runat="server" Text="<%$ Resources:TestSiteResources,  AddGoal %>" CssClass="green-btn add-del-goal fl"
                Width="105px" OnClick="btnAddGoal_Click" />
            <%--<div class="green-btn add-del-goal fl">
                    Delete Goal
                </div>--%>
            <asp:Button ID="btnDeleteGoal" runat="server" Text="<%$ Resources:TestSiteResources,  DeleteGoal %>" CssClass="green-btn add-del-goal fl"
                Width="120px" OnClick="btnDeleteGoal_Click" />
        </div>
        <div class="clear">
        </div>
    </div>
    </div>
    <%-- <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="Back"
            CssClass="green-btn btn fl" onclick="btnHome_Click"></asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
        <div class="lvl-desc edit-block mt50 wbg">
            <asp:Label ID="lblLevelName" runat="server" Text="<%$ Resources:TestSiteResources, NameL %>"></asp:Label>
            
            <asp:TextBox ID="txtLevelName" runat="server" MaxLength="100" ValidationGroup="Insertion"
                Width="136px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvLevelName" runat="server" ErrorMessage="Provide Level Name"
                ControlToValidate="txtLevelName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
            <div class="clear">
            </div>
        </div>
        <div class="lvl-desc edit-block mt50 wbg">
            <asp:Label ID="lblPosition" runat="server" Text="<%$ Resources:TestSiteResources, Position %>"></asp:Label>
            <asp:TextBox ID="txtPosition" runat="server" MaxLength="10" ValidationGroup="Insertion"
                Width="80px" Enabled="False"></asp:TextBox>
            <div class="clear">
            </div>
        </div>
        <div class="lvl-desc edit-block mt50 wbg">
            <asp:Label ID="lblBaseHours" runat="server" Text="<%$ Resources:TestSiteResources, BaseHours %>"></asp:Label>
            <asp:TextBox ID="txtBaseHours" runat="server" MaxLength="10" ValidationGroup="Insertion"
                Width="80px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBaseHours"
                Display="Dynamic" ErrorMessage="Enter only Numeric value for Measure" SetFocusOnError="True"
                ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="rfvBaseHour" runat="server" ControlToValidate="txtBaseHours"
                Display="Dynamic" ErrorMessage="Provide Level Base Hours" SetFocusOnError="True"
                ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
            <div class="clear">
            </div>
        </div>
        <div class="lvl-desc edit-block mt50 wbg">
            <asp:Label ID="lblActive" runat="server" class="edit-name fl" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
            <asp:CheckBox ID="cbActive" runat="server" />
            <asp:HiddenField ID="hdnCheckStatus" runat="server" Visible="false" />
            <div class="clear">
            </div>
        </div>
    </div>
    <asp:Button ID="btnAddLevel" runat="server" Text="<%$ Resources:TestSiteResources, Add %>"
        ValidationGroup="Insertion" OnClick="btnAddLevels_Click" />
    &nbsp;
    <asp:Button ID="btnCancelLevel" runat="server" Text="<%$ Resources:TestSiteResources, Cancel %>"
        OnClick="btnCancel_Click" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="Insertion" />--%>
</asp:Content>
