<%@ Page Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"  Title="Welcome Page" AutoEventWireup="true" CodeBehind="WelcomeAdmin.aspx.cs" Inherits="LevelsPro.AdminPanel.WelcomeAdmin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <p id="pagee" align="justify" class="boxe_textw">
                    Welcome
                    <asp:Label ID="lblUser" runat="server" Font-Bold="True"></asp:Label>!
                    
                    <br />
                    <br />
                    You are signed in as Administrator rights.Left menu displays frequently-used functions
                    for each module. For a complete list of functions, select a module from the Menu
                    Bar. Please note you may not have permissions to execute all functions. If you do
                    not have a required permission, execution of the selected function will be ignored
                    and a message will be displayed.<br /><br /><asp:Label ID="lbldays" runat="server" Font-Size="Large" Font-Bold="True" ForeColor="#ff0066"></asp:Label>
                    
                </p>
               
            </td>
        </tr>
    </table>
</asp:Content>



<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
--%>