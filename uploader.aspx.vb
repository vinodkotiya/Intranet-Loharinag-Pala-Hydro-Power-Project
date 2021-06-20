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

            Session("CurrentPage") = 0
            Session("SortExpression") = Nothing
            GridViewSortDirection = "ASC"
            ' Set current query
            'Session("CurrentQuery") = "SELECT * from circulars ORDER BY cdate DESC"
            If Request.Params("mode") = "circulars" Then
                TabContainer2.ActiveTabIndex = 0
            ElseIf Request.Params("mode") = "articles" Then
                TabContainer2.ActiveTabIndex = 1
            ElseIf Request.Params("mode") = "ftp" Then
                TabContainer2.ActiveTabIndex = 2
            ElseIf Request.Params("mode") = "feedback" Then
                TabContainer2.ActiveTabIndex = 3
            ElseIf Request.Params("mode") = "reports" Then
                TabContainer2.ActiveTabIndex = 4
            ElseIf Request.Params("mode") = "zigyaasa" Then
                TabContainer2.ActiveTabIndex = 5
            ElseIf Request.Params("mode") = "profile" Then
                TabContainer2.ActiveTabIndex = 6
            End If
        End If
        'this will be executed every time any event happen on web page
        ''page parameter inputs.. "requestedpage"

        'kisi page me session expire ho gaya hai.. login kara ke wapas bhejne ke liye
        If Not String.IsNullOrEmpty(Session("eid")) Then

            If (FileIO.FileSystem.FileExists(Server.MapPath("~/database/pics/") + "p" + Session("eid") + ".gif")) Then
                imgUser.ImageUrl = "database\pics\p" + Session("eid") + ".gif"
            Else
                lblName.Text = "Guest: " + Request.UserHostAddress
                imgUser.ImageUrl = "database\pics\anonymous.gif"
            End If
            lblName.Text = Session("name")
            lblEid.Text = "Eid : " + Session("eid")
            lblDept.Text = Session("dept") + "<br/><a href=login.aspx?signout=1> Log Out </a>"

        Else
            imgUser.ImageUrl = "database\pics\anonymous.gif"
            lblDept.Text = "<a href=login.aspx> Log in </a>"
            lblName.Text = "Guest: " + Request.UserHostAddress
        End If



        If TabContainer2.ActiveTabIndex = 0 Then ' And Not String.IsNullOrEmpty(Session("eid")) Then
            afuFile.Visible = True
            afuFile0.Visible = False
            afufile1.Visible = False
            afufile4.Visible = False
            afuFile6.Visible = False
            'txtCno.Text = "tab1 " '+ Str(TabContainer2.ActiveTabIndex)
            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblBy.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
                btnSubmit.Enabled = True
                lbSignin.Visible = False
            End If
            Session("CurrentQuery") = "SELECT cno, sub , name ,dept, filename, eid , ipaddress, convert(varchar, cdate, 104) as cdate1, cdate from circulars ORDER BY cdate DESC"
            rebindGridView(Session("CurrentQuery"), gvCirculars)
        ElseIf TabContainer2.ActiveTabIndex = 1 Then 'And Not String.IsNullOrEmpty(Session("eid")) Then
            afuFile.Visible = False
            afuFile0.Visible = True
            afufile1.Visible = False
            afufile4.Visible = False
            afuFile6.Visible = False
            ' txtSub0.Text = "tab2 " '+ Str(TabContainer2.ActiveTabIndex)
            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblBy0.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
                btnsubmit0.Enabled = True
                lbSignin0.Visible = False
            End If
            Session("CurrentQuery") = "SELECT topic, name, filename, eid, ipaddress, convert(varchar, cdate, 104) as cdate1, cdate from articles ORDER BY cdate DESC"
            rebindGridView(Session("CurrentQuery"), gvCirculars0)
        ElseIf TabContainer2.ActiveTabIndex = 2 Then
            afuFile.Visible = False
            afuFile0.Visible = False
            afufile1.Visible = True
            afufile4.Visible = False
            afuFile6.Visible = False
            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblBy1.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
                btnSubmit1.Enabled = True
                lbSignin1.Visible = False
            End If
        ElseIf TabContainer2.ActiveTabIndex = 3 Then
            afuFile.Visible = False
            afuFile0.Visible = False
            afufile1.Visible = False
            afufile4.Visible = False
            afuFile6.Visible = False
            ' txtSub1.Text = vbCrLf + vbCrLf + vbCrLf + "Name:"
            Session("CurrentQuery") = "SELECT feedback, fby, convert(varchar, fdate, 104) as fdate1 from feedback ORDER BY fdate DESC"
            rebindGridView(Session("CurrentQuery"), gvCirculars1)
        ElseIf TabContainer2.ActiveTabIndex = 4 Then
            afuFile.Visible = False
            afuFile0.Visible = False
            afufile1.Visible = False
            afufile4.Visible = True
            afuFile6.Visible = False
            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblBy4.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
                btnSubmit4.Enabled = True
                lbsignin4.Visible = False
            End If
            Session("CurrentQuery") = "SELECT filename, eid, convert(varchar, cdate, 104) as cdate1, dept from reports ORDER BY cdate DESC"
            rebindGridView(Session("CurrentQuery"), gvCirculars4)
        ElseIf TabContainer2.ActiveTabIndex = 6 Then
            afuFile.Visible = False
            afuFile0.Visible = False
            afufile1.Visible = False
            afufile4.Visible = False
            afuFile6.Visible = True
            If Not String.IsNullOrEmpty(Request.Params("eid")) Then
                txtUser.Text = Request.Params("eid")
            End If
            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblBy6.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
                btnSubmit6.Enabled = True
                lbSignin6.Visible = False
            End If
            lblMsg6.Text = "You are requested to not use your date of birth as password for security reasons"

        Else
            afuFile.Visible = False
            afuFile0.Visible = False
            afufile1.Visible = False
            afufile4.Visible = False
            afuFile6.Visible = False
            End If
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
        '        cstext.Append("function CheckChatReqOnComplete(strSenderUserID) {" & vbCrLf)  'this will listen for request so init =0 and open a popup
        '        cstext.Append("    if (strSenderUserID != """")" & vbCrLf)
        '        cstext.Append("    {" & vbCrLf)
        '        cstext.Append("        var popupWindow = null;" & vbCrLf)
        '        cstext.Append("        document.getElementById('" & hiddenSenderUserID.ClientID & "').value = strSenderUserID;" & vbCrLf)
        '        cstext.Append("   //     document.getElementById('ChatRequest').innerHTML = ""<p style=\""text-align: center;\"">""" & vbCrLf)
        '        cstext.Append("  //          + ""You have an incoming chat request from: '"" + strSenderUserID + ""'<br/><br/>""" & vbCrLf)
        '        cstext.Append("  //          + ""Would you like to accept?</p>"";" & vbCrLf)
        '        cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("     $get('chatframe').src='http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
        '        cstext.Append("      var modalPopupBehavior = $find('programmaticModalPopupBehaviorChatReq');" & vbCrLf)
        '        cstext.Append("      modalPopupBehavior.show();" & vbCrLf)
        '        cstext.Append(" //  redirect('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
        '        cstext.Append("  // window.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
        '        cstext.Append("  // popupWindow = window.open('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
        '        cstext.Append("   setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
        '        cstext.Append("   }" & vbCrLf)
        '        cstext.Append("     else" & vbCrLf)
        '        cstext.Append("    {" & vbCrLf)
        '        cstext.Append("        var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("        setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
        '        cstext.Append("    }" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append("function vinModal( strOther) {" & vbCrLf)  'this will call other person window so init =1
        '        cstext.Append("        var popupWindow = null;" & vbCrLf)
        '        cstext.Append("        document.getElementById('" & hiddenSenderUserID.ClientID & "').value = strOther;" & vbCrLf)
        '        cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("     $get('chatframe').src= 'chat.aspx?Usr=' +  strSenderUserID+ '&Init=1';" & vbCrLf)
        '        cstext.Append("      var modalPopupBehavior = $find('programmaticModalPopupBehaviorChatReq');" & vbCrLf)
        '        cstext.Append("      modalPopupBehavior.show();" & vbCrLf)
        '        cstext.Append(" //movePanel();" & vbCrLf)
        '        cstext.Append("  }" & vbCrLf)
        '        cstext.Append("var id = null; " & vbCrLf)
        '        cstext.Append("function movePanel() { " & vbCrLf)
        '        cstext.Append("  var pnl = $get('PanelChatRequest'); " & vbCrLf)
        '        cstext.Append(" if (pnl != null) { " & vbCrLf)
        '        cstext.Append("  pnl.style.top = '200'; " & vbCrLf)
        '        cstext.Append("  pnl.style.left =  '200'; } " & vbCrLf)
        '        cstext.Append(" id = setTimeout('movePanel();', 100);" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append(" function stopMoving() { " & vbCrLf)
        '        cstext.Append(" clearTimeout(id);" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append("function CheckChatReqOnTimeout(strSenderUserID) {" & vbCrLf)
        '        cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", DelayInSeconds * 1000);" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append("function OnOk() {" & vbCrLf)
        '        cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strAppPath = document.getElementById('" & hiddenAppPath.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("  // var w = window.open();" & vbCrLf)
        '        cstext.Append("  // w.opener = null;" & vbCrLf)
        '        cstext.Append("  // w.document.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
        '        cstext.Append("  // window.location = 'http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0';" & vbCrLf)
        '        cstext.Append(" //   popupWindow = window.open('http://' + strAppPath + '/chat.aspx?Usr=' + strSenderUserID + '&Init=0');" & vbCrLf)
        '        cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
        '        cstext.Append("}" & vbCrLf)
        '        cstext.Append("function OnCancel() {" & vbCrLf)
        '        cstext.Append("    var strSenderUserID = document.getElementById('" & hiddenSenderUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    var strMyUserID = document.getElementById('" & hiddenMyUserID.ClientID & "').value;" & vbCrLf)
        '        cstext.Append("    ret = ChatService.SendNak(strMyUserID, strSenderUserID);" & vbCrLf)
        '        cstext.Append("    setTimeout(""CheckChatReq('"" + strMyUserID + ""')"", 1000);" & vbCrLf)
        '        cstext.Append("//stopMoving();" & vbCrLf)
        '        cstext.Append("  }" & vbCrLf)

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

    End Sub
    'Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Dim ChatService As New ChatService
    '    ChatService.trackOnlineVisitor(Session("myIP"))

    'End Sub



    Protected Sub gvCirculars_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvCirculars.PageIndexChanging
        If gvCirculars.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvCirculars.DataSource = SortDataTable(gvCirculars.DataSource, True)
            gvCirculars.PageIndex = e.NewPageIndex
            Session("CurrentPage") = e.NewPageIndex
            gvCirculars.DataBind()
        End If
    End Sub
    Protected Sub gvCirculars_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCirculars.SelectedIndexChanged
        ' Bind current data
        gvCirculars.DataSource = SortDataTable(gvCirculars.DataSource, True)
        gvCirculars.PageIndex = Session("CurrentPage")
        gvCirculars.DataBind()

        ' Clear session variables
        Session("CurrentPage") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery") = Nothing

    End Sub
    Protected Sub gvCirculars0_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvCirculars0.PageIndexChanging
        If gvCirculars0.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvCirculars0.DataSource = SortDataTable(gvCirculars0.DataSource, True)
            gvCirculars0.PageIndex = e.NewPageIndex
            Session("CurrentPage") = e.NewPageIndex
            gvCirculars0.DataBind()
        End If
    End Sub
    Protected Sub gvCirculars0_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCirculars0.SelectedIndexChanged
        ' Bind current data
        gvCirculars0.DataSource = SortDataTable(gvCirculars0.DataSource, True)
        gvCirculars0.PageIndex = Session("CurrentPage")
        gvCirculars0.DataBind()

        ' Clear session variables
        Session("CurrentPage") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery") = Nothing

    End Sub
    Protected Sub gvCirculars1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvCirculars1.PageIndexChanging
        If gvCirculars1.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvCirculars1.DataSource = SortDataTable(gvCirculars1.DataSource, True)
            gvCirculars1.PageIndex = e.NewPageIndex
            Session("CurrentPage") = e.NewPageIndex
            gvCirculars1.DataBind()
        End If
    End Sub
    Protected Sub gvCirculars1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCirculars1.SelectedIndexChanged
        ' Bind current data
        gvCirculars1.DataSource = SortDataTable(gvCirculars1.DataSource, True)
        gvCirculars1.PageIndex = Session("CurrentPage")
        gvCirculars1.DataBind()

        ' Clear session variables
        Session("CurrentPage") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery") = Nothing

    End Sub
    Protected Sub gvCirculars4_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvCirculars4.PageIndexChanging
        If gvCirculars4.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvCirculars4.DataSource = SortDataTable(gvCirculars4.DataSource, True)
            gvCirculars4.PageIndex = e.NewPageIndex
            Session("CurrentPage") = e.NewPageIndex
            gvCirculars4.DataBind()
        End If
    End Sub
    Protected Sub gvCirculars4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvCirculars4.SelectedIndexChanged
        ' Bind current data
        gvCirculars4.DataSource = SortDataTable(gvCirculars4.DataSource, True)
        gvCirculars4.PageIndex = Session("CurrentPage")
        gvCirculars4.DataBind()

        ' Clear session variables
        Session("CurrentPage") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery") = Nothing

    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Session("CurrentQuery") = "SELECT cno, sub , name ,dept, filename, eid , ipaddress, convert(varchar, cdate, 104) as cdate1, cdate from circulars where sub LIKE N'%" + Trim(txtSearch.Text) + "%'"
        rebindGridView(Session("CurrentQuery"), gvCirculars)
    End Sub
    Protected Sub btnSearch0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch0.Click
        Session("CurrentQuery") = "SELECT topic, name, filename, eid, ipaddress, convert(varchar, cdate, 104) as cdate1, cdate from articles where topic LIKE N'%" + Trim(txtSearch0.Text) + "%'"
        rebindGridView(Session("CurrentQuery"), gvCirculars0)
    End Sub
    Protected Sub btnSearch4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch4.Click
        Session("CurrentQuery") = "SELECT filename, eid, convert(varchar, cdate, 104) as cdate1, dept from reports where dept LIKE '%" + Trim(txtSearch4.Text) + "%'"
        rebindGridView(Session("CurrentQuery"), gvCirculars4)
    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If (afuFile.HasFile) Then
            'check file is attached or not
            Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(afuFile.FileName), " ", "_"))
            Dim circdate As Date
            circdate = txtDate.Text
            Dim mysql As String = "Insert Into circulars ( cno, sub, name , dept, filename, cdate, eid, ipaddress)" & _
       "VALUES  (" & _
                "N'" & Replace(txtCno.Text, "'", "''") & "', " & _
                "N'" & Replace(txtSub.Text, "'", "''") & "', " & _
                "N'" & Replace(Session("name"), "'", "''") & "', " & _
                "N'" & Replace(Session("dept"), "'", "''") & "', " & _
                "'" & Replace(TheFile, "'", "''") & "', " & _
                "'" & Replace(circdate, "'", "''") & "', " & _
                 "'" & Replace(Session("eid"), "'", "''") & "', " & _
                               "'" & Replace(Request.UserHostAddress, "'", "''") & "') "
            'lbldebug.Text = mysql
            'lblBy.Text = mysql
            lblMsg.Text = ""  'to prevent multiple submits
            txtCno.Text = ""
            txtSub.Text = ""
            txtDate.Text = ""
            If insertRecord(mysql) Then
                'now insert in database
                Try


                    afuFile.SaveAs(Server.MapPath("~/database/circulars/") + TheFile)
                    lblMsg.Text = TheFile + " uploaded! from : " + Request.UserHostAddress  '+ mysql
                    rebindGridView(Session("CurrentQuery"), gvCirculars)
                    Return
                Catch Exc As Exception

                    lblMsg.Text = "File not uploaded: " + Exc.Message
                    Return
                End Try
            Else
                lblMsg.Text = "unable to insert " + mysql
            End If
        Else
            lblMsg.Text = "Please attach the file"
        End If
        'rebindGridView(Session("CurrentQuery"), gvCirculars)
    End Sub
    Protected Sub btnsubmit0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit0.Click
        '  lblMsg0.Text = "clicked" + afuFile0.FileName
        If (afuFile0.HasFile) Then
            'check file is attached or not
            Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(afuFile0.FileName), " ", "_"))
            Dim circdate As Date
            circdate = Now()
            Dim mysql As String = "Insert Into articles ( topic, name , filename, cdate, eid, ipaddress)" & _
       "VALUES  (" & _
                "N'" & Replace(txtSub0.Text, "'", "''") & "', " & _
                "N'" & Replace(Session("name"), "'", "''") & "', " & _
                "'" & Replace(TheFile, "'", "''") & "', " & _
                "'" & Replace(circdate, "'", "''") & "', " & _
                                 "'" & Replace(Session("eid"), "'", "''") & "', " & _
                               "'" & Replace(Request.UserHostAddress, "'", "''") & "') "
            'lbldebug.Text = mysql
            'lblBy.Text = mysql
            lblMsg0.Text = ""  'to prevent multiple submits
            txtSub0.Text = ""
            circdate = Nothing

            If insertRecord(mysql) Then

                'now insert in database
                Try


                    afuFile0.SaveAs(Server.MapPath("~/database/articles/") + TheFile)
                    lblMsg0.Text = TheFile + " uploaded! From : " + Request.UserHostAddress '+ mysql
                    rebindGridView(Session("CurrentQuery"), gvCirculars0)
                    Return
                Catch Exc As Exception

                    lblMsg0.Text = "File not uploaded: " + Exc.Message
                    Return
                End Try
            Else
                lblMsg0.Text = "unable to insert " + mysql
            End If
        Else
            lblMsg0.Text = "Please attach the file"
        End If
    End Sub
    Protected Sub btnSubmit1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit1.Click
        If (afufile1.HasFile) Then
            'check file is attached or not
            Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(afufile1.FileName), " ", "_"))

            Try


                afufile1.SaveAs(Server.MapPath("~/ftp/") + TheFile)
                'lblBy.Text = TheFile + " uploaded! From : " + Request.UserHostAddress '+ mysql
                txtLink.Visible = True
                lblshare.Text = "Please right click and copy this link and share with others >"
                txtLink.Text = "http://191.254.186.1/ftp/" + TheFile
                Return
            Catch Exc As Exception

                lblshare.Text = "File not uploaded: " + Exc.Message
                Return
            End Try


        Else
            lblshare.Text = "Please attach the file"
        End If
    End Sub

    Protected Sub btnsubmit2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit2.Click

        Dim fby As String = Session("name")
        If String.IsNullOrEmpty(fby) Then
            fby = "Guest:" + Request.UserHostAddress
        Else
            fby = fby + ":" + Request.UserHostAddress
        End If
        Dim circdate As Date
        Dim fback As String = txtSub1.Text
        fback = Replace(fback, vbCrLf, " ") ' replace line feed with space
        circdate = Now()
        Dim mysql As String = "Insert Into feedback ( feedback, fby, fdate )" & _
   "VALUES  (" & _
            "N'" & Replace(txtSub1.Text, "'", "''") & "', " & _
            "N'" & Replace(fby, "'", "''") & "', " & _
                           "'" & Replace(circdate, "'", "''") & "') "
        'lbldebug.Text = mysql
        'lblBy.Text = mysql
        'to prevent multiple submits
        txtSub1.Text = ""
        circdate = Nothing

        If insertRecord(mysql) Then
            lblBy2.Text = "Your feedback has been Submitted. Thank You :)"
            lbSignin2.Visible = False
        Else
            lblBy2.Text = "unable to insert " + mysql
        End If
        rebindGridView(Session("CurrentQuery"), gvCirculars1)
    End Sub

    Protected Sub btnsubmit4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit4.Click
        '  lblMsg0.Text = "clicked" + afuFile0.FileName
        If (afufile4.HasFile) Then
            'check file is attached or not
            Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(afufile4.FileName), " ", "_"))
            Dim circdate As Date
            circdate = txtDate0.Text
            Dim mysql As String = "Insert Into reports ( filename, cdate,dept, eid)" & _
       "VALUES  (" & _
                "'" & Replace(TheFile, "'", "''") & "', " & _
                "'" & Replace(circdate, "'", "''") & "', " & _
                                 "'" & Replace(Session("dept"), "'", "''") & "', " & _
                               "'" & Replace(Session("eid"), "'", "''") & "') "
            'lbldebug.Text = mysql
            'lblBy.Text = mysql
            lblMsg4.Text = ""  'to prevent multiple submits
            txtDate0.Text = ""
            circdate = Nothing

            If insertRecord(mysql) Then

                'now insert in database
                Try


                    afufile4.SaveAs(Server.MapPath("~/database/reports/") + TheFile)
                    lblMsg4.Text = TheFile + " uploaded! From : " + Request.UserHostAddress '+ mysql
                    rebindGridView(Session("CurrentQuery"), gvCirculars4)
                    Return
                Catch Exc As Exception

                    lblMsg4.Text = "File not uploaded: " + Exc.Message
                    Return
                End Try
            Else
                lblMsg4.Text = "unable to insert " + mysql
            End If
        Else
            lblMsg4.Text = "Please attach the file"
        End If
    End Sub

    Protected Sub btnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If Authenticateuser(txtUser.Text, txtOldPwd.Text) Then
            If updatePwd(txtUser.Text, txtNewPwd.Text) Then
                lblMsg6.Text = "Your Password has been updated succesfully.. <a href=login.aspx?signout=1> Click here to login Again </a>"
                'Response.Write("<script language='javascript'>window.alert('Your Password has been updated succesfully. You have to login again with new password. Redirecting Now....');</script>")
                '  Response.Redirect("login.aspx?signout=1")

            Else
                lblMsg6.Text = "Unable to update your new password. Contact Web Admin"
            End If
        Else
            lblMsg6.Text = "Wrong eid or old password. Try Again " + txtUser.Text + txtOldPwd.Text
        End If
    End Sub
    Private Function Authenticateuser(ByVal name As String, ByVal pwd As String) As Boolean
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            '  connection.Close()
            connection.Open()
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Try
                sqlComm = New SqlCommand("select * from emplogin WHERE (eid = '" + name + "') AND (pwd = '" + pwd + "') ", connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                dataTableRowCount = dt.Rows.Count
                sqlReader.Close()
                sqlComm.Dispose()
                If dataTableRowCount = 1 Then
                    'Session("eid") = name
                    connection.Close()
                    Return True
                Else
                    connection.Close()
                    Return False
                End If

            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return False
            End Try
            connection.Close()
        End Using
    End Function
    Private Function updatePwd(ByVal name As String, ByVal pwd As String) As Boolean
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            '  connection.Close()
            connection.Open()
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()

            Try
                sqlComm = New SqlCommand("update emplogin set pwd = '" + pwd + "' where eid = '" + name + "'", connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                sqlComm.Dispose()
                sqlReader.Close()

                connection.Close()
                Return True


            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return False
            End Try
            connection.Close()
        End Using
    End Function

    Protected Sub btnSubmit6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit6.Click

        Const bmpW = 100 'New image canvas width

        Const bmpH = 140 'New Image canvas height
        If (afuFile6.HasFile) Then
            'check file is attached or not
           
            Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(afuFile6.FileName), " ", "_"))
            Dim extension As String = System.IO.Path.GetExtension(afuFile6.FileName)
            If (extension.ToUpper = ".JPG") Or (extension.ToUpper = ".GIF") Then
                Dim newWidth As Integer = bmpW
                Dim newHeight As Integer = bmpH
                'Use the uploaded filename without the '.' extension
                '  Dim upName As String = Mid(FileUpload1.FileName, 1, (InStr(FileUpload1.FileName, ".") - 1))
                Dim filePath As String = "~/database/pics/p" & Session("eid") & ".gif"
                '**** Resize image section ****  
                'Create a new Bitmap using the uploaded picture as a Stream
                'Set the new bitmap resolution to 72 pixels per inch
                Dim upBmp As System.Drawing.Bitmap = System.Drawing.Bitmap.FromStream(afuFile6.PostedFile.InputStream)
                Dim newBmp As System.Drawing.Bitmap = New System.Drawing.Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                newBmp.SetResolution(100, 140)
                'Get the uploaded image width and height
                Dim upWidth As Integer = upBmp.Width
                Dim upHeight As Integer = upBmp.Height
                Dim newX As Integer = 0
                Dim newY As Integer = 0
                'Dim reDuce As Decimal
                ''Keep the aspect ratio of image the same if not 4:3 and work out the newX and newY positions
                ''to ensure the image is always in the centre of the canvas vertically and horizontally
                'If upWidth > upHeight Then 'Landscape picture
                '    reDuce = newWidth / upWidth

                '    'calculate the width percentage reduction as decimal
                '    newHeight = Int(upHeight * reDuce)

                '    'reduce the uploaded image height by the reduce amount
                '    newY = Int((bmpH - newHeight) / 2)

                '    'Position the image centrally down the canvas
                '    newX = 0

                '    'Picture will be full width
                'ElseIf upWidth < upHeight Then 'Portrait picture
                '    reDuce = newHeight / upHeight

                '    'calculate the height percentage reduction as decimal
                '    newWidth = Int(upWidth * reDuce)

                '    'reduce the uploaded image height by the reduce amount
                '    newX = Int((bmpW - newWidth) / 2)

                '    'Position the image centrally across the canvas
                '    newY = 0

                '    'Picture will be full hieght
                'ElseIf upWidth = upHeight Then 'square picture
                '    reDuce = newHeight / upHeight

                '    'calculate the height percentage reduction as decimal
                '    newWidth = Int(upWidth * reDuce)

                '    'reduce the uploaded image height by the reduce amount
                '    newX = Int((bmpW - newWidth) / 2)

                '    'Position the image centrally across the canvas
                '    newY = Int((bmpH - newHeight) / 2)

                '    'Position the image centrally down the canvas
                'End If
                'Create a new image from the uploaded picture using the Graphics class
                'Clear the graphic and set the background colour to white
                'Use Antialias and High Quality Bicubic to maintain a good quality picture
                'Save the new bitmap image using 'Png' picture format and the calculated canvas positioning
                Dim newGraphic As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(newBmp)
                Try
                    newGraphic.Clear(System.Drawing.Color.White)

                    newGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

                    newGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

                    newGraphic.DrawImage(upBmp, newX, newY, newWidth, newHeight)

                    newBmp.Save(Server.MapPath(filePath), System.Drawing.Imaging.ImageFormat.Bmp)


                Catch ex As Exception
                    lblBy6.Text = ex.ToString + Server.MapPath(filePath)

                Finally
                    upBmp.Dispose()

                    newBmp.Dispose()

                    newGraphic.Dispose()

                End Try
               
                '**** End resize image section ****  


                lblBy6.Text = "Your picture has been uploaded succesfully. It may take some time to reflect changes. Restart your browser to see changes."

            Else
                lblBy6.Text = "Please only upload .jpg or .gif files"

            End If
        Else
            lblBy6.Text = "No file selected"

        End If
    End Sub
   

End Class