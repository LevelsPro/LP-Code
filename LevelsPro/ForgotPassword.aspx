<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="LevelsPro.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblMeassage" runat="server" Visible="false"></asp:Label>
        <br />
        <br />
        <asp:Panel ID="pnlForgotStep1" runat="server" Visible="true">
            <table width="700" border="0" cellspacing="0" cellpadding="3">
                <tr>
                    <td colspan="3" align="left">
                        <h3>
                            <asp:Label ID="lblForgot" runat="server" Text=" <%$ Resources:TestSiteResources, InfoNeeded %>"></asp:Label></h3>
                        <b>
                            <asp:Label ID="lblProtect" runat="server" Text=" <%$ Resources:TestSiteResources, ProtectsAccount %>"></asp:Label></b><br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text=" <%$ Resources:TestSiteResources, UserName %>"></asp:Label><br />
                        <br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtUser" runat="server" MaxLength="32" Width="155px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ControlToValidate="txtUser"
                            SetFocusOnError="true" ValidationGroup="username"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnProceed" runat="server" Text="<%$ Resources:TestSiteResources, Proceed %>"
                            Width="155px" OnClick="btnProceed_Click" ValidationGroup="username" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlForgotStep2" runat="server" Visible="false">
            <%--<asp:Label ID="lblUserName" runat="server" Text="User Name: "></asp:Label>
            &nbsp; : &nbsp;
            <asp:Label ID="lblUserNameValue" runat="server" Font-Bold="true"></asp:Label>--%>
            <br />
            <br />
            <asp:Label ID="lblChoice" runat="server" Text="<%$ Resources:TestSiteResources, RetrievePassword %>"></asp:Label>
            <asp:RadioButtonList ID="rblChoice" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                RepeatLayout="Flow" OnSelectedIndexChanged="rblChoice_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="<%$ Resources:TestSiteResources, EmailH %>" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="<%$ Resources:TestSiteResources, SecurityQuestions %>" Value="2"></asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            <div id="divEmail" runat="server">
                <asp:Label ID="lblEnterEmail" runat="server" Text="<%$ Resources:TestSiteResources, EnterEmail %>"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                    ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" Display="Dynamic"
                    ValidationGroup="Email"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Enter valid email address."
                    ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="Email"></asp:RegularExpressionValidator>
                <br />
                <asp:Button ID="btnSubmitEmail" runat="server" Text="<%$ Resources:TestSiteResources, Submit %>"
                    OnClick="btnSubmitEmail_Click" ValidationGroup="Email" />
                &nbsp;<asp:Button ID="btnLogin" runat="server" Text="<%$ Resources:TestSiteResources, GoLogin %>" PostBackUrl="~/Index.aspx"
                    Visible="false" />
            </div>
            <div id="divQuestions" runat="server" visible="false">
                <table cellpadding="4" cellspacing="0" width="700px">
                    <tr>
                        <td width="20%">
                            <asp:Label ID="lblQuestion1" runat="server" Text="<%$ Resources:TestSiteResources, QuestionOne %>"></asp:Label>
                        </td>
                        <td width="80%">
                            <asp:DropDownList ID="ddlQuestion1" runat="server" Width="80%">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvQuestion1" runat="server" InitialValue="0" ErrorMessage="*" ValidationGroup="Question"
                                ControlToValidate="ddlQuestion1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Label ID="lblAnswer1" runat="server" Text="<%$ Resources:TestSiteResources, Answer %>"></asp:Label>
                        </td>
                        <td width="78%">
                            <asp:TextBox ID="txtAnswer1" runat="server" Width="79%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAnswer1" runat="server" ErrorMessage="*" ValidationGroup="Question"
                                ControlToValidate="txtAnswer1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Label ID="lblQuestion2" runat="server" Text="<%$ Resources:TestSiteResources, Questiontwo %>"></asp:Label>
                        </td>
                        <td width="80%">
                            <asp:DropDownList ID="ddlQuestion2" runat="server" Width="80%">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvQuestion2" runat="server" ErrorMessage="*" InitialValue="0" ValidationGroup="Question"
                                ControlToValidate="ddlQuestion2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Label ID="lblAnswer2" runat="server" Text="<%$ Resources:TestSiteResources, Answer %>"></asp:Label>
                        </td>
                        <td width="78%">
                            <asp:TextBox ID="txtAnswer2" runat="server" Width="79%"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvAnswer2" runat="server" ErrorMessage="*" ValidationGroup="Question"
                                ControlToValidate="txtAnswer2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Label ID="lblQuestion3" runat="server" Text="<%$ Resources:TestSiteResources, Questionthree %>"></asp:Label>
                        </td>
                        <td width="80%">
                            <asp:DropDownList ID="ddlQuestion3" runat="server" Width="80%">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvQuestion3" runat="server" ErrorMessage="*" InitialValue="0" ValidationGroup="Question"
                                ControlToValidate="ddlQuestion3"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Label ID="lblAnswer3" runat="server" Text="<%$ Resources:TestSiteResources, Answer %>"></asp:Label>
                        </td>
                        <td width="78%">
                            <asp:TextBox ID="txtAnswer3" runat="server" Width="79%"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvAnswer3" runat="server" ErrorMessage="*" ValidationGroup="Question"
                                ControlToValidate="txtAnswer3"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <td width="50%">
                            <asp:Label ID="lblQuestion1" runat="server" Text="<%$ Resources:TestSiteResources, Question1 %>"></asp:Label>
                        </td>
                        <td width="50%">
                            <asp:TextBox ID="txtAnswer1" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAnswer1" runat="server" ErrorMessage="*" ValidationGroup="Question"
                                ControlToValidate="txtAnswer1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblQuestion2" runat="server" Text="<%$ Resources:TestSiteResources, Question2 %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAnswer2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAnswer2" runat="server" ErrorMessage="*" ValidationGroup="Question"
                                ControlToValidate="txtAnswer2"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblQuestion3" runat="server" Text="<%$ Resources:TestSiteResources, Question3 %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAnswer3" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAnswer3" runat="server" ErrorMessage="*" ValidationGroup="Question"
                                ControlToValidate="txtAnswer3"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                        </td>
                        <td align="center">
                            <asp:Button ID="btnSubmitAnswers" runat="server" Text="<%$ Resources:TestSiteResources, Submit %>"
                                ValidationGroup="Question" OnClick="btnSubmitAnswers_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divChangePwd" runat="server" visible="false">
                <table cellpadding="4" cellspacing="0" width="700px">
                    <tr>
                        <td width="20%">
                            <asp:Label ID="lblNewPassword" runat="server" Text="<%$ Resources:TestSiteResources, NewPassword %>"></asp:Label>
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ErrorMessage="*" ValidationGroup="Change"
                                ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblConfirmPassword" runat="server" Text="<%$ Resources:TestSiteResources, ConfirmPassword %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ValidationGroup="Change" ControlToValidate="txtConfirmPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password does not match."
                                ValidationGroup="Change" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword"
                                Operator="Equal"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnUpdatePassword" runat="server" Text="<%$ Resources:TestSiteResources, ChangePasswordB %>"
                                ValidationGroup="Change" OnClick="btnUpdatePassword_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
