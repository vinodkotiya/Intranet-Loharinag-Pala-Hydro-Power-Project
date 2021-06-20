Imports System.Data
Imports System.Data.SqlClient
Imports filter

Partial Class Chat
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'taken from master
        If Not Page.IsPostBack Then
            hiddenMyUserName.Text = getIPName(Session("myIP"))
            hiddenRecipientUserName.Text = getIPName(Request.Params("Usr"))
            ' also delete all unhandeled entries from IMChats only once
            executeQuerydb2("delete from IMChats where senderuserid = '" + Session("myIP") + "'")
        End If
        'lblName.Text = hiddenMyUserName.Text + " is chating with " + hiddenRecipientUserName.Text
        ' lblUpdate.Text = "<br/> Note: <b>" + hiddenMyUserName.Text + "</b> if you think your name is misspelt or not visible then let us correct it.<br/> Please enter your correct name in textbox below and click on update"
        'If Not String.IsNullOrEmpty(Session("myIP")) Then '  If Not String.IsNullOrEmpty(Page.User.Identity.Name) Then
        '    hiddenAppPath.Text = Request.ServerVariables("SERVER_NAME") & ":" & Request.ServerVariables("SERVER_PORT") & Request.ApplicationPath()

        '    Dim csname As String = "CheckChatReq"
        '    Dim cstype As Type = Me.GetType()
        '    Dim cs As ClientScriptManager = Page.ClientScript
        '    If (Not cs.IsClientScriptBlockRegistered(cstype, csname)) Then
        '        Dim cstext As New StringBuilder()
        '        cstext.Append("var DelayInSeconds = 12;" & vbCrLf)
        '        cstext.Append("function InitCheckChatReq(strMyUserID) {" & vbCrLf)
        '        cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append("function CheckChatReq(strMyUserID) {" & vbCrLf)
        '        cstext.Append("    ret = ChatService.CheckChatReq(strMyUserID, CheckChatReqOnComplete, CheckChatReqOnTimeout);" & vbCrLf)
        '        cstext.Append("    document.getElementById('" & hiddenMyUserID.ClientID & "').value = strMyUserID;" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append("function CheckChatReqOnComplete(strSenderUserID) {" & vbCrLf)
        '        cstext.Append("    if (strSenderUserID != """")" & vbCrLf)
        '        cstext.Append("    {" & vbCrLf)
        '        cstext.Append("        var popupWindow = null;" & vbCrLf)
        '        cstext.Append("        document.getElementById('" & hiddenSenderUserID.ClientID & "').value = strSenderUserID;" & vbCrLf)
        '        cstext.Append("  //      document.getElementById('ChatRequest').innerHTML = ""<br/><br/><p style=\""text-align: center;\"">""" & vbCrLf)
        '        cstext.Append("  //          + "" <font color=yellow face=arial> You have an incoming chat request from: '"" + strSenderUserID + ""'<br/><br/>""" & vbCrLf)
        '        cstext.Append("   //         + ""Would you like to accept?</p>"";" & vbCrLf)
        '        cstext.Append("   //     var modalPopupBehavior = $find('programmaticModalPopupBehaviorChatReq');" & vbCrLf)
        '        cstext.Append("    //    modalPopupBehavior.show();" & vbCrLf)
        '        cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
        '        cstext.Append(" //  var w = window.open();" & vbCrLf)
        '        cstext.Append(" //  w.opener = null;" & vbCrLf)
        '        cstext.Append("  // w.document.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
        '        cstext.Append("   // popupWindow = window.open('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
        '        cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
        '        cstext.Append("    }" & vbCrLf)
        '        cstext.Append("     else" & vbCrLf)
        '        cstext.Append("    {" & vbCrLf)
        '        cstext.Append("        var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("        setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
        '        cstext.Append("    }" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append("function CheckChatReqOnTimeout(strSenderUserID) {" & vbCrLf)
        '        cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append("function OnOk() {" & vbCrLf)
        '        cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("   var w = window.open();" & vbCrLf)
        '        cstext.Append("   w.opener = null;" & vbCrLf)
        '        cstext.Append("   w.document.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
        '        cstext.Append(" //   popupWindow = window.open('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
        '        cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append("function OnCancel() {" & vbCrLf)
        '        cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    ret = ChatService.SendNak(strMyUserID, strSenderUserID);" & vbCrLf)
        '        cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cs.RegisterClientScriptBlock(cstype, csname, cstext.ToString, True)
        '    End If

        '    ' Dim strScript As String = "InitCheckChatReq('" & HttpUtility.UrlEncode(Page.User.Identity.Name) & "');"
        '    Dim strScript As String = "InitCheckChatReq('" & Session("myIP") & "');"
        '    csname = "InitCheckChatReq"
        '    cs = Page.ClientScript
        '    If (Not cs.IsStartupScriptRegistered(cstype, csname)) Then
        '        cs.RegisterStartupScript(cstype, csname, strScript, True)
        '    End If

        'End If

        ' its own

        If Not String.IsNullOrEmpty(Session("myIP")) Then '  If Not String.IsNullOrEmpty(User.Identity.Name) Then

            '    StatusLabel.Text = "Establishing connection..."

            Dim str = HttpUtility.UrlEncode(User.Identity.Name) & " " & Request.QueryString("Usr")

            Dim BodyTag As New HtmlGenericControl
            BodyTag = FindControl("MasterBody")
            'BodyTag.Attributes.Add("OnUnLoad", "Javascript:ChatCleanUp();")
            Dim FormTag As HtmlForm
            FormTag = FindControl("formChat")
            FormTag.Attributes.Add("OnSubmit", "Javascript:return blockSubmit();")

            Page.Form.DefaultButton = SendMessage.UniqueID
            SendMessage.OnClientClick = "javascript:SendMessageOnClick();"

            Dim csname As String = "Chat"
            Dim cstype As Type = Me.GetType()
            Dim cs As ClientScriptManager = Page.ClientScript
            If (Not cs.IsClientScriptBlockRegistered(cstype, csname)) Then
                Dim cstext As New StringBuilder()
                cstext.Append("var DelayInMilliSeconds = 400;" & vbCrLf)
                cstext.Append("var WaitForConnectionLoop = 200; // * DelayInMilliSeconds" & vbCrLf)
                cstext.Append("var iWaitForConnectionLoop = 0;" & vbCrLf)
                cstext.Append("var WaitForHandshake = 40; // * DelayInMilliSeconds" & vbCrLf)
                cstext.Append("var iWaitForHandshake = 0;" & vbCrLf)
                cstext.Append("//window.onbeforeunload = PreventClose;" & vbCrLf)
                cstext.Append("window.onunload = ChatCleanUp;" & vbCrLf)
                cstext.Append(" //function PreventClose()" & vbCrLf)
                cstext.Append("// {" & vbCrLf)
                cstext.Append("  //   event.returnValue = ""If you do so, you will be signed out of the instant messenger."";" & vbCrLf)
                cstext.Append("//}" & vbCrLf)
                cstext.Append("function blockSubmit()" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("	SendMessageOnClick();" & vbCrLf)
                cstext.Append("	return false;" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function GetMessages()" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strRecipientUserID = document.getElementById('" & hiddenRecipientUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    ChatService.GetMessages(strMyUserID, strRecipientUserID, GetMessagesOnComplete, OnTimeOut);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function GetMessagesOnComplete(data)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strRecipientUserID = document.getElementById('" & hiddenRecipientUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    if (data != '')" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        if (data.substring(0,25) == ""~::::=[(HANDSHAKE)]=::::~"")" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("             if (data == ""~::::=[(HANDSHAKE)]=::::~[EOT]"")" & vbCrLf)
                cstext.Append("             {" & vbCrLf)
                cstext.Append("                   $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'User: ' + strRecipientUserID + ' Left Chat!';" & vbCrLf)
                cstext.Append("             }" & vbCrLf)
                cstext.Append("             else" & vbCrLf)
                cstext.Append("             {" & vbCrLf)
                cstext.Append("                   $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  document.getElementById('" & hiddenRecipientUserName.ClientID & "').value + ' Has quit the chat!';" & vbCrLf)
                cstext.Append("             }" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("            else" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("            $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/> <font color=magenta>"" + document.getElementById('" & hiddenRecipientUserName.ClientID & "').value  + "" says: <b> "" + ""<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"" + data + "" </b></font> ""; " & vbCrLf)
                cstext.Append("            document.getElementById('" & pnlChat.ClientID & "').scrollTop = document.getElementById('" & pnlChat.ClientID & "').scrollHeight;" & vbCrLf)
                cstext.Append("            setTimeout('GetMessages()', DelayInMilliSeconds);" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("        else" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        setTimeout('GetMessages()', DelayInMilliSeconds);" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function SendMessageOnClick()" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    document.getElementById('" & SendMessage.ClientID & "').disabled = true;" & vbCrLf)
                cstext.Append("    if (document.getElementById('" & NewMessage.ClientID & "').value != '')" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        var strMyUserID =  document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("        var strRecipientUserID = document.getElementById('" & hiddenRecipientUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("        $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" + document.getElementById('" & hiddenMyUserName.ClientID & "').value  + "" says: <b>"" + ""<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"" + document.getElementById('" & NewMessage.ClientID & "').value + ""</b> ""  ;" & vbCrLf)
                cstext.Append("        ChatService.SendMessage(strMyUserID, strRecipientUserID, document.getElementById('" & NewMessage.ClientID & "').value);" & vbCrLf)
                cstext.Append("        document.getElementById('" & pnlChat.ClientID & "').scrollTop = document.getElementById('" & pnlChat.ClientID & "').scrollHeight;" & vbCrLf)
                cstext.Append("        document.getElementById('" & NewMessage.ClientID & "').value = '';" & vbCrLf)
                cstext.Append("        document.getElementById('" & NewMessage.ClientID & "').focus();" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("    document.getElementById('" & SendMessage.ClientID & "').disabled = false;" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function InitChat(strMyUserID, strRecipientUserID, strInit)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    if (strMyUserID != strRecipientUserID)" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        document.getElementById('" & NewMessage.ClientID & "').focus();" & vbCrLf)
                cstext.Append("        document.getElementById('" & hiddenMyUserID.ClientID & "').value = strMyUserID;" & vbCrLf)
                cstext.Append("        document.getElementById('" & hiddenRecipientUserID.ClientID & "').value = strRecipientUserID;" & vbCrLf)
                cstext.Append("        if (strInit == ""1"") // Sender sends ENQ and waits for ACK" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("              $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'Establishing Connection... Sending Chat Request Please Wait for 30 Seconds';" & vbCrLf)
                cstext.Append("            ChatService.SendChatReq(strMyUserID, strRecipientUserID);" & vbCrLf)
                cstext.Append("            setTimeout(""WaitForAck('"" + strMyUserID + ""', '""+ strRecipientUserID + ""')"", DelayInMilliSeconds);" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("        else // Recipient ACK's ENQ and waits for ACK ACK back" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("              $get('" & pnlChat.ClientID & "').innerHTML = 'Establishing Connection... Acknowledging Chat Request. Please Wait for 30 Seconds';" & vbCrLf)
                cstext.Append("            ChatService.SendAck(strMyUserID, strRecipientUserID);" & vbCrLf)
                cstext.Append("            setTimeout(""WaitForAckAck('"" + strMyUserID + ""', '""+ strRecipientUserID + ""')"", DelayInMilliSeconds);" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("        else" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("          $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'Error: You can not chat with yourself.';" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function WaitForAck(strMyUserID, strRecipientUserID)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    iWaitForConnectionLoop++" & vbCrLf)
                cstext.Append("      $get('" & pnlChat.ClientID & "').innerHTML =   'Establishing Connection... Waiting For Acknowledgment. Please Wait for 30 Seconds';" & vbCrLf)
                cstext.Append("    ret = ChatService.GetAck(strMyUserID, strRecipientUserID, WaitForAckOnComplete, OnTimeOut);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function WaitForAckOnComplete(blnReturn)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strRecipientUserID = document.getElementById('" & hiddenRecipientUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    if (blnReturn == true) // Sender gets ACK and sends ACK back and waits 4 EOT" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("          $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'Establishing Connection... Sending Acknowledgment. Please Wait';" & vbCrLf)
                cstext.Append("        ChatService.SendAck(strMyUserID, strRecipientUserID);" & vbCrLf)
                cstext.Append("        setTimeout(""WaitForEot('"" + strMyUserID + ""', '"" +strRecipientUserID +""')"", DelayInMilliSeconds);" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("            else" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        ret = ChatService.GetNak(strMyUserID, strRecipientUserID, GetNakOnComplete, OnTimeOut);" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function GetNakOnComplete(blnReturn)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strRecipientUserID = document.getElementById('" & hiddenRecipientUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    if (blnReturn == true) // Sender got NAK or waits 4 ACK" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("          $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'User: ' + strRecipientUserID + ' do not want to chat with you right now..';" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("            else" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        if (iWaitForConnectionLoop == WaitForConnectionLoop)" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("              $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'Error: Chat Request Timed Out! May be person is out of desk.';" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("            else" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("            setTimeout(""WaitForAck('"" + strMyUserID + ""', '""+ strRecipientUserID + ""')"", DelayInMilliSeconds);" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function WaitForAckAck(strMyUserID, strRecipientUserID)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    iWaitForConnectionLoop++" & vbCrLf)
                cstext.Append("      $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'Establishing Connection... Waiting For Acknowledgment';" & vbCrLf)
                cstext.Append("    ret = ChatService.GetAck(strMyUserID, strRecipientUserID, WaitForAckAckOnComplete, OnTimeOut);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function WaitForAckAckOnComplete(blnReturn)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strRecipientUserID = document.getElementById('" & hiddenRecipientUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    if (blnReturn == true) // Recipient gets ACK ACK and sends EOT" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("          $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'Establishing Connection... Sending End Of Transmission';" & vbCrLf)
                cstext.Append("        ret = ChatService.SendEot(strMyUserID, strRecipientUserID);" & vbCrLf)
                cstext.Append("          $get('" & pnlChat.ClientID & "').innerHTML ='Connection Established - Start chatting';" & vbCrLf)
                cstext.Append("  $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML +  ""<br/> <font color=magenta>"" + document.getElementById('" & hiddenRecipientUserName.ClientID & "').value  + ' has requested to Chat with ' +  document.getElementById('" & hiddenMyUserName.ClientID & "').value  + "" <br/> </font>  <font color=black> To respond Type Your message in box given below and press enter.</font>  "" ;  soundManager.play('ding'); " & vbCrLf)  '<embed src='images/imsg.wav' type='audio/x-wav' width='2' height='0'/> </embed>
                cstext.Append("        setTimeout(""GetMessages()"", DelayInMilliSeconds);" & vbCrLf) 'cstext.Append("  $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML +  ""<br/> <font color=magenta>"" + document.getElementById('" & hiddenRecipientUserName.ClientID & "').value  + ' has requested to Chat with ' +  document.getElementById('" & hiddenMyUserName.ClientID & "').value  + "" <br/> </font>  <font color=black> To respond Type Your message in box given below and press enter.</font>  "" ;  soundManager.play('ding'); " & vbCrLf)  '<embed src='images/imsg.wav' type='audio/x-wav' width='2' height='0'/> </embed>
                cstext.Append("    }" & vbCrLf)
                cstext.Append("            else" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        if (iWaitForConnectionLoop == WaitForConnectionLoop)" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("              $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'Error: Chat Request Timed Out!';" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("            else" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("            setTimeout(""WaitForAckAck('"" + strMyUserID + ""', '""+ strRecipientUserID + ""')"", DelayInMilliSeconds);" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function WaitForEot(strMyUserID, strRecipientUserID)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    iWaitForHandshake++" & vbCrLf)
                cstext.Append("      $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'Establishing Connection... Waiting End Of Transmission';" & vbCrLf)
                cstext.Append("    ret = ChatService.GetEot(strMyUserID, strRecipientUserID, WaitForEotOnComplete, OnTimeOut);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function WaitForEotOnComplete(blnReturn)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strRecipientUserID = document.getElementById('" & hiddenRecipientUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    if (blnReturn == true)" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("          $get('" & pnlChat.ClientID & "').innerHTML =   'Connection Established - Start chatting';" & vbCrLf)
                cstext.Append("  $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML +  ""<br/> <font color=magenta>"" + document.getElementById('" & hiddenMyUserName.ClientID & "').value  + ' is In chat with ' +  document.getElementById('" & hiddenRecipientUserName.ClientID & "').value  + ""</font>  "" ;" & vbCrLf)
                cstext.Append("        setTimeout(""GetMessages()"", DelayInMilliSeconds);" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("            else" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        if (iWaitForHandshake == WaitForHandshake)" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("              $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" +  'Error: Chat Request Timed Out!';" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("            else" & vbCrLf)
                cstext.Append("        {" & vbCrLf)
                cstext.Append("            setTimeout(""WaitForEot('"" + strMyUserID + ""', '"" +strRecipientUserID +""')"", DelayInMilliSeconds);" & vbCrLf)
                cstext.Append("        }" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function OnTimeOut(data)" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strRecipientUserID = document.getElementById('" & hiddenRecipientUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("      $get('" & pnlChat.ClientID & "').innerHTML = $get('" & pnlChat.ClientID & "').innerHTML + ""<br/>"" + document.getElementById('" & hiddenRecipientUserName.ClientID & "').value + ' Has quit the chat!';" & vbCrLf)
                cstext.Append("    ret = ChatService.CleanUp(strMyUserID, strRecipientUserID, false);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function ChatCleanUp()" & vbCrLf)
                cstext.Append("{" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strRecipientUserID = document.getElementById('" & hiddenRecipientUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    ret = ChatService.CleanUp(strMyUserID, strRecipientUserID, true);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cs.RegisterClientScriptBlock(cstype, csname, cstext.ToString, True)

                'strScript = "InitChat('" & HttpUtility.UrlEncode(User.Identity.Name).ToLower & "', '" & Request.QueryString("Usr").ToLower & "', '" & Request.QueryString("Init") & "');"
                Dim strScript As String = "InitChat('" & Session("myIP") & "', '" & Request.QueryString("Usr").ToLower & "', '" & Request.QueryString("Init") & "');"
                csname = "InitChat"
                cs = Page.ClientScript
                If (Not cs.IsStartupScriptRegistered(cstype, csname)) Then
                    cs.RegisterStartupScript(cstype, csname, strScript, True)
                End If

            End If
        End If
    End Sub
    Private Function getIPName(ByVal ipaddress As String) As String
        Dim connection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
        connection.Open()
        Dim sqlComm As SqlCommand
        Dim sqlReader As SqlDataReader
        Dim dt As New DataTable()

        Dim name As String

        Try
            sqlComm = New SqlCommand("SELECT   name   FROM iplist WHERE  (ipaddress = '" + ipaddress + "')", connection)  ' fname + ' ' + lname AS name
            sqlReader = sqlComm.ExecuteReader()
            dt.Load(sqlReader)
            sqlComm.Dispose()
            If dt.Rows.Count > 0 Then
                name = dt.Rows(0).Item("name")
                connection.Close()
                getIPName = name

            Else   ' if no name then return ip address
                connection.Close()
                getIPName = ipaddress
            End If
            sqlReader.Close()
        Catch e As Exception
            'lblDebug.text = e.Message
            connection.Close()
            getIPName = "Database not open " + e.Message
        End Try
        connection.Close()
    End Function

    'Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
    '    If Not String.IsNullOrEmpty(txtUpdate.Text) Then
    '        updateIPList(Session("myIP"), txtUpdate.Text)
    '        txtUpdate.Text = ""
    '        lblUpdate.Text = " We have update your identity .. Thanks..."
    '    End If
    'End Sub
    Private Function updateIPList(ByVal ipaddress As String, ByVal myname As String) As String

        Dim connection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("vinConn2").ConnectionString)
        connection.Open()

        Dim sqlComm As SqlCommand
        Dim sqlReader As SqlDataReader
        Dim dt As New DataTable()

        Try
            sqlComm = New SqlCommand("select * from iplist WHERE (ipaddress = '" + ipaddress + "') ", connection)  ' fname + ' ' + lname AS name
            sqlReader = sqlComm.ExecuteReader()
            dt.Load(sqlReader)
            sqlReader.Close()
            If dt.Rows.Count = 1 Then    ' if ip exists
                dt.Dispose()
                sqlComm.Dispose()
                'connection.Close()
                'connection.Open()
                sqlComm = New SqlCommand("UPDATE iplist set name = '" + myname + "' WHERE (ipaddress = '" + ipaddress + "') ", connection)  ' fname + ' ' + lname AS name
                sqlReader = sqlComm.ExecuteReader()
                sqlComm.Dispose()
                sqlReader.Close()
                connection.Close()


                Return "updated"

            Else    'insert ip
                'connection.Close()
                'connection.Open()
                sqlComm = New SqlCommand("Insert Into iplist ( ipaddress, name) " & _
       " VALUES  ( '" + ipaddress + "' , '" + myname + "' ) ", connection)
                sqlReader = sqlComm.ExecuteReader()
                sqlComm.Dispose()
                connection.Close()
                sqlReader.Close()
                Return "new insertion"
            End If


        Catch e As Exception
            'lblDebug.text = e.Message
            connection.Close()
            Return e.Message
        End Try
        connection.Close()

    End Function

   
End Class
