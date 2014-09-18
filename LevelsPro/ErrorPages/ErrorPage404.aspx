<%@ Page Title="" Language="C#" MasterPageFile="~/ErrorPages/Error.Master" AutoEventWireup="true" CodeBehind="ErrorPage404.aspx.cs" Inherits="LevelsPro.ErrorPages.ErrorPage404" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" media="all" href="../Styles/Error-404-Style.css" />
    <div id="pagewrap">
        <div class="inner-wrapper">
            <div class="container">
            <br />
               <h2>
                    You’ve gone in the <br />
                    wrong direction
                </h2>
                <br />
                <a href="../Login.aspx"><img src="../Images/Errors/404Image.png"   /></a>

            </div><!-- / container -->
            
        </div><!-- / inner-wrapper -->
    </div><!-- / pagewrap -->
</asp:Content>
