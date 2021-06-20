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
            ' txtSub1.Text = vbCrLf + vbCrLf + vbCrLf + "Name:"
            Session("CurrentQuery") = "SELECT feedback, fby, convert(varchar, fdate, 104) as fdate1 from feedback ORDER BY fdate DESC"
            rebindGridView(Session("CurrentQuery"), gvCirculars1)
        ElseIf TabContainer2.ActiveTabIndex = 4 Then
            afuFile.Visible = False
            afuFile0.Visible = False
            afufile1.Visible = False
            afufile4.Visible = True
            If Not String.IsNullOrEmpty(Session("eid")) Then
                lblBy4.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
                btnSubmit4.Enabled = True
                lbsignin4.Visible = False
            End If
            Session("CurrentQuery") = "SELECT filename, eid, convert(varchar, cdate, 104) as cdate1, dept from reports ORDER BY cdate DESC"
            rebindGridView(Session("CurrentQuery"), gvCirculars4)
        Else
            afuFile.Visible = False
            afuFile0.Visible = False
            afufile1.Visible = False
            afufile4.Visible = False
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
        Session("CurrentQuery") = "SELECT cno, sub , name ,dept, filename, eid , ipaddress, convert(varchar, cdate, 104) as cdate1, cdate from circulars where sub LIKE '%" + Trim(txtSearch.Text) + "%'"
        rebindGridView(Session("CurrentQuery"), gvCirculars)
    End Sub
    Protected Sub btnSearch0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch0.Click
        Session("CurrentQuery") = "SELECT topic, name, filename, eid, ipaddress, convert(varchar, cdate, 104) as cdate1, cdate from articles where topic LIKE '%" + Trim(txtSearch0.Text) + "%'"
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
            "'" & Replace(txtSub1.Text, "'", "''") & "', " & _
            "'" & Replace(fby, "'", "''") & "', " & _
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
End Class