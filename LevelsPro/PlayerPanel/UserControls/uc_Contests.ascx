<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Contests.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_Contests" %>
<div class="fl-wrapper contest-positions overview">
    <asp:ListView ID="lvViewContests" runat="server" 
        ItemPlaceholderID="itemImageContainer" 
        OnItemCommand="lvViewContests_ItemCommand" 
        onitemdatabound="lvViewContests_ItemDataBound">
        <LayoutTemplate>
            <ul class="position-list">
                <asp:PlaceHolder ID="itemImageContainer" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:LinkButton ID="lnkbtnContestDetail" runat="server" CommandArgument='<%# Eval("ContestID") %>'
                    CommandName="ViewContests" Enabled="false" >
                    <div class="strip">
                        <div class="msg-r">
                            <span class='st <%# Eval("cssClass") %>'>
                                <asp:Label ID="lblRank1" runat="server" Text='<%# Eval("Position") %>' />
                            </span>
                            <span class="lt">
                                <%# Eval("ContestName")%>
                            </span>
                        </div>
                    </div>
                </asp:LinkButton><asp:HiddenField ID="hfToDate" runat="server" Value='<%# Eval("ToDate") %>' />
                <div class="clear">
                </div>
            </li>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                No Images to Display </div></EmptyDataTemplate></asp:ListView></div>