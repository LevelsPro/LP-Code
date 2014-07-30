<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_AssignAwards.ascx.cs"
    Inherits="LevelsPro.ManagerPanel.UserControls.uc_AssignAwards" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
       <div class="box forums-popup">
          <asp:ImageButton ID="exit" width="41" height="41" class="exit"  runat="server" 
               ImageUrl="~/ManagerPanel/Images/remove-quiz.png" onclick="exit_Click" />
                    <asp:Label ID="lblmessage" runat="server" Visible="False"></asp:Label>
             <div class="in-cont p-cont">
                    <asp:Label ID="Label2" class="tr-in fl" runat="server" Text="<%$ Resources:TestSiteResources, AssignAward1 %>"></asp:Label>
                 <span class="tr-in fr mr20">
                    <asp:DropDownList ID="ddlAward" runat="server"  class="abp-opt fr">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvAward" runat="server" ErrorMessage="Provide Award"
                        ControlToValidate="ddlAward" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"
                        InitialValue="0"> * </asp:RequiredFieldValidator></span>
            <div class="clear"></div>
                    <asp:Button ID="btnAssignAward" runat="server" Text="Assign"
                         class="green-btn btn fr mr20 abp" OnClick="btnAssignAward_Click" ValidationGroup="Insertion" />
                
                    <asp:Button ID="btnCancel" runat="server" Text="<%$ Resources:TestSiteResources, Cancel %>"
                        class="green-btn btn fr mr10 abp" OnClick="btnCancel_Click" />
              <div class="clear"></div>
                 <div class="manager-cont fl-wrapper" id="scrollbar2">
                                                               
                <div class="scrollbar">
                            <div class="track">
                                <div class="thumb">
                                    <div class="end">
                                    </div>
                                </div>
                            </div>
                        </div>
                   <div class="viewport msgs">
                    <div class="overview">
                                                               
        <asp:DataList ID="dlAwards" runat="server" RepeatColumns="1" RepeatDirection="Vertical"
            Width="100%" OnItemCommand="dlAwards_ItemCommand1">
            <ItemTemplate>
                <div class="adminprog-cont">
                    <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/ManagerPanel/Images/remove-quiz.png"
                        class="fl mt30" Width="50" Height="50" OnClientClick="return confirm('Are you sure to delete Award.');"
                        CommandName="DeleteAward" CommandArgument='<%# Eval("userAwardsId") %>' />
                    <asp:Image ID="imgAwardImage" runat="server" ImageUrl='<%# Eval("Award_Thumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["AwardsThumbPath"].ToString() + Eval("Award_Thumbnail") :"Images/placeholder.png" %>'
                        class="fl" Width="72" Height="72" />
                    <h1 class="prog-text">
                        <%#Eval("Award_Name")%>
                        <br />
                        <%# Convert.ToDateTime(Eval("awarded_date")).ToShortDateString() %>
                    </h1>
                    <%-- <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="green-btn prog-edit fr" />--%>
                    <div class="clear">
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        </div>
        </div>
        </div>
        </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
