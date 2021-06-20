Imports System.Data
Imports System.Data.SqlClient
Imports filter
Imports databaseconn
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("myIP") = Request.UserHostAddress   ' for LAN/WAN   or
        'Session("myIP") = Request.UserHostAddress + Request.Browser.Browser  'for single PC
        If Not Page.IsPostBack Then
            'this will be executed only first time any event happen on web page
            ' Clear user paging/sort
            'Session("CurrentPage") = 0
            'Session("SortExpression") = Nothing
            'GridViewSortDirection = "ASC"
            ' Set current query

        End If
        'this will be executed every time any event happen on web page
        ''page parameter inputs.. "requestedpage"

        'kisi page me session expire ho gaya hai.. login kara ke wapas bhejne ke liye

        frmLoader.Visible = True
        If Request.Params("requestedpage") = "layout" Then
            frmLoader.Attributes("src") = "loader/layout.htm"
            lblLoader.Text = "Project Layout"
        ElseIf Request.Params("requestedpage") = "activity" Then
            frmLoader.Attributes("src") = "loader/activity.htm"
            lblLoader.Text = "Project Activity"
        ElseIf Request.Params("requestedpage") = "award" Then
            frmLoader.Attributes("src") = "loader/awarddetail.htm"
            lblLoader.Text = "Award Status"
        ElseIf Request.Params("requestedpage") = "milestone" Then
            frmLoader.Attributes("src") = "loader/milestone.htm"
            lblLoader.Text = "LPHPP Milestones"
        ElseIf Request.Params("requestedpage") = "fotogal" Then
            frmLoader.Attributes("src") = "loader/fotogal.htm"
            lblLoader.Text = "LPHPP Foto Gallery"
        ElseIf Request.Params("requestedpage") = "erp" Then
            frmLoader.Attributes("src") = "loader/erp.htm"
            lblLoader.Text = "Enterprize Resource Planning - ERP"
        ElseIf Request.Params("requestedpage") = "tourism" Then
            frmLoader.Attributes("src") = "loader/tourism.htm"
            lblLoader.Text = "How to Reach - Tourism"
        ElseIf Request.Params("requestedpage") = "projects" Then
            frmLoader.Attributes("src") = "loader/projlinks.htm"
            lblLoader.Text = "Link To NTPC Projects"
        ElseIf Request.Params("requestedpage") = "hindi" Then
            frmLoader.Attributes("src") = "loader/hindi.htm"
            lblLoader.Text = "How to Use Hindi on Intranet"
        ElseIf Request.Params("requestedpage") = "livenews" Then
            frmLoader.Attributes("src") = "loader/livenews.aspx"
            lblLoader.Text = "Live News"
        End If
        If Not String.IsNullOrEmpty(Session("myIP")) Then '  If Not String.IsNullOrEmpty(Page.User.Identity.Name) Then
            hiddenAppPath.Text = Request.ServerVariables("SERVER_NAME") & ":" & Request.ServerVariables("SERVER_PORT") & Request.ApplicationPath()

            Dim csname As String = "CheckChatReq"
            Dim cstype As Type = Me.GetType()
            Dim cs As ClientScriptManager = Page.ClientScript
            If (Not cs.IsClientScriptBlockRegistered(cstype, csname)) Then
                Dim cstext As New StringBuilder()
                cstext.Append("var DelayInSeconds = 12;" & vbCrLf)
                cstext.Append("function InitCheckChatReq(strMyUserID) {" & vbCrLf)
                cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function CheckChatReq(strMyUserID) {" & vbCrLf)
                cstext.Append("    ret = ChatService.CheckChatReq(strMyUserID, CheckChatReqOnComplete, CheckChatReqOnTimeout);" & vbCrLf)
                cstext.Append("    document.getElementById('" & hiddenMyUserID.ClientID & "').value = strMyUserID;" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function CheckChatReqOnComplete(strSenderUserID) {" & vbCrLf)  'this will listen for request so init =0 and open a popup
                cstext.Append("    if (strSenderUserID != """")" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        var popupWindow = null;" & vbCrLf)
                cstext.Append("        document.getElementById('" & hiddenSenderUserID.ClientID & "').value = strSenderUserID;" & vbCrLf)
                cstext.Append("   //     document.getElementById('ChatRequest').innerHTML = ""<p style=\""text-align: center;\"">""" & vbCrLf)
                cstext.Append("  //          + ""You have an incoming chat request from: '"" + strSenderUserID + ""'<br/><br/>""" & vbCrLf)
                cstext.Append("  //          + ""Would you like to accept?</p>"";" & vbCrLf)
                cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
                cstext.Append("     $get('chatframe').src='http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
                cstext.Append("      var modalPopupBehavior = $find('programmaticModalPopupBehaviorChatReq');" & vbCrLf)
                cstext.Append("      modalPopupBehavior.show();" & vbCrLf)
                cstext.Append(" //  redirect('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
                cstext.Append("  // window.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
                cstext.Append("  // popupWindow = window.open('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
                cstext.Append("   setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
                cstext.Append("   }" & vbCrLf)
                cstext.Append("     else" & vbCrLf)
                cstext.Append("    {" & vbCrLf)
                cstext.Append("        var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("        setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
                cstext.Append("    }" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function vinModal( strOther) {" & vbCrLf)  'this will call other person window so init =1
                cstext.Append("        var popupWindow = null;" & vbCrLf)
                cstext.Append("        document.getElementById('" & hiddenSenderUserID.ClientID & "').value = strOther;" & vbCrLf)
                cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
                cstext.Append("     $get('chatframe').src= 'chat.aspx?Usr=' +  strSenderUserID+ '&Init=1';" & vbCrLf)
                cstext.Append("      var modalPopupBehavior = $find('programmaticModalPopupBehaviorChatReq');" & vbCrLf)
                cstext.Append("      modalPopupBehavior.show();" & vbCrLf)
                cstext.Append(" //movePanel();" & vbCrLf)
                cstext.Append("  }" & vbCrLf)
                cstext.Append("var id = null; " & vbCrLf)
                cstext.Append("function movePanel() { " & vbCrLf)
                cstext.Append("  var pnl = $get('PanelChatRequest'); " & vbCrLf)
                cstext.Append(" if (pnl != null) { " & vbCrLf)
                cstext.Append("  pnl.style.top = '200'; " & vbCrLf)
                cstext.Append("  pnl.style.left =  '200'; } " & vbCrLf)
                cstext.Append(" id = setTimeout('movePanel();', 100);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append(" function stopMoving() { " & vbCrLf)
                cstext.Append(" clearTimeout(id);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function CheckChatReqOnTimeout(strSenderUserID) {" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function OnOk() {" & vbCrLf)
                cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
                cstext.Append("  // var w = window.open();" & vbCrLf)
                cstext.Append("  // w.opener = null;" & vbCrLf)
                cstext.Append("  // w.document.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
                cstext.Append("  // window.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
                cstext.Append(" //   popupWindow = window.open('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
                cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
                cstext.Append("}" & vbCrLf)
                cstext.Append("function OnCancel() {" & vbCrLf)
                cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
                cstext.Append("    ret = ChatService.SendNak(strMyUserID, strSenderUserID);" & vbCrLf)
                cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
                cstext.Append("//stopMoving();" & vbCrLf)
                cstext.Append("  }" & vbCrLf)

                cs.RegisterClientScriptBlock(cstype, csname, cstext.ToString, True)
            End If

            ' Dim strScript As String = "InitCheckChatReq('" & HttpUtility.UrlEncode(Page.User.Identity.Name) & "');"
            Dim strScript As String = "InitCheckChatReq('" & Session("myIP") & "');"
            csname = "InitCheckChatReq"
            cs = Page.ClientScript
            If (Not cs.IsStartupScriptRegistered(cstype, csname)) Then
                cs.RegisterStartupScript(cstype, csname, strScript, True)
            End If

        End If
    End Sub

    
    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ChatService As New ChatService
        ChatService.trackOnlineVisitor(Session("myIP"))
        
    End Sub
    
End Class
