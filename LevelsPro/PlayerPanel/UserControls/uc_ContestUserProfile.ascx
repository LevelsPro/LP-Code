<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ContestUserProfile.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_ContestUserProfile" %>
<div class="header-container">
    <div class="sec-left">
        <div class="strip">
            <div class="msg-r">
                <span class="st <%= cssClass %>">
                    <asp:Label ID="lblRank1" runat="server"></asp:Label>
                </span>
            </div>
        </div>
    </div>
    <div class="sec-right">
        <div class="profile-bcont">
            <div class="usern">
                <asp:Label ID="lblNameContest" runat="server"></asp:Label><br />
                <asp:Label ID="lblRoleName" runat="server"></asp:Label><br />
                <asp:Label ID="lblStore" runat="server"></asp:Label>
            </div>
            <div class="rankings">
                <asp:Label ID="lblStoreRanking" runat="server" Text="<%$ Resources:TestSiteResources, StoreRanking %>"></asp:Label>&nbsp;<asp:Label ID="lblStorePlace" runat="server" CssClass="store-place"></asp:Label><br />
                <asp:Label ID="lblCompanyRank" runat="server" Text="<%$ Resources:TestSiteResources, CompanyRanking %>"></asp:Label>&nbsp;<asp:Label ID="lblCompanyPlace" runat="server" CssClass="company-place"></asp:Label>
            </div>
            <div class="scores sposition">
                <span class="wc">
                    <asp:Label ID="lblContest" runat="server" Text="<%$ Resources:TestSiteResources, AwardsB %>"></asp:Label>
                </span>
                <asp:ListView ID="lvAwards" runat="server" OnItemDataBound="lvAwards_ItemDataBound">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />  
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li>
                            <div class="lPosition fr">
                                <strong>
                                    <asp:Literal ID="ltNumber" runat="server" Text='<%#Eval("Position")%>'></asp:Literal>&nbsp;<asp:Literal ID="Literal1" runat="server" Text='<%$ Resources:TestSiteResources, Place %>'></asp:Literal>
                                </strong>
                            </div>
                            <div class="lPoints fr">
                                <asp:Literal ID="ltPoints" runat="server" Text='<%#Eval("Points")%>'></asp:Literal>
                            </div>
                        </li>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <p>Nothing here.</p>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</div>