<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" AutoEventWireup="true" CodeBehind="KPIEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.KPIEdit" %>

<%@ Register TagPrefix="uc" TagName="Tips" Src="~/AdminPanel/UserControls/uc_TipsTricks.ascx" %>
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
<script type="text/javascript">
    function AllowOnlyAlphabets(e) {
        isIE = document.all ? true : false;
        keyEntry = (!isIE) ? e.which : event.keyCode;
        if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || keyEntry == '45' || keyEntry == '0' || keyEntry == '8' || keyEntry == '32')

            return true;
        else
            return false;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
 <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/KPIManagement.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
           <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" onclick="btnLogout_Click1" ></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div style="width:100%;">
    	<div class="box brd2">
		 <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
		<div class="lvl-desc edit-block">
                    <asp:Label ID="lblKPIName" runat="server" class="edit-name fl" Text="<%$ Resources:TestSiteResources, KPIName %>"></asp:Label>
               
                    <asp:TextBox ID="txtKPIName" runat="server" class="edit-desc fl" MaxLength="100" ValidationGroup="Insertion"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvKPIName" runat="server" ErrorMessage="Provide KPI Name"
                        ControlToValidate="txtKPIName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="revKPIname" runat="server" 
                        ControlToValidate="txtKPIName" Display="Dynamic" 
                        ErrorMessage="Enter only Alphabets" SetFocusOnError="True" 
                        ValidationExpression="^[a-zA-Z  ]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>--%>
                <div class="clear"></div>
                </div>
                <div class="note"><asp:Label ID="lblHeading1" runat="server" Text="<%$ Resources:TestSiteResources, Note %>"></asp:Label></div>
            <div class="lvl-desc edit-block mt50 wbg">
                    <asp:Label ID="lblKPIMeasure" runat="server" class="edit-name fl" Text="<%$ Resources:TestSiteResources, KPIMeasure %>"></asp:Label>
                    <asp:TextBox ID="txtKPIMeasure" class="edit-desc fl" runat="server" MaxLength="100" onkeypress="return AllowOnlyAlphabets(event);"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvKPIMeasure" runat="server" ErrorMessage="Provide KPI Measure"
                        ControlToValidate="txtKPIMeasure" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="revKPIMeasure" runat="server" 
                        ControlToValidate="txtKPIMeasure" Display="Dynamic" 
                        ErrorMessage="Enter only Alphabets" SetFocusOnError="True" 
                        ValidationExpression="^[a-zA-Z  ]+$" ValidationGroup="Insertion">Enter only Alphabets</asp:RegularExpressionValidator>--%>
              <div class="clear"></div>
              </div>

               <div class="lvl-desc edit-block mt50 wbg">
                    <asp:Label ID="lblKPIDesc" runat="server" class="edit-name fl" Text="<%$ Resources:TestSiteResources, Description %>"></asp:Label>
                    <asp:TextBox ID="txtDescp" class="edit-desc fl" runat="server" MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                    <asp:Button ID="btnHyperLink" CssClass="green-btn fr" Text="Tips & Tricks" 
                        runat="server" onclick="btnHyperLink_Click"/>
                    <asp:RequiredFieldValidator ID="rfvDescp" runat="server" ErrorMessage="Provide KPI Description"
                        ControlToValidate="txtDescp" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="revKPIMeasure" runat="server" 
                        ControlToValidate="txtKPIMeasure" Display="Dynamic" 
                        ErrorMessage="Enter only Alphabets" SetFocusOnError="True" 
                        ValidationExpression="^[a-zA-Z  ]+$" ValidationGroup="Insertion">Enter only Alphabets</asp:RegularExpressionValidator>--%>
              <div class="clear"></div>
              </div>

           <div class="lvl-desc edit-block mt50 wbg">
                    <asp:Label ID="lblKPIType" runat="server" class="edit-name fl"  Text="<%$ Resources:TestSiteResources, KPIType %>"></asp:Label>
                
                    <%--<asp:TextBox ID="txtKPIType" runat="server" MaxLength="100"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlKPIType" class="edit-combo fr" runat="server" ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvKPIType" runat="server" ErrorMessage="Select KPI Name" InitialValue="0"
                        ControlToValidate="ddlKPIType" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="revKPIType" runat="server" 
                        ControlToValidate="txtKPIType" Display="Dynamic" 
                        ErrorMessage="Enter only Alphabets" SetFocusOnError="True" 
                        ValidationExpression="^[a-zA-Z  ]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>--%>
               <div class="clear"></div>
              </div>
              	<div class="lvl-desc edit-block wbg">
					<h1 class="edit-name fl"><asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, CategoryH %>"></asp:Label></h1>
                    <asp:DropDownList ID="ddlCategory" class="edit-combo fr" runat="server" ></asp:DropDownList>
					<%--<select class="edit-combo fr">
						<option>Training</option>
					</select>--%>
					<div class="clear"></div>
		</div>
            <div class="lvl-desc edit-block mt50 wbg">
          
                    <asp:Label ID="lblActive" runat="server"  class="edit-name fl"  Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
               
                    <asp:CheckBox ID="cbActive" class="edit-desc fl" runat="server" />
             <div class="clear"></div>
              </div>
              <div class="edit-block">
              <asp:Button ID="btnAddKPI" runat="server" class="edit-left" CssClass="green-btn admin-edit fr" Text="<%$ Resources:TestSiteResources, Add %>" ValidationGroup="Insertion"
                        OnClick="btnAddKPI_Click"  />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10" Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
          
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="Insertion" />
                        <div class="clear"></div>
                        </div>
               </div>
               
                    
     
    </div>

                <asp:Button ID="_editPopupButton" runat="server" Text="Edit Contact" Style="display: none" />
                <asp:ModalPopupExtender ID="mpeTipsTricks" runat="server" BackgroundCssClass="modalBackground"
                    RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
                    PopupControlID="_CongratsMessageDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
                    BehaviorID="EditModalPopupMessage">
                </asp:ModalPopupExtender>
                <div class="_popupButtons" style="display: none">
                    <input id="_okPopupButton" value="OK" type="button" />
                    <input id="_cancelPopupButton" value="Cancel" type="button" />
                </div>
                <div id="_CongratsMessageDiv" class="congrats-cont" style="display: none;">
                    <uc:Tips ID="ucCongratsMessage" runat="server" />
                </div>
</asp:Content>
