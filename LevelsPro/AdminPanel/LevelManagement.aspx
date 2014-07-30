<%@ Page Title="Level Management" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="LevelManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.LevelManagement" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%;">
        <asp:UpdatePanel ID="upLevel" runat="server">
            <ContentTemplate>
                <h3>
                    <asp:Label ID="lblLevelManagement" runat="server" Text="<%$ Resources:TestSiteResources, LevelManagement %>"></asp:Label></h3>
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
                            <asp:Label ID="lblRoleName" runat="server" Text="<%$ Resources:TestSiteResources, Role %>"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRole" runat="server" Width="142px" AutoPostBack="True" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ErrorMessage="Provide Role Name"
                                ControlToValidate="ddlRole" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"
                                InitialValue="0"> * </asp:RequiredFieldValidator>
                            <asp:Button ID="btnSort" runat="server" Text="<%$ Resources:TestSiteResources, SortTasks %>" OnClick="btnSort_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td width="25%">
                            <asp:Label ID="lblLevelName" runat="server" Text="<%$ Resources:TestSiteResources, NameL %>" Width="131px"></asp:Label>
                        </td>
                        <td width="75%">
                            <asp:TextBox ID="txtLevelName" runat="server" MaxLength="100" ValidationGroup="Insertion"
                                Width="136px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLevelName" runat="server" ErrorMessage="Provide Level Name"
                                ControlToValidate="txtLevelName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="25%">
                            <asp:Label ID="lblPosition" runat="server" Text="<%$ Resources:TestSiteResources, Position %>"></asp:Label>
                        </td>
                        <td width="75%">
                            <asp:TextBox ID="txtPosition" runat="server" MaxLength="10" ValidationGroup="Insertion"
                                Width="80px" Enabled="False"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="revPosition" runat="server" ControlToValidate="txtPosition"
                                Display="Dynamic" ErrorMessage="Enter only Numeric value for Measure" SetFocusOnError="True"
                                ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    
                    <tr>
                        <td width="25%">
                            <asp:Label ID="lblBaseHours" runat="server" Text="<%$ Resources:TestSiteResources, BaseHours %>"></asp:Label>
                        </td>
                        <td width="75%">
                            <asp:TextBox ID="txtBaseHours" runat="server" MaxLength="10" ValidationGroup="Insertion"
                                Width="80px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtBaseHours"
                                Display="Dynamic" ErrorMessage="Enter only Numeric value for Measure" SetFocusOnError="True"
                                ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvBaseHour" runat="server" 
                                ControlToValidate="txtBaseHours" Display="Dynamic" 
                                ErrorMessage="Provide Level Base Hours" SetFocusOnError="True" 
                                ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr id="trActive" runat="server" visible="false">
                        <td>
                            <asp:Label ID="lblActive" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbActive" runat="server" />
                            <asp:HiddenField ID="hdnCheckStatus" runat="server" Visible="false" />
                        </td>
                    </tr>
                    <%--<tr style="visibility:hidden">
                        <td width="25%">
                            <asp:Label ID="lblDimension_top" runat="server" Text="<%$ Resources:TestSiteResources, DimensionTop %>"></asp:Label>
                        </td>
                        <td width="75%">
                            <asp:TextBox ID="txtDimension_top" runat="server" MaxLength="3" ValidationGroup="Insertion"
                                Width="80px"></asp:TextBox>&nbsp;<span style="font-size: x-small">(%)</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtDimension_top"
                                Display="Dynamic" ErrorMessage="Enter only Numeric value for Measure" SetFocusOnError="True"
                                ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="visibility:hidden">
                        <td width="25%">
                            <asp:Label ID="lblDimension_Left" runat="server" Text="<%$ Resources:TestSiteResources, DimensionLeft %>"></asp:Label>
                        </td>
                        <td width="75%">
                            <asp:TextBox ID="txtDimension_left" runat="server" MaxLength="3" ValidationGroup="Insertion"
                                Width="80px"></asp:TextBox>&nbsp;<span style="font-size: x-small">(%)</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDimension_left"
                                Display="Dynamic" ErrorMessage="Enter only Numeric value for Measure" SetFocusOnError="True"
                                ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnAddLevel" runat="server" Text="<%$ Resources:TestSiteResources, Add %>" ValidationGroup="Insertion"
                                OnClick="btnAddLevels_Click" />
                            &nbsp;
                            <asp:Button ID="btnCancelLevel" runat="server" Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
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
                            <asp:Panel ID="pnlPlayergrid" runat="server">
                                <asp:GridView ID="gvLevel" runat="server" ForeColor="#333333" Width="70%" CaptionAlign="Top"
                                    CellPadding="4" EmptyDataText="No Records Found" DataKeyNames="Level_ID" AutoGenerateColumns="False"
                                    OnSelectedIndexChanged="gvLevel_SelectedIndexChanged" OnRowDataBound="gvLevel_RowDataBound">
                                    <FooterStyle BackColor="#348ec2" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <EditRowStyle BackColor="#999999" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#348EC2" ForeColor="White" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#348ec2" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoleID" runat="server" Text='<%# Eval("Role_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActive" runat="server" Text='<%# Eval("Active") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="8%">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgEdit" runat="server" AlternateText="<%$ Resources:TestSiteResources, Edit %>" Height="17px" ImageUrl="images/btn_edit.gif"
                                                    Width="15px" CommandName="Select" ToolTip="Click to edit the record" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Level_Position" HeaderText="<%$ Resources:TestSiteResources, PositionH %>" ItemStyle-Width="22%"
                                            ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Level_Name" HeaderText="<%$ Resources:TestSiteResources, Name %>" ItemStyle-Width="50%" />
                                        <asp:BoundField DataField="BaseHours" HeaderText="<%$ Resources:TestSiteResources, BaseHoursH %>" ItemStyle-Width="22%"
                                            ItemStyle-HorizontalAlign="Center" />
                                       <%-- <asp:BoundField DataField="Dimension_top" HeaderText="<%$ Resources:TestSiteResources, Top %>" ItemStyle-Width="435px"
                                            ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Dimension_left" HeaderText="<%$ Resources:TestSiteResources, Left %>" ItemStyle-Width="435px"
                                            ItemStyle-HorizontalAlign="Center" />--%>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pnlSort" runat="server" Width="100%">
                    <table width="49%">
                        <caption>
                            <h1>
                            <asp:Label ID="lblLevelPosition" runat="server" Text="<%$ Resources:TestSiteResources, LevelPosition %>"></asp:Label></h1>
                            <asp:Label ID="lblInfo" runat="server" Font-Bold="true" Text="<%$ Resources:TestSiteResources, LevelUPDown %>"></asp:Label>
                            <br />
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td align="center">
                                    <asp:ListBox ID="lstSelectedSections" runat="server" AutoPostBack="True" Rows="10"
                                        SelectionMode="Multiple" Width="200px" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnUp" runat="server" ImageUrl="~/AdminPanel/Images/top.jpg"
                                        OnClick="btnUp_Click" Width="40px" />
                                    <br />
                                    <br />                                    
                                    <asp:ImageButton ID="btnDown" runat="server" ImageUrl="~/AdminPanel/Images/bottom.jpg"
                                        OnClick="btnDown_Click" Width="40px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width:150px">
                                </td>
                                <td>
                                </td>
                                <td align="center">
                                    <asp:Button ID="btnSet" runat="server" OnClick="btnSet_Click" Text="<%$ Resources:TestSiteResources, SetPosition %>" />
                                    <asp:Button ID="btnCancelPriority" runat="server" OnClick="btnCancelPriority_Click"
                                        Text="<%$ Resources:TestSiteResources, Cancel %>" />
                                    <%--OnClick="btnCancelPriority_Click"--%>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </caption>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
