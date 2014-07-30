<%@ Page Language="C#" MasterPageFile="~/PlayerPanel/Player.master"  Title="Welcome Page" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="LevelsPro.Player.Welcome" %>


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
                    You are signed in as Player rights.
                    This page shows the player his or her status at a glance.Additionally, it allows the player
                    to drill into their performance status in more details.It also acts as a command center from 
                    where a player can navigate to other areas of the application.
                    Through this functionality, players can view their progress, get tips and tricks to improve 
                    their performance, view awards, redeem their points for rewards of value to them, update their
                    profile, view and send messages, and add tips,questions, and replies to the discussion forums.
                    In addition, players can select to play a game.<br /><br />
                    
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