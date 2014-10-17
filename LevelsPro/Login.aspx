<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LevelsPro.Login" %>

<%--popup for security questions--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="SetNewPassword" Src="~/UserControls/uc_SetPassword.ascx" %>
<%@ Register TagPrefix="uc" TagName="SecurityQuestions" Src="~/UserControls/uc_SecurityQuestions.ascx" %>
<%@ Register TagPrefix="uc" TagName="ForgotPassword" Src="~/UserControls/uc_ForgotPassword.ascx" %>
<%--<%@ Register TagPrefix="uc" TagName="CheckAnswers" Src="~/UserControls/uc_CheckAnswers.ascx" %>--%>
<%--end popup for security questions--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>::Login Page::</title>  
    <script src="PlayerPanel/Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="PlayerPanel/Scripts/jquery-latest.js" type="text/javascript"></script>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Styles/uniform.default.css" type="text/css" />

    <script type="text/javascript">

        $(document).ready(function () {
            $(window).resize(function () {
                var winHeight = $(window).height();

                if (winHeight < 585) {

                    $('.login-cont').css({ top: '135px', margin: '0px 0 0 -244px' });
                }
                else {
                    $('.login-cont').css({ top: '50%', margin: '-155px 0 0 -244px' });
                }
            });

            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);
        });

        var dh = $(document).height();
       $('.opac-wrap').height(dh);



      
   



    </script>



    <script src="Scripts/canvas-draw.js" type="text/javascript"></script>
        
    <style type="text/css">
        .tbl-processing
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.50;
        }
        
        
        .watermarkcss
        {
            color: Gray;
            border: 0 none;
            box-shadow: 0 1px 1px 1px #000000 inset;
            font-size: 24px;
            margin-top: 10px;
            outline: medium none;
            padding: 12px 15px;
            width: 418px;
        }
        
        .updateProgress
        {
            color: #FFFFFF;
            
            font-size: small;
            margin: auto;
            opacity: 1;
            position: fixed;
            left: 50%;
            top: 50%;
            vertical-align: middle;
            margin-left: -150px;
            margin-top: -100px;
        }
        
        
    </style>
</head>

