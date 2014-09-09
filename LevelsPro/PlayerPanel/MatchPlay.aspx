<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true" CodeBehind="MatchPlay.aspx.cs" Inherits="LevelsPro.PlayerPanel.MatchPlay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);
            callScript();
        });

        var interval;
        function abc() {
            var counter = 0;
            var startTime = new Date().getTime();
            var timeSec = parseInt($('#<%=lblTimeDataSet.ClientID%>').html());
            var score = parseInt($('#<%=ltScore.ClientID%>').html());
            var useHint = $('#<%=lblHint.ClientID%>').html();
            var notAllow = $('#<%=ltDone.ClientID%>');
            var deduction = 0;
            var sec = timeSec;
            //var scoreTemp = score / (timeSec - deduction);
            var scoreTemp = score / (timeSec);
            var values = 100 - (100 / timeSec);
            interval = setInterval(function () {
                counter = counter + 1;
                if (counter > deduction) {
                    score = score - scoreTemp;
                    sec -= 1;
                    values = values - (100 / timeSec);
                }
                $('#<%=ltScore.ClientID%>').html(Math.round(score).toString());
                $('#<%=progressBar.ClientID%>').css({ 'width': values + '%' });
                $('#<%=lblTimeDataSet.ClientID%>').html(sec.toString());

                if (new Date().getTime() - startTime >= (timeSec * 1000)) {
                    Stop(interval);
                    $('#<%=lblTimeDataSet.ClientID%>').html(0);
                    $('#<%=progressBar.ClientID%>').css({ 'width': '0%' });
                    $('#<%=ltScore.ClientID%>').html(0);
                    var currentRound = parseInt($('#<%=lblCurrentRound.ClientID%>').html());
                    var noRounds = parseInt($('#<%=lblNoOfRounds.ClientID%>').html());

                    CheckGeneralHint($('ul#sortable'));

                    $('ul .match-dataset-text').draggable("destroy");
                    $('ul li').droppable("destroy");
                    if (notAllow.length == 0) {
                        $('#<%=btnResults.ClientID %>').removeClass('noVisible');
                        $('#<%=btnTry.ClientID %>').removeClass('noVisible');
                        $('#<%=lblSorry.ClientID %>').removeClass('noVisible');
                    }
                    return;
                }
            }, 1000);
        }

        function Stop(interval) {
            clearInterval(interval);
        }

        function callScript() {

            $(function () {
                var droppableParent;
                var currentElement;
                var targetElement;
                var useHint = $('#<%=lblHint.ClientID%>').html();

                //Set current element as draggable
                $('ul .match-dataset-text').draggable({
                    revert: 'invalid',
                    axis: "y",
                    revertDuration: 200,
                    start: function () {
                        droppableParent = $(this).parent();

                        $(this).addClass('being-dragged');
                        currentElement = $(this);
                    },
                    stop: function () {
                        $(this).removeClass('being-dragged');
                    }
                });

                //Set droppable elements
                $('ul li').droppable({
                    hoverClass: 'drop-hover',
                    over: function (event, ui) {
                        var draggable = $(ui.draggable[0]),
                            draggableOffset = draggable.offset(),
                            container = $(event.target),
                            containerOffset = container.offset();

                        targetElement = container.children();
                    },
                    drop: function (event, ui) {
                        var draggable = $(ui.draggable[0]),
                            draggableOffset = draggable.offset(),
                            container = $(event.target),
                            containerOffset = container.offset();

                        var currentClass = currentElement.attr('datarel');
                        var targetClass = targetElement.attr('datarel');

                        if (currentClass == targetClass) {
                            $('.match-dataset-text', event.target).appendTo(droppableParent).css({
                                opacity: 0
                            }).animate({
                                opacity: 1
                            }, 200);

                            draggable.appendTo(container).css({
                                left: draggableOffset.left - containerOffset.left,
                                top: draggableOffset.top - containerOffset.top
                            }).animate({
                                left: 0,
                                top: 0
                            }, 200);
                            
                            if (useHint == 'true') {
                                CheckSelection($(event.target));
                            }

                            CheckGeneral($(event.target).parent());

                        } else {
                            draggable.animate({
                                left: 0,
                                top: 0
                            }, 200);
                        }
                    }
                });
            } ());
            setTimeout(function () { abc() }, 1000);
        }

        function isPair(value) {
            if (value % 2 === 0) return true;
            else return false;
        }

        function isEvenOdd(value) {
            return value % 3;
        }

        function CheckGeneralHint(target) {
            var noDataElements = $('#<%=lblNoDataElements.ClientID%>').html();
            var toReturn = false;

            target.children().each(function (index) {
                var dataindex = index;

                switch (noDataElements) {
                    case '2':
                        var datapos = Math.round(dataindex / 1) + 1;
                        var dataimg = $("ul.image-list li:eq( " + (datapos - 1) + " ) img");
                        break;
                    case '3':
                        var datapos = isPair(dataindex) ? Math.round(dataindex / 2) + 1 : Math.round(dataindex / 2);
                        var dataimg = $("ul.image-list li:eq( " + (datapos - 1) + " ) img");
                        break;
                    case '4':
                        var datamod = (dataindex % 3);
                        var datapos = (dataindex - datamod) / 3;
                        var dataimg = $("ul.image-list li:eq( " + datapos + " ) img");
                        break;
                }

                var dataimgtext = dataimg.attr('datarel');

                var txt1 = '';
                var txt2 = '';

                switch (noDataElements) {
                    case '2':
                        txt1 = dataimgtext.split('|')[0];
                        txt2 = $(this).text().trim();
                        break;
                    case '3':
                        if (isPair(dataindex)) {
                            txt1 = dataimgtext.split('|')[1];
                            txt2 = $(this).text().trim();
                        }
                        else {
                            txt1 = dataimgtext.split('|')[0];
                            txt2 = $(this).text().trim();
                        }
                        break;
                    case '4':
                        var modRes = isEvenOdd(dataindex);
                        switch (modRes) {
                            case 0:
                                txt1 = dataimgtext.split('|')[2];
                                txt2 = $(this).text().trim();
                                break;
                            case 1:
                                txt1 = dataimgtext.split('|')[1];
                                txt2 = $(this).text().trim();
                                break;
                            case 2:
                                txt1 = dataimgtext.split('|')[0];
                                txt2 = $(this).text().trim();
                                break;
                        }
                        break;
                }

                if (txt1 == txt2) {
                    toReturn = true;
                }
                else {
                    toReturn = false;
                }

                if (toReturn == true) {
                    $(this).children().removeClass('disabled').removeClass('disabled-blue').removeClass('disabled-white').removeClass('wrong-no').addClass('correct-no');
                }
                else {
                    $(this).children().removeClass('disabled').removeClass('disabled-blue').removeClass('disabled-white').removeClass('correct-no').addClass('wrong-no');
                }
            });            
        }

        function CheckGeneral(target) {
            var noDataElements = $('#<%=lblNoDataElements.ClientID%>').html();
            var toReturn = false;

            target.children().each(function (index) {
                var dataindex = index;

                switch (noDataElements) {
                    case '2':
                        var datapos = Math.round(dataindex / 1) + 1;
                        var dataimg = $("ul.image-list li:eq( " + (datapos - 1) + " ) img");
                        break;
                    case '3':
                        var datapos = isPair(dataindex) ? Math.round(dataindex / 2) + 1 : Math.round(dataindex / 2);
                        var dataimg = $("ul.image-list li:eq( " + (datapos - 1) + " ) img");
                        break;
                    case '4':
                        var datamod = (dataindex % 3);
                        var datapos = (dataindex - datamod) / 3;
                        var dataimg = $("ul.image-list li:eq( " + datapos + " ) img");
                        break;
                }

                var dataimgtext = dataimg.attr('datarel');

                var txt1 = '';
                var txt2 = '';

                switch (noDataElements) {
                    case '2':
                        txt1 = dataimgtext.split('|')[0];
                        txt2 = $(this).text().trim();
                        break;
                    case '3':
                        if (isPair(dataindex)) {
                            txt1 = dataimgtext.split('|')[1];
                            txt2 = $(this).text().trim();
                        }
                        else {
                            txt1 = dataimgtext.split('|')[0];
                            txt2 = $(this).text().trim();
                        }
                        break;
                    case '4':
                        switch (isEvenOdd(dataindex)) {
                            case 0:
                                txt1 = dataimgtext.split('|')[2];
                                txt2 = $(this).text().trim();
                                break;
                            case 1:
                                txt1 = dataimgtext.split('|')[1];
                                txt2 = $(this).text().trim();
                                break;
                            case 2:
                                txt1 = dataimgtext.split('|')[0];
                                txt2 = $(this).text().trim();
                                break;
                        }
                        break;
                }

                if (txt1 == txt2) {
                    toReturn = true;
                }
                else {
                    toReturn = false;
                }

                if (toReturn == true) {
                    $(this).children().removeClass('wrongSelect').addClass('correctSelect');
                }
                else {
                    $(this).children().removeClass('correctSelect').addClass('wrongSelect');
                }
            });

            var count = target.children().length;

            var correctCount = target.children().children('.correctSelect').length;
            console.log(correctCount);
            if (count == correctCount) {
                Stop(interval);
                var currentRound = parseInt($('#<%=lblCurrentRound.ClientID%>').html());
                var noRounds = parseInt($('#<%=lblNoOfRounds.ClientID%>').html());

                CheckGeneralHint(target);

                if (currentRound < noRounds) {
                    UpdateScore($('#<%=ltScore.ClientID%>').html());
                    $('#<%=btnNext.ClientID %>').removeClass('noVisible');
                    $('#<%=lblMessageCongratsRound.ClientID %>').removeClass('noVisible');
                }
                else {
                    UpdateScore($('#<%=ltScore.ClientID%>').html());
                    $('#<%=btnCnfrm.ClientID %>').removeClass('noVisible');
                    $('#<%=lblMessageCongratsGame.ClientID %>').removeClass('noVisible');

                    var points = parseInt($('#<%=lblPoints.ClientID %>').html()) + parseInt($('#<%=ltScore.ClientID%>').html()) + parseInt($('#<%=lblPointsForCompletation.ClientID%>').html());
                    var pointsText = $('#<%=lblMessagePoints.ClientID %>').html().replace('POINTCOUNT', points);
                    $('#<%=lblMessagePoints.ClientID %>').html(pointsText);
                    $('#<%=lblMessagePoints.ClientID %>').removeClass('noVisible');
                }
            }
        }

        function CheckSelection(target) {
            var noDataElements = $('#<%=lblNoDataElements.ClientID%>').html();
            var toReturn = false;

            var dataindex = target.index();

            switch (noDataElements) {
                case '2':
                    var datapos = Math.round(dataindex / 1) + 1;
                    var dataimg = $("ul.image-list li:eq( " + (datapos - 1) + " ) img");
                    break;
                case '3':
                    var datapos = isPair(dataindex) ? Math.round(dataindex / 2) + 1 : Math.round(dataindex / 2);
                    var dataimg = $("ul.image-list li:eq( " + (datapos - 1) + " ) img");
                    break;
                case '4':
                    var datamod = (dataindex % 3);
                    var datapos = (dataindex - datamod) / 3;
                    var dataimg = $("ul.image-list li:eq( " + datapos + " ) img");
                    break;
            }
            
            var dataimgtext = dataimg.attr('datarel');
            
            var txt1 = '';
            var txt2 = '';

            switch (noDataElements) {
                case '2':
                    txt1 = dataimgtext.split('|')[0];
                    txt2 = target.children().text().trim();
                    break;
                case '3':
                    if (isPair(dataindex)) {
                        txt1 = dataimgtext.split('|')[1];
                        txt2 = target.children().text().trim();
                    }
                    else {
                        txt1 = dataimgtext.split('|')[0];
                        txt2 = target.children().text().trim();
                    }
                    break;
                case '4':
                    switch (isEvenOdd(dataindex)) {
                        case 0:
                            txt1 = dataimgtext.split('|')[2];
                            txt2 = target.children().text().trim();
                            break;
                        case 1:
                            txt1 = dataimgtext.split('|')[1];
                            txt2 = target.children().text().trim();
                            break;
                        case 2:
                            txt1 = dataimgtext.split('|')[0];
                            txt2 = target.children().text().trim();
                            break;
                    }
                    break;
            }
            if (txt1 == txt2) {
                target.children().removeClass('disabled').removeClass('disabled-blue').removeClass('disabled-white').removeClass('wrong-no').addClass('correct-no');
            }
        }

        function UpdateScore(score) {
            PageMethods.set_path("MatchPlay.aspx")
            PageMethods.UpdateScore(score);

        }

    </script>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tbl-processing
        {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.50;
        }
        .updateProgress
        {
            color: #FFFFFF;
            font-family: Trebuchet MS;
            font-size: small;
            margin: auto;
            opacity: 1;
            position: fixed;
            left: 50%;
            top: 50%;
            vertical-align: middle;
            margin-left: -150px;
            margin-top: -100px;
            z-index: 7;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="top-b">
            <div class="green-ar-wrapper fl">
                <asp:Button ID="btnHome" runat="server" CssClass="green-ar" Text="<%$ Resources:TestSiteResources, Quit %>" OnClick="btnHome_Click" />
            </div>
            <div class="user-nt">
                <asp:Literal ID="ltlName" runat="server"></asp:Literal></div>
            <div class="green-wrapper logout">
                <asp:Button ID="btnLogout" runat="server" CssClass="green" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" OnClick="btnLogout_Click" />
            </div>
            <div class="clear">
            </div>
        </div>        
        <div class="qbody">
            <asp:UpdatePanel ID="upMatch" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="lblMainMatchTime" runat="server" Text="Label" Visible="False"></asp:Label>
                    <div class="match-datasets">
                        <div class="tophead">
                            <asp:Literal ID="ltlDataSetNumber" runat="server"></asp:Literal>
                        </div>
                        <div class="datasetContainer">
                            <div class="dataelementContainer">
                                <div class="image-container <%=cssClassW34 %>">
                                    <asp:ListView ID="lvDataElementImage" runat="server" ItemPlaceholderID="itemImageContainer">
                                        <LayoutTemplate>
                                            <ul class="image-list fl">
                                                <asp:PlaceHolder ID="itemImageContainer" runat="server" />
                                            </ul>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <li>
                                                <asp:Image ID="imgDataSet" dataid='<%# Eval("DataSetID")%>' datarel='<%# Eval("DataSetElementsData").ToString().Trim()%>' ImageUrl='<%# Eval("DataSetImageThumbnail").ToString().Trim() != "" ?  "../" + ConfigurationSettings.AppSettings["DataSetThumbPath"].ToString() + Eval("DataSetImageThumbnail") :"Images/placeholder.png" %>' Width="73" Height="72" CssClass="fl" runat="server" />
                                            </li>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <div>
                                                No Images to Display
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                </div>
                                <div class="elements-container <%=cssClassW34 %>">
                                    <asp:Literal ID="litWriteCode" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="congratsText">
                                <asp:Label ID="lblMessageCongratsRound" runat="server" CssClass="noVisible" Text="<%$ Resources:TestSiteResources, CongratulationsRound %>"></asp:Label>
                                <asp:Label ID="lblMessageCongratsGame" runat="server" CssClass="noVisible" Text="<%$ Resources:TestSiteResources, CongratulationsGame %>"></asp:Label>
                                <asp:Label ID="lblMessagePoints" runat="server" CssClass="noVisible" Text="<%$ Resources:TestSiteResources, PointsScored %>"></asp:Label>
                                <asp:Label ID="lblSorry" runat="server" CssClass="noVisible" Text="<%$ Resources:TestSiteResources, OutOfTime %>"></asp:Label>
                                <asp:Label ID="ltDone" runat="server" Text="<%$ Resources:TestSiteResources, youAlreadyPlayedMatch %>" Visible="false" />
                            </div>
                            <div>
                                <asp:Button ID="btnNext" runat="server" CssClass="btn-done noVisible" onclick="btnNext_Click" Text="<%$ Resources:TestSiteResources, NextRound %>" />
                                <asp:Button ID="btnCnfrm" runat="server"  CssClass="btn-done noVisible"  OnClick="btnCnfrm_Click" Text="<%$ Resources:TestSiteResources, Continue %>" />
                                <asp:Button ID="btnResults" runat="server"  CssClass="btn-done noVisible"  OnClick="btnResults_Click" Text="<%$ Resources:TestSiteResources, ViewCorrectAnswers %>" />
                                <asp:Button ID="btnTry" runat="server"  CssClass="btn-done noVisible"  OnClick="btnTry_Click" Text="<%$ Resources:TestSiteResources, TryAgain %>" />
                            </div>
                        </div>
                        <div class="bottom-container">
                            <div class="slide-cont">
                                <div class="slider">
                                    <div class="knob">
                                        <asp:Label ID="lblTimeDataSet" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <div id="progressBar" runat="server" class="filled">
                                        <asp:HiddenField ID="hdDeductionTime" runat="server" />
                                    </div>
                                </div>
                                <div class="my-points">
                                    <asp:Label ID="ltScore" runat="server" Text="0"></asp:Label>&nbsp;<asp:Literal ID="ltP" runat="server" Text="<%$ Resources:TestSiteResources, Points %>" Visible="true"></asp:Literal>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <asp:Label ID="lblCurrentRound" runat="server" Text="0" CssClass="noVisible" />
                    <asp:Label ID="lblNoOfRounds" runat="server" Text="0" CssClass="noVisible" />
                    <asp:Label ID="lblPoints" runat="server" Text="0" CssClass="noVisible" />
                    <asp:Label ID="lblPointsForCompletation" runat="server" Text="0" CssClass="noVisible" />
                    <asp:Label ID="lblHint" runat="server" Text="0" CssClass="noVisible" />
                    <asp:Label ID="lblNoDataElements" runat="server" Text="0" CssClass="noVisible" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdateProgress ID="uprogressHome" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="upMatch">
        <ProgressTemplate>
            <div style="background-color: Teal; filter: alpha(opacity=80); opacity: 0.80; width: 100%;
                top: 0px; left: 0px; position: fixed; height: 100%; z-index: 7;">
            </div>
            <div class="updateProgress">
                <table width="100%">
                    <tr>
                        <td style="width: 30%">
                            <img src="../Images/loading-small.gif" alt="wait" />
                        </td>
                        <td style="width: 70%" align="left">
                            <span style="font-size: medium; font-weight: bold; color: #FFFFFF">
                                <asp:Literal ID="ltProcessing" runat="server" Text="<%$ Resources:TestSiteResources, Processing %>"></asp:Literal></span>
                        </td>
                    </tr>
                </table>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
