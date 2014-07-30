<%@ Page Title="" Language="C#" MasterPageFile="~/ManagerPanel/Manager.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ManagerHome.aspx.cs" Inherits="LevelsPro.ManagerPanel.ManagerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><asp:Label ID="lblWelcomeHome" runat="server" Text="<%$ Resources:TestSiteResources, WelcomeHomeManager %>"></asp:Label></h2>
</asp:Content>
