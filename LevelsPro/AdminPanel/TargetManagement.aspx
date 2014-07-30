<%@ Page Title="Target Management" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="TargetManagement.aspx.cs" Inherits="LevelsPro.AdminPanel.TargetManagement" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%;">
        <asp:UpdatePanel ID="upTarget" runat="server">
            <ContentTemplate>
                <h3>
                    <asp:Label ID="lblTargetManagement" runat="server" Text="<%$ Resources:TestSiteResources, TargetManagement %>"></asp:Label></h3>
                <br />
                <br />
                <table cellpadding="3" cellspacing="0" width="100%">
                    <tr>
                        <td></td>
                        <td align="left">
                            <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRoleName" runat="server" Text="<%$ Resources:TestSiteResources, RoleName %>"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRole" runat="server" Width="142px" AutoPostBack="true" onselectedindexchanged="ddlRole_SelectedIndexChanged" 
                                >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ErrorMessage="Provide Role Name"
                                ControlToValidate="ddlRole" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion" InitialValue="0"> * </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblLevelName" runat="server" Text="<%$ Resources:TestSiteResources, LevelName %>"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlLevel" runat="server" Width="142px" onselectedindexchanged="ddlLevel_SelectedIndexChanged" AutoPostBack="true" 
                               >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvLevelName" runat="server" ErrorMessage="Provide Level Name"
                                ControlToValidate="ddlLevel" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion" InitialValue="0"> * </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblKPIName" runat="server" Text="<%$ Resources:TestSiteResources, KPINameL %>"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlKPI" runat="server" Width="142px"  
                               >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvKPIName" runat="server" ErrorMessage="Provide KPI Name"
                                ControlToValidate="ddlKPI" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion" InitialValue="0"> * </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    

                    
                    
                    
                    <tr>
                        <td width="25%">
                            <asp:Label ID="lblTargetValue" runat="server" Text="<%$ Resources:TestSiteResources, TargetValueL %>"></asp:Label>
                        </td>
                        <td width="75%">
                            <asp:TextBox ID="txtTargetValue" runat="server" MaxLength="100" ValidationGroup="Insertion"
                                Width="136px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTargetValue" runat="server" ErrorMessage="Provide Target Value"
                                ControlToValidate="txtTargetValue" Display="Dynamic" 
                                SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revTargetValue" runat="server" 
                                ControlToValidate="txtTargetValue" Display="Dynamic" 
                                ErrorMessage="Enter only Numbers" SetFocusOnError="True" 
                                ValidationExpression="^[0-9]+$" ValidationGroup="Insertion">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                     <tr>
                        <td width="25%">
                            <asp:Label ID="lblDesription" runat="server" Text="Description:"></asp:Label>
                        </td>
                        <td width="75%">
                            <asp:TextBox ID="txtDescription" runat="server" MaxLength="100" ValidationGroup="Insertion"
                                Width="250px" TextMode="MultiLine"></asp:TextBox>                          
                           
                        </td>
                    </tr>
                    <tr id="trActive" runat="server" visible="false">
                        <td>
                            <asp:Label ID="lblActive" runat="server" Text="<%$ Resources:TestSiteResources, Active %>"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbActive" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnAddTarget" runat="server" Text="<%$ Resources:TestSiteResources, Add %>" ValidationGroup="Insertion"
                                OnClick="btnAddTarget_Click" />
                            &nbsp;
                            <asp:Button ID="btnCancelTarget" runat="server" Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancelTarget_Click" />
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
                            <asp:GridView ID="gvTarget" runat="server" ForeColor="#333333" Width="70%" CaptionAlign="Top"
                                CellPadding="4" EmptyDataText="No Records Found" DataKeyNames="Target_ID" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="gvTarget_SelectedIndexChanged" 
                                onrowdatabound="gvTarget_RowDataBound">
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
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblKPIID" runat="server" Text='<%# Eval("KPI_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLevelID" runat="server" Text='<%# Eval("Level_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" AlternateText="<%$ Resources:TestSiteResources, Edit %>" Height="17px" ImageUrl="images/btn_edit.gif"
                                                Width="15px" CommandName="Select" ToolTip="Click to edit the record" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No." ItemStyle-Width="3%">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:BoundField DataField="Role_ID" HeaderText="ID" />--%>
                                    <asp:BoundField DataField="Target_Value" HeaderText="<%$ Resources:TestSiteResources, TargetValue %>" ItemStyle-Width="435px" />
                                    <asp:BoundField DataField="KPI_name" HeaderText="<%$ Resources:TestSiteResources, KPI %>" ItemStyle-Width="435px" />
                                    <%--<asp:BoundField DataField="Target_Desc" HeaderText="Description" ItemStyle-Width="435px" Visible="false" />--%>
                                     <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTarget_Desc" runat="server" Text='<%# Eval("Target_Desc") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="KPI_name" HeaderText="KPI" ItemStyle-Width="435px" />
                                    <asp:BoundField DataField="Level_Name" HeaderText="Level" ItemStyle-Width="435px" />
                                    <asp:BoundField DataField="Role_Name" HeaderText="Role" ItemStyle-Width="435px" />--%>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
