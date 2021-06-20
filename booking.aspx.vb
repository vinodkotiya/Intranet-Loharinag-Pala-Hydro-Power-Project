Imports System.Data
Imports System.Data.SqlClient
Imports filter
Imports databaseconn

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Session("CurrentPage") = 0
            Session("SortExpression") = Nothing
            GridViewSortDirection = "ASC"
            If String.IsNullOrEmpty(Session("eid")) Then


                Response.Redirect("login.aspx?requestedpage=booking.aspx")
            End If
            'Dim empdata() As String = Split(Request.Params("empdata"), "*")
            'Session("eid") = empdata(0)

            ''Session("eid") = "101330"
            ' Session("query") = "select * from welfare where seat1 = '" & Session("eid") & "' OR seat2 = '" & Session("eid") & "' OR seat3 = '" & Session("eid") & "' OR seat4 = '" & Session("eid") & "' OR seat5 = '" & Session("eid") & "' OR seat6 = '" & Session("eid") & "' OR seat7 = '" & Session("eid") & "' OR seat8 = '" & Session("eid") & "' OR seat9 = '" & Session("eid") & "' OR seat10 = '" & Session("eid") & "' OR seat11 = '" & Session("eid") & "' OR seat12 = '" & Session("eid") & "'"
            Session("query") = "select convert(varchar, book_date, 104) as book_date, seat1, seat2, seat3, seat4, seat5, seat6, seat7, seat8, seat9, seat10, seat11, seat12 from welfare where LEFT(seat1, 6) = '" & Session("eid") & "' OR LEFT(seat2, 6) = '" & Session("eid") & "' OR LEFT(seat3, 6) = '" & Session("eid") & "' OR LEFT(seat4, 6) = '" & Session("eid") & "' OR LEFT(seat5, 6) = '" & Session("eid") & "' OR LEFT(seat6, 6) = '" & Session("eid") & "' OR LEFT(seat7, 6) = '" & Session("eid") & "' OR LEFT(seat8, 6) = '" & Session("eid") & "' OR LEFT(seat9, 6) = '" & Session("eid") & "' OR LEFT(seat10, 6) = '" & Session("eid") & "' OR LEFT(seat11, 6) = '" & Session("eid") & "' OR LEFT(seat12, 6) = '" & Session("eid") & "' ORDER BY book_date DESC"
            rebindGridView(Session("query"), gvHistorygrid)
        End If
        '  Session("query") = "select * from welfare where seat1 = '" & Session("eid") & "' OR seat2 = '" & Session("eid") & "' OR seat3 = '" & Session("eid") & "' OR seat4 = '" & Session("eid") & "' OR seat5 = '" & Session("eid") & "' OR seat6 = '" & Session("eid") & "' OR seat7 = '" & Session("eid") & "' OR seat8 = '" & Session("eid") & "' OR seat9 = '" & Session("eid") & "' OR seat10 = '" & Session("eid") & "' OR seat11 = '" & Session("eid") & "' OR seat12 = '" & Session("eid") & "'"
        If String.IsNullOrEmpty(Session("eid")) Then
            Response.Redirect("login.aspx?requestedpage=booking.aspx")

        ElseIf Not String.IsNullOrEmpty(Session("eid")) Then

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
        '  Session("query") = "select * from welfare where LEFT(seat1, 6) = '" & Session("eid") & "' OR LEFT(seat2, 6) = '" & Session("eid") & "' OR LEFT(seat3, 6) = '" & Session("eid") & "' OR LEFT(seat4, 6) = '" & Session("eid") & "' OR LEFT(seat5, 6) = '" & Session("eid") & "' OR LEFT(seat6, 6) = '" & Session("eid") & "' OR LEFT(seat7, 6) = '" & Session("eid") & "' OR LEFT(seat8, 6) = '" & Session("eid") & "' OR LEFT(seat9, 6) = '" & Session("eid") & "' OR LEFT(seat10, 6) = '" & Session("eid") & "' OR LEFT(seat11, 6) = '" & Session("eid") & "' OR LEFT(seat12, 6) = '" & Session("eid") & "'"
        Session("query") = "select convert(varchar, book_date, 104) as book_date, seat1, seat2, seat3, seat4, seat5, seat6, seat7, seat8, seat9, seat10, seat11, seat12 from welfare where LEFT(seat1, 6) = '" & Session("eid") & "' OR LEFT(seat2, 6) = '" & Session("eid") & "' OR LEFT(seat3, 6) = '" & Session("eid") & "' OR LEFT(seat4, 6) = '" & Session("eid") & "' OR LEFT(seat5, 6) = '" & Session("eid") & "' OR LEFT(seat6, 6) = '" & Session("eid") & "' OR LEFT(seat7, 6) = '" & Session("eid") & "' OR LEFT(seat8, 6) = '" & Session("eid") & "' OR LEFT(seat9, 6) = '" & Session("eid") & "' OR LEFT(seat10, 6) = '" & Session("eid") & "' OR LEFT(seat11, 6) = '" & Session("eid") & "' OR LEFT(seat12, 6) = '" & Session("eid") & "' ORDER BY book_date DESC"
        rebindGridView(Session("query"), gvHistorygrid)
        Button3.Visible = False 'cancel
        ' Button2.Visible = False 'book
        If Not String.IsNullOrEmpty(Session("canceled")) Then
            'lblMsg.Text = "yor ticket canceled"

            Response.Write("<script language='javascript'>window.alert('Your Seats " + Session("canceled") + " have been Canceled Succesfully');</script>")
            Session("canceled") = Nothing
        End If
    End Sub
    Function check_date(ByVal dte As String) As Boolean
        If (Not IsDate(dte)) Then
            Response.Write("<script language='javascript'>window.alert(' Please Enter a valid date in format mm/dd/yyyy or use calender ');</script>")
            Return False
        End If
        If (Date.Now > CDate(dte)) Then
            Response.Write("<script language='javascript'>window.alert('Cancelation and Booking are not permitted in previous dates');</script>")
            Return False
        End If
        If (CDate(dte).DayOfWeek = 1) Then
            Response.Write("<script language='javascript'>window.alert('Welfare Vehicle is not Available on Monday');</script>")
            Return False
        End If
        Return True
    End Function



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        '' show status ' 'txtDate.Text = "hello"
        If (check_date(txtDate.Text)) Then
            lblDate.Text = "Booking Status of Date: " + Str(Day(txtDate.Text)) + " " + MonthName(Month(txtDate.Text)) + " " + Str(Year(txtDate.Text))
            Button2.Visible = True
            Dim t2 As Date
            t2 = CDate(txtDate.Text)

            If showdata(t2) Then
                'return tru if date found means data found so populate it
                Button2.Enabled = True
            Else
                'date has been inserted , fields are blank, populate gain
                insertRecord("INSERT INTO welfare VALUES ('" & t2 & "','1','1','1','1','1','1','1','1','1','1','1','1','1','1')")
                showdata(t2)
            End If
            Button2.Visible = True 'book
            UpdatePanel3.Visible = True
            UpdatePanel2.Visible = False
            lblCdate.Text = ""
            ' lblMsg.Text = "Showing Status for Date:" + txtDate.Text
            'check date
            'dateinsert
            'populate ur checkbox using session var
        Else

        End If

    End Sub
    Function insertRecord(ByVal mysql As String) As Boolean

        'Create Connection String
        'Initlize all Database Varaibles
        '  Dim DBConn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\intradb.mdf;Integrated Security=True;User Instance=True")
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            'connection.Close()
            connection.Open()
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader


            Try
                sqlComm = New SqlCommand(mysql, connection)
                sqlReader = sqlComm.ExecuteReader()

                sqlReader.Close()
                sqlComm.Dispose()
                connection.Close()

                Return True


            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return False
            End Try
            connection.Close()
            insertRecord = True
        End Using
    End Function
    Private Function showdata(ByVal bdate As Date) As Boolean
        ' it will check if date exist . if date not exist than insert date else pick the data
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            'connection.Close()
            connection.Open()
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer

            Try
                sqlComm = New SqlCommand("select book_date, seat1, seat2, seat3, seat4, seat5, seat6, seat7, seat8, seat9, seat10, seat11, seat12 from welfare WHERE (book_date = '" & bdate & "')", connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                dataTableRowCount = dt.Rows.Count

                If dataTableRowCount = 1 Then

                    ' txtDate.Text = "Available"
                    Session("seat1") = dt.Rows(0).Item("seat1")
                    Session("seat2") = dt.Rows(0).Item("seat2")
                    Session("seat3") = dt.Rows(0).Item("seat3")
                    Session("seat4") = dt.Rows(0).Item("seat4")
                    Session("seat5") = dt.Rows(0).Item("seat5")
                    Session("seat6") = dt.Rows(0).Item("seat6")
                    Session("seat7") = dt.Rows(0).Item("seat7")
                    Session("seat8") = dt.Rows(0).Item("seat8")
                    Session("seat9") = dt.Rows(0).Item("seat9")
                    Session("seat10") = dt.Rows(0).Item("seat10")
                    Session("seat11") = dt.Rows(0).Item("seat11")
                    Session("seat12") = dt.Rows(0).Item("seat12")
                    If Session("seat1") = "1" Then
                        s1.Visible = True
                        cs1.ForeColor = Drawing.Color.Green
                        cs1.Text = "Available"
                        cs1.Enabled = True
                        cs1.Visible = True
                    Else

                        s1.Visible = True
                        cs1.Text = "Already booked by : " + Session("seat1") + " "    '+  getnamecell(session("seat1"))
                        cs1.Enabled = False
                        cs1.Visible = True
                    End If
                    If Session("seat2") = "1" Then
                        s2.Visible = True
                        cs2.ForeColor = Drawing.Color.Green
                        cs2.Text = "Available"
                        cs2.Enabled = True
                        cs2.Visible = True

                    Else

                        s2.Visible = True
                        cs2.Text = "Already booked by : " + Session("seat2")
                        cs2.Enabled = False
                        cs2.Visible = True
                    End If
                    If Session("seat3") = "1" Then
                        s3.Visible = True
                        cs3.ForeColor = Drawing.Color.Green
                        cs3.Text = "Available"
                        cs3.Enabled = True
                        cs3.Visible = True
                    Else
                        s3.Visible = True
                        cs3.Text = "Already booked by : " + Session("seat3")
                        cs3.Enabled = False
                        cs3.Visible = True
                    End If
                    If Session("seat4") = "1" Then
                        s4.Visible = True
                        cs4.ForeColor = Drawing.Color.Green
                        cs4.Text = "Available"
                        cs4.Enabled = True
                        cs4.Visible = True
                    Else
                        s4.Visible = True
                        cs4.Text = "Already booked by : " + Session("seat4")
                        cs4.Enabled = False
                        cs4.Visible = True
                    End If
                    If Session("seat5") = "1" Then
                        s5.Visible = True
                        cs5.ForeColor = Drawing.Color.Green
                        cs5.Text = "Available"
                        cs5.Enabled = True
                        cs5.Visible = True
                    Else
                        s5.Visible = True
                        cs5.Text = "Already booked by : " + Session("seat5")
                        cs5.Enabled = False
                        cs5.Visible = True
                    End If
                    If Session("seat6") = "1" Then
                        s6.Visible = True
                        cs6.ForeColor = Drawing.Color.Green
                        cs6.Text = "Available"
                        cs6.Enabled = True
                        cs6.Visible = True
                    Else
                        s6.Visible = True
                        cs6.Text = "Already booked by : " + Session("seat6")
                        cs6.Enabled = False
                        cs6.Visible = True
                    End If
                    If Session("seat7") = "1" Then
                        s7.Visible = True
                        cs7.ForeColor = Drawing.Color.Green
                        cs7.Text = "Available"
                        cs7.Enabled = True
                        cs7.Visible = True
                    Else
                        s7.Visible = True
                        cs7.Text = "Already booked by : " + Session("seat7")
                        cs7.Enabled = False
                        cs7.Visible = True
                    End If
                    If Session("seat8") = "1" Then
                        s8.Visible = True
                        cs8.ForeColor = Drawing.Color.Green
                        cs8.Text = "Available"
                        cs8.Enabled = True
                        cs8.Visible = True
                    Else
                        s8.Visible = True
                        cs8.Text = "Already booked by : " + Session("seat8")
                        cs8.Enabled = False
                        cs8.Visible = True
                    End If
                    If Session("seat9") = "1" Then
                        s9.Visible = True
                        cs9.ForeColor = Drawing.Color.Green
                        cs9.Text = "Available"
                        cs9.Enabled = True
                        cs9.Visible = True
                    Else
                        s9.Visible = True
                        cs9.Text = "Already booked by : " + Session("seat9")
                        cs9.Enabled = False
                        cs9.Visible = True
                    End If
                    If Session("seat10") = "1" Then
                        s10.Visible = True
                        cs10.ForeColor = Drawing.Color.Green
                        cs10.Text = "Available"
                        cs10.Enabled = True
                        cs10.Visible = True
                    Else
                        s10.Visible = True
                        cs10.Text = "Already booked by : " + Session("seat10")
                        cs10.Enabled = False
                        cs10.Visible = True
                    End If
                    If Session("seat11") = "1" Then
                        s11.Visible = True
                        cs11.ForeColor = Drawing.Color.Green
                        cs11.Text = "Available"
                        cs11.Enabled = True
                        cs11.Visible = True
                    Else
                        s11.Visible = True
                        cs11.Text = "Already booked by : " + Session("seat11")
                        cs11.Enabled = False
                        cs11.Visible = True
                    End If
                    If Session("seat12") = "1" Then
                        s12.Visible = True
                        cs12.ForeColor = Drawing.Color.Green
                        cs12.Text = "Available"
                        cs12.Enabled = True
                        cs12.Visible = True
                    Else
                        s12.Visible = True
                        cs12.Text = "Already booked by : " + Session("seat12")
                        cs12.Enabled = False
                        cs12.Visible = True
                    End If
                    Session.Timeout = 30
                    connection.Close()
                    sqlComm.Dispose()


                    Return True
                Else

                    ' date doesnt exist s o exit
                    sqlComm.Dispose()
                    connection.Close()
                    Return False
                End If
                sqlReader.Close()
            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return False
            End Try
            connection.Close()
        End Using
    End Function

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.TextChanged

    End Sub
    Function update(ByVal bdate As Date) As Boolean

        Dim ab As String
        Dim cd As String
        Dim ef As String
        Dim eid_declare As String = Session("eid") + "#" + rbDeclare.SelectedValue
        ef = ""
        ab = "update welfare set"
        If cs1.Checked = True Then
            ef = " seat1 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs1.Checked = False

        End If
        If cs2.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat2 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs2.Checked = False
        End If
        If cs3.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat3 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs3.Checked = False
        End If
        If cs4.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat4 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs4.Checked = False
        End If
        If cs5.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat5 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs5.Checked = False
        End If
        If cs6.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat6 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs6.Checked = False
        End If
        If cs7.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat7 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs7.Checked = False
        End If
        If cs8.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat8 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs8.Checked = False
        End If
        If cs9.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat9 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs9.Checked = False
        End If
        If cs10.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat10 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs10.Checked = False
        End If
        If cs11.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat11 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs11.Checked = False
        End If
        If cs12.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat12 =" + "'" + eid_declare + "'"
            ab = ab + ef
            cs12.Checked = False
        End If
        cd = DateAndTime.DateValue(bdate.ToString)
        ab = ab + " where book_date= " + "'" + cd + "'"
        ' CheckBox1.Text = ab
        If insertRecord(ab) Then
            'lblMsg.Text = "Booked"
            Return True
        Else
            ' lblMsg.Text = "Not Booked"
            Return False
        End If
    End Function
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        '' booking button
        Dim t2 As Date

        t2 = DateAndTime.DateValue(txtDate.Text)
        Dim t3 As Boolean
        t3 = update(t2)
        If t3 Then
            showdata(t2)
            UpdatePanel3.Visible = True
            rebindGridView(Session("query"), gvHistorygrid)
            ' lblMsg.Text = " Your seat have been booked"
            'Button2.Enabled = False
        End If

    End Sub



    Protected Sub gvHistorygrid_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvHistorygrid.PageIndexChanging
        If gvHistorygrid.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvHistorygrid.DataSource = SortDataTable(gvHistorygrid.DataSource, True)
            gvHistorygrid.PageIndex = e.NewPageIndex
            Session("CurrentPage") = e.NewPageIndex
            gvHistorygrid.DataBind()

        End If
    End Sub
    'Protected Sub gvHistorygrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvHistorygrid.SelectedIndexChanged
    '    ' Get the currently selected row using the SelectedRow property.
    '    Dim row As GridViewRow = gvHistorygrid.SelectedRow

    '    ' Display the company name from the selected row.
    '    ' In this example, the third column (index 2) contains
    '    ' the company name.
    '    txtDate.Text = row.Cells(1).Text
    '    ' Bind current data
    '    gvHistorygrid.DataSource = SortDataTable(gvHistorygrid.DataSource, True)
    '    gvHistorygrid.PageIndex = Session("CurrentPage")
    '    gvHistorygrid.DataBind()

    '    ' Clear session variables
    '    Session("CurrentPage") = Nothing
    '    Session("SortExpression") = Nothing
    '    Session("CurrentQuery") = Nothing

    'End Sub

    Protected Sub gvHistorygrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvHistorygrid.SelectedIndexChanged

        Dim txt As String
        ' Dim txtarr As String
        Dim cd As Date
        Dim txtarr As String()
        txt = gvHistorygrid.SelectedRow.Cells(0).Text
        'txtDate.Text = txt
        lblCdate.Text = "Select the seat to cancel For journey Date: " + txt
        UpdatePanel3.Visible = False
        UpdatePanel2.Visible = True
        'dd.mm.yyyy
        'txt = Replace(txt, ".", "/")
        txtarr = Split(txt, ".")
        txt = txtarr(1) + "/" + txtarr(0) + "/" + txtarr(2)
        Session("candate") = txt


        cd = DateAndTime.DateValue(CDate(txt))
        showCancelationData(cd)
        Button3.Visible = True 'cancel
        Button2.Visible = False 'book

        'gvHistorygrid.DataSource = SortDataTable(gvHistorygrid.DataSource, True)
        'gvHistorygrid.PageIndex = Session("CurrentPage")
        'gvHistorygrid.DataBind()

        '' Clear session variables
        'Session("CurrentPage") = Nothing
        'Session("SortExpression") = Nothing
        'Session("Query") = Nothing
    End Sub
    Private Function showCancelationData(ByVal bdate As Date) As Boolean
        ' it will check if date exist . if date not exist than insert date else pick the data
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            'connection.Close()
            connection.Open()

            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            '' clear all previous seat history
            c1.Visible = False
            c2.Visible = False
            c3.Visible = False
            c4.Visible = False
            c5.Visible = False
            c6.Visible = False
            c7.Visible = False
            c8.Visible = False
            c9.Visible = False
            c10.Visible = False
            c11.Visible = False
            c12.Visible = False
            cc1.Visible = False
            cc2.Visible = False
            cc3.Visible = False
            cc4.Visible = False
            cc5.Visible = False
            cc6.Visible = False
            cc7.Visible = False
            cc8.Visible = False
            cc9.Visible = False
            cc10.Visible = False
            cc11.Visible = False
            cc12.Visible = False
            cc1.Checked = False
            cc2.Checked = False
            cc3.Checked = False
            cc4.Checked = False
            cc5.Checked = False
            cc6.Checked = False
            cc7.Checked = False
            cc8.Checked = False
            cc9.Checked = False
            cc10.Checked = False
            cc11.Checked = False
            cc12.Checked = False
            Try
                sqlComm = New SqlCommand("select book_date,seat1, seat2, seat3, seat4, seat5, seat6, seat7, seat8, seat9, seat10, seat11, seat12 from welfare WHERE (book_date = '" & bdate & "')", connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                dataTableRowCount = dt.Rows.Count

                If dataTableRowCount = 1 Then

                    ' txtDate.Text = "Available"

                    Session("seat1") = Left(dt.Rows(0).Item("seat1"), 6)
                    Session("seat2") = Left(dt.Rows(0).Item("seat2"), 6)
                    Session("seat3") = Left(dt.Rows(0).Item("seat3"), 6)
                    Session("seat4") = Left(dt.Rows(0).Item("seat4"), 6)
                    Session("seat5") = Left(dt.Rows(0).Item("seat5"), 6)
                    Session("seat6") = Left(dt.Rows(0).Item("seat6"), 6)
                    Session("seat7") = Left(dt.Rows(0).Item("seat7"), 6)
                    Session("seat8") = Left(dt.Rows(0).Item("seat8"), 6)
                    Session("seat9") = Left(dt.Rows(0).Item("seat9"), 6)
                    Session("seat10") = Left(dt.Rows(0).Item("seat10"), 6)
                    Session("seat11") = Left(dt.Rows(0).Item("seat11"), 6)
                    Session("seat12") = Left(dt.Rows(0).Item("seat12"), 6)
                    If Session("seat1") = Session("eid") Then
                        c1.Visible = True

                        cc1.Text = "Cancel"
                        cc1.Enabled = True
                        cc1.Visible = True
                        ' Else
                        '    s1.Visible = True
                        '   CheckBox1.Text = "Already booked by : " + Session("seat1")
                        '  CheckBox1.Enabled = False
                        ' CheckBox1.Visible = True
                    End If
                    If Session("seat2") = Session("eid") Then
                        c2.Visible = True

                        cc2.Text = "Cancel"
                        cc2.Enabled = True
                        cc2.Visible = True

                        ' Else
                        '    s2.Visible = True
                        '   CheckBox2.Text = "Already booked by : " + Session("seat2")
                        '  CheckBox2.Enabled = False
                        ' CheckBox2.Visible = True
                    End If
                    If Session("seat3") = Session("eid") Then
                        c3.Visible = True
                        cc3.Text = "Cancel"
                        cc3.Enabled = True
                        cc3.Visible = True
                        'Else
                        '   s3.Visible = True
                        '  CheckBox3.Text = "Already booked by : " + Session("seat3")
                        ' CheckBox3.Enabled = False
                        'CheckBox3.Visible = True
                    End If
                    If Session("seat4") = Session("eid") Then
                        c4.Visible = True
                        cc4.Text = "Cancel"
                        cc4.Enabled = True
                        cc4.Visible = True

                    End If
                    If Session("seat5") = Session("eid") Then
                        c5.Visible = True
                        cc5.Text = "Cancel"
                        cc5.Enabled = True
                        cc5.Visible = True

                    End If
                    If Session("seat6") = Session("eid") Then
                        c6.Visible = True
                        cc6.Text = "Cancel"
                        cc6.Enabled = True
                        cc6.Visible = True

                    End If
                    If Session("seat7") = Session("eid") Then
                        c7.Visible = True
                        cc7.Text = "Cancel"
                        cc7.Enabled = True
                        cc7.Visible = True

                    End If
                    If Session("seat8") = Session("eid") Then
                        c8.Visible = True
                        cc8.Text = "Cancel"
                        cc8.Enabled = True
                        cc8.Visible = True

                    End If
                    If Session("seat9") = Session("eid") Then
                        c9.Visible = True
                        cc9.Text = "Cancel"
                        cc9.Enabled = True
                        cc9.Visible = True

                    End If
                    If Session("seat10") = Session("eid") Then
                        c10.Visible = True
                        cc10.Text = "Cancel"
                        cc10.Enabled = True
                        cc10.Visible = True

                    End If
                    If Session("seat11") = Session("eid") Then
                        c11.Visible = True
                        cc11.Text = "Cancel"
                        cc11.Enabled = True
                        cc11.Visible = True

                    End If
                    If Session("seat12") = Session("eid") Then
                        c12.Visible = True
                        cc12.Text = "Cancel"
                        cc12.Enabled = True
                        cc12.Visible = True

                    End If
                    Session.Timeout = 30
                    connection.Close()
                    '   Button2.Visible = True


                    Return True
                Else

                    ' insertRecord("INSERT INTO welfare VALUES ('" & bdate & "','1','1','1')")

                    connection.Close()
                    Return False
                End If
                sqlComm.Dispose()
                sqlReader.Close()
            Catch e As Exception
                'lblDebug.text = e.Message
                connection.Close()
                Return False
            End Try
            connection.Close()
        End Using
    End Function
    Function seatcancellation(ByVal bdate As Date) As String
        ' take date and return query
        Dim ab As String
        Dim cd As String
        Dim ef As String
        ef = ""
        ab = "update welfare set"
        If cc1.Checked = True Then
            ef = " seat1 =" + "'" + "1" + "'"
            ab = ab + ef
            cc1.Checked = False

        End If
        If cc2.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat2 =" + "'" + "1" + "'"
            ab = ab + ef
            cc2.Checked = False
        End If
        If cc3.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat3 =" + "'" + "1" + "'"
            ab = ab + ef
            cc3.Checked = False
        End If
        If cc4.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat4 =" + "'" + "1" + "'"
            ab = ab + ef
            cc4.Checked = False
        End If
        If cc5.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat5 =" + "'" + "1" + "'"
            ab = ab + ef
            cc5.Checked = False
        End If
        If cc6.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat6 =" + "'" + "1" + "'"
            ab = ab + ef
            cc6.Checked = False
        End If
        If cc7.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat7 =" + "'" + "1" + "'"
            ab = ab + ef
            cc7.Checked = False
        End If
        If cc8.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat8 =" + "'" + "1" + "'"
            ab = ab + ef
            cc8.Checked = False
        End If
        If cc9.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat9 =" + "'" + "1" + "'"
            ab = ab + ef
            cc9.Checked = False
        End If
        If cc10.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat10 =" + "'" + "1" + "'"
            ab = ab + ef
            cc10.Checked = False
        End If
        If cc11.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat11 =" + "'" + "1" + "'"
            ab = ab + ef
            cc11.Checked = False
        End If
        If cc12.Checked = True Then
            If ef <> "" Then
                ab = ab + ","
            End If
            ef = " seat12 =" + "'" + "1" + "'"
            ab = ab + ef
            cc12.Checked = False
        End If
        If String.IsNullOrEmpty(ef) Then   'no seats selected for cancelation
            Return ""
        Else
            cd = DateAndTime.DateValue(bdate.ToString)
            ab = ab + " where book_date= " + "'" + cd + "'"
            Return ab
        End If
    End Function

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        If (check_date(Session("candate"))) Then  'do not permit to cancel history of seats
            Dim updatequery As String
            updatequery = seatcancellation(Session("candate"))
            UpdatePanel2.Visible = False
            If String.IsNullOrEmpty(updatequery) Then
                Response.Write("<script language='javascript'>window.alert('You must select atleast 1 seat for cancelation.');</script>")
                Exit Sub    'no seats selected for cancelation
            End If
            If (insertRecord(updatequery)) Then

                ' lblMsg .Text = "Your seats have been canceled succesfully"
            Else

                ' lblMsg.Text = "Not able to cancel, error occured"
            End If
            'rebindGridView(Session("query"), gvHistorygrid)
            'Response.Write("<script language='javascript'>window.alert('Please enter file name');</script>")

            Dim st As String = Replace(Right(updatequery, Len(updatequery) - 17), "='1'", "  ")
            st = Left(st, Len(st) - 31)
            Session("canceled") = st
            Response.Redirect("booking.aspx")
        End If
    End Sub


    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        If (check_date1(txtDate.Text)) Then
            Response.Redirect("print.aspx?bookdate=" & txtDate.Text)
        End If
    End Sub


    Function check_date1(ByVal dte As String) As Boolean
        If (Not IsDate(dte)) Then
            Response.Write("<script language='javascript'>window.alert(' Please Enter a valid date in format mm/dd/yyyy or use calender ');</script>")
            Return False
        End If

        Return True
    End Function

End Class