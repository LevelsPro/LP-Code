<%@ Page Title="<%$ Resources:TestSiteResources, EditMatch %>" Language="C#" MasterPageFile="~/AdminPanel/Administrator.master" AutoEventWireup="true" CodeBehind="MatchEdit.aspx.cs" Inherits="LevelsPro.AdminPanel.MatchEdit" %>
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
                $('#imgMatch').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="box top-b options-bar">
        <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, Back %>" PostBackUrl="~/AdminPanel/MatchManagement.aspx"
            CssClass="green-btn btn fl"></asp:Button>        
        <div class="user-nt fl er">
            <asp:Label ID="lblHeading" runat="server" Text="<%$ Resources:TestSiteResources, EditMatch %>"></asp:Label>
        </div>
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
                <asp:Label ID="lblMatchName" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, MatchName %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtMatchName" runat="server"  class="qq-admin" MaxLength="100"
                    ValidationGroup="Insertion" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMatchName" runat="server" ErrorMessage="Provide Match Name"
                    ControlToValidate="txtMatchName" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>    </span>            
                <div class="clear">
                </div>
            </div><!-- MatchName-->
            <div class="strip">
                <asp:Label ID="lblPointsForCompletation" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, PointsForCompletion %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtPointsForCompletation" runat="server" class="qq-admin"  ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPointsForCompletation" runat="server" ErrorMessage="Provide Points per Completation"
                    ControlToValidate="txtPointsForCompletation" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                <asp:RegularExpressionValidator ID="revPointsForCompletation" runat="server" ControlToValidate="txtPointsForCompletation"
                    Display="Dynamic" ErrorMessage="Enter only numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>       </span>
                <div class="clear">
                </div>
            </div><!-- PointsForCompletation-->
            <div class="strip">
                <asp:Label ID="lblMaxPlaysPerDay" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, MaxPlaysPerDay %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtMaxPlaysPerDay" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMaxPlaysPerDay" runat="server" ErrorMessage="Provide Max Plays Per Day"
                    ControlToValidate="txtMaxPlaysPerDay" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revMaxPlaysPerDay" runat="server" ControlToValidate="txtMaxPlaysPerDay"
                    Display="Dynamic" ErrorMessage="Enter only numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>       </span>
                <div class="clear">
                </div>
            </div><!-- MaxPlaysPerDay-->
            <div class="strip">
                <asp:Label ID="lblNoOfDataSet" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, NoOfDataSet %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:DropDownList ID="ddlNoOfDataSet" runat="server" CssClass="combo-fw" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" 
                    onfocus="disableautocompletion(this.id);">
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvNoOfDataSet" runat="server" ErrorMessage="Provide No. of DataSets"
                    ControlToValidate="ddlNoOfDataSet" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator></span>
                <div class="clear">
                </div>
            </div><!-- NoOfDataSet-->
            <div class="strip">
                <asp:Label ID="lblNoOfRounds" runat="server" class="edit-left32" Text="<%$ Resources:TestSiteResources, NoOfRounds %>"></asp:Label>
                <span class="edit-right32 tl">
                <asp:TextBox ID="txtNoOfRounds" runat="server" class="qq-admin" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNoOfRounds" runat="server" ErrorMessage="Provide No. of Rounds"
                    ControlToValidate="txtNoOfRounds" Display="Dynamic" SetFocusOnError="True" ValidationGroup="Insertion"> * </asp:RequiredFieldValidator>                
                <asp:RegularExpressionValidator ID="revNoOfRounds" runat="server" ControlToValidate="txtNoOfRounds"
                    Display="Dynamic" ErrorMessage="Enter only Numbers" SetFocusOnError="True" ValidationExpression="^[0-9]+$"
                    ValidationGroup="Insertion">Enter numbers only.</asp:RegularExpressionValidator>
                    <br />
                <asp:RangeValidator ID="ranNoOfRounds" runat="server" ErrorMessage="Must be between 1 and 5" ControlToValidate="txtNoOfRounds" 
                    Display="Dynamic" SetFocusOnError="True" MaximumValue="5" MinimumValue="1" ValidationGroup="Insertion">Must be between 1 and 5</asp:RangeValidator>   </span>             
                <div class="clear">
                </div>
            </div><!-- NoOfRounds-->
            <div class="strip">
                <asp:Label ID="lblKPIName" runat="server" class="edit-left32" Text="KPI Relation: "></asp:Label>
                <span class="edit-right32 tl">
                <asp:DropDownList ID="ddlKPI_ID" runat="server" CssClass="combo-fw" ValidationGroup="Insertion"
                    MaxLength="10" AutoCompleteType="Disabled" onfocus="disableautocompletion(this.id);"></asp:DropDownList>
                </span>           
                <div class="clear">
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblDataElementDefinition" runat="server" class="edit-leftfull" Text="<%$ Resources:TestSiteResources, DataElementDefinition %>"></asp:Label>
                <div class="overview">
                    <%--<asp:DataList ID="dlDataElements" runat="server" Width="100%" OnItemCommand="dlDataElements_ItemCommand">
                        <HeaderTemplate>
                            <ul class="header-list">
                                <li><span>Element ID</span></li>
                                <li><span>Element Name</span></li>
                                <li><span>&nbsp;</span></li>
                                <li><span>&nbsp;</span></li>
                            </ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="adminprog-cont">
                                <ul>
                                    <li>
                                        <asp:Label ID="lblElementID" runat="server" Text='<%# Eval("ElementID") %>'></asp:Label>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblElementName" runat="server" Text='<%# Eval("ElementName") %>'></asp:Label>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="EditElement" CommandArgument='<%# Eval("ElementID") %>'>
                                            <span>edit</span>
                                        </asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="DeleteElement" CommandArgument='<%# Eval("ElementID") %>'>
                                            <span>delete</span>
                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>--%>
                    <asp:GridView ID="grdDataElements" AutoGenerateColumns="False" CssClass="fl" DataKeyNames="MatchID,ElementID,ElementName" runat="server" Width="564px">
                        <Columns>
                            <asp:TemplateField HeaderText="Element ID" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="11%" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblElementID" runat="server" Text='<%# Bind("ElementID") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="11%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Element Name" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-Width="69%" ItemStyle-CssClass="table-title" ItemStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblElementName" runat="server" Text='<%# Bind("ElementName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" CssClass="table-title" Width="69%"></ItemStyle>
                            </asp:TemplateField>                            
                            <asp:HyperLinkField Text="Edit" DataNavigateUrlFields='MatchID, ElementID' DataNavigateUrlFormatString='~/AdminPanel/DataElementEdit.aspx?matchid={0}&eid={1}&cmd=edit'
                            ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                ItemStyle-VerticalAlign="Middle" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%"></ItemStyle>
                            </asp:HyperLinkField>
                            <asp:HyperLinkField Text="Delete" DataNavigateUrlFields='MatchID, ElementID' DataNavigateUrlFormatString='~/AdminPanel/DataElementEdit.aspx?matchid={0}&eid={1}&cmd=delete'
                            ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                ItemStyle-VerticalAlign="Middle" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%"></ItemStyle>
                            </asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="overview">
                    <asp:Button ID="btnNewDataElement" class="green-btn create-reward wa" Text="<%$ Resources:TestSiteResources, AddDataElement %>" runat="server"
                        OnClick="btnNewMatchElement_Click" />
                </div>
            </div>
            <div class="strip">
                <asp:Label ID="lblRounds" runat="server" class="edit-leftfull" Text="<%$ Resources:TestSiteResources, MatchRounds %>"></asp:Label>
                <span class="edit-block">
                    <asp:GridView ID="grdRounds" AutoGenerateColumns="False" DataKeyNames="MatchID,RoundID,RoundNumber,RoundName,NoOfDataSets,TimePerRound,PointsPerRound" CssClass="fl" runat="server" Width="564px">
                        <Columns>
                            <asp:TemplateField HeaderText="Round Number" HeaderStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="11%" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblRoundNumber" runat="server" Text='<%# Bind("RoundNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="11%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="25%" ItemStyle-CssClass="table-title" ItemStyle-HorizontalAlign="Left" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblRoundName" runat="server" Text='<%# Bind("RoundName") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left" CssClass="table-title" Width="25%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Number <br/> of DataSets" HeaderStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoOfDataSets" runat="server" Text='<%# Bind("NoOfDataSets") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="16%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time Allowed <br/> (in seconds)" HeaderStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblTimePerRound" runat="server" Text='<%# Bind("TimePerRound") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="16%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Points" HeaderStyle-HorizontalAlign="Center" 
                            ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="12px">
                                <ItemTemplate>
                                    <asp:Label ID="lblPointsPerRound" runat="server" Text='<%# Bind("PointsPerRound") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center" Width="12%"></ItemStyle>
                            </asp:TemplateField>
                            <asp:HyperLinkField Text="Edit" DataNavigateUrlFields='MatchID, RoundID' DataNavigateUrlFormatString='~/AdminPanel/RoundEdit.aspx?matchid={0}&rid={1}&cmd=edit' 
                            ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                ItemStyle-VerticalAlign="Middle" ItemStyle-Font-Underline="false" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Underline="False" Width="10%"></ItemStyle>
                            </asp:HyperLinkField>
                            <asp:HyperLinkField Text="Delete" DataNavigateUrlFields='MatchID, RoundID' DataNavigateUrlFormatString='~/AdminPanel/RoundEdit.aspx?matchid={0}&rid={1}&cmd=delete' 
                            ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" 
                                ItemStyle-VerticalAlign="Middle" >
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%"></ItemStyle>
                            </asp:HyperLinkField>
                        </Columns>
                    </asp:GridView>
                </span>
                <div class="overview">
                    <asp:Button ID="btnAddRound" class="green-btn create-reward wa" Text="<%$ Resources:TestSiteResources, AddRound %>" runat="server"
                        OnClick="btnNewMatchRound_Click" />
                </div>
            </div>
        </div>           
        <div  class="fl-wrapper img-r mt10 pr">
            <div class="r-image" >
                <%--<asp:Image ID="imgMatch" runat="server" ImageUrl="~/Images/No_Image_Wide.png" width="284px" height="223px" />--%>
                <img id="imgMatch" alt=""  src="<%= hdImage.Value %>" style="width: 284px; height: 223px"  />
                <asp:HiddenField ID="hdImage" runat="server" Value="/Images/No_Image_Wide.png" />
            </div>
            <div class="green-btn create-reward change-img fr"> <asp:Label ID="lblimg" runat="server" Text="<%$ Resources:TestSiteResources, ChangeImage %>"></asp:Label></div>
            <asp:FileUpload ID="fuMatchImage"  class="change-img-transparent"  runat="server" onchange="readURL(this);"/>
            <asp:Button ID="btnAddImage" runat="server" class="green-btn create-reward change-img fr" Text="<%$ Resources:TestSiteResources, AddImage %>" 
                onclick="btnAddImage_Click" Visible="false" />                
            <div class="clear">
            </div>
        </div>
    </div>                                
    <asp:Button ID="btnAddMatch" runat="server" class="edit-left" CssClass="green-btn admin-edit fr wa"
        Text="<%$ Resources:TestSiteResources, AddMatch %>" ValidationGroup="Insertion" onclick="btnAddMatch_Click" />
    &nbsp;
    <asp:Button ID="btnCancel" runat="server" class="edit-left" CssClass="green-btn admin-edit fr mr10"
        Text="<%$ Resources:TestSiteResources, Cancel %>" OnClick="btnCancel_Click" />
    <div class="clear">
    </div>
</asp:Content>
