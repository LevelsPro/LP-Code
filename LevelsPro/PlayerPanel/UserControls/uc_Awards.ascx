<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Awards.ascx.cs" Inherits="LevelsPro.PlayerPanel.UserControls.uc_Awards" %>
<asp:DataList ID="dlViewAwards" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" Width="100%">
    <ItemTemplate>
        <span>
            <asp:Image  ID="imgAwards" runat="server" ImageUrl='<%# Eval("Award_Image").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["AwardsPath"].ToString() + Eval("Award_Image") :"../" + "Images/placeholder.png" %>'
                 />
        </span>
    </ItemTemplate>
</asp:DataList>