<%@ Page Title="Edit Award" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="AwardEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.AwardEdit"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="Styles/admin-theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/admin-website.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="Scripts/jquery.min.js" type="text/javascript"></script>--%>
    <link href="Styles/horizontal-website.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar({ axis: 'x' });

            $('#<%= ddlManual.ClientID %>').on('change', function () {
                //alert(this.value);
                if (this.value != '-1') {
                    if (this.value == '0') {
                        document.getElementById('<%= ddlKPI.ClientID %>').style.visibility = 'visible';  //ddlKPI.Visible = false;
                        document.getElementById('<%= txtTarget.ClientID %>').style.visibility = 'visible'; //txtTarget.Visible = false;
                        document.getElementById('<%= lblAwardKPI.ClientID %>').style.visibility = 'visible';
                        document.getElementById('<%= lblTarget.ClientID %>').style.visibility = 'visible';

                    }
                    else {
                        document.getElementById('<%= ddlKPI.ClientID %>').style.visibility = 'hidden';  //ddlKPI.Visible = false;
                        document.getElementById('<%= txtTarget.ClientID %>').style.visibility = 'hidden'; //txtTarget.Visible = false;
                        document.getElementById('<%= lblAwardKPI.ClientID %>').style.visibility = 'hidden';
                        document.getElementById('<%= lblTarget.ClientID %>').style.visibility = 'hidden';
                        document.getElementById('<%= txtTarget.ClientID %>').value = '';
                    }
                }
            });

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
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/AwardManagement.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
            <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <%--<asp:UpdatePanel ID="upAward" runat="server">
            <ContentTemplate>--%>
    <%-- <h3>
            <asp:Label ID="lblAwardManagement" runat="server" Text="<%$ Resources:TestSiteResources, AwardManagement %>"></asp:Label></h3>
        <br />
        <br />--%>
    <div class="box brd2">
        <div class="fl-wrapper">
            <asp:Label ID="lblmessage" runat="server" class="edit-left" Visible="False"></asp:Label>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="false">LinkButton</asp:LinkButton>
            <div class="clear">
            </div>
            <div class="strip">
                <asp:Label ID="lblAwardName" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, NameL %>"></asp:Label>
                <asp:TextBox ID="txtAwardName" runat="server" class="edit-right tl" MaxLength="100"
                    ValidationGroup="Insertion"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAwardName" runat="server" ErrorMessage="Provide Award Name"
                    ControlToValidate="txtAwardName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                <%--<asp:RegularExpressionValidator ID="revAwardname" runat="server" 
                        ControlToValidate="txtAwardName" Display="Dynamic" 
                        ErrorMessage="Enter only Alphabets" SetFocusOnError="True" 
                        ValidationExpression="^[a-zA-Z  ]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>--%>
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblAwardDesc" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Description %>"></asp:Label>
                <asp:TextBox ID="txtAwardDesc" runat="server" class="edit-right tl" ValidationGroup="Insertion"
                    MaxLength="200"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAwardDesc" runat="server" ErrorMessage="Provide Award Description:"
                    ControlToValidate="txtAwardDesc" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                <%--<asp:RegularExpressionValidator ID="revAwardDesc" runat="server" 
                        ControlToValidate="txtAwardDesc" Display="Dynamic" 
                        ErrorMessage="Enter only Alphabets" SetFocusOnError="True" 
                        ValidationExpression="^[a-zA-Z  ]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>--%>
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblTarget" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, TargetL %>"></asp:Label>
                <asp:TextBox ID="txtTarget" runat="server" class="edit-right tl" ValidationGroup="Insertion"
                    MaxLength="10"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="rfvTarget" runat="server" ErrorMessage="*"
                        ControlToValidate="txtTarget" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"></asp:RequiredFieldValidator>--%>
                <asp:RegularExpressionValidator ID="revTarget" runat="server" ControlToValidate="txtTarget"
                    Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>
                <%--<asp:DropDownList ID="ddlTarget" runat="server" Width="142px" 
                         AutoPostBack="true">
                    </asp:DropDownList>--%>
                <div class="clear">
                </div>
            </div>
        </div>
        <%--<tr>
                <td>
                    <asp:Label ID="lblAwardDur" runat="server" Text="Award Duration:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAwardDur" runat="server" ValidationGroup="Insertion" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAwardDur" runat="server" ErrorMessage="Provide Award Duration:"
                        ControlToValidate="txtAwardDur" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revAwardDur" runat="server" 
                        ControlToValidate="txtAwardDur" Display="Dynamic" 
                        ErrorMessage="Enter only Numbers for Duration" SetFocusOnError="True" 
                        ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                </td>
            </tr>--%>
        <div class="fl-wrapper mt10">
            <div class="lvl-desc edit-block mt10 wbg">
                <div class="strip">
                    <asp:Label ID="lblAwardKPI" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, KPIL %>"></asp:Label>
                    <asp:DropDownList ID="ddlKPI" runat="server" class="edit-right wbg">
                    </asp:DropDownList>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblAwardCategory" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, AwardCategory %>"></asp:Label>
                    <asp:DropDownList ID="ddlAwardCategory" runat="server" class="edit-right wbg">
                    </asp:DropDownList>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblManual" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Manual %>"></asp:Label>
                    <asp:DropDownList ID="ddlManual" runat="server" class="edit-right wbg">
                        <asp:ListItem Text="Select" Value="-1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Automatic" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Manual" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblActive" runat="server" class="edit-name fl" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
                    <asp:CheckBox ID="cbActive" runat="server" class="edit-right tl" />
                    <div class="clear">
                    </div>
                </div>
                <%--<asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"
                            class="edit-left"></asp:Label>--%>
            </div>
        </div>
        <asp:Panel ID="pnlImg" runat="server">
            <div class="fl-wrapper img-r mt10">
                <div class="current-image">
                    <asp:Image ID="imgCurrentImage" runat="server" Width="100px" Height="100" ImageUrl="Images/placeholder.png" />
                    <asp:Literal ID="ltimage" runat="server" Text="<%$ Resources:TestSiteResources, CurrentImageL %>"> </asp:Literal>
                </div>
                <div class="ul-imgs-sel" id="scrollbar1">
                    <div class="viewport in-cont imgs-sel" style="width: 370px;">
                        <div class="overview" style="margin-top: 17px; margin-left: 12px;">
                            <div class="mscr">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:DataList ID="dlImages" runat="server" RepeatDirection="Horizontal" CssClass="dlTable"
                                                OnItemCommand="dlImages_ItemCommand">
                                                <ItemTemplate>
                                                    <div class="img-selcont">
                                                        <asp:ImageButton ID="ibtnImage" runat="server" ImageUrl='<%# ConfigurationSettings.AppSettings["AwardsThumbPath"].ToString() + Eval("Award_Thumbnail") %>'
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
                                                <asp:FileUpload ID="fileAwardImage" runat="server" CssClass="FUImage" onchange="onFileSelect();" />
                                            </div>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileAwardImage"
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
                    </div>
                    <div class="scrollbar" style="width: 400px; float: right;">
                        <div class="track">
                            <div class="thumb">
                                <div class="end">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <%-- <div class="strip">
                    <asp:Label ID="lblAwardGraphic" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Graphic %>"
                        Width="123px"></asp:Label>

                     <asp:HyperLink ID="hplView" runat="server" class="view" Text="<%$ Resources:TestSiteResources, View %>"
                        rel="lightbox" Visible="false"></asp:HyperLink>

                    <asp:FileUpload ID="fileAwardImage" class="edit-right tl browse-file" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvGraphic" runat="server" ErrorMessage="Award Graphic is required."
                        ControlToValidate="fileAwardImage" Display="Static" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="fileAwardImage"
                        Display="Dynamic" ErrorMessage=".jpeg, .jpg, .bmp, .png, .tif & gif formats are allowed"
                        SetFocusOnError="True" ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Jj][Pp][Ee][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Pp][Nn][Gg])|.+\.([Gg][Ii][Ff])|.+\.([Tt][Ii][Ff]))"
                        ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                   
                    <div class="clear">
                    </div>
                </div>
               
                </div>
               <div class="fl-wrapper mt10">
             
               
                
                   
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="Insertion" />
            </div>--%>
        <asp:Button ID="btnAddAward" runat="server" class="edit-left" CssClass="green-btn admin-edit fr"
            Text="<%$ Resources:TestSiteResources, Add %>" ValidationGroup="Insertion" OnClick="btnAddAward_Click" />
        &nbsp;
        <asp:Button ID="btnCancelAward" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
            Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
        <div class="clear">
        </div>
    </div>
</asp:Content>
