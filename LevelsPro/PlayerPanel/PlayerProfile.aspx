<%@ Page Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="PlayerProfile.aspx.cs" Inherits="LevelsPro.PlayerPanel.PlayerProfile"
    EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<%@ Register TagPrefix="uc" TagName="Profile" Src="~/PlayerPanel/UserControls/uc_Profile.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-57350527-1', 'auto');
        ga('send', 'pageview');

    </script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <%--<link href="Styles/website.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/horizontal-website.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            


            $('.strip').last().css("border", 0);

            var maxWidth = $('.fl-wrapper').width();
            $('.imgs-sel').width(maxWidth - 190);
            $('.scrollbar, .track').width(maxWidth - 190);
            

            $(window).resize(function () {

                var maxWidth = $('.fl-wrapper').width();
                $('.imgs-sel').width(maxWidth - 190);
                $('.scrollbar, .track').width(maxWidth - 190);

                $('#scrollbar1').tinyscrollbar({ axis: 'x' });

            });

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
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="false">LinkButton</asp:LinkButton>
    <div class="container">
        <div class="top-b">
            <div class="green-ar-wrapper fl home-btn">
                <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, HomeAdmin %>"
                    PostBackUrl="~/PlayerPanel/PlayerHome.aspx" CssClass="green-ar"></asp:Button>
            </div>
            <div class="user-nt">
                <asp:Literal ID="lblName" runat="server"></asp:Literal></div>
            <div class="green-wrapper logout">
                <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
                    CssClass="green" OnClick="btnLogout_Click"></asp:Button>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="body-cont">
            <uc:Profile ID="ViewProfile" runat="server" />
            <div class="clear">
            </div>
            <div class="box twob">
                <h1 class="edit-heading">
                    <asp:Literal ID="lblName1" runat="server" Text="<%$ Resources:TestSiteResources, Name %>"></asp:Literal></h1>
                <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
                <div class="fl-wrapper">
                    <div class="strip">
                        <asp:Label ID="lblFirstName" runat="server" Text="<%$ Resources:TestSiteResources, FirstName %>"
                            CssClass="edit-left"></asp:Label>
                        <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="Insertion" MaxLength="20"
                            CssClass="edit-right"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                            Display="Dynamic" ErrorMessage="Enter First Name" SetFocusOnError="True" ValidationGroup="Insertion"
                            ToolTip="Enter First Name" Font-Size="36px" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFirstName" runat="server" Display="Dynamic"
                            ErrorMessage="Enter Only Alphabets" SetFocusOnError="True" ValidationExpression="^[a-zA-Z  ]+$"
                            ValidationGroup="Insertion" ControlToValidate="txtFirstName" ToolTip="Enter Only Alphabets"
                            Font-Size="36px" ForeColor="Red">*</asp:RegularExpressionValidator>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip">
                        <asp:Label ID="lblLastName" runat="server" Text="<%$ Resources:TestSiteResources, LastName %>"
                            CssClass="edit-left"></asp:Label>
                        <asp:TextBox ID="txtLastName" runat="server" ValidationGroup="Insertion" MaxLength="20"
                            CssClass="edit-right"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                            Display="Dynamic" ErrorMessage="Enter Last Name" SetFocusOnError="True" ValidationGroup="Insertion"
                            ToolTip="Enter Last Name" Font-Size="36px" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revLastName" runat="server" Display="Dynamic"
                            ErrorMessage="Enter Only Alphabets" SetFocusOnError="True" ValidationExpression="^[a-zA-Z  ]+$"
                            ValidationGroup="Insertion" ControlToValidate="txtLastName" ToolTip="Enter Only Alphabets"
                            Font-Size="36px" ForeColor="Red">*</asp:RegularExpressionValidator>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip ">
                        <asp:Label ID="lblNickName" runat="server" Text="<%$ Resources:TestSiteResources, NickName %>"
                            CssClass="edit-left"></asp:Label>
                        <asp:TextBox ID="txtNickName" runat="server" ValidationGroup="Insertion" MaxLength="20"
                            CssClass="edit-right"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvNickName" runat="server" ControlToValidate="txtNickName"
                            Display="Dynamic" ErrorMessage="Enter Nick Name" SetFocusOnError="True" ValidationGroup="Insertion"
                            ToolTip="Enter Nick Name" Font-Size="36px" ForeColor="Red">*</asp:RequiredFieldValidator>--%>
                        <div class="clear">
                        </div>
                    </div>
                    <asp:UpdatePanel ID="upRadiobutton" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <div class="strip ">
                        <asp:Label ID="lblDisplayName" runat="server" Text="<%$ Resources:TestSiteResources, DisplayName %>"
                            CssClass="edit-left"></asp:Label>
                        <asp:RadioButtonList ID="rblName" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                            CssClass="edit-right" 
                            onselectedindexchanged="rblName_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="<%$ Resources:TestSiteResources, FullName %>" Value="Full" Selected="True"
                                style="font-size: 24px" />
                            <asp:ListItem Text="<%$ Resources:TestSiteResources, NickNameR %>" Value="Nick" style="font-size: 24px" />
                        </asp:RadioButtonList>
                        <div class="clear">
                        </div>
                    </div>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <%--<div class="box twob">
                <h1 class="edit-heading">
                    Social Media</h1>
                <div class="fl-wrapper">
                    <div class="strip">
                        <span class="edit-left">Twitter Account</span> <span class="edit-right">Jennytweets123</span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip">
                        <span class="edit-left">Twitter Password</span> <span class="edit-right">**********</span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip ">
                        <span class="edit-left">Facebook Account</span> <span class="edit-right">jennyjohnson123</span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip ">
                        <span class="edit-left">Facebook Password</span> <span class="edit-right">********</span>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>--%>
            <div class="box twob">
                <h1 class="edit-heading">
                    <asp:Literal ID="ltImages" runat="server" Text="<%$ Resources:TestSiteResources, ImagesL %>"></asp:Literal></h1>
                <div class="fl-wrapper img-h">
                    <div class="current-image">
                        <asp:Image ID="imgCurrentImage" runat="server" Width="100px" Height="100" ImageUrl="~/PlayerPanel/Images/imagesNo.jpeg" />
                        <asp:Literal ID="ltimage" runat="server" Text="<%$ Resources:TestSiteResources, CurrentImageL %>"> </asp:Literal>
                    </div>
                    <div class="ul-imgs-sel" id="scrollbar1">
                        <div class="viewport in-cont imgs-sel">
                            <div class="overview">
                                <div class="mscr">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:DataList ID="dlImages" runat="server" RepeatDirection="Horizontal" OnItemCommand="dlImages_ItemCommand"
                                                    DataKeyField="U_UserIDImage" CssClass="dlTable">
                                                    <ItemTemplate>
                                                        <div class="img-selcont">
                                                            <asp:ImageButton ID="ibtnImage" runat="server" ImageUrl='<%# ConfigurationManager.AppSettings["PlayersThumbPath"].ToString() + Eval("Player_Thumbnail") %>'
                                                                Width="106px" Height="106px" CommandArgument='<%# Eval("U_UserIDImage") %>' CommandName="ViewImages" />
                                                            <asp:ImageButton ID="ibtnDelete" runat="server" ImageUrl="Images/del-img.png" CommandArgument='<%# Eval("U_UserIDImage") %>'
                                                                CommandName="DeleteImage" CssClass="del" OnClientClick="return confirm('Are you sure you want to delete this image?')" />
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                            <td>
                                                <div class="img-selcont1">
                                                    <asp:Image ID="imgUpload" runat="server" ImageUrl="Images/upload-photo.png" />
                                                    <asp:FileUpload ID="fileUserImage" runat="server" CssClass="FUImage" onchange="onFileSelect();" />
                                                </div>
                                                <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="fileUserImage"
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
                        <div class="scrollbar">
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
                <table align="center">
                
                    <tr>
                        <td>
                            
                            <div class="green-wrapper fl reply-msg">
                                <asp:Button ID="btnUpdateInfo" runat="server" Text="<%$ Resources:TestSiteResources, UpdateProfileB %>"
                                    ValidationGroup="Insertion" OnClick="btnUpdateInfo_Click" CssClass="green" />
                            </div>

                        </td>
                    </tr>

                </table>
                
            <div class="clear"></div>
            </div>
            
        </div>
        
    </div>
</asp:Content>
