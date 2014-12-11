<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="ViewContests.aspx.cs" Inherits="LevelsPro.PlayerPanel.ViewContests" %>

<%@ Register TagPrefix="uc" TagName="ucContestDetails" Src="~/PlayerPanel/UserControls/uc_ContestDetails.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-57350527-1', 'auto');
    ga('send', 'pageview');

    </script>
    <script type="text/javascript">
        function hideModalPopupViaClient(e) {
            if (document.getElementById('_DetailsDiv').style.display != 'none') {
                var modalPopupBehavior = $find('EditModalPopupContests');
                modalPopupBehavior.hide();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 40%;" align="center">
        <div>
            <h4>
               <asp:Label ID="lblcontests"  runat="server" Text="<%$ Resources:TestSiteResources, ContestLabel %>"></asp:Label>&nbsp;<label id="lblContestCount" runat="server"></label>&nbsp;&nbsp;
               <asp:Label ID="lblContest"  runat="server" Text="<%$ Resources:TestSiteResources, contestsL %>"></asp:Label></h4>
        </div>
        <br />
        <div style="width: 85%;">
            <asp:DataList ID="dlViewContests" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                RepeatLayout="Table">
                <ItemTemplate>
                    <table width="300px">
                        <tr>
                            <td style="width: 30%">
                                &nbsp;<asp:ImageButton ID="ibtnContest" runat="server" ImageUrl='<%# "~/view-file.aspx?contestid=" + Eval("Contest_ID") %>'
                                    Width="100px" Height="90px" CommandArgument='<%# Eval("Contest_ID") %>' CommandName="ViewContests" />
                            </td>
                            <td align="left" style="width: 70%;">
                              <h4>
                                    <%# Eval("Contest_Name") %></h4>
                                Your rank :13
                                <br /><br />
                            </td>
                        </tr>
                       
                    </table>
                     <hr />
                </ItemTemplate>
            </asp:DataList>
            <br />
        </div>
    </div>
    <asp:Button ID="_editPopupButton" runat="server" Text="Edit Contact" Style="display: none" />
    <asp:ModalPopupExtender ID="mpeContestDetails" runat="server" BackgroundCssClass="modalBackground"
        RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
        PopupControlID="_DetailsDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
        BehaviorID="EditModalPopupContests">
    </asp:ModalPopupExtender>
    <div class="_popupButtons" style="display: none">
        <input id="_okPopupButton" value="OK" type="button" />
        <input id="_cancelPopupButton" value="Cancel" type="button" />
    </div>
    <asp:UpdatePanel ID="upContestDetails" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="dg-tbl" style="border-width: 0px;">
                <tr>
                    <td>
                        <div id="_DetailsDiv" style="width: 300px; position: fixed; background-color: White;
                            z-index: 100001; left: 239.5px; display: none; top: -102px; height: 300px;" class="popup">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="dg-tbl" style="border-width: 0px;
                                padding: 0;">
                                <tr>
                                    <th align="left">
                                        <div style="text-align: right; float: right; height: 15px;">
                                            <img src="Images/close.png" height="25px" width="25px" style="cursor: pointer;" alt="Close"
                                                id="img1" onclick="hideModalPopupViaClient(event);" />
                                        </div>
                                    </th>
                                </tr>
                            </table>
                            <div style="overflow-y: auto; height: 800px; width: 500px;">
                                <div id="tblMainA">
                                    <uc:ucContestDetails ID="ucContestDetails" runat="server" />
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
