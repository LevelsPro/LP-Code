<%@ Page Title="Edit DataSet" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="DataSetEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.DataSetEdit" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();          

        });
  
        function disableautocompletion(id) {
            var passwordControl = document.getElementById(id);
            passwordControl.setAttribute("autocomplete", "off");
        }

        function readURL(input, id) {                

            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#'+id).attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }    

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>"
            CssClass="green-btn btn fl" OnClick="btnHome_Click"></asp:Button>
        <div class="user-nt fl er">
            <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>
    <div class="box brd2">
        <div id="flWrapper" runat="server" class="fl-wrapper">
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            <div class="clear">
            </div>
            <div class="strip">
                <asp:Label ID="lblLocation" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Location %>"></asp:Label>
                <span class="edit-right tl">
                    <asp:DropDownList ID="ddlLocation" runat="server" class="aw-edit-combo fr">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ErrorMessage="Provide Location"
                        ControlToValidate="ddlLocation" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"
                        InitialValue="-1"> * </asp:RequiredFieldValidator></span>
                <div class="clear">
                </div>
            </div>
        </div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="manager-cont mt10" id="scrollbar1">
                    <div class="scrollbar" style="height: 450px;">
                        <div class="track" style="height: 450px;">
                            <div class="thumb" style="top: 0px; height: 52px;">
                                <div class="end">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="viewport progadmin">
                        <div class="overview" style="top: 0px;">
                            <asp:DataList ID="dlRoles" runat="server" Width="100%" RepeatDirection="Vertical"
                                RepeatColumns="1" OnItemDataBound="dlRoles_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="l33p hem">
                                        <asp:Label ID="lblimg" runat="server" Text="<%$ Resources:TestSiteResources, Role %>"></asp:Label>
                                    </div>
                                    <div class="r66p hem">
                                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, Levels1 %>"></asp:Label>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="l33p">
                                        <asp:Literal ID="ltRoleID" runat="server" Text='<%# Eval("Role_ID") %>' Visible="false"></asp:Literal>
                                        <asp:Literal ID="ltRole" runat="server" Text='<%# Eval("Role_Name") %>'></asp:Literal>
                                    </div>
                                    <div class="r66p">
                                        <asp:DataList ID="dlLevels" runat="server" RepeatDirection="Horizontal" RepeatColumns="10"
                                            OnItemCommand="dlLevels_ItemCommand">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltRoleID" runat="server" Text='<%# Eval("Role_ID") %>' Visible="false"></asp:Literal>
                                                <asp:Button ID="btnLevels" runat="server" class="lvl-white" Text='<%# Eval("Level_Position") %>'
                                                    CommandName="LevelSet" CommandArgument='<%# Eval("Level_ID") %>' />
                                                </div>
                                                <div class="clear">
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>                  
        </asp:UpdatePanel>
        <asp:Button ID="btnAddDataSet" runat="server" class="edit-left" CssClass="green-btn admin-edit fr"
            Text="<%$ Resources:TestSiteResources, Add %>" ValidationGroup="Insertion" OnClick="btnAddDataSet_Click" />
        &nbsp;
        <asp:Button ID="btnCancel" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
            Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
        <asp:HiddenField ID="hfControls" runat="server" />
        <div class="clear">
        </div>
    </div>
</asp:Content>
