<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true" CodeBehind="QuizResult.aspx.cs" Inherits="LevelsPro.PlayerPanel.QuizResult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
       (function (i, s, o, g, r, a, m) {
           i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
               (i[r].q = i[r].q || []).push(arguments)
           }, i[r].l = 1 * new Date(); a = s.createElement(o),
        m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
       })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

       ga('create', 'UA-57350527-1', 'auto');
       ga('send', 'pageview');

    </script>
    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#scrollbar1').tinyscrollbar();
            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);
        });
    </script>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
<div class="container-2">
		<div class="top-b">
	
		 <div class="green-ar-wrapper fl">
                <asp:Button ID="btnHome" runat="server" CssClass="green-ar" Text="<%$ Resources:TestSiteResources, HomeAdmin %>" OnClick="btnHome_Click" />
            </div>
            <div class="user-nt">
                <asp:Literal ID="ltlName" runat="server"></asp:Literal></div>
            <div class="green-wrapper logout">
                <asp:Button ID="btnLogout" runat="server" CssClass="green" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>" OnClick="btnLogout_Click" />
            </div>
            <div class="clear">
            </div>
	
	</div>
	
  
<div class="body-cont">	

	<div class="quiz-selection">
		<div class="tophead">  <asp:Label ID="lblResult" runat="server" Text="<%$ Resources:TestSiteResources, YourResults %>"></asp:Label> </div>
		
		
		<div class="qs-cont" id="scrollbar1">
				
				<div class="scrollbar"><div class="track"><div class="thumb"><div class="end"></div></div></div></div>
		<div class="viewport msgs2">
			 <div class="overview">
				
				                          <asp:DataList ID="dlResult" runat="server" RepeatDirection="Vertical" 
                                              Width="100%" onitemdatabound="dlResult_ItemDataBound" >
                                                <ItemTemplate>
                                                <asp:Label ID="lblCorrect" Text='<%# Eval("IsCorrect")%>' runat="server" Visible="false"></asp:Label>
                                                    <div class="qr-item qr-green" runat="server" id="clstrip">
                                                    <div class="qr-desc">
                                                       <asp:Label ID="lblQuestion" runat="server"  Text='<%# Eval("ShortQuestion")%>'></asp:Label></div>
                                                       <div class="qr-points">
                                                       <asp:Label ID="lblPoints" runat="server"  Text='<%# Eval("PointsAchieved")%>'></asp:Label>
                                                       </div>
                                                     <div class="clear"></div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:DataList>		
		</div>
		</div>
		
			
		</div>
		
	</div>
	
	
	<div class="points-black"> <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, YouScored %>"></asp:Label>&nbsp;<asp:Label ID="lblTotal" runat="server"></asp:Label>&nbsp;<asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, Points1 %>"></asp:Label></div>
	<div class="green-wrapper fr done-btn">
    <asp:Button ID="btnDone" Text="<%$ Resources:TestSiteResources, Done %>" runat="server" class="green" 
            onclick="btnDone_Click" />
	</div>
	
	<div class="clear"></div>
	
	</div>	
	
	
</div>


</asp:Content>
