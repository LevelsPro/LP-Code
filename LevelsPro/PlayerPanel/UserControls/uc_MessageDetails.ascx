<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_MessageDetails.ascx.cs"
    Inherits="LevelsPro.PlayerPanel.UserControls.uc_MessageDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="box forums-popup">
    <div class="in-cont p-cont">
        <div class="manager-cont">
           <%-- <div class="scrollbar">
                <div class="track">
                    <div class="thumb">
                        <div class="end">
                        </div>
                    </div>
                </div>
            </div>--%>
            <div class="viewport read-msg">
                <div class="overview">
                    <asp:Image runat="server" class="msg-ico" ID="imgUser" />
                    <div class="msg-det">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:TestSiteResources, From %>"></asp:Label>
                        <asp:Label ID="lblFrom" runat="server"></asp:Label><br />
                         <asp:Label ID="Label2" runat="server" Text="<%$ Resources:TestSiteResources, Subject %>"></asp:Label>
                        <asp:Label ID="lblSubject" runat="server"></asp:Label><br />
                        <asp:Label ID="Label3" runat="server" Text="<%$ Resources:TestSiteResources, Date %>"></asp:Label> 
                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                        <p id="pdesc" runat="server">                           
                        </p>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="post-msg-cont">
                        <asp:TextBox ID="txtReply" TextMode="MultiLine" CssClass="input-style post-area pm"
                            runat="server" ForeColor="Black"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True"
                            TargetControlID="txtReply" WatermarkText="Your Answer">
                        </asp:TextBoxWatermarkExtender>                                                
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="green-wrapper fl mc-canse m10px">
    <asp:Button ID="btnBack" class="green" Text="<%$ Resources:TestSiteResources, Back %>" runat="server"
        OnClick="btnBack_Click" />
        </div>
        <div class="green-wrapper fl mc-canse m10px">
    <asp:Button ID="btnDelete" class="green" Text="<%$ Resources:TestSiteResources, Delete %>" 
        runat="server" onclick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this message?')"
        />
        </div>
          <div class="green-wrapper fr mc-canse m10px">
    <asp:Button ID="btnReply" class="green"  Text="<%$ Resources:TestSiteResources, Reply %>" runat="server"
        OnClick="btnReply_Click" />
        </div>
</div>
