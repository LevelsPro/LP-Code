<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_SecurityQuestions.ascx.cs"
    Inherits="LevelsPro.UserControls.uc_SecurityQuestions" %>

  <%--  <script type ="text/javascript">
        // Build a javascript array with all of the select names/values
        var options = new Array();
        $('#ddlQuestion1 option').each(function () {
            $this = $(this);
            options.push({ Name: $this.text(), Value: $this.val() });
        });

        // Create a function for re-building a select minus the chosen option
        var rebuildSelect = function ($selOption, $select) {
            $previouslySelected = $select.find(':selected');
            $select.empty();
            for (var i = 0; i < options.length; i++) {
                var opt = options[i];
                if (opt.Value != $selOption.val()) {
                    if ($previouslySelected.val() == opt.Value) {
                        $select.append('<option value="' + opt.Value + '" selected="selected">' + opt.Name + '</option>');
                    }
                    else {
                        $select.append('<option value="' + opt.Value + '">' + opt.Name + '</option>');
                    }
                }
            }
        }

        // Wire up the event handlers
        var $ddlQuestion1 = $('#ddlQuestion1');
        var $ddlQuestion2 = $('#ddlQuestion2');

        $ddlQuestion1.change(function () {
            rebuildSelect($(this), $ddlQuestion2);
        });

        $ddlQuestion2.change(function () {
            rebuildSelect($(this), $ddlQuestion1);
        });

        // Go ahead and run the function on each box to remove the default entries from the other box
        rebuildSelect($ddlQuestion1.find(':selected'), $ddlQuestion2);
        rebuildSelect($ddlQuestion2.find(':selected'), $ddlQuestion1);
    </script>--%>

<%--
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
</script>--%>





<%--<div id="divQuestions" runat="server" visible="false">--%>



<div class="popup-cyan">
    <div class="cyan-head">
     <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, SetSecurity %>"></asp:Label>
    </div>
    <div class="answer-title">
     <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, SelectSecurity %>"></asp:Label>
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblQuestion1" runat="server" Text="<%$ Resources:TestSiteResources, QuestionOne %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <%-- <select class="choose-answer">--%>
        <asp:DropDownList CssClass="choose-answer" ID="ddlQuestion1" runat="server" 
            Width="95%">
        </asp:DropDownList>
        <%-- </select>--%>
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblAnswer1" runat="server" Text="<%$ Resources:TestSiteResources, Answer %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <asp:TextBox ID="txtAnswer1"  CssClass="input-pop" runat="server" Width="88%" 
            autocomplete="off"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAnswer1" runat="server" ErrorMessage="*" ValidationGroup="Questiongrp"
            ControlToValidate="txtAnswer1"></asp:RequiredFieldValidator>
    </div>
    <div class="clear">
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblQuestion2" runat="server" Text="<%$ Resources:TestSiteResources, Questiontwo %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <%--<select class="choose-answer">--%>
        <asp:DropDownList CssClass="choose-answer" ID="ddlQuestion2" runat="server" Width="95%">
        </asp:DropDownList>           
            <%--<asp:CompareValidator
                ID="CompareValidator1" ControlToValidate="ddlQuestion2" runat="server" 
            ErrorMessage="*" ValidationGroup="Question" ControlToCompare="ddlQuestion1"></asp:CompareValidator>--%>
        <%-- </select>--%>
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblAnswer2" runat="server" Text="<%$ Resources:TestSiteResources, Answer %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <asp:TextBox ID="txtAnswer2" runat="server" CssClass="input-pop" Width="88%" 
            autocomplete="off"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAnswer2" runat="server" ErrorMessage="*" ValidationGroup="Questiongrp"
            ControlToValidate="txtAnswer2"></asp:RequiredFieldValidator>
    </div>
    <div class="clear">
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblQuestion3" runat="server" Text="<%$ Resources:TestSiteResources, Questionthree %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <%--<select class="choose-answer">--%>
        <asp:DropDownList CssClass="choose-answer" ID="ddlQuestion3" runat="server" Width="95%">
        </asp:DropDownList>
    <%--    <asp:RequiredFieldValidator ID="rfvQuestion3" runat="server" ErrorMessage="*" InitialValue="0"
            ValidationGroup="Question" ControlToValidate="ddlQuestion3"></asp:RequiredFieldValidator>--%>
        <%-- </select>--%>
    </div>
    <div class="left-label fl">
        <asp:Label ID="lblAnswer3" runat="server" Text="<%$ Resources:TestSiteResources, Answer %>"></asp:Label>
    </div>
    <div class="right-label fl">
        <asp:TextBox ID="txtAnswer3" runat="server" CssClass="input-pop" Width="88%" 
            ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAnswer3" runat="server" ErrorMessage="*" ValidationGroup="Questiongrp"
            ControlToValidate="txtAnswer3"></asp:RequiredFieldValidator>
    </div>
    <div class="clear">
    </div>
   
    <div class="btn-pop">
        <div class="green-wrapper pop-btn">
            <asp:Button ID="btnSubmit" CssClass="green" runat="server" Text="<%$ Resources:TestSiteResources, Submit %>" OnClick="btnSubmit_Click"  ValidationGroup="Questiongrp"/>
        </div>
        <div class="green-wrapper pop-btn">
            <asp:Button ID="btnCancel" runat="server" CssClass="green" Text="<%$ Resources:TestSiteResources, Cancel %>" onclick="btnCancel_Click" 
                 />
        </div>
    </div>
     <div class="answer-title">
     <asp:Label ID="lblMeassage" runat="server" Visible="false"></asp:Label>
    </div>
</div>

<%-- <div class="popup-cyan">
		
		<div class="cyan-head">
			Set Your Security Question
		</div>
		<form class="styleThese">
		<div class="answer-title">
			Select a security question and enter your answer.
		</div>
		
		
		<div class="left-label fl">
			Question:
		</div>
		
		<div class="right-label fl">
			<select class="choose-answer">
				<option>What is your mother’s maiden name?</option>
			</select>
		</div>
		
		
		<div class="left-label fl">
			Answer:
		</div>
		
		<div class="right-label fl">
			<input type="text" class="input-pop" />
		</div>
		<div class="clear"></div>
		
		<div class="btn-pop">
			<div class="green-wrapper pop-btn">
				<input type="button" class="green" value="Submit" />
			</div>
			
			<div class="green-wrapper pop-btn">
				<input type="button" class="green" value="Cancel" />
			</div>
		</div>
		</form>
		
	</div>--%>