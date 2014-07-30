<%@ Page Title="::Starting::" Language="C#"  AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="LevelsPro.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body onload="OpenActiveX()">
<script language="javascript" type="text/javascript">
    
    function OpenActiveX() {
    document.getElementById("bth").click();
    }	
    </script>
    <form id="form1" runat="server">
    <asp:Button ID="bth" runat="server" PostBackUrl="~/Login.aspx" Style="display: none">
        </asp:Button>
    </form>
</body>
</html>
