<%@ Page Title="Add/Edit Player" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="EditPlayer.aspx.cs" Inherits="LevelsPro.EditPlayer" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" CssClass="green-btn btn fl" OnClick="btnBack_Click" />
        <div class="user-nt fl ep">
            <asp:Literal ID="ltHeading" runat="server"></asp:Literal></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" CssClass="green-btn btn fr"
            OnClick="btnLogout_Click"/>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <div>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="false">LinkButton</asp:LinkButton>
            <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
        </div>
        <div class="box admin-btns-cont">
            <asp:Button ID="btnMainInfo" runat="server" Text="<%$ Resources:TestSiteResources, MainInfo %>" CssClass="yellow-btn ad-btns" />
            <asp:Button ID="btnAwards" runat="server" Text="<%$ Resources:TestSiteResources, AwardsB %>" CssClass="green-btn ad-btns"
                OnClick="btnAwards_Click" />
            <asp:Button ID="btnProgress" runat="server" Text="<%$ Resources:TestSiteResources, Progress1 %>" 
                CssClass="green-btn ad-btns" onclick="btnProgress_Click" />
            <asp:Button ID="btnRewards" runat="server" Text="<%$ Resources:TestSiteResources, Reward %>" 
                CssClass="green-btn ad-btns" onclick="btnRewards_Click" />
        </div>
        <div class="usercont-right">
            <div class="fl-wrapper user-data np-user-data">
                <div class="strip" id="divUserName" runat="server">
                    <asp:Label ID="lblUserName" runat="server" Text="<%$ Resources:TestSiteResources, UserID %>"
                        CssClass="edit-left"></asp:Label>
                    <asp:TextBox ID="txtUserName" runat="server" ValidationGroup="Insertion" MaxLength="50"
                        CssClass="edit-right"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                        ErrorMessage="Enter Only Alphanumeric :" SetFocusOnError="True" ValidationExpression="^[a-zA-Z0-9]*$"
                        ValidationGroup="Insertion" ControlToValidate="txtUserName">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter Only Alphanumeric</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                        Display="Dynamic" ErrorMessage="Enter User Name" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                    
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblFirstName" runat="server" Text="<%$ Resources:TestSiteResources, FirstName %>"
                        CssClass="edit-left"></asp:Label>
                    <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="Insertion" MaxLength="50"
                        CssClass="edit-right"></asp:TextBox>
                    
                     <asp:RegularExpressionValidator ID="revFirstName" runat="server" Display="Dynamic" 
                        ErrorMessage="Enter Only Alphabets :" SetFocusOnError="True" ValidationExpression="^[a-zA-Z  ]+$"
                        ValidationGroup="Insertion" ControlToValidate="txtFirstName">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter Only Alphabets</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                        Display="Dynamic" ErrorMessage="Enter First Name" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                   
                   
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblLastName" runat="server" Text="<%$ Resources:TestSiteResources, LastName %>"
                        CssClass="edit-left"></asp:Label>
                    <asp:TextBox ID="txtLastName" runat="server" ValidationGroup="Insertion" MaxLength="50"
                        CssClass="edit-right"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="revLastName" runat="server" Display="Dynamic"
                        ErrorMessage="Enter Only Alphabets :" SetFocusOnError="True" ValidationExpression="^[a-zA-Z  ]+$"
                        ValidationGroup="Insertion" ControlToValidate="txtLastName">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter Only Alphabets</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                        Display="Dynamic" ErrorMessage="Enter Last Name" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                   
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblNickName" runat="server" Text="<%$ Resources:TestSiteResources, NickName %>"
                        CssClass="edit-left"></asp:Label>
                    <asp:TextBox ID="txtNickName" runat="server" MaxLength="50"
                        AutoCompleteType="None" autocomplete="False" CssClass="edit-right"></asp:TextBox>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip" id="divPassword" runat="server">
                    <asp:Label ID="lblPassword" runat="server" Text="<%$ Resources:TestSiteResources, Password %>"
                        CssClass="edit-left"></asp:Label>
                    <input id="user" runat="server" type="password" style="display: none;" />
                    <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="Insertion" TextMode="Password"
                        MaxLength="50" AutoCompleteType="None" autocomplete="False" CssClass="edit-right"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        Display="Dynamic" ErrorMessage="Enter password" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip" id="divCPassword" runat="server">
                    <asp:Label ID="lblConfirmPassword" runat="server" Text="<%$ Resources:TestSiteResources, ConfirmPassword %>"
                        CssClass="edit-left"></asp:Label>
                    <input id="Text1" runat="server" type="password" style="display: none;" />
                    <asp:TextBox ID="txtConfirmPassword" runat="server" ValidationGroup="Insertion" TextMode="Password"
                        MaxLength="50" CssClass="edit-right"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                        Display="Dynamic" ErrorMessage="Enter password" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password does not match."
                        Display="Dynamic" ValidationGroup="Insertion" ControlToCompare="txtPassword"
                        ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip">
                    <asp:Label ID="lblEmail" runat="server" Text="<%$ Resources:TestSiteResources, Email %>"
                        CssClass="edit-left"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="Insertion" MaxLength="50"
                        CssClass="edit-right"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" Display="Dynamic" ErrorMessage="e.g abc@deg.com"
                        SetFocusOnError="True" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$"
                        ValidationGroup="Insertion" ControlToValidate="txtEmail">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.g abc@deg.com</asp:RegularExpressionValidator>
                    <div class="clear">
                    </div>
                </div>
                  <div class="strip" id="HoursRow" runat="server" >
                    <asp:Label ID="lblHours" runat="server" Text="<%$ Resources:TestSiteResources, WorkedHours %>"
                        CssClass="edit-left"></asp:Label>
                    <asp:TextBox ID="txtWorkedHours" runat="server" ValidationGroup="Insertion" MaxLength="50"
                        CssClass="edit-right"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvHours" runat="server" ControlToValidate="txtWorkedHours"
                        Display="Dynamic" ErrorMessage="Enter password" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revHours" runat="server" Display="Dynamic" ErrorMessage="Enter Numeric Value for Hours :"
                        SetFocusOnError="True" ValidationExpression="[0-9]+$"
                        ValidationGroup="Insertion" ControlToValidate="txtWorkedHours">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.g abc@deg.com</asp:RegularExpressionValidator>
                    <div class="clear">
                    </div>
                </div>
                <div class="strip" id="PointsRow" runat="server" visible="false" style="display:none;">
                    <asp:Label ID="lblPoints" runat="server" Text="<%$ Resources:TestSiteResources, Points %>"
                        CssClass="edit-left"></asp:Label>
                    <asp:TextBox ID="txtPoints" runat="server" ValidationGroup="Insertion" MaxLength="50"
                        CssClass="edit-right"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPoints" runat="server" ControlToValidate="txtPoints"
                        Display="Dynamic" ErrorMessage="Enter Only Numeric Values :" SetFocusOnError="True"
                        ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Enter Only Numeric Values</asp:RegularExpressionValidator>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="left-ar">
                <asp:Literal ID="lblGeneralRole" runat="server" Text="<%$ Resources:TestSiteResources, ApplicationRole %>"></asp:Literal>
            </div>
            <div class="right-ar">
                <asp:DropDownList ID="ddlGeneralRole" runat="server" Width="139px" ValidationGroup="Insertion"
                    CssClass="assign-combo">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGeneralRole" runat="server" ControlToValidate="ddlGeneralRole"
                    Display="Dynamic" ErrorMessage="Enter General Role" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
            </div>
            <div class="clear">
            </div>
            <div class="left-ar">
                <asp:Literal ID="lblRole" runat="server" Text="<%$ Resources:TestSiteResources, Role %>"></asp:Literal>
            </div>
            <div class="right-ar">
                <asp:DropDownList ID="ddlRole" runat="server" Width="139px" ValidationGroup="Insertion"
                    OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" AutoPostBack="True" CssClass="assign-combo">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvRole" runat="server" ControlToValidate="ddlRole"
                    Display="Dynamic" ErrorMessage="Enter Role" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
            </div>
            <div class="clear">
            </div>
            <div class="left-ar">
                <asp:Literal ID="lblLevel" runat="server" Text="<%$ Resources:TestSiteResources, Level %>"></asp:Literal>
            </div>
            <div class="right-ar">
                <asp:DropDownList ID="ddlLevel" runat="server" ValidationGroup="Insertion" AutoPostBack="true"
                    Width="139px" OnSelectedIndexChanged="ddlLevel_SelectedIndexChanged" CssClass="assign-combo">
                </asp:DropDownList>
            </div>
            <div class="clear">
            </div>
            <div class="left-ar">
                <asp:Literal ID="lblSite" runat="server" Text="<%$ Resources:TestSiteResources, Site %>"></asp:Literal>
            </div>
            <div class="right-ar">
                <asp:DropDownList ID="ddlSite" runat="server" Width="139px" CssClass="assign-combo">
                </asp:DropDownList>
            </div>
            <div class="clear">
            </div>
            <div class="left-ar">
                <asp:Literal ID="lblManager" runat="server" Text="<%$ Resources:TestSiteResources, Manager %>"></asp:Literal>
            </div>
            <div class="right-ar">
                <asp:DropDownList ID="ddlManager" runat="server" Width="139px" ValidationGroup="Insertion"
                    CssClass="assign-combo">
                </asp:DropDownList>
            </div>
            <div class="clear">
            </div>
            <div class="left-ar">
                <asp:Literal ID="lblActive" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Literal>
            </div>
            <div class="right-ar">
                <asp:CheckBox ID="cbActive" runat="server" />
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="box twob" id="divImages" runat="server" visible="false">
        <h1 class="edit-heading">
            <asp:Literal ID="ltImages" runat="server" Text="<%$ Resources:TestSiteResources, ImagesL %>"></asp:Literal></h1>
        <div class="fl-wrapper img-h">
            <div class="current-image">
                <asp:Image ID="imgCurrentImage" runat="server" Width="100px" Height="100" ImageUrl="~/PlayerPanel/Images/imagesNo.jpeg" />
                <asp:Literal ID="ltimage" runat="server" Text="<%$ Resources:TestSiteResources, CurrentImageL %>"> </asp:Literal>
            </div>
            <div class="ul-imgs-sel" id="scrollbar1">
                <div class="viewport in-cont imgs-sel" style="width: 370px;">
                    <div class="overview" style="margin-top:17px;margin-left:12px;">
                        <div class="mscr">
                        <table>
                        <tr>
                        <td>
                            <asp:DataList ID="dlImages" runat="server" RepeatDirection="Horizontal"
                                OnItemCommand="dlImages_ItemCommand" DataKeyField="U_UserIDImage" CssClass="dlTable">
                                <ItemTemplate>
                                    <div class="img-selcont">
                                        <asp:ImageButton ID="ibtnImage" runat="server" ImageUrl='<%# ConfigurationManager.AppSettings["PlayersThumbPath"].ToString() + Eval("Player_Thumbnail") %>'
                                            Width="106px" Height="106px" CommandArgument='<%# Eval("U_UserIDImage") + "|" + Eval("UserID") %>' CommandName="ViewImages" />
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
                                Font-Size="36px" ForeColor="Red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.jpeg, .jpg, .bmp, .png, .tif & gif formats are allowed</asp:RegularExpressionValidator>
                                </td>
                                </tr>
                                </table>
                        </div>
                        
                        <div class="clear">
                        </div>
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
            </div>
        </div>
    </div>
    <div class="m0 ub-div" style="width:110px;">
        <asp:Button ID="btnInsertInfo" runat="server" Text="<%$ Resources:TestSiteResources, Save %>"
            ValidationGroup="Insertion" OnClick="btnInsertInfo_Click" CssClass="green-btn btn" />
    </div>
</asp:Content>
