<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="AssignAwards.aspx.cs" Inherits="LevelsPro.AdminPanel.AssignAwards" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%;">
        <asp:UpdatePanel ID="upLevel" runat="server">
            <ContentTemplate>
                <h3>
                    <asp:Label ID="lblManualAward" runat="server" Text="<%$ Resources:TestSiteResources, ManualAwardAssignment %>"></asp:Label></h3>
                <br />
                <br />
                <table cellpadding="3" cellspacing="0" width="100%">
                    <tr>
                        <td>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPlayer" runat="server" Text="<%$ Resources:TestSiteResources, Player %>"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPalyer" runat="server" Width="142px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ErrorMessage="Provide Player Name"
                                ControlToValidate="ddlPalyer" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"
                                InitialValue="0"> * </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%">
                            <asp:Label ID="lblAward" runat="server" Text="<%$ Resources:TestSiteResources, Award %>"
                                Width="131px"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAward" runat="server" Width="142px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvAward" runat="server" ErrorMessage="Provide Award"
                                ControlToValidate="ddlAward" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"
                                InitialValue="0"> * </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnAssignAward" runat="server" Text="<%$ Resources:TestSiteResources, AssignAwardB %>"
                                ValidationGroup="Insertion" OnClick="btnAssignAward_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="Insertion" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvAwards" runat="server" ForeColor="#333333" Width="70%" CaptionAlign="Top"
                                CellPadding="4" EmptyDataText="No Records Found" AutoGenerateColumns="False"                                
                                OnPageIndexChanging="gvAwards_PageIndexChanging">
                                <FooterStyle BackColor="#348ec2" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <EditRowStyle BackColor="#999999" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#348EC2" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#348ec2" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>                                    
                                    <asp:TemplateField HeaderText="S.No." ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FullName" HeaderText="<%$ Resources:TestSiteResources, PlayerNameAssign %>"
                                        ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Award_Name" HeaderText="<%$ Resources:TestSiteResources, AwardName %>"
                                        ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="awarded_date" HeaderText="<%$ Resources:TestSiteResources, AwardedDate %>"
                                        ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:yyyy/MM/dd}" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
