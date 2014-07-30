<%@ Page Title="Edit Quiz" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" AutoEventWireup="true" CodeBehind="QuizEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.QuizEdit" %>
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
                $('#imgQuiz').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/QuizManagement.aspx"
            CssClass="green-btn btn fl"></asp:Button>
        <div class="user-nt fl er">
            <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
        <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
            CssClass="green-btn btn fr" OnClick="btnLogout_Click"></asp:Button>
        <div class="clear">
        </div>
    </div>

    <div class="box brd2">
        <div class="fl-wrapper">
            <asp:Label ID="lblmessage" runat="server" Visible="false"></asp:Label>            
            <div class="clear">
            </div>
            <div class="strip">
                <asp:Label ID="lblQuizName" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, NameL %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtQuizName" runat="server"  class="qq-admin" MaxLength="100"
                    ValidationGroup="Insertion" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvQuizName" runat="server" ErrorMessage="Provide Quiz Name"
                    ControlToValidate="txtQuizName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>    </span>            
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblNoOfQuestions" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, NoOfQuestions %>"></asp:Label>
                 <span class="edit-right32 tl">
                <asp:TextBox ID="txtNoOfQuestions" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="200" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoOfQuestions" runat="server" ErrorMessage="Provide No. of Questions"
                    ControlToValidate="txtNoOfQuestions" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator> </span>               
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblNoOfTimesPerDay" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, NoTimesPlayable %>"></asp:Label>
                 <span class="edit-right32 tl">
                <asp:TextBox ID="txtNoOfTimesPerDay" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoOfTimesPerDay" runat="server" ErrorMessage="Provide No. of Questions Per Day"
                    ControlToValidate="txtNoOfTimesPerDay" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                <asp:RegularExpressionValidator ID="revNoOfTimesPerDay" runat="server" ControlToValidate="txtNoOfTimesPerDay"
                    Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>   </span>             
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblTimePerQuestion" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, TimePerQuestion %>"></asp:Label>
                 <span class="edit-right32 tl">
                <asp:TextBox ID="txtTimePerQuestion" runat="server" class="qq-admin"  ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTimePerQuestion" runat="server" ErrorMessage="Provide time per question"
                    ControlToValidate="txtTimePerQuestion" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                <asp:RegularExpressionValidator ID="revTimePerQuestion" runat="server" ControlToValidate="txtTimePerQuestion"
                    Display="Dynamic" ErrorMessage="Enter only numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>       </span>         
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblPointsPerQuestion" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, Pointsperquestion %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtPointsPerQuestion" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPointsPerQuestion" runat="server" ErrorMessage="Provide time per question"
                    ControlToValidate="txtPointsPerQuestion" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                <asp:RegularExpressionValidator ID="revPointsPerQuestion" runat="server" ControlToValidate="txtPointsPerQuestion"
                    Display="Dynamic" ErrorMessage="Enter only numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>     </span>           
                <div class="clear">
                </div>
            </div>
            
            <div class="strip">
                <asp:Label ID="lblTimeBeforePointDeduction" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, TimeDeduction %>"></asp:Label>
                  <span class="edit-right32 tl">
                <asp:TextBox ID="txtTimeBeforePointDeduction" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTimeBeforePointDeduction" runat="server" ErrorMessage="Provide time before point deduction"
                    ControlToValidate="txtTimeBeforePointDeduction" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                <asp:RegularExpressionValidator ID="revTimeBeforePointDeduction" runat="server" ControlToValidate="txtTimeBeforePointDeduction"
                    Display="Dynamic" ErrorMessage="Enter only numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>         </span>       
                <div class="clear">
                </div>
            </div>

            <div class="strip">
                <asp:Label ID="lblKPIName" runat="server" class="edit-left32" Text="KPI Relation: "></asp:Label>
                <span class="edit-right32 tl">
                <asp:DropDownList ID="ddlKPI_ID" runat="server" CssClass="combo-fw" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:DropDownList>
                </span>           
                <div class="clear">
                </div>
            </div>
            </div>
           
            	<div  class="fl-wrapper img-r mt10 pr">
                <div class="r-image" >
                <%--<asp:Image ID="imgQuiz" runat="server" ImageUrl="~/Images/No_Image_Wide.png" width="284px" height="223px" />--%>
                 <img id="imgQuiz" alt=""  src="<%= hdImage.Value %>" style="width: 284px; height: 223px"  />
                        <asp:HiddenField ID="hdImage" runat="server" Value="/Images/No_Image_Wide.png" />
                </div>
                  <div class="green-btn create-reward change-img fr"> <asp:Label ID="lblimg" runat="server" Text="<%$ Resources:TestSiteResources, ChangeImage %>"></asp:Label></div>
                <asp:FileUpload ID="fuQuizImage"  class="change-img-transparent"  runat="server" onchange="readURL(this);"/>
                <asp:Button ID="btnAddImage" runat="server" class="green-btn create-reward change-img fr" Text="<%$ Resources:TestSiteResources, AddImage %>" 
                    onclick="btnAddImage_Click" Visible="false" />                
                <div class="clear">
                </div>
            </div>
        </div>                                
        <asp:Button ID="btnAddQuiz" runat="server" class="edit-left" CssClass="green-btn admin-edit fr"
            Text="<%$ Resources:TestSiteResources, AddQuiz %>" ValidationGroup="Insertion" onclick="btnAddQuiz_Click" />
        &nbsp;
        <asp:Button ID="btnCancel" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
            Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
        <div class="clear">
        </div>
   

</asp:Content>
