<%@ Page Title="Edit Question" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master"
    AutoEventWireup="true" CodeBehind="QuestionEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.QuestionEdit" %>

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

            function readURL(input) {                

                if (input.files && input.files[0]) {
                    var reader = new FileReader();

                    reader.onload = function (e) {                                             
                        /*$('#<%=hdImage.ClientID%>').val(e.target.result)*/
                        $('#imgQuestion').attr('src', e.target.result);
                    }

                    reader.readAsDataURL(input.files[0]);
                }
            }
    

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--  <asp:UpdatePanel ID="upMain" runat="server">
        <ContentTemplate>--%>
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
                <div class="fl-wrapper">
                    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                    <div class="clear">
                    </div>
                    <div class="strip">
                        <asp:Label ID="lblQuestionText" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Question %>"></asp:Label>
                        <span class="edit-right tl">
                            <asp:TextBox ID="txtQuestion" runat="server" class="qq-admin" 
                            MaxLength="200" AutoCompleteType="Disabled"
                                onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvQuestion" runat="server" ErrorMessage="Provide Question"
                                ControlToValidate="txtQuestion" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator></span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip">
                        <asp:Label ID="lblShort" runat="server" class="edit-left" Text="Short Question"></asp:Label>
                        <span class="edit-right tl">
                            <asp:TextBox ID="txtShort" runat="server" class="qq-admin" MaxLength="100" AutoCompleteType="Disabled"
                                onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Provide Question"
                                ControlToValidate="txtQuestion" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator></span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip">
                        <asp:Label ID="lblExplanation" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, Explanation %>"
                            Width="174px"></asp:Label>
                        <span class="edit-right tl">
                            <asp:TextBox ID="txtExplanation" runat="server" class="qq-admin" ValidationGroup="Insertion"
                                MaxLength="200" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvExplanation" runat="server" ErrorMessage="Provide Explanation"
                                ControlToValidate="txtExplanation" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator></span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip">
                        <asp:Label ID="lblCorrectAnswer" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, CorrectAnswer %>"></asp:Label>
                        <span class="edit-right tl">
                            <asp:TextBox ID="txtCorrectAnswer" runat="server" class="qq-admin" ValidationGroup="Insertion"
                                MaxLength="35" AutoCompleteType="Disabled" 
                            onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCorrectAnswer" runat="server" ErrorMessage="Provide Correct Answer"
                                ControlToValidate="txtCorrectAnswer" Display="Dynamic" SetFocusOnError="True"
                                ValidationGroup="Insertion"> * </asp:RequiredFieldValidator></span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip">
                        <asp:Label ID="lblIncorrectAnswers" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, IncorrectAnswers %>"></asp:Label>
                        <span class="edit-right tl">
                            <asp:TextBox ID="txtAnswer1" runat="server" class="qq-admin-s" 
                            MaxLength="35" AutoCompleteType="Disabled"
                                onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAnswer1" runat="server" ErrorMessage="Provide Incorrect Answer 1"
                                ControlToValidate="txtAnswer1" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAnswer2" runat="server" class="qq-admin-s" 
                            MaxLength="35" AutoCompleteType="Disabled"
                                onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAnswer2" runat="server" ErrorMessage="Provide Incorrect Answer 2"
                                ControlToValidate="txtAnswer2" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtAnswer3" runat="server" class="qq-admin-s" 
                            MaxLength="35" AutoCompleteType="Disabled"
                                onfocus="disableautocompletion(this.id);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAnswer3" runat="server" ErrorMessage="Provide Incorrect Answer 3"
                                ControlToValidate="txtAnswer3" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator></span>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="strip">
                        <asp:Label ID="lblCategory" runat="server" class="edit-left" Text="<%$ Resources:TestSiteResources, CategoryH %>"></asp:Label>
                        <span class="edit-right wbg">
                            <asp:DropDownList ID="ddlCategory" runat="server" class="aw-edit-combo fr" 
                            onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ErrorMessage="Provide Category"
                                ControlToValidate="ddlCategory" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"
                                InitialValue="0"> * </asp:RequiredFieldValidator></span>
                        <asp:Button ID="btnCategoryEdit" runat="server" Text="Edit Category" OnClick="btnCategoryEdit_Click" />
                        <div class="clear">
                        </div>
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
                <div class="fl-wrapper img-r mt10 pr">
                    <div class="r-image">
                    <%--    <asp:Image ID="imgQuestion" runat="server" ImageUrl="~/Images/No_Image_Wide.png"
                            Width="284px" Height="223px"/> --%>                     
                        <img id="imgQuestion" alt=""  src="<%= hdImage.Value %>" style="width: 284px; height: 223px"  />
                        <asp:HiddenField ID="hdImage" runat="server" Value="/Images/No_Image_Wide.png" />

                    </div>
                    <div class="green-btn create-reward change-img fr">
                        <asp:Label ID="lblimg" runat="server" Text="<%$ Resources:TestSiteResources, ChangeImage %>"></asp:Label></div>
                    <asp:FileUpload ID="fuQuestionImage" class="change-img-transparent" runat="server" onchange="readURL(this);"/>
                    <asp:Button ID="btnAddImage" runat="server" class="green-btn create-reward change-img fr"
                        Text="<%$ Resources:TestSiteResources, AddImage %>" Visible="false" />
                    <div class="clear">
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
                                            <%-- <table>
                                <tr>
                                    <td>--%>
                                            <div class="l33p">
                                                <asp:Literal ID="ltRoleID" runat="server" Text='<%# Eval("Role_ID") %>' Visible="false"></asp:Literal>
                                                <asp:Literal ID="ltRole" runat="server" Text='<%# Eval("Role_Name") %>'></asp:Literal>
                                            </div>
                                            <%--</td>
                                    <td>--%>
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
                                            <%--</td>
                                </tr>
                            </table>--%>
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                  
                </asp:UpdatePanel>
                <asp:Button ID="btnAddQuestion" runat="server" class="edit-left" CssClass="green-btn admin-edit fr"
                    Text="<%$ Resources:TestSiteResources, Add %>" ValidationGroup="Insertion" OnClick="btnAddQuestion_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
                    Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
                <div class="clear">
                </div>
            </div>
            <asp:UpdatePanel ID="upManualScore" runat="server">
                <ContentTemplate>
            <asp:Button ID="_editPopupButton" runat="server" Text="Edit Contact" Style="display: none" />
            <asp:ModalPopupExtender ID="mpeManualScore" runat="server" BackgroundCssClass="modalBackground"
                RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
                PopupControlID="_CreatePostDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
                BehaviorID="EditModalPopupPost">
            </asp:ModalPopupExtender>
            <div class="_popupButtons" style="display: none">
                <input id="_okPopupButton" value="OK" type="button" />
                <input id="_cancelPopupButton" value="Cancel" type="button" />
            </div>
            <%--<asp:UpdatePanel ID="upManualScore" runat="server">
                <ContentTemplate>--%>
                    <div id="_CreatePostDiv" class="box forums-popup" style="background-color: Gray;
                        height: 30%; display: none">
                        Add or Edit Category

                        
                        <table>
                        <tr><td></td><td><asp:Label ID="lblcatgmess" runat="server" Visible="false"></asp:Label></td></tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblCategory1" runat="server" Text="Category"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:GridView ID="gvCategory" runat="server" ForeColor="#333333" Width="70%" CaptionAlign="Top"
                                        CellPadding="4" AutoGenerateColumns="false" DataKeyNames="CategoryID" OnSelectedIndexChanged="gvCategory_SelectedIndexChanged">
                                        <FooterStyle BackColor="#348ec2" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <EditRowStyle BackColor="#999999" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#348EC2" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#348ec2" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="8%">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgEdit" runat="server" AlternateText="<%$ Resources:TestSiteResources, Edit %>"
                                                        Height="17px" ImageUrl="images/btn_edit.gif" Width="15px" CommandName="Select"
                                                        ToolTip="Click to edit the record" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="S.No." ItemStyle-Width="3%">
                                                <ItemTemplate>
                                                    <asp:Literal ID="ltsno" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Literal>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CategoryName" HeaderText="Name" ItemStyle-Width="200px"
                                                ItemStyle-HorizontalAlign="Center" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="<%$ Resources:TestSiteResources, Save %>"
                                        OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="btnCancel1" runat="server" Text="<%$ Resources:TestSiteResources, Cancel %>"
                                        OnClick="btnCancel1_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
        </asp:UpdatePanel> 
<%--          
       </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddQuestion" />
        </Triggers>
    </asp:UpdatePanel>--%>
</asp:Content>
