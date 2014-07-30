<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_FourmSearch.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_FourmSearch" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<div class="in-cont p-cont">
    Keyword
    <br />
    <br />
    <asp:TextBox ID="txtKeyword" runat="server" class="input-style post-area" Height="20px"></asp:TextBox>
    <asp:TextBoxWatermarkExtender ID="weKeyword" runat="server" TargetControlID="txtKeyword" WatermarkText="Search"></asp:TextBoxWatermarkExtender>
    <asp:Label ID="Label1" runat="server" Text="Type:" class="tr-in fl"></asp:Label>
    <asp:Label ID="Label2" runat="server" class="tr-in fl">
        <asp:DropDownList ID="ddlType" runat="Server" class="opt">
            <asp:ListItem Text="Select" Value="-1" />
        </asp:DropDownList>
    </asp:Label>
    <asp:Label ID="lblrole" Text="Role" runat="server" class="tr-in fl"></asp:Label>
    <asp:Label ID="Label3" runat="server" class="tr-in fl">
        <asp:DropDownList ID="ddlRole" runat="Server" class="opt">
            <asp:ListItem Text="Select" Value="-1" />
        </asp:DropDownList>
    </asp:Label>
    <asp:Label ID="lblPlayer" Text="Player" runat="server" class="tr-in fl"></asp:Label>
    <asp:Label ID="Label5" runat="server" class="tr-in fl">
        <asp:DropDownList ID="ddlPlayer" runat="Server" class="opt">
            <asp:ListItem Text="Select" Value="-1" />
        </asp:DropDownList>
    </asp:Label>
    <asp:Label ID="lblDate" Text="Date" runat="server" class="tr-in fl"></asp:Label>
    <asp:Label ID="Label6" runat="server" class="tr-in fl">
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
        <asp:CalendarExtender ID="ceDate" runat="server" TargetControlID="txtDate"
            Format="yyyy/MM/dd" PopupPosition="BottomRight" FirstDayOfWeek="Monday">
        </asp:CalendarExtender>
    </asp:Label>          
    
    <div class="clear">
    </div>
</div>
<asp:Button ID="btnSearch" runat="server" Text="Search" 
        class="green-btn btn fl ps" onclick="btnSearch_Click">
    </asp:Button> &nbsp;
<asp:Button ID="btnClose" runat="server" Text="Close" class="green-btn btn fl ps">
</asp:Button>
