<%@ Page Title="" Language="C#" MasterPageFile="~/ErrorPages/Error.Master" AutoEventWireup="true" CodeBehind="DefaultErrorPage.aspx.cs" Inherits="LevelsPro.ErrorPages.DefaultErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" media="all" href="../Styles/Def-Error-Style.css" />
<div class="background">
		<div class="wrapper">
			
			<div class="description">
				<h1>Oops!</h1>
				<h2>looks like something went completely wrong.</h2>
			</div>
			
			<img src="../Images/Errors/DefaultError.png" class="turtle" alt="" />
			<div class="shadow"></div>
			<img src="../Images/Errors/Default-PowerCon.png" class="wall-p-c" alt="" />
		
					
		</div>
	</div>
</asp:Content>
