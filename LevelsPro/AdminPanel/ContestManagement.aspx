<%@ Page Title="Contest Management" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="ContestManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.ContestManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   	<link href="Styles/admin-theme.css" rel="stylesheet" type="text/css" />
	<link href="Styles/admin-website.css" rel="stylesheet" type="text/css" />
     <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <link href="../Styles/lightbox.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.smooth-scroll.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script src="../Scripts/lightbox.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
    </script>
    <script type="text/javascript">
                function dateselect(ev) {



                    var calendarBehavior1 = $find("calID");
                    var d = calendarBehavior1._selectedDate;
                    var now = new Date();
                    calendarBehavior1.get_element().value = d.format("yyyy/MM/dd") + " " + "11:59:59"



                }

                function Compare() {
                    var TextBox = document.getElementById('<%= txtStartDate.ClientID %>');

                    var StartDate = Date.parse(TextBox.value);


                    var TextBox1 = document.getElementById('<%= txtEndDate.ClientID %>');

                    var DueDate = Date.parse(TextBox1.value);                   
                    
                    if (StartDate < DueDate) {
                        //alert(""); 
                        return true;
                    }
                    else {

                        alert("End Date Must be Greater Than Start Date")
                    }                                            
                }


                function CompareCurrent() {
                    var TextBox = document.getElementById('<%= txtStartDate.ClientID %>');

                    var StartDate = Date.parse(TextBox.value);                    


                    var curdate = new Date();

                    var cmonth = curdate.getMonth() + 1;

                    var cday = curdate.getDate();

                    var cyear = curdate.getFullYear();

                    var currentdate = Date.parse(cmonth + "/" + cday + "/" + cyear);


                    if (currentdate <= StartDate) {
                                             
                        return true;
                    }
                    else {
                        alert("Start Date Must be Greater Than Current Date");

                    }
                }

                
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="box top-b options-bar">
        
             <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" 
            PostBackUrl="~/AdminPanel/AdminHome.aspx" CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources,  ManageContests %>"></asp:Label>
           </div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" onclick="btnLogout_Click" ></asp:Button>
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
                    <asp:UpdatePanel ID="upgvRoles" runat="server">
                        <ContentTemplate>
                            <asp:DataList ID="dlContest" runat="server" DataKeyField="Contest_ID" Width="100%">
                                <ItemTemplate>
                                    <div class="adminprog-cont">
                                    <asp:Image ID="imgContestImage" runat="server" class="fl" width="76" height="76" ImageUrl='<%#"~/view-file.aspx?contestid="+Eval("Contest_ID")%>'
                                                />
                                        <h1 class="admin-text">
                                       
                                            <asp:Literal ID="ltContestName" runat="server" Text='<%# Eval("Contest_Name")%>'/><br />
                                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Role_Name") %>'/> - expires 
                                            <asp:Literal ID="Literal2" runat="server" Text='<%# Convert.ToDateTime(Eval("Contest_EndDate")).ToString("MM/dd")%> '/></h1>
                                        <asp:Button ID="btnEditContest" runat="server" CssClass="green-btn admin-edit fr" CommandName="EditContest" Text="<%$ Resources:TestSiteResources, Edit %>" />
                                        <div class="clear">
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                            <div class="adminprog-cont crt-reward">
                             <asp:Button ID="Button1" runat="server" Text="<%$ Resources:TestSiteResources, CreateNewContest %>"
                             CssClass="green-btn create-reward"></asp:Button>
                                <%--<input type="button" class="green-btn create-reward" value="Create New Contest" />--%>
                            </div>
                            
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div class="clear"></div>
		
		
		<div class="left-50 mt10">
		
			<select class="sort-filter">
				<option>Sort by...</option>
			</select><br />
			
			<select class="sort-filter">
				<option>Filter by...</option>
			</select>
		
		</div>
		
		<div class="right-50 mt46">
		
			<div class="green-btn create-reward fr">Delete Contest</div>
		
		</div>
		<div class="clear"></div>
    <div style="width: 100%;display:none;">
        <asp:UpdatePanel ID="upContest" runat="server">
            <ContentTemplate>
                <h3>
                    <asp:Label ID="lblContestManagement" runat="server" Text="<%$ Resources:TestSiteResources, ContestManagement %>"></asp:Label></h3>
                <br />
                <br />
                <table cellpadding="3" cellspacing="0" width="100%">
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%">
                            <asp:Label ID="lblContestName" runat="server" Text="<%$ Resources:TestSiteResources, NameL %>"></asp:Label>
                        </td>
                        <td width="75%">
                            <asp:TextBox ID="txtContestName" runat="server" MaxLength="100" ValidationGroup="Insertion"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContestName" runat="server" ErrorMessage="Provide Contest Name"
                                ControlToValidate="txtContestName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revContestname" runat="server" ControlToValidate="txtContestName"
                                Display="Dynamic" ErrorMessage="Enter only Alphabets" SetFocusOnError="True"
                                ValidationExpression="^[a-zA-Z  ]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <%--            <tr>
                <td>
                    <asp:Label ID="lblContestDur" runat="server" Text="Duration:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContestDur" runat="server" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvContestDur" runat="server" ErrorMessage="Provide Contest Duration:"
                        ControlToValidate="txtContestDur" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revContestDur" runat="server" 
                        ControlToValidate="txtContestDur" Display="Dynamic" 
                        ErrorMessage="Enter only Alphabets" SetFocusOnError="True" 
                        ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                </td>
            </tr>--%>
                    <tr>
                        <td width="25%">
                            <asp:Label ID="lblStartDate" runat="server" Text="<%$ Resources:TestSiteResources, StartDate %>" Width="134px"></asp:Label>
                        </td>
                        <td width="75%">
                            <asp:TextBox ID="txtStartDate" runat="server" MaxLength="100" ValidationGroup="Insertion"></asp:TextBox>
                            <asp:CalendarExtender ID="ceStartDate" runat="server" TargetControlID="txtStartDate" 
                                Format="yyyy/MM/dd HH:mm:ss" PopupPosition="BottomRight" FirstDayOfWeek="Monday">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ValidationGroup="Insertion"
                                SetFocusOnError="true" ErrorMessage="Provide Start Date" Display="Dynamic" ControlToValidate="txtStartDate">*</asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="revStartDate" runat="server" ControlToValidate="txtStartDate"
                                Display="Dynamic" ErrorMessage="Enter in form mm/dd/yy" SetFocusOnError="True"
                                ValidationExpression="^[0-9]{4}/[0-9]{1,2}/[0-9]{1,2}$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>--%>
                                 <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtStartDate" 
                                 ErrorMessage="Start date should be greater than or equal to today." Operator="GreaterThanEqual" Type="Date"
                               ValuetoCompare='<%# DateTime.Now.ToString("MM/dd/yyyy")%>' Display="Dynamic" ValidationGroup="Insertion"></asp:CompareValidator>--%>
                               <%--<asp:CustomValidator OnServerValidate="ValidateDuration"
                                   ID="CustomValidator1" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>--%>
                               
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEndDate" runat="server" Text="<%$ Resources:TestSiteResources, EndDate %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndDate" runat="server" ValidationGroup="Insertion" MaxLength="100" onchange="Compare();"></asp:TextBox>
                            <asp:CalendarExtender ID="ceEndDate" runat="server" TargetControlID="txtEndDate" BehaviorID="calID" OnClientDateSelectionChanged="dateselect"
                                Format="yyyy/MM/dd HH:mm:ss" PopupPosition="BottomRight" FirstDayOfWeek="Monday">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ErrorMessage="Provide End Date"
                                ControlToValidate="txtEndDate" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                            <%--<asp:RegularExpressionValidator ID="revEndDate" runat="server" ControlToValidate="txtEndDate"
                                Display="Dynamic" ErrorMessage="Enter in form mm/dd/yy" SetFocusOnError="True"
                                ValidationExpression="^[0-9]{4}/[0-9]{1,2}/[0-9]{1,2}$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                                <asp:CompareValidator ControlToCompare="txtStartDate"
                                ControlToValidate="txtEndDate"
                                Display="Dynamic"
                                ErrorMessage="End Date Must Be Greater then the Start Date"
                                ID="CompareValidator2"
                                Operator="GreaterThanEqual"
                                Type="Date"
                                runat="server"
                                ValidationGroup="Insertion" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblContestGraphic" runat="server" Text="<%$ Resources:TestSiteResources, Graphic %>" Width="123px"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="fileContestImage" runat="server" />
                            
                            <asp:RequiredFieldValidator ID="rfvGraphic" runat="server" ErrorMessage="Contest Graphic is required."
                        ControlToValidate="fileContestImage" Display="Static" SetFocusOnError="True" ValidationGroup="Insertion">*</asp:RequiredFieldValidator>
                   
                            <asp:RegularExpressionValidator ID="uplValidator" runat="server" ControlToValidate="fileContestImage"
                 Display="Dynamic" ErrorMessage=".jpeg, .jpg, .bmp, .png, .tif & gif formats are allowed"  SetFocusOnError="True"
                 ValidationExpression="(.+\.([Jj][Pp][Gg])|.+\.([Jj][Pp][Ee][Gg])|.+\.([Bb][Mm][Pp])|.+\.([Pp][Nn][Gg])|.+\.([Gg][Ii][Ff])|.+\.([Tt][Ii][Ff]))"  ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                          
                           <asp:HyperLink ID="hplView" runat="server" Text="<%$ Resources:TestSiteResources, View %>" rel="lightbox" Visible="false"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="30%">
                            <asp:Label ID="lblSite" runat="server" Text="<%$ Resources:TestSiteResources, Site %>"></asp:Label>
                        </td>
                        <td width="70%">
                            <asp:DropDownList ID="ddlSite" runat="server" Width="139px" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRoleName" runat="server" Text="<%$ Resources:TestSiteResources, Role %>"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRole" runat="server" Width="139px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblKPIName" runat="server" Text="<%$ Resources:TestSiteResources, KPINameL %>"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlKPI" runat="server" Width="139px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvKPIName" runat="server" ErrorMessage="Provide KPI Name"
                                ControlToValidate="ddlKPI" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"
                                InitialValue="0"> * </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trActive" runat="server" visible="false">
                        <td>
                            <asp:Label ID="lblActive" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbActive" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnAddContest" runat="server" Text="<%$ Resources:TestSiteResources, Add %>" ValidationGroup="Insertion"
                                OnClick="btnAddContest_Click" />
                            &nbsp;
                            <asp:Button ID="btnCancelContest" runat="server" Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="Insertion" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvContest" runat="server" ForeColor="#333333" Width="70%" CaptionAlign="Top"
                                CellPadding="4" EmptyDataText="No Records Found" DataKeyNames="Contest_ID" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="gvContest_SelectedIndexChanged" OnRowDataBound="gvContest_RowDataBound">
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
                                            <asp:Label ID="lblRoleID" runat="server" Text='<%# Eval("Role_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContestGraphicExt" runat="server" Text='<%# Eval("Contest_Graphics_Ext") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" AlternateText="<%$ Resources:TestSiteResources, Edit %>" Height="17px" ImageUrl="images/btn_edit.gif"
                                                Width="15px" CommandName="Select" ToolTip="Click to edit the record" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No." ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:BoundField DataField="Role_ID" HeaderText="ID" />--%>
                                    <asp:BoundField DataField="Contest_Name" HeaderText="<%$ Resources:TestSiteResources, Name %>" ItemStyle-Width="435px" />
                                    <asp:BoundField DataField="Role_Name" HeaderText="<%$ Resources:TestSiteResources, RoleH %>" ItemStyle-Width="435px" />
                                    <asp:BoundField DataField="Contest_StartDate" HeaderText="<%$ Resources:TestSiteResources, StartDateH %>" ItemStyle-Width="435px"
                                        DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" />
                                    <asp:BoundField DataField="Contest_EndDate" HeaderText="<%$ Resources:TestSiteResources, EndDateH %>" ItemStyle-Width="435px"
                                        DataFormatString="{0:yyyy/MM/dd HH:mm:ss}" />
                                    <asp:BoundField DataField="site_name" HeaderText="<%$ Resources:TestSiteResources, SiteH %>" ItemStyle-Width="435px" />
                                    <asp:BoundField DataField="KPI_name" HeaderText="<%$ Resources:TestSiteResources, KPI %>" ItemStyle-Width="435px" />
                                    <asp:TemplateField HeaderText="<%$ Resources:TestSiteResources, GraphicH %>" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%--<asp:Image ID="imgAwardImage" runat="server" ImageUrl='data:image/jpg;base64,<%# Convert.ToBase64String((byte[])Eval("Award_Graphics"),0,((byte[])Eval("Award_Graphics")).Length) %>' Height="100px" Width="100px" />--%>
                                            <asp:Image ID="imgContestImage" runat="server" ImageUrl='<%#"~/view-file.aspx?contestid="+Eval("Contest_ID")%>'
                                                Height="30px" Width="30px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSiteID" runat="server" Text='<%# Eval("Site_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKPIID" runat="server" Text='<%# Eval("KPIID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnAddContest" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
