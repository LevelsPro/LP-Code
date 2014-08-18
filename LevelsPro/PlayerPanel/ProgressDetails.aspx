<%@ Page Title="" Language="C#" MasterPageFile="~/PlayerPanel/Player.master" AutoEventWireup="true"
    CodeBehind="ProgressDetails.aspx.cs" Inherits="LevelsPro.PlayerPanel.ProgressDetails"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="ucViewProgressDetails" Src="~/PlayerPanel/UserControls/uc_ProgressDetails.ascx" %>
<%@ Register TagPrefix="uc" TagName="Map" Src="~/PlayerPanel/UserControls/uc_Map.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Progress Details</title>

    <script src="Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.tinyscrollbar.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $(window).resize(function () {

                var mpclm = $('.mapb').height();
                $(".pd-left-dt").height(mpclm - 32);
                console.log(mpclm);

            });
            $('#scrollbar1').tinyscrollbar();
            var faw = $('.filled-area').text();
            $('.filled-area').css("width", faw);


        });
		
	</script>
    <script src="Scripts/canvas-draw.js" type="text/javascript"></script>
    <link href="Styles/theme.css" rel="stylesheet" type="text/css" />
    <link href="Styles/website.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container"> 

    <div class="top-b">

        <div class="green-ar-wrapper fl">
            <asp:Button ID="btnHome" runat="server" Text="<%$ Resources:TestSiteResources, HomeAdmin %>"
                PostBackUrl="~/PlayerPanel/PlayerHome.aspx" CssClass="green-ar"></asp:Button>
        </div>

        <div class="user-nt">
            <asp:Label ID="lblName" runat="server"></asp:Label>
        </div>
        
        <div class="green-wrapper logout">
            <asp:Button ID="btnLogout" runat="server" Text="<%$ Resources:TestSiteResources, LogoutAdmin %>"
                CssClass="green" OnClick="btnLogout_Click"></asp:Button>
        </div>

        <div class="clear">
        </div>
    </div>

    <div class ="body-cont">

    <div class="sec-left">
       
        <div class="box pd-desc brd pd-left-dt">
            <span class="pr-det">

                <asp:Label ID="lblYou" runat="server" Text=" <%$ Resources:TestSiteResources, YouAreIn %>"></asp:Label>
                <asp:Label ID="lblLevelName" runat="server"></asp:Label>

            </span>
            
            <span class="pr-det">

                <asp:Label ID="Label1" runat="server" Text=" <%$ Resources:TestSiteResources, Reach %>"></asp:Label>
                <asp:Label ID="lblNextLevelName" runat="server"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=" <%$ Resources:TestSiteResources, AndEarnA %>"></asp:Label>
                <img src="images/star-orng.png" width="27" height="26" alt="Star" /><asp:Label ID="lblbonus"
                    runat="server"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" <%$ Resources:TestSiteResources, bonus %>"></asp:Label>

           </span>
            
            <span class="pr-det" style="display:none;">
                    <asp:Label ID="Label3" runat="server" Text=" <%$ Resources:TestSiteResources, TargetDate %>"></asp:Label><br />
                    <asp:Label ID="lblTargetDate" runat="server"></asp:Label><%--April 30th, 2013--%>
             </span>
                
             <span class="pr-space-cover"></span>
        </div>
    
    </div>


    <div class="sec-right mr10pxi">

        <div class="pd-mp">

          <div class="box-2 mapb mappad">
           
            <div class="map">
                    <canvas id="myCanvas"> </canvas>
                    <img  id="MapImage" runat="server"  class="my-map" width="925" />
                   
                    <uc:Map ID="ucMap" runat="server" />
                    <%--<div class="orange-cir" style="top: 30%; left: 13%;">
                                1</div>
                            <div class="orange-cir" style="top: 20%; left: 20%;">
                                2</div>
                            <div class="orange-cir" style="top: 30%; left: 30%;">
                                3</div>
                            <div class="pic-holder" style="top: 4%; left: 27%;">
                                <img src="images/avatar.png" />
                            </div>
                            <div class="blue-cir" style="top: 23%; left: 43%;">
                                4</div>
                            <div class="blue-cir" style="top: 18%; left: 53%;">
                                5</div>
                            <div class="blue-cir" style="top: 30%; left: 63%;">
                                6</div>
                            <div class="blue-cir" style="top: 45%; left: 70%;">
                                7</div>
                            <div class="blue-cir" style="top: 80%; left: 80%;">
                                8</div>--%>
                </div>
                
            <div class="fl-cont pd-flcont">
                
               <div class="filling">
                    <div class="filled-area">
                        <asp:Literal ID="lblPerformance" runat="server"></asp:Literal></div>
                </div>
                
               <div class="levels levels-home">
               <asp:Image ID="LevelStar" runat="server" width="86" height="82" AlternateText="No Image"  />
                   <%--<img src="Images/level-3.png" width="86" height="82" />--%>
                    <!--<asp:Label ID="lblLevel" runat="server"></asp:Label>-->
                </div>

                <div class="fl-right"></div>
                
                <div class="clear"></div>
            
            </div>
            
          </div>
            
           
        
        </div>

        <div class="clear"></div>

   </div>

        <div class="clear">
        </div>


    <div class="box brd mt10 m10px p10px brd-p">

        <asp:DataList ID="dlProgressDetail" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
            Width="100%" RepeatLayout="Table" OnItemDataBound="dlProgressDetail_ItemDataBound"
            OnItemCommand="dlProgressDetail_ItemCommand">

            <ItemTemplate>
               <asp:LinkButton ID="lbtnView" runat="server" CommandName="ViewPopup" CommandArgument='<%# Eval("Target_ID")%>' Font-Underline="false" ForeColor="Black">     
                <div class='<%# Convert.ToInt32(Eval("current_percentage")) == 100 ? "qgame-cont flset-change pdone" : "qgame-cont quiz-game" %>'>
                    <%--<asp:Label ID="lbltargetID" runat="server" Text='<%# Eval("Target_ID")%>' Visible="false"></asp:Label>--%>
                    
                    <div class="game-desc fl">
                        <%-- Score 100 points in the Quiz Game--%>
                        <asp:Label ID="lblKPIName" Text='<%# Eval("KPI_name")%>' runat="server"></asp:Label>
                        <asp:Label ID="lblTargetValue" Text='<%# Eval("Target_Value")%>' runat="server" Visible="false"></asp:Label>
                        <br />

                        <span>
                            <img src="images/star-orng.png" />
                            <%# Eval("Points")%></span>

                    </div>

                    <div class="dest-img-h fl" style="cursor: pointer;">
                                          
                                <div class="cont" style="width: <%# Convert.ToInt32(Eval("current_percentage")) > 100 ? 100 :Convert.ToInt32(Eval("current_percentage")) %>%;">
                                </div>
                        
                    </div>

                    <div class="percentager fr">
                        <asp:Label ID="cpercentage" Text='<%# Eval("current_percentage")%>' runat="server"></asp:Label>
                        <%-- <%# Eval("current_percentage")%>%--%>
                    </div>
                    
                    <div class="clear">
                    </div>
                </div>
                </asp:LinkButton>
            </ItemTemplate>   
            
           
            <AlternatingItemTemplate>
             <asp:LinkButton ID="lbtnView" runat="server" CommandName="ViewPopup" CommandArgument='<%# Eval("Target_ID")%>' Font-Underline="false" ForeColor="Black">
                <div class='<%# Convert.ToInt32(Eval("current_percentage")) == 100 ? "qgame-cont flset-change pdone" : "qgame-cont quiz-game" %>'>
                    <%--<asp:Label ID="lbltargetID" runat="server" Text='<%# Eval("Target_ID")%>' Visible="false"></asp:Label>--%>
                    <div class="game-desc fl">
                        <%-- Score 100 points in the Quiz Game--%>
                        <asp:Label ID="lblKPIName" Text='<%# Eval("KPI_name")%>' runat="server"></asp:Label>
                        <asp:Label ID="lblTargetValue" Text='<%# Eval("Target_Value")%>' runat="server" Visible="false"></asp:Label>
                        <br />
                        <span>
                            <img src="images/star-orng.png" />
                            <%# Eval("Points")%></span>
                    </div>
                    <div class="dest-img-h fl" style="cursor: pointer;">
                                               
                                <div class="cont" style="width: <%# Convert.ToInt32(Eval("current_percentage")) > 100 ? 100 :Convert.ToInt32(Eval("current_percentage")) %>%;">
                                </div>
                        
                    </div>
                    <div class="percentager fr">
                        <asp:Label ID="cpercentage" Text='<%# Eval("current_percentage")%>' runat="server"></asp:Label>
                        <%-- <%# Eval("current_percentage")%>%--%></div>
                    <div class="clear">
                    </div>
                </div>
                </asp:LinkButton>
            </AlternatingItemTemplate>
            
        </asp:DataList>
        
        
        <%--<div class="qgame-cont quiz-game">
		
			<div class="game-desc fl">Score 100 points in the Quiz Game
			<br />

			<span><img src="images/star-orng.png" />100</span>
			</div>
			
			<div class="dest-img-h fl">
				<div class="cont" style="width:42%;"></div>
			</div>
			
			
			<div class="percentager fl">42%</div>
			
			<div class="clear"></div>
			
		</div>
		
		
		
		<div class="qgame-cont transactions">
		
			<div class="game-desc fl">Complete 100 Transactions
			<br />

			<span><img src="images/star-orng.png" />100</span>
			</div>
			
			<div class="dest-img-h fl">
				<div class="cont" style="width:84%;"></div>
			</div>
			
			
			<div class="percentager fl">84%</div>
			
			<div class="clear"></div>
			
		</div>
		
		
		<div class="qgame-cont cc-app">
		
			<div class="game-desc fl">Process 20 Credit Card Applications
			<br />

			<span><img src="images/star-orng.png" />150</span>
			</div>
			
			<div class="dest-img-h fl">
				<div class="cont" style="width:30%;"></div>
			</div>
			
			
			<div class="percentager fl">30%</div>
			
			<div class="clear"></div>
			
		</div>
		
		<div class="qgame-cont flset-change">
		
			<div class="game-desc fl">Perform a Floor Set Change
			<br />

			<span><img src="images/star-orng.png" />50</span>
			</div>
			
			<div class="dest-img-h fl">
				<div class="cont" style="width:100%;"></div>
			</div>
			
			
			<div class="percentager fl"><img src="images/ok-qg.png" width="56" height="56" alt=" " /></div>
			
			<div class="clear"></div>
			
		</div>
		
		
		<div class="qgame-cont ctc-hours">
		
			<div class="game-desc fl">Complete Training Course Hours
			<br />

			<span><img src="images/star-orng.png" />100</span>
			</div>
			
			<div class="dest-img-h fl">
				<div class="cont" style="width:90%;"></div>
			</div>
			
			
			<div class="percentager fl">90%</div>
			
			<div class="clear"></div>
			
		</div>
        --%>


        <div class="challenge-btm">
            <asp:Label ID="lblClick" runat="server" Text="<%$ Resources:TestSiteResources, Click %>"></asp:Label></div>
        </div>

    <asp:Button ID="_editPopupButton" runat="server" Text="Edit Contact" Style="display: none" />
    <asp:ModalPopupExtender ID="mpeViewProgressDetailsDiv" runat="server" BackgroundCssClass="modalBackground"
        RepositionMode="None" TargetControlID="_editPopupButton" ClientIDMode="AutoID"
        PopupControlID="_ViewProgressDetailsDiv" OkControlID="_okPopupButton" CancelControlID="_cancelPopupButton"
        BehaviorID="EditModalPopupPost">
    </asp:ModalPopupExtender>
    <div class="_popupButtons" style="display: none">
        <input id="_okPopupButton" value="OK" type="button" />
        <input id="_cancelPopupButton" value="Cancel" type="button" />
    </div>
    <asp:UpdatePanel ID="upViewProgressDetails" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="_ViewProgressDetailsDiv" class="box pd-popup" style="display: none;">
                <uc:ucViewProgressDetails ID="ucViewProgressDetails" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    </div>

</div>

</asp:Content>
