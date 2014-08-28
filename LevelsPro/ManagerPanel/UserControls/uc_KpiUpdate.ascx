<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_KpiUpdate.ascx.cs" Inherits="LevelsPro.ManagerPanel.UserControls.uc_KpiUpdate" %>
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
     
                    <asp:Label ID="lblKPIText" Text="KPI Text " runat="server" class="tr-in fl"></asp:Label>
                    <span class="tr-in fl">
                        <asp:TextBox ID="txtKPI" runat="Server" class="opt" AutoCompleteType="Disabled" > </asp:TextBox>
                    </span>
                <div class="clear">
                </div>
          
    </div>
    <div class="green-wrapper fl mc-canse m10px">
        <asp:Button ID="btnSend" runat="server" Text="Update" class="green" onclick="btnSend_Click" 
            ></asp:Button>
    </div>
    <div class="green-wrapper fr mc-canse m10px">
        <asp:Button ID="btnCancel" runat="server" 
            Text="<%$ Resources:TestSiteResources, Cancel %>" class="green" onclick="btnCancel_Click" 
           >
        </asp:Button>
    </div>