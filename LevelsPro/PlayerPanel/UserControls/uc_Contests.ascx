<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Contests.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_Contests" %>
<div class="sm-h">
    <asp:Label ID="lblContests" runat="server" Text="<%$ Resources:TestSiteResources, ContestLabel %>"></asp:Label>&nbsp;<label
        id="lblContestCount" runat="server"></label>&nbsp;<asp:Label ID="lblContest" runat="server"
            Text="<%$ Resources:TestSiteResources, contestsL %>"></asp:Label>
</div>
<div class="fl-wrapper flw-left">
    <asp:DataList ID="dlViewContests" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
        OnItemCommand="dlViewContests_ItemCommand" OnItemDataBound="dlViewContests_ItemDataBound"
        Width="100%">
        <ItemTemplate>
            <asp:LinkButton ID="lnkbtnContestDetail" runat="server" CommandArgument='<%# Eval("Contest_ID") %>'
                CommandName="ViewContests">
                <div class="strip">
                    <%--<span class="lt">--%>
                    <asp:Image ID="ibtnContest" runat="server" ImageUrl='<%# "~/view-file.aspx?contestid=" + Eval("Contest_ID") %>'
                        CssClass="msg-l" /><%--</span>--%>
                    <div class="msg-r">
                        <span class="lt">
                            <%# Eval("Contest_Name") %>
                        </span>
                        <br />
                        <span class="st">
                            <asp:Label ID="lblRank1" runat="server" Text="<%$ Resources:TestSiteResources, YourRank %>"> &nbsp;</asp:Label><asp:Label
                                ID="lblRank" runat="server"></asp:Label>
                            <asp:Label ID="lblcontestid" runat="server" Visible="false" Text='<%# Eval("Contest_ID") %>'></asp:Label>
                        </span>
                    </div>
            </asp:LinkButton>
            <div class="clear">
            </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>
