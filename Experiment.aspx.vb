Imports System.Data
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gridRefresh("select * from test")

    End Sub





    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        imgProgress.ImageUrl = "images/loading.gif"

        If (FileUpload1.HasFile) Then


            Try
                Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(FileUpload1.FileName), " ", "_"))

                FileUpload1.SaveAs(Server.MapPath("~/database/") + TheFile)
                Label1.Text = TheFile + " uploaded!"
                Label1.Visible = False


            Catch Exc As Exception

                Label1.Text = "Upload status: The file could not be uploaded. The following error occured: " + Exc.Message
            End Try

            imgProgress.ImageUrl = "images/loading1.gif"
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim TheFile As String
        If (AsyncFileUpload2.HasFile) Then
            TheFile = Strings.LCase(Replace(System.IO.Path.GetFileName(AsyncFileUpload2.FileName), " ", "_"))
        Else
            Label2.Text = " No files To attach"
            Exit Sub
        End If

        Dim mysql As String = "Insert Into test ( name, filename)" & _
       "VALUES  (" & _
                "'" & Replace(TextBox2.Text, "'", "''") & "', " & _
                               "'" & Replace(TheFile, "'", "''") & "') "
        If insertRecord(mysql) = False Then
            Label2.Text = "Unable to insert :-  " & mysql
            Return
        Else
            TextBox2.Text = ""

        End If
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click

        If (AsyncFileUpload1.HasFile) Then
            Try
                Dim TheFile As String = Strings.LCase(Replace(System.IO.Path.GetFileName(AsyncFileUpload1.FileName), " ", "_"))

                AsyncFileUpload1.SaveAs(Server.MapPath("~/database/") + TheFile)
                Label1.Text = TheFile + " uploaded!"


            Catch Exc As Exception

                Label1.Text = "Error occured: " + Exc.Message
            End Try

            imgProgress.ImageUrl = "images/loading1.gif"
        End If
    End Sub

    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click

    End Sub
    Function insertRecord(ByVal mysql As String) As Boolean
        
        'Create Connection String
        'Initlize all Database Varaibles
        'Dim DBConn As New SqlConnection("UID=YourID;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=circulars;Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\intradb.mdf;Integrated Security=True;User Instance=True")
        Dim DBConn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\intradb.mdf;Integrated Security=True;User Instance=True")
        Dim DBCmd As New SqlCommand
        Dim DBAdap As New SqlDataAdapter
        Dim DS As New DataSet
        DBConn.Open()

        Try

            'Add Insert Statement
            'DBCmd = New SqlCommand("INSERT INTO UserRecord(UserName, ContactNumber, Address, Country) VALUES (@UserName, @ContactNumber, @Address, @Country)", DBConn)
            DBCmd = New SqlCommand(mysql, DBConn)
            'Add Database Parameters
            'DBCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = txtName.Text
            'DBCmd.Parameters.Add("@ContactNumber", SqlDbType.NChar).Value = txtCNumber.Text
            'DBCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text
            'DBCmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = ddlCountry.SelectedItem.Text
            DBCmd.ExecuteNonQuery()
            Label2.Text = "Inserted "

            'Set the value of DataAdapter
            'DBAdap = New SqlDataAdapter("SELECT * FROM table1", DBConn)
            'Fill the DataSet
            'DBAdap.Fill(DS)
            'Bind with GridView control and Display the Record
            'gvShowRecord.DataSource = DS
            'gvShowRecord.DataBind()

        Catch exp As Exception
            Label2.Text = exp.Message
            insertRecord = False

        End Try
        'Close Database connection
        'and Dispose Database objects
        DBCmd.Dispose()
        DBAdap.Dispose()
        DBConn.Close()
        DBConn = Nothing
        insertRecord = True

    End Function
    Function gridRefresh(ByVal mysql As String) As Boolean
        'Create Connection String
        'Initlize all Database Varaibles
        Dim DBConn As New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\intradb.mdf;Integrated Security=True;User Instance=True")

        Dim DBAdap As New SqlDataAdapter
        Dim DS As New DataSet
        DBConn.Open()

        Try


            'Set the value of DataAdapter
            DBAdap = New SqlDataAdapter(mysql, DBConn)
            'Fill the DataSet
            DBAdap.Fill(DS)
            'Bind with GridView control and Display the Record
            ' Label2.Text = Str(DS.) + " rows"
            gvData.DataSource = DS
            gvData.DataBind()


        Catch exp As Exception
            Label2.Text = exp.Message
            gridRefresh = False
            DBConn.Close()
        End Try
        'Close Database connection
        'and Dispose Database objects

        DBAdap.Dispose()
        DBConn.Close()
        DBConn = Nothing
        gridRefresh = True
    End Function


    Protected Sub btnupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim mysql As String = "UPDATE  test SET filename = 'hopooo' WHERE        (name = 'vin') "
        If insertRecord(mysql) = False Then
            Label2.Text = "Unable to insert :-  " & mysql
            Return
        End If
        'System.Configuration.ConfigurationManager.ConnectionStrings("xyz").ConnectionString 
        '"EXEC basicSearch  " & txtSearch.Text 
        If gridRefresh(" select * from test where name like '%vin%'") = False Then
            Label2.Text = "Unable to refresh :-  " & mysql
            Return
        End If
    End Sub

    Private Sub gvData_PageIndexChanging(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        '    ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs
        gvData.PageIndex = e.NewPageIndex
        gvData.DataBind()

    End Sub
    'Protected Sub gvdata_sorting(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvData.Sorting
    'Dim ds As New DataSet
    '   ds = gvData.DataSource
    '  If (ds.Tables(0).Rows.Count <> 0) Then
    'Dim dv As New Data.DataView
    'dv = ds.Tables(0)
    'dv.Sort



    '   End If






    'End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class
  
