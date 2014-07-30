<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_SetNewPassword.ascx.cs" Inherits="LevelsPro.UserControls.uc_SetNewPassword" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


        <div class="popup-cyan">
		
		<div class="cyan-head">
         <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, SetPassword %>"></asp:Label>
		</div>
		<form class="styleThese">
		
        <div class="answer-title">
        <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, Younew %>"></asp:Label>
		</div>
		
		
		<div class="left-label fl">
         <asp:Label ID="Label3" runat="server" Text="<%$ Resources:TestSiteResources, EnterPassword %>"></asp:Label>
		</div>
		
		<div class="right-label fl">
            <asp:TextBox ID="txtPassword" runat="server" CssClass ="input-pop"></asp:TextBox>
		</div>
		
		
		<div class="left-label fl">
         <asp:Label ID="Label4" runat="server" Text="<%$ Resources:TestSiteResources, ConfirmPasswordH %>"></asp:Label>
		</div>
		
		<div class="right-label fl">
			<asp:TextBox ID="txtConfrmPassword" runat="server" CssClass ="input-pop"></asp:TextBox>
		</div>
		
        <div class="right-label fl" id="divError" runat="server" visible="false">
        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:TestSiteResources, Passwordmatch %>"></asp:Label>
        </div>

        <div class="clear"></div>

		<div class="btn-pop pt47">
			<div class="green-wrapper pop-btn">
                <asp:Button ID="btnSubmit" runat="server" CssClass="green" text="<%$ Resources:TestSiteResources, Submit %>" OnClick="btnSubmit_Click" 
                    />
			</div>	
		</div>
         <asp:Button ID="btnTest" runat="server" text="Test" onclick="btnTest_Click" />
		</form>
		
	    </div>
