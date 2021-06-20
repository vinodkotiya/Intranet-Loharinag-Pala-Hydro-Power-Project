<%@ Page Language="VB"  AutoEventWireup="false" CodeFile="Chat.aspx.vb" Inherits="Chat" title="Chat Console" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="Style.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
    
  <script type="text/javascript" src="soundmanager.js">
</script>
    
</head>
<body id="MasterBody" runat="server" width="100%" >
    <form id="formChat" runat="server">
    <div>
    <div>
</div>
<script>
    soundManagerInit();
</script>
            
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Services>
                    <asp:ServiceReference Path="ChatService.asmx" />
                </Services>
        </asp:ToolkitScriptManager>

           
            <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>
            <asp:TextBox ID="hiddenSenderUserID" runat="server" style="display:none"></asp:TextBox>
            <asp:TextBox ID="TextBox1" runat="server" style="display:none"></asp:TextBox>
            <asp:TextBox ID="hiddenAppPath" runat="server" style="display:none"></asp:TextBox>
           

       <div id="ChatSection">
        <asp:TextBox ID="hiddenMyUserID" runat="server" style="display:none"></asp:TextBox>
         <asp:TextBox ID="hiddenMyUserName" runat="server" style="display:none"></asp:TextBox>
        <asp:TextBox ID="hiddenRecipientUserID" runat="server" style="display:none"></asp:TextBox>
         <asp:TextBox ID="hiddenRecipientUserName" runat="server" style="display:none"></asp:TextBox>
        <table id="MainTable" width ="180px">
            <tr>
                <td >
                    <asp:Panel ID="pnlChat" runat="server" BackColor="#E0E0E0" Height="160px" 
                        Width="100%" ScrollBars="Auto" BorderColor="#009933" BorderWidth="2px" 
                        CssClass="tchatbox">
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td >
                    <asp:TextBox ID="NewMessage" runat="server" MaxLength="500" Columns="68" 
                        CssClass="tchatbox" ValidationGroup="group1" Width="120px"></asp:TextBox>
                    <asp:Button ID="SendMessage" runat="server" Text="Send"
                                BackColor="#FFFBFF" BorderColor="#009933" BorderStyle="Solid" BorderWidth="2px" 
                                Font-Names="Verdana" ForeColor="#284775" CssClass="button" 
                        ValidationGroup="group1" Font-Size="Smaller" Width="47px" />
                </td>
            </tr>
        </table>
    </div>
    </div>
    </form>
</body>
</html>


    
    
