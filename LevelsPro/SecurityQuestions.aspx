<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityQuestions.aspx.cs"
    Inherits="LevelsPro.SecurityQuestions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function fncheckDuplication() {
            var e = document.getElementById("ddlQuestion1");

            var strQuestion1 = e.options[e.selectedIndex].value;

            var e1 = document.getElementById("ddlQuestion2");

            var strQuestion2 = e1.options[e1.selectedIndex].value;

            var e2 = document.getElementById("ddlQuestion3");

            var strQuestion3 = e2.options[e2.selectedIndex].value;

            if ((strQuestion1 == strQuestion2) && (strQuestion2 == strQuestion3)) {
                alert("question1,question2 and question3 are same");
            }
            else
                if (strQuestion1 == strQuestion2) {
                    alert("question1 and question2 are same");
                }
                else
                    if (strQuestion2 == strQuestion3) {
                        alert("question2 and question3 are same");
                    }


            //         else
            //        if(strQuestion3 == strQuestion1)
            //        {
            //            alert("question1 and question3 are same");
            //        }


        }
        function fncheckDuplication2() {
            var e = document.getElementById("ddlQuestion1");

            var strQuestion1 = e.options[e.selectedIndex].value;

            var e1 = document.getElementById("ddlQuestion2");

            var strQuestion2 = e1.options[e1.selectedIndex].value;

            var e2 = document.getElementById("ddlQuestion3");

            var strQuestion3 = e2.options[e2.selectedIndex].value;

            if ((strQuestion1 == strQuestion2) && (strQuestion2 == strQuestion3)) {
                alert("question1,question2 and question3 are same");
            }
            else
            //            if (strQuestion1 == strQuestion2) {
            //                alert("question1 and question2 are same");
            //            }
            //            else
                if (strQuestion2 == strQuestion3) {
                    alert("question2 and question3 are same");
                }
                else
                    if (strQuestion3 == strQuestion1) {
                        alert("question1 and question3 are same");
                    }


        }
        function fncheckDuplication3() {
            var e = document.getElementById("ddlQuestion1");

            var strQuestion1 = e.options[e.selectedIndex].value;

            var e1 = document.getElementById("ddlQuestion2");

            var strQuestion2 = e1.options[e1.selectedIndex].value;

            var e2 = document.getElementById("ddlQuestion3");

            var strQuestion3 = e2.options[e2.selectedIndex].value;

            if ((strQuestion1 == strQuestion2) && (strQuestion2 == strQuestion3)) {
                alert("question1,question2 and question3 are same");
            }
            else
                if (strQuestion1 == strQuestion2) {
                    alert("question1 and question2 are same");
                }
                else
                //                    if (strQuestion2 == strQuestion3) {
                //                        alert("question2 and question3 are same");
                //                    }
                //else
                    if (strQuestion3 == strQuestion1) {
                        alert("question1 and question3 are same");
                    }


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="upQuest" runat="server">
            <ContentTemplate>
                <table cellpadding="4" cellspacing="0" width="700px">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblHeading" runat="server" Text="<%$ Resources:TestSiteResources, ProvideInformation %>"
                                Font-Bold="true" Font-Size="18px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMeassage" runat="server" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            <asp:Label ID="lblPassword" runat="server" Text="<%$ Resources:TestSiteResources, NewPassword %> "></asp:Label>
                        </td>
                        <td width="70%">
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ErrorMessage="*" ValidationGroup="Email"
                                ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblConfirmPassword" runat="server" Text="<%$ Resources:TestSiteResources, ConfirmPassword %>"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="*"
                                ValidationGroup="Email" ControlToValidate="txtConfirmPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvPassword" runat="server" ErrorMessage="Password does not match."
                                ValidationGroup="Email" ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword"
                                Operator="Equal"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <%--<asp:Button ID="btnUpdatePassword" runat="server" Text="Change Password" ValidationGroup="Change"
                         />--%>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblChoice" runat="server" Text="<%$ Resources:TestSiteResources, INCaseForgot %> "></asp:Label>
                <asp:RadioButtonList ID="rblChoice" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                    RepeatLayout="Flow" OnSelectedIndexChanged="rblChoice_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="<%$ Resources:TestSiteResources, EmailH %>" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:TestSiteResources, SecurityQuestions %>" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
                <br />
                <br />
                <div id="divEmail" runat="server">
                    <asp:Label ID="lblName" runat="server" Text=" <%$ Resources:TestSiteResources, EnterEmail %>"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                        ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" Display="Dynamic"
                        ValidationGroup="Email"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Enter valid email address."
                        ControlToValidate="txtEmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="Email"></asp:RegularExpressionValidator>
                    <br />
                    <%--<asp:Button ID="btnSubmitEmail" runat="server" Text="Submit" ValidationGroup="Email"
                OnClick="btnSubmitEmail_Click" />--%>
                </div>
                <div id="divQuestions" runat="server" visible="false">
                    <table cellpadding="4" cellspacing="0" width="700px">
                        <tr>
                            <td width="20%">
                                <asp:Label ID="lblQuestion1" runat="server" Text="<%$ Resources:TestSiteResources, QuestionOne %>"></asp:Label>
                            </td>
                            <td width="80%">
                                <asp:DropDownList ID="ddlQuestion1" runat="server" Width="80%" onchange="fncheckDuplication3()">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvQuestion1" runat="server" InitialValue="0" ErrorMessage="*"
                                    ValidationGroup="Question" ControlToValidate="ddlQuestion1"></asp:RequiredFieldValidator>
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
                                <asp:DropDownList ID="ddlQuestion2" runat="server" Width="80%" onchange="fncheckDuplication()">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvQuestion2" runat="server" ErrorMessage="*" InitialValue="0"
                                    ValidationGroup="Question" ControlToValidate="ddlQuestion2"></asp:RequiredFieldValidator>
                                <%--<asp:CompareValidator ID="cvquestion1" runat="server" ErrorMessage="same question"
                                    ValidationGroup="Question" ControlToCompare="ddlQuestion1" ControlToValidate="ddlQuestion2"
                                    Operator="NotEqual"></asp:CompareValidator>--%>
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
                                <asp:DropDownList ID="ddlQuestion3" runat="server" Width="80%" onchange="fncheckDuplication2()">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvQuestion3" runat="server" ErrorMessage="*" InitialValue="0"
                                    ValidationGroup="Question" ControlToValidate="ddlQuestion3"></asp:RequiredFieldValidator>
                                <%-- <asp:CompareValidator ID="cvquestion2" runat="server" ErrorMessage="same question"
                                    Display="Dynamic" ValidationGroup="Question" ControlToCompare="ddlQuestion2"
                                    ControlToValidate="ddlQuestion3" Operator="NotEqual"></asp:CompareValidator>
                                <asp:CompareValidator ID="cvquestion3" runat="server" ErrorMessage="same question"
                                    Display="Dynamic" ValidationGroup="Question" ControlToCompare="ddlQuestion3"
                                    ControlToValidate="ddlQuestion1" Operator="NotEqual"></asp:CompareValidator>--%>
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
                    </table>
                </div>
                <br />
                <center>
                    <asp:Button ID="btnSubmit" runat="server" Text="<%$ Resources:TestSiteResources, Submit %>"
                        OnClick="btnSubmit_Click" /></center>
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