<body >
    <form id="form1" runat="server" class="styleThese" >
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
    <div class="container">
       <div class="top-banner">
			<div class="logo">
				<img src="AdminPanel/Images/logo.png">
			</div>
			<div class="banner">
				<!--<div class="acme-inc"></div>-->
			</div>
			<div class="clear"></div>
		</div>
        <div class="body-cont flog">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="upLogin" runat="server">
                <ContentTemplate>
                    <div class="login-cont">
                        Log In<br />
                        <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="True" CssClass="up-login"
                            Width="448px">
                            <asp:ListItem Selected="True" Value="0">US English</asp:ListItem>
                            <asp:ListItem Value="1">French</asp:ListItem>
                            <asp:ListItem Value="2">Spanish</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtUser" runat="server" MaxLength="32" CssClass="up-login" ToolTip="Username" ></asp:TextBox>
                   <asp:TextBoxWatermarkExtender ID="weUserID" runat="server" TargetControlID="txtUser"
                            WatermarkText="Username" WatermarkCssClass="watermarkcss">
                        </asp:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ControlToValidate="txtUser"
                            SetFocusOnError="true" ValidationGroup="login" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" ToolTip="Password is case sensitive."
                            MaxLength="25" CssClass="watermarkcss" TextMode="Password" placeholder="Password" ></asp:TextBox>
                      <%--  <asp:TextBoxWatermarkExtender ID="wePassword" runat="server" TargetControlID="txtPassword"
                            WatermarkText="Password" WatermarkCssClass="watermarkcss">  onfocus="DoFocus(this)"
                        </asp:TextBoxWatermarkExtender>--%>
                        <asp:RequiredFieldValidator ID="RfvPassword" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"
                            SetFocusOnError="true" ValidationGroup="login" Display="Dynamic"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Button ID="btnSignin" runat="server" OnClick="btnSignin_Click" Text="<%$ Resources:TestSiteResources, Login %>"
                            ValidationGroup="login" CssClass="lgn-btn" />
                        <asp:Button ID="btnForgetPass" runat="server" OnClick="btnForgetPass_Click" CssClass="forgot-pw"
                            Text="<%$ Resources:TestSiteResources, ForgotPassword %>" />
                        <br />
                        <asp:Label ID="lblError" runat="server" Visible="False" ForeColor="#FF3300"></asp:Label>
                         

                    </div>
                    <asp:UpdateProgress ID="uprogressLogin" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="upLogin">
                        <ProgressTemplate>
                            <div style="background-color: Teal; filter: alpha(opacity=80); opacity: 0.80; width: 100%;
                                top: 0px; left: 0px; position: fixed; height: 100%;">
                            </div>
                            <div class="updateProgress">
                                <table width="100%">
                                    <tr>
                                        <td style="width: 30%">
                                            <img src="Images/loading-small.gif" alt="wait" />
                                        </td>
                                        <td style="width: 70%" align="left">
                                            <span style="font-size: medium; font-weight: bold; color: #FFFFFF">
                                                <asp:Literal ID="ltProcessing" runat="server" Text="<%$ Resources:TestSiteResources, Processing %>"></asp:Literal>
                                            </span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="_editSetNewPopupButton2" runat="server" Text="Set New Password" Style="display: none" />
            <asp:ModalPopupExtender ID="mpeForgot" runat="server" BackgroundCssClass="modalBackground"
                RepositionMode="None" TargetControlID="_editSetNewPopupButton2" ClientIDMode="AutoID"
                PopupControlID="_ForgotDiv" OkControlID="btnOK1" CancelControlID="btnCancel1"
                BehaviorID="ForgotBehaviourID">
            </asp:ModalPopupExtender>
            <div class="_popupButtons" style="display: none">
                <input id="btnOK1" value="OK" type="button" />
                <input id="btnCancel1" value="Cancel" type="button" />
            </div>
            <%--<asp:UpdatePanel ID="upSetNewPassword" runat="server" UpdateMode="Conditional">
                <ContentTemplate>--%>
            <div id="_ForgotDiv" class="box pd-popup" style="display: none;">
                <uc:ForgotPassword ID="ForgotPassword1" runat="server" />
            </div>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
            <!----------------------------------------------------------------------------------------------------->
           <%-- <asp:Button ID="_editPopupButtonAnswer" runat="server" Text="Edit Contact" Style="display: none" />
            <asp:ModalPopupExtender ID="mpeAnswers" runat="server" BackgroundCssClass="modalBackground"
                RepositionMode="None" TargetControlID="_editPopupButtonAnswer" ClientIDMode="AutoID"
                PopupControlID="AnswerDiv" OkControlID="_okPopupButtonA" CancelControlID="_cancelPopupButtonA"
                BehaviorID="EditModalPopupAnswer">
            </asp:ModalPopupExtender>
            <div class="_popupButtons" style="display: none">
                <input id="_okPopupButtonA" value="OK" type="button" />
                <input id="_cancelPopupButtonA" value="Cancel" type="button" />
            </div>
            <div id="AnswerDiv" class="box pd-popup" style="display: none;">
                <uc:CheckAnswers ID="ucCheckAnswers" runat="server" />
            </div>--%>
            <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
            <!------------------------------------- Model Popup for SetNewPassword -------------------------------->
            <asp:Button ID="_editSetNewPopupButton" runat="server" Style="display: none" />
            <%--<asp:ModalPopupExtender ID="mpeSetNewPassword" runat="server" BackgroundCssClass="modalBackground"
                RepositionMode="None" TargetControlID="_editSetNewPopupButton" ClientIDMode="AutoID"
                PopupControlID="_SetNewPasswordDiv" OkControlID="btnOK" CancelControlID="btnCancel"
                BehaviorID="SetupNewPassword_ModalPopup">
            </asp:ModalPopupExtender>--%>

            <asp:ModalPopupExtender ID="mpeSetNewPassword" runat="server" BackgroundCssClass="modalBackground"
                RepositionMode="RepositionOnWindowResizeAndScroll" TargetControlID="_editSetNewPopupButton" 
                PopupControlID="_SetNewPasswordDiv">
            </asp:ModalPopupExtender>

           <%-- <div class="_popupButtons" style="display: none">
                <input id="btnOK" value="OK" type="button" />
                <input id="btnCancel" value="Cancel" type="button" />
            </div>--%>

                 <div id="_SetNewPasswordDiv" class="box pd-popup" style="display: none;">
                            <uc:SetNewPassword ID="ucSetNewPassword" runat="server" />
                        </div>
           
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
            <!----------------------------------------------------------------------------------------------------->
            <%--popup for security questions--%>
            <asp:Button ID="_editPopupButton1" runat="server"  Style="display: none" />
            <%--<asp:ModalPopupExtender ID="mpeSecurityQuestionsDiv" runat="server" BackgroundCssClass="modalBackground"
                RepositionMode="None" TargetControlID="_editPopupButton1" ClientIDMode="AutoID"
                PopupControlID="_SecurityQuestionsDiv" OkControlID="_okPopupButton1" CancelControlID="_cancelPopupButton1"
                BehaviorID="EditModalPopupSecurityQuestions">
            </asp:ModalPopupExtender>--%>

            <asp:ModalPopupExtender ID="mpeSecurityQuestionsDiv" runat="server" BackgroundCssClass="modalBackground"
                RepositionMode="RepositionOnWindowResizeAndScroll" TargetControlID="_editPopupButton1" 
                PopupControlID="_SecurityQuestionsDiv" 
                BehaviorID="EditModalPopupSecurityQuestions">
            </asp:ModalPopupExtender>

           <%-- <div class="_popupButtons" style="display: none">
                <input id="_okPopupButton1" value="OK" type="button" />
                <input id="_cancelPopupButton1" value="Cancel" type="button" />
            </div>--%>
            <div id="_SecurityQuestionsDiv" class="congrats-cont" style="display: none;">
                <uc:SecurityQuestions ID="ucSecurityQuestions" runat="server" />
            </div>
            <%--<asp:Button ID="btnshowpopup" runat="server" OnClick="btnshowpopup_Click" />--%>
            <%--end popup for security questions--%>
            <div>
            </div>
            <div>
            </div>
        </div>
    </div>
    
     </ContentTemplate>
                </asp:UpdatePanel>
                </form>
</body>
</html>
