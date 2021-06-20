Imports System.Data
Imports System.Data.SqlClient
Imports filter
Imports databaseconn


Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'this will be executed only first time any event happen on web page
            ' Clear user paging/sort
            lblName.Text = "Guest: " + Request.UserHostAddress
            Session("CurrentPage") = 0
            Session("SortExpression") = Nothing
            GridViewSortDirection = "ASC"
            ' Set current query
            Session("CurrentQuery") = "SELECT * from circulars ORDER BY cdate DESC"
            If Request.Params("mode") = "circulars" Then
                TabContainer1.ActiveTabIndex = 0
            ElseIf Request.Params("mode") = "articles" Then
                TabContainer1.ActiveTabIndex = 1
            ElseIf Request.Params("mode") = "ftp" Then
                TabContainer1.ActiveTabIndex = 2
            ElseIf Request.Params("mode") = "feedback" Then
                TabContainer1.ActiveTabIndex = 3
            ElseIf Request.Params("mode") = "reports" Then
                TabContainer1.ActiveTabIndex = 4
            ElseIf Request.Params("mode") = "zigyaasa" Then
                TabContainer1.ActiveTabIndex = 5
            End If
        End If

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
        End If
            'this will be executed every time any event happen on web page

            ' Bind GridView to current query & always store ur queery into session("currentquery") before calling
            ' reason is whenever page indexed changed or sort.. then it will show data from currentquery

            'rebindGridView(Session("CurrentQuery"), gvCirculars)
            'this code is causing page refresh in tab change , otherwise not
        'If TabContainer1.ActiveTabIndex = 0 Then
        '    'if u wont use this then get error at gvCirculars0.DataSource.GetType().ToString = "System.Data.DataTable" 
        '    Session("CurrentQuery") = "SELECT * from circulars ORDER BY cdate DESC"
        '    rebindGridView(Session("CurrentQuery"), gvCirculars)
        'ElseIf TabContainer1.ActiveTabIndex = 1 Then
        '    Session("CurrentQuery") = "SELECT * from articles ORDER BY cdate DESC"
        '    rebindGridView(Session("CurrentQuery"), gvCirculars0)
        'End If
        If TabContainer1.ActiveTabIndex = 0 Then ' And Not String.IsNullOrEmpty(Session("eid")) Then
            afuFile.Visible = True
            afuFile0.Visible = False
            afufile1.Visible = False
            'txtCno.Text = "tab1 " '+ Str(TabContainer1.ActiveTabIndex)
            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblBy.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
                btnSubmit.Enabled = True
                lbSignin.Visible = False
            End If
            Session("CurrentQuery") = "SELECT cno, sub , name ,dept, filename, eid , ipaddress, convert(varchar, cdate, 104) as cdate1, cdate from circulars ORDER BY cdate DESC"
            rebindGridView(Session("CurrentQuery"), gvCirculars)
        ElseIf TabContainer1.ActiveTabIndex = 1 Then 'And Not String.IsNullOrEmpty(Session("eid")) Then
            afuFile.Visible = False
            afuFile0.Visible = True
            afufile1.Visible = False

            ' txtSub0.Text = "tab2 " '+ Str(TabContainer1.ActiveTabIndex)
            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblBy0.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
                btnSubmit0.Enabled = True
                lbSignin0.Visible = False
            End If
            Session("CurrentQuery") = "SELECT topic, name, filename, eid, ipaddress, convert(varchar, cdate, 104) as cdate1, cdate from articles ORDER BY cdate DESC"
            rebindGridView(Session("CurrentQuery"), gvCirculars0)
        ElseIf TabContainer1.ActiveTabIndex = 2 Then
            afuFile.Visible = False
            afuFile0.Visible = False
            afufile1.Visible = True
            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblBy1.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
                btnSubmit1.Enabled = True
                lbSignin1.Visible = False
            End If
        ElseIf TabContainer1.ActiveTabIndex = 3 Then
            afuFile.Visible = False
            afuFile0.Visible = False
            afufile1.Visible = False
            Session("CurrentQuery") = "SELECT * from feedback ORDER BY fdate DESC"
            ' rebindGridView(Session("CurrentQuery"), gvCirculars1)
        End If
    End Sub
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
    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If (afuFile.HasFile) Then
            'check file is attached or not
            Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(afuFile.FileName), " ", "_"))
            Dim circdate As Date
            circdate = txtDate.Text
            Dim mysql As String = "Insert Into circulars ( cno, sub, name , dept, filename, cdate, eid, ipaddress)" & _
       "VALUES  (" & _
                "'" & Replace(txtCno.Text, "'", "''") & "', " & _
                "'" & Replace(txtSub.Text, "'", "''") & "', " & _
                "'" & Replace(Session("name"), "'", "''") & "', " & _
                "'" & Replace(Session("dept"), "'", "''") & "', " & _
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

    
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Session("CurrentQuery") = "SELECT cno, sub , name ,dept, filename, eid , ipaddress, convert(varchar, cdate, 104) as cdate1, cdate from circulars where sub LIKE '%" + Trim(txtSearch.Text) + "%'"
        rebindGridView(Session("CurrentQuery"), gvCirculars)
    End Sub

   

    Protected Sub TabPanel2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPanel2.Load
       
    End Sub

   
    Protected Sub TabPanel1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPanel1.Load
       
    End Sub
   

    Protected Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        'asyncfile upload gives error if placed in multiple tab a._innerTB.style.width=a._inputFile.offsetWidth-107+"px";
        ' thats why all async are false on visible...
        'If TabContainer1.ActiveTabIndex = 0 Then ' And Not String.IsNullOrEmpty(Session("eid")) Then
        '    afuFile.Visible = True
        '    afuFile0.Visible = False

        '    'txtCno.Text = "tab1 " '+ Str(TabContainer1.ActiveTabIndex)
        '    If Not String.IsNullOrEmpty(Session("eid")) Then
        '        lblBy.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
        '        btnSubmit.Enabled = True
        '        lbSignin.Visible = False
        '    End If
        '    Session("CurrentQuery") = "SELECT * from circulars ORDER BY cdate DESC"
        '    rebindGridView(Session("CurrentQuery"), gvCirculars)
        'ElseIf TabContainer1.ActiveTabIndex = 1 Then 'And Not String.IsNullOrEmpty(Session("eid")) Then
        '    afuFile.Visible = False
        '    afuFile0.Visible = True

        '    ' txtSub0.Text = "tab2 " '+ Str(TabContainer1.ActiveTabIndex)
        '    If Not String.IsNullOrEmpty(Session("eid")) Then
        '        lblBy0.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
        '        btnSubmit0.Enabled = True
        '        lbSignin0.Visible = False
        '    End If
        '    Session("CurrentQuery") = "SELECT * from articles ORDER BY cdate DESC"
        '    rebindGridView(Session("CurrentQuery"), gvCirculars0)
        'End If
    End Sub

    Protected Sub btnSearch0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch0.Click
        Session("CurrentQuery") = "SELECT * from articles where topic LIKE '%" + Trim(txtSearch0.Text) + "%'"
        rebindGridView(Session("CurrentQuery"), gvCirculars0)
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
                "'" & Replace(txtSub0.Text, "'", "''") & "', " & _
                "'" & Replace(Session("name"), "'", "''") & "', " & _
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

   
    'Protected Sub btnsubmit2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit2.Click

    '    '     Dim fby As String = Session("name")
    '    '     If String.IsNullOrEmpty(fby) Then
    '    '         fby = "Guest:" + Request.UserHostAddress
    '    '     Else
    '    '         fby = fby + ":" + Request.UserHostAddress
    '    '     End If
    '    '     Dim circdate As Date
    '    '     circdate = Now()
    '    '     Dim mysql As String = "Insert Into feedback ( feedback, fby, fdate )" & _
    '    '"VALUES  (" & _
    '    '         "'" & Replace(txtSub1.Text, "'", "''") & "', " & _
    '    '         "'" & Replace(fby, "'", "''") & "', " & _
    '    '                        "'" & Replace(circdate, "'", "''") & "') "
    '    '     'lbldebug.Text = mysql
    '    '     'lblBy.Text = mysql
    '    '     'to prevent multiple submits
    '    '     txtSub1.Text = ""
    '    '     circdate = Nothing

    '    '     If insertRecord(mysql) Then
    '    '         lblBy2.Text = "Your feedback has been Submitted. Thank You :)"
    '    '     Else
    '    '         lblBy2.Text = "unable to insert " + mysql
    '    '     End If

    'End Sub
End Class
