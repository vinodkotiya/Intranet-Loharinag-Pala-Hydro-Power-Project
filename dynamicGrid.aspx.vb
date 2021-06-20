Imports System.Data
Imports System.Data.SqlClient
Imports filter
Imports databaseconn
Partial Class dynamicGrid
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'this will be executed only first time any event happen on web page
            ' Clear user paging/sort
            Session("CurrentPage") = 0
            Session("SortExpression") = Nothing
            GridViewSortDirection = "ASC"
            ' Set current query
            Session("CurrentQuery") = "SELECT * from circulars"
        End If
        'this will be executed every time any event happen on web page

        ' Bind GridView to current query & always store ur queery into session("currentquery") before calling
        ' reason is whenever page indexed changed or sort.. then it will show data from currentquery

        rebindGridView(Session("CurrentQuery"), gvMygrid)
        ' Session("CurrentQuery") = "select * from test"
        ' rebindGridView(Session("CurrentQuery"), GridView1)

    End Sub
    Protected Sub gvMygrid_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvMygrid.PageIndexChanging
        If gvMygrid.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvMygrid.DataSource = SortDataTable(gvMygrid.DataSource, True)
            gvMygrid.PageIndex = e.NewPageIndex
            Session("CurrentPage") = e.NewPageIndex
            gvMygrid.DataBind()
        End If
    End Sub
    Protected Sub gvMygrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMygrid.SelectedIndexChanged
        ' Bind current data
        gvMygrid.DataSource = SortDataTable(gvMygrid.DataSource, True)
        gvMygrid.PageIndex = Session("CurrentPage")
        gvMygrid.DataBind()

        ' <This is the row the user selected -- do with it what you want>
        'supplierNumber.Text = gvMygrid.SelectedRow.Cells(1).Text
        'supplierName.Text = gvMygrid.SelectedRow.Cells(2).Text
        'supplierStreet.Text = gvMygrid.SelectedRow.Cells(3).Text



        ' Clear session variables
        Session("CurrentPage") = Nothing
        Session("SortExpression") = Nothing
        Session("CurrentQuery") = Nothing

    End Sub
    Protected Sub gvMygrid_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvMygrid.Sorting
        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = gvMygrid.PageIndex
        If gvMygrid.DataSource.GetType().ToString = "System.Data.DataTable" Then
            gvMygrid.DataSource = SortDataTable(gvMygrid.DataSource, False)
            gvMygrid.PageIndex = Session("CurrentPage")
            gvMygrid.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mysql As String = "insert into test (name,filename) values('" + txtfname.Text + "', '" + txtname.Text + "')"
        If insertRecord(mysql) Then
            Session("CurrentQuery") = "select * from test"
            'rebindGridView(Session("CurrentQuery"), gvMygrid)
            lblmsg.Text = " insert " + mysql
            rebindGridView(Session("CurrentQuery"), GridView1)
        Else
            lblmsg.Text = " unable to insert " + mysql
        End If
    End Sub
End Class
