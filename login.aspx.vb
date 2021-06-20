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
            'Session("CurrentPage") = 0
            'Session("SortExpression") = Nothing
            'GridViewSortDirection = "ASC"
            ' Set current query
            If Request.Params("signout") = 1 And Not String.IsNullOrEmpty(Session("eid")) Then 'signout only once 
                clearsession()
                Response.Redirect("http://191.254.186.1:3431/default.aspx?signout=1")
            End If

        End If
        'this will be executed every time any event happen on web page
        ''page parameter inputs.. "requestedpage"

        'kisi page me session expire ho gaya hai.. login kara ke wapas bhejne ke liye

        If Not String.IsNullOrEmpty(Session("eid")) Then


            lblName.Text = Session("name") & _
            "<br/>Eid : " + Session("eid") & _
            "<br/>" + Session("dept") + "<br/><a href=login.aspx?signout=1> Log Out </a>"

        Else
            lblName.Text = "Guest: " + Request.UserHostAddress
        End If
        Session("requestedpage") = Request.Params("requestedpage")


        If InStr(Session("requestedpage"), "3431") > 0 And (Not String.IsNullOrEmpty(Session("eid"))) Then
            Dim empdata As String = "?empdata=" + Session("eid") + "*" + Session("name") + "*" + Session("dept") + "*" + Session("designation")

            empdata = Replace(empdata, "&", "%26")
            ' & wont pass as parameter so replace it with %26,
            'lblMessage.Text = str & empdata

            Response.Redirect(Session("requestedpage") + empdata)
        End If

    End Sub

    

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
       
        If Authenticateuser(txtEid.Text, txtPwd.Text) Then
            '' id pwd valid then enter here and now create a session for user by retrieving his details
            'If createSession(Session("eid")) Then
            lblMessage.Text = " login succesfull "

            'End If
            If createSession(Session("eid")) Then
                If isPwdDate(txtPwd.Text) Then    '' if pasword is a birth date then return true and force to change
                    Response.Redirect("uploader.aspx?mode=profile&eid=" + txtEid.Text)
                End If
                If String.IsNullOrEmpty(Session("requestedpage")) Then       'refresh the page with pageload event code
                    Response.Redirect("default.aspx?loginsuccesful")
                Else
                    Dim empdata As String = "?empdata=" + Session("eid") + "*" + Session("name") + "*" + Session("dept") + "*" + Session("designation")

                    empdata = Replace(empdata, "&", "%26")
                    ' & wont pass as parameter so replace it with %26,
                    'lblMessage.Text = str & empdata
                    If InStr(Session("requestedpage"), "3431") > 0 Then
                        Response.Redirect(Session("requestedpage") + empdata)     '2("filemgr.aspx") '1?hostname=" & System.Web.HttpUtility.UrlEncode(hostname.Text))
                        'empdata.ToString.Replace("0", "x") 
                    ElseIf InStr(Session("requestedpage"), "49931") > 0 Then
                        Response.Redirect(Session("requestedpage") + empdata)     '2("filemgr.aspx") '1?hostname=" & System.Web.HttpUtility.UrlEncode(hostname.Text))
                        'empdata.ToString.Replace("0", "x") 
                    Else
                        Response.Redirect(Session("requestedpage"))
                    End If
                End If
            Else
                lblMessage.Text = " login succesfull but employee not found. Contact Web admin"

            End If


        Else
            txtEid.Text = ""
            txtEid.Enabled = True
            txtPwd.Text = ""
            lblMessage.Text = "Wrong employee ID or password entered. Please Sign In again."

        End If
    End Sub
    Private Function isPwdDate(ByVal pwd As String) As Boolean
        '' if pasword is a birth date then return true and force to change
        Dim txtarr As String()

        txtarr = Split(pwd, ".")
        If txtarr.Length = 3 Then  'if txtarr has date format 
            If IsDate(txtarr(1) + "/" + txtarr(0) + "/" + txtarr(2)) Then
                Return True
            Else
                Return False
            End If

        Else
            Return False
        End If
    End Function
    Private Function Authenticateuser(ByVal name As String, ByVal pwd As String) As Boolean
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            ' connection.Close()
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
                    Session("eid") = name
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

    Private Function createSession(ByVal eid As String) As Boolean
        Using connection As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("vinConn").ConnectionString)
            'connection.Close()
            connection.Open()
            Dim sqlComm As SqlCommand
            Dim sqlReader As SqlDataReader
            Dim dt As New DataTable()
            Dim dataTableRowCount As Integer
            Try
                sqlComm = New SqlCommand("select eid, fname, lname, dept, designation from empdetail WHERE (eid = '" + eid + "') ", connection)
                sqlReader = sqlComm.ExecuteReader()
                dt.Load(sqlReader)
                dataTableRowCount = dt.Rows.Count
                ''Strings.Format(Session("name"), "capetalize")
                If dataTableRowCount = 1 Then
                    'capetalize the name.
                    Session("eid") = eid
                    Session("name") = UCase(Left(dt.Rows(0).Item("fname"), 1)) + LCase(Mid(dt.Rows(0).Item("fname"), 2)) + " " + UCase(Left(dt.Rows(0).Item("lname"), 1)) + LCase(Mid(dt.Rows(0).Item("lname"), 2))
                    Session("dept") = dt.Rows(0).Item("dept")
                    Session("designation") = dt.Rows(0).Item("designation")
                    Session.Timeout = 30
                    connection.Close()
                    Return True
                Else
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
End Class
