Imports System.Data
Imports System.Data.SqlClient
Imports databaseconn
Imports filter
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If String.IsNullOrEmpty(Request.Params("bookdate")) Then
                Response.Redirect("http://localhost:49848/onlinebook/booking1.aspx")
            End If

            Dim dt_journey As Date = CDate(Request.Params("bookdate"))
            lblDate.Text = "Journey Date: " + Str(Day(Request.Params("bookdate"))) + " " + MonthName(Month(Request.Params("bookdate"))) + " " + Str(Year(Request.Params("bookdate"))) + "  Booking Status Print"
            Dim t1 As Boolean = showdata(dt_journey)
            If (t1) Then
                Response.Write("<script language='javascript'>window.print();</script>")
            End If

        End If
        '   lblDate.Text = "SELECT        book_date, seat1, seat2, seat3, seat4, seat5, seat6, seat7, seat8, seat9, seat10, seat11, seat12, seat13, seat14 from welfare where month(book_date) = " + Str(Month(Request.Params("bookdate"))) + ""
        rebindGridView("SELECT       convert(varchar,book_date, 104) as book_date, seat1, seat2, seat3, seat4, seat5, seat6, seat7, seat8, seat9, seat10, seat11, seat12, seat13, seat14 from welfare where month(book_date) = " + Str(Month(Request.Params("bookdate"))) + "", gvWelfare)
    End Sub
    Private Function showdata(ByVal bdate As Date) As Boolean
        ' it will check if date exist . if date not exist than insert date else pick the data
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            ' connection.Close()
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

                    ' txtDate.Text = "availabe"

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
                    Dim tt As String = Session("seat1")
                    If Session("seat1") = "1" Or Session("seat1") = "" Then
                        lblSeat1.Text = "Not Booked"
                    Else
                        lblSeat1.Text = Session("seat1") + "  " + Getempdetail(Left(Session("Seat1"), 6))
                    End If

                    If Session("seat2") = "1" Or Session("seat2") = "" Then
                        lblSeat2.Text = "Not Booked"
                    Else
                        lblSeat2.Text = Session("seat2") + "  " + Getempdetail(Left(Session("Seat2"), 6))
                    End If
                    If Session("seat3") = "1" Or Session("seat3") = "" Then
                        lblSeat3.Text = "Not Booked"
                    Else
                        lblSeat3.Text = Session("seat3") + "  " + Getempdetail(Left(Session("Seat3"), 6))
                    End If
                    If Session("seat4") = "1" Or Session("seat4") = "" Then
                        lblSeat4.Text = "Not Booked"
                    Else
                        lblSeat4.Text = Session("seat4") + "  " + Getempdetail(Left(Session("Seat4"), 6))
                    End If
                    If Session("seat5") = "1" Or Session("seat5") = "" Then
                        lblSeat5.Text = "Not Booked"
                    Else
                        lblSeat5.Text = Session("seat5") + "  " + Getempdetail(Left(Session("Seat5"), 6))
                    End If
                    If Session("seat6") = "1" Or Session("seat6") = "" Then
                        lblSeat6.Text = "Not Booked"
                    Else
                        lblSeat6.Text = Session("seat6") + "  " + Getempdetail(Left(Session("Seat6"), 6))
                    End If
                    If Session("seat7") = "1" Or Session("seat7") = "" Then
                        lblSeat7.Text = "Not Booked"
                    Else
                        lblSeat7.Text = Session("seat7") + "  " + Getempdetail(Left(Session("Seat7"), 6))
                    End If
                    If Session("seat8") = "1" Or Session("seat8") = "" Then
                        lblSeat8.Text = "Not Booked"
                    Else
                        lblSeat8.Text = Session("seat8") + "  " + Getempdetail(Left(Session("Seat8"), 6))
                    End If
                    If Session("seat9") = "1" Or Session("seat9") = "" Then
                        lblSeat9.Text = "Not Booked"
                    Else
                        lblSeat9.Text = Session("seat9") + "  " + Getempdetail(Left(Session("Seat9"), 6))
                    End If
                    If Session("seat10") = "1" Or Session("seat10") = "" Then
                        lblSeat10.Text = "Not Booked"
                    Else
                        lblSeat10.Text = Session("seat10") + "  " + Getempdetail(Left(Session("Seat10"), 6))
                    End If
                    If Session("seat11") = "1" Or Session("seat11") = "" Then
                        lblSeat11.Text = "Not Booked"
                    Else
                        lblSeat11.Text = Session("seat11") + "  " + Getempdetail(Left(Session("Seat11"), 6))
                    End If
                    If Session("seat12") = "1" Or Session("seat12") = "" Then
                        lblSeat12.Text = "Not Booked"
                    Else
                        lblSeat12.Text = Session("seat12") + "  " + Getempdetail(Left(Session("Seat12"), 6))
                    End If

                    Session.Timeout = 30
                    connection.Close()



                    Return True
                Else

                    '' all seats available for this date.. no records found ' date doesnt exist s o exit



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
   

    Private Function Getempdetail(ByVal eid As String) As String
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            ' connection.Close()
            connection.Open()
            Dim sqlComm As SqlCommand

            Dim sqlReader As SqlDataReader

            Dim dt As New DataTable()

            Dim dataTableRowCount As Integer
            Dim empdata As String = ""
            Try
                sqlComm = New SqlCommand("select eid, fname, lname, cell from empdetail WHERE (eid = '" & eid & "')", connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                dataTableRowCount = dt.Rows.Count


                If dataTableRowCount = 1 Then

                    'empdata = empdata + " " + UCase(dt.Rows(0).Item("fname"))
                    empdata = empdata + " " + UCase(Left(dt.Rows(0).Item("fname"), 1)) + LCase(Mid(dt.Rows(0).Item("fname"), 2)) + " " + UCase(Left(dt.Rows(0).Item("lname"), 1)) + LCase(Mid(dt.Rows(0).Item("lname"), 2))
                    empdata = empdata + " Cell: " + dt.Rows(0).Item("cell")
                    sqlReader.Close()
                    connection.Close()
                    Getempdetail = empdata


                Else

                    ' date doesnt exist s o exit
                    sqlReader.Close()
                    connection.Close()
                    Getempdetail = "No Records"
                End If

            Catch e As Exception
                'lblDebug.text = e.Message

                connection.Close()
                Getempdetail = e.Message

            End Try
            connection.Close()
        End Using
    End Function
    

    Protected Sub gvWelfare_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvWelfare.SelectedIndexChanged

    End Sub
End Class
