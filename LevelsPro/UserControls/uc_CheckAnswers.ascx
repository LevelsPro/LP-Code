<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_CheckAnswers.ascx.cs"
    Inherits="LevelsPro.UserControls.uc_CheckAnswers" %>
    
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


<div class="popup-cyan">

    <div class="cyan-head">
     <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, AnswerSecurity %>"></asp:Label>  
    </div>
    <div class="answer-title">
        &nbsp &nbsp &nbsp <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, EnterAnswer %>"></asp:Label>
    </div>
    <div>&nbsp &nbsp &nbsp <asp:Label ID="lblMeassage" runat="server" Visible="false"></asp:Label></div>
    <div class="left-label fl">
        <asp:Label ID="lblQuestion1" runat="server" Text="<%$ Resources:TestSiteResources, QuestionOne %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <%-- <select class="choose-answer">--%>
        
        <asp:DropDownList ID="ddlQuestion1" runat="server" Width="100%" CssClass="choose-answer" 
            onchange="fncheckDuplication3()">
        </asp:DropDownList>
        <%-- </select>--%>
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblAnswer1" runat="server" Text="<%$ Resources:TestSiteResources, Answer %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <asp:TextBox ID="txtAnswer1"  CssClass="input-pop" runat="server" Width="86%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAnswer1" runat="server" ErrorMessage="*" ValidationGroup="Question"
            ControlToValidate="txtAnswer1"></asp:RequiredFieldValidator>
    </div>
    <div class="clear">
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblQuestion2" runat="server" Text="<%$ Resources:TestSiteResources, Questiontwo %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <%--<select class="choose-answer">--%>
        <asp:DropDownList CssClass="choose-answer" ID="ddlQuestion2" runat="server" Width="100%"
            onchange="fncheckDuplication()">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvQuestion2" runat="server" ErrorMessage="*" InitialValue="0"
            ValidationGroup="Question" ControlToValidate="ddlQuestion2"></asp:RequiredFieldValidator>
        <%-- </select>--%>
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblAnswer2" runat="server" Text="<%$ Resources:TestSiteResources, Answer %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <asp:TextBox ID="txtAnswer2" runat="server" CssClass="input-pop" Width="86%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAnswer2" runat="server" ErrorMessage="*" ValidationGroup="Question"
            ControlToValidate="txtAnswer2"></asp:RequiredFieldValidator>
    </div>
    <div class="clear">
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblQuestion3" runat="server" Text="<%$ Resources:TestSiteResources, Questionthree %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <%--<select class="choose-answer">--%>
        <asp:DropDownList CssClass="choose-answer" ID="ddlQuestion3" runat="server" Width="100%"
            onchange="fncheckDuplication2()">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvQuestion3" runat="server" ErrorMessage="*" InitialValue="0"
            ValidationGroup="Question" ControlToValidate="ddlQuestion3"></asp:RequiredFieldValidator>
        <%-- </select>--%>
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblAnswer3" runat="server" Text="<%$ Resources:TestSiteResources, Answer %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <asp:TextBox ID="txtAnswer3" runat="server" CssClass="input-pop" Width="86%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAnswer3" runat="server" ErrorMessage="*" ValidationGroup="Question"
            ControlToValidate="txtAnswer3"></asp:RequiredFieldValidator>
    </div>
    <div class="clear">
    </div>
    <div class="btn-pop">
        <div class="green-wrapper pop-btn">
            <asp:Button ID="btnSubmit" CssClass="green" runat="server" Text="<%$ Resources:TestSiteResources, Submit %>" OnClick="btnSubmitAnswers_Click"/>
        </div>
        <div class="green-wrapper pop-btn">
            <asp:Button ID="Button1" runat="server" CssClass="green" Text="<%$ Resources:TestSiteResources, Cancel %>" PostBackUrl="~/Index.aspx" />
        </div>
    </div>
</div>
