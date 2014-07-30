<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true" CodeBehind="ForumPostDetails.aspx.cs" Inherits="LevelsPro.PlayerPanel.ForumPostDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="Scripts/jquery.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="Scripts/jquery.tinyscrollbar.min.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $('#scrollbar1').tinyscrollbar();
	        var faw = $('.filled-area').text();
	        $('.filled-area').css("width", faw);
	        //	$('.filled-area').slideRight();


	    });
	</script>
	
	<link href="Styles/theme-2.css" rel="stylesheet" type="text/css" />
	<link href="Styles/website.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container-2">
		<div class="box top-b">
				
				<div class="green-btn btn fl">Home</div>
		
		<div class="user-nt fl">Jenny Johson - Contest</div>
		
		<div class="green-btn btn fr">Logout</div>
		
		<div class="clear"></div>
	
	</div>
	
	
	<div class="user-info">
		
		<div class="box avatar brd fl">
					<img src="images/jenny-avatar.png" />

		</div>
		
		<div class="box rbrd fl">
			<div class="star fl">
				Level 3
			</div>
			
			<div class="name-post fl">
				
				Jenny J.<br />
				Cashier
			</div>
			
			
			<div class="grey-btn pal fr">
						<span class="wc">You have:</span><br />
							<img src="images/star-small.png" />
						1, 203</div>
			
			<div class="clear"></div>
		</div>
		<div class="clear"></div>
	</div>
	
	
	<div class="box brd mt10">
		<div class="btn-nav">
				<div class="green-btn btn fl index-btn">Index</div>
				<div class="question-ind fl">
					Question 1 lorem ipsum lorem ipsum lorem ipsum
				</div>
				
		</div>
		
	
			
				
		<div class="in-cont" id="scrollbar1">
				
				<div class="scrollbar"><div class="track"><div class="thumb"><div class="end"></div></div></div></div>
		<div class="viewport forum-cont">
			 <div class="overview">
				
				<div class="f-item-cont">
					
					<div class="like-cont">5 Likes<br />
						<div class="green-btn like-btn">Like</div>
					</div>
				
				
					<img src="images/fr-img-1.png" width="94" height="94" class="fl" />
					
					<div class="fans-text fl">
						Terry G.<span> (5/1/2013 - 1:23:45pm)</span><br />
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
	
					</div>
				
				
					<div class="clear"></div>
				</div>
				
				<div class="f-item-cont">
					
					<div class="like-cont">5 Likes<br />
						<div class="green-btn like-btn">Like</div>
					</div>
				
				
					<img src="images/fr-img-2.png" width="94" height="94" class="fl" />
					
					<div class="fans-text fl">
						Jenny P.<span> (5/1/2013 - 1:28:45pm)</span><br />
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
	
					</div>
				
				
					<div class="clear"></div>
				</div>
				
				
				<div class="f-item-cont">
					
					<div class="like-cont">2 Likes<br />
						<div class="green-btn like-btn">Like</div>
					</div>
				
				
					<img src="images/fr-img-3.png" width="94" height="94" class="fl" />
					
					<div class="fans-text fl">
						Jack L.<span> (5/1/2013 - 1:38:45pm)</span><br />
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
						lorem ipsum lorem ipsum lorem ipsum
	
					</div>
				
				
					<div class="clear"></div>
				</div>
				
				
				
		</div>
		</div>
		
			
		</div>
		
		<div class="post-msg-cont">
				<textarea class="input-style post-area pm">Your Answer</textarea><br />
		
				<span class="msg-count fl">0/200</span>
				
				<div class="green-btn fr reply-msg">Reply</div>
				
				<div class="clear"></div>
				
		</div>
		
		
	</div>
	
	
</div>
</asp:Content>
