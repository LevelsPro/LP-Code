<%@ Page Title="Edit Reward" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="RewardEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.RewardEdit"
    EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/admin-theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/admin-website.css" rel="stylesheet" type="text/css" />
    <link href="Styles/horizontal-website.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar({ axis: 'x' });
        });

        function onFileSelect() {
            __doPostBack('ctl00$ContentPlaceHolder1$LinkButton1', '')
        }
    </script>
    <style type="text/css">
        .FUImage
        {
            border: 1px solid #CC3300;
            font: Verdana 10px;
            padding: 1px 4px;
            background-image: url('Images/upload-photo.png');
            width: 106px;
            height: 106px;
            border: 0;
            opacity: 0;
            cursor: pointer;
        }
        .dlTable
        {
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/RewardManagement.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div style="width: 100%;">
        <div class="box brd2">
            <div class="fl-wrapper">
                <asp:Label ID="lblmessage" runat="server" class="edit-left" Visible="False"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="false">LinkButton</asp:LinkButton>
                <div class="clear">
                </div>
                <div class="strip">
                    <asp:Label ID="lblRewardName" runat="server" Text="<%$ Resources:TestSiteResources, RewardName %>"
                        class="edit-left" Width="134px"></asp:Label>
                    <asp:TextBox ID="txtRewardName" class="edit-right tl" runat="server" MaxLength="100"
                        ValidationGroup="Insertion"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRewardName" runat="server" ValidationGroup="Insertion"
                        SetFocusOnError="true" ErrorMessage="Provide Reward name" Display="Dynamic" ControlToValidate="txtRewardName">*</asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="revRewardname" runat="server" ControlToValidate="txtRewardName"
                                Display="Dynamic" ErrorMessage="Enter only Alphabets" SetFocusOnError="True"
                                ValidationExpression="^[a-zA-Z  ]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>--%>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblRewardDescp" runat="server" Text="<%$ Resources:TestSiteResources, Description %>"
                        class="edit-left"></asp:Label>
                    <asp:TextBox ID="txtRewardDescp" class="edit-right tl" runat="server" ValidationGroup="Insertion"
                        MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRewardLimit" runat="server" ErrorMessage="Provide Limit"
                        ControlToValidate="txtRewardDescp" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblRewardPoints" runat="server" Text="<%$ Resources:TestSiteResources, Cost %>"
                        class="edit-left"></asp:Label>
                    <asp:TextBox ID="txtRewardPoints" class="edit-right tl" runat="server" ValidationGroup="Insertion"
                        MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRewardPoints" runat="server" ErrorMessage="Provide Points"
                        ControlToValidate="txtRewardPoints" Display="Dynamic" SetFocusOnError="True"
                        ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revRewardPoints" runat="server" ControlToValidate="txtRewardPoints"
                        Display="Dynamic" ErrorMessage="Enter only Numbers for Points" SetFocusOnError="True"
                        ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                    <div class="clear">
                    </div>
                </div>
                    <div class="strip">
                    <asp:Label ID="lblType" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Type %>"></asp:Label>
                    <asp:DropDownList ID="ddlType" runat="server" class="edit-right wbg">
                        <asp:ListItem Text="Select" Value="-1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Once" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Infinity" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                    <div class="clear">
                    </div>
                </div>
                <%--                    <tr>
                        <td>
                            <asp:Label ID="lblRewardLevel" runat="server" Text="Level:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRewardLevel" runat="server" ValidationGroup="Insertion" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRewardLevel" runat="server" ErrorMessage="Provide Level"
                                ControlToValidate="txtRewardLevel" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revRewardLevel" runat="server" ControlToValidate="txtRewardLevel"
                                Display="Dynamic" ErrorMessage="Enter only Numbers for Level" SetFocusOnError="True"
                                ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                <%--<div class="strip">
                    <asp:Label ID="lblRewardGraphic" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Graphic %>"
                        Width="123px"></asp:Label>
                    <asp:HyperLink ID="hplView" runat="server" class="view" Text="<%$ Resources:TestSiteResources, View %>"
                        rel="lightbox" Visible="false"></asp:HyperLink>--%>
                <%-- <asp:FileUpload ID="fileRewardImage" runat="server" class="edit-right tl browse-file" />
                    <asp:RequiredFieldValidator ID="rfvGraphic" runat="server" ErrorMessage="Reward Graphic is required."
                        ControlToValidate="fileRewardImage" Display="Static" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="fileRewardImage"
                        Display="Dynamic" ErrorMessage=".jpeg, .jpg, .bmp, .png, .tif & gif formats are allowed"
                        SetFocusOnError="True" ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Jj][Pp][Ee][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Pp][Nn][Gg])|.+\.([Gg][Ii][Ff])|.+\.([Tt][Ii][Ff]))"
                        ValidationGroup="Insertion">File format is not allowed. Please choose image file.</asp:RegularExpressionValidator>--%>
                <%-- <div class="clear">
                    </div>
                </div>
            </div>--%>
                <%--<div class="box twob">
                <h1 class="edit-heading">
                    <asp:Literal ID="ltImages" runat="server" Text="<%$ Resources:TestSiteResources, ImagesL %>"></asp:Literal></h1>--%>
                <asp:Panel ID="pnlCurrentImage" runat="server">
                    <div class="lvl-desc edit-block mt10 wbg">
                        <h1 class="edit-name fl">
                            Status</h1>
                        <%--<asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"
                            class="edit-left"></asp:Label>--%>
                        <asp:CheckBox ID="cbActive" runat="server" class="edit-right tl" />
                        <div class="clear">
                        </div>
                    </div>
                    <div class="fl-wrapper img-h">
                        <div class="current-image">
                            <asp:Image ID="imgCurrentImage" runat="server" Width="100px" Height="100" ImageUrl="~/PlayerPanel/Images/imagesNo.jpeg" />
                            <asp:Literal ID="ltimage" runat="server" Text="<%$ Resources:TestSiteResources, CurrentImageL %>"> </asp:Literal>
                        </div>
                        <div class="ul-imgs-sel" id="scrollbar1">
                            <div class="viewport in-cont imgs-sel" style="width: 370px;">
                                <div class="overview" style="margin-top: 17px; margin-left: 12px;">
                                    <div class="mscr">
                                    <table>
                                    <tr>
                                        <td>
                                        <asp:DataList ID="dlImages" runat="server" RepeatDirection="Horizontal"
                                            CssClass="dlTable" OnItemCommand="dlImages_ItemCommand">
                                            <ItemTemplate>
                                                <div class="img-selcont">
                                                    <asp:ImageButton ID="ibtnImage" runat="server" ImageUrl='<%# ConfigurationSettings.AppSettings["RewardsThumbPath"].ToString() + Eval("Reward_Thumbnail") %>'
                                                        Width="106px" Height="106px" CommandName="ViewImages" CommandArgument='<%# Eval("ID") %>' />
                                                    <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="Images/del-img.png" CommandName="DeleteImage"
                                                        CssClass="del" OnClientClick="return confirm('Are you sure you want to delete this image?')"
                                                        CommandArgument='<%# Eval("ID") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        </td>
                                        <td>
                                        <div class="img-selcont1">
                                            <asp:Image ID="imgUpload" runat="server" ImageUrl="Images/upload-photo.png" />
                                            <asp:FileUpload ID="fileRewardImage" runat="server" CssClass="FUImage" onchange="onFileSelect();" />
                                        </div>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileRewardImage"
                                            Display="Dynamic" ErrorMessage=".jpeg, .jpg, .bmp, .png, .tif & gif formats are allowed"
                                            SetFocusOnError="True" ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Jj][Pp][Ee][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Pp][Nn][Gg])|.+\.([Gg][Ii][Ff])|.+\.([Tt][Ii][Ff]))"
                                            ValidationGroup="Insertion" ToolTip=".jpeg, .jpg, .bmp, .png, .tif & gif formats are allowed"
                                            Font-Size="36px" ForeColor="Red">*</asp:RegularExpressionValidator>
                                            </td>
                                            </tr>
                                            </table>
                                    </div>
                                    <div class="clear">
                                    
                                </div>
                            </div>
                            <div class="scrollbar" style="width: 355px; float: right;">
                                <div class="track">
                                    <div class="thumb">
                                        <div class="end">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        <br />

                                    <strong><span class="style1">
                                    </span><span class="style2">(Image Size: 100px * 100px)</span></strong>
                                    </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="strip">
                    <asp:Button ID="btnAddReward" runat="server" class="edit-left" CssClass="green-btn admin-edit fr"
                        Text="<%$ Resources:TestSiteResources, Add %>" ValidationGroup="Insertion" OnClick="btnAddReward_Click1" />
                    &nbsp;
                    <asp:Button ID="btnCancelReward" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
                        Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancelReward_Click" />
                    <div class="clear">
                    </div>
                </div>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="Insertion" />
            </div>
        </div>
    </div>
</asp:Content>
