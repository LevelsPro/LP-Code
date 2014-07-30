<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="ContestDetails.aspx.cs" Inherits="LevelsPro.PlayerPanel.ContestDetails" %>
    <%@ Register TagPrefix="uc" TagName="Profile" Src="~/PlayerPanel/UserControls/uc_Profile.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Contests</title>
    <script type="text/javascript" src="http://code.jquery.com/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/fontResizer.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);
            //	$('.filled-area').slideRight();
        });
    </script>
    <link href="Styles/theme-3.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b">
        <%--<div class="green-btn btn fl">--%>
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, HomeAdmin %>"
            PostBackUrl="~/PlayerPanel/PlayerHome.aspx" CssClass="green-btn btn fl"></asp:Button><%--</div>--%>
        <%--<div class="user-nt fl">--%>
        <asp:Label ID="lblName" runat="server" CssClass="user-nt fl"></asp:Label><%--</div>--%>
        <%--div class="green-btn btn fr">--%>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button><%--</div>--%>
        <div class="clear">
        </div>
    </div>
     <uc:Profile ID="ViewProfile" runat="server" />
    <div class="box brd mt10">
        <div class="cc-h">
           <asp:Label ID="lblContest" runat="server" Text="<%$ Resources:TestSiteResources, Contest %>"></asp:Label></div>
        <div class="in-cont">
            <asp:Image ID="imgContestImage" runat="server" Width="152" Height="96" class="fl" />
            <%-- <img src='<%# "~/view-file.aspx?contestid=" + Eval("Contest_ID") %>' width="152"
                height="96" class="fl" alt="" />--%>
            <h2 class="int-heading fl">
                <label id="lblContestName" runat="server">
                </label>
                <br />
                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, EndOn %>"></asp:Label>&nbsp;&nbsp;
                <label id="lblContestEndDate" runat="server">
                </label>
            </h2>
            
          
            <div class="clear">
            </div>
            <p class="expl">
                <asp:Literal ID="ltContestDescription" runat="server"></asp:Literal>
                <%--Are you the Acme Inc. trivia champion? You have until July 1st to play the special
                Acme quiz to find out. The highest scoring team member in the chain will win a great
                prize as well as being crowned our Trivia King. There are also prizes for second
                and third places. So go ahead and give it your best shot, and best of luck.--%></p>
            <asp:GridView ID="gvPointsTable" runat="server" EmptyDataText="No Record Found."
                AutoGenerateColumns="false" CssClass="grid" GridLines="None" Width="100%" OnRowDataBound="gvPointsTable_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="<%$ Resources:TestSiteResources, Rank %>" ItemStyle-Width="17%">
                        <ItemTemplate>
                            <asp:Image ID="imgbtnRank" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="4%">
                        <ItemTemplate>
                            <asp:Literal ID="ltsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Literal>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="<%$ Resources:TestSiteResources, Player %>" DataField="U_FullName" HeaderStyle-HorizontalAlign="Left"
                        ItemStyle-Width="52%" />
                    <asp:BoundField HeaderText="<%$ Resources:TestSiteResources, Score %>" DataField="Score" ItemStyle-HorizontalAlign="Center"
                        ItemStyle-Width="18%" />
                    <asp:TemplateField ItemStyle-Width="9%">
                        <ItemTemplate>
                            <asp:Literal ID="ltend" runat="server" Text=''></asp:Literal>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="even" />
                <AlternatingRowStyle CssClass="odd" />
            </asp:GridView>
            <%-- <table width="100%" border="0" cellspacing="0" cellpadding="0" class="grid">
                <tr>
                    <th width="17%">
                        Rank
                    </th>
                    <th width="4%">
                        &nbsp;
                    </th>
                    <th width="52%">
                        Player
                    </th>
                    <th width="18%">
                        Score
                    </th>
                    <th width="9%">
                        &nbsp;
                    </th>
                </tr>
                <tr class="odd">
                    <td align="center">
                        <img src="images/rank-1.png" width="34" height="26" />
                    </td>
                    <td>
                        1.
                    </td>
                    <td>
                        Jason P.
                    </td>
                    <td>
                        2,104
                    </td>
                    <td>
                        <img src="images/up-arrow.png" width="10" height="10" />
                        2
                    </td>
                </tr>
                <tr class="even">
                    <td align="center">
                        <img src="images/rank-2.png" width="27" height="20" />
                    </td>
                    <td>
                        2.
                    </td>
                    <td>
                        Jackie T.
                    </td>
                    <td>
                        1,990
                    </td>
                    <td>
                        <img src="images/down-arrow.png" width="10" height="10" />
                        1
                    </td>
                </tr>
                <tr class="odd">
                    <td align="center">
                        <img src="images/rank-3.png" width="21" height="16" />
                    </td>
                    <td>
                        3.
                    </td>
                    <td>
                        Sarah L.
                    </td>
                    <td>
                        1,800
                    </td>
                    <td>
                        <img src="images/down-arrow.png" width="10" height="10" />
                        1
                    </td>
                </tr>
                <tr align="center" class="even">
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        4.
                    </td>
                    <td align="left">
                        Paul P.
                    </td>
                    <td>
                        1,754
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr class="odd">
                    <td align="center">
                        &nbsp;
                    </td>
                    <td>
                        5.
                    </td>
                    <td>
                        Peggy S.
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        1,650
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="100%" height="42">
                        <img src="images/dots.png" width="4" height="24" />
                    </td>
                </tr>
                <tr class="odd">
                    <td align="center">
                        &nbsp;
                    </td>
                    <td>
                        9.
                    </td>
                    <td>
                        Jason P.
                    </td>
                    <td>
                        2,104
                    </td>
                    <td>
                        <img src="images/up-arrow.png" width="10" height="10" />
                        2
                    </td>
                </tr>
                <tr class="even">
                    <td align="center">
                        &nbsp;
                    </td>
                    <td>
                        10.
                    </td>
                    <td>
                        Jackie T.
                    </td>
                    <td>
                        1,990
                    </td>
                    <td>
                        <img src="images/down-arrow.png" width="10" height="10" />
                        1
                    </td>
                </tr>
                <tr class="odd">
                    <td align="center">
                        &nbsp;
                    </td>
                    <td>
                        11.
                    </td>
                    <td>
                        Sarah L.
                    </td>
                    <td>
                        1,800
                    </td>
                    <td>
                        <img src="images/down-arrow.png" width="10" height="10" />
                        1
                    </td>
                </tr>
                <tr align="center">
                    <td colspan="100%" height="42">
                        <img src="images/dots.png" width="4" height="24" />
                    </td>
                </tr>
            </table>--%>
        </div>
    </div>
</asp:Content>
