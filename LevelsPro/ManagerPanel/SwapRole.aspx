<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerPanel/Manager.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="SwapRole.aspx.cs" Inherits="LevelsPro.ManagerPanel.SwapRole" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Button ID="btnSwapRole" runat="server" onclick="btnSwapRole_Click" 
        Text="<%$ Resources:TestSiteResources, SwapRole %>" />
    
</asp:Content>