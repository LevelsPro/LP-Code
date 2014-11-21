<%@ Page Title="API Import Sheet" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="APIExportSheet.aspx.cs" Inherits="LevelsPro.AdminPanel.APIExportSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/admin-theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/admin-website.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <link href="../Styles/lightbox.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.smooth-scroll.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script src="../Scripts/lightbox.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/AdminHome.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl">
         <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources,  APIImportSheet %>"></asp:Label>
           </div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
        <br />
        <asp:FileUpload ID="fuImport" runat="server" /><br />
        <asp:Button ID="btnImpToGrid" runat="server" CssClass="green-btn admin-edit fl" Text="<%$ Resources:TestSiteResources, UploadToGrid %>"
            OnClick="btnImpToGrid_Click" Width="160px" />&nbsp;      &nbsp;&nbsp;  
        <asp:Button ID="btnImport" runat="server" CssClass="green-btn admin-edit fl" Text="<%$ Resources:TestSiteResources, Import %>"
            OnClick="btnImport_Click" /><br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:LevelsproCS %>" 
            ProviderName="<%$ ConnectionStrings:LevelsproCS.ProviderName %>" 
            SelectCommand="Select UserID, U_EmpID from tblUser"></asp:SqlDataSource>
        <br /><br /><br />
        <asp:GridView ID="gvAPI" runat="server" AutoGenerateColumns="true" Width="100%">
                    </asp:GridView>
        <div class="manager-cont" id="scrollbar1">
            <div class="scrollbar">
                <div class="track">
                    <div class="thumb">
                        <div class="end">
                        </div>
                    </div>
                </div>
            </div>
            <div class="viewport progadmin">
                <div class="overview">
                    
                    <%-- <asp:GridView ID="gvAPI1" runat="server" AutoGenerateColumns="false" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="User ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="KPI ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblKPIID" runat="server" Text='<%# Eval("KPIID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Score">
                                <ItemTemplate>
                                    <asp:Label ID="lblScore" runat="server" Text='<%# Eval("Score") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Measure">
                                <ItemTemplate>
                                    <asp:Label ID="lblMeasure" runat="server" Text='<%# Eval("Measure") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date and Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblDateTime" runat="server" Text='<%# Eval("DateTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                        <HeaderStyle ForeColor="White" />
                    </asp:GridView>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
