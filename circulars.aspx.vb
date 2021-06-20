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
            Session("CurrentQuery") = "SELECT * from circulars ORDER BY cdate DESC"
            
        End If

        If Session("eid") <> "" Then
            btnSubmit.Enabled = True
            lbSignin.Visible = False
            lblBy.Text = "Uploaded by: " + Session("name") + " " + Session("designation") + " " + Session("dept")
            imgUser.ImageUrl = "database\pics\p" + Session("eid") + ".gif"
            lblName.Text = Session("name")
            lblEid.Text = "Eid : " + Session("eid")
            lblDept.Text = Session("dept")

        Else
            imgUser.ImageUrl = "database\pics\anonymous.gif"
        End If
        'this will be executed every time any event happen on web page

        ' Bind GridView to current query & always store ur queery into session("currentquery") before calling
        ' reason is whenever page indexed changed or sort.. then it will show data from currentquery

        rebindGridView(Session("CurrentQuery"), gvCirculars)

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

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If (afuFile.HasFile) Then
            'check file is attached or not
            Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(afuFile.FileName), " ", "_"))
            Dim circdate As Date
            circdate = txtDate.Text
            Dim mysql As String = "Insert Into circulars ( cno, sub, name , dept, filename, cdate, eid)" & _
       "VALUES  (" & _
                "'" & Replace(txtCno.Text, "'", "''") & "', " & _
                "'" & Replace(txtSub.Text, "'", "''") & "', " & _
                "'" & Replace(Session("name"), "'", "''") & "', " & _
                "'" & Replace(Session("dept"), "'", "''") & "', " & _
                "'" & Replace(TheFile, "'", "''") & "', " & _
                "'" & Replace(circdate, "'", "''") & "', " & _
                               "'" & Replace(Session("eid"), "'", "''") & "') "
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
                    lblMsg.Text = TheFile + " uploaded! " '+ mysql
                    rebindGridView(Session("CurrentQuery"), gvCirculars)

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
        rebindGridView(Session("CurrentQuery"), gvCirculars)
    End Sub

    
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Session("CurrentQuery") = "SELECT * from circulars where sub LIKE '%" + Trim(txtSearch.Text) + "%'"
        rebindGridView(Session("CurrentQuery"), gvCirculars)
    End Sub
End Class
