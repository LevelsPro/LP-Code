﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_TipsTricks.ascx.cs" Inherits="LevelsPro.AdminPanel.UserControls.uc_TipsTricks" %>

<style type="text/css">
    .opt
    {
        float: none !important;
        width: 225px !important;
    }
    .post-area
    {
      /*  width: 463px !important;*/
    }
</style>




     <div class="in-cont p-cont">
     
                    <asp:Label ID="lblReferalText" Text="Referal Text " runat="server" class="tr-in fl"></asp:Label>
                    <span class="tr-in fl">
                        <asp:TextBox ID="txtReferal" runat="Server" class="opt" AutoCompleteType="Disabled" >
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvReferal" runat="server" ErrorMessage="*" ControlToValidate="txtReferal"
                            Font-Size="25px" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ValidationGroup="Compose"
                            ToolTip="Input Some Reference Text"></asp:RequiredFieldValidator>
                    </span>
                     <asp:Label ID="lblLink" Text="Referal Link " runat="server" class="tr-in fl"></asp:Label>
                    <span class="tr-in fl">
                        <asp:TextBox ID="txtLink" runat="Server" class="opt" AutoCompleteType="Disabled">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLink" runat="server" ErrorMessage="*" ControlToValidate="txtLink"
                            Font-Size="25px" ForeColor="Red" InitialValue="0" SetFocusOnError="true" ValidationGroup="Compose"
                            ToolTip="Input Some Reference Text"></asp:RequiredFieldValidator>
                    </span>
                
                <div class="clear">
                </div>
          
    </div>
    <div class="green-wrapper fl mc-canse m10px">
        <asp:Button ID="btnSend" runat="server" Text="Save" class="green" 
            onclick="btnSend_Click"></asp:Button>
    </div>
    <div class="green-wrapper fr mc-canse m10px">
        <asp:Button ID="btnCancel" runat="server" 
            Text="<%$ Resources:TestSiteResources, Cancel %>" class="green" 
            onclick="btnCancel_Click">
        </asp:Button>
    </div>
