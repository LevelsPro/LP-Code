<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_CreatePost.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_CreatePost" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="in-cont p-cont">
    Create Post
    <br />
    <br />
    <label id="lblMessageStatus" class="fr"> 0/200 </label>
    <div class="clear">
    </div>
    <asp:TextBox ID="txtTitle" runat="server" MaxLength="200" class="input-style post-area"
        TextMode="MultiLine" onKeyUp="count(this);" ></asp:TextBox>
        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" Enabled="True"
                TargetControlID="txtTitle" WatermarkText="Post Title"/>
    <asp:Label runat="server" Text="Type:" class="tr-in fl"></asp:Label>
    <asp:Label runat="server" class="tr-in fl">
        <asp:DropDownList ID="ddlType" runat="Server" class="opt">
            <asp:ListItem Text="Select something" Value="-1" />
        </asp:DropDownList>
    </asp:Label>
    <asp:Label ID="lblrole" Text="Role" runat="server" class="tr-in fl"></asp:Label>
    <asp:Label ID="Label1" runat="server" class="tr-in fl">
        <asp:DropDownList ID="ddlrole" runat="Server" class="opt">
            <asp:ListItem Text="Select something" Value="-1" />
        </asp:DropDownList>
    </asp:Label>
    <div class="clear">
    </div>
    <asp:TextBox ID="txtPostArea" runat="server" class="input-style post-area pm" TextMode="MultiLine"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                TargetControlID="txtPostArea" WatermarkText="Post Message"/>
</div>
<asp:Button ID="Button1" runat="server" Text="Cancel" class="green-btn btn fl ps"
    OnClick="Button1_Click"></asp:Button>
<asp:Button ID="btnPost" runat="server" Text="Post" class="green-btn btn fl ps" 
    OnClick="btnPost_Click">
</asp:Button>


<script type="text/javascript">
function count(field) {
    document.getElementById('lblMessageStatus').value = field.value.length + '/200';
//    alert(document.getElementById('lblMessageStatus').value);
}
</script>
